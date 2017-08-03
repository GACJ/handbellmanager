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
using System.Windows.Forms;

namespace HandbellManager
{
	public partial class CalibrationForm : Form
	{
		private Handbell _handbell;
		private int _question;
		private int _index;

		private int _bsz;
		private int _hsz;

		public CalibrationForm()
		{
			InitializeComponent();
		}

		public Handbell StartCalibration(MotionControllerManager.MotionControllerManager manager, int index)
		{
			_handbell = new Handbell(manager, index);
			_question = 0;
			_index = index;
			AskQuestion();
			if (ShowDialog() == DialogResult.OK)
			{
				_handbell.UpdateSettings();

				Close();
				return _handbell;
			}
			else
			{
				Close();
				return null;
			}
		}

		private void AskQuestion()
		{
			switch (_question)
			{
				case 0:
					grpInstruction.Text = "Set Backstroke Strike Position";
					lblInstruction.Text = String.Format("Hold handbell {0} horizontally and press a button on the controller.\n\n"
						+ "This will be the position in the swing where the clapper will strike at backstroke.", _index + 1);
					break;
				case 1:
					grpInstruction.Text = "Set Handstroke Strike Position";
					lblInstruction.Text = String.Format("Hold handbell {0} vertically and press a button on the controller.\n\n"
						+ "This will be the position in the swing where the clapper will strike at handstroke.", _index + 1);
					break;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void tmrCalibration_Tick(object sender, EventArgs e)
		{
			_handbell.Update(0);
			if (_handbell.Button1Pressed || _handbell.Button2Pressed)
			{
				switch (_question)
				{
					case 0:
						_bsz = _handbell.CurrentZ;
						_question++;
						AskQuestion();
						break;
					case 1:
						_hsz = _handbell.CurrentZ;
						SaveSettings();
						DialogResult = DialogResult.OK;
						break;
				}

			}
		}

		private void SaveSettings()
		{
			Settings.BSP[_index] = _bsz;
			Settings.HSP[_index] = _hsz;

			_handbell.UpdateSettings();
		}
	}
}
