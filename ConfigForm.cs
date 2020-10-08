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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HandbellManager
{
    public partial class ConfigForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, uint Msg, long wParam, long lParam);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);

        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

    
        public static string GetWindowClassName(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(128);
            GetClassName(hWnd, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        int _lastTick;

        IntPtr _Simulator_hWnd;
        double _secsSinceUpdate;
        int _ticksSinceUpdate;
        int _averageticks;
        int _sumticks;
        int _updates;
        bool _functionkey;
        public static int [] ControllerSequence = new int[20];
        public static bool sendKeystrokesEnabled;
        public static bool optionsTabKeystrokesSelected;
        bool _suppressNoControllerMessage;
        Simulator _sim;
        MotionControllerManager.MotionControllerManager _mcm;
        Handbell[] _hb = new Handbell[Settings.numHandbells];

        MonitorForm _monitorForm;
        OptionsForm _optionsForm;
        //Process clientProcess;

        public ConfigForm()
        {
            
            InitializeComponent();

            _suppressNoControllerMessage = true; 

            _sim = Settings.simulator[Settings.currentSimulator];
            InitialiseRunSimulator();

            InitDevices();

            _suppressNoControllerMessage = false;

            _lastTick = Environment.TickCount;

            Color controlBGColor = Color.White;
            if (_mcm.Count > 0)
                btnReset.Focus();
            else
                btnFindControllers.Focus();
            sendKeystrokesEnabled = true;

            this.Text = "Handbell Manager - " + _sim.Name;

            if (Settings.autoRunSimulator)
                runSimulator();

        }

        //		private bool IsSimulatorFocused()
        //		{
        //			foreach (Process p in Process.GetProcessesByName(_sim.ProcessName))
        //			{
        //				if (GetForegroundWindow() == p.MainWindowHandle)
        //				{
        //					return true;
        //				}
        //			}
        //
        //			return false;
        //		}

        private void InitDevices()
        {
            tmrTurn.Stop();

            try
            {
                _mcm = new MotionControllerManager.MotionControllerManager();
                _mcm.initialize(true);
                _mcm.initDetectors();
                _mcm.update(0);
                //Set initial controller sequence
                for (int i = 0; i < _mcm.Count; i++)
                {
                    ControllerSequence[i] = i;
                }
                //Assign to handbells
                for (int i = 0; i < Settings.numHandbells; i++)
                {
                    _hb[i] = new Handbell(_mcm, i);
                    if (i >= _mcm.Count)
                    {
                        _hb[i].Enabled = false;
                    }
                    else
                    {
                        _hb[i].Enabled = true;
                        _hb[i].UpdateSettings();
                        _hb[i].Update(0);
                    }
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
#if EMULATE_CONTROLLER
            tmrTurn.Interval = 1000;
#endif
            tmrTurn.Start();
        }


        private void GetSimulatorhWnd()
        {
            //Simulator window already identified?
            if (_Simulator_hWnd != IntPtr.Zero)
            {
                //And still open?
                if (IsWindow(_Simulator_hWnd))
                    return;
            }

            Process[] processlist = Process.GetProcesses();
            int pcount = 0;

            if (_sim.Name == "RingingRoom") // RingingRoom
            {
                foreach (Process p in processlist)
                {
                    if (p.MainWindowHandle != IntPtr.Zero)
                    {
                        var winTitle = p.MainWindowTitle;
                        if (winTitle.Contains(_sim.GrandchildWindowName) || winTitle.Contains(_sim.GrandchildWindowClassName))
                    {
                            p.Refresh();
                            _Simulator_hWnd = p.MainWindowHandle;
                            pcount++;
                            break;
                        } 
                    }
                }
            }
            else  // Abel, Beltower and Muster
            {
                foreach (Process p in processlist)
                {
                    if (Convert.ToString(p.ProcessName).ToUpper() == _sim.ProcessName.ToUpper())
                    {
                        p.Refresh();
                        _Simulator_hWnd = p.MainWindowHandle;
                        pcount++;
                        break;
                    }
                }
                
                //For BelTower (VB), get the parent MDI window rather than the owner
                string windowName = "";
                string childWindowName = "";
                string grandchildWindowName = "";
                string processWindowClassName = GetWindowClassName(_Simulator_hWnd);
                if (processWindowClassName == "ThunderRT6Main")
                {
                    while (_Simulator_hWnd != IntPtr.Zero)
                    {
                        windowName = GetWindowClassName(_Simulator_hWnd);
                        if (windowName == "ThunderRT6MDIForm")
                            break;
                        uint GW_HWNDPREV = 3;
                        _Simulator_hWnd = GetWindow(_Simulator_hWnd, GW_HWNDPREV);
                    }
                }
                windowName = GetWindowClassName(_Simulator_hWnd);
                //Find child and grandchild windows if required
                if (_sim.ChildWindowClassName.Length > 0)
                    _Simulator_hWnd = FindWindowEx(_Simulator_hWnd, IntPtr.Zero, _sim.ChildWindowClassName, _sim.ChildWindowName);
                childWindowName = GetWindowClassName(_Simulator_hWnd);
                if (_sim.GrandchildWindowClassName.Length > 0)
                    _Simulator_hWnd = FindWindowEx(_Simulator_hWnd, IntPtr.Zero, _sim.GrandchildWindowClassName, _sim.GrandchildWindowName);
                grandchildWindowName = GetWindowClassName(_Simulator_hWnd);
            }
        }

        private void SendKeystrokes(string cmd, bool keyDown, bool keyUp)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_CHAR = 0x102; 
            long c;

            _functionkey = false;
            if (!sendKeystrokesEnabled)
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
                    _functionkey = true;
                    break;
                    case "End":
                    c = (long)Keys.End;
                    _functionkey = true;
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

#if BRUTE_FORCE_SEND_KEY_STROKES
            char character = (char)c;
            SendKeys.Send(character.ToString());
#else
            GetSimulatorhWnd();

            // If the window is no longer open, just return. Nothing to do.
            if (_Simulator_hWnd == IntPtr.Zero)
                return;

            // RingingRoom runs as Javascript in a Browser, so it has no WINPROC.
            // We use brute force SendKeys.Send().
            if (_sim.Name == "RingingRoom")
            {
                if (GetForegroundWindow() == _Simulator_hWnd)
                {
                    char character = (char)c;
                    SendKeys.Send(character.ToString());
                }
            }
            else  // Abel, Beltower, Musterf
            {
                if (_sim.UseKeyUpDown & (keyDown | keyUp))
                {
                    if (keyDown)
                        PostMessage(_Simulator_hWnd, WM_KEYDOWN, c, 0);
                    else
                        PostMessage(_Simulator_hWnd, WM_KEYUP, c, 0);
                }
                else
                {
                    if (_functionkey)
                    {
                        PostMessage(_Simulator_hWnd, WM_KEYDOWN, c, 0);
                        PostMessage(_Simulator_hWnd, WM_KEYUP, c, 0);
                    }
                    else
                        if (_sim.Name == "Muster")
                            PostMessage(_Simulator_hWnd, WM_KEYDOWN, c, 0);
                        else
                            PostMessage(_Simulator_hWnd, WM_CHAR, c, 0);
                }
            }
#endif
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

            // Here we just send an event every time the timer ticks, but with the timer slowed right down to 1 second intervals.
            // Controller 0 HS and BS are the same key.

            // APN: This is just to create events since we don't have an actual controller attached.
            //	    COMMENT OUT THE FOLLOWING 2 LINES TO USE CONTROLLERS NORMALLY!
#if EMULATE_CONTROLLER
            SendKeystrokes(_sim.KeyHS[0], false, true);
            this.Controls["txtCountHS" + 0].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountHS" + 0].Text) + 1);
#endif

            for (int i = 0; i < _mcm.Count; i++)
            {
                if (i < Settings.numHandbells)
                {
                    _hb[i].Update(_lastTick);
                    if (_hb[i].HandstrokeStrike)
                    {
                        SendKeystrokes(_sim.KeyHS[i], false, true);
                        this.Controls["txtCountHS" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountHS" + i].Text) + 1);
                    }
                    if (_hb[i].BackstrokeStrike)
                    {
                        SendKeystrokes(_sim.KeyBS[i], true, false);
                        this.Controls["txtCountBS" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountBS" + i].Text) + 1);
                    }
                    if (_hb[i].Button1Pressed)
                    {
                        SendKeystrokes(_sim.KeyB1[i], false, false);
                        this.Controls["txtCountB1" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB1" + i].Text) + 1);
                    }
                    if (_hb[i].Button2Pressed)
                    {
                        SendKeystrokes(_sim.KeyB2[i], false, false);
                        this.Controls["txtCountB2" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB2" + i].Text) + 1);
                    }
                    if (_hb[i].Button3Pressed)
                    {
                        SendKeystrokes(_sim.KeyB3[i], false, false);
                        this.Controls["txtCountB3" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB3" + i].Text) + 1);
                    }
                    if (_hb[i].Button4Pressed)
                    {
                        SendKeystrokes(_sim.KeyB4[i], false, false);
                        this.Controls["txtCountB4" + i].Text = Convert.ToString(Convert.ToInt32(this.Controls["txtCountB4" + i].Text) + 1);
                    }
                    if (_hb[i].Handstroke)
                        this.Controls["txtCountHS" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountHS" + i].BackColor = SystemColors.Window;
                    if (_hb[i].Backstroke)
                        this.Controls["txtCountBS" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountBS" + i].BackColor = SystemColors.Window;
                    if (_hb[i].Button1Down)
                        this.Controls["txtCountB1" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountB1" + i].BackColor = SystemColors.Window;
                    if (_hb[i].Button2Down)
                        this.Controls["txtCountB2" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountB2" + i].BackColor = SystemColors.Window;
                    if (_hb[i].Button3Down)
                        this.Controls["txtCountB3" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountB3" + i].BackColor = SystemColors.Window;
                    if (_hb[i].Button4Down)
                        this.Controls["txtCountB4" + i].BackColor = Color.Orange;
                    else
                        this.Controls["txtCountB4" + i].BackColor = SystemColors.Window;
                }
            }
            
            if (_monitorForm != null)
                _monitorForm.UpdateGraph(_hb, _mcm.Count);

            if (_optionsForm != null)
                _optionsForm.Tick();
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            sendKeystrokesEnabled = false;
            Button btn = (Button)sender;
            int i = Convert.ToInt32(btn.Name.Substring(btn.Name.Length - 1, 1));

            CalibrationForm cf = new CalibrationForm();
            Handbell newHB = cf.StartCalibration(_mcm, i);
            if (newHB != null)
            {
                _hb[i] = newHB;
            }
            sendKeystrokesEnabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings.numHandbells; i++)
            {
                this.Controls["txtCountHS" + i].Text = "0";
                this.Controls["txtCountHS" + i].BackColor = SystemColors.Window;
                this.Controls["txtCountBS" + i].Text = "0";
                this.Controls["txtCountBS" + i].BackColor = SystemColors.Window;
                this.Controls["txtCountB1" + i].Text = "0";
                this.Controls["txtCountB1" + i].BackColor = SystemColors.Window;
                this.Controls["txtCountB2" + i].Text = "0";
                this.Controls["txtCountB2" + i].BackColor = SystemColors.Window;
                this.Controls["txtCountB3" + i].Text = "0";
                this.Controls["txtCountB3" + i].BackColor = SystemColors.Window;
                this.Controls["txtCountB4" + i].Text = "0";
                this.Controls["txtCountB4" + i].BackColor = SystemColors.Window;
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

        // Start the simulator running. This may be caused by Settings.autoRunSimulator == true, or the Run menu
        // item has been clicked.
        private void runSimulator()
        {
            // Ringingroom launches the default web-browser. We just start a process with the URL
            // which is set in the options. We therefore don't need a link
            if (_sim.Name == "RingingRoom")
            {
                try
                {
                    // First see if there is already a RingingRoom process running.
                    _Simulator_hWnd = IntPtr.Zero;
                    Process[] processlist = Process.GetProcesses();
                    foreach (Process p in processlist)
                    {
                        if (p.MainWindowHandle != IntPtr.Zero && p.MainWindowTitle.Contains(_sim.GrandchildWindowName))
                        {
                            p.Refresh();
                            _Simulator_hWnd = p.MainWindowHandle;
                            break;
                        }
                    }
                    // If no RR process found, try to Start one.
                    if (_Simulator_hWnd == IntPtr.Zero)
                    {
                        Process.Start(_sim.ChildWindowClassName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to bind to a RingingRoom session.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (_sim.Name == "Muster")
            {
                try
                {
                    // First see if there is already a Muster process running.
                    _Simulator_hWnd = IntPtr.Zero;
                    Process[] processlist = Process.GetProcesses();
                    foreach (Process p in processlist)
                    {
                        if (p.MainWindowHandle != IntPtr.Zero && p.ProcessName == "Muster")
                        {
                            p.Refresh();
                            _Simulator_hWnd = p.MainWindowHandle;
                            break;
                        }
                    }
                    // If no process found, try to Start one.
                    if (_Simulator_hWnd == IntPtr.Zero)
                    {
                        string simulatorShortcut = Path.Combine(Application.StartupPath, _sim.ProcessName + ".lnk");
                        if (File.Exists(simulatorShortcut))
                        {
                            try
                            {
                                Process.Start(simulatorShortcut);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Shortcut Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show(String.Format("To run {0} from Handbell Manager, place a shortcut to the {0} executable in the Handbell Manager installation folder with the name {1}.",
                                _sim.Name, _sim.ProcessName), String.Format("{0} Shortcut Not Found", _sim.Name), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to bind to a RingingRoom session.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            else // Abel etc. Start a process with a shortcut (.lnk filename)
            {
                string simulatorShortcut = Path.Combine(Application.StartupPath, _sim.ProcessName + ".lnk");

                if (File.Exists(simulatorShortcut))
                {
                    try
                    {
                        Process.Start(simulatorShortcut);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Shortcut Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show(String.Format("To run {0} from Handbell Manager, place a shortcut to the {0} executable in the Handbell Manager installation folder with the name {1}.",
                        _sim.Name, _sim.ProcessName), String.Format("{0} Shortcut Not Found", _sim.Name), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runSimulator();			
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
            changeSimulatorToolStripMenuItem.Enabled = false;
        }

        public void OptionsClosed()
        {
            _optionsForm.Dispose();
            _optionsForm = null;

            //Reset simulator object as Cancel will have created a new instance 
            _sim = Settings.simulator[Settings.currentSimulator];
            //Enabling Config Form functions
            btnFindControllers.Enabled = true;
            optionsToolStripMenuItem.Enabled = true;
            changeSimulatorToolStripMenuItem.Enabled = true;
            Focus();
        }

        private void controllersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_mcm.Count == 0)
                MessageBox.Show("No motion controllers found to assign.", "Controller Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ControllerForm form = new ControllerForm(_mcm, _hb);
                form.ShowDialog();
            }
        }
        
        private void abelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.currentSimulator != 0)
            {
                if (Settings.currentSimulator == 1)
                    beltowerToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 2)
                    ringingMasterToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 3)
                    ringingRoomToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 4)
                    musterToolStripMenuItem.Image = runToolStripMenuItem.Image;

                runToolStripMenuItem.Image = abelToolStripMenuItem1.Image;
                abelToolStripMenuItem1.Image = null;
                abelToolStripMenuItem1.Checked = true;
                beltowerToolStripMenuItem1.Checked = false;
                ringingMasterToolStripMenuItem1.Checked = false;
                ringingRoomToolStripMenuItem1.Checked = false;
                musterToolStripMenuItem.Checked = false;
                Settings.currentSimulator = 0;
                _sim = Settings.simulator[Settings.currentSimulator];
                runToolStripMenuItem.Text = _sim.Name;
                this.Text = "Handbell Manager - " + _sim.Name;
                Settings.Save();
                _Simulator_hWnd = IntPtr.Zero; //Reset Simulator handle
            }
        }

        private void beltowerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.currentSimulator != 1)
            {
                if (Settings.currentSimulator == 0)
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 2)
                    ringingMasterToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 3)
                    ringingRoomToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 4)
                    musterToolStripMenuItem.Image = runToolStripMenuItem.Image;

                runToolStripMenuItem.Image = beltowerToolStripMenuItem1.Image;
                beltowerToolStripMenuItem1.Image = null;
                abelToolStripMenuItem1.Checked = false;
                beltowerToolStripMenuItem1.Checked = true;
                ringingMasterToolStripMenuItem1.Checked = false;
                ringingRoomToolStripMenuItem1.Checked = false;
                musterToolStripMenuItem.Checked = false;
                Settings.currentSimulator = 1;
                _sim = Settings.simulator[Settings.currentSimulator];
                runToolStripMenuItem.Text = _sim.Name;
                this.Text = "Handbell Manager - " + _sim.Name;
                Settings.Save();
                _Simulator_hWnd = IntPtr.Zero; //Reset Simulator handle
            }
        }

        private void ringingMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.currentSimulator != 2)
            {
                if (Settings.currentSimulator == 0)
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 1)
                    beltowerToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 3)
                    ringingRoomToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 4)
                    musterToolStripMenuItem.Image = runToolStripMenuItem.Image;

                runToolStripMenuItem.Image = ringingMasterToolStripMenuItem1.Image;
                ringingMasterToolStripMenuItem1.Image = null;
                abelToolStripMenuItem1.Checked = false;
                beltowerToolStripMenuItem1.Checked = false;
                ringingMasterToolStripMenuItem1.Checked = true;
                ringingRoomToolStripMenuItem1.Checked = false;
                musterToolStripMenuItem.Checked = false;
                Settings.currentSimulator = 2;
                _sim = Settings.simulator[Settings.currentSimulator];
                this.Text = "Handbell Manager - " + _sim.Name;
                runToolStripMenuItem.Text = _sim.Name;
                Settings.Save();
                _Simulator_hWnd = IntPtr.Zero; //Reset Simulator handle
            }
        }

        private void ringingRoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.currentSimulator != 3)
            {
                if (Settings.currentSimulator == 0)
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 1)
                    beltowerToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 2)
                    ringingMasterToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 4)
                    musterToolStripMenuItem.Image = runToolStripMenuItem.Image;

                runToolStripMenuItem.Image = ringingMasterToolStripMenuItem1.Image;
                ringingRoomToolStripMenuItem1.Image = null;
                abelToolStripMenuItem1.Checked = false;
                beltowerToolStripMenuItem1.Checked = false;
                ringingMasterToolStripMenuItem1.Checked = false;
                ringingRoomToolStripMenuItem1.Checked = true;
                musterToolStripMenuItem.Checked = false;
                Settings.currentSimulator = 3;
                _sim = Settings.simulator[Settings.currentSimulator];
                runToolStripMenuItem.Text = _sim.Name;
                this.Text = "Handbell Manager - " + _sim.Name;
                Settings.Save();
                _Simulator_hWnd = IntPtr.Zero; //Reset Simulator handle
            }
        }
        private void musterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Settings.currentSimulator != 4)
            {
                if (Settings.currentSimulator == 0)
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 1)
                    beltowerToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 2)
                    ringingMasterToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                if (Settings.currentSimulator == 3)
                    ringingRoomToolStripMenuItem1.Image = runToolStripMenuItem.Image;

                runToolStripMenuItem.Image = musterToolStripMenuItem.Image;
                ringingRoomToolStripMenuItem1.Image = null;
                abelToolStripMenuItem1.Checked = false;
                beltowerToolStripMenuItem1.Checked = false;
                ringingMasterToolStripMenuItem1.Checked = false;
                ringingRoomToolStripMenuItem1.Checked = false;
                musterToolStripMenuItem.Checked = true;
                Settings.currentSimulator = 4;
                _sim = Settings.simulator[Settings.currentSimulator];
                runToolStripMenuItem.Text = _sim.Name;
                this.Text = "Handbell Manager - " + _sim.Name;
                Settings.Save();
                _Simulator_hWnd = IntPtr.Zero; //Reset Simulator handle
            }
        }

        private void InitialiseRunSimulator()
        {
            switch (Settings.currentSimulator)
            {
                case 0: //No action - Abel is default
                    break;
                case 1: //Set Run to Beltower
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                    runToolStripMenuItem.Image = beltowerToolStripMenuItem1.Image;
                    beltowerToolStripMenuItem1.Image = null;
                    abelToolStripMenuItem1.Checked = false;
                    beltowerToolStripMenuItem1.Checked = true;
                    ringingMasterToolStripMenuItem1.Checked = false;
                    ringingRoomToolStripMenuItem1.Checked = false;
                    musterToolStripMenuItem.Checked = false;
                    runToolStripMenuItem.Text = _sim.Name;
                    break;
                case 2: //Set Run to RingingMaster
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                    runToolStripMenuItem.Image = ringingMasterToolStripMenuItem1.Image;
                    ringingMasterToolStripMenuItem1.Image = null;
                    abelToolStripMenuItem1.Checked = false;
                    beltowerToolStripMenuItem1.Checked = false;
                    ringingMasterToolStripMenuItem1.Checked = true;
                    ringingRoomToolStripMenuItem1.Checked = false;
                    musterToolStripMenuItem.Checked = false;
                    runToolStripMenuItem.Text = _sim.Name;
                    break;
                case 3: // Set Ringing Room
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                    runToolStripMenuItem.Image = ringingRoomToolStripMenuItem1.Image;
                    ringingRoomToolStripMenuItem1.Image = null;
                    abelToolStripMenuItem1.Checked = false;
                    beltowerToolStripMenuItem1.Checked = false;
                    ringingMasterToolStripMenuItem1.Checked = false;
                    ringingRoomToolStripMenuItem1.Checked = true;
                    musterToolStripMenuItem.Checked = false;
                    runToolStripMenuItem.Text = _sim.Name;					
                    break;
                case 4: // Set Muster
                    abelToolStripMenuItem1.Image = runToolStripMenuItem.Image;
                    runToolStripMenuItem.Image = musterToolStripMenuItem.Image;
                    musterToolStripMenuItem.Image = null;
                    abelToolStripMenuItem1.Checked = false;
                    beltowerToolStripMenuItem1.Checked = false;
                    ringingMasterToolStripMenuItem1.Checked = false;
                    ringingRoomToolStripMenuItem1.Checked = false;
                    musterToolStripMenuItem.Checked = true;
                    runToolStripMenuItem.Text = _sim.Name;
                    break;
            }
        }		
    }
}
