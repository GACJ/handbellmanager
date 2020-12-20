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
using System.Windows.Forms;
using System.IO;

namespace HandbellManager
{
    static class Settings
    {
        private class SettingsVersion
        {
            public int versionNumber;
            public int numSimulators;
            public int numHandbells;
        }

        // Add a new entry to settingsVersionHistory when something changes that affects the settings file format
        private static SettingsVersion[] settingsVersionHistory = new[]
        {
            new SettingsVersion() { versionNumber=210, numSimulators=6, numHandbells=4 }, // Adds Ding
            new SettingsVersion() { versionNumber=141, numSimulators=5, numHandbells=4 }, // Adds RingingRoom and Muster
            new SettingsVersion() { versionNumber=120, numSimulators=3, numHandbells=4 }, // Adds Beltower and RingingMaster
            new SettingsVersion() { versionNumber=110, numSimulators=1, numHandbells=4 }  // Abel
        };
        public static int numSimulators = settingsVersionHistory[0].numSimulators;
        public static int numHandbells = settingsVersionHistory[0].numHandbells;
        public static Simulator[] simulator = new Simulator[numSimulators];
        public static int currentSimulator = 0;
        public static int[] swingAxis = new int[] { 2, 2, 2, 2 };
        public static int[] BSP = new int[] { 0, 0, 0, 0 };
        public static int[] HSP = new int[] { 0, 0, 0, 0 };
        public static int debounceDelay = 0;
        public static int handstrokeStrikeDelay = 0;
        public static int backstrokeStrikeDelay = 0;
        public static bool autoRunSimulator = false;   // Flag (not saved) to indicate -R command line to force simulator automatic start
#if DEBUG
        public static bool emulateControllers = true;
#else
        public static bool emulateControllers = false;
#endif

