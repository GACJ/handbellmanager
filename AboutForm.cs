﻿// This file is part of Handbell Manager.
// Copyright Graham John 2009-2021. graham@changeringing.co.uk
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
using System.Windows.Forms;
using System.Diagnostics;

namespace HandbellManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Text = String.Format("About {0}", Application.ProductName);
            lblName.Text = String.Format("{0} Version {1}", Application.ProductName, Application.ProductVersion);
            lblCopyright.Text = "Copyright © Graham A C John 2009-2021";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkemail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("mailto:graham@changeringing.co.uk?subject=Handbell Manager");
            }
            catch
            {
            }
        }

        private void lnkemail1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("mailto:adrian.nashmail@btinternet.com?subject=Handbell Manager");
            }
            catch
            {
            }
        }

        private void lnkemail2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("mailto:gilesrwood@gmail.com?subject=Handbell%20Manager");
            }
            catch
            {
            }
        }
    }
}
