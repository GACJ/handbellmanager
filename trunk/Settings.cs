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
using System.Windows.Forms;
using System.IO;

namespace HandbellManager
{

	static class Settings
	{
		public static int settingsVersion = 120; //Change when Settings File format changes
		public static int previousSettingsVersion = 110; //Change when Settings File format changes
		public static Simulator[] simulator = new Simulator[3];
		public static int currentSimulator = 0;
		public static int[] swingAxis = new int[] { 2, 2, 2, 2 };
		public static int[] BSP = new int[] { 0, 0, 0, 0 };
		public static int[] HSP = new int[] { 0, 0, 0, 0 };
		public static int debounceDelay = 0;
		public static int handstrokeStrikeDelay = 0;
		public static int backstrokeStrikeDelay = 0;

		public static void Default()
		{
			switch (currentSimulator)
			{
				case 0:
					simulator[0].Name = "Abel";
					simulator[0].ProcessName = "Abel3";
					simulator[0].ChildWindowClassName = "AfxMDIFrame80s";
					simulator[0].ChildWindowName = "";
					simulator[0].GrandchildWindowClassName = "AfxFrameOrView80s";
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
			}
			//Calibration defaults
			debounceDelay = 350;
			handstrokeStrikeDelay = 0;
			backstrokeStrikeDelay = 0;
			swingAxis = new int[] { 2, 2, 2, 2 };
			BSP = new int[] { -600, -600, -600, -600 };
			HSP = new int[] { 100, 100, 100, 100 };
		}

		public static string SettingsFilename
		{
			get
			{
				string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string appName = "Handbell Manager";
				string settingsFile = "settings" + settingsVersion + ".cfg";
				return Path.Combine(Path.Combine(appData, appName), settingsFile);
			}
		}

		public static string Folder
		{
			get
			{
				return Path.GetDirectoryName(SettingsFilename);
			}
		}

		public static void CreateFolder()
		{
			if (!Directory.Exists(Folder))
			{
				Directory.CreateDirectory(Folder); 
			}
		}

		public static void Open()
		{
			for (int j = 0; j < 3; j++)
			{
				currentSimulator = j;
				simulator[j] = new Simulator();
				Default();
			}
			currentSimulator = 0;

			if (!File.Exists(SettingsFilename))
			{
				//Get previous settings, if any
				GetPreviousSettings();
				//Save default settings
				Save();
				return;
			}

			FileStream fs = null;
			BinaryReader br = null;
			try
			{
				fs = new FileStream(SettingsFilename, FileMode.Open, FileAccess.Read);
				br = new BinaryReader(fs);

				int fileversion = br.ReadInt32();
				if (fileversion == settingsVersion)
				{
					//Get Calibration Settings
					debounceDelay = br.ReadInt32();
					handstrokeStrikeDelay = br.ReadInt32();
					backstrokeStrikeDelay = br.ReadInt32();
					for (int i = 0; i < 4; i++)
					{
						BSP[i] = br.ReadInt32();
						HSP[i] = br.ReadInt32();
						swingAxis[i] = br.ReadInt32();
					}
					//Get Current Simulator
					currentSimulator = br.ReadInt32();
					//Get Simulator settings
					for (int j = 0; j < 3; j++)
					{
						simulator[j].Name = br.ReadString();
						simulator[j].ProcessName = br.ReadString();
						simulator[j].ChildWindowClassName = br.ReadString();
						simulator[j].ChildWindowName = br.ReadString();
						simulator[j].GrandchildWindowClassName = br.ReadString();
						simulator[j].GrandchildWindowName = br.ReadString();
						simulator[j].UseKeyUpDown = br.ReadBoolean();
						for (int i = 0; i < 4; i++)
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
				FileStream fs = new FileStream(SettingsFilename, FileMode.Create, FileAccess.ReadWrite);
				BinaryWriter bw = new BinaryWriter(fs);

				bw.Write(settingsVersion);
				//Write Calibration Settings
				bw.Write(debounceDelay);
				bw.Write(handstrokeStrikeDelay);
				bw.Write(backstrokeStrikeDelay);
				for (int i = 0; i < 4; i++)
				{
					bw.Write(BSP[i]);
					bw.Write(HSP[i]);
					bw.Write(swingAxis[i]);
				}
				//Write Current Simulator Index
				bw.Write(currentSimulator);
				//Write Simulator Settings
				for (int j = 0; j < 3; j++)
				{
					bw.Write(simulator[j].Name);
					bw.Write(simulator[j].ProcessName);
					bw.Write(simulator[j].ChildWindowClassName);
					bw.Write(simulator[j].ChildWindowName);
					bw.Write(simulator[j].GrandchildWindowClassName); 
					bw.Write(simulator[j].GrandchildWindowName);
					bw.Write(simulator[j].UseKeyUpDown);
					for (int i = 0; i < 4; i++)
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
		public static void GetPreviousSettings()
		{
			//Read previous version of settings file
			int version = settingsVersion;
			settingsVersion = previousSettingsVersion;

			if (!File.Exists(SettingsFilename))
			{
				settingsVersion = version;
				return;
			}

			FileStream fs = null;
			BinaryReader br = null;
			try
			{
				fs = new FileStream(SettingsFilename, FileMode.Open, FileAccess.Read);
				br = new BinaryReader(fs);

				int fileversion = br.ReadInt32();
				if (fileversion == settingsVersion)
				{
					simulator[0].ProcessName = br.ReadString();
					debounceDelay = br.ReadInt32();
					handstrokeStrikeDelay = br.ReadInt32();
					backstrokeStrikeDelay = br.ReadInt32();
					for (int i = 0; i < 4; i++)
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Open Settings Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				//revert to latest version
				settingsVersion = version;
				br.Close();
				fs.Close();
			}
		}
	}
}