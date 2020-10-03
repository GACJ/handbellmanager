using System;
using System.Collections.Generic;
using Microsoft.DirectX.DirectInput;

namespace MotionControllerManager
{
    /*  Motion Controller Control Class
     *  
     * This class enables the easy detection, enumeration, and reading of Motion Controllers attached to the system.
     * It requires Managed DirectInput and DirectX to run.
     * 
     * http://www.actionxl.com
     * 
     * (c) ActionXL 2007
     * Written by Benjamin Kalb
     * bkalb@actionxl.com
     * 
     * Edited to allow any joystick - GACJ Aug09
     * 
     */
    
    public class MotionControllerManager
    {
        List<Device> applicationDevices;
        List<JoystickState> currentStates, lastStates;
        List<MotionDetector> detectors;

        public List<Device> ApplicationDevices
        {
            get
            {
                return applicationDevices;
            }
        }

        /// <summary>
        /// The number of attached and detected Motion Controllers
        /// </summary>
        public int Count
        {
            get { return applicationDevices.Count; }
        }

        /// <summary>
        /// A Framework for using ActionXL Motion Controllers
        /// </summary>
        public MotionControllerManager()
        {
            applicationDevices = new List<Device>();
            currentStates = new List<JoystickState>();
            lastStates = new List<JoystickState>();
            detectors = new List<MotionDetector>();
        }

        /// <summary>
        /// Clear all currently detected joysticks and re-detect all joysticks attached to the system,
        /// enumerating all attached Motion Controllers.
        /// </summary>
        /// <param name="initDetecors">Whether or not to also initialize a motion detector for each joystick.</param>
        public void initialize(bool initDetecors)
        {
            //Reset stored Joysticks
            applicationDevices.Clear();
            currentStates.Clear();
            lastStates.Clear();
            //Initialize DirectInput
            // Enumerate Joysticks in the system.
            foreach (DeviceInstance instance in Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly))
            {
//DELETE				// Create the device.  Accept only Motion Controllers
//DELETE				if (instance.InstanceName == "Motion Controller")
//DELETE		{
                    applicationDevices.Add(new Device(instance.InstanceGuid));
                    currentStates.Add(new JoystickState());
                    lastStates.Add(new JoystickState());
//DELETE		}
            }

            if (applicationDevices.Count == 0)
            {
                //fail
            throw new NoMotionControllerFoundException("No Motion Controller Found");
            }

            //loop through all detected controllers and set axis parameters.
            foreach (Device applicationDevice in applicationDevices)
            {
                // Set the data format to the c_dfDIJoystick pre-defined format.
                applicationDevice.SetDataFormat(DeviceDataFormat.Joystick);

                // Enumerate all the objects on the device.
                foreach (DeviceObjectInstance d in applicationDevice.Objects)
                {
                    // For axes that are returned, set the DIPROP_RANGE property for the
                    // enumerated axis in order to scale min/max values.
                    if ((0 != (d.ObjectId & (int)DeviceObjectTypeFlags.Axis)))
                    {
                        // Set the range for the axis.  The Motion Controller has 12 bits of precision (0-4095),
                        //so we use that range and center it about zero.
                        applicationDevice.Properties.SetRange(ParameterHow.ById, d.ObjectId, new InputRange(-2048, +2047));
                    }
                }
            }

        }

        /// <summary>
        /// Activates or resets the MotionDetectors attached to the Motion Controllers
        /// </summary>
        public void initDetectors()
        {
            if (detectors.Count == 0)
            {
                for (int i = 0; i < applicationDevices.Count; i++)
                {
                    detectors.Add(new MotionDetector());
                }
            }
            else
            {
                foreach (MotionDetector detector in detectors)
                {
                    detector.Clear();
                }
            }
        }

        /// <summary>
        /// Removes all MotionDetectors
        /// </summary>
        public void releaseDetectors()
        {
            detectors.Clear();
        }

        /// <summary>
        /// Poll each motion controller and get its state.  This function  should be called every frame.
        /// </summary>
        /// <param name="seconds">The number of seconds that have passed since the last update.</param>
        public void update(double seconds)
        {
            if (applicationDevices.Count == 0)
                return;

            //set the last states (to check for button presses, etc.)
            for (int i = 0; i < currentStates.Count; i++)
            {
                lastStates[i] = currentStates[i];
            }

            //Loop through all the Motion Controllers
            foreach (Device applicationDevice in applicationDevices)
            {
                try
                {
                    // Poll the device for info.
                    applicationDevice.Poll();
                }
                catch (InputException inputex)
                {
                    if ((inputex is NotAcquiredException) || (inputex is InputLostException))
                    {
                        // Check to see if either the app
                        // needs to acquire the device, or
                        // if the app lost the device to another
                        // process.
                        try
                        {
                            // Acquire the device.
                            applicationDevice.Acquire();
                        }
                        catch (InputException)
                        {
                            // Failed to acquire the device.
                            // This could be because the app
                            // doesn't have focus.
                            return;
                        }
                    }

                } //catch(InputException inputex)

                // Get the state of the device.
                try { currentStates[applicationDevices.IndexOf(applicationDevice)] = applicationDevice.CurrentJoystickState; }
                // Catch any exceptions. None will be handled here, 
                // any device re-aquisition will be handled above.  
                catch (InputException)
                {
                    return;
                }
            }

            //update detectors if initialized
            if (detectors.Count > 0)
            {
                for (int i = 0; i < currentStates.Count; i++)
                {
                    detectors[i].feedData(currentStates[i].X, currentStates[i].Y, currentStates[i].Z, seconds);
                }
            }
        }

