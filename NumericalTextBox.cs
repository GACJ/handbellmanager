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
using System.ComponentModel;
using System.Windows.Forms;

namespace HandbellManager
{
	class NumericalTextBox : TextBox
	{
		bool _fixingText;
		int _selstart;
		int _value;
		string _text;

		public NumericalTextBox()
		{
			FixText();
		}

		private void FixText()
		{
			if (_fixingText)
				return;

			_fixingText = true;
			_selstart = SelectionStart;
			_text = Text;

			for (int i = 0; i < _text.Length; i++)
			{
				if (i == 0 && _text[i] == '-')
					continue;
				
				if (!Char.IsNumber(_text[i]))
				{

					_text = _text.Remove(i, 1);
						if (i <= _selstart)
							_selstart -= 1;
						if (_selstart < 0)
							_selstart = 0;
					i = -1;
				}
			}

			if (_text.Length == 0)
			{
				_text = "0";
			}
			if (_text == "-" || _text == "-0")
				_value = 0;
			else
			{
				_value = Convert.ToInt32(_text);
				//Reformat value only if at end of field
				if (_selstart == _text.Length)
				{
					_text = _value.ToString();
					_selstart = _text.Length;
				}
			}
			if (_selstart == 0)
				//Reformat value only if no longer editing
				_text = _value.ToString();
			Text = _text;
			SelectionStart = _selstart;
			_fixingText = false;
		}

		[Category("Appearance")]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				FixText();
				if (Text == "-")
					return 0;
				else
					return Convert.ToInt32(Text);
			}
			set
			{
				Text = value.ToString();
			}
		}

		[DefaultValue("0")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				FixText();
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);

			Keys k = (Keys)e.KeyChar;
			if (e.KeyChar == '-')
				return;
			if (k == Keys.Delete || k == Keys.Back)
				return;
			if (Char.IsNumber(e.KeyChar))
				return;

			e.Handled = true;
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			SelectionStart = 0;
			FixText();
		}
	}
}