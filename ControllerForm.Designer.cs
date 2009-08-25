namespace HandbellManager
{
	partial class ControllerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
			this.lstController = new System.Windows.Forms.ListBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstController
			// 
			this.lstController.FormattingEnabled = true;
			this.lstController.IntegralHeight = false;
			this.lstController.Location = new System.Drawing.Point(12, 12);
			this.lstController.Name = "lstController";
			this.lstController.Size = new System.Drawing.Size(294, 112);
			this.lstController.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(265, 132);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(85, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnUp
			// 
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.Location = new System.Drawing.Point(312, 12);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(40, 40);
			this.btnUp.TabIndex = 8;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.Location = new System.Drawing.Point(312, 57);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(40, 40);
			this.btnDown.TabIndex = 9;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// ControllerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 167);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lstController);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ControllerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assign Controllers to Handbells";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstController;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
	}
}