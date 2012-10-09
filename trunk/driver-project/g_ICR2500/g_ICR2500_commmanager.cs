using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Reflection;
using System.Configuration;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Threading;

namespace g_ICR2500
{
    class g_ICR2500_commmanager
    {
        private g_ICR2500_databag DataBag;

        const string Key = "ICR2500";

        #region Variables
        private SerialPort _comPort = new SerialPort();
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;

        #endregion

        #region Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public g_ICR2500_commmanager(string baud, string par, string sBits, string dBits, string name)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            //now add an event handler
            _comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            DataBag = g_ICR2500_databag.GetInstance();
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public g_ICR2500_commmanager()
        {
            try
            {
                string PortName = null;
                Dictionary<string, string> friendlyPorts = BuildPortNameHash(SerialPort.GetPortNames());
                if (g_ICR2500_decl.bPhysical)
                    PortName = friendlyPorts[Key];
                var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                _baudRate = appConfig.AppSettings.Settings["BaudRate"].Value;
                _parity = System.IO.Ports.Parity.None + "";
                _stopBits = System.IO.Ports.StopBits.One + "";
                _dataBits = appConfig.AppSettings.Settings["DataBits"].Value;
                if (PortName != null)
                {
                    _portName = PortName;
                }
                else
                {
                    _portName = appConfig.AppSettings.Settings["ComPort"].Value;
                }
                //add event handler
                if (g_ICR2500_decl.bPhysical)
                    _comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
                DataBag = g_ICR2500_databag.GetInstance();
            }
            catch (Exception)
            {
                
               //Nothing connected
            }
           
        }
        #endregion Manager Constructors

        #region ComPort Load
        static Dictionary<string, string> BuildPortNameHash(string[] portsToMap)
        {
            Dictionary<string, string> oReturnTable = new Dictionary<string, string>();
            if (g_ICR2500_decl.bPhysical)
                MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum\\USB", oReturnTable, portsToMap);
            return oReturnTable;
        }

        static void MineRegistryForPortName(string startKeyPath, Dictionary<string, string> targetMap, string[] portsToMap)
        {
            if (targetMap.Count >= portsToMap.Length)
                return;
            using (RegistryKey currentKey = Registry.LocalMachine)
            {
                try
                {
                    using (RegistryKey currentSubKey = currentKey.OpenSubKey(startKeyPath))
                    {
                        string[] currentSubkeys = currentSubKey.GetSubKeyNames();
                        foreach (string s in currentSubkeys)
                        {
                            if (s.Contains("IC-R2500") && startKeyPath != "SYSTEM\\CurrentControlSet\\Enum\\USB")
                            {
                                object portName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + startKeyPath + "\\" + s + "\\Device Parameters", "PortName", null);
                                targetMap[Key] = portName.ToString();
                            }
                            else
                            {
                                foreach (string strSubKey in currentSubkeys)
                                    MineRegistryForPortName(startKeyPath + "\\" + strSubKey, targetMap, portsToMap);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error accessing key '{0}'.. Skipping..", startKeyPath);
                }
            }
        }

        #endregion ComPort Load

        #region Delegate Method
        /// <summary>
        /// method that will be called when there is data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //read data waiting in the buffer
            string msg = _comPort.ReadExisting();
            //display the data to the user
            if (msg.Contains(g_ICR2500_constants.ReadSignalStrength))
            {
                SignalStrengthParse(msg);
            }
            //if (msg.Contains(g_ICR2500_constants.ReadBandScope))
            //{
            //    SweepParse(msg);
            //}
        }
        #endregion Delegate Method

        #region ComMethods
        public void WriteData(string msg)
        {
            if (g_ICR2500_decl.bPhysical)
            {
                try
                {
                    //first make sure the port is open
                    //if its not open then open it
                    if (!_comPort.IsOpen && g_ICR2500_databag.GetInstance().IcomOn) _comPort.Open();

                    //send the message to the port
                    msg += "\r\n";
                    _comPort.Write(msg);
                }
                catch (Exception ex)
                {
                    //Port not opened
                    //throw ex;
                }
            }
        }

        public bool ClosePort()
        {
            try
            {
                _comPort.DiscardInBuffer();
                _comPort.DiscardOutBuffer();
                _comPort.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (_comPort.IsOpen == true) _comPort.Close();

                //set the properties of our SerialPort Object
                _comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                _comPort.DataBits = int.Parse(_dataBits);    //DataBits
                _comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                _comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                _comPort.PortName = _portName;   //PortName
                //now open the port
                _comPort.Open();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region DataParsers
        private void SignalStrengthParse(string message)
        {
            try
            {
                string[] data;
                data = Regex.Split(message, "I1|NE1");
                foreach (var d in data)
                {
                    if (d.Length == 2)
                    {
                        if (g_ICR2500_databag.GetInstance().BandScope)
                        {

                            g_ICR2500_databag.GetInstance().UpdateSweep();
                        }
                        else
                        {
                            int IntValue = g_ICR2500_utils.ConvertHexToInt(d);
                            DataBag.SignalStrength = g_ICR2500_utils.ConvertSignalToDBM(IntValue).ToString();
                            if (DataBag.BandScopeScan)
                                DataBag.UpdateSweepDScan();
                        }
                    }
                    else if (d.Length == 4) //ask signal strenght alone
                    {
                        string aux = d.Substring(0, 2);
                        int IntValue = g_ICR2500_utils.ConvertHexToInt(aux);
                        DataBag.SignalStrength = g_ICR2500_utils.ConvertSignalToDBM(IntValue).ToString();
                        if (DataBag.BandScopeScan)
                            DataBag.UpdateSweepDScan();
                    }
                }
            }
            catch (Exception)
            {
                //TODO:
            }
        }

        //private void SweepParse(string message)
        //{
        //    string[] data;
        //    data = Regex.Split(message, "I1|NE1");
        //    int cont = 0;
        //    foreach (var d in data)
        //    {
        //        cont++;
        //        if (cont == 30)
        //            break;
        //        double startFreq = Double.Parse(g_ICR2500_databag.GetInstance().StartFreq);
        //        double endFreq = Double.Parse(g_ICR2500_databag.GetInstance().EndFreq);
        //        double stepInt = Double.Parse(g_ICR2500_databag.GetInstance().Step);
        //        string sampleFreq = string.Empty;
        //        int numPaqDec = 0;

        //        if (startFreq % 2 != 0)
        //            startFreq++;

        //        double currentFreq = (startFreq + endFreq) / 2;
        //        string selectFreq = currentFreq.ToString();

        //        while (selectFreq.Length < 10)
        //        {
        //            selectFreq = "0" + selectFreq;
        //        }

        //        if (d.Length == 34)
        //        {
        //            numPaqDec = Convert.ToInt32(d.Substring(0, 2), 16);
        //            for (int i = 4; i < 34; i += 2)
        //            {
        //                sampleFreq = (currentFreq + (numPaqDec + ((i / 2) - 2) - Convert.ToInt32("80", 16)) * stepInt).ToString();
        //                if (d.Substring(i - 2, 2) != "00" && currentFreq != 0)
        //                {
        //                    g_ICR2500_constants.FreqChartPoints it = new g_ICR2500_constants.FreqChartPoints(sampleFreq, g_ICR2500_utils.ConvertHexToInt(d.Substring(i - 2, 2)).ToString());
        //                    DataBag.Sweep.Add(it);
        //                }
        //            }
        //            if (DataBag.BandScope)
        //                DataBag.UpdateSweep();
        //        }
        //    }
        //}
        #endregion
    }
}