        public static void Default()
        {
            switch (currentSimulator)
            {
                case 0:
                    simulator[0].Name = "Abel";
                    simulator[0].ProcessName = "Abel3";
                    simulator[0].ChildWindowClassName = "AfxMDIFrame140s";
                    simulator[0].ChildWindowName = "";
                    simulator[0].GrandchildWindowClassName = "AfxFrameOrView140s";
                    simulator[0].GrandchildWindowName = "";
                    simulator[0].UseKeyUpDown = true;
                    simulator[0].KeyBS = new string[] { "J", "F", "R", "U" };
                    simulator[0].KeyHS = new string[] { "J", "F", "R", "U" };
                    simulator[0].KeyB1 = new string[] { "F9", "A", "F9", "A" };
                    simulator[0].KeyB2 = new string[] { "G", ";", "G", ";" };
                    simulator[0].KeyB3 = new string[] { "F9", "A", "F9", "A" };
                    simulator[0].KeyB4 = new string[] { "G", ";", "G", ";" };
                    break;
                case 1:
                    simulator[1].Name = "Beltower";
                    simulator[1].ProcessName = "Beltow95";
                    simulator[1].ChildWindowClassName = "MDIClient";
                    simulator[1].ChildWindowName = "";
                    simulator[1].GrandchildWindowClassName = "ThunderRT6FormDC";
                    simulator[1].GrandchildWindowName = "Changes";
                    simulator[1].UseKeyUpDown = false;
                    simulator[1].KeyBS = new string[] { "J", "F", "R", "U" };
                    simulator[1].KeyHS = new string[] { "J", "F", "R", "U" };
                    simulator[1].KeyB1 = new string[] { "¬", "B", "¬", "B" };
                    simulator[1].KeyB2 = new string[] { " ", "S", " ", "S" };
                    simulator[1].KeyB3 = new string[] { "¬", "B", "¬", "B" };
                    simulator[1].KeyB4 = new string[] { " ", "S", " ", "S" };
                    break;
                case 2:
                    simulator[2].Name = "RingingMaster";
                    simulator[2].ProcessName = "RingingMaster";
                    simulator[2].ChildWindowClassName = ""; //"MDIClient";
                    simulator[2].ChildWindowName = "";
                    simulator[2].GrandchildWindowClassName = ""; //"BCGPTabWnd:400000:8:10003:10";
                    simulator[2].GrandchildWindowName = "";
                    simulator[2].UseKeyUpDown = true;
                    simulator[2].KeyBS = new string[] { "I", "J", "D", "E" };
                    simulator[2].KeyHS = new string[] { "I", "J", "D", "E" };
                    simulator[2].KeyB1 = new string[] { "S", " ", "S", " " };
                    simulator[2].KeyB2 = new string[] { " ", "C", " ", "C" };
                    simulator[2].KeyB3 = new string[] { "S", " ", "S", " " };
                    simulator[2].KeyB4 = new string[] { " ", "C", " ", "C" };
                    break;
                case 3:
                    simulator[3].Name = "RingingRoom";
                    simulator[3].ProcessName = "RingingRoom";
                    simulator[3].ChildWindowClassName = "www.ringingroom.com"; // Use as URL for Ringing Room (not actually a class) for compatibility with other sims.
                    simulator[3].ChildWindowName = "www.ringingroom.com"; 
                    simulator[3].GrandchildWindowClassName = "Ringing Room"; // Use as the window identifier name (not actually a class)  for compatibility with other sims.
                    simulator[3].GrandchildWindowName = "Ringing Room"; 
                    simulator[3].UseKeyUpDown = false;
                    simulator[3].KeyBS = new string[] { "j", "f", "r", "u" };
                    simulator[3].KeyHS = new string[] { "j", "f", "r", "u" };
                    simulator[3].KeyB1 = new string[] { "b", "h", "b", "h" };
                    simulator[3].KeyB2 = new string[] { "n", "g", "n", "g" };
                    simulator[3].KeyB3 = new string[] { "F9", "a", "F9", "a" };
                    simulator[3].KeyB4 = new string[] { "g", ";", "g", ";" };
                    break;
                case 4:
                    simulator[4].Name = "Muster";
                    simulator[4].ProcessName = "Muster";
                    //simulator[4].ChildWindowClassName = "WindowsForms10.Window.8.app.0.2a45bdb_r16_ad1";
                    simulator[4].ChildWindowClassName = "";
                    simulator[4].ChildWindowName = "Muster";
                    simulator[4].GrandchildWindowClassName = "";
                    simulator[4].GrandchildWindowName = "";
                    simulator[4].UseKeyUpDown = false;
                    simulator[4].KeyBS = new string[] { "J", "F", "R", "U" };
                    simulator[4].KeyHS = new string[] { "J", "F", "R", "U" };
                    simulator[4].KeyB1 = new string[] { "F4", "A", "F4", "A" };
                    simulator[4].KeyB2 = new string[] { "G", ";", "G", ";" };
                    simulator[4].KeyB3 = new string[] { "F4", "A", "F4", "A" };
                    simulator[4].KeyB4 = new string[] { "G", ";", "G", ";" };
                    break;
                case 5:
                    simulator[5].Name = "Ding";
                    simulator[5].ProcessName = "Ding";
                    simulator[5].ChildWindowClassName = ""; 
                    simulator[5].ChildWindowName = "";
                    simulator[5].GrandchildWindowClassName = ""; 
                    simulator[5].GrandchildWindowName = "";
                    simulator[5].UseKeyUpDown = true;
                    simulator[5].KeyBS = new string[] { "HBJN", "DC", "K", "S" };
                    simulator[5].KeyHS = new string[] { "HJ", "D", "M", "X" };
                    simulator[5].KeyB1 = new string[] { "T", "T", "T", "T" };
                    simulator[5].KeyB2 = new string[] { "Y", "Y", "Y", "Y" };
                    simulator[5].KeyB3 = new string[] { "Q", "E", "Q", "E" };
                    simulator[5].KeyB4 = new string[] { "W", "R", "W", "R" };
                    break;
            }
            //Calibration defaults
            debounceDelay = 350;
            handstrokeStrikeDelay = 0;
            backstrokeStrikeDelay = 0;
            swingAxis = new int[] { 2, 2, 2, 2 };
            BSP = new int[] { -600, -600, -600, -600 };
            HSP = new int[] { 100, 100, 100, 100 };
        }

        private static string GetSettingsFilename(SettingsVersion v)
        {
            string settingsFile = "settings" + v.versionNumber + ".cfg";
            return Path.Combine(Folder, settingsFile);
        }

