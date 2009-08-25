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
		public static int settingsVersion = 110; //Change when Settings File format changes
		public static string abelProcessName = " ";
		public static int debounceDelay = 0;
		public static int handstrokeStrikeDelay = 0;
		public static int backstrokeStrikeDelay = 0;
		public static string[] keyBS = new string[] { " ", " ", " ", " " };
		public static string[] keyHS = new string[] { " ", " ", " ", " " };
		public static string[] keyB1 = new string[] { " ", " ", " ", " " };
		public static string[] keyB2 = new string[] { " ", " ", " ", " " };
		public static string[] keyB3 = new string[] { " ", " ", " ", " " };
		public static string[] keyB4 = new string[] { " ", " ", " ", " " };
		public static bool useKeyUpDown = false;

		public static int[] swingAxis = new int[] { 2, 2, 2, 2 };
		public static int[] BSP = new int[] { 0, 0, 0, 0 };
		public static int[] HSP = new int[] { 0, 0, 0, 0 };

		public static void Default()
		{
			abelProcessName = "Abel3";
			debounceDelay = 350;
			handstrokeStrikeDelay = 0;
			backstrokeStrikeDelay = 0;
			keyBS = new string[] { "J", "F", "R", "U" };
			keyHS = new string[] { "J", "F", "R", "U" };
			keyB1 = new string[] { "F9", "A", "F9", "A" };
			keyB2 = new string[] { "G", ";", "G", ";" };
			keyB3 = new string[] { "F9", "A", "F9", "A" };
			keyB4 = new string[] { "G", ";", "G", ";" };
			useKeyUpDown = true;
			swingAxis = new int[] { 2, 2, 2, 2 };
			BSP = new int[] { -600, -600, -600, -600 };
			HSP = new int[] { 100, 100, 100, 100 };
		}

		public static string Filename
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
				return Path.GetDirectoryName(Filename);
			}
		}

		public static bool SettingsFileExists()
		{
			return (File.Exists(Filename));
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
			Default();
			if (!SettingsFileExists())
			{
				//Save default settings
				Save();
				return;
			}

			FileStream fs = null;
			BinaryReader br = null;
			try
			{
				fs = new FileStream(Filename, FileMode.Open, FileAccess.Read);
				br = new BinaryReader(fs);

				int fileversion = br.ReadInt32();
				if (fileversion == settingsVersion)
				{
					abelProcessName = br.ReadString();
					debounceDelay = br.ReadInt32();
					handstrokeStrikeDelay = br.ReadInt32();
					backstrokeStrikeDelay = br.ReadInt32();
					for (int i = 0; i < 4; i++)
					{
						keyBS[i] = br.ReadString();
						keyHS[i] = br.ReadString();
						keyB1[i] = br.ReadString();
						keyB2[i] = br.ReadString();
						keyB3[i] = br.ReadString();
						keyB4[i] = br.ReadString();
						BSP[i] = br.ReadInt32();
						HSP[i] = br.ReadInt32();
						swingAxis[i] = br.ReadInt32();
					}
					useKeyUpDown = br.ReadBoolean();
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
				FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.ReadWrite);
				BinaryWriter bw = new BinaryWriter(fs);

				bw.Write(settingsVersion);
				bw.Write(abelProcessName);
				bw.Write(debounceDelay);
				bw.Write(handstrokeStrikeDelay);
				bw.Write(backstrokeStrikeDelay);
				for (int i = 0; i < 4; i++)
				{
					bw.Write(keyBS[i]);
					bw.Write(keyHS[i]);
					bw.Write(keyB1[i]);
					bw.Write(keyB2[i]);
					bw.Write(keyB3[i]);
					bw.Write(keyB4[i]);
					bw.Write(BSP[i]);
					bw.Write(HSP[i]);
					bw.Write(swingAxis[i]);
				}
				bw.Write(useKeyUpDown);
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