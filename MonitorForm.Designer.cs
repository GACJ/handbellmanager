namespace HandbellManager
{
	partial class MonitorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
			this.c2dGraph1 = new CustomUIControls.Graphing.C2DPushGraph();
			this.graphMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.handbellLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.strikeSignalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell0ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell1ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell2ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell3ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.calibrationLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell0ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.handbell3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.graphMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// c2dGraph1
			// 
			this.c2dGraph1.AutoAdjustPeek = false;
			this.c2dGraph1.BackColor = System.Drawing.Color.Black;
			this.c2dGraph1.ContextMenuStrip = this.graphMenuStrip;
			this.c2dGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c2dGraph1.GridColor = System.Drawing.Color.Green;
			this.c2dGraph1.GridSize = ((ushort)(15));
			this.c2dGraph1.HighQuality = true;
			this.c2dGraph1.LineInterval = ((ushort)(5));
			this.c2dGraph1.Location = new System.Drawing.Point(0, 0);
			this.c2dGraph1.MaxLabel = "Max";
			this.c2dGraph1.MaxPeekMagnitude = 100;
			this.c2dGraph1.MinLabel = "Minimum";
			this.c2dGraph1.MinPeekMagnitude = 0;
			this.c2dGraph1.Name = "c2dGraph1";
			this.c2dGraph1.ShowGrid = true;
			this.c2dGraph1.ShowLabels = true;
			this.c2dGraph1.Size = new System.Drawing.Size(744, 366);
			this.c2dGraph1.TabIndex = 4;
			this.c2dGraph1.Text = "c2DPushGraph1";
			this.c2dGraph1.TextColor = System.Drawing.Color.Yellow;
			// 
			// graphMenuStrip
			// 
			this.graphMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeToolStripMenuItem,
            this.toolStripSeparator1,
            this.handbellLinesToolStripMenuItem,
            this.strikeSignalsToolStripMenuItem,
            this.calibrationLinesToolStripMenuItem});
			this.graphMenuStrip.Name = "graphMenuStrip";
			this.graphMenuStrip.Size = new System.Drawing.Size(163, 98);
			// 
			// freezeToolStripMenuItem
			// 
			this.freezeToolStripMenuItem.CheckOnClick = true;
			this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
			this.freezeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.freezeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.freezeToolStripMenuItem.Text = "Freeze";
			this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
			// 
			// handbellLinesToolStripMenuItem
			// 
			this.handbellLinesToolStripMenuItem.Checked = true;
			this.handbellLinesToolStripMenuItem.CheckOnClick = true;
			this.handbellLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbellLinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handbell0ToolStripMenuItem,
            this.handbell1ToolStripMenuItem,
            this.handbell2ToolStripMenuItem,
            this.handbell3ToolStripMenuItem});
			this.handbellLinesToolStripMenuItem.Name = "handbellLinesToolStripMenuItem";
			this.handbellLinesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.handbellLinesToolStripMenuItem.Text = "Handbell Lines";
			this.handbellLinesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.handbellLines_CheckChanged);
			// 
			// handbell0ToolStripMenuItem
			// 
			this.handbell0ToolStripMenuItem.Checked = true;
			this.handbell0ToolStripMenuItem.CheckOnClick = true;
			this.handbell0ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell0ToolStripMenuItem.Name = "handbell0ToolStripMenuItem";
			this.handbell0ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.handbell0ToolStripMenuItem.Text = "Handbell 1";
			this.handbell0ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.lineToolStripMenuItem_Click);
			this.handbell0ToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell1ToolStripMenuItem
			// 
			this.handbell1ToolStripMenuItem.Checked = true;
			this.handbell1ToolStripMenuItem.CheckOnClick = true;
			this.handbell1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell1ToolStripMenuItem.Name = "handbell1ToolStripMenuItem";
			this.handbell1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.handbell1ToolStripMenuItem.Text = "Handbell 2";
			this.handbell1ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.lineToolStripMenuItem_Click);
			this.handbell1ToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell2ToolStripMenuItem
			// 
			this.handbell2ToolStripMenuItem.Checked = true;
			this.handbell2ToolStripMenuItem.CheckOnClick = true;
			this.handbell2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell2ToolStripMenuItem.Name = "handbell2ToolStripMenuItem";
			this.handbell2ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.handbell2ToolStripMenuItem.Text = "Handbell 3";
			this.handbell2ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.lineToolStripMenuItem_Click);
			this.handbell2ToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell3ToolStripMenuItem
			// 
			this.handbell3ToolStripMenuItem.Checked = true;
			this.handbell3ToolStripMenuItem.CheckOnClick = true;
			this.handbell3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell3ToolStripMenuItem.Name = "handbell3ToolStripMenuItem";
			this.handbell3ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.handbell3ToolStripMenuItem.Text = "Handbell 4";
			this.handbell3ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.lineToolStripMenuItem_Click);
			this.handbell3ToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// strikeSignalsToolStripMenuItem
			// 
			this.strikeSignalsToolStripMenuItem.Checked = true;
			this.strikeSignalsToolStripMenuItem.CheckOnClick = true;
			this.strikeSignalsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.strikeSignalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handbell0ToolStripMenuItem2,
            this.handbell1ToolStripMenuItem2,
            this.handbell2ToolStripMenuItem2,
            this.handbell3ToolStripMenuItem2});
			this.strikeSignalsToolStripMenuItem.Name = "strikeSignalsToolStripMenuItem";
			this.strikeSignalsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.strikeSignalsToolStripMenuItem.Text = "Strike Signals";
			this.strikeSignalsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.strikeSignals_CheckChanged);
			// 
			// handbell0ToolStripMenuItem2
			// 
			this.handbell0ToolStripMenuItem2.Checked = true;
			this.handbell0ToolStripMenuItem2.CheckOnClick = true;
			this.handbell0ToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell0ToolStripMenuItem2.Name = "handbell0ToolStripMenuItem2";
			this.handbell0ToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
			this.handbell0ToolStripMenuItem2.Text = "Handbell 1";
			this.handbell0ToolStripMenuItem2.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell1ToolStripMenuItem2
			// 
			this.handbell1ToolStripMenuItem2.Checked = true;
			this.handbell1ToolStripMenuItem2.CheckOnClick = true;
			this.handbell1ToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell1ToolStripMenuItem2.Name = "handbell1ToolStripMenuItem2";
			this.handbell1ToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
			this.handbell1ToolStripMenuItem2.Text = "Handbell 2";
			this.handbell1ToolStripMenuItem2.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell2ToolStripMenuItem2
			// 
			this.handbell2ToolStripMenuItem2.Checked = true;
			this.handbell2ToolStripMenuItem2.CheckOnClick = true;
			this.handbell2ToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell2ToolStripMenuItem2.Name = "handbell2ToolStripMenuItem2";
			this.handbell2ToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
			this.handbell2ToolStripMenuItem2.Text = "Handbell 3";
			this.handbell2ToolStripMenuItem2.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell3ToolStripMenuItem2
			// 
			this.handbell3ToolStripMenuItem2.Checked = true;
			this.handbell3ToolStripMenuItem2.CheckOnClick = true;
			this.handbell3ToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell3ToolStripMenuItem2.Name = "handbell3ToolStripMenuItem2";
			this.handbell3ToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
			this.handbell3ToolStripMenuItem2.Text = "Handbell 4";
			this.handbell3ToolStripMenuItem2.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// calibrationLinesToolStripMenuItem
			// 
			this.calibrationLinesToolStripMenuItem.Checked = true;
			this.calibrationLinesToolStripMenuItem.CheckOnClick = true;
			this.calibrationLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.calibrationLinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handbell0ToolStripMenuItem1,
            this.handbell1ToolStripMenuItem1,
            this.handbell2ToolStripMenuItem1,
            this.handbell3ToolStripMenuItem1});
			this.calibrationLinesToolStripMenuItem.Name = "calibrationLinesToolStripMenuItem";
			this.calibrationLinesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.calibrationLinesToolStripMenuItem.Text = "Calibration Lines";
			this.calibrationLinesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.calibrationLines_CheckChanged);
			// 
			// handbell0ToolStripMenuItem1
			// 
			this.handbell0ToolStripMenuItem1.Checked = true;
			this.handbell0ToolStripMenuItem1.CheckOnClick = true;
			this.handbell0ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell0ToolStripMenuItem1.Name = "handbell0ToolStripMenuItem1";
			this.handbell0ToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.handbell0ToolStripMenuItem1.Text = "Handbell 1";
			this.handbell0ToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell1ToolStripMenuItem1
			// 
			this.handbell1ToolStripMenuItem1.Checked = true;
			this.handbell1ToolStripMenuItem1.CheckOnClick = true;
			this.handbell1ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell1ToolStripMenuItem1.Name = "handbell1ToolStripMenuItem1";
			this.handbell1ToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.handbell1ToolStripMenuItem1.Text = "Handbell 2";
			this.handbell1ToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell2ToolStripMenuItem1
			// 
			this.handbell2ToolStripMenuItem1.Checked = true;
			this.handbell2ToolStripMenuItem1.CheckOnClick = true;
			this.handbell2ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell2ToolStripMenuItem1.Name = "handbell2ToolStripMenuItem1";
			this.handbell2ToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.handbell2ToolStripMenuItem1.Text = "Handbell 3";
			this.handbell2ToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// handbell3ToolStripMenuItem1
			// 
			this.handbell3ToolStripMenuItem1.Checked = true;
			this.handbell3ToolStripMenuItem1.CheckOnClick = true;
			this.handbell3ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.handbell3ToolStripMenuItem1.Name = "handbell3ToolStripMenuItem1";
			this.handbell3ToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.handbell3ToolStripMenuItem1.Text = "Handbell 4";
			this.handbell3ToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// MonitorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 366);
			this.Controls.Add(this.c2dGraph1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MonitorForm";
			this.Text = "Handbell Monitor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
			this.graphMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CustomUIControls.Graphing.C2DPushGraph c2dGraph1;
		private System.Windows.Forms.ContextMenuStrip graphMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem handbellLinesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell0ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem calibrationLinesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell0ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem handbell1ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem handbell2ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem handbell3ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem strikeSignalsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem handbell0ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem handbell1ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem handbell2ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem handbell3ToolStripMenuItem2;
	}
}