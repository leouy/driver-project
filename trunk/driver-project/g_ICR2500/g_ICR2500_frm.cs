using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExtDrv;
using System.Threading;

namespace g_ICR2500
{
    public partial class g_ICR2500_frm : Form
    {
        g_ICR2500_icommanager IcomMgr;
        public g_ICR2500_ffm FFMTab;
        public g_ICR2500_scan DSCANTab;

        public g_ICR2500_frm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icr2500;
            IcomMgr = g_ICR2500_icommanager.GetInstance();
            this.FFMTab = new g_ICR2500_ffm();
            tab_Page_FFM.Controls.AddRange(new Control[] { FFMTab });
            this.DSCANTab = new g_ICR2500_scan();
            tab_Page_DSCAN.Controls.AddRange(new Control[] { DSCANTab });

        }

        private void g_ICR2500_frm_Load(object sender, EventArgs e)
        {
            LoadFormValues();
            Form_DH_INIT();
        }

        private void TurnOn()
        {
            if (g_ICR2500_decl.bPhysical)
            {
                IcomMgr.TurnOn();
                g_ICR2500_databag.GetInstance().IcomOn = true;
            }
        }

        private void TurnOff()
        {
            IcomMgr.TurnOff();
            g_ICR2500_databag.GetInstance().IcomOn = false;
        }

        private void LoadFormValues()
        {
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                FFMTab.DefaultValues();
                IcomMgr.AutoUpdate(true);
            }
            FFMTab.Enabled = true;
            DSCANTab.Enabled = true;
        }

        private void g_ICR2500_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            object oVar = null;
            g_ICR2500.dci_Data((Int32)e_Commands.DH_NFY_CANCEL, 0, ref oVar);
            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {
                object pVar = null;
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref pVar);
            }
            else 
            {
                TurnOff();
            }
            g_ICR2500_decl.f.FFMTab.Dispose();
            g_ICR2500_decl.f.DSCANTab.Dispose();
            g_ICR2500_decl.f.FFMTab = null;
            g_ICR2500_decl.f.DSCANTab = null;
            g_ICR2500_decl.f.DestroyHandle();
            g_ICR2500_decl.f.Dispose();
            g_ICR2500_decl.f = null;
        }

        private void tab_Control_Forms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 0)
            {
                if (DSCANTab.BandScopeVisible_DSCAN)
                {
                    DSCANTab.BandScopeVisible_DSCAN = !DSCANTab.BandScopeVisible_DSCAN;
                    g_ICR2500_databag.GetInstance().BandScopeScan = DSCANTab.BandScopeVisible_DSCAN;
                    DSCANTab.DSCAN_Off();
                }
                g_ICR2500_icommanager.GetInstance().AutoUpdate(true);
                FFMTab.SetFrequency();
                g_ICR2500_databag.GetInstance().IMM = false;
                g_ICR2500_databag.GetInstance().M_Type = "Level";
                g_ICR2500_decl.UsedParams = 4097;



            }
            else if (((TabControl)sender).SelectedIndex == 1)
            {
                if (FFMTab.BandScopeVisible)
                {
                    FFMTab.BandScopeVisible = !FFMTab.BandScopeVisible;
                    g_ICR2500_databag.GetInstance().BandScope = FFMTab.BandScopeVisible;
                    FFMTab.SCAN_Off();
                }
                if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                {
                    object nVar = null;
                    g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref nVar);
                }
                g_ICR2500_databag.GetInstance().IMM = false;
                g_ICR2500_databag.GetInstance().M_Type = "Scan Level";
                g_ICR2500_decl.UsedParams = 8193;


                g_ICR2500_icommanager.GetInstance().AutoUpdate(false);
            }
        }

        public void Form_DH_INIT()
        {
            if (g_ICR2500_decl.f == null)
                g_ICR2500_decl.f = new g_ICR2500_frm();
            if (g_ICR2500_decl.fSet == null)
                g_ICR2500_decl.fSet = new g_ICR2500_frmSet();
            g_ICR2500_databag.GetInstance().Form = g_ICR2500_decl.f;
        }

    }
}
