using System;
using System.Collections.Generic;
using System.Text;

namespace g_ICR2500
{
    class g_ICR2500_constants
    {
        #region IcomConstants
        public const double MaxFreq = 9999999999;
        public const double MinFreq = 0;
        #endregion

        #region Writer Constants

        public const string CRLF = "/r/n";
        public const string Volume = "J40";
        public const string On = "H101";
        public const string Baud = "G1";
        public const string Off = "H100";
        public const string Frequency_1 = "K0";
        public const string Frequency_2 = "00";
        public const string Squelch = "J41";
        public const string AutoUpdate = "G3";
        public const string Bandscope = "ME00001";
        public const string Bandscope_Off = "ME00000";
        public const string NoiseBlanker = "J46";
        public const string Attenuator = "J47";
        public const string Agc = "J45";

        #endregion

        #region Reading Constants
        public const string ReadSignalStrength = "I1";
        public const string ReadBandScope = "NE1";
        #endregion

        #region UtilsMethods
        public static string ConvertToHex(int value)
        {
            string hexOutput = String.Format("{0:X}", value);
            return hexOutput;
        }
        #endregion

        public class FrequencyStep
        {
            public FrequencyStep(string name, double value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public double Value { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Filter
        {
            public Filter(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Span
        {
            public Span(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Mode
        {
            public Mode(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class FreqChartPoints
        {
            public FreqChartPoints(string freq, string ss)
            {
                Frequency = freq;
                Strength = ss;
            }
            public string Frequency { get; set; }
            public string Strength { get; set; }
        }

        public class FrequencyMeasure
        {
            public FrequencyMeasure(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
