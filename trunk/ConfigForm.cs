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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MotionControllerManager;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using CustomUIControls.Graphing;

namespace HandbellManager
{
	public partial class ConfigForm : Form
	{
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);
		
		[DllImport("user32.dll")]
		private static extern int PostMessage(IntPtr hWnd, uint Msg, long wParam, long lParam);

		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern bool IsWindow(IntPtr hWnd);

		int _lastTick;

		IntPtr _ABEL_hWnd;
		double _secsSinceUpdate;
		int _ticksSinceUpdate;
		int _averageticks;
		int _sumticks;
		int _updates;
		bool _functionkey;
		public static bool sendToAbelEnabled;
		bool _suppressNoControllerMessage;

		MotionControllerManager.MotionControllerManager _mcm;
        Handbell[] _hb = new Handbell[4];

		MonitorForm _monitorForm;
		OptionsForm _optionsForm;

		public ConfigForm()
		{
            
			InitializeComponent();

			_suppressNoControllerMessage = true; 

			InitDevices();

			_suppressNoControllerMessage = false;

			_lastTick = Environment.TickCount;

			Color controlBGColor = Color.White;
			if (_mcm.Count > 0)
				btnReset.Focus();
			else
				btnFindControllers.Focus();
			sendToAbelEnabled = true;
		}

		private bool IsAbelFocused()
		{
			foreach (Process p in Process.GetProcessesByName(Settings.abelProcessName))
			{
				if (GetForegroundWindow() == p.MainWindowHandle)
				{
					return true;
				}
			}

			return false;
		}

		private void InitDevices()
		{
			tmrTurn.Stop();

			try
			{
				_mcm = new MotionControllerManager.MotionControllerManager();
				_mcm.initialize(true);
				_mcm.initDetectors();
				_mcm.update(0);
				for (int i = 0; i < _mcm.Count; i++)
				{
					_hb[i] = new Handbell(_mcm, i);
					_hb[i].BackstrokeStrikeZ = Settings.zBSP[i];
					_hb[i].HandstrokeStrikeZ = Settings.zHSP[i];
					_hb[i].Update(0);
				}
			}
			catch (Exception ex)
			{
				if (ex.Message != "No Motion Controller Found" && _suppressNoControllerMessage)
					MessageBox.Show(ex.Message,"Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_lastTick = Environment.TickCount;
			btnReset_Click(null, EventArgs.Empty);
			if (_mcm.Count > 0)
				btnReset.Focus();
			else
				btnFindControllers.Focus();

			if (_monitorForm != null)
				_monitorForm.ReInitLines();
			tmrTurn.Start();
		}

		private void GetAbelhWnd()
		{
			//Abel window already identified?
			if (_ABEL_hWnd != IntPtr.Zero)
			{
				//And still open?
				if (IsWindow(_ABEL_hWnd))
					return;
			}
			//If not find Abel window
			Process[] processlist = Process.GetProcesses();
			foreach (Process p in processlist)
			{
				if (p.ProcessName == Settings.abelProcessName)
				{
					_ABEL_hWnd = p.MainWindowHandle;
				}
			}
			_ABEL_hWnd = FindWindowEx(_ABEL_hWnd, IntPtr.Zero, "AfxMDIFrame80s", null);
			_ABEL_hWnd = FindWindowEx(_ABEL_hWnd, IntPtr.Zero, "AfxFrameOrView80s", null);
		}

		private void SendAbel(string cmd, bool keyDown, bool keyUp)
		{
			const int WM_KEYDOWN = 0x100;
			const int WM_KEYUP = 0x101;
			const int WM_CHAR = 0x102; 
			long c;

			_functionkey = false;
			if (!sendToAbelEnabled)
				return;

			if (cmd.Length == 0)
				return;
			if (cmd.Length == 1)
				c = (long)cmd[0];
			else
			{
				//Check for Functions
				cmd = cmd.ToUpper();
				cmd = cmd.Trim();
				switch (cmd)
				{
					case "ESC":
					c = (long)Keys.Escape;
					break;
					case "F1":
					c = (long)Keys.F1;
					_functionkey = true;
					break;
					case "F2":
					c = (long)Keys.F2;
					_functionkey = true;
					break;
					case "F3":
					c = (long)Keys.F3;
					_functionkey = true;
					break;
					case "F4":
					c = (long)Keys.F4;
					_functionkey = true;
					break;
					case "F5":
					c = (long)Keys.F5;
					_functionkey = true;
					break;
					case "F6":
					c = (long)Keys.F6;
					_functionkey = true;
					break;
					case "F7":
					c = (long)Keys.F7;
					_functionkey = true;
					break;
					case "F8":
					c = (long)Keys.F8;
					_functionkey = true;
					break;
					case "F9":
					c = (long)Keys.F9;
					_functionkey = true;
					break;
					case "F10":
					c = (long)Keys.F10;
					_functionkey = true;
					break;
					case "F11":
					c = (long)Keys.F11;
					_functionkey = true;
					break;
					case "F12":
					c = (long)Keys.F12;
					_functionkey = true;
					break;
					default:
					return;
				}
			}

			GetAbelhWnd();
			if (_ABEL_hWnd != IntPtr.Zero)
			{
				if (Settings.useKeyUpDown & (keyDown | keyUp))
				{
					if (keyDown)
						PostMessage(_ABEL_hWnd, WM_KEYDOWN, c, 0);
					else
						PostMessage(_ABEL_hWnd, WM_KEYUP, c, 0);
				}
				else
					if (_functionkey)
					{
						PostMessage(_ABEL_hWnd, WM_KEYDOWN, c, 0);
						PostMessage(_ABEL_hWnd, WM_KEYUP, c, 0);
					}
					else
						PostMessage(_ABEL_hWnd, WM_CHAR, c, 0);
			}
		}

		private void tmrTurn_Tick(object sender, EventArgs e)
		{
			_ticksSinceUpdate = Environment.TickCount - _lastTick;
			_updates++;
			_sumticks += _ticksSinceUpdate;
			_averageticks = _sumticks / _updates;
			_secsSinceUpdate = (double)_ticksSinceUpdate / 1000d;
			if (_secsSinceUpdate < 0)
				_secsSinceUpdate = 0;
			_mcm.update(_secsSinceUpdate);
			_lastTick = Environment.TickCount;

			for (int i = 0; i < _mcm.Count; i++)
			{
				_hb[i].Update(_lastTick);
				if (_hb[i].HandstrokeStrike)
				{
					SendAbel(Settings.keyHS[i], false, true);
					this.Controls["txtCountHS" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountHS" + i].Text) + 1);
				}
				if (_hb[i].BackstrokeStrike)
				{
					SendAbel(Settings.keyBS[i], true, false);
					this.Controls["txtCountBS" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountBS" + i].Text) + 1);
				}
				if (_hb[i].ButtonAPressed)
				{
					SendAbel(Settings.keyB1[i], false, false);
					this.Controls["txtCountB1" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB1" + i].Text) + 1);
				}
				if (_hb[i].ButtonBPressed)
				{
					SendAbel(Settings.keyB2[i], false, false);
					this.Controls["txtCountB2" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB2" + i].Text) + 1);
				}
				if (_hb[i].Handstroke)
					this.Controls["txtCountHS" + i].BackColor = Color.Orange;
				else
					this.Controls["txtCountHS" + i].BackColor = SystemColors.Window;
				if (_hb[i].Backstroke)
					this.Controls["txtCountBS" + i].BackColor = Color.Orange;
				else
					this.Controls["txtCountBS" + i].BackColor = SystemColors.Window;
				if (_hb[i].ButtonADown)
					this.Controls["txtCountB1" + i].BackColor = Color.Orange;
				else
					this.Controls["txtCountB1" + i].BackColor = SystemColors.Window;
				if (_hb[i].ButtonBDown)
					this.Controls["txtCountB2" + i].BackColor = Color.Orange;
				else
					this.Controls["txtCountB2" + i].BackColor = SystemColors.Window;

			}

			if (_monitorForm != null)
				_monitorForm.UpdateGraph(_hb, _mcm.Count);

			if (_optionsForm != null)
				_optionsForm.Tick();
		}

		private void btnCalibrate_Click(object sender, EventArgs e)
		{
			sendToAbelEnabled = false;
			Button btn = (Button)sender;
			int i = Convert.ToInt32(btn.Name.Substring(btn.Name.Length - 1, 1));

			CalibrationForm cf = new CalibrationForm();
			Handbell newHB = cf.StartCalibration(_mcm, i);
			if (newHB != null)
			{
				_hb[i] = newHB;
			}
			sendToAbelEnabled = true;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				this.Controls["txtCountHS" + i].Text = "0";
				this.Controls["txtCountHS" + i].BackColor = SystemColors.Window;
				this.Controls["txtCountBS" + i].Text = "0";
				this.Controls["txtCountBS" + i].BackColor = SystemColors.Window;
				this.Controls["txtCountB1" + i].Text = "0";
				this.Controls["txtCountB1" + i].BackColor = SystemColors.Window;
				this.Controls["txtCountB2" + i].Text = "0";
				this.Controls["txtCountB2" + i].BackColor = SystemColors.Window;
			}
		}


		private void btnFindControllers_Click(object sender, EventArgs e)
		{
			InitDevices();
			if (_mcm.Count == 0)
				MessageBox.Show("No motion controllers found.", "Handbell Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string abelShortcut = Path.Combine(Application.StartupPath, Settings.abelProcessName + ".lnk");
			if (File.Exists(abelShortcut))
			{
				try
				{
					Process.Start(abelShortcut);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Shortcut Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
				MessageBox.Show(String.Format("To run Abel from Handbell Manager, place a shortcut to the Abel executable in the Handbell Manager installation folder with the name {0}.",
					Settings.abelProcessName), "Abel Shortcut Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string helpfile = Path.Combine(Application.StartupPath, "HMHelp.htm");
			if (File.Exists(helpfile))
			{
				Process.Start(helpfile);
			}
			else
			MessageBox.Show(String.Format("Cannot find {0}.",
				helpfile), "Help File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_monitorForm == null)
			{
				_monitorForm = new MonitorForm();
			}

			_monitorForm.Show();
			_monitorForm.Focus();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_optionsForm = new OptionsForm(_hb, _mcm);
			_optionsForm.Show();
			_optionsForm.Focus();

			//Disabling Config Form functions while Options Dialog open
			btnFindControllers.Enabled = false;
			optionsToolStripMenuItem.Enabled = false;
		}

		public void OptionsClosed()
		{
			_optionsForm.Dispose();
			_optionsForm = null;

			//Enabling Config Form functions
			btnFindControllers.Enabled = true;
			optionsToolStripMenuItem.Enabled = true;
			Focus();
		}
	}
}
