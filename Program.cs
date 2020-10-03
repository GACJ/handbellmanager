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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace HandbellManager
{
    static class Program
    {
        static ConfigForm _configForm;

        [STAThread]
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                Settings.Open();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Create the config form
                _configForm = new ConfigForm();

                Application.Run(_configForm);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public static ConfigForm ConfigForm
        {
            get
            {
                return _configForm;
            }
        }
    }
}
