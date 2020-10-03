// This file is part of Handbell Manager.
// Copyright Graham John 2009-2017. graham@changeringing.co.uk
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
using System.Drawing;
using System.Windows.Forms;

namespace HandbellManager
{
	public partial class OptionsForm : Form
	{
		private MotionControllerManager.MotionControllerManager _mcm;
		private Handbell[] _hb;
		bool _initialisation;
		Simulator _sim;

		public OptionsForm(Handbell[] handbells, MotionControllerManager.MotionControllerManager mcm)
		{
			InitializeComponent();
			_mcm = mcm;
			_hb = handbells;
			InitializeFields();
		}
		private void InitializeFields()
		{
			_initialisation = true;
			_sim = Settings.simulator[Settings.currentSimulator];
			//Handbell Calibration
			for (int i = 0; i < Settings.numHandbells; i++)
			{
				ComboBox cb = (ComboBox) tabHandbellCalibration.Controls["cmbAxis" + i];
				cb.SelectedIndex = Settings.swingAxis[i];
				tabHandbellCalibration.Controls["txtBSP" + i].Text = Settings.BSP[i].ToString();
				tabHandbellCalibration.Controls["txtHSP" + i].Text = Settings.HSP[i].ToString();
				//Enable calibration buttons
				if (i < _mcm.Count)
					tabHandbellCalibration.Controls["btnCalibrate" + i].Enabled = true;
				else
					tabHandbellCalibration.Controls["btnCalibrate" + i].Enabled = false;
			}

			spnDebounceDelay.Value = Settings.debounceDelay;
			spnDelayHS.Value = Settings.handstrokeStrikeDelay;
			spnDelayBS.Value = Settings.backstrokeStrikeDelay;

			//Simulator keystrokes
			// Ringing Room is a little different. It is a web page so we only need to specify a URL.
			if (_sim.Name=="RingingRoom")
			{
				tabSimulatorKeyStrokes.Text = _sim.Name + " Settings";
				lblSimulatorProcessName.Hide();
				txtProcessName.Hide();
				lblChildWindowClassName.Text = "RingingRoom URL:";				
				lblGrandchildWindowClassName.Text = "Window Name:";				
				chkUseKeyUpDown.Hide();
			}
			// For Muster we hide the controls for process, window names and key-up/down. This
			// may be temporary whilst Muster is still in development.
			else if (_sim.Name =="Muster")
			{
				tabSimulatorKeyStrokes.Text = _sim.Name + " Settings";
				lblSimulatorProcessName.Text = _sim.Name + " Process Name:";
				txtProcessName.Text = _sim.ProcessName;
				chkUseKeyUpDown.Checked = _sim.UseKeyUpDown;
				lblSimulatorProcessName.Hide();
				txtProcessName.Hide();
				chkUseKeyUpDown.Hide();
				lblChildWindowClassName.Hide();
				lblGrandchildWindowClassName.Hide();
				txtChildWindowClassName.Hide();
				txtGrandchildWindowClassName.Hide();
			}
			else
			{
				tabSimulatorKeyStrokes.Text = _sim.Name + " Settings";
				lblSimulatorProcessName.Text = _sim.Name + " Process Name:";
				txtProcessName.Text = _sim.ProcessName;				
				chkUseKeyUpDown.Checked = _sim.UseKeyUpDown;	
			}

			txtChildWindowClassName.Text = _sim.ChildWindowClassName;
			txtGrandchildWindowClassName.Text = _sim.GrandchildWindowClassName;
			for (int i = 0; i < 4; i++)
			{
				tabSimulatorKeyStrokes.Controls["txtKeyBS" + i].Text = _sim.KeyBS[i];
				tabSimulatorKeyStrokes.Controls["txtKeyHS" + i].Text = _sim.KeyHS[i];
				tabSimulatorKeyStrokes.Controls["txtKeyB1" + i].Text = _sim.KeyB1[i];
				tabSimulatorKeyStrokes.Controls["txtKeyB2" + i].Text = _sim.KeyB2[i];
				tabSimulatorKeyStrokes.Controls["txtKeyB3" + i].Text = _sim.KeyB3[i];
				tabSimulatorKeyStrokes.Controls["txtKeyB4" + i].Text = _sim.KeyB4[i];
			}

			//Bring previously selected tab to the front
			if (ConfigForm.optionsTabKeystrokesSelected)
                tabControl1.SelectedIndex = 1;
            else
                tabControl1.SelectedIndex = 0;

            _initialisation = false;
		}

		private NumericalTextBox GetHandbellTextbox(string name, int index)
		{
			return (NumericalTextBox)tabHandbellCalibration.Controls[name + index];
		}

		private void txtProcessName_TextChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			if (txtProcessName.Text.TrimEnd(' ').EndsWith(".exe", StringComparison.CurrentCultureIgnoreCase))
			{
				Point pnt = txtProcessName.GetPositionFromCharIndex(txtProcessName.TextLength - 1);
				pnt.X -= 8;
				pnt.Y -= 68;
				warningTip.ToolTipTitle = "Extension";
				warningTip.Show("Do not include .exe!", txtProcessName, pnt, int.MaxValue);

				System.Media.SystemSounds.Beep.Play();

			}
			else
			{
				warningTip.RemoveAll();
			}

			_sim.ProcessName = txtProcessName.Text;
		}

        private void txtChildWindowClassName_TextChanged(object sender, EventArgs e)
        {
            if (_initialisation)
                return;

            _sim.ChildWindowClassName = txtChildWindowClassName.Text;
        }

