using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.quinncurtis.chart2dnet;
using ExtDrv;
using System.Threading;
using System.Runtime.InteropServices;

namespace g_ICR2500
{
    public partial class g_ICR2500_ffm : ChartView
    {
        #region Properties
        private g_ICR2500_icommanager IcomManager;
        public bool BandScopeVisible;
        ChartView ChartFFM;
        public double[] YPoints { get; set; }
        public double[] XPoints { get; set; }

        private const int NumPoints = 1;
        public SimpleDataset DataSet;
        Font TheFont;
        //public double StartFrequency { get; set; }
        //public double StopFrequency { get; set; }

        //bool NBOn = false;
        //bool AttOn = false;
        //bool AgcOn = false;

        g_ICR2500_constants.FrequencyStep FrequencyVal;
        //g_ICR2500_constants.Filter FilterVal;
        //g_ICR2500_constants.Mode ModeVal;

        string CurrentVol;
        string CurrentSquelch;
        #endregion Properties

        #region Contructor / FormLoad
        public g_ICR2500_ffm()
        {

            InitializeComponent();
            IcomManager = g_ICR2500_icommanager.GetInstance();
            this.Enabled = false;
            InitializeSquelchTrackBar();
            InitializeVolumeTrackBar();
            InitializeChart();

        }

        private void g_ICR2500_ffm_Load(object sender, EventArgs e)
        {
            FrequencyStepLoad();
            //FilterLoad();
            //ModesLoad();
            cmb_step.SelectedIndex = 0;
            //cmb_Filter.SelectedIndex = 4;
            //cmb_Mode.SelectedIndex = 5;
            FrequencyVal = (g_ICR2500_constants.FrequencyStep)cmb_step.SelectedItem;

        }

        public void DefaultValues()
        {
            string Freq = txt_freqMask.Text;
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                IcomManager.SetBaudRate("05");
            }

            //if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M)
            //{
            //    object pVar2 = (object)FilterVal.Name;
            //    object pVar3 = (object)ModeVal.Name;
            //    g_ICR2500.dci_SetRemote((int)e_Commands.DH_IFBW, 0, ref pVar2);
            //    g_ICR2500.dci_SetRemote((int)e_Commands.DH_DEMOD, 0, ref pVar3);
            //}

            //Freq - Mode - Filter
            string[] a = txt_freqMask.Text.Split('.');
            string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", a));
            object pVar = (object)freqToArgus;
            g_ICR2500.dci_Data((Int32)ExtDrv.e_Commands.DH_NFY_CHANGE, (Int32)ExtDrv.e_Commands.DH_FREQ_FFM_GET, ref pVar);

            int valueSq = trk_Squelch.Value;
            CurrentSquelch = g_ICR2500_utils.ConvertIntToHex(valueSq);
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                IcomManager.SetSquelch(CurrentSquelch);
            }


        }
        #endregion Contructor / FormLoad

        #region Loads
        private void FrequencyStepLoad()
        {
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("1.000 Hz", 1000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("10.000 Hz", 10000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("12.500 Hz", 12500));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("25.000 Hz", 25000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("50.000 Hz", 50000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("100.000 Hz", 100000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("200.000 Hz", 200000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("500.000 Hz", 500000));
            cmb_step.Items.Add(new g_ICR2500_constants.FrequencyStep("1.000.000 Hz", 1000000));
        }

        //private void FilterLoad()
        //{
        //    cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("3 KHz", "00"));
        //    cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("6 KHz", "01"));
        //    cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("15 KHz", "02"));
        //    cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("50 KHz", "03"));
        //    cmb_Filter.Items.Add(new g_ICR2500_constants.Filter("230 KHz", "04"));
        //}

        //private void ModesLoad()
        //{
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("LSB", "00"));
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("USB", "01"));
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("AM", "02"));
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("CW", "03"));
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("NFM", "05"));
        //    cmb_Mode.Items.Add(new g_ICR2500_constants.Mode("WFM", "06"));
        //}


        #endregion Loads

        #region Initializers
        private void InitializeVolumeTrackBar()
        {
            trk_volume.Orientation = Orientation.Vertical;
            trk_volume.TickFrequency = 10;
            trk_volume.SmallChange = 1;
            trk_volume.Height = 104;
            trk_volume.Maximum = 100;
            trk_volume.Value = 0;
            CurrentVol = g_ICR2500_utils.ConvertIntToHex(trk_volume.Value);
        }

        private void InitializeSquelchTrackBar()
        {
            trk_Squelch.Orientation = Orientation.Vertical;
            trk_Squelch.TickFrequency = 10;
            trk_Squelch.SmallChange = 1;
            trk_Squelch.Height = 104;
            trk_Squelch.Maximum = 100;
            trk_Squelch.Value = 0;
            CurrentSquelch = g_ICR2500_utils.ConvertIntToHex(trk_Squelch.Value);
        }


        public void InitializeChart()
        {
            int NumPoint = 1;
            ChartFFM = this;
            XPoints = new double[NumPoint];
            YPoints = new double[NumPoint];

            int i;


            for (i = 0; i < NumPoint; i++)
            {
                XPoints[i] = i;
                YPoints[i] = -127;
            }



            TheFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            DataSet = new SimpleDataset("Signal Strength", XPoints, YPoints);
            CartesianCoordinates pTransform1 = new CartesianCoordinates();
            pTransform1.AutoScale(DataSet, ChartObj.AUTOAXES_FAR, ChartObj.AUTOAXES_FAR);
            pTransform1.SetScaleStartY(-127);
            pTransform1.SetScaleStopY(0);
            // double freq = double.Parse(g_ICR2500_databag.GetInstance().CurrentFreq);

            pTransform1.SetScaleX(0, 1);

            pTransform1.SetGraphBorderDiagonal(0.375, .375, .395, 0.775);
            Background graphbackground = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND,
                Color.LightGray);
            ChartFFM.AddChartObject(graphbackground);
            Background plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND,
                Color.Black);
            ChartFFM.AddChartObject(plotbackground);

            LinearAxis xAxis = new LinearAxis(pTransform1, ChartObj.X_AXIS);
            xAxis.SetColor(Color.Black);
            ChartFFM.AddChartObject(xAxis);

            LinearAxis yAxis = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
            yAxis.SetColor(Color.Black);
            ChartFFM.AddChartObject(yAxis);

            NumericAxisLabels xAxisLab = new NumericAxisLabels(xAxis);
            xAxisLab.SetColor(Color.Black);
            ChartFFM.AddChartObject(xAxisLab);

            NumericAxisLabels yAxisLab = new NumericAxisLabels(yAxis);
            yAxisLab.SetColor(Color.Black);
            ChartFFM.AddChartObject(yAxisLab);

            Grid ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
            ygrid.SetColor(Color.White);
            ygrid.SetLineWidth(1);
            ChartFFM.AddChartObject(ygrid);

            ChartAttribute attrib1 = new ChartAttribute(Color.Green, 0, DashStyle.Solid, Color.Green);
            attrib1.SetFillFlag(true);
            SimpleBarPlot thePlot1 = new SimpleBarPlot(pTransform1, DataSet, 1, -127.0, attrib1, ChartObj.JUSTIFY_MIN);
            ChartFFM.AddChartObject(thePlot1);

            Font theTitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            ChartTitle mainTitle = new ChartTitle(pTransform1, theTitleFont, "Signal Strength IC-R2500");
            mainTitle.SetTitleType(ChartObj.CHART_HEADER);
            mainTitle.SetTitlePosition(ChartObj.CENTER_GRAPH);
            mainTitle.SetColor(Color.Black);
            ChartFFM.AddChartObject(mainTitle);

            Font theFooterFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            ChartTitle footer = new ChartTitle(pTransform1, theFooterFont,
                "Signal Strength for the selected scope.");
            footer.SetTitleType(ChartObj.CHART_FOOTER);
            footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
            footer.SetTitleOffset(8);
            footer.SetColor(Color.Black);
            ChartFFM.AddChartObject(footer);
            ChartFFM.UpdateDraw();
        }//end InitializeChart()

        #endregion Initializers

        #region ON/OFF
        public void SCAN_Off()
        {
            pct_ON.Visible = false;
            pct_OFF.Visible = true;
        }

        public void SCAN_On()
        {
            pct_ON.Visible = true;
            pct_OFF.Visible = false;
        }
        #endregion ON/OFF

        #region FormClicks/Values Changed

        private void trk_volume_ValueChanged(object sender, EventArgs e)
        {
            int value = ((TrackBar)sender).Value;
            lbl_VolumeValue.Text = value.ToString();
            CurrentVol = g_ICR2500_utils.ConvertIntToHex(value);
            try
            {
                if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
                {
                    IcomManager.SetVolume(CurrentVol);
                }


            }
            catch (Exception)
            {
                //Com not opened.
            }
        }

        private void trk_Squelch_ValueChanged(object sender, EventArgs e)
        {
            int value = ((TrackBar)sender).Value;
            lbl_SquelchValue.Text = value.ToString();
            CurrentSquelch = g_ICR2500_utils.ConvertIntToHex(value);
            g_ICR2500_databag.GetInstance().Squelch = CurrentSquelch;
            try
            {
                if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
                {
                    IcomManager.SetSquelch(CurrentSquelch);
                }

            }
            catch (Exception)
            {
                //Com not opened.
            }
        }

        //private void cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FilterVal = (g_ICR2500_constants.Filter)cmb_Filter.SelectedItem;
        //    g_ICR2500_databag.GetInstance().Filter = FilterVal.Value;
        //    string[] a = txt_freqMask.Text.Split('.');

        //    object pVar2 = (object)FilterVal.Name;

        //    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
        //    {
        //        g_ICR2500.dci_SetRemote((int)e_Commands.DH_IFBW, 0, ref pVar2);
        //    }


        //    string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", a));
        //    object pVar = (object)freqToArgus;
        //    g_ICR2500.dci_Data((Int32)ExtDrv.e_Commands.DH_NFY_CHANGE, (Int32)ExtDrv.e_Commands.DH_FREQ_FFM_GET, ref pVar);
        //}

        //private void cmb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ModeVal = (g_ICR2500_constants.Mode)cmb_Mode.SelectedItem;
        //    g_ICR2500_databag.GetInstance().Mode = ModeVal.Value;
        //    string[] a = txt_freqMask.Text.Split('.');

        //    object pVar2 = (object)ModeVal.Name;

        //    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
        //    {
        //        g_ICR2500.dci_SetRemote((int)e_Commands.DH_DEMOD, 0, ref pVar2);
        //    }

        //    string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", a));
        //    object pVar = (object)freqToArgus;
        //    g_ICR2500.dci_Data((Int32)ExtDrv.e_Commands.DH_NFY_MEAS_DATA, (Int32)ExtDrv.e_Commands.DH_FREQ_FFM_GET, ref pVar);
        //}

        private void btn_upFreq_Click(object sender, EventArgs e)
        {
            string[] a = txt_freqMask.Text.Split('.');
            txt_freqMask.Text = g_ICR2500_utils.CalculateFrequencyStep(String.Join("", a), FrequencyVal.Value, true);
            a = txt_freqMask.Text.Split('.');
            string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", a));
            object pVar = (object)freqToArgus;
            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {

                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_FFM, 0, ref pVar);
            }
            else //CM
            {
                IcomManager.SetFrequency(g_ICR2500_utils.ParseFullFrecuency(String.Join("", a)), 
                    g_ICR2500_databag.GetInstance().Filter, g_ICR2500_databag.GetInstance().Mode);

            }
        }

        private void btn_lowFreq_Click(object sender, EventArgs e)
        {
            string[] a = txt_freqMask.Text.Split('.');
            txt_freqMask.Text = g_ICR2500_utils.CalculateFrequencyStep(String.Join("", a), FrequencyVal.Value, false);
            a = txt_freqMask.Text.Split('.');
            string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", a));
            object pVar = (object)freqToArgus;
            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {

                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_FFM, 0, ref pVar);
            }
            else //CM
            {
                IcomManager.SetFrequency(g_ICR2500_utils.ParseFullFrecuency(String.Join("", a)),
                    g_ICR2500_databag.GetInstance().Filter, g_ICR2500_databag.GetInstance().Mode);
            }
        }

        public void txt_freqMask_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetFrequency();
            }
        }

        private void cmb_step_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrequencyVal = (g_ICR2500_constants.FrequencyStep)cmb_step.SelectedItem;
        }
        #endregion FormClicks/Values Changed

        public void SetFrequency()
        {
            string[] stepFreq = txt_freqMask.Text.Split('.');
            double ValidateFreq = double.Parse(String.Join("", stepFreq));
            if (ValidateFreq < 10000 || ValidateFreq > 3299999999)
            {
                MessageBox.Show("La frecuencia no puede ser menor a 0.010 MHz ni mayor a 3299.99 MHz.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_freqMask.Text =g_ICR2500_utils.ParseFullFrecuency(g_ICR2500_databag.GetInstance().CurrentFreq);
                return;
            }

            string freqToArgus = g_ICR2500_utils.ParseFullFrecuency(String.Join("", stepFreq));
            g_ICR2500_databag.GetInstance().CurrentFreq = freqToArgus;
            object pVar = (object)freqToArgus;

            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
            {
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_FFM, 0, ref pVar);
            }
            else //CM
            {
                IcomManager.SetFrequency(freqToArgus, g_ICR2500_databag.GetInstance().Filter, g_ICR2500_databag.GetInstance().Mode);
            }
        }

        [STAThread]
        public void UpdateFFM()
        {
            try
            {

                int y = Int32.Parse(g_ICR2500_databag.GetInstance().SignalStrength);
                int yStrength = g_ICR2500_utils.ConvertSignalToDBM(y);

                this.YPoints[0] = yStrength;
                this.UpdateSpectrumChart();

            }
            catch (Exception)
            {
                //
            }

        }

        public void UpdateSpectrumChart()
        {
            double y;
            Point2D p;
            int i;

            for (i = 0; i < DataSet.GetNumberDatapoints(); i++)
            {
                y = YPoints[i];
                // Use accessor methods
                p = DataSet[i]; // Get xy values at index i
                p.Y = y; // change y value
                DataSet[i] = p; // Set xy values at index i

                // Alternative way of changing just the y-value
                // Dataset1.SetYDataValue(i,y);
            }
            ChartFFM.UpdateDraw();
        }

        [STAThread]
        public void UpdateSignalStrength()
        {
            if (!string.IsNullOrEmpty(g_ICR2500_databag.GetInstance().SignalStrength))
            {
                if (g_ICR2500_databag.GetInstance().SignalStrength.Length < 5)
                {
                    this.txt_SignalStrength.Text = g_ICR2500_databag.GetInstance().SignalStrength;
                    double var = double.Parse(g_ICR2500_databag.GetInstance().SignalStrength);
                    UpdateChartDMM(var.ToString());
                }
            }
        }

        [STAThread]
        public void UpdateChartDMM(string signalS)
        {

            try
            {
                int y = Convert.ToInt32(signalS);
                try
                {

                    YPoints[0] = y;

                    UpdateSpectrumChart();

                }
                catch (Exception)
                {
                    //throw;
                }
                Thread.Sleep(1);
            }
            catch (Exception)
            {
                //No
            }
        }


        //RS:: handler for timer from Test_Dec
        public void ActivateTimer()
        {
            this.timerFFM.Enabled = true;
        }

        public void DisableTimer()
        {
            this.timerFFM.Enabled = false;
        }
        public void ActivateTimerDMM()
        {
            this.timerFFMDMM.Enabled = true;
        }


        private void timerFFM_tick(object sender, EventArgs e)
        {
            g_ICR2500.SendMeasResultToArgus();

            bool IMM = g_ICR2500_databag.GetInstance().IMM;
            if (IMM)
                this.timerFFM.Enabled = false; // for IMM one shot


        }

        private void timerFFMDMM_Tick(object sender, EventArgs e)
        {
            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M)
            {
                g_ICR2500.SendMeasResultToArgusDMM(g_ICR2500_decl.MEAS_SING);
            }
            else
            {
                //Pinto caja texto             
                UpdateSignalStrength();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
            {
                if (!BandScopeVisible)
                {
                    IcomManager.TurnOn();
                    IcomManager.AutoUpdate(true);
                    g_ICR2500_databag.GetInstance().IcomOn = true;

                    IcomManager.SetSquelch(CurrentSquelch);
                    IcomManager.SetVolume(CurrentVol);
                    pct_ON.Visible = true;
                    pct_OFF.Visible = false;
                }
                else
                {
                    IcomManager.TurnOff();
                    IcomManager.AutoUpdate(false);
                    g_ICR2500_databag.GetInstance().IcomOn = false;
                    pct_ON.Visible = false;
                    pct_OFF.Visible = true;
                }

            }
            else
            {
                //Sends Type Level 
                object pVar3 = "Level";
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_SET, 0, ref pVar3);
            }

            if (!BandScopeVisible)
            {
                BandScopeVisible = !BandScopeVisible;
                pct_ON.Visible = true;
                pct_OFF.Visible = false;
                g_ICR2500_databag.GetInstance().IMM = false;
                timerFFMDMM.Enabled = true;
                g_ICR2500_decl.UsedParams = 4097;
                g_ICR2500_databag.GetInstance().M_Type = "Level";


                object oo = null;

                g_ICR2500.dci_Data((Int32)e_Commands.DH_NFY_CHANGE,
                            0,
                            ref oo);

                object oVar = new MarshalAsAttribute(UnmanagedType.LPArray);
                //RS:: use list of params "UsedParams" to get right indexes in stead of "0"
                string[] units = { g_ICR2500_decl.MEASPARAM_VAL[0].Unit };
                oVar = units;
                g_ICR2500.dci_Data(
                    (Int32)e_Commands.DH_NFY_CHANGE,
                    (Int32)e_Commands.DH_MEAS_UNITS,
                    ref oVar);

                object pVar = null;
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_START, 0, ref pVar);
            }
            else
            {
                BandScopeVisible = !BandScopeVisible;
                pct_ON.Visible = false;
                pct_OFF.Visible = true;
                timerFFMDMM.Enabled = false;
                object pVar = null;
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref pVar);
            }
            SetFrequency();
        }

       
    }
}
