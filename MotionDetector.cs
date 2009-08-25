using System;
using System.Collections.Generic;
using System.Text;

namespace MotionControllerManager
{
  /*  Motion Controller Detector Class
  *  
  * This class reads data from the Motion Controller and reports some basic information about its orientation.
  * It can also detect a few simple gestures.
  * 
  * http://www.actionxl.com
  * 
  * (c) ActionXL 2007
  * Written by Benjamin Kalb
  * bkalb@actionxl.com
  */

    public class MotionDetector
    {
        List<int> Xdata, Ydata, Zdata, Time;
        List<double> Gdata;
        int maxXYZ;
        double maxG;
        double totalTime = 0;

        /// <summary>
        /// Test to see if the controller was moved or only tilted.
        /// </summary>
        /// <returns>True if the cotroller was only tilted in place</returns>
        bool rotationOnly()
        {
            foreach (double g in Gdata)
            {
                if (g > maxG * 0.3)
                {
                    return false;
                }
                if(g < maxG * 0.15)
                {
                    return false;
                }//*/
            }
            return true;
        }

        public MotionDetector()
        {
            maxG = 3547;
            maxXYZ = 2048;

            Xdata = new List<int>();
            Ydata = new List<int>();
            Zdata = new List<int>();
            Gdata = new List<double>();
            Time = new List<int>();
        }

        /// <summary>
        /// Stores this frame of accelerometer data for simple gesture recognition.
        /// </summary>
        /// <param name="x">The x-axis acceleration</param>
        /// <param name="y">The y-axis acceleration</param>
        /// <param name="z">The z-axis acceleration</param>
        /// <param name="dT">time elapsed since last frame in seconds</param>
        internal void feedData(int x, int y, int z, double dT)
        {
            if(totalTime + dT == totalTime)
            {
                totalTime = 0;
            }
            totalTime += dT;
            //check Maxima
            if (Math.Abs(x) > maxXYZ)
                maxXYZ = Math.Abs(x);
            if (Math.Abs(x) > maxXYZ)
                maxXYZ = Math.Abs(y);
            if (Math.Abs(x) > maxXYZ)
                maxXYZ = Math.Abs(z);

            double grav = Math.Sqrt(x * x + y * y + z * z);
            if (grav > maxG)
                maxG = grav;

            //log this frame
            Xdata.Add(x);
            Ydata.Add(y);
            Zdata.Add(z);
            Gdata.Add(grav);
            Time.Add((int)(totalTime * 1000));

            //clean old data
            while (Time.Count > 0 && totalTime - Time[0] > 1000)
            {
                Xdata.RemoveAt(0);
                Ydata.RemoveAt(0);
                Zdata.RemoveAt(0);
                Gdata.RemoveAt(0);
                Time.RemoveAt(0);
            }
        }

        /// <summary>
        /// Clears all gesture data.
        /// </summary>
        public void Clear()
        {
            Xdata.Clear();
            Ydata.Clear();
            Zdata.Clear();
            Gdata.Clear();
            Time.Clear();
        }