        private static SettingsVersion GetSettingsFromVersion(int versionNumber)
        {
            return settingsVersionHistory.FirstOrDefault(v => v.versionNumber == versionNumber);
        }

        private static string Folder
        {
            get
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appName = "Handbell Manager";
                return Path.Combine(appData, appName);
            }
        }

        private static void CreateFolder()
        {
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder); 
            }
        }

        public static void Open()
        {
            for (int j = 0; j < numSimulators; j++)
            {
                currentSimulator = j;
                simulator[j] = new Simulator();
                Default();
            }
            currentSimulator = 0;

            // Iterate through the version history to find the most recent settings file
            var settings = settingsVersionHistory.FirstOrDefault(v => File.Exists(GetSettingsFilename(v)));
            if (settings == null)
            {
                // No settings file exists.  Save the default settings.
                Save(); 
                return;
            }

            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                var settingsFileName = GetSettingsFilename(settings);
                fs = new FileStream(settingsFileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                // We already know the file version from the search for the latest settings file - or do we?  Quick check for users who and try to rename an old settings file
                int fileversion = br.ReadInt32(); 
                settings = GetSettingsFromVersion(fileversion);
                if (settings == null)
                {
                    // the file is from an unrecognised version.  Ignore it and create a brand new settings file with default settings.
                    Save(); 
                    return;
                }

                if (fileversion > 110)
                {
                    debounceDelay = br.ReadInt32();
                    handstrokeStrikeDelay = br.ReadInt32();
                    backstrokeStrikeDelay = br.ReadInt32();

                    for (int i = 0; i < settings.numHandbells; i++)
                    {
                        BSP[i] = br.ReadInt32();
                        HSP[i] = br.ReadInt32();
                        swingAxis[i] = br.ReadInt32();
                    }
                    //Get Current Simulator
                    currentSimulator = br.ReadInt32();
                    //Get Simulator settings
                    for (int j = 0; j < settings.numSimulators; j++)
                    {
                        simulator[j].Name = br.ReadString();
                        simulator[j].ProcessName = br.ReadString();
                        simulator[j].ChildWindowClassName = br.ReadString();
                        simulator[j].ChildWindowName = br.ReadString();
                        simulator[j].GrandchildWindowClassName = br.ReadString();
                        simulator[j].GrandchildWindowName = br.ReadString();
                        simulator[j].UseKeyUpDown = br.ReadBoolean();
                        for (int i = 0; i < settings.numHandbells; i++)
                        {
                            simulator[j].KeyBS[i] = br.ReadString();
                            simulator[j].KeyHS[i] = br.ReadString();
                            simulator[j].KeyB1[i] = br.ReadString();
                            simulator[j].KeyB2[i] = br.ReadString();
                            simulator[j].KeyB3[i] = br.ReadString();
                            simulator[j].KeyB4[i] = br.ReadString();
                        }
                    }
                }
                else // Version 110 had a slightly different layout
                {
                    simulator[0].Name = simulator[0].ProcessName = br.ReadString();
                    debounceDelay = br.ReadInt32();
                    handstrokeStrikeDelay = br.ReadInt32();
                    backstrokeStrikeDelay = br.ReadInt32();

                    for (int i = 0; i < settings.numHandbells; i++)
                    {
                        simulator[0].KeyBS[i] = br.ReadString();
                        simulator[0].KeyHS[i] = br.ReadString();
                        simulator[0].KeyB1[i] = br.ReadString();
                        simulator[0].KeyB2[i] = br.ReadString();
                        simulator[0].KeyB3[i] = br.ReadString();
                        simulator[0].KeyB4[i] = br.ReadString();
                        BSP[i] = br.ReadInt32();
                        HSP[i] = br.ReadInt32();
                        swingAxis[i] = br.ReadInt32();
                    }
                    simulator[0].UseKeyUpDown = br.ReadBoolean();
                }

                // Command line options
                // -r        : run the current simulator upon startup
                // -s <0-5>  : Set simulator 0 (Abel), 1 (Beltower), 2 (RingingMaster), 3 (RingingRoom), 4 (Muster), 5 (Ding) - overrides current setting.
                // -c <name> : Set the child window class - or URL for RingingRoom
                // -p        : Set the simulator process name
                // -u <url>  : Sets the URL for RingingRoom (Simulator 3)
                string[] arguments = Environment.GetCommandLineArgs();
                int narg = arguments.GetLength(0);
                int idx = 1;
                while (narg > 1)
                {
                    switch (arguments[idx++].ToUpper())
                    {
                        // Simulator selection 0-3
                        case "-S":
                            narg--;
                            Int32 simNum = Int32.Parse(arguments[idx++]);
                            if (simNum >= 0 && simNum < numSimulators)
                                currentSimulator = simNum;
                            narg--;
                            break;
                        // auto-run simulator upon startup
                        case "-R":
                            autoRunSimulator = true;		
                            narg--;
                            break;
                        // Process name for simulator
                        case "-P":
                            narg--;
                            simulator[currentSimulator].ProcessName = arguments[idx++];
                            narg--;
                            break;
                        // ChildWindow name for simulator (e.g. URL for RingingRoom)
                        case "-C":
                            narg--;
                            simulator[currentSimulator].ChildWindowClassName = arguments[idx++];
                            narg--;
                            break;
                        case "-U":
                            narg--;
                            simulator[currentSimulator].ChildWindowName = arguments[idx++];
                            narg--;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open Settings Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                br.Close();
                fs.Close();
            }
        }

        public static void Save()
        {
            try
            {
                CreateFolder();
                var settingsVersion = settingsVersionHistory[0];
                FileStream fs = new FileStream(GetSettingsFilename(settingsVersion), FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                
                bw.Write(settingsVersion.versionNumber);
#if DEBUG
                if (settingsVersion.versionNumber == 110)
                {   // This code would only ever be used if forcing generation of a v110 file for testing purposes
                    bw.Write(simulator[0].ProcessName);
                    //Write Calibration Settings
                    bw.Write(debounceDelay);
                    bw.Write(handstrokeStrikeDelay);
                    bw.Write(backstrokeStrikeDelay);
                    for (int i = 0; i < settingsVersion.numHandbells; i++)
                    {
                        bw.Write(simulator[0].KeyBS[i]);
                        bw.Write(simulator[0].KeyHS[i]);
                        bw.Write(simulator[0].KeyB1[i]);
                        bw.Write(simulator[0].KeyB2[i]);
                        bw.Write(simulator[0].KeyB3[i]);
                        bw.Write(simulator[0].KeyB4[i]);
                        bw.Write(BSP[i]);
                        bw.Write(HSP[i]);
                        bw.Write(swingAxis[i]);
                    }
                    bw.Write(simulator[0].UseKeyUpDown);
                    bw.Close();
                    fs.Close();
                    return;
                }
#endif
                //Write Calibration Settings
                bw.Write(debounceDelay);
                bw.Write(handstrokeStrikeDelay);
                bw.Write(backstrokeStrikeDelay);
                for (int i = 0; i < settingsVersion.numHandbells; i++)
                {
                    bw.Write(BSP[i]);
                    bw.Write(HSP[i]);
                    bw.Write(swingAxis[i]);
                }
                //Write Current Simulator Index
                bw.Write(currentSimulator);
                //Write Simulator Settings
                for (int j = 0; j < settingsVersion.numSimulators; j++)
                {
                    bw.Write(simulator[j].Name);
                    bw.Write(simulator[j].ProcessName);
                    bw.Write(simulator[j].ChildWindowClassName);
                    bw.Write(simulator[j].ChildWindowName);
                    bw.Write(simulator[j].GrandchildWindowClassName); 
                    bw.Write(simulator[j].GrandchildWindowName);
                    bw.Write(simulator[j].UseKeyUpDown);
                    for (int i = 0; i < numHandbells; i++)
                    {
                        bw.Write(simulator[j].KeyBS[i]);
                        bw.Write(simulator[j].KeyHS[i]);
                        bw.Write(simulator[j].KeyB1[i]);
                        bw.Write(simulator[j].KeyB2[i]);
                        bw.Write(simulator[j].KeyB3[i]);
                        bw.Write(simulator[j].KeyB4[i]);
                    }
                }
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Settings Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
    }
}