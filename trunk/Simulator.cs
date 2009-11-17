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

namespace HandbellManager
{
	public class Simulator
	{
		string[] _simKeyBS = new string[] { " ", " ", " ", " " };
		string[] _simKeyHS = new string[] { " ", " ", " ", " " };
		string[] _simKeyB1 = new string[] { " ", " ", " ", " " };
		string[] _simKeyB2 = new string[] { " ", " ", " ", " " };
		string[] _simKeyB3 = new string[] { " ", " ", " ", " " };
		string[] _simKeyB4 = new string[] { " ", " ", " ", " " };
		bool _simUseKeyUpDown = false;
		string _simProcessName = " ";
		string _simName = " ";
		string _simChildWindowClassName = "";
		string _simChildWindowName = "";
		string _simGrandchildWindowClassName = "";
		string _simGrandchildWindowName = "";

		public bool UseKeyUpDown
		{
			get
			{
				return _simUseKeyUpDown;
			}
			set
			{
				_simUseKeyUpDown = value;
			}
		}

		public string ProcessName
		{
			get
			{
				return _simProcessName;
			}
			set
			{
				_simProcessName = value;
			}
		}

		public string Name
		{
			get
			{
				return _simName;
			}
			set
			{
				_simName = value;
			}
		}

		public string ChildWindowClassName
		{
			get
			{
				return _simChildWindowClassName;
			}
			set
			{
				_simChildWindowClassName = value;
			}
		}
	
		public string ChildWindowName
		{
			get
			{
				return _simChildWindowName;
			}
			set
			{
				_simChildWindowName = value;
			}
		}

		public string GrandchildWindowClassName
		{
			get
			{
				return _simGrandchildWindowClassName;
			}
			set
			{
				_simGrandchildWindowClassName = value;
			}
		}

		public string GrandchildWindowName
		{
			get
			{
				return _simGrandchildWindowName;
			}
			set
			{
				_simGrandchildWindowName = value;
			}
		}

		public string[] KeyBS
		{
			get
			{
				return _simKeyBS;
			}
			set
			{
				_simKeyBS = value;
			}
		}

		public string[] KeyHS
		{
			get
			{
				return _simKeyHS;
			}
			set
			{
				_simKeyHS = value;
			}
		}

		public string[] KeyB1
		{
			get
			{
				return _simKeyB1;
			}
			set
			{
				_simKeyB1 = value;
			}
		}

		public string[] KeyB2
		{
			get
			{
				return _simKeyB2;
			}
			set
			{
				_simKeyB2 = value;
			}
		}

		public string[] KeyB3
		{
			get
			{
				return _simKeyB3;
			}
			set
			{
				_simKeyB3 = value;
			}
		}

		public string[] KeyB4
		{
			get
			{
				return _simKeyB4;
			}
			set
			{
				_simKeyB4 = value;
			}
		}

	}
}
