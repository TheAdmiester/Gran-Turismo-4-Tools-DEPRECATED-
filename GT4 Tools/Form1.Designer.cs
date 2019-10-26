namespace GT4_Random_Cars
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpCars = new System.Windows.Forms.GroupBox();
            this.btnCarsGenerate = new System.Windows.Forms.Button();
            this.txtCar5 = new System.Windows.Forms.TextBox();
            this.txtCar4 = new System.Windows.Forms.TextBox();
            this.txtCar3 = new System.Windows.Forms.TextBox();
            this.txtCar2 = new System.Windows.Forms.TextBox();
            this.txtCar1 = new System.Windows.Forms.TextBox();
            this.grpTrack = new System.Windows.Forms.GroupBox();
            this.btnTrackGenerate = new System.Windows.Forms.Button();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlrGenerate = new System.Windows.Forms.Button();
            this.txtPlrCar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPlrCar = new System.Windows.Forms.ComboBox();
            this.btnManualPlrApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboCar5 = new System.Windows.Forms.ComboBox();
            this.cboCar4 = new System.Windows.Forms.ComboBox();
            this.cboCar3 = new System.Windows.Forms.ComboBox();
            this.cboCar2 = new System.Windows.Forms.ComboBox();
            this.cboCar1 = new System.Windows.Forms.ComboBox();
            this.btnManualAIApply = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboTrack = new System.Windows.Forms.ComboBox();
            this.btnManualTrackApply = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboCameraType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFOV = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCar = new System.Windows.Forms.CheckBox();
            this.chkTrack = new System.Windows.Forms.CheckBox();
            this.chkPlrCar = new System.Windows.Forms.CheckBox();
            this.grpCars.SuspendLayout();
            this.grpTrack.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFOV)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCars
            // 
            this.grpCars.Controls.Add(this.btnCarsGenerate);
            this.grpCars.Controls.Add(this.txtCar5);
            this.grpCars.Controls.Add(this.txtCar4);
            this.grpCars.Controls.Add(this.txtCar3);
            this.grpCars.Controls.Add(this.txtCar2);
            this.grpCars.Controls.Add(this.txtCar1);
            this.grpCars.Location = new System.Drawing.Point(6, 105);
            this.grpCars.Name = "grpCars";
            this.grpCars.Size = new System.Drawing.Size(382, 198);
            this.grpCars.TabIndex = 0;
            this.grpCars.TabStop = false;
            this.grpCars.Text = "AI Vehicles";
            // 
            // btnCarsGenerate
            // 
            this.btnCarsGenerate.Location = new System.Drawing.Point(254, 150);
            this.btnCarsGenerate.Name = "btnCarsGenerate";
            this.btnCarsGenerate.Size = new System.Drawing.Size(121, 38);
            this.btnCarsGenerate.TabIndex = 6;
            this.btnCarsGenerate.Text = "Generate and Apply";
            this.btnCarsGenerate.UseVisualStyleBackColor = true;
            this.btnCarsGenerate.Click += new System.EventHandler(this.btnCarsGenerate_Click);
            // 
            // txtCar5
            // 
            this.txtCar5.Location = new System.Drawing.Point(6, 124);
            this.txtCar5.Name = "txtCar5";
            this.txtCar5.ReadOnly = true;
            this.txtCar5.Size = new System.Drawing.Size(369, 20);
            this.txtCar5.TabIndex = 4;
            // 
            // txtCar4
            // 
            this.txtCar4.Location = new System.Drawing.Point(6, 98);
            this.txtCar4.Name = "txtCar4";
            this.txtCar4.ReadOnly = true;
            this.txtCar4.Size = new System.Drawing.Size(369, 20);
            this.txtCar4.TabIndex = 3;
            // 
            // txtCar3
            // 
            this.txtCar3.Location = new System.Drawing.Point(6, 72);
            this.txtCar3.Name = "txtCar3";
            this.txtCar3.ReadOnly = true;
            this.txtCar3.Size = new System.Drawing.Size(369, 20);
            this.txtCar3.TabIndex = 2;
            // 
            // txtCar2
            // 
            this.txtCar2.Location = new System.Drawing.Point(7, 46);
            this.txtCar2.Name = "txtCar2";
            this.txtCar2.ReadOnly = true;
            this.txtCar2.Size = new System.Drawing.Size(368, 20);
            this.txtCar2.TabIndex = 1;
            // 
            // txtCar1
            // 
            this.txtCar1.Location = new System.Drawing.Point(7, 20);
            this.txtCar1.Name = "txtCar1";
            this.txtCar1.ReadOnly = true;
            this.txtCar1.Size = new System.Drawing.Size(368, 20);
            this.txtCar1.TabIndex = 0;
            // 
            // grpTrack
            // 
            this.grpTrack.Controls.Add(this.btnTrackGenerate);
            this.grpTrack.Controls.Add(this.txtTrack);
            this.grpTrack.Location = new System.Drawing.Point(6, 315);
            this.grpTrack.Name = "grpTrack";
            this.grpTrack.Size = new System.Drawing.Size(381, 95);
            this.grpTrack.TabIndex = 1;
            this.grpTrack.TabStop = false;
            this.grpTrack.Text = "Track";
            // 
            // btnTrackGenerate
            // 
            this.btnTrackGenerate.Location = new System.Drawing.Point(253, 46);
            this.btnTrackGenerate.Name = "btnTrackGenerate";
            this.btnTrackGenerate.Size = new System.Drawing.Size(122, 38);
            this.btnTrackGenerate.TabIndex = 7;
            this.btnTrackGenerate.Text = "Generate and Apply";
            this.btnTrackGenerate.UseVisualStyleBackColor = true;
            this.btnTrackGenerate.Click += new System.EventHandler(this.btnTrackGenerate_Click);
            // 
            // txtTrack
            // 
            this.txtTrack.Location = new System.Drawing.Point(8, 20);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.ReadOnly = true;
            this.txtTrack.Size = new System.Drawing.Size(367, 20);
            this.txtTrack.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(402, 447);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grpCars);
            this.tabPage1.Controls.Add(this.grpTrack);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(394, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event Synthesizer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlrGenerate);
            this.groupBox1.Controls.Add(this.txtPlrCar);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Car";
            // 
            // btnPlrGenerate
            // 
            this.btnPlrGenerate.Location = new System.Drawing.Point(254, 45);
            this.btnPlrGenerate.Name = "btnPlrGenerate";
            this.btnPlrGenerate.Size = new System.Drawing.Size(121, 38);
            this.btnPlrGenerate.TabIndex = 7;
            this.btnPlrGenerate.Text = "Generate and Apply";
            this.btnPlrGenerate.UseVisualStyleBackColor = true;
            this.btnPlrGenerate.Click += new System.EventHandler(this.btnPlrGenerate_Click);
            // 
            // txtPlrCar
            // 
            this.txtPlrCar.Location = new System.Drawing.Point(8, 19);
            this.txtPlrCar.Name = "txtPlrCar";
            this.txtPlrCar.ReadOnly = true;
            this.txtPlrCar.Size = new System.Drawing.Size(367, 20);
            this.txtPlrCar.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(394, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Custom Event";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboPlrCar);
            this.groupBox2.Controls.Add(this.btnManualPlrApply);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 93);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Car";
            // 
            // cboPlrCar
            // 
            this.cboPlrCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlrCar.FormattingEnabled = true;
            this.cboPlrCar.Location = new System.Drawing.Point(8, 20);
            this.cboPlrCar.Name = "cboPlrCar";
            this.cboPlrCar.Size = new System.Drawing.Size(366, 21);
            this.cboPlrCar.TabIndex = 8;
            // 
            // btnManualPlrApply
            // 
            this.btnManualPlrApply.Location = new System.Drawing.Point(254, 45);
            this.btnManualPlrApply.Name = "btnManualPlrApply";
            this.btnManualPlrApply.Size = new System.Drawing.Size(121, 38);
            this.btnManualPlrApply.TabIndex = 7;
            this.btnManualPlrApply.Text = "Apply";
            this.btnManualPlrApply.UseVisualStyleBackColor = true;
            this.btnManualPlrApply.Click += new System.EventHandler(this.btnManualPlrApply_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboCar5);
            this.groupBox3.Controls.Add(this.cboCar4);
            this.groupBox3.Controls.Add(this.cboCar3);
            this.groupBox3.Controls.Add(this.cboCar2);
            this.groupBox3.Controls.Add(this.cboCar1);
            this.groupBox3.Controls.Add(this.btnManualAIApply);
            this.groupBox3.Location = new System.Drawing.Point(6, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 204);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AI Vehicles";
            // 
            // cboCar5
            // 
            this.cboCar5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar5.FormattingEnabled = true;
            this.cboCar5.Location = new System.Drawing.Point(6, 127);
            this.cboCar5.Name = "cboCar5";
            this.cboCar5.Size = new System.Drawing.Size(366, 21);
            this.cboCar5.TabIndex = 13;
            // 
            // cboCar4
            // 
            this.cboCar4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar4.FormattingEnabled = true;
            this.cboCar4.Location = new System.Drawing.Point(6, 100);
            this.cboCar4.Name = "cboCar4";
            this.cboCar4.Size = new System.Drawing.Size(366, 21);
            this.cboCar4.TabIndex = 12;
            // 
            // cboCar3
            // 
            this.cboCar3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar3.FormattingEnabled = true;
            this.cboCar3.Location = new System.Drawing.Point(6, 73);
            this.cboCar3.Name = "cboCar3";
            this.cboCar3.Size = new System.Drawing.Size(366, 21);
            this.cboCar3.TabIndex = 11;
            // 
            // cboCar2
            // 
            this.cboCar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar2.FormattingEnabled = true;
            this.cboCar2.Location = new System.Drawing.Point(6, 46);
            this.cboCar2.Name = "cboCar2";
            this.cboCar2.Size = new System.Drawing.Size(366, 21);
            this.cboCar2.TabIndex = 10;
            // 
            // cboCar1
            // 
            this.cboCar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar1.FormattingEnabled = true;
            this.cboCar1.Location = new System.Drawing.Point(6, 19);
            this.cboCar1.Name = "cboCar1";
            this.cboCar1.Size = new System.Drawing.Size(366, 21);
            this.cboCar1.TabIndex = 9;
            // 
            // btnManualAIApply
            // 
            this.btnManualAIApply.Location = new System.Drawing.Point(254, 154);
            this.btnManualAIApply.Name = "btnManualAIApply";
            this.btnManualAIApply.Size = new System.Drawing.Size(121, 38);
            this.btnManualAIApply.TabIndex = 6;
            this.btnManualAIApply.Text = "Apply";
            this.btnManualAIApply.UseVisualStyleBackColor = true;
            this.btnManualAIApply.Click += new System.EventHandler(this.btnManualAIApply_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboTrack);
            this.groupBox4.Controls.Add(this.btnManualTrackApply);
            this.groupBox4.Location = new System.Drawing.Point(6, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 95);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Track";
            // 
            // cboTrack
            // 
            this.cboTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrack.FormattingEnabled = true;
            this.cboTrack.Location = new System.Drawing.Point(9, 19);
            this.cboTrack.Name = "cboTrack";
            this.cboTrack.Size = new System.Drawing.Size(366, 21);
            this.cboTrack.TabIndex = 14;
            // 
            // btnManualTrackApply
            // 
            this.btnManualTrackApply.Location = new System.Drawing.Point(253, 46);
            this.btnManualTrackApply.Name = "btnManualTrackApply";
            this.btnManualTrackApply.Size = new System.Drawing.Size(122, 38);
            this.btnManualTrackApply.TabIndex = 7;
            this.btnManualTrackApply.Text = "Apply";
            this.btnManualTrackApply.UseVisualStyleBackColor = true;
            this.btnManualTrackApply.Click += new System.EventHandler(this.btnManualTrackApply_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cboCameraType);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.nudFOV);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(394, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Misc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboCameraType
            // 
            this.cboCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameraType.FormattingEnabled = true;
            this.cboCameraType.Items.AddRange(new object[] {
            "Default",
            "GT3-like"});
            this.cboCameraType.Location = new System.Drawing.Point(267, 61);
            this.cboCameraType.Name = "cboCameraType";
            this.cboCameraType.Size = new System.Drawing.Size(120, 21);
            this.cboCameraType.TabIndex = 3;
            this.cboCameraType.SelectedIndexChanged += new System.EventHandler(this.cboCameraType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chase Camera Attachment (race reload required)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Field of View";
            // 
            // nudFOV
            // 
            this.nudFOV.Location = new System.Drawing.Point(337, 22);
            this.nudFOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudFOV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFOV.Name = "nudFOV";
            this.nudFOV.Size = new System.Drawing.Size(50, 20);
            this.nudFOV.TabIndex = 0;
            this.nudFOV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(394, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 188);
            this.label7.MaximumSize = new System.Drawing.Size(375, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(361, 91);
            this.label7.TabIndex = 4;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 41);
            this.label6.MaximumSize = new System.Drawing.Size(375, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(375, 78);
            this.label6.TabIndex = 3;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Custom Event";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Event Synthesizer";
            // 
            // chkCar
            // 
            this.chkCar.AutoSize = true;
            this.chkCar.Location = new System.Drawing.Point(12, 476);
            this.chkCar.Name = "chkCar";
            this.chkCar.Size = new System.Drawing.Size(146, 17);
            this.chkCar.TabIndex = 4;
            this.chkCar.Text = "Override AI Cars (Arcade)";
            this.chkCar.UseVisualStyleBackColor = true;
            // 
            // chkTrack
            // 
            this.chkTrack.AutoSize = true;
            this.chkTrack.Location = new System.Drawing.Point(12, 499);
            this.chkTrack.Name = "chkTrack";
            this.chkTrack.Size = new System.Drawing.Size(185, 17);
            this.chkTrack.TabIndex = 5;
            this.chkTrack.Text = "Override Selected Track (Arcade)";
            this.chkTrack.UseVisualStyleBackColor = true;
            // 
            // chkPlrCar
            // 
            this.chkPlrCar.AutoSize = true;
            this.chkPlrCar.Location = new System.Drawing.Point(12, 453);
            this.chkPlrCar.Name = "chkPlrCar";
            this.chkPlrCar.Size = new System.Drawing.Size(160, 17);
            this.chkPlrCar.TabIndex = 6;
            this.chkPlrCar.Text = "Override Player Car (Arcade)";
            this.chkPlrCar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 524);
            this.Controls.Add(this.chkPlrCar);
            this.Controls.Add(this.chkTrack);
            this.Controls.Add(this.chkCar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GT4 Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCars.ResumeLayout(false);
            this.grpCars.PerformLayout();
            this.grpTrack.ResumeLayout(false);
            this.grpTrack.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFOV)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCars;
        private System.Windows.Forms.Button btnCarsGenerate;
        private System.Windows.Forms.TextBox txtCar5;
        private System.Windows.Forms.TextBox txtCar4;
        private System.Windows.Forms.TextBox txtCar3;
        private System.Windows.Forms.TextBox txtCar2;
        private System.Windows.Forms.GroupBox grpTrack;
        private System.Windows.Forms.Button btnTrackGenerate;
        private System.Windows.Forms.TextBox txtTrack;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFOV;
        private System.Windows.Forms.ComboBox cboCameraType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCar1;
        private System.Windows.Forms.CheckBox chkCar;
        private System.Windows.Forms.CheckBox chkTrack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlrGenerate;
        private System.Windows.Forms.TextBox txtPlrCar;
        private System.Windows.Forms.CheckBox chkPlrCar;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboPlrCar;
        private System.Windows.Forms.Button btnManualPlrApply;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboCar5;
        private System.Windows.Forms.ComboBox cboCar4;
        private System.Windows.Forms.ComboBox cboCar3;
        private System.Windows.Forms.ComboBox cboCar2;
        private System.Windows.Forms.ComboBox cboCar1;
        private System.Windows.Forms.Button btnManualAIApply;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboTrack;
        private System.Windows.Forms.Button btnManualTrackApply;
    }
}

