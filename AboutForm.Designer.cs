namespace HandbellManager
{
	partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblName = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lnkemail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkemail1 = new System.Windows.Forms.LinkLabel();
            this.lnkemail2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(79, 28);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(171, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Handbell Manager Version x.x";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(79, 58);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(236, 15);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright (C) Graham A C John 2009-2020";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(385, 249);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.Location = new System.Drawing.Point(16, 28);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(43, 39);
            this.pnlLogo.TabIndex = 3;
            // 
            // lnkemail
            // 
            this.lnkemail.AutoSize = true;
            this.lnkemail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkemail.Location = new System.Drawing.Point(79, 87);
            this.lnkemail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkemail.Name = "lnkemail";
            this.lnkemail.Size = new System.Drawing.Size(171, 15);
            this.lnkemail.TabIndex = 4;
            this.lnkemail.TabStop = true;
            this.lnkemail.Text = "graham@changeringing.co.uk";
            this.lnkemail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkemail_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Support for RingingRoom and Muster added by Adrian Nash.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 8;
            // 
            // lnkemail1
            // 
            this.lnkemail1.AutoSize = true;
            this.lnkemail1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkemail1.Location = new System.Drawing.Point(79, 155);
            this.lnkemail1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkemail1.Name = "lnkemail1";
            this.lnkemail1.Size = new System.Drawing.Size(190, 15);
            this.lnkemail1.TabIndex = 7;
            this.lnkemail1.TabStop = true;
            this.lnkemail1.Text = "adrian.nashmail@btinternet.com";
            this.lnkemail1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkemail1_LinkClicked);
            // 
            // lnkemail2
            // 
            this.lnkemail2.AutoSize = true;
            this.lnkemail2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkemail2.Location = new System.Drawing.Point(79, 222);
            this.lnkemail2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkemail2.Name = "lnkemail2";
            this.lnkemail2.Size = new System.Drawing.Size(137, 15);
            this.lnkemail2.TabIndex = 10;
            this.lnkemail2.TabStop = true;
            this.lnkemail2.Text = "gilesrwood@gmail.com";
            this.lnkemail2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkemail2_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Support for Ding added by Giles Wood.";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 292);
            this.Controls.Add(this.lnkemail2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkemail1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkemail);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Handbell Manager ";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel pnlLogo;
		private System.Windows.Forms.LinkLabel lnkemail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkemail1;
        private System.Windows.Forms.LinkLabel lnkemail2;
        private System.Windows.Forms.Label label3;
    }
}