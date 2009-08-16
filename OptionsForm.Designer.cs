namespace HandbellManager
{
	partial class OptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			this.txtProcessName = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.txtKeyB23 = new System.Windows.Forms.TextBox();
			this.txtKeyB22 = new System.Windows.Forms.TextBox();
			this.txtKeyB21 = new System.Windows.Forms.TextBox();
			this.txtKeyB20 = new System.Windows.Forms.TextBox();
			this.txtKeyB13 = new System.Windows.Forms.TextBox();
			this.txtKeyB12 = new System.Windows.Forms.TextBox();
			this.txtKeyB11 = new System.Windows.Forms.TextBox();
			this.txtKeyB10 = new System.Windows.Forms.TextBox();
			this.txtKeyBS3 = new System.Windows.Forms.TextBox();
			this.txtKeyBS2 = new System.Windows.Forms.TextBox();
			this.txtKeyBS1 = new System.Windows.Forms.TextBox();
			this.txtKeyBS0 = new System.Windows.Forms.TextBox();
			this.txtKeyHS3 = new System.Windows.Forms.TextBox();
			this.txtKeyHS2 = new System.Windows.Forms.TextBox();
			this.txtKeyHS1 = new System.Windows.Forms.TextBox();
			this.txtKeyHS0 = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.warningTip = new System.Windows.Forms.ToolTip(this.components);
			this.label31 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabHandbellCalibration = new System.Windows.Forms.TabPage();
			this.btnCalibrate3 = new System.Windows.Forms.Button();
			this.btnCalibrate2 = new System.Windows.Forms.Button();
			this.btnCalibrate1 = new System.Windows.Forms.Button();
			this.btnCalibrate0 = new System.Windows.Forms.Button();
			this.spnDebounceDelay = new System.Windows.Forms.NumericUpDown();
			this.spnDelayBS = new System.Windows.Forms.NumericUpDown();
			this.spnDelayHS = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtZ3 = new System.Windows.Forms.TextBox();
			this.txtZ2 = new System.Windows.Forms.TextBox();
			this.txtZ1 = new System.Windows.Forms.TextBox();
			this.txtZ0 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tabAbelKeyStrokes = new System.Windows.Forms.TabPage();
			this.chkUseKeyUpDown = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDefault = new System.Windows.Forms.Button();
			this.txtZBSP2 = new HandbellManager.NumericalTextBox();
			this.txtZBSP1 = new HandbellManager.NumericalTextBox();
			this.txtZBSP3 = new HandbellManager.NumericalTextBox();
			this.txtZBSP0 = new HandbellManager.NumericalTextBox();
			this.txtZHSP0 = new HandbellManager.NumericalTextBox();
			this.txtZHSP1 = new HandbellManager.NumericalTextBox();
			this.txtZHSP3 = new HandbellManager.NumericalTextBox();
			this.txtZHSP2 = new HandbellManager.NumericalTextBox();
			this.tabControl1.SuspendLayout();
			this.tabHandbellCalibration.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spnDebounceDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnDelayBS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnDelayHS)).BeginInit();
			this.tabAbelKeyStrokes.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtProcessName
			// 
			this.txtProcessName.Location = new System.Drawing.Point(159, 160);
			this.txtProcessName.Name = "txtProcessName";
			this.txtProcessName.Size = new System.Drawing.Size(263, 20);
			this.txtProcessName.TabIndex = 26;
			this.txtProcessName.Text = "Abel3";
			this.txtProcessName.TextChanged += new System.EventHandler(this.txtProcessName_TextChanged);
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(6, 163);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(103, 13);
			this.label32.TabIndex = 25;
			this.label32.Text = "Abel Process Name:";
			// 
			// txtKeyB23
			// 
			this.txtKeyB23.Location = new System.Drawing.Point(159, 97);
			this.txtKeyB23.MaxLength = 3;
			this.txtKeyB23.Name = "txtKeyB23";
			this.txtKeyB23.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB23.TabIndex = 20;
			this.txtKeyB23.Text = ";";
			this.txtKeyB23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB23.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB22
			// 
			this.txtKeyB22.Location = new System.Drawing.Point(228, 97);
			this.txtKeyB22.MaxLength = 3;
			this.txtKeyB22.Name = "txtKeyB22";
			this.txtKeyB22.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB22.TabIndex = 21;
			this.txtKeyB22.Text = "W";
			this.txtKeyB22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB22.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB21
			// 
			this.txtKeyB21.Location = new System.Drawing.Point(297, 97);
			this.txtKeyB21.MaxLength = 3;
			this.txtKeyB21.Name = "txtKeyB21";
			this.txtKeyB21.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB21.TabIndex = 22;
			this.txtKeyB21.Text = ";";
			this.txtKeyB21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB21.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB20
			// 
			this.txtKeyB20.Location = new System.Drawing.Point(365, 97);
			this.txtKeyB20.MaxLength = 3;
			this.txtKeyB20.Name = "txtKeyB20";
			this.txtKeyB20.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB20.TabIndex = 23;
			this.txtKeyB20.Text = "W";
			this.txtKeyB20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB20.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB13
			// 
			this.txtKeyB13.Location = new System.Drawing.Point(159, 74);
			this.txtKeyB13.MaxLength = 3;
			this.txtKeyB13.Name = "txtKeyB13";
			this.txtKeyB13.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB13.TabIndex = 15;
			this.txtKeyB13.Text = "A";
			this.txtKeyB13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB13.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB12
			// 
			this.txtKeyB12.Location = new System.Drawing.Point(228, 74);
			this.txtKeyB12.MaxLength = 3;
			this.txtKeyB12.Name = "txtKeyB12";
			this.txtKeyB12.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB12.TabIndex = 16;
			this.txtKeyB12.Text = "G";
			this.txtKeyB12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB12.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB11
			// 
			this.txtKeyB11.Location = new System.Drawing.Point(297, 74);
			this.txtKeyB11.MaxLength = 3;
			this.txtKeyB11.Name = "txtKeyB11";
			this.txtKeyB11.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB11.TabIndex = 17;
			this.txtKeyB11.Text = "A";
			this.txtKeyB11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB11.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyB10
			// 
			this.txtKeyB10.Location = new System.Drawing.Point(365, 74);
			this.txtKeyB10.MaxLength = 3;
			this.txtKeyB10.Name = "txtKeyB10";
			this.txtKeyB10.Size = new System.Drawing.Size(60, 20);
			this.txtKeyB10.TabIndex = 18;
			this.txtKeyB10.Text = "G";
			this.txtKeyB10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyB10.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyBS3
			// 
			this.txtKeyBS3.Location = new System.Drawing.Point(159, 30);
			this.txtKeyBS3.MaxLength = 1;
			this.txtKeyBS3.Name = "txtKeyBS3";
			this.txtKeyBS3.Size = new System.Drawing.Size(60, 20);
			this.txtKeyBS3.TabIndex = 5;
			this.txtKeyBS3.Text = "U";
			this.txtKeyBS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyBS3.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyBS2
			// 
			this.txtKeyBS2.Location = new System.Drawing.Point(228, 30);
			this.txtKeyBS2.MaxLength = 1;
			this.txtKeyBS2.Name = "txtKeyBS2";
			this.txtKeyBS2.Size = new System.Drawing.Size(60, 20);
			this.txtKeyBS2.TabIndex = 6;
			this.txtKeyBS2.Text = "R";
			this.txtKeyBS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyBS2.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyBS1
			// 
			this.txtKeyBS1.Location = new System.Drawing.Point(297, 30);
			this.txtKeyBS1.MaxLength = 1;
			this.txtKeyBS1.Name = "txtKeyBS1";
			this.txtKeyBS1.Size = new System.Drawing.Size(60, 20);
			this.txtKeyBS1.TabIndex = 7;
			this.txtKeyBS1.Text = "F";
			this.txtKeyBS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyBS1.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyBS0
			// 
			this.txtKeyBS0.Location = new System.Drawing.Point(365, 30);
			this.txtKeyBS0.MaxLength = 1;
			this.txtKeyBS0.Name = "txtKeyBS0";
			this.txtKeyBS0.Size = new System.Drawing.Size(60, 20);
			this.txtKeyBS0.TabIndex = 8;
			this.txtKeyBS0.Text = "J";
			this.txtKeyBS0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyBS0.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyHS3
			// 
			this.txtKeyHS3.Location = new System.Drawing.Point(160, 52);
			this.txtKeyHS3.MaxLength = 1;
			this.txtKeyHS3.Name = "txtKeyHS3";
			this.txtKeyHS3.Size = new System.Drawing.Size(60, 20);
			this.txtKeyHS3.TabIndex = 10;
			this.txtKeyHS3.Text = "U";
			this.txtKeyHS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyHS3.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyHS2
			// 
			this.txtKeyHS2.Location = new System.Drawing.Point(229, 52);
			this.txtKeyHS2.MaxLength = 1;
			this.txtKeyHS2.Name = "txtKeyHS2";
			this.txtKeyHS2.Size = new System.Drawing.Size(60, 20);
			this.txtKeyHS2.TabIndex = 11;
			this.txtKeyHS2.Text = "R";
			this.txtKeyHS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyHS2.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyHS1
			// 
			this.txtKeyHS1.Location = new System.Drawing.Point(298, 52);
			this.txtKeyHS1.MaxLength = 1;
			this.txtKeyHS1.Name = "txtKeyHS1";
			this.txtKeyHS1.Size = new System.Drawing.Size(60, 20);
			this.txtKeyHS1.TabIndex = 12;
			this.txtKeyHS1.Text = "F";
			this.txtKeyHS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyHS1.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// txtKeyHS0
			// 
			this.txtKeyHS0.Location = new System.Drawing.Point(366, 52);
			this.txtKeyHS0.MaxLength = 1;
			this.txtKeyHS0.Name = "txtKeyHS0";
			this.txtKeyHS0.Size = new System.Drawing.Size(60, 20);
			this.txtKeyHS0.TabIndex = 13;
			this.txtKeyHS0.Text = "J";
			this.txtKeyHS0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtKeyHS0.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(158, 9);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(58, 13);
			this.label18.TabIndex = 0;
			this.label18.Text = "Handbell 4";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(227, 9);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(58, 13);
			this.label19.TabIndex = 1;
			this.label19.Text = "Handbell 3";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(296, 9);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(58, 13);
			this.label20.TabIndex = 2;
			this.label20.Text = "Handbell 2";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(364, 9);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(58, 13);
			this.label21.TabIndex = 3;
			this.label21.Text = "Handbell 1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Button B:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Button A:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Backstroke:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Handstroke:";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(376, 263);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// warningTip
			// 
			this.warningTip.AutomaticDelay = 0;
			this.warningTip.AutoPopDelay = 0;
			this.warningTip.InitialDelay = 0;
			this.warningTip.IsBalloon = true;
			this.warningTip.ReshowDelay = 0;
			this.warningTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(6, 187);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(110, 13);
			this.label31.TabIndex = 27;
			this.label31.Text = "Debounce delay (ms):";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(166, 7);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 0;
			this.label17.Text = "Handbell 4";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(230, 7);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(58, 13);
			this.label16.TabIndex = 1;
			this.label16.Text = "Handbell 3";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(294, 7);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(58, 13);
			this.label15.TabIndex = 2;
			this.label15.Text = "Handbell 2";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(358, 7);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(58, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Handbell 1";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 109);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(131, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Backstroke strike position:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 84);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(132, 13);
			this.label9.TabIndex = 13;
			this.label9.Text = "Handstroke strike position:";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabHandbellCalibration);
			this.tabControl1.Controls.Add(this.tabAbelKeyStrokes);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(439, 245);
			this.tabControl1.TabIndex = 0;
			// 
			// tabHandbellCalibration
			// 
			this.tabHandbellCalibration.Controls.Add(this.btnCalibrate3);
			this.tabHandbellCalibration.Controls.Add(this.btnCalibrate2);
			this.tabHandbellCalibration.Controls.Add(this.btnCalibrate1);
			this.tabHandbellCalibration.Controls.Add(this.btnCalibrate0);
			this.tabHandbellCalibration.Controls.Add(this.spnDebounceDelay);
			this.tabHandbellCalibration.Controls.Add(this.spnDelayBS);
			this.tabHandbellCalibration.Controls.Add(this.spnDelayHS);
			this.tabHandbellCalibration.Controls.Add(this.label6);
			this.tabHandbellCalibration.Controls.Add(this.label5);
			this.tabHandbellCalibration.Controls.Add(this.txtZ3);
			this.tabHandbellCalibration.Controls.Add(this.txtZ2);
			this.tabHandbellCalibration.Controls.Add(this.txtZ1);
			this.tabHandbellCalibration.Controls.Add(this.txtZ0);
			this.tabHandbellCalibration.Controls.Add(this.label12);
			this.tabHandbellCalibration.Controls.Add(this.txtZBSP2);
			this.tabHandbellCalibration.Controls.Add(this.label15);
			this.tabHandbellCalibration.Controls.Add(this.txtZBSP1);
			this.tabHandbellCalibration.Controls.Add(this.label31);
			this.tabHandbellCalibration.Controls.Add(this.txtZBSP3);
			this.tabHandbellCalibration.Controls.Add(this.label16);
			this.tabHandbellCalibration.Controls.Add(this.txtZBSP0);
			this.tabHandbellCalibration.Controls.Add(this.label14);
			this.tabHandbellCalibration.Controls.Add(this.txtZHSP0);
			this.tabHandbellCalibration.Controls.Add(this.label17);
			this.tabHandbellCalibration.Controls.Add(this.txtZHSP1);
			this.tabHandbellCalibration.Controls.Add(this.label9);
			this.tabHandbellCalibration.Controls.Add(this.label10);
			this.tabHandbellCalibration.Controls.Add(this.txtZHSP3);
			this.tabHandbellCalibration.Controls.Add(this.txtZHSP2);
			this.tabHandbellCalibration.Location = new System.Drawing.Point(4, 22);
			this.tabHandbellCalibration.Name = "tabHandbellCalibration";
			this.tabHandbellCalibration.Padding = new System.Windows.Forms.Padding(3);
			this.tabHandbellCalibration.Size = new System.Drawing.Size(431, 219);
			this.tabHandbellCalibration.TabIndex = 0;
			this.tabHandbellCalibration.Text = "Handbell Calibration";
			this.tabHandbellCalibration.UseVisualStyleBackColor = true;
			// 
			// btnCalibrate3
			// 
			this.btnCalibrate3.Location = new System.Drawing.Point(165, 52);
			this.btnCalibrate3.Name = "btnCalibrate3";
			this.btnCalibrate3.Size = new System.Drawing.Size(60, 23);
			this.btnCalibrate3.TabIndex = 9;
			this.btnCalibrate3.Text = "Calibrate";
			this.btnCalibrate3.UseVisualStyleBackColor = true;
			this.btnCalibrate3.Click += new System.EventHandler(this.btnCalibrate_Click);
			// 
			// btnCalibrate2
			// 
			this.btnCalibrate2.Location = new System.Drawing.Point(230, 52);
			this.btnCalibrate2.Name = "btnCalibrate2";
			this.btnCalibrate2.Size = new System.Drawing.Size(60, 23);
			this.btnCalibrate2.TabIndex = 10;
			this.btnCalibrate2.Text = "Calibrate";
			this.btnCalibrate2.UseVisualStyleBackColor = true;
			this.btnCalibrate2.Click += new System.EventHandler(this.btnCalibrate_Click);
			// 
			// btnCalibrate1
			// 
			this.btnCalibrate1.Location = new System.Drawing.Point(296, 52);
			this.btnCalibrate1.Name = "btnCalibrate1";
			this.btnCalibrate1.Size = new System.Drawing.Size(60, 23);
			this.btnCalibrate1.TabIndex = 11;
			this.btnCalibrate1.Text = "Calibrate";
			this.btnCalibrate1.UseVisualStyleBackColor = true;
			this.btnCalibrate1.Click += new System.EventHandler(this.btnCalibrate_Click);
			// 
			// btnCalibrate0
			// 
			this.btnCalibrate0.Location = new System.Drawing.Point(362, 52);
			this.btnCalibrate0.Name = "btnCalibrate0";
			this.btnCalibrate0.Size = new System.Drawing.Size(57, 23);
			this.btnCalibrate0.TabIndex = 12;
			this.btnCalibrate0.Text = "Calibrate";
			this.btnCalibrate0.UseVisualStyleBackColor = true;
			this.btnCalibrate0.Click += new System.EventHandler(this.btnCalibrate_Click);
			// 
			// spnDebounceDelay
			// 
			this.spnDebounceDelay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.spnDebounceDelay.Location = new System.Drawing.Point(166, 185);
			this.spnDebounceDelay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.spnDebounceDelay.Name = "spnDebounceDelay";
			this.spnDebounceDelay.Size = new System.Drawing.Size(58, 20);
			this.spnDebounceDelay.TabIndex = 28;
			this.spnDebounceDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.spnDebounceDelay.ValueChanged += new System.EventHandler(this.spnDebounceDelay_ValueChanged);
			// 
			// spnDelayBS
			// 
			this.spnDelayBS.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.spnDelayBS.Location = new System.Drawing.Point(166, 159);
			this.spnDelayBS.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.spnDelayBS.Name = "spnDelayBS";
			this.spnDelayBS.Size = new System.Drawing.Size(58, 20);
			this.spnDelayBS.TabIndex = 26;
			this.spnDelayBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.spnDelayBS.ValueChanged += new System.EventHandler(this.spnDelayBS_ValueChanged);
			// 
			// spnDelayHS
			// 
			this.spnDelayHS.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.spnDelayHS.Location = new System.Drawing.Point(166, 133);
			this.spnDelayHS.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.spnDelayHS.Name = "spnDelayHS";
			this.spnDelayHS.Size = new System.Drawing.Size(58, 20);
			this.spnDelayHS.TabIndex = 24;
			this.spnDelayHS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.spnDelayHS.ValueChanged += new System.EventHandler(this.spnDelayHS_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 161);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(142, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "Backstroke strike delay (ms):";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(143, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Handstroke strike delay (ms):";
			// 
			// txtZ3
			// 
			this.txtZ3.Enabled = false;
			this.txtZ3.Location = new System.Drawing.Point(165, 26);
			this.txtZ3.Name = "txtZ3";
			this.txtZ3.Size = new System.Drawing.Size(60, 20);
			this.txtZ3.TabIndex = 5;
			this.txtZ3.Text = "0";
			this.txtZ3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtZ2
			// 
			this.txtZ2.Enabled = false;
			this.txtZ2.Location = new System.Drawing.Point(229, 26);
			this.txtZ2.Name = "txtZ2";
			this.txtZ2.Size = new System.Drawing.Size(60, 20);
			this.txtZ2.TabIndex = 6;
			this.txtZ2.Text = "0";
			this.txtZ2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtZ1
			// 
			this.txtZ1.Enabled = false;
			this.txtZ1.Location = new System.Drawing.Point(294, 26);
			this.txtZ1.Name = "txtZ1";
			this.txtZ1.Size = new System.Drawing.Size(60, 20);
			this.txtZ1.TabIndex = 7;
			this.txtZ1.Text = "0";
			this.txtZ1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtZ0
			// 
			this.txtZ0.Enabled = false;
			this.txtZ0.Location = new System.Drawing.Point(359, 26);
			this.txtZ0.Name = "txtZ0";
			this.txtZ0.Size = new System.Drawing.Size(60, 20);
			this.txtZ0.TabIndex = 8;
			this.txtZ0.Text = "0";
			this.txtZ0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(129, 13);
			this.label12.TabIndex = 4;
			this.label12.Text = "Handbell position (Z-Axis):";
			// 
			// tabAbelKeyStrokes
			// 
			this.tabAbelKeyStrokes.Controls.Add(this.chkUseKeyUpDown);
			this.tabAbelKeyStrokes.Controls.Add(this.txtProcessName);
			this.tabAbelKeyStrokes.Controls.Add(this.label32);
			this.tabAbelKeyStrokes.Controls.Add(this.label2);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB23);
			this.tabAbelKeyStrokes.Controls.Add(this.label1);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB22);
			this.tabAbelKeyStrokes.Controls.Add(this.label3);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB21);
			this.tabAbelKeyStrokes.Controls.Add(this.label4);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB20);
			this.tabAbelKeyStrokes.Controls.Add(this.label21);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB13);
			this.tabAbelKeyStrokes.Controls.Add(this.label20);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB12);
			this.tabAbelKeyStrokes.Controls.Add(this.label19);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB11);
			this.tabAbelKeyStrokes.Controls.Add(this.label18);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyB10);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyHS0);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyBS3);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyHS1);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyBS2);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyHS2);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyBS1);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyHS3);
			this.tabAbelKeyStrokes.Controls.Add(this.txtKeyBS0);
			this.tabAbelKeyStrokes.Location = new System.Drawing.Point(4, 22);
			this.tabAbelKeyStrokes.Name = "tabAbelKeyStrokes";
			this.tabAbelKeyStrokes.Padding = new System.Windows.Forms.Padding(3);
			this.tabAbelKeyStrokes.Size = new System.Drawing.Size(431, 219);
			this.tabAbelKeyStrokes.TabIndex = 1;
			this.tabAbelKeyStrokes.Text = "Abel Settings";
			this.tabAbelKeyStrokes.UseVisualStyleBackColor = true;
			this.tabAbelKeyStrokes.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// chkUseKeyUpDown
			// 
			this.chkUseKeyUpDown.AutoSize = true;
			this.chkUseKeyUpDown.Location = new System.Drawing.Point(9, 128);
			this.chkUseKeyUpDown.Name = "chkUseKeyUpDown";
			this.chkUseKeyUpDown.Size = new System.Drawing.Size(299, 17);
			this.chkUseKeyUpDown.TabIndex = 24;
			this.chkUseKeyUpDown.Text = "Use bell keys up/down action (must match setting in Abel)";
			this.chkUseKeyUpDown.UseVisualStyleBackColor = true;
			this.chkUseKeyUpDown.CheckedChanged += new System.EventHandler(this.chkUseKeyUpDown_CheckedChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(295, 263);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnDefault
			// 
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDefault.Location = new System.Drawing.Point(12, 263);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(119, 23);
			this.btnDefault.TabIndex = 1;
			this.btnDefault.Text = "Default Settings";
			this.btnDefault.UseVisualStyleBackColor = true;
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// txtZBSP2
			// 
			this.txtZBSP2.Location = new System.Drawing.Point(229, 107);
			this.txtZBSP2.MaxLength = 5;
			this.txtZBSP2.Name = "txtZBSP2";
			this.txtZBSP2.Size = new System.Drawing.Size(60, 20);
			this.txtZBSP2.TabIndex = 20;
			this.txtZBSP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZBSP2.TextChanged += new System.EventHandler(this.txtZBSP_TextChanged);
			// 
			// txtZBSP1
			// 
			this.txtZBSP1.Location = new System.Drawing.Point(294, 107);
			this.txtZBSP1.MaxLength = 5;
			this.txtZBSP1.Name = "txtZBSP1";
			this.txtZBSP1.Size = new System.Drawing.Size(60, 20);
			this.txtZBSP1.TabIndex = 21;
			this.txtZBSP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZBSP1.TextChanged += new System.EventHandler(this.txtZBSP_TextChanged);
			// 
			// txtZBSP3
			// 
			this.txtZBSP3.Location = new System.Drawing.Point(165, 107);
			this.txtZBSP3.MaxLength = 5;
			this.txtZBSP3.Name = "txtZBSP3";
			this.txtZBSP3.Size = new System.Drawing.Size(60, 20);
			this.txtZBSP3.TabIndex = 19;
			this.txtZBSP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZBSP3.TextChanged += new System.EventHandler(this.txtZBSP_TextChanged);
			// 
			// txtZBSP0
			// 
			this.txtZBSP0.Location = new System.Drawing.Point(359, 107);
			this.txtZBSP0.MaxLength = 5;
			this.txtZBSP0.Name = "txtZBSP0";
			this.txtZBSP0.Size = new System.Drawing.Size(60, 20);
			this.txtZBSP0.TabIndex = 22;
			this.txtZBSP0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZBSP0.TextChanged += new System.EventHandler(this.txtZBSP_TextChanged);
			// 
			// txtZHSP0
			// 
			this.txtZHSP0.Location = new System.Drawing.Point(359, 81);
			this.txtZHSP0.MaxLength = 5;
			this.txtZHSP0.Name = "txtZHSP0";
			this.txtZHSP0.Size = new System.Drawing.Size(60, 20);
			this.txtZHSP0.TabIndex = 17;
			this.txtZHSP0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZHSP0.TextChanged += new System.EventHandler(this.txtZHSP_TextChanged);
			// 
			// txtZHSP1
			// 
			this.txtZHSP1.Location = new System.Drawing.Point(294, 81);
			this.txtZHSP1.MaxLength = 5;
			this.txtZHSP1.Name = "txtZHSP1";
			this.txtZHSP1.Size = new System.Drawing.Size(60, 20);
			this.txtZHSP1.TabIndex = 16;
			this.txtZHSP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZHSP1.TextChanged += new System.EventHandler(this.txtZHSP_TextChanged);
			// 
			// txtZHSP3
			// 
			this.txtZHSP3.Location = new System.Drawing.Point(165, 81);
			this.txtZHSP3.MaxLength = 5;
			this.txtZHSP3.Name = "txtZHSP3";
			this.txtZHSP3.Size = new System.Drawing.Size(60, 20);
			this.txtZHSP3.TabIndex = 14;
			this.txtZHSP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZHSP3.TextChanged += new System.EventHandler(this.txtZHSP_TextChanged);
			// 
			// txtZHSP2
			// 
			this.txtZHSP2.Location = new System.Drawing.Point(229, 81);
			this.txtZHSP2.MaxLength = 5;
			this.txtZHSP2.Name = "txtZHSP2";
			this.txtZHSP2.Size = new System.Drawing.Size(60, 20);
			this.txtZHSP2.TabIndex = 15;
			this.txtZHSP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtZHSP2.TextChanged += new System.EventHandler(this.txtZHSP_TextChanged);
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 292);
			this.ControlBox = false;
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabHandbellCalibration.ResumeLayout(false);
			this.tabHandbellCalibration.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spnDebounceDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnDelayBS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnDelayHS)).EndInit();
			this.tabAbelKeyStrokes.ResumeLayout(false);
			this.tabAbelKeyStrokes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtProcessName;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtKeyB23;
		private System.Windows.Forms.TextBox txtKeyB22;
		private System.Windows.Forms.TextBox txtKeyB21;
		private System.Windows.Forms.TextBox txtKeyB20;
		private System.Windows.Forms.TextBox txtKeyB13;
		private System.Windows.Forms.TextBox txtKeyB12;
		private System.Windows.Forms.TextBox txtKeyB11;
		private System.Windows.Forms.TextBox txtKeyB10;
		private System.Windows.Forms.TextBox txtKeyBS3;
		private System.Windows.Forms.TextBox txtKeyBS2;
		private System.Windows.Forms.TextBox txtKeyBS1;
		private System.Windows.Forms.TextBox txtKeyBS0;
		private System.Windows.Forms.TextBox txtKeyHS3;
		private System.Windows.Forms.TextBox txtKeyHS2;
		private System.Windows.Forms.TextBox txtKeyHS1;
		private System.Windows.Forms.TextBox txtKeyHS0;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ToolTip warningTip;
		private System.Windows.Forms.Label label31;
		private HandbellManager.NumericalTextBox txtZHSP3;
		private HandbellManager.NumericalTextBox txtZHSP2;
		private HandbellManager.NumericalTextBox txtZHSP1;
		private HandbellManager.NumericalTextBox txtZHSP0;
		private HandbellManager.NumericalTextBox txtZBSP3;
		private HandbellManager.NumericalTextBox txtZBSP2;
		private HandbellManager.NumericalTextBox txtZBSP1;
		private HandbellManager.NumericalTextBox txtZBSP0;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabHandbellCalibration;
		private System.Windows.Forms.TabPage tabAbelKeyStrokes;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtZ3;
		private System.Windows.Forms.TextBox txtZ2;
		private System.Windows.Forms.TextBox txtZ1;
		private System.Windows.Forms.TextBox txtZ0;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown spnDelayHS;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown spnDelayBS;
		private System.Windows.Forms.NumericUpDown spnDebounceDelay;
		private System.Windows.Forms.CheckBox chkUseKeyUpDown;
		private System.Windows.Forms.Button btnCalibrate3;
		private System.Windows.Forms.Button btnCalibrate2;
		private System.Windows.Forms.Button btnCalibrate1;
		private System.Windows.Forms.Button btnCalibrate0;
		private System.Windows.Forms.Button btnDefault;
	}
}