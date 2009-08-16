namespace HandbellManager
{
	partial class CalibrationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpInstruction = new System.Windows.Forms.GroupBox();
			this.lblInstruction = new System.Windows.Forms.Label();
			this.tmrCalibration = new System.Windows.Forms.Timer(this.components);
			this.grpInstruction.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(205, 119);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// grpInstruction
			// 
			this.grpInstruction.Controls.Add(this.lblInstruction);
			this.grpInstruction.Location = new System.Drawing.Point(13, 13);
			this.grpInstruction.Name = "grpInstruction";
			this.grpInstruction.Size = new System.Drawing.Size(267, 100);
			this.grpInstruction.TabIndex = 2;
			this.grpInstruction.TabStop = false;
			this.grpInstruction.Text = "Heading";
			// 
			// lblInstruction
			// 
			this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblInstruction.Location = new System.Drawing.Point(3, 16);
			this.lblInstruction.Name = "lblInstruction";
			this.lblInstruction.Size = new System.Drawing.Size(261, 81);
			this.lblInstruction.TabIndex = 0;
			this.lblInstruction.Text = "Instruction";
			this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tmrCalibration
			// 
			this.tmrCalibration.Enabled = true;
			this.tmrCalibration.Tick += new System.EventHandler(this.tmrCalibration_Tick);
			// 
			// CalibrationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 148);
			this.ControlBox = false;
			this.Controls.Add(this.grpInstruction);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CalibrationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Handbell Calibration";
			this.grpInstruction.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grpInstruction;
		private System.Windows.Forms.Label lblInstruction;
		private System.Windows.Forms.Timer tmrCalibration;
	}
}