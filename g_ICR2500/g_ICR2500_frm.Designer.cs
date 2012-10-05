namespace g_ICR2500
{
    partial class g_ICR2500_frm
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
            this.tab_Control_Forms = new System.Windows.Forms.TabControl();
            this.tab_Page_FFM = new System.Windows.Forms.TabPage();
            this.tab_Page_DSCAN = new System.Windows.Forms.TabPage();
            this.btn_ATT = new System.Windows.Forms.Button();
            this.btn_AGC = new System.Windows.Forms.Button();
            this.btn_NB = new System.Windows.Forms.Button();
            this.cmb_Filter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmb_Mode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab_Control_Forms.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Control_Forms
            // 
            this.tab_Control_Forms.Controls.Add(this.tab_Page_FFM);
            this.tab_Control_Forms.Controls.Add(this.tab_Page_DSCAN);
            this.tab_Control_Forms.Location = new System.Drawing.Point(12, 74);
            this.tab_Control_Forms.Name = "tab_Control_Forms";
            this.tab_Control_Forms.SelectedIndex = 0;
            this.tab_Control_Forms.Size = new System.Drawing.Size(760, 400);
            this.tab_Control_Forms.TabIndex = 0;
            this.tab_Control_Forms.SelectedIndexChanged += new System.EventHandler(this.tab_Control_Forms_SelectedIndexChanged);
            // 
            // tab_Page_FFM
            // 
            this.tab_Page_FFM.Location = new System.Drawing.Point(4, 22);
            this.tab_Page_FFM.Name = "tab_Page_FFM";
            this.tab_Page_FFM.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Page_FFM.Size = new System.Drawing.Size(752, 374);
            this.tab_Page_FFM.TabIndex = 0;
            this.tab_Page_FFM.Text = "FFM";
            this.tab_Page_FFM.UseVisualStyleBackColor = true;
            // 
            // tab_Page_DSCAN
            // 
            this.tab_Page_DSCAN.Location = new System.Drawing.Point(4, 22);
            this.tab_Page_DSCAN.Name = "tab_Page_DSCAN";
            this.tab_Page_DSCAN.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Page_DSCAN.Size = new System.Drawing.Size(752, 374);
            this.tab_Page_DSCAN.TabIndex = 1;
            this.tab_Page_DSCAN.Text = "SCAN";
            this.tab_Page_DSCAN.UseVisualStyleBackColor = true;
            // 
            // btn_ATT
            // 
            this.btn_ATT.Location = new System.Drawing.Point(543, 10);
            this.btn_ATT.Name = "btn_ATT";
            this.btn_ATT.Size = new System.Drawing.Size(82, 21);
            this.btn_ATT.TabIndex = 105;
            this.btn_ATT.Text = "ATT";
            this.btn_ATT.UseVisualStyleBackColor = true;
            this.btn_ATT.Click += new System.EventHandler(this.btn_ATT_Click);
            // 
            // btn_AGC
            // 
            this.btn_AGC.Location = new System.Drawing.Point(631, 10);
            this.btn_AGC.Name = "btn_AGC";
            this.btn_AGC.Size = new System.Drawing.Size(82, 21);
            this.btn_AGC.TabIndex = 104;
            this.btn_AGC.Text = "AGC";
            this.btn_AGC.UseVisualStyleBackColor = true;
            this.btn_AGC.Click += new System.EventHandler(this.btn_AGC_Click);
            // 
            // btn_NB
            // 
            this.btn_NB.Location = new System.Drawing.Point(453, 10);
            this.btn_NB.Name = "btn_NB";
            this.btn_NB.Size = new System.Drawing.Size(84, 21);
            this.btn_NB.TabIndex = 103;
            this.btn_NB.Text = "NB";
            this.btn_NB.UseVisualStyleBackColor = true;
            this.btn_NB.Click += new System.EventHandler(this.btn_NB_Click);
            // 
            // cmb_Filter
            // 
            this.cmb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Filter.FormattingEnabled = true;
            this.cmb_Filter.Location = new System.Drawing.Point(189, 10);
            this.cmb_Filter.Name = "cmb_Filter";
            this.cmb_Filter.Size = new System.Drawing.Size(82, 21);
            this.cmb_Filter.TabIndex = 101;
            this.cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.cmb_Filter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(154, 13);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 106;
            this.lblFilter.Text = "Filter";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(300, 13);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 107;
            this.lblMode.Text = "Mode";
            // 
            // cmb_Mode
            // 
            this.cmb_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Mode.FormattingEnabled = true;
            this.cmb_Mode.Location = new System.Drawing.Point(340, 10);
            this.cmb_Mode.Name = "cmb_Mode";
            this.cmb_Mode.Size = new System.Drawing.Size(82, 21);
            this.cmb_Mode.TabIndex = 102;
            this.cmb_Mode.SelectedIndexChanged += new System.EventHandler(this.cmb_Mode_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_ATT);
            this.panel1.Controls.Add(this.btn_AGC);
            this.panel1.Controls.Add(this.btn_NB);
            this.panel1.Controls.Add(this.lblFilter);
            this.panel1.Controls.Add(this.cmb_Filter);
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.cmb_Mode);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 49);
            this.panel1.TabIndex = 108;
            // 
            // g_ICR2500_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 492);
            this.Controls.Add(this.tab_Control_Forms);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "g_ICR2500_frm";
            this.Text = "IC-R2500 GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.g_ICR2500_frm_FormClosed);
            this.Load += new System.EventHandler(this.g_ICR2500_frm_Load);
            this.tab_Control_Forms.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Control_Forms;
        private System.Windows.Forms.TabPage tab_Page_FFM;
        private System.Windows.Forms.TabPage tab_Page_DSCAN;
        private System.Windows.Forms.Button btn_ATT;
        private System.Windows.Forms.Button btn_AGC;
        private System.Windows.Forms.Button btn_NB;
        private System.Windows.Forms.ComboBox cmb_Filter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmb_Mode;
        private System.Windows.Forms.Panel panel1;
    }
}