using System;
using System.Collections.Generic;
using System.Text;

namespace g_ICR2500
{
    class g_ICR2500_utils
    {
        public static string CalculateFrequencyStep(string currentValue, double step, bool up)
        {
            double currentFreq = Double.Parse(currentValue);
            if (up)
            {
                step = currentFreq + step;
                if (step > g_ICR2500_constants.MaxFreq)
                    step = g_ICR2500_constants.MaxFreq;
            }
            else
            {
                step = currentFreq - step;
                if (step < g_ICR2500_constants.MinFreq)
                    step = g_ICR2500_constants.MinFreq;
            }

            string valString = step.ToString();
            return ParseFullFrecuency(valString);
        }

        /// <summary>
        /// Returns full frequency
        /// </summary>
        /// <param name="freq"></param>
        /// <returns></returns>
        public static string ParseFullFrecuency(string freq)
        {
            while (freq.Length < 10)
            {
                freq = "0" + freq;
            }
            return freq;
        }

        /// <summary>
        /// Weights dec value for volume to hexa to talk with ICOM
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertIntToHex(double value)
        {
            double factor = (double)255 / 100;
            int ponderValue = Convert.ToInt32(value * factor);
            string hexValue = ponderValue.ToString("X");
            if (hexValue.Length == 1)
                hexValue = "0" + hexValue;
            return hexValue;
        }

        public static int ConvertHexToInt(string hexa)
        {
            double retorno = Convert.ToInt32(hexa, 16);
            int ret = Convert.ToInt32(retorno);
            return ret;
        }

        public static int ConvertSignalToDBM(int signalStrength)
        {
            if (signalStrength <= 144)
            {
                return Convert.ToInt32((signalStrength * 0.375) - 127);
            }
            else
                if (signalStrength > 144)
                {
                    return Convert.ToInt32((signalStrength * 0.625) - 163);
                }
            return 0;
        }
    }
}