        /// <summary>
        /// Get the value of an axis on Motion Controller 0
        /// </summary>
        /// <param name="axis">The axis to check (X=0, Y=1, Z=2)</param>
        /// <returns>The value of the axis from -2048 to +2047</returns>
        public int getAxis(int axis)
        {
            return getAxis(axis, 0);
        }

        /// <summary>
        /// Get the value of an axis on a Motion Controller
        /// </summary>
        /// <param name="axis">The axis to check (X=0, Y=1, Z=2)</param>
        /// <param name="joyStick">The zero-based index of the Motion Controller to read</param>
        /// <returns>The value of the axis from -2048 to +2047</returns>
        public int getAxis(int axis, int joyStick)
        {
            if (joyStick >= applicationDevices.Count)
            {
                throw new InsufficientControllersAttachedException("There are fewer than " + (joyStick + 1) + " Motion Controllers connected");
            }
            switch (axis)
            {
                case 0:
                    return currentStates[joyStick].X;
                case 1:
                    return currentStates[joyStick].Y;
                case 2:
                    return currentStates[joyStick].Z;
                default:
                    return 0;
            }
        }

        public MotionDetector getDetector(int joyStick)
        {
            if (joyStick >= applicationDevices.Count)
                throw new InsufficientControllersAttachedException("There are fewer than " + (joyStick + 1) + " Motion Controllers connected");
            else if (detectors.Count > 0)
                return detectors[joyStick];
            else
                throw new DetectorsNotInitializedException("You must call initDetectors before getting them.");
        }

        /// <summary>
        /// Check the status of a button on Motion Controller 0
        /// </summary>
        /// <param name="button">The zero-based index of the button to read</param>
        /// <returns>True if the button is down</returns>
        public bool getButton(int button)
        {
            return getButton(button, 0);
        }

        /// <summary>
        /// Check the status of a button on a Motion Controller
        /// </summary>
        /// <param name="button">The zero-based index of the button to read</param>
        /// <param name="joyStick">The zero-based index of the Motion Controller to read</param>
        /// <returns>True if the button is down</returns>
        public bool getButton(int button, int joyStick)
        {
            if (joyStick >= applicationDevices.Count)
            {
                throw new InsufficientControllersAttachedException("There are fewer than " + (joyStick + 1) + " Motion Controllers connected");
            }
            return currentStates[joyStick].GetButtons()[button] > 0;
        }

        /// <summary>
        /// Check whether a button was pressed this frame (getButton() was false last update() and is true this update()) on Motion Controller 0
        /// </summary>
        /// <param name="button">The zero-based index of the button to read</param>
        /// <returns>True if the button was just pressed</returns>
        public bool getButtonPress(int button)
        {
            return getButtonPress(button, 0);
        }

        /// <summary>
        /// Check whether a button was pressed this frame (getButton() was false last update() and is true this update()) on a Motion Controller
        /// </summary>
        /// <param name="button">The zero-based index of the button to read</param>
        /// <param name="joyStick">The zero-based index of the Motion Controller to read</param>
        /// <returns>True if the button was just pressed</returns>
        public bool getButtonPress(int button, int joyStick)
        {
            if (joyStick >= applicationDevices.Count)
            {
                throw new InsufficientControllersAttachedException("There are fewer than " + (joyStick + 1) + " Motion Controllers connected");
            }
            return currentStates[joyStick].GetButtons()[button] > 0 && lastStates[joyStick].GetButtons()[button] == 0;
        }
    }

    class DetectorsNotInitializedException : Exception
    {
        public DetectorsNotInitializedException(string message)
            : base(message)
        {
        }
    }

    class InsufficientControllersAttachedException : Exception
    {
        public InsufficientControllersAttachedException(string message)
            : base(message)
        {
        }
    }

    class NoMotionControllerFoundException : Exception
    {
        public NoMotionControllerFoundException(string message)
            : base(message)
        {
        }
    }
}