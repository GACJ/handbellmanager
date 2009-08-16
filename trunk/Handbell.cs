// This file is part of Handbell Manager.
// Copyright Graham John 2009. graham@changeringing.co.uk
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
// along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

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
		private int _index;
		private int _backstrokeStrikeZ;
		private int _handstrokeStrikeZ;
		private int _currentZ;
		private int _lasttick;

		private bool _buttonAPressed;
		private bool _buttonADown;
		private bool _buttonBPressed;
		private bool _buttonBDown;

		private bool _handstroke;
		private bool _backstroke;
		private bool _handstrokeStrike;
		private bool _backstrokeStrike;
		private bool _handstrokeStrikePending;
		private bool _backstrokeStrikePending;

		public Handbell(MotionControllerManager.MotionControllerManager manager, int index)
		{
			_manager = manager;
			_index = index;
			_motionController = _manager.getDetector(_index);
		    _buttonAPressed = false;
			_buttonADown = false;
			_buttonBPressed = false;
			_buttonBDown = false;
			_handstroke = true;
			_backstroke = false;
			_handstrokeStrike = false;
			_backstrokeStrike = false;
			_handstrokeStrikePending = false;
			_backstrokeStrikePending = false;
			_lasttick = 0;

		}

		public void UpdateSettings()
		{
			HandstrokeStrikeZ = Settings.zHSP[_index];
			BackstrokeStrikeZ = Settings.zBSP[_index];
		}

		public void Update(int tick)
		{
			if (_motionController == null)
				return;

			_currentZ = _manager.getAxis(2, _index);

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
				if (_backstrokeStrikeZ > _handstrokeStrikeZ)
				{
					//Handstroke?
					if (_currentZ < _handstrokeStrikeZ)
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
					if (_currentZ > _backstrokeStrikeZ)
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
					if (_currentZ > _handstrokeStrikeZ)
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
					if (_currentZ < _backstrokeStrikeZ)
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
			//Button A
			if (_manager.getButton(0, _index))
			{
				if (!_buttonADown)
				{
					_buttonADown = true;
					_buttonAPressed = true;
				}
				else
				{
					_buttonAPressed = false;
				}
			}
			else
			{
				_buttonADown = false;
				_buttonAPressed = false;
			}

			//Button B
			if (_manager.getButton(1, _index))
			{
				if (!_buttonBDown)
				{
					_buttonBDown = true;
					_buttonBPressed = true;
				}
				else
				{
					_buttonBPressed = false;
				}
			}
			else
			{
				_buttonBDown = false;
				_buttonBPressed = false;
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

		public int Index
		{
			get
			{
				return _index;
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
		public int BackstrokeStrikeZ
		{
			get
			{
				return _backstrokeStrikeZ;
			}
			set
			{
				_backstrokeStrikeZ = value;
			}
		}

		public int HandstrokeStrikeZ
		{
			get
			{
				return _handstrokeStrikeZ;
			}
			set
			{
				_handstrokeStrikeZ = value;
			}
		}

		public int CurrentZ
		{
			get
			{
				return _currentZ;
			}
		}

		public bool ButtonADown
		{
			get
			{
				return _buttonADown;
			}
			set
			{
				_buttonADown = value;
			}
		}

		public bool ButtonBDown
		{
			get
			{
				return _buttonBDown;
			}
			set
			{
				_buttonBDown = value;
			}
		}

		public bool ButtonAPressed
		{
			get
			{
				return _buttonAPressed;
			}
			set
			{
				_buttonAPressed = value;
			}
		}

		public bool ButtonBPressed
		{
			get
			{
				return _buttonBPressed;
			}
			set
			{
				_buttonBPressed = value;
			}
		}
	}
}
