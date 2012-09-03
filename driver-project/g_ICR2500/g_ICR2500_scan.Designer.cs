namespace g_ICR2500
{
    partial class g_ICR2500_scan
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
            this.txt_Step = new System.Windows.Forms.MaskedTextBox();
            this.pnl_GraphLimits = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_dBm_2 = new System.Windows.Forms.Label();
            this.lbl_dBm = new System.Windows.Forms.Label();
            this.txt_HighdBm = new System.Windows.Forms.MaskedTextBox();
            this.txt_LowdBm = new System.Windows.Forms.MaskedTextBox();
            this.lbl_Hz_3 = new System.Windows.Forms.Label();
            this.pnl_MeasParam = new System.Windows.Forms.Panel();
            this.lbl_Hz_2 = new System.Windows.Forms.Label();
            this.lbl_Hz_1 = new System.Windows.Forms.Label();
            this.txt_startFreqMask = new System.Windows.Forms.MaskedTextBox();
            this.txt_endFreqMask = new System.Windows.Forms.MaskedTextBox();
            this.lbl_StartFreq = new System.Windows.Forms.Label();
            this.lbl_Step = new System.Windows.Forms.Label();
            this.lbl_EndFreq = new System.Windows.Forms.Label();
            this.btn_startBandScope = new System.Windows.Forms.Button();
            this.pnl_StartBtn = new System.Windows.Forms.Panel();
            this.pct_OFF = new System.Windows.Forms.PictureBox();
            this.pct_ON = new System.Windows.Forms.PictureBox();
            this.timerScan = new System.Windows.Forms.Timer(this.components);
            this.pnl_GraphLimits.SuspendLayout();
            this.pnl_MeasParam.SuspendLayout();
            this.pnl_StartBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_ON)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Step
            // 
            this.txt_Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Step.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_Step.Location = new System.Drawing.Point(232, 71);
            this.txt_Step.Mask = "000000";
            this.txt_Step.Name = "txt_Step";
            this.txt_Step.PromptChar = '0';
            this.txt_Step.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Step.Size = new System.Drawing.Size(63, 26);
            this.txt_Step.TabIndex = 102;
            this.txt_Step.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Step.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // pnl_GraphLimits
            // 
            this.pnl_GraphLimits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_GraphLimits.Controls.Add(this.label6);
            this.pnl_GraphLimits.Controls.Add(this.label5);
            this.pnl_GraphLimits.Controls.Add(this.lbl_dBm_2);
            this.pnl_GraphLimits.Controls.Add(this.lbl_dBm);
            this.pnl_GraphLimits.Controls.Add(this.txt_HighdBm);
            this.pnl_GraphLimits.Controls.Add(this.txt_LowdBm);
            this.pnl_GraphLimits.Location = new System.Drawing.Point(382, 35);
            this.pnl_GraphLimits.Name = "pnl_GraphLimits";
            this.pnl_GraphLimits.Size = new System.Drawing.Size(365, 70);
            this.pnl_GraphLimits.TabIndex = 114;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 108;
            this.label6.Text = "Low Signal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Top Signal";
            // 
            // lbl_dBm_2
            // 
            this.lbl_dBm_2.AutoSize = true;
            this.lbl_dBm_2.Location = new System.Drawing.Point(234, 42);
            this.lbl_dBm_2.Name = "lbl_dBm_2";
            this.lbl_dBm_2.Size = new System.Drawing.Size(28, 13);
            this.lbl_dBm_2.TabIndex = 106;
            this.lbl_dBm_2.Text = "dBm";
            // 
            // lbl_dBm
            // 
            this.lbl_dBm.AutoSize = true;
            this.lbl_dBm.Location = new System.Drawing.Point(234, 13);
            this.lbl_dBm.Name = "lbl_dBm";
            this.lbl_dBm.Size = new System.Drawing.Size(28, 13);
            this.lbl_dBm.TabIndex = 105;
            this.lbl_dBm.Text = "dBm";
            // 
            // txt_HighdBm
            // 
            this.txt_HighdBm.Culture = new System.Globalization.CultureInfo("en-US");
            this.txt_HighdBm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HighdBm.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_HighdBm.Location = new System.Drawing.Point(180, 35);
            this.txt_HighdBm.Mask = "<<#000>>";
            this.txt_HighdBm.Name = "txt_HighdBm";
            this.txt_HighdBm.PromptChar = '0';
            this.txt_HighdBm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_HighdBm.Size = new System.Drawing.Size(48, 26);
            this.txt_HighdBm.TabIndex = 104;
            this.txt_HighdBm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_HighdBm.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // txt_LowdBm
            // 
            this.txt_LowdBm.Culture = new System.Globalization.CultureInfo("en-US");
            this.txt_LowdBm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LowdBm.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_LowdBm.Location = new System.Drawing.Point(180, 5);
            this.txt_LowdBm.Mask = "#000";
            this.txt_LowdBm.Name = "txt_LowdBm";
            this.txt_LowdBm.PromptChar = '0';
            this.txt_LowdBm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_LowdBm.Size = new System.Drawing.Size(48, 26);
            this.txt_LowdBm.TabIndex = 103;
            this.txt_LowdBm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_LowdBm.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // lbl_Hz_3
            // 
            this.lbl_Hz_3.AutoSize = true;
            this.lbl_Hz_3.Location = new System.Drawing.Point(301, 79);
            this.lbl_Hz_3.Name = "lbl_Hz_3";
            this.lbl_Hz_3.Size = new System.Drawing.Size(20, 13);
            this.lbl_Hz_3.TabIndex = 116;
            this.lbl_Hz_3.Text = "Hz";
            // 
            // pnl_MeasParam
            // 
            this.pnl_MeasParam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_MeasParam.Controls.Add(this.lbl_Hz_3);
            this.pnl_MeasParam.Controls.Add(this.lbl_Hz_2);
            this.pnl_MeasParam.Controls.Add(this.lbl_Hz_1);
            this.pnl_MeasParam.Controls.Add(this.txt_startFreqMask);
            this.pnl_MeasParam.Controls.Add(this.txt_Step);
            this.pnl_MeasParam.Controls.Add(this.txt_endFreqMask);
            this.pnl_MeasParam.Controls.Add(this.lbl_StartFreq);
            this.pnl_MeasParam.Controls.Add(this.lbl_Step);
            this.pnl_MeasParam.Controls.Add(this.lbl_EndFreq);
            this.pnl_MeasParam.Location = new System.Drawing.Point(3, 35);
            this.pnl_MeasParam.Name = "pnl_MeasParam";
            this.pnl_MeasParam.Size = new System.Drawing.Size(365, 110);
            this.pnl_MeasParam.TabIndex = 115;
            // 
            // lbl_Hz_2
            // 
            this.lbl_Hz_2.AutoSize = true;
            this.lbl_Hz_2.Location = new System.Drawing.Point(301, 49);
            this.lbl_Hz_2.Name = "lbl_Hz_2";
            this.lbl_Hz_2.Size = new System.Drawing.Size(20, 13);
            this.lbl_Hz_2.TabIndex = 115;
            this.lbl_Hz_2.Text = "Hz";
            // 
            // lbl_Hz_1
            // 
            this.lbl_Hz_1.AutoSize = true;
            this.lbl_Hz_1.Location = new System.Drawing.Point(301, 19);
            this.lbl_Hz_1.Name = "lbl_Hz_1";
            this.lbl_Hz_1.Size = new System.Drawing.Size(20, 13);
            this.lbl_Hz_1.TabIndex = 114;
            this.lbl_Hz_1.Text = "Hz";
            // 
            // txt_startFreqMask
            // 
            this.txt_startFreqMask.Culture = new System.Globalization.CultureInfo("en-US");
            this.txt_startFreqMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_startFreqMask.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_startFreqMask.Location = new System.Drawing.Point(179, 11);
            this.txt_startFreqMask.Mask = "0.000.000.000";
            this.txt_startFreqMask.Name = "txt_startFreqMask";
            this.txt_startFreqMask.PromptChar = '0';
            this.txt_startFreqMask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_startFreqMask.Size = new System.Drawing.Size(116, 26);
            this.txt_startFreqMask.TabIndex = 96;
            this.txt_startFreqMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_startFreqMask.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // txt_endFreqMask
            // 
            this.txt_endFreqMask.Culture = new System.Globalization.CultureInfo("en-US");
            this.txt_endFreqMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_endFreqMask.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txt_endFreqMask.Location = new System.Drawing.Point(179, 41);
            this.txt_endFreqMask.Mask = "0.000.000.000";
            this.txt_endFreqMask.Name = "txt_endFreqMask";
            this.txt_endFreqMask.PromptChar = '0';
            this.txt_endFreqMask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_endFreqMask.Size = new System.Drawing.Size(116, 26);
            this.txt_endFreqMask.TabIndex = 97;
            this.txt_endFreqMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_endFreqMask.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // lbl_StartFreq
            // 
            this.lbl_StartFreq.AutoSize = true;
            this.lbl_StartFreq.Location = new System.Drawing.Point(52, 19);
            this.lbl_StartFreq.Name = "lbl_StartFreq";
            this.lbl_StartFreq.Size = new System.Drawing.Size(82, 13);
            this.lbl_StartFreq.TabIndex = 98;
            this.lbl_StartFreq.Text = "Start Frequency";
            // 
            // lbl_Step
            // 
            this.lbl_Step.AutoSize = true;
            this.lbl_Step.Location = new System.Drawing.Point(52, 79);
            this.lbl_Step.Name = "lbl_Step";
            this.lbl_Step.Size = new System.Drawing.Size(29, 13);
            this.lbl_Step.TabIndex = 100;
            this.lbl_Step.Text = "Step";
            // 
            // lbl_EndFreq
            // 
            this.lbl_EndFreq.AutoSize = true;
            this.lbl_EndFreq.Location = new System.Drawing.Point(52, 49);
            this.lbl_EndFreq.Name = "lbl_EndFreq";
            this.lbl_EndFreq.Size = new System.Drawing.Size(79, 13);
            this.lbl_EndFreq.TabIndex = 99;
            this.lbl_EndFreq.Text = "End Frequency";
            // 
            // btn_startBandScope
            // 
            this.btn_startBandScope.Location = new System.Drawing.Point(187, 5);
            this.btn_startBandScope.Name = "btn_startBandScope";
            this.btn_startBandScope.Size = new System.Drawing.Size(82, 21);
            this.btn_startBandScope.TabIndex = 101;
            this.btn_startBandScope.Text = "Start";
            this.btn_startBandScope.UseVisualStyleBackColor = true;
            this.btn_startBandScope.Click += new System.EventHandler(this.btn_startBandScope_Click);
            // 
            // pnl_StartBtn
            // 
            this.pnl_StartBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_StartBtn.Controls.Add(this.btn_startBandScope);
            this.pnl_StartBtn.Controls.Add(this.pct_OFF);
            this.pnl_StartBtn.Controls.Add(this.pct_ON);
            this.pnl_StartBtn.Location = new System.Drawing.Point(382, 109);
            this.pnl_StartBtn.Name = "pnl_StartBtn";
            this.pnl_StartBtn.Size = new System.Drawing.Size(365, 35);
            this.pnl_StartBtn.TabIndex = 116;
            // 
            // pct_OFF
            // 
            this.pct_OFF.Image = global::g_ICR2500.Properties.Resources.off;
            this.pct_OFF.Location = new System.Drawing.Point(144, 3);
            this.pct_OFF.Name = "pct_OFF";
            this.pct_OFF.Size = new System.Drawing.Size(25, 25);
            this.pct_OFF.TabIndex = 109;
            this.pct_OFF.TabStop = false;
            // 
            // pct_ON
            // 
            this.pct_ON.Image = global::g_ICR2500.Properties.Resources.on;
            this.pct_ON.Location = new System.Drawing.Point(144, 3);
            this.pct_ON.Name = "pct_ON";
            this.pct_ON.Size = new System.Drawing.Size(25, 25);
            this.pct_ON.TabIndex = 110;
            this.pct_ON.TabStop = false;
            // 
            // timerScan
            // 
            this.timerScan.Interval = 50;
            this.timerScan.Tick += new System.EventHandler(this.timerScan_Tick);
            // 
            // g_ICR2500_scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_GraphLimits);
            this.Controls.Add(this.pnl_MeasParam);
            this.Controls.Add(this.pnl_StartBtn);
            this.Name = "g_ICR2500_scan";
            this.Size = new System.Drawing.Size(750, 400);
            this.pnl_GraphLimits.ResumeLayout(false);
            this.pnl_GraphLimits.PerformLayout();
            this.pnl_MeasParam.ResumeLayout(false);
            this.pnl_MeasParam.PerformLayout();
            this.pnl_StartBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pct_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_ON)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pct_OFF;
        private System.Windows.Forms.MaskedTextBox txt_Step;
        private System.Windows.Forms.PictureBox pct_ON;
        private System.Windows.Forms.Panel pnl_GraphLimits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_dBm_2;
        private System.Windows.Forms.Label lbl_dBm;
        private System.Windows.Forms.MaskedTextBox txt_HighdBm;
        private System.Windows.Forms.MaskedTextBox txt_LowdBm;
        private System.Windows.Forms.Label lbl_Hz_3;
        private System.Windows.Forms.Panel pnl_MeasParam;
        private System.Windows.Forms.Label lbl_Hz_2;
        private System.Windows.Forms.Label lbl_Hz_1;
        private System.Windows.Forms.MaskedTextBox txt_startFreqMask;
        private System.Windows.Forms.MaskedTextBox txt_endFreqMask;
        private System.Windows.Forms.Label lbl_StartFreq;
        private System.Windows.Forms.Label lbl_Step;
        private System.Windows.Forms.Label lbl_EndFreq;
        private System.Windows.Forms.Button btn_startBandScope;
        private System.Windows.Forms.Panel pnl_StartBtn;
        private System.Windows.Forms.Timer timerScan;
    }
}
