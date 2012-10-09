using System;
using System.Collections.Generic;
using System.Text;
using ExtDrv;

namespace g_ICR2500
{
    class g_ICR2500_decl
    {
        //Constants of the device.
        public const string C_CLASSCODE = "CLASS_RECEIVER";
        public const string C_PHYNAME = "DCI_RCV";
        public const string C_VERSION = "ICR2500.1.0.0";

        //Default-Settings.
        public const string DEFAULT_DRVMODE = "(Physical)";
        public const string DEFAULT_LOGNAME = "ICR2500";

        public static string REG_PATH = "";						//Registry path for device-settings.
        public static string REG_DIR = "";
        public static bool SAVE_MEAS_RES = false;
        public static bool VALID_DATA_AVAILABLE = true;
        public static bool DEVICE_IS_WAITING_FOR_DATA = false;	  //Only C/S.
        public static double INVALID_VALUE = Double.MinValue;	  //Value for invalid data, only C/S.
        public static string RCVLOGNAME = "";
        public static bool MEAS_RUNNING = false;
        public static bool ACK_RCV = true;
        public static bool ACK_RCV_DMM = true;

        public static bool RES_AS_STRING = false;   //string=true, double=false;

        public static bool bPhysical = false;

        public const int MEAS_LEV = 0x0001;
        public const int MEAS_OFFS = 0x0002;
        public const int MEAS_MOD_AM = 0x0004;
        public const int MEAS_MOD_FM = 0x0008;
        public const int MEAS_PARALL = 0x00ff;

        public const int MEAS_SING = 0x1000;
        public const int MEAS_SCAN = 0x2000;
        public const int MEAS_DSCAN = 0x4000;
        public const int MEAS_FL_SCAN = 0x8000;
        public const int MEAS_PAGE = 0xf000;

        public static int STATIONMODE;
        //Station-modes.
        public enum UNIT
        {
            CM = 1,		//meas- and control-unit
            C,			//only control-unit (only C/S).
            M			//only meas-unit (only C/S).
        }

        public struct strRcvSettings
        {
            public string Version;
            public string ClassCode;
            public string Drvmode;
            public string Logname;
            public bool SetCTCSSEdit;
            public bool SetCTCSSMeas;
        }

        public class MEASPARAM
        {
            public MEASPARAM(string SName, string SUnit, UInt32 IMask)
            {
                Name = SName;
                Unit = SUnit;
                Mask = IMask;
            }
            public string Name { get; set; }
            public string Unit { get; set; }
            public UInt32 Mask { get; set; }
        }

        public class CODE
        {
            public CODE(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; set; }
            public string Value { get; set; }

        }

        public static CODE[] IF_BANDWITHS =
        {
            new CODE("3 KHz" , "00" ),
            new CODE("6 KHz" , "01" ),
            new CODE("15 KHz" , "02" ),
            new CODE("50 KHz" , "03" ),
            new CODE("230 KHz" , "04" )
        };

        public static CODE[] MEAS_MODES =
        {
            new CODE("LSB" , "00" ),
            new CODE("USB" , "01" ),
            new CODE("AM" , "02" ),
            new CODE("CW" , "03" ),
            new CODE("NFM" , "05" ),
            new CODE("WFM" , "06" )
           
        };


        //Available measurement parameters.
        public static MEASPARAM[] MEASPARAM_VAL =
		{
            new MEASPARAM("Level","dBm", MEAS_LEV | MEAS_SING),

            new MEASPARAM("Scan Level","dBm", MEAS_LEV | MEAS_SCAN),
            new MEASPARAM("DScan Level","dBm", MEAS_LEV | MEAS_DSCAN),

            new MEASPARAM("FL Scan Level","dBm", MEAS_LEV | MEAS_FL_SCAN),
            //RS:: for CTCSS
            //new MEASPARAM("Theo. Sub Audio Tone","Hz¹", MEAS_CTCSS | MEAS_SING),

		};
        //RS:: remember params to be measured
        public static UInt32 UsedParams = 0;
        //in dci_SetDevice DH_MEAS_RG  --> UsedParams |= MEAS_LEV;    internally if you need it: | MEAS_SING or MEAS_SCAN etc)
        //then use in dci_GetDevice DH_MEAS_CHECK to accept


        public static string[] MEASPARAMUNIT =
		{
			"Hz¹"
		};

        public static string[] IFBANDWIDTHS =
        {
            "3 KHz", "6 KHz", "15 KHz", "50 KHz", "230 KHz"
        };

        public static double[] POSSIBLEMTIME =
        {
            -1
        };

        public static double[] MIN_MAX_FREQUENCIES =
        {
            10000, 3299999000
        };

        public static string[] MEAS_MODE =
        {
           "LSB", "USB", "AM", "CW" , "NFM", "WFM"
         
        };

        public static string[] ATTN_OPTIONS =
        {
            "0 dB" , "20 dB"
        };

        public static strRcvSettings RcvSettings;
        public static strRcvSettings RcvSettingsRemote;

        //Interfaces.
        public static IDciDriver dci;
        public static IDciDriverNfy nfy;

        //Form.
        public static g_ICR2500_frm f = null;
        public static g_ICR2500_frmSet fSet = null;

        
    }
}
