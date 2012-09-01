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
            this.tab_Control_Forms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Control_Forms
            // 
            this.tab_Control_Forms.Controls.Add(this.tab_Page_FFM);
            this.tab_Control_Forms.Controls.Add(this.tab_Page_DSCAN);
            this.tab_Control_Forms.Location = new System.Drawing.Point(12, 12);
            this.tab_Control_Forms.Name = "tab_Control_Forms";
            this.tab_Control_Forms.SelectedIndex = 0;
            this.tab_Control_Forms.Size = new System.Drawing.Size(760, 470);
            this.tab_Control_Forms.TabIndex = 0;
            this.tab_Control_Forms.SelectedIndexChanged += new System.EventHandler(this.tab_Control_Forms_SelectedIndexChanged);
            // 
            // tab_Page_FFM
            // 
            this.tab_Page_FFM.Location = new System.Drawing.Point(4, 22);
            this.tab_Page_FFM.Name = "tab_Page_FFM";
            this.tab_Page_FFM.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Page_FFM.Size = new System.Drawing.Size(752, 444);
            this.tab_Page_FFM.TabIndex = 0;
            this.tab_Page_FFM.Text = "FFM";
            this.tab_Page_FFM.UseVisualStyleBackColor = true;
            // 
            // tab_Page_DSCAN
            // 
            this.tab_Page_DSCAN.Location = new System.Drawing.Point(4, 22);
            this.tab_Page_DSCAN.Name = "tab_Page_DSCAN";
            this.tab_Page_DSCAN.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Page_DSCAN.Size = new System.Drawing.Size(752, 444);
            this.tab_Page_DSCAN.TabIndex = 1;
            this.tab_Page_DSCAN.Text = "SCAN";
            this.tab_Page_DSCAN.UseVisualStyleBackColor = true;
            // 
            // g_ICR2500_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 492);
            this.Controls.Add(this.tab_Control_Forms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "g_ICR2500_frm";
            this.Text = "IC-R2500 GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.g_ICR2500_frm_FormClosed);
            this.Load += new System.EventHandler(this.g_ICR2500_frm_Load);
            this.tab_Control_Forms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Control_Forms;
        private System.Windows.Forms.TabPage tab_Page_FFM;
        private System.Windows.Forms.TabPage tab_Page_DSCAN;
    }
}