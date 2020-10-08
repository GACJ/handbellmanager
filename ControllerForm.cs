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
using System.Windows.Forms;

namespace HandbellManager
{
    public partial class ControllerForm : Form
    {
        MotionControllerManager.MotionControllerManager _mcm;
        Handbell[] _hb;
        public ControllerForm(MotionControllerManager.MotionControllerManager mcm, Handbell [] hb)
        {
            InitializeComponent();
            _mcm = mcm;
            _hb = hb;
            listControllers();
            lstController.SelectedIndex = 0;
        }

        private void listControllers()
        {
            string cName;
            int[] cs = ConfigForm.ControllerSequence;
            //List controllers
            lstController.Items.Clear();
            for (int i = 0; i < _mcm.Count; i++)
            {
                if (i < 4)
                    //Assigned
                    cName = "Handbell " + Convert.ToString(i + 1) + " - " + _mcm.ApplicationDevices[cs[i]].DeviceInformation.ProductName + " (" + Convert.ToString(cs[i] + 1) + ")";
                else
                    //Not assigned
                    cName = "Unassigned - " + _mcm.ApplicationDevices[cs[i]].DeviceInformation.ProductName + " (" + Convert.ToString(cs[i] + 1) + ")";
                lstController.Items.Add(cName);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int c;
            int [] cs = ConfigForm.ControllerSequence;
            int si = lstController.SelectedIndex;
            if (si > 0)
                {
                    //Switch controllers in list
                    c = cs[si];
                    cs[si] = cs[si - 1];
                    cs[si - 1] = c;
                    //Reassign controllers to handbells
                    if (si < 4)
                    {
                        _hb[si].Controller = cs[si];
                    }
                    if (si - 1 < 4)
                    {
                        _hb[si - 1].Controller = cs[si - 1];
                    }
                    listControllers();
                    lstController.SelectedIndex = si - 1;
                }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int c;
            int[] cs = ConfigForm.ControllerSequence;
            int si = lstController.SelectedIndex;
            if (si + 1 < _mcm.Count)
            {
                //Switch controllers in list
                c = cs[si];
                cs[si] = cs[si + 1];
                cs[si + 1] = c;
                //Reassign controllers to handbells
                if (si < 4)
                {
                    _hb[si].Controller = cs[si];
                }
                if (si + 1 < 4)
                {
                    _hb[si + 1].Controller = cs[si + 1];
                }
                listControllers();
                lstController.SelectedIndex = si + 1;
            }
        }
    }
}