        /// <summary>
        /// Detects whether the Motion Controller is level (the buttons are pointing at the ceiling) and still.
        /// </summary>
        public bool isLevel()
        {
            return Xdata.Count > 0 && Math.Abs(Xdata[Xdata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Ydata[Ydata.Count - 1]) < maxXYZ * 0.1 && Zdata[Zdata.Count - 1] < -maxXYZ * 0.3 && Zdata[Zdata.Count - 1] > -maxXYZ * 0.5;
        }

        /// <summary>
        /// Detects whether the Motion Controller is tipped left (the buttons are pointing to the left) and still.
        /// </summary>
        public bool isTippedLeft()
        {
            return Xdata.Count > 0 && Math.Abs(Zdata[Zdata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Ydata[Ydata.Count - 1]) < maxXYZ * 0.1 && Xdata[Xdata.Count - 1] < -maxXYZ * 0.3 && Xdata[Xdata.Count - 1] > -maxXYZ * 0.5;
        }
        
        /// <summary>
        /// Detects whether the Motion Controller is tipped up (the wire is pointing down) and still.
        /// </summary>
        public bool isTippedUp()
        {
            return Xdata.Count > 0 && Math.Abs(Zdata[Zdata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Xdata[Xdata.Count - 1]) < maxXYZ * 0.1 && Ydata[Ydata.Count - 1] < -maxXYZ * 0.3 && Ydata[Ydata.Count - 1] > -maxXYZ * 0.5;
        }

        /// <summary>
        /// Detects whether the Motion Controller is tipped right (the buttons are pointing to the right) and still.
        /// </summary>
        public bool isTippedRight()
        {
            return Xdata.Count > 0 && Math.Abs(Zdata[Zdata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Ydata[Ydata.Count - 1]) < maxXYZ * 0.1 && Xdata[Xdata.Count - 1] > maxXYZ * 0.3 && Xdata[Xdata.Count - 1] < maxXYZ * 0.5;
        }

        /// <summary>
        /// Detects whether the Motion Controller is tipped down (the wire is pointing up) and still.
        /// </summary>
        public bool isTippedDown()
        {
            return Xdata.Count > 0 && Math.Abs(Zdata[Zdata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Xdata[Xdata.Count - 1]) < maxXYZ * 0.1 && Ydata[Ydata.Count - 1] > maxXYZ * 0.3 && Ydata[Ydata.Count - 1] < maxXYZ * 0.5;
        } 
        
        /// <summary>
        /// Detects whether the Motion Controller is flipped over (the buttons facing the floor) and still.
        /// </summary>
        public bool isFlipped()
        {
            return Xdata.Count > 0 && Math.Abs(Ydata[Ydata.Count - 1]) < maxXYZ * 0.1 && Math.Abs(Xdata[Xdata.Count - 1]) < maxXYZ * 0.1 && Zdata[Zdata.Count - 1] > maxXYZ * 0.3 && Zdata[Zdata.Count - 1] < maxXYZ * 0.5;
        }

        /// <summary>
        /// Detects whether the Motion Controller has been shaken left and right in the last second.
        /// </summary>
        public bool hasShakenX()
        {
            bool low = false, high = false, low2 = false;

            foreach (int i in Xdata)
            {
                if (!low && i > 0.7f * maxXYZ)
                    low = true;
                if (low && !high && i < -0.7f * maxXYZ)
                    high = true;
                if (low && high && !low2 && i > 0.7f * maxXYZ)
                    low2 = true;
            }

            return low && high && low2;
        }        
        
        /// <summary>
        /// Detects whether the Motion Controller has been shaken up and down in the last second.
        /// </summary>
        public bool hasShakenZ()
        {
            bool low = false, high = false, low2 = false;

            foreach (int i in Zdata)
            {
                if (!low && i > 0.7f * maxXYZ)
                    low = true;
                if (low && !high && i < -0.7f * maxXYZ)
                    high = true;
                if (low && high && !low2 && i > 0.7f * maxXYZ)
                    low2 = true;
            }

            return low && high && low2;
        }

        /// <summary>
        /// Detects whether the Motion Controller has been moved in a circle in the last second.
        /// </summary>
        public bool hasCircled()
        {
            bool low = false, high = false, low2 = false;

            int iLast = 0;

            foreach (int i in Ydata)
            {
                if (iLast != 0 && !low && i < -0.25f * maxXYZ && Math.Abs(i - iLast) < 0.2f * maxXYZ)
                    low = true;
                if (iLast != 0 && low && !high && i > 0.1f * maxXYZ && Math.Abs(i - iLast) < 0.2f * maxXYZ)
                    high = true;
                if (iLast != 0 && low && high && !low2 && i < -0.25f * maxXYZ && Math.Abs(i - iLast) < 0.2f * maxXYZ)
                    low2 = true;
                iLast = i;
            }

            return low && high && low2;
        }
        
        /// <summary>
        /// Detects whether the Motion Controller has been shaken in and out in the last second.
        /// </summary>
        public bool hasShakenY()
        {
            bool low = false, high = false, low2 = false;

            foreach (int i in Ydata)
            {
                if (!low && i > 0.7f * maxXYZ)
                    low = true;
                if (low && !high && i < -0.7f * maxXYZ)
                    high = true;
                if (low && high && !low2 && i > 0.7f * maxXYZ)
                    low2 = true;
            }

            return low && high && low2;
        }

        /// <summary>
        /// Detects whether the Motion Controller has been slashed like a sword.
        /// </summary>
        public bool hasSlashed()
        {
            for (int i = 0; i < Xdata.Count; i++)
            {
                if (Math.Abs(Xdata[i]) > 0.35 * maxXYZ && Ydata[i] > 0.35 * maxXYZ)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Detects whether the Motion Controller is in free fall (has been dropped or thrown)
        /// </summary>
        public bool isFreeFalling()
        {
            return Gdata.Count > 0 && Gdata[Gdata.Count - 1] < 0.08 * maxG;
        }
    }
}
