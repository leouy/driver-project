using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.quinncurtis.chart2dnet;
using System.Threading;
using ExtDrv;
using System.Runtime.InteropServices;

namespace g_ICR2500
{
    public partial class g_ICR2500_scan : ChartView
    {
        #region DSCAN Properties

        ChartView ChartDSCAN;
        SimpleDataset DataSet;
        g_ICR2500_icommanager IcomManager;
        Font TheFont;
        public double[] YPoints { get; set; }
        public double[] XPoints { get; set; }
        int NumPoints;
        public double StartFrequency { get; set; }
        public double StopFrequency { get; set; }
        public bool BandScopeVisible_DSCAN;
        double StartFreqStart;
        static double CurrentFreq;
        static double Step;
        static double EndFreqEnd;

        #endregion

        #region Constructor / FormLoad
        public g_ICR2500_scan()
        {
            InitializeComponent();
            
            this.Enabled = false;
            NumPoints = 0;
            StartFrequency = 88000000;
            StopFrequency = 105000000;
            txt_LowdBm.Text = "-127";
            txt_HighdBm.Text = "0";
            InitializeChart();
        }
        private void g_ICR2500_scan_Load(object sender, EventArgs e)
        {
            IcomManager = g_ICR2500_icommanager.GetInstance();
        }

        #endregion Constructor / FormLoad

        #region ON/OFF
        public void DSCAN_Off()
        {
            pct_ON.Visible = false;
            pct_OFF.Visible = true;
            txt_startFreqMask.Enabled = true;
            txt_endFreqMask.Enabled = true;
            txt_Step.Enabled = true;
            txt_LowdBm.Enabled = true;
            txt_HighdBm.Enabled = true;
        }

        public void DSCAN_On()
        {
            pct_ON.Visible = true;
            pct_OFF.Visible = false;
            txt_startFreqMask.Enabled = false;
            txt_endFreqMask.Enabled = false;
            txt_Step.Enabled = false;
            txt_HighdBm.Enabled = false;
            txt_LowdBm.Enabled = false;
            Thread oThread = new Thread(new ThreadStart(BandScopeFunction_DSCAN));
            oThread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!oThread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread
            // to do some work:
            Thread.Sleep(1);
        }

        public void DSCAN_Remote_Off()
        {
            pct_ON.Visible = false;
            pct_OFF.Visible = true;
            txt_startFreqMask.Enabled = true;
            txt_endFreqMask.Enabled = true;
            txt_Step.Enabled = true;
            txt_LowdBm.Enabled = true;
            txt_HighdBm.Enabled = true;

            object pVar = null;
            g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref pVar);
        }

