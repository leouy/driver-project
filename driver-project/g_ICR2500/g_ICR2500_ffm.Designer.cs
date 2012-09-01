namespace g_ICR2500
{
    partial class g_ICR2500_ffm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_MeasParam = new System.Windows.Forms.Panel();
            this.lbl_Hz = new System.Windows.Forms.Label();
            this.btn_ATT = new System.Windows.Forms.Button();
            this.btn_AGC = new System.Windows.Forms.Button();
            this.btn_NB = new System.Windows.Forms.Button();
            this.txt_freqMask = new System.Windows.Forms.MaskedTextBox();
            this.btn_lowFreq = new System.Windows.Forms.Button();
            this.btn_upFreq = new System.Windows.Forms.Button();
            this.cmb_step = new System.Windows.Forms.ComboBox();
            this.cmb_Filter = new System.Windows.Forms.ComboBox();
            this.lbl_Step = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmb_Mode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_dBm = new System.Windows.Forms.Label();
            this.pnl_Data = new System.Windows.Forms.Panel();
            this.pct_ON = new System.Windows.Forms.PictureBox();
            this.pct_OFF = new System.Windows.Forms.PictureBox();
            this.txt_SignalStrength = new System.Windows.Forms.TextBox();
            this.lbl_VolumeValue = new System.Windows.Forms.Label();
            this.trk_volume = new System.Windows.Forms.TrackBar();
            this.lbl_SquelchValue = new System.Windows.Forms.Label();
            this.trk_Squelch = new System.Windows.Forms.TrackBar();
            this.lbl_SignalStrength = new System.Windows.Forms.Label();
            this.lbl_VolumenTitle = new System.Windows.Forms.Label();
            this.lbl_squelch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerFFM = new System.Windows.Forms.Timer(this.components);
            this.timerFFMDMM = new System.Windows.Forms.Timer(this.components);
            this.pnl_MeasParam.SuspendLayout();
            this.pnl_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Squelch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_MeasParam
            // 
            this.pnl_MeasParam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_MeasParam.Controls.Add(this.lbl_Hz);
            this.pnl_MeasParam.Controls.Add(this.btn_ATT);
            this.pnl_MeasParam.Controls.Add(this.btn_AGC);
            this.pnl_MeasParam.Controls.Add(this.btn_NB);
            this.pnl_MeasParam.Controls.Add(this.txt_freqMask);
            this.pnl_MeasParam.Controls.Add(this.btn_lowFreq);
            this.pnl_MeasParam.Controls.Add(this.btn_upFreq);
            this.pnl_MeasParam.Controls.Add(this.cmb_step);
            this.pnl_MeasParam.Controls.Add(this.cmb_Filter);
            this.pnl_MeasParam.Controls.Add(this.lbl_Step);
            this.pnl_MeasParam.Controls.Add(this.lblFilter);
            this.pnl_MeasParam.Controls.Add(this.lblMode);
            this.pnl_MeasParam.Controls.Add(this.cmb_Mode);
            this.pnl_MeasParam.Location = new System.Drawing.Point(3, 19);
            this.pnl_MeasParam.Name = "pnl_MeasParam";
            this.pnl_MeasParam.Size = new System.Drawing.Size(744, 65);
            this.pnl_MeasParam.TabIndex = 104;
            // 
            // lbl_Hz
            // 
            this.lbl_Hz.AutoSize = true;
            this.lbl_Hz.Location = new System.Drawing.Point(219, 30);
            this.lbl_Hz.Name = "lbl_Hz";
            this.lbl_Hz.Size = new System.Drawing.Size(20, 13);
            this.lbl_Hz.TabIndex = 101;
            this.lbl_Hz.Text = "Hz";
            // 
            // btn_ATT
            // 
            this.btn_ATT.Location = new System.Drawing.Point(636, 37);
            this.btn_ATT.Name = "btn_ATT";
            this.btn_ATT.Size = new System.Drawing.Size(82, 21);
            this.btn_ATT.TabIndex = 7;
            this.btn_ATT.Text = "ATT";
            this.btn_ATT.UseVisualStyleBackColor = true;
            this.btn_ATT.Click += new System.EventHandler(this.btn_ATT_Click);
            // 
            // btn_AGC
            // 
            this.btn_AGC.Location = new System.Drawing.Point(636, 10);
            this.btn_AGC.Name = "btn_AGC";
            this.btn_AGC.Size = new System.Drawing.Size(82, 21);
            this.btn_AGC.TabIndex = 6;
            this.btn_AGC.Text = "AGC";
            this.btn_AGC.UseVisualStyleBackColor = true;
            this.btn_AGC.Click += new System.EventHandler(this.btn_AGC_Click);
            // 
            // btn_NB
            // 
            this.btn_NB.Location = new System.Drawing.Point(501, 37);
            this.btn_NB.Name = "btn_NB";
            this.btn_NB.Size = new System.Drawing.Size(82, 21);
            this.btn_NB.TabIndex = 5;
            this.btn_NB.Text = "NB";
            this.btn_NB.UseVisualStyleBackColor = true;
            this.btn_NB.Click += new System.EventHandler(this.btn_NB_Click);
            // 
            // txt_freqMask
            // 
            this.txt_freqMask.Culture = new System.Globalization.CultureInfo("en-US");
            this.txt_freqMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_freqMask.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_freqMask.Location = new System.Drawing.Point(12, 13);
            this.txt_freqMask.Mask = "0.000.000.000";
            this.txt_freqMask.Name = "txt_freqMask";
            this.txt_freqMask.PromptChar = '0';
            this.txt_freqMask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_freqMask.Size = new System.Drawing.Size(201, 40);
            this.txt_freqMask.TabIndex = 1;
            this.txt_freqMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_freqMask.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txt_freqMask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_freqMask_KeyUp);
            // 
            // btn_lowFreq
            // 
            this.btn_lowFreq.Location = new System.Drawing.Point(252, 33);
            this.btn_lowFreq.Name = "btn_lowFreq";
            this.btn_lowFreq.Size = new System.Drawing.Size(19, 20);
            this.btn_lowFreq.TabIndex = 11;
            this.btn_lowFreq.Text = "-";
            this.btn_lowFreq.UseVisualStyleBackColor = true;
            this.btn_lowFreq.Click += new System.EventHandler(this.btn_lowFreq_Click);
            // 
            // btn_upFreq
            // 
            this.btn_upFreq.Location = new System.Drawing.Point(252, 13);
            this.btn_upFreq.Name = "btn_upFreq";
            this.btn_upFreq.Size = new System.Drawing.Size(19, 20);
            this.btn_upFreq.TabIndex = 10;
            this.btn_upFreq.Text = "+";
            this.btn_upFreq.UseVisualStyleBackColor = true;
            this.btn_upFreq.Click += new System.EventHandler(this.btn_upFreq_Click);
            // 
            // cmb_step
            // 
            this.cmb_step.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_step.FormattingEnabled = true;
            this.cmb_step.Location = new System.Drawing.Point(356, 10);
            this.cmb_step.Name = "cmb_step";
            this.cmb_step.Size = new System.Drawing.Size(82, 21);
            this.cmb_step.TabIndex = 2;
            this.cmb_step.SelectedIndexChanged += new System.EventHandler(this.cmb_step_SelectedIndexChanged);
            // 
            // cmb_Filter
            // 
            this.cmb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Filter.FormattingEnabled = true;
            this.cmb_Filter.Location = new System.Drawing.Point(356, 37);
            this.cmb_Filter.Name = "cmb_Filter";
            this.cmb_Filter.Size = new System.Drawing.Size(82, 21);
            this.cmb_Filter.TabIndex = 3;
            this.cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.cmb_Filter_SelectedIndexChanged);
            // 
            // lbl_Step
            // 
            this.lbl_Step.AutoSize = true;
            this.lbl_Step.Location = new System.Drawing.Point(311, 15);
            this.lbl_Step.Name = "lbl_Step";
            this.lbl_Step.Size = new System.Drawing.Size(29, 13);
            this.lbl_Step.TabIndex = 100;
            this.lbl_Step.Text = "Step";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(311, 42);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 100;
            this.lblFilter.Text = "Filter";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(456, 15);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 100;
            this.lblMode.Text = "Mode";
            // 
            // cmb_Mode
            // 
            this.cmb_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Mode.FormattingEnabled = true;
            this.cmb_Mode.Location = new System.Drawing.Point(501, 10);
            this.cmb_Mode.Name = "cmb_Mode";
            this.cmb_Mode.Size = new System.Drawing.Size(82, 21);
            this.cmb_Mode.TabIndex = 4;
            this.cmb_Mode.SelectedIndexChanged += new System.EventHandler(this.cmb_Mode_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 21);
            this.button1.TabIndex = 102;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_dBm
            // 
            this.lbl_dBm.AutoSize = true;
            this.lbl_dBm.Location = new System.Drawing.Point(119, 15);
            this.lbl_dBm.Name = "lbl_dBm";
            this.lbl_dBm.Size = new System.Drawing.Size(28, 13);
            this.lbl_dBm.TabIndex = 100;
            this.lbl_dBm.Text = "dBm";
            // 
            // pnl_Data
            // 
            this.pnl_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Data.Controls.Add(this.button1);
            this.pnl_Data.Controls.Add(this.pct_OFF);
            this.pnl_Data.Controls.Add(this.lbl_dBm);
            this.pnl_Data.Controls.Add(this.txt_SignalStrength);
            this.pnl_Data.Controls.Add(this.pct_ON);
            this.pnl_Data.Location = new System.Drawing.Point(3, 85);
            this.pnl_Data.Name = "pnl_Data";
            this.pnl_Data.Size = new System.Drawing.Size(744, 40);
            this.pnl_Data.TabIndex = 105;
            // 
            // pct_ON
            // 
            this.pct_ON.Image = global::g_ICR2500.Properties.Resources.on;
            this.pct_ON.Location = new System.Drawing.Point(314, 7);
            this.pct_ON.Name = "pct_ON";
            this.pct_ON.Size = new System.Drawing.Size(25, 25);
            this.pct_ON.TabIndex = 112;
            this.pct_ON.TabStop = false;
            // 
            // pct_OFF
            // 
            this.pct_OFF.Image = global::g_ICR2500.Properties.Resources.off;
            this.pct_OFF.Location = new System.Drawing.Point(314, 7);
            this.pct_OFF.Name = "pct_OFF";
            this.pct_OFF.Size = new System.Drawing.Size(25, 25);
            this.pct_OFF.TabIndex = 111;
            this.pct_OFF.TabStop = false;
            // 
            // txt_SignalStrength
            // 
            this.txt_SignalStrength.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_SignalStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SignalStrength.ForeColor = System.Drawing.Color.Lime;
            this.txt_SignalStrength.Location = new System.Drawing.Point(37, 7);
            this.txt_SignalStrength.Name = "txt_SignalStrength";
            this.txt_SignalStrength.Size = new System.Drawing.Size(77, 26);
            this.txt_SignalStrength.TabIndex = 100;
            this.txt_SignalStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_VolumeValue
            // 
            this.lbl_VolumeValue.AutoSize = true;
            this.lbl_VolumeValue.BackColor = System.Drawing.SystemColors.WindowText;
            this.lbl_VolumeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VolumeValue.ForeColor = System.Drawing.Color.Lime;
            this.lbl_VolumeValue.Location = new System.Drawing.Point(43, 182);
            this.lbl_VolumeValue.Name = "lbl_VolumeValue";
            this.lbl_VolumeValue.Size = new System.Drawing.Size(18, 20);
            this.lbl_VolumeValue.TabIndex = 100;
            this.lbl_VolumeValue.Text = "0";
            // 
            // trk_volume
            // 
            this.trk_volume.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trk_volume.Location = new System.Drawing.Point(37, 66);
            this.trk_volume.Maximum = 100;
            this.trk_volume.Name = "trk_volume";
            this.trk_volume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_volume.Size = new System.Drawing.Size(45, 104);
            this.trk_volume.TabIndex = 12;
            this.trk_volume.TickFrequency = 10;
            this.trk_volume.ValueChanged += new System.EventHandler(this.trk_volume_ValueChanged);
            // 
            // lbl_SquelchValue
            // 
            this.lbl_SquelchValue.AutoSize = true;
            this.lbl_SquelchValue.BackColor = System.Drawing.SystemColors.WindowText;
            this.lbl_SquelchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SquelchValue.ForeColor = System.Drawing.Color.Lime;
            this.lbl_SquelchValue.Location = new System.Drawing.Point(128, 182);
            this.lbl_SquelchValue.Name = "lbl_SquelchValue";
            this.lbl_SquelchValue.Size = new System.Drawing.Size(18, 20);
            this.lbl_SquelchValue.TabIndex = 100;
            this.lbl_SquelchValue.Text = "0";
            // 
            // trk_Squelch
            // 
            this.trk_Squelch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trk_Squelch.Location = new System.Drawing.Point(124, 66);
            this.trk_Squelch.Maximum = 100;
            this.trk_Squelch.Name = "trk_Squelch";
            this.trk_Squelch.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trk_Squelch.Size = new System.Drawing.Size(45, 104);
            this.trk_Squelch.TabIndex = 13;
            this.trk_Squelch.TickFrequency = 10;
            this.trk_Squelch.ValueChanged += new System.EventHandler(this.trk_Squelch_ValueChanged);
            // 
            // lbl_SignalStrength
            // 
            this.lbl_SignalStrength.AutoSize = true;
            this.lbl_SignalStrength.Location = new System.Drawing.Point(302, 36);
            this.lbl_SignalStrength.Name = "lbl_SignalStrength";
            this.lbl_SignalStrength.Size = new System.Drawing.Size(79, 13);
            this.lbl_SignalStrength.TabIndex = 103;
            this.lbl_SignalStrength.Text = "Signal Strength";
            // 
            // lbl_VolumenTitle
            // 
            this.lbl_VolumenTitle.AutoSize = true;
            this.lbl_VolumenTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VolumenTitle.Location = new System.Drawing.Point(19, 41);
            this.lbl_VolumenTitle.Name = "lbl_VolumenTitle";
            this.lbl_VolumenTitle.Size = new System.Drawing.Size(63, 20);
            this.lbl_VolumenTitle.TabIndex = 45;
            this.lbl_VolumenTitle.Text = "Volume";
            // 
            // lbl_squelch
            // 
            this.lbl_squelch.AutoSize = true;
            this.lbl_squelch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_squelch.Location = new System.Drawing.Point(120, 41);
            this.lbl_squelch.Name = "lbl_squelch";
            this.lbl_squelch.Size = new System.Drawing.Size(67, 20);
            this.lbl_squelch.TabIndex = 46;
            this.lbl_squelch.Text = "Squelch";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.trk_volume);
            this.panel1.Controls.Add(this.lbl_VolumeValue);
            this.panel1.Controls.Add(this.lbl_SquelchValue);
            this.panel1.Controls.Add(this.trk_Squelch);
            this.panel1.Controls.Add(this.lbl_VolumenTitle);
            this.panel1.Controls.Add(this.lbl_squelch);
            this.panel1.Location = new System.Drawing.Point(3, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 350);
            this.panel1.TabIndex = 106;
            // 
            // timerFFM
            // 
            this.timerFFM.Tick += new System.EventHandler(this.timerFFM_tick);
            // 
            // timerFFMDMM
            // 
            this.timerFFMDMM.Tick += new System.EventHandler(this.timerFFMDMM_Tick);
            // 
            // g_ICR2500_ffm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_MeasParam);
            this.Controls.Add(this.pnl_Data);
            this.Controls.Add(this.lbl_SignalStrength);
            this.Controls.Add(this.panel1);
            this.Name = "g_ICR2500_ffm";
            this.Size = new System.Drawing.Size(750, 500);
            this.Load += new System.EventHandler(this.g_ICR2500_ffm_Load);
            this.pnl_MeasParam.ResumeLayout(false);
            this.pnl_MeasParam.PerformLayout();
            this.pnl_Data.ResumeLayout(false);
            this.pnl_Data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Squelch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MeasParam;
        private System.Windows.Forms.Label lbl_Hz;
        private System.Windows.Forms.Button btn_ATT;
        private System.Windows.Forms.Button btn_AGC;
        private System.Windows.Forms.Button btn_NB;
        private System.Windows.Forms.MaskedTextBox txt_freqMask;
        private System.Windows.Forms.Button btn_lowFreq;
        private System.Windows.Forms.Button btn_upFreq;
        private System.Windows.Forms.ComboBox cmb_step;
        private System.Windows.Forms.ComboBox cmb_Filter;
        private System.Windows.Forms.Label lbl_Step;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmb_Mode;
        private System.Windows.Forms.Label lbl_dBm;
        private System.Windows.Forms.Panel pnl_Data;
        private System.Windows.Forms.TextBox txt_SignalStrength;
        private System.Windows.Forms.Label lbl_VolumeValue;
        private System.Windows.Forms.TrackBar trk_volume;
        private System.Windows.Forms.Label lbl_SquelchValue;
        private System.Windows.Forms.TrackBar trk_Squelch;
        private System.Windows.Forms.Label lbl_SignalStrength;
        private System.Windows.Forms.Label lbl_VolumenTitle;
        private System.Windows.Forms.Label lbl_squelch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerFFM;
        private System.Windows.Forms.Timer timerFFMDMM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pct_OFF;
        private System.Windows.Forms.PictureBox pct_ON;
    }
}
