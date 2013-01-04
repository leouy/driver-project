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
        g_ICR2500_icommanager IcomManager;
        public g_ICR2500_ffm FFMTab;
        public g_ICR2500_scan DSCANTab;
        bool NBOn = false;
        bool AttOn = false;
        bool AgcOn = false;

        g_ICR2500_constants.FrequencyStep FrequencyVal;
        g_ICR2500_constants.Filter FilterVal;
        g_ICR2500_constants.Mode ModeVal;

        public g_ICR2500_frm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icr2500;
            this.FFMTab = new g_ICR2500_ffm();
            tab_Page_FFM.Controls.AddRange(new Control[] { FFMTab });
            this.DSCANTab = new g_ICR2500_scan();
            tab_Page_DSCAN.Controls.AddRange(new Control[] { DSCANTab });

        }

        private void g_ICR2500_frm_Load(object sender, EventArgs e)
        {
            IcomManager = g_ICR2500_icommanager.GetInstance();
            FilterLoad();
            ModesLoad();
            LoadFormValues();
            Form_DH_INIT();
        }

        private void TurnOn()
        {
            if (g_ICR2500_decl.bPhysical)
            {
                IcomManager.TurnOn();
                g_ICR2500_databag.GetInstance().IcomOn = true;
            }
        }

        private void TurnOff()
        {
            IcomManager.TurnOff();
            g_ICR2500_databag.GetInstance().IcomOn = false;
        }

        private void LoadFormValues()
        {
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                FFMTab.DefaultValues();
                if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M)
                {
                    object pVar2 = (object)FilterVal.Name;
                    object pVar3 = (object)ModeVal.Name;
                    g_ICR2500.dci_SetRemote((int)e_Commands.DH_IFBW, 0, ref pVar2);
                    g_ICR2500.dci_SetRemote((int)e_Commands.DH_DEMOD, 0, ref pVar3);
                }
                IcomManager.AutoUpdate(true);
            }
            FFMTab.Enabled = true;
            DSCANTab.Enabled = true;
            cmb_Filter.SelectedIndex = 4;
            cmb_Mode.SelectedIndex = 5;
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
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        DSCANTab.DSCAN_Remote_Off();
                    }
                    else 
                    {
                        DSCANTab.DSCAN_Off();
                    }

                    //FFM Tab off
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        object nVar = null;
                        g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref nVar);
                    }
                    else
                    {
                        IcomManager.TurnOff();
                        IcomManager.AutoUpdate(false);
                        g_ICR2500_databag.GetInstance().IcomOn = false;
                        g_ICR2500_icommanager.GetInstance().AutoUpdate(true);
                    }
                    
                }
              
                FFMTab.SetFrequency();
                g_ICR2500_databag.GetInstance().IMM = false;
                g_ICR2500_databag.GetInstance().M_Type = "Level";
                g_ICR2500_decl.UsedParams = 4097;
                g_ICR2500_databag.GetInstance().SignalStrength = "-127";


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
                else 
                {
                    IcomManager.TurnOff();
                    IcomManager.AutoUpdate(false);
                    g_ICR2500_databag.GetInstance().IcomOn = false;                   
                }

                if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                {
                    DSCANTab.DSCAN_Remote_Off();
                }
                else
                {
                    DSCANTab.DSCAN_Off();
                    g_ICR2500_icommanager.GetInstance().AutoUpdate(false);
                }

                g_ICR2500_databag.GetInstance().IMM = false;
                g_ICR2500_databag.GetInstance().M_Type = "Scan Level";
                g_ICR2500_decl.UsedParams = 8193;
                
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

        private void FilterLoad()
        {
            cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("3 KHz", "00"));
            cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("6 KHz", "01"));
            cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("15 KHz", "02"));
            cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("50 KHz", "03"));
            cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("230 KHz", "04"));
        }

        private void ModesLoad()
        {
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("LSB", "00"));
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("USB", "01"));
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("AM", "02"));
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("CW", "03"));
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("NFM", "05"));
            cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("WFM", "06"));
        }

        private void cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterVal = (g_ICR2500_constants.Filter)cmb_Filter.SelectedItem;
            g_ICR2500_databag.GetInstance().Filter = FilterVal.Value;

            object pVar2 = (object)FilterVal.Name;

            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_IFBW, 0, ref pVar2);
            }
            else 
            {
                string freqToArgus = g_ICR2500_databag.GetInstance().CurrentFreq;
                object pVar = (object)freqToArgus;
                g_ICR2500.dci_Data((Int32)ExtDrv.e_Commands.DH_NFY_CHANGE, (Int32)ExtDrv.e_Commands.DH_FREQ_FFM_GET, ref pVar);
                IcomManager.SetFrequency(freqToArgus, g_ICR2500_databag.GetInstance().Filter, g_ICR2500_databag.GetInstance().Mode);
            }
        }

        private void cmb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModeVal = (g_ICR2500_constants.Mode)cmb_Mode.SelectedItem;
            g_ICR2500_databag.GetInstance().Mode = ModeVal.Value;
           // string[] a = g_ICR2500_databag.GetInstance().CurrentFreq.Split('.');

            object pVar2 = (object)ModeVal.Name;

            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_DEMOD, 0, ref pVar2);
            }

            string freqToArgus = g_ICR2500_databag.GetInstance().CurrentFreq;
            object pVar = (object)freqToArgus;
            g_ICR2500.dci_Data((Int32)ExtDrv.e_Commands.DH_NFY_MEAS_DATA, (Int32)ExtDrv.e_Commands.DH_FREQ_FFM_GET, ref pVar);
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                IcomManager.SetFrequency(freqToArgus, g_ICR2500_databag.GetInstance().Filter, g_ICR2500_databag.GetInstance().Mode);
            }
        }

        private void btn_NB_Click(object sender, EventArgs e)
        {
            NBOn = !NBOn;

            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                IcomManager.SetNoiseBlanker(NBOn);
            }
            //
            if (NBOn)
            {
                btn_NB.ForeColor = Color.Red;
            }
            else
            {
                btn_NB.ForeColor = Color.Black;
            }
        }

        private void btn_AGC_Click(object sender, EventArgs e)
        {
            AgcOn = !AgcOn;
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                IcomManager.SetAgc(AgcOn);
            }

            if (AgcOn)
            {
                btn_AGC.ForeColor = Color.Red;
            }
            else
            {
                btn_AGC.ForeColor = Color.Black;
            }
        }

        private void btn_ATT_Click(object sender, EventArgs e)
        {
            AttOn = !AttOn;
            string res = AttOn ? "20 dB" : "0 dB";
            object pVar = (object)res;
            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_RFATTN, 0, ref pVar);
            }
            else
            {
                IcomManager.SetAttenuator(AttOn);
            }

            if (AttOn)
            {
                btn_ATT.ForeColor = Color.Red;
            }
            else
            {
                btn_ATT.ForeColor = Color.Black;
            }
        }

        
    }
}