        public void DSCAN_Remote_On()
        {
            if (BandScopeVisible_DSCAN)
            {
                pct_ON.Visible = true;
                pct_OFF.Visible = false;
                txt_startFreqMask.Enabled = false;
                txt_endFreqMask.Enabled = false;
                txt_Step.Enabled = false;
                txt_HighdBm.Enabled = false;
                txt_LowdBm.Enabled = false;

                object fsVar = (object)g_ICR2500_databag.GetInstance().StartFreq;
                object feVar = (object)g_ICR2500_databag.GetInstance().EndFreq;
                object sVar = (object)g_ICR2500_databag.GetInstance().Step;

                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_START, 0, ref fsVar);
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_STOP, 0, ref feVar);
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_STEP, 0, ref sVar);

                object pVar = null;
                g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_START, 0, ref pVar);
            }
        }

        #endregion ON/OFF

        #region FormClicks/Values Changed
        private void btn_startBandScope_Click(object sender, EventArgs e)
        {
            BandscopeClickEvent();
        }

        public void BandscopeClickEvent()
        {
            string[] startFreqA = txt_startFreqMask.Text.Split('.');
            string[] endFreqA = txt_endFreqMask.Text.Split('.');
            double ValidateFreqStart = double.Parse(String.Join("", startFreqA));
            double ValidateFreqEnd = double.Parse(String.Join("", endFreqA));
            if ((ValidateFreqStart < 10000 || ValidateFreqStart > 3299999000) || (ValidateFreqEnd < 10000 || ValidateFreqEnd > 3299999000))
            {
                MessageBox.Show("La frecuencia no puede ser menor a 0.010 MHz ni mayor a 3299.999 MHz.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateFreqStart >= ValidateFreqEnd)
            {
                MessageBox.Show("La frecuencia final debe ser mayor a la frecuencia de inicio del barrido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] stepFreq = txt_Step.Text.Split('.');
            double ValidateFreqStep = double.Parse(String.Join("", stepFreq));
            if (ValidateFreqStep == 0)
            {
                MessageBox.Show("El paso del barrido no puede ser 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.CM)
            {
                IcomManager.TurnOn();

                g_ICR2500_databag.GetInstance().IcomOn = true;

                IcomManager.SetSquelch(g_ICR2500_databag.GetInstance().Squelch);
                //IcomManager.SetVolume("00");

                InitMeas();

                ChartDSCAN.ResetChartObjectList();
                InitializeChart();
                BandScopeVisible_DSCAN = !BandScopeVisible_DSCAN;
                g_ICR2500_databag.GetInstance().BandScopeScan = BandScopeVisible_DSCAN;

                if (BandScopeVisible_DSCAN)
                {
                    DSCAN_On();
                }
                else
                {
                    DSCAN_Off();
                }
            }
            else
            {
                g_ICR2500_databag.GetInstance().IMM = false;

                if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                {
                    BandScopeVisible_DSCAN = !BandScopeVisible_DSCAN;
                    if (BandScopeVisible_DSCAN)
                    {
                        g_ICR2500_databag.GetInstance().StartFreq = ValidateFreqStart.ToString();
                        g_ICR2500_databag.GetInstance().EndFreq = ValidateFreqEnd.ToString();
                        g_ICR2500_databag.GetInstance().Step = ValidateFreqStep.ToString();

                        object pVar3 = "Scan Level";
                        g_ICR2500.dci_SetRemote((int)e_Commands.DH_MEAS_SET, 0, ref pVar3);

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

                        InitMeas();
                        ChartDSCAN.ResetChartObjectList();
                        InitializeChart();
                        DSCAN_Remote_On();
                    }
                    else
                    {
                        DSCAN_Remote_Off();
                    }
                }
                else
                {
                    IcomManager.TurnOn();
                    g_ICR2500_databag.GetInstance().IcomOn = true;
                    IcomManager.SetSquelch(g_ICR2500_databag.GetInstance().Squelch);
                   // IcomManager.SetVolume("00");
                }

            }
        }

        #endregion FormClicks/Values Changed

        #region Initializers
        public void InitializeChart()
        {
            ChartDSCAN = this;
            int size = NumPoints + 1;
            XPoints = new double[NumPoints];
            YPoints = new double[NumPoints];


            for (int i = 0; i < NumPoints; i++)
            {

                if ((i + 1) == NumPoints)
                    XPoints[i] = EndFreqEnd;
                else
                    XPoints[i] = StartFrequency + ((i) * ((StopFrequency - StartFrequency) / NumPoints));
                YPoints[i] = Int32.Parse(txt_LowdBm.Text);
            }

            TheFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            DataSet = new SimpleDataset("Signal Strength", XPoints, YPoints);
            CartesianCoordinates pTransform1 = new CartesianCoordinates();
            pTransform1.AutoScale(DataSet, ChartObj.AUTOAXES_FAR, ChartObj.AUTOAXES_FAR);
            pTransform1.SetScaleStartY(Int32.Parse(txt_LowdBm.Text));
            pTransform1.SetScaleStopY(Int32.Parse(txt_HighdBm.Text));
            pTransform1.SetScaleStartX(StartFrequency);
            pTransform1.SetScaleStopX(StopFrequency);

            pTransform1.SetGraphBorderDiagonal(0.080, .375, .95, 0.80);
            Background graphbackground = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND,
                Color.LightGray);
            ChartDSCAN.AddChartObject(graphbackground);
            Background plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND,
                Color.Black);
            ChartDSCAN.AddChartObject(plotbackground);

            LinearAxis xAxis = new LinearAxis(pTransform1, ChartObj.X_AXIS);
            xAxis.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(xAxis);

            LinearAxis yAxis = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
            yAxis.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(yAxis);

            NumericAxisLabels xAxisLab = new NumericAxisLabels(xAxis);
            xAxisLab.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(xAxisLab);

            NumericAxisLabels yAxisLab = new NumericAxisLabels(yAxis);
            yAxisLab.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(yAxisLab);

            Grid ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
            ygrid.SetColor(Color.White);
            ygrid.SetLineWidth(1);
            ChartDSCAN.AddChartObject(ygrid);

            ChartAttribute attrib = new ChartAttribute(Color.Green, 0.2, DashStyle.Solid);
            SimpleLinePlot thePlot1 = new SimpleLinePlot(pTransform1, DataSet, attrib);
            ChartDSCAN.AddChartObject(thePlot1);

            Font theTitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            ChartTitle mainTitle = new ChartTitle(pTransform1, theTitleFont, "Scan IC-R2500");
            mainTitle.SetTitleType(ChartObj.CHART_HEADER);
            mainTitle.SetTitlePosition(ChartObj.CENTER_GRAPH);
            mainTitle.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(mainTitle);

            Font theFooterFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            ChartTitle footer = new ChartTitle(pTransform1, theFooterFont,
                "Signal Strength for the selected scope.");
            footer.SetTitleType(ChartObj.CHART_FOOTER);
            footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
            footer.SetTitleOffset(8);
            footer.SetColor(Color.Black);
            ChartDSCAN.AddChartObject(footer);
            ChartDSCAN.UpdateDraw();
        }//end InitializeChart()
        #endregion Initializers

        private void InitMeas()
        {
            string[] startFreqA = txt_startFreqMask.Text.Split('.');
            string[] endFreqA = txt_endFreqMask.Text.Split('.');
            StartFreqStart = double.Parse(String.Join("", startFreqA));
            CurrentFreq = StartFreqStart;
            EndFreqEnd = double.Parse(String.Join("", endFreqA));
            Step = Int32.Parse(txt_Step.Text);
            int cantMeas = Convert.ToInt32((EndFreqEnd - StartFreqStart) / Step);
            StartFrequency = StartFreqStart;
            StopFrequency = EndFreqEnd;
            //initialize chart arrays
            NumPoints = cantMeas;
            InitializeChart();
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
            ChartDSCAN.UpdateDraw();
            if (!chk_Continuous.Checked)
            {
                BandscopeClickEvent();
            }
         }

        [STAThread]
        public void UpdateDSCAN()
        {
            try
            {
                int y = Convert.ToInt32(g_ICR2500_databag.GetInstance().SignalStrength);
                int x = Convert.ToInt32(CurrentFreq);
                double aux1 = CurrentFreq - StartFreqStart;
                double cantMedidas = aux1 / Step;
                int cantStepSum = Convert.ToInt32(cantMedidas);
                x = cantStepSum;

                try
                {
                    YPoints[x] = y;

                    if (BandScopeVisible_DSCAN)
                    {
                        UpdateSpectrumChart();
                    }
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

        [STAThread]
        public void UpdateDSCANDMM(string signalS, int pos)
        {

            try
            {
                int y = Convert.ToInt32(signalS);
                try
                {
                    YPoints[pos] = y;

                    //if (BandScopeVisible_DSCAN)
                    //{
                    //    UpdateSpectrumChart();
                    //}
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
        [STAThread]
        public void UpdateSpectrumChartRemote()
        {
            if (BandScopeVisible_DSCAN)
            {
                UpdateSpectrumChart();
            }
        }




        private void BandScopeFunction_DSCAN()
        {
            StartFreqStart = CurrentFreq;

            while (BandScopeVisible_DSCAN)
            {
                if (CurrentFreq > EndFreqEnd)
                    CurrentFreq = StartFreqStart;//1 lap
                string currFreq = g_ICR2500_utils.ParseFullFrecuency(CurrentFreq.ToString());

                g_ICR2500_databag.GetInstance().CurrentFreq = currFreq;
                object pVar = (object)currFreq;

                if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                {
                    g_ICR2500.dci_SetRemote((int)e_Commands.DH_FREQ_FFM, 0, ref pVar);
                }
                else //CM
                {
                    var data = g_ICR2500_databag.GetInstance();
                    IcomManager.SetFrequency(currFreq, data.Filter, data.Mode);
                    IcomManager.AskFrequencyStrength();
                }



                g_ICR2500_databag.GetInstance().CurrentFreq = currFreq;
                //Calls Signal Update               

                Thread.Sleep(50);

                CurrentFreq += Step;

            }
        }

        public void ActivateTimer()
        {
            this.timerScan.Enabled = true;
        }
        public void DisableTimer()
        {
            this.timerScan.Enabled = false;
        }
        private void timerScan_Tick(object sender, EventArgs e)
        {
            //g_ICR2500.SendMeasResultToArgus();
            //this.timerScan.Enabled = false;
            g_ICR2500.SendMeasResultToArgus();
            bool IMM = g_ICR2500_databag.GetInstance().IMM;
            bool M = g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M;
            if (IMM || M)
                this.timerScan.Enabled = false; // for IMM one shot and DMM remote
        }

     
    }
}
