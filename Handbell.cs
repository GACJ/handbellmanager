// This file is part of Handbell Manager.
// Copyright Graham John 2009-2020. graham@changeringing.co.uk
//
// Handbell Manager is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Handbell Manager is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Handbell Manager.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotionControllerManager;

namespace HandbellManager
{
    public class Handbell
    {
        private MotionControllerManager.MotionControllerManager _manager;
        private MotionDetector _motionController = null;
        private int _backstrokeStrikePoint;
        private int _handstrokeStrikePoint;
        private int _currentSwingValue;
        private int _lasttick;
        private int _axis;
        private int _controller;
        private int _handbell;

        private bool _enabled;

        private bool _button1Pressed;
        private bool _button1Down;
        private bool _button2Pressed;
        private bool _button2Down;
        private bool _button3Pressed;
        private bool _button3Down;
        private bool _button4Pressed;
        private bool _button4Down;

        private bool _handstroke;
        private bool _backstroke;
        private bool _handstrokeStrike;
        private bool _backstrokeStrike;
        private bool _handstrokeStrikePending;
        private bool _backstrokeStrikePending;

        public Handbell(MotionControllerManager.MotionControllerManager manager, int index)
        {
            _manager = manager;
            _button1Pressed = false;
            _button1Down = false;
            _button2Pressed = false;
            _button2Down = false;
            _button3Pressed = false;
            _button3Down = false;
            _button4Pressed = false;
            _button4Down = false;
            _handstroke = true;
            _backstroke = false;
            _handstrokeStrike = false;
            _backstrokeStrike = false;
            _handstrokeStrikePending = false;
            _backstrokeStrikePending = false;
            _lasttick = 0;
            _axis = 2; //Z-axis
            if (index < _manager.Count)
            {
                _controller = index;
                _handbell = index;
                _motionController = _manager.getDetector(_controller);
                _enabled = true;
            }
            else
            {
                _enabled = false;
                _controller = -1;
            }
        }

        public void UpdateSettings()
        {
            HandstrokeStrikePoint = Settings.HSP[_handbell];
            BackstrokeStrikePoint = Settings.BSP[_handbell];
            SwingAxis = Settings.swingAxis[_handbell];
        }

        public void Update(int tick)
        {
            if (_motionController == null)
                return;

            _currentSwingValue = _manager.getAxis(_axis, _controller);

            UpdateButtons();
            UpdateStrokes(tick);
        }

        private void UpdateStrokes(int tick)
        {
            _handstrokeStrike = false;
            _backstrokeStrike = false;

            //Check whether debounce delay satisfied
            if (tick > _lasttick + Settings.debounceDelay)
            {
                //Check whether Z is higher for handstroke or backstroke
                if (_backstrokeStrikePoint > _handstrokeStrikePoint)
                {
                    //Handstroke?
                    if (_currentSwingValue < _handstrokeStrikePoint)
                    {
                        //Flag if change of State
                        if (_handstroke)
                        {
                            _handstrokeStrikePending = true;
                            _backstroke = true;
                            _handstroke = false;
                            _lasttick = tick;			//Keep time of last strike
                        }

                    }
                    //Backstroke?
                    if (_currentSwingValue > _backstrokeStrikePoint)
                    {
                        //Flag if change of State
                        if (_backstroke)
                        {
                            _backstrokeStrikePending = true;
                            _handstroke = true;
                            _backstroke = false;
                            _lasttick = tick;			//Keep time of last strike
                        }
                    }
                }
                else
                {
                    //Handstroke?
                    if (_currentSwingValue > _handstrokeStrikePoint)
                    {
                        //Flag if change of State
                        if (_handstroke)
                        {
                            _handstrokeStrikePending = true;
                            _backstroke = true;
                            _handstroke = false;
                            _lasttick = tick;			//Keep time of last strike
                        }
                    }
                    //Backstroke?
                    if (_currentSwingValue < _backstrokeStrikePoint)
                    {
                        //Flag if change of State
                        if (_backstroke)
                        {
                            _backstrokeStrikePending = true;
                            _handstroke = true;
                            _backstroke = false;
                            _lasttick = tick;			//Keep time of last strike
                        }
                    }
                }
            }
            //Trigger actual strike if delay interval has passed
            if (HandstrokeStrikePending)
            {
                if (tick >= _lasttick + Settings.handstrokeStrikeDelay)
                {
                    HandstrokeStrike = true;
                    HandstrokeStrikePending = false;
                }
            }
            if (BackstrokeStrikePending)
            {
                if (tick >= _lasttick + Settings.backstrokeStrikeDelay)
                {
                    BackstrokeStrike = true;
                    BackstrokeStrikePending = false;
                }
            }
        }

