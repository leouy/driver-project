using System;
using System.Collections.Generic;
using System.Text;

namespace g_ICR2500
{
    class g_ICR2500_databag
    {
        private static g_ICR2500_databag _dataBag;
        private string _signalStrength;
        private List<g_ICR2500_constants.FreqChartPoints> _sweep;
        public g_ICR2500_frm Form { get; set; }
        public string StartFreq { get; set; }
        public string EndFreq { get; set; }
        public string Step { get; set; }
        public string CurrentFreq { get; set; }
        public bool BandScope { get; set; }
        public bool BandScopeScan { get; set; }
        public string Filter { get; set; }
        public string Mode { get; set; }
        public bool CurrentMeasure { get; set; }
        public bool IcomOn { get; set; }
        public bool Attenuator { get; set; }
        public string Squelch { get; set; }
        public string M_Type;
        public bool IMM = true;

        public g_ICR2500_databag()
        {
            _sweep = new List<g_ICR2500_constants.FreqChartPoints>();
            StartFreq = "88000000";
            EndFreq = "105000000";
            Step = "5000";
            CurrentFreq = "0";
            BandScope = false;
            BandScopeScan = false;
            CurrentMeasure = false;
        }

        public static g_ICR2500_databag GetInstance()
        {
            if (_dataBag == null) _dataBag = new g_ICR2500_databag();
            return _dataBag;
        }

        public string SignalStrength
        {
            get { return _signalStrength; }
            set
            {
                _signalStrength = value;
                bool M = g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M;

                if (!_dataBag.BandScopeScan && !M)
                {
                    Form.FFMTab.Invoke(new EventHandler(delegate
                    {
                        Form.FFMTab.UpdateSignalStrength();
                    }));
                }
            }
        }

        public List<g_ICR2500_constants.FreqChartPoints> Sweep
        {
            get { return _sweep; }
            set
            {
                _sweep = value;
            }
        }

        public void UpdateSweep()
        {
            Form.FFMTab.Invoke(new EventHandler(delegate
            {
                //Form.FFMTab.UpdateFFM();
                Sweep.Clear();
            }));
        }

        public void UpdateSweepDScan()
        {
            if (Form.DSCANTab != null)
            {
                Form.DSCANTab.Invoke(new EventHandler(delegate
                {
                    Form.DSCANTab.UpdateDSCAN();
                    Sweep.Clear();

                }));
            }
        }

        public g_ICR2500_constants.FrequencyMeasure[] scanMeas { get; set; }
        public bool scanFull { get; set; }
    }
}
