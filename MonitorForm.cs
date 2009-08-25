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
using CustomUIControls.Graphing;

namespace HandbellManager
{
	public partial class MonitorForm : Form
	{
		private C2DPushGraph.LineHandle[] _ZAxisGraphLine;
		private C2DPushGraph.LineHandle[] _strikingGraphLine;
		private C2DPushGraph.LineHandle[] _handstrokeStrikeLine;
		private C2DPushGraph.LineHandle[] _backstrokeStrikeLine;

		private bool _frozen;

		private Color[] _lineColours = new Color[] { Color.White, Color.Yellow, Color.Pink, Color.Cyan };

		public MonitorForm()
		{
			InitializeComponent();

			c2dGraph1.MaxPeekMagnitude = 2200;
			c2dGraph1.MaxLabel = "+2200";
			c2dGraph1.MinPeekMagnitude = -2200;
			c2dGraph1.MinLabel = "-2200";

			InitLines();
		}

		private void InitLines()
		{
			_ZAxisGraphLine = new C2DPushGraph.LineHandle[4];
			_strikingGraphLine = new C2DPushGraph.LineHandle[4];
			_handstrokeStrikeLine = new C2DPushGraph.LineHandle[4];
			_backstrokeStrikeLine = new C2DPushGraph.LineHandle[4];
			for (int i = 0; i < 4; i++)
			{
				if (((ToolStripMenuItem)(calibrationLinesToolStripMenuItem.DropDownItems[i])).Checked)
				{
					_handstrokeStrikeLine[i] = c2dGraph1.AddLine(i + 8, _lineColours[i]);
					_backstrokeStrikeLine[i] = c2dGraph1.AddLine(i + 12, _lineColours[i]);
				}
				if (((ToolStripMenuItem)(strikeSignalsToolStripMenuItem.DropDownItems[i])).Checked)
				{
					_strikingGraphLine[i] = c2dGraph1.AddLine(i + 4, _lineColours[i]);
					_strikingGraphLine[i].ShowAsBar = true;
				}
				if (((ToolStripMenuItem)(handbellLinesToolStripMenuItem.DropDownItems[i])).Checked)
				{
					_ZAxisGraphLine[i] = c2dGraph1.AddLine(i, _lineColours[i]);
					_ZAxisGraphLine[i].Thickness = 3;
				}
			}
		}

		private void DeinitLines()
		{
			for (int i = 0; i < 16; i++)
			{
				c2dGraph1.RemoveLine(i);
			}
		}

		public void ReInitLines()
		{
			DeinitLines();
			InitLines();
		}

		public void UpdateGraph(Handbell [] handbell, int handbellCount)
		{
			if (_frozen)
				return;

			int hbCt = handbellCount;
			if (hbCt > 4)
				hbCt = 4;

			for (int i = 0; i < hbCt; i++)
			{
				if (((ToolStripMenuItem)(calibrationLinesToolStripMenuItem.DropDownItems[i])).Checked)
				{
					c2dGraph1.Push(handbell[i].HandstrokeStrikePoint, i + 8);
					c2dGraph1.Push(handbell[i].BackstrokeStrikePoint, i + 12);
				}
				if (((ToolStripMenuItem)(strikeSignalsToolStripMenuItem.DropDownItems[i])).Checked)
				{
					if (handbell[i].BackstrokeStrike || handbell[i].HandstrokeStrike)
					{
						c2dGraph1.Push(handbell[i].CurrentZ, i + 4);
					}
					else
					{
						c2dGraph1.Push(c2dGraph1.MinPeekMagnitude, i + 4);
					}
				}
				if (((ToolStripMenuItem)(handbellLinesToolStripMenuItem.DropDownItems[i])).Checked)
				{
					c2dGraph1.Push(handbell[i].CurrentZ, i);
				}
			}
			c2dGraph1.UpdateGraph();
		}

		private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_frozen = freezeToolStripMenuItem.Checked;
		}

		private void lineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReInitLines();
		}

		private void handbellLines_CheckChanged(object sender, EventArgs e)
		{
			if (handbellLinesToolStripMenuItem.Checked)
			{
				handbell0ToolStripMenuItem.Checked = true;
				handbell1ToolStripMenuItem.Checked = true;
				handbell2ToolStripMenuItem.Checked = true;
				handbell3ToolStripMenuItem.Checked = true;
			}
			else
			{
				handbell0ToolStripMenuItem.Checked = false;
				handbell1ToolStripMenuItem.Checked = false;
				handbell2ToolStripMenuItem.Checked = false;
				handbell3ToolStripMenuItem.Checked = false;
			}
			ReInitLines();
		}

		private void strikeSignals_CheckChanged(object sender, EventArgs e)
		{
			if (strikeSignalsToolStripMenuItem.Checked)
			{
				handbell0ToolStripMenuItem2.Checked = true;
				handbell1ToolStripMenuItem2.Checked = true;
				handbell2ToolStripMenuItem2.Checked = true;
				handbell3ToolStripMenuItem2.Checked = true;
			}
			else
			{
				handbell0ToolStripMenuItem2.Checked = false;
				handbell1ToolStripMenuItem2.Checked = false;
				handbell2ToolStripMenuItem2.Checked = false;
				handbell3ToolStripMenuItem2.Checked = false;
			}
			ReInitLines();
		}
		
		private void calibrationLines_CheckChanged(object sender, EventArgs e)
		{
			if (calibrationLinesToolStripMenuItem.Checked)
			{
				handbell0ToolStripMenuItem1.Checked = true;
				handbell1ToolStripMenuItem1.Checked = true;
				handbell2ToolStripMenuItem1.Checked = true;
				handbell3ToolStripMenuItem1.Checked = true;
			}
			else
			{
				handbell0ToolStripMenuItem1.Checked = false;
				handbell1ToolStripMenuItem1.Checked = false;
				handbell2ToolStripMenuItem1.Checked = false;
				handbell3ToolStripMenuItem1.Checked = false;
			}
			ReInitLines();
		}
	}
}