        private void UpdateButtons()
        {
            //Button 1
            if (_manager.getButton(0, _controller))
            {
                if (!_button1Down)
                {
                    _button1Down = true;
                    _button1Pressed = true;
                }
                else
                {
                    _button1Pressed = false;
                }
            }
            else
            {
                _button1Down = false;
                _button1Pressed = false;
            }

            //Button 2
            if (_manager.getButton(1, _controller))
            {
                if (!_button2Down)
                {
                    _button2Down = true;
                    _button2Pressed = true;
                }
                else
                {
                    _button2Pressed = false;
                }
            }
            else
            {
                _button2Down = false;
                _button2Pressed = false;
            }
            //Button 3
            if (_manager.getButton(2, _controller))
            {
                if (!_button3Down)
                {
                    _button3Down = true;
                    _button3Pressed = true;
                }
                else
                {
                    _button3Pressed = false;
                }
            }
            else
            {
                _button3Down = false;
                _button3Pressed = false;
            }
            //Button 4
            if (_manager.getButton(3, _controller))
            {
                if (!_button4Down)
                {
                    _button4Down = true;
                    _button4Pressed = true;
                }
                else
                {
                    _button4Pressed = false;
                }
            }
            else
            {
                _button4Down = false;
                _button4Pressed = false;
            }
        }

        public MotionDetector MotionController
        {
            get
            {
                return _motionController;
            }
            set
            {
                _motionController = value;
            }
        }
        public int Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
                _motionController = _manager.getDetector(_controller);
            }
        }

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        
        public bool Backstroke
        {
            get
            {
                return _backstroke;
            }
            set
            {
                _backstroke = value;
            }
        }

        public bool Handstroke
        {
            get
            {
                return _handstroke;
            }
            set
            {
                _handstroke = value;
            }
        }
        public bool BackstrokeStrike
        {
            get
            {
                return _backstrokeStrike;
            }
            set
            {
                _backstrokeStrike = value;
            }
        }

        public bool HandstrokeStrike
        {
            get
            {
                return _handstrokeStrike;
            }
            set
            {
                _handstrokeStrike = value;
            }
        }
        public bool BackstrokeStrikePending
        {
            get
            {
                return _backstrokeStrikePending;
            }
            set
            {
                _backstrokeStrikePending = value;
            }
        }

        public bool HandstrokeStrikePending
        {
            get
            {
                return _handstrokeStrikePending;
            }
            set
            {
                _handstrokeStrikePending = value;
            }
        }
        public int BackstrokeStrikePoint
        {
            get
            {
                return _backstrokeStrikePoint;
            }
            set
            {
                _backstrokeStrikePoint = value;
            }
        }

        public int HandstrokeStrikePoint
        {
            get
            {
                return _handstrokeStrikePoint;
            }
            set
            {
                _handstrokeStrikePoint = value;
            }
        }
        
        public int SwingAxis
        {
            get
            {
                return _axis;
            }
            set
            {
                _axis = value;
            }
        }

        public int CurrentZ
        {
            get
            {
                return _currentSwingValue;
            }
        }

        public bool Button1Down
        {
            get
            {
                return _button1Down;
            }
            set
            {
                _button1Down = value;
            }
        }

        public bool Button2Down
        {
            get
            {
                return _button2Down;
            }
            set
            {
                _button2Down = value;
            }
        }

        public bool Button3Down
        {
            get
            {
                return _button3Down;
            }
            set
            {
                _button3Down = value;
            }
        }

        public bool Button4Down
        {
            get
            {
                return _button4Down;
            }
            set
            {
                _button4Down = value;
            }
        }

        public bool Button1Pressed
        {
            get
            {
                return _button1Pressed;
            }
            set
            {
                _button1Pressed = value;
            }
        }

        public bool Button2Pressed
        {
            get
            {
                return _button2Pressed;
            }
            set
            {
                _button2Pressed = value;
            }
        }

        public bool Button3Pressed
        {
            get
            {
                return _button3Pressed;
            }
            set
            {
                _button3Pressed = value;
            }
        }

        public bool Button4Pressed
        {
            get
            {
                return _button4Pressed;
            }
            set
            {
                _button4Pressed = value;
            }
        }
    }
}
