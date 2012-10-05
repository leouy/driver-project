using System;
using System.Collections.Generic;
using System.Text;

namespace g_ICR2500
{
    class g_ICR2500_icommanager
    {
        g_ICR2500_commmanager ComManager;

        static g_ICR2500_icommanager IcomManager;

        private g_ICR2500_icommanager()
        {
            if(g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
                ComManager = new g_ICR2500_commmanager();
        }

        public static g_ICR2500_icommanager GetInstance()
        {
            if (IcomManager == null)
            {
                IcomManager = new g_ICR2500_icommanager();
            }

            return IcomManager;
        }

        public void TurnOn()
        {
            if (g_ICR2500_decl.bPhysical)
            {
                ComManager.OpenPort();
                ComManager.WriteData(g_ICR2500_constants.On + g_ICR2500_constants.CRLF);
            }
        }

        public void TurnOff()
        {
            ComManager.WriteData(g_ICR2500_constants.Off + g_ICR2500_constants.CRLF);
            //ComManager.ClosePort();
        }

        public void AskFrequencyStrength()
        {
            ComManager.WriteData(g_ICR2500_constants.ReadSignalStrength + "?" + g_ICR2500_constants.CRLF);
        }

        public void SetFrequency(string frec, string filter, string mm)
        {
            ComManager.WriteData(g_ICR2500_constants.Frequency_1 + frec + mm + filter + g_ICR2500_constants.Frequency_2 + g_ICR2500_constants.CRLF);
            g_ICR2500_databag.GetInstance().CurrentFreq = frec;
        }

        public void SetVolume(string vol)
        {
            ComManager.WriteData(g_ICR2500_constants.Volume + vol + g_ICR2500_constants.CRLF);
        }

        public void SetSquelch(string sq)
        {
            ComManager.WriteData(g_ICR2500_constants.Squelch + sq + g_ICR2500_constants.CRLF);
        }

        public void SetBaudRate(string br)
        {
            ComManager.WriteData(g_ICR2500_constants.Baud + br + g_ICR2500_constants.CRLF);
        }

        public void AutoUpdate(bool on)
        {
            if (on)
                ComManager.WriteData(g_ICR2500_constants.AutoUpdate + "01" + g_ICR2500_constants.CRLF);
            else
                ComManager.WriteData(g_ICR2500_constants.AutoUpdate + "00" + g_ICR2500_constants.CRLF);
        }

        public void SetNoiseBlanker(bool on)
        {
            if (!on)
                ComManager.WriteData(g_ICR2500_constants.NoiseBlanker + "00" + g_ICR2500_constants.CRLF);
            else
                ComManager.WriteData(g_ICR2500_constants.NoiseBlanker + "01" + g_ICR2500_constants.CRLF);
        }

        public void SetAttenuator(bool on)
        {
            if (!on)
                ComManager.WriteData(g_ICR2500_constants.Attenuator + "00" + g_ICR2500_constants.CRLF);
            else
                ComManager.WriteData(g_ICR2500_constants.Attenuator + "01" + g_ICR2500_constants.CRLF);
        }

        public void SetAgc(bool on)
        {
            if (!on)
                ComManager.WriteData(g_ICR2500_constants.Agc + "00" + g_ICR2500_constants.CRLF);
            else
                ComManager.WriteData(g_ICR2500_constants.Agc + "01" + g_ICR2500_constants.CRLF);
        }

        public void StartSweepBandscope(string start, string end)
        {

            string sampleRate = "28";
            double startFreq = Double.Parse(start);
            double endFreq = Double.Parse(end);
            int result = 255;
            int stepInt = Convert.ToInt32((endFreq - startFreq) / result);
            g_ICR2500_databag.GetInstance().Step = stepInt.ToString();
            string step = stepInt.ToString();
            string numberOfSamples = g_ICR2500_constants.ConvertToHex(result);
            if (numberOfSamples.Length < 2) numberOfSamples = "0" + numberOfSamples;
            while (step.Length < 6)
                step = "0" + step;
            ComManager.WriteData(g_ICR2500_constants.Bandscope + numberOfSamples + sampleRate + "0100" + step);
        }

        public void EndSweepBandscope()
        {
            ComManager.WriteData(g_ICR2500_constants.Bandscope_Off + "00" + "00" + "0100" + "000000");
        }
    }
}