        private void txtGrandchildWindowClassName_TextChanged(object sender, EventArgs e)
        {
            if (_initialisation)
                return;

            _sim.GrandchildWindowClassName = txtGrandchildWindowClassName.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
		{
			//Save settings and close
			Settings.Save();

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			//Restore settings and close
			Settings.Open();
			//Update handbell settings
			for (int i = 0; i < _mcm.Count; i++)
			{
				if (i < 4)
					_hb[i].UpdateSettings();
			}
			Close();
		}

		public void Tick()
		{
			for (int i = 0; i < _mcm.Count; i++)
			{
				if (i < 4)
					tabHandbellCalibration.Controls["txt" + i].Text = _hb[i].CurrentZ.ToString();
			}
		}

		private void btnCalibrate_Click(object sender, EventArgs e)
		{
			ConfigForm.sendKeystrokesEnabled = false;
			Button btn = (Button)sender;
			int i = Convert.ToInt32(btn.Name.Substring(btn.Name.Length - 1, 1));

			CalibrationForm cf = new CalibrationForm();
			Handbell newHB = cf.StartCalibration(_mcm, i);
			//Apply Calibration
			if (newHB != null)
			{
				_hb[i] = newHB;
				tabHandbellCalibration.Controls["txtBSP" + i].Text = Settings.BSP[i].ToString();
				tabHandbellCalibration.Controls["txtHSP" + i].Text = Settings.HSP[i].ToString();
			}
			ConfigForm.sendKeystrokesEnabled = true;
		}

		private void spnDebounceDelay_ValueChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			Settings.debounceDelay = Convert.ToInt32(spnDebounceDelay.Value);
		}

		private void spnDelayBS_ValueChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			Settings.backstrokeStrikeDelay = Convert.ToInt32(spnDelayBS.Value);
		}

		private void spnDelayHS_ValueChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			Settings.handstrokeStrikeDelay = Convert.ToInt32(spnDelayHS.Value);
		}

		private void txtBSP_TextChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			
			for (int i = 0; i < Settings.numHandbells; i++)
			{
				Settings.BSP[i] = GetHandbellTextbox("txtBSP", i).Value;
			}
			//Update handbell settings
			for (int i = 0; i < _mcm.Count; i++)
			{
				if (i < Settings.numHandbells)
					_hb[i].UpdateSettings();
			}

		}

		private void txtHSP_TextChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;

			for (int i = 0; i < Settings.numHandbells; i++)
			{
				Settings.HSP[i] = GetHandbellTextbox("txtHSP", i).Value;
			}
			//Update handbell settings
			for (int i = 0; i < _mcm.Count; i++)
			{
				if (i < 4)
					_hb[i].UpdateSettings();
			}

		}
		private void txtKey_TextChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			for (int i = 0; i < Settings.numHandbells; i++)
			{
				_sim.KeyBS[i] = tabSimulatorKeyStrokes.Controls["txtKeyBS" + i].Text;
				_sim.KeyHS[i] = tabSimulatorKeyStrokes.Controls["txtKeyHS" + i].Text;
				_sim.KeyB1[i] = tabSimulatorKeyStrokes.Controls["txtKeyB1" + i].Text;
				_sim.KeyB2[i] = tabSimulatorKeyStrokes.Controls["txtKeyB2" + i].Text;
				_sim.KeyB3[i] = tabSimulatorKeyStrokes.Controls["txtKeyB3" + i].Text;
				_sim.KeyB4[i] = tabSimulatorKeyStrokes.Controls["txtKeyB4" + i].Text;
			}
		}

		private void cmbAxis_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			for (int i = 0; i < Settings.numHandbells; i++)
			{
				int z1, z2, z3, z4;
				z1 = cmbAxis0.SelectedIndex;
				z2 = cmbAxis1.SelectedIndex;
				z3 = cmbAxis2.SelectedIndex;
				z4 = cmbAxis3.SelectedIndex;
				ComboBox cb = (ComboBox)tabHandbellCalibration.Controls["cmbAxis" + i];
				Settings.swingAxis[i] = cb.SelectedIndex;
				_hb[i].SwingAxis = cb.SelectedIndex;
			}
		}

		private void chkUseKeyUpDown_CheckedChanged(object sender, EventArgs e)
		{
			if (_initialisation)
				return;
			_sim.UseKeyUpDown = chkUseKeyUpDown.Checked;
		}

		private void btnDefault_Click(object sender, EventArgs e)
		{
			//Confirm reset
			System.Windows.Forms.DialogResult response =
				MessageBox.Show(String.Format("Revert all Handbell Calibration and {0} Settings to their default values?", _sim.Name), "Default Settings Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (response == DialogResult.Yes)
			{
				//Set back to defaults
				Settings.Default();
				//Update handbell settings
				for (int i = 0; i < _mcm.Count; i++)
				{
					if (i < Settings.numHandbells)
						_hb[i].UpdateSettings();
				}
				InitializeFields();
			}
		}

		private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.ConfigForm.OptionsClosed();
		}

        private void tabSimulatorKeyStrokes_Enter(object sender, EventArgs e)
        {
            ConfigForm.optionsTabKeystrokesSelected = true;
        }

        private void tabHandbellCalibration_Enter(object sender, EventArgs e)
        {
            ConfigForm.optionsTabKeystrokesSelected = false;
        }

		private void textBox_rrURL_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox_rrID_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
