using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ExtDrv;
using System.Reflection;
using Microsoft.Win32;
using System.Threading;

namespace g_ICR2500
{
    [ProgId("g_ICR2500.ICR2500"), Guid("AEDB0E12-CE8C-4730-93A3-BE1A2F481646")]
    public class g_ICR2500 : IDciDriver
    {
        private g_ICR2500_icommanager IcomManager;
        #region IDciDriver Members
        int k = 0;
        public void dci_GetDevice(int lCommand, int lType, ref object pVar, ref string pStr)
        {
            e_Commands eCommand;
            eCommand = (e_Commands)lCommand;
            switch (eCommand)
            {
                #region GeneralInstructions
                //////////
                case e_Commands.DH_PRIORITY:
                    break;

                //////////
                case e_Commands.DH_CLASS:
                    //Supply the device class of the driver
                    pVar = e_Commands.CLASS_RECEIVER;
                    break;

                //case e_Commands.DH_ATTRIBUTE:
                //    //Supply the set of available attributes (Optional)
                //    break;

                case e_Commands.DH_VERSION:
                    //Is shown in ARGUS in the properties dialog of the DCI-driver
                    pVar = g_ICR2500_decl.C_VERSION;
                    break;

                case e_Commands.DH_PHYNAME:
                    //Supply the physical name of the associated device
                    pVar = g_ICR2500_decl.C_PHYNAME;
                    break;

                case e_Commands.DH_ICON:

                    //Windows handle of the Icon to be shown in the Visualizer. (Optional)

                    pVar = g_ICR2500_decl.f.Icon.Handle;
                    break;

                //case e_Commands.DH_SETT:
                //    //Deposit byte array of the actual settings of the device. (Optional)
                //    //pVar = GetBithaufen((e_Commands)lType);
                //    break;

                //case e_Commands.DH_SETT_USER:
                //    //Settings dependent on the ARGUS user as byte array. Deposited or recovered on user change. (Optional)
                //    //pVar = GetBithaufen((e_Commands)lType);
                //    break;

                case e_Commands.DH_SETT_SUPPL:
                    //Additional string. Freely definable by the user, only for external device drivers. (Optional)
                    //pVar = GetBithaufen((e_Commands)lType);
                    break;

                #endregion

                #region ControlInstructionsForMeas

                case e_Commands.DH_MEAS_RG:
                    //The driver supplies the list of possible measurement parameters (<Param1>, Scan <Param2>, FLScan <Param3> etc.)
                    object oVar_DH_MEAS_RG = new MarshalAsAttribute(UnmanagedType.LPArray);
                    string[] ParamsNames = new string[g_ICR2500_decl.MEASPARAM_VAL.Length];
                    //foreach (var m in g_ICR2500_decl.MEASPARAM_VAL)
                    for (int i = 0; i < g_ICR2500_decl.MEASPARAM_VAL.Length; i++)
                    {
                        ParamsNames[i] = g_ICR2500_decl.MEASPARAM_VAL[i].Name;
                    }
                    oVar_DH_MEAS_RG = ParamsNames;
                    pVar = oVar_DH_MEAS_RG;
                    break;

                case e_Commands.DH_MEAS_CHECK:
                    //Return bit mask of the accepted measurement parameters
                    //object oVar_1 = new MarshalAsAttribute(UnmanagedType.R8);
                    //int[] ParamsMask = new int[g_ICR2500_decl.MEASPARAM_VAL.Length];
                    //                  int IntMask = 0;
                    UInt32 uiMask = 0;
                    UInt32 shift = 1;
                    //foreach (var m in g_ICR2500_decl.MEASPARAM_VAL)
                    //RS:: compare to saved list of selected meas. params in DH_MEAS_RG dci_SetDevice
                    for (int i = 0; i < g_ICR2500_decl.MEASPARAM_VAL.Length; i++)
                    {
                        if ((g_ICR2500_decl.UsedParams & g_ICR2500_decl.MEAS_PAGE & g_ICR2500_decl.MEASPARAM_VAL[i].Mask) != 0)
                            if ((g_ICR2500_decl.UsedParams & g_ICR2500_decl.MEAS_PARALL & g_ICR2500_decl.MEASPARAM_VAL[i].Mask) != 0)
                            {
                                uiMask |= shift;
                                shift <<= 1;
                            }
                    }
                    //oVar = ParamsMask;
                    pVar = uiMask;
                    break;

                #endregion

                #region ReceiverCommands

                case e_Commands.DH_IFBW_RG:
                    //Possible IF-Bandwidths in Hz (Optional)
                    object oVar_DH_IFBW_RG = new MarshalAsAttribute(UnmanagedType.BStr);
                    oVar_DH_IFBW_RG = g_ICR2500_decl.IFBANDWIDTHS;
                    pVar = oVar_DH_IFBW_RG;
                    break;

                case e_Commands.DH_DETECT_RG:
                    //The device specific options of the detector (Optional)
                    throw (new NotImplementedException());
                //break;

                case e_Commands.DH_DEMOD_RG:
                    //The device specific options of the demodulator (Optional)
                    try
                    {
                        object oVar_DH_DEMOD_RG = new MarshalAsAttribute(UnmanagedType.LPArray);
                        oVar_DH_DEMOD_RG = g_ICR2500_decl.MEAS_MODE;
                        pVar = oVar_DH_DEMOD_RG;

                    }
                    catch (Exception)
                    {

                        //todo: sacar esto
                    }

                    break;

                case e_Commands.DH_RFATTN_RG:
                    //The device specific options of the attenuator (Optional)
                    object oVar_DH_RFATTN_RG = new MarshalAsAttribute(UnmanagedType.LPArray);
                    oVar_DH_RFATTN_RG = g_ICR2500_decl.ATTN_OPTIONS;
                    pVar = oVar_DH_RFATTN_RG;
                    break;

                case e_Commands.DH_FREQ_RG:
                    //Min, Max frequencies in Hz (Optional)
                    object oVar_DH_FREQ_RG = new MarshalAsAttribute(UnmanagedType.LPArray);
                    oVar_DH_FREQ_RG = g_ICR2500_decl.MIN_MAX_FREQUENCIES;
                    pVar = oVar_DH_FREQ_RG;
                    break;

                case e_Commands.DH_FREQ_FFM:
                    //Selected frequency in Hz (Optional)
                    object oVar_DH_FREQ_FFM = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_FREQ_FFM = double.Parse(g_ICR2500_databag.GetInstance().CurrentFreq);
                    pVar = oVar_DH_FREQ_FFM;
                    break;

                case e_Commands.DH_FREQ_START:
                    //Start frequency in Hz (Optional)
                    object oVar_DH_FREQ_START = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_FREQ_START = double.Parse(g_ICR2500_databag.GetInstance().StartFreq);
                    pVar = oVar_DH_FREQ_START;
                    break;

                case e_Commands.DH_FREQ_STOP:
                    //Stop frequency in Hz (Optional)
                    object oVar_DH_FREQ_STOP = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_FREQ_STOP = double.Parse(g_ICR2500_databag.GetInstance().EndFreq);
                    pVar = oVar_DH_FREQ_STOP;
                    break;

                case e_Commands.DH_FREQ_STEP:
                    //Step width frequency in Hz (Optional)
                    object oVar_DH_FREQ_STEP = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_FREQ_STEP = double.Parse(g_ICR2500_databag.GetInstance().Step);
                    pVar = oVar_DH_FREQ_STEP;
                    break;

                //case e_Commands.DH_IF_FREQ:
                //    //Ask IF-frequency of the receiver
                //    break;

                case e_Commands.DH_MTIME_RG:
                    //Possible measurement times in s. -1 for Default, -2 for Auto
                    object oVar_DH_MTIME_RG = new MarshalAsAttribute(UnmanagedType.LPArray);
                    oVar_DH_MTIME_RG = g_ICR2500_decl.POSSIBLEMTIME;
                    pVar = oVar_DH_MTIME_RG;
                    break;

                case e_Commands.DH_MTIME:
                    //Selected value for measurement time in s. -1 for Default, -2 for Auto
                    double ret = -1;
                    pVar = ret;
                    break;

                #endregion

                default:
                    throw new NotImplementedException();
            }//End of switch
        }

        static bool stop = false;

        public void dci_SetDevice(int lCommand, int lType, ref object pVar, ref string pStr)
        {
            e_Commands eCommand;
            eCommand = (e_Commands)lCommand;

            switch (eCommand)
            {
                #region GeneralInstructions
                case e_Commands.DH_INIT:
                    //Start and initialize the device driver. Pass the path for entry in the Registry
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_INIT, 0, ref pVar);
                    }
                    //else
                    //{
                    if (g_ICR2500_decl.f == null)
                        g_ICR2500_decl.f = new g_ICR2500_frm();
                    if (g_ICR2500_decl.fSet == null)
                        g_ICR2500_decl.fSet = new g_ICR2500_frmSet();
                    g_ICR2500_databag.GetInstance().Form = g_ICR2500_decl.f;
                    // g_ICR2500_decl.f.Show();
                    //Save registry path.
                    BuildRegPath((string)pVar);
                    //Load Settings.
                    LoadSettingsFromRegistry();
                    //}
                    break;

                case e_Commands.DH_INIT_NFY:
                    //Passes the pointer to the Notify Interface
                    g_ICR2500_decl.nfy = (IDciDriverNfy)pVar;
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_INIT_NFY, 0, ref pVar);
                    }

                    break;

                case e_Commands.DH_DEINIT:
                    //Deinitialize the device driver and free the Notify Interface
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_DEINIT, 0, ref pVar);
                    }
                    else
                    {
                        g_ICR2500_decl.f.FFMTab.Dispose();
                        g_ICR2500_decl.f.DSCANTab.Dispose();
                        g_ICR2500_decl.f.FFMTab = null;
                        g_ICR2500_decl.f.DSCANTab = null;
                        g_ICR2500_decl.f.Close();
                        g_ICR2500_decl.f.Dispose();
                        g_ICR2500_decl.f = null;
                    }
                    break;

                case e_Commands.DH_LOGNAME:
                    //Logical name used in ARGUS (Optional)
                    g_ICR2500_decl.RcvSettings.Logname = (string)pVar;
                    //Set dialog-caption.
                    g_ICR2500_decl.f.Text = g_ICR2500_decl.RcvSettings.Logname + " " + g_ICR2500_decl.RcvSettings.Drvmode;
                    break;

                case e_Commands.DH_DRVMODE:
                    //Switches between physical (TRUE) and virtual mode (FALSE) (Optional)
                    g_ICR2500_decl.bPhysical = System.Convert.ToBoolean(pVar);
                    if (g_ICR2500_decl.bPhysical == false)
                    {
                        //Virtual mode.
                        g_ICR2500_decl.RcvSettings.Drvmode = "(Virtual)";
                        g_ICR2500_decl.f.Text = g_ICR2500_decl.RcvSettings.Logname + " " + g_ICR2500_decl.RcvSettings.Drvmode;
                    }
                    else
                    {
                        //Physical mode is not available.
                        g_ICR2500_decl.RcvSettings.Drvmode = "(Physical)";
                        g_ICR2500_decl.f.Text = g_ICR2500_decl.RcvSettings.Logname + " " + g_ICR2500_decl.RcvSettings.Drvmode;
                    }
                    break;

                case e_Commands.DH_LANGUAGE:
                    //Sets the language (Optional)
                    break;

                case e_Commands.DH_MENU:
                    //Open the dialog to edit parameter settings for the device. Specific to the considered device. (Optional)
                    if (g_ICR2500_decl.f == null)
                        g_ICR2500_decl.f = new g_ICR2500_frm();
                    //Show dialog.
                    g_ICR2500_decl.f.Text = g_ICR2500_decl.RcvSettings.Logname + " " + g_ICR2500_decl.RcvSettings.Drvmode;
                    g_ICR2500_decl.f.Show();
                    pVar = g_ICR2500_decl.f.Handle;

                    break;

                case e_Commands.DH_SETT:
                    //Recover previously deposited byte array of settings (Optional)     

                    // object oVar2 = new MarshalAsAttribute(UnmanagedType.BStr);
                    //oVar2 = pVar;
                    //string Param2 = (string)oVar2;

                    ////RS:: remember selected meas. params and return in accepted params in DH_MEAS_CHECK
                    //g_ICR2500_decl.UsedParams = 0;

                    //for (int j = 0; j < g_ICR2500_decl.MEASPARAM_VAL.Length; j++)
                    //{
                    //    if (Param2 == g_ICR2500_decl.MEASPARAM_VAL[j].Name)
                    //        g_ICR2500_decl.UsedParams |= g_ICR2500_decl.MEASPARAM_VAL[j].Mask;
                    //}

                    //g_ICR2500_databag.GetInstance().M_Type = Param2;

                    break;

                case e_Commands.DH_SETT_USER:
                    //Settings dependent on the ARGUS user as byte array. Deposited or recovered on user change (Optional)   
                    break;

                case e_Commands.DH_SETT_SUPPL:
                    //Additional string. Freely definable by the user, only for external device drivers (Optional)   
                    object oVar2 = new MarshalAsAttribute(UnmanagedType.BStr);
                    oVar2 = pVar;
                    string Param2 = (string)oVar2;

                    //RS:: remember selected meas. params and return in accepted params in DH_MEAS_CHECK
                    g_ICR2500_decl.UsedParams = 0;

                    for (int j = 0; j < g_ICR2500_decl.MEASPARAM_VAL.Length; j++)
                    {
                        if (Param2 == g_ICR2500_decl.MEASPARAM_VAL[j].Name)
                            g_ICR2500_decl.UsedParams |= g_ICR2500_decl.MEASPARAM_VAL[j].Mask;
                    }

                    g_ICR2500_databag.GetInstance().M_Type = Param2;

                    break;

                case e_Commands.DH_STATIONMODE:
                    //Device driver is connected to a measurement unit viz. a control unit.
                    e_Commands eVar;
                    eVar = (e_Commands)pVar;
                    if (eVar == e_Commands.DH_M_UNIT)
                    {
                        //Device is meas-unit.
                        g_ICR2500_decl.STATIONMODE = (int)g_ICR2500_decl.UNIT.M;
                    }
                    else if (eVar == e_Commands.DH_C_UNIT)
                    {
                        //Device is control-unit.
                        g_ICR2500_decl.STATIONMODE = (int)g_ICR2500_decl.UNIT.C;
                        //Ask remote unit for settings.
                        dci_SetRemote((Int32)e_Commands.DH_SEND_SETTINGS_REQ, 0, ref pVar);
                    }
                    else if (eVar == e_Commands.DH_CM_UNIT)
                    {
                        //Device is meas- and control-unit.
                        g_ICR2500_decl.STATIONMODE = (int)g_ICR2500_decl.UNIT.CM;
                    }
                    break;

                case e_Commands.DH_PROPSETT:
                    //Open the dialog for initialization settings (Optional)
                    //decl.fSet.ShowDialog();
                    //pVar = decl.bDialogDirty;
                    break;
                #endregion

                #region ControlInstructionsForMeas
                case e_Commands.DH_PRIORITY:
                    //Indicates that it is an instruction referring to the control of the measurement priority for the considered device driver.
                    //UInt32 iPrio = (UInt32)pVar;
                    //if (iPrio > (UInt32)e_Commands.DH_PRIO_MEAS && (g_ICR2500_decl.MEAS_RUNNING))
                    //{
                    //    //Stop measurement.
                    //    g_ICR2500_decl.f.StopRecord();
                    //    if ((g_ICR2500_decl.UNIT)g_ICR2500_decl.STATIONMODE == g_ICR2500_decl.UNIT.C)
                    //    {
                    //        object oNull = null;
                    //        dci_SetRemote(g_ICR2500_decl.DH_REC_STOP, 0, ref oNull);
                    //    }
                    //    else
                    //    {
                    //        //Send to physical device.
                    //    }
                    //}
                    //if (iPrio > (UInt32)e_Commands.DH_PRIO_MEAS)
                    //{
                    //    g_ICR2500_decl.f.DisableControls();
                    //    g_ICR2500_decl.f.EnableOKCancel();
                    //}
                    //else
                    //{
                    //    g_ICR2500_decl.f.EnableControls();
                    //}
                    break;

                case e_Commands.DH_MEAS_RG:
                    //Contains the list of selected parameters for measurement
                    object oVar1 = new MarshalAsAttribute(UnmanagedType.BStr);
                    oVar1 = pVar;
                    string[] Param = (string[])oVar1;
                    //RS:: remember selected meas. params and return in accepted params in DH_MEAS_CHECK
                    g_ICR2500_decl.UsedParams = 0;
                    for (int i = 0; i < Param.Length; i++)
                    {
                        for (int j = 0; j < g_ICR2500_decl.MEASPARAM_VAL.Length; j++)
                        {
                            if (Param[i] == g_ICR2500_decl.MEASPARAM_VAL[j].Name)
                                g_ICR2500_decl.UsedParams |= g_ICR2500_decl.MEASPARAM_VAL[j].Mask;
                        }
                    }
                    g_ICR2500_databag.GetInstance().M_Type = Param[0];

                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        object sVar = Param[0];
                        dci_SetRemote((int)e_Commands.DH_SETT_SUPPL, 0, ref sVar);
                        //dci_SetRemote((int)e_Commands.DH_SETT, (int)e_Commands.MEAS, ref sVar);
                    }

                    break;


                case e_Commands.DH_MEAS_SET:
                    //The driver sends the actual settings to the device. The Measurement is prepared but not yet started.
                    string measType = (string)pVar;
                    switch (measType)
                    {
                        case "Level":
                            {
                                g_ICR2500_decl.UsedParams = 4097;
                                g_ICR2500_databag.GetInstance().M_Type = "Level";
                                g_ICR2500_decl.f.FFMTab.ActivateTimer();
                                g_ICR2500_databag.GetInstance().IMM = false;
                                break;
                            }
                        case "Scan Level":
                            {
                                g_ICR2500_decl.UsedParams = 8193; //TODO SCAN LEVEL
                                g_ICR2500_databag.GetInstance().M_Type = "Scan Level";
                                //g_ICR2500_decl.f.DSCANTab.ActivateTimer();
                                g_ICR2500_databag.GetInstance().IMM = false;
                                break;
                            }
                        default:
                            break;
                    }
                    break;

                case e_Commands.DH_MEAS_START:
                    stop = false;
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        object oo = null;

                        dci_Data((Int32)e_Commands.DH_NFY_CHANGE,
                                    0,
                                    ref oo);

                        object oVar = new MarshalAsAttribute(UnmanagedType.LPArray);
                        //RS:: use list of params "UsedParams" to get right indexes in stead of "0"
                        string[] units = { g_ICR2500_decl.MEASPARAM_VAL[0].Unit };
                        oVar = units;
                        dci_Data(
                            (Int32)e_Commands.DH_NFY_CHANGE,
                            (Int32)e_Commands.DH_MEAS_UNITS,
                            ref oVar);

                        dci_SetRemote((int)e_Commands.DH_MEAS_START, 0, ref pVar);
                    }
                    else
                    {
                        initMeas();
                        //RS: use doubles, string is also possible 
                        object oo = null;

                        dci_Data((Int32)e_Commands.DH_NFY_CHANGE,
                                    0,
                                    ref oo);

                        object oVar = new MarshalAsAttribute(UnmanagedType.LPArray);
                        //RS:: use list of params "UsedParams" to get right indexes in stead of "0"
                        string[] units = { g_ICR2500_decl.MEASPARAM_VAL[0].Unit };
                        oVar = units;
                        dci_Data(
                            (Int32)e_Commands.DH_NFY_CHANGE,
                            (Int32)e_Commands.DH_MEAS_UNITS,
                            ref oVar);

                        //The driver sends the actual settings to the device. The measurement is started. Data can be sent to ARGUS.
                        // Start IMM-/AMM-measurement.
                        if (g_ICR2500_decl.bPhysical)
                        {
                            if (g_ICR2500_decl.f == null)
                                g_ICR2500_decl.f = new g_ICR2500_frm();
                            if (g_ICR2500_decl.fSet == null)
                                g_ICR2500_decl.fSet = new g_ICR2500_frmSet();
                            g_ICR2500_databag.GetInstance().Form = g_ICR2500_decl.f;
                            UInt32 measmode = g_ICR2500_decl.UsedParams & g_ICR2500_decl.MEAS_PAGE;
                            switch (measmode)
                            {
                                case g_ICR2500_decl.MEAS_SING:
                                    g_ICR2500_decl.f.FFMTab.ActivateTimer();
                                    break;

                                case g_ICR2500_decl.MEAS_SCAN:
                                    g_ICR2500_decl.f.DSCANTab.ActivateTimer();
                                    break;
                            }
                            StartMeas(); //RS:: get data from device
                        }
                        else
                        {
                            // RS:: use timer to yield control and avoid closed loop with IMM
                            // in physical mode it should work automatically because of th e callback (delegate)

                            //if (g_ICR2500_databag.GetInstance().M_Type == "Level")
                            // R&S cases for virtual mode are placed in SendMeasResultToArgus();

                            break;
                        }

                        //RS:: put some dummy result
                        // over timer in SendMeasResultToArgus();

                        ////Infos about result type and result unit.
                    }
                    break;

                case e_Commands.DH_MEAS_STOP:
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_MEAS_STOP, 0, ref pVar);
                    }
                    else
                    {
                        Logger.LogEx("DH_MEAS_STOP");
                        stop = true;
                        g_ICR2500_databag.GetInstance().scanMeas = null;
                        TurnOff();
                        if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.M)
                        {
                            g_ICR2500_decl.f.FFMTab.Dispose();
                            g_ICR2500_decl.f.DSCANTab.Dispose();
                            g_ICR2500_decl.f.FFMTab = null;
                            g_ICR2500_decl.f.DSCANTab = null;
                            //g_ICR2500_decl.f.DestroyHandle();
                            g_ICR2500_decl.f.Dispose();
                            g_ICR2500_decl.f = null;
                        }
                        else
                        {
                            g_ICR2500_decl.f.FFMTab.DisableTimer();
                            g_ICR2500_decl.f.DSCANTab.DisableTimer();

                        }
                        //End measurement    

                    }
                    break;

                case e_Commands.DH_MEAS_ACK:
                    {
                        lock ((object)g_ICR2500_decl.ACK_RCV)
                        {
                            g_ICR2500_decl.ACK_RCV = true;
                        }

                    }
                    break;

                case e_Commands.DH_MEAS_DATA:
                    //Arrival of data from the sibling device driver connected to the remote measurement unit (Optional)
                    //Data from meas unit (only CS IMM).
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {

                        dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                  (Int32)e_Commands.NFY_RESULT,
                                  ref pVar);
                        object x = null;
                        dci_SetRemote((Int32)e_Commands.DH_MEAS_ACK, 0, ref x);

                        if (g_ICR2500_databag.GetInstance().M_Type == "Level")
                        {
                            //Update databag
                            double[,] dMeasResult = (double[,])pVar;
                            g_ICR2500_databag.GetInstance().CurrentFreq = dMeasResult[0, 0].ToString();	//Frequency
                            g_ICR2500_databag.GetInstance().SignalStrength = dMeasResult[1, 0].ToString();

                            bool IMM = g_ICR2500_databag.GetInstance().IMM; //IMM = existe form
                            if (!IMM)
                            {
                                //Pinto grafica local.
                                g_ICR2500_decl.f.FFMTab.UpdateSignalStrength();

                            }
                        }
                        else if (g_ICR2500_databag.GetInstance().M_Type == "Scan Level")
                        {
                            //Pintar grafica scan grande
                            var data = g_ICR2500_databag.GetInstance();


                            double[,] dMeasResult = (double[,])pVar;
                            int iSize = dMeasResult.Length;

                            data.scanMeas = new g_ICR2500_constants.FrequencyMeasure[iSize / 2];
                            int f = 0;
                            int j = 0, i = 0;

                            for (int k = 0; k < iSize / 2; k++)
                            {
                                j = k % 2;
                                data.scanMeas[k] = new g_ICR2500_constants.FrequencyMeasure("", "");
                                data.scanMeas[k].Name = dMeasResult[j, i].ToString();
                                if (j == 1) i++;
                                j++;
                            }
                            int l = 0;
                            for (int k = iSize / 2; k < iSize; k++)
                            {
                                j = k % 2;
                                if (!String.IsNullOrEmpty(dMeasResult[j, i].ToString()))
                                {
                                    data.scanMeas[l].Value = dMeasResult[j, i].ToString();
                                    g_ICR2500_decl.f.DSCANTab.UpdateDSCANDMM(data.scanMeas[l].Value, l);
                                }
                                else
                                {
                                    data.scanMeas[l].Value = "-127";
                                    g_ICR2500_decl.f.DSCANTab.UpdateDSCANDMM(data.scanMeas[l].Value, l);
                                }

                                if (j == 1) i++;
                                j++;
                                l++;
                            }
                            g_ICR2500_decl.f.DSCANTab.UpdateSpectrumChartRemote();
                            g_ICR2500_decl.f.DSCANTab.DSCAN_Remote_On();
                        }

                    }

                    break;

                #endregion

                #region ReceiverCommands
                case e_Commands.DH_IFBW:
                    //Selected IF-Bandwidth in Hz (Optional)
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_IFBW, 0, ref pVar);
                    }

                    object oVar_DH_IFBW = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_IFBW = pVar;
                    foreach (var code in g_ICR2500_decl.IF_BANDWITHS)
                    {
                        if (code.Name == oVar_DH_IFBW.ToString())
                        {
                            g_ICR2500_databag.GetInstance().Filter = code.Value;
                            break;
                        }
                    }

                    string FilterVal = g_ICR2500_databag.GetInstance().Filter;
                    string ModeVal = g_ICR2500_databag.GetInstance().Mode;
                    string FreqVal = g_ICR2500_databag.GetInstance().CurrentFreq;
                    if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
                    {
                        if (IcomManager == null)
                            IcomManager = g_ICR2500_icommanager.GetInstance();

                        if (!string.IsNullOrEmpty(FilterVal) && !string.IsNullOrEmpty(ModeVal) && !string.IsNullOrEmpty(FreqVal))
                            IcomManager.SetFrequency(g_ICR2500_utils.ParseFullFrecuency(FreqVal), FilterVal, ModeVal);
                    }


                    break;

                case e_Commands.DH_DETECT:
                    //The option selected for the detector (Optional)
                    break;

                case e_Commands.DH_DEMOD:
                    //The option selected for the demodulator (Optional)
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_DEMOD, 0, ref pVar);
                    }

                    object oVar_DH_DEMOD = new MarshalAsAttribute(UnmanagedType.R8);
                    oVar_DH_DEMOD = pVar;
                    foreach (var mode in g_ICR2500_decl.MEAS_MODES)
                    {
                        if (mode.Name == oVar_DH_DEMOD.ToString())
                        {
                            g_ICR2500_databag.GetInstance().Mode = mode.Value;
                            break;
                        }
                    }
                    FilterVal = g_ICR2500_databag.GetInstance().Filter;
                    ModeVal = g_ICR2500_databag.GetInstance().Mode;
                    FreqVal = g_ICR2500_databag.GetInstance().CurrentFreq;
                    if (g_ICR2500_decl.STATIONMODE != (int)g_ICR2500_decl.UNIT.C)
                    {
                        if (IcomManager == null)
                            IcomManager = g_ICR2500_icommanager.GetInstance();

                        if (!string.IsNullOrEmpty(FilterVal) && !string.IsNullOrEmpty(ModeVal) && !string.IsNullOrEmpty(FreqVal))
                            IcomManager.SetFrequency(g_ICR2500_utils.ParseFullFrecuency(FreqVal), FilterVal, ModeVal);
                    }

                    break;

                case e_Commands.DH_FREQ_FFM:
                    //Selected frequency in Hz (Optional)
                    g_ICR2500_databag.GetInstance().CurrentFreq = pVar.ToString();
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_FREQ_FFM, 0, ref pVar);
                    }
                    else
                    {

                        FilterVal = g_ICR2500_databag.GetInstance().Filter;
                        ModeVal = g_ICR2500_databag.GetInstance().Mode;
                        FreqVal = g_ICR2500_databag.GetInstance().CurrentFreq;
                        if (!string.IsNullOrEmpty(FilterVal) && !string.IsNullOrEmpty(ModeVal) && !string.IsNullOrEmpty(FreqVal))
                        {
                            if (IcomManager == null)
                                IcomManager = g_ICR2500_icommanager.GetInstance();

                            IcomManager.SetBaudRate("05");
                            IcomManager.SetFrequency(g_ICR2500_utils.ParseFullFrecuency(FreqVal), FilterVal, ModeVal);


                        }
                        if (g_ICR2500_databag.GetInstance().BandScopeScan)
                        {
                            if (IcomManager == null)
                                IcomManager = g_ICR2500_icommanager.GetInstance();
                            IcomManager.AskFrequencyStrength();
                        }
                    }

                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.M)
                    {
                        IcomManager.SetVolume("10");
                        IcomManager.SetSquelch("00");
                    }
                    break;

                case e_Commands.DH_FREQ_START:
                    //Start frequency in Hz (Optional)
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_FREQ_START, 0, ref pVar);
                    }

                    g_ICR2500_databag.GetInstance().StartFreq = pVar.ToString();

                    break;

                case e_Commands.DH_FREQ_STOP:
                    //Stop frequency in Hz (Optional)
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_FREQ_STOP, 0, ref pVar);
                    }

                    g_ICR2500_databag.GetInstance().EndFreq = pVar.ToString();

                    break;

                case e_Commands.DH_FREQ_STEP:
                    //Step width frequency in Hz (Optional)
                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_FREQ_STEP, 0, ref pVar);
                    }

                    g_ICR2500_databag.GetInstance().Step = pVar.ToString();

                    break;

                case e_Commands.DH_FREQ_LIST:
                    //Frequency list in Hz is sent to the device driver (Optional)
                    break;

                case e_Commands.DH_TRANS:
                    //Transducer table in Hz <> Value (Unit as set with next instruction) is sent to the device driver. (k-factor) (Optional)
                    break;

                case e_Commands.DH_TRANS_UNIT_Y:
                    //Unit for Y-values of the transducer table. UNIT_X for frequency is always Hz (Optional)
                    break;

                case e_Commands.DH_MTIME:
                    //Selected value for measurement time in s. -1 for Default, -2 for Auto
                    break;

                case e_Commands.DH_RESET:
                    //Reset device for new measurement
                    break;
                case e_Commands.DH_RFATTN:

                    bool turnOn = pVar.ToString() == "20 dB";
                    g_ICR2500_databag.GetInstance().Attenuator = turnOn;

                    if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                    {
                        dci_SetRemote((int)e_Commands.DH_RFATTN, 0, ref pVar);
                    }
                    else
                    {
                        if (IcomManager == null)
                            IcomManager = g_ICR2500_icommanager.GetInstance();

                        IcomManager.SetAttenuator(turnOn);
                    }

                    break;

                #endregion

                default:
                    throw (new NotImplementedException());
            }//End of switch
        }



        private void initMeas()
        {
            stop = false;
            if (IcomManager == null)
                IcomManager = g_ICR2500_icommanager.GetInstance();
            if (!g_ICR2500_databag.GetInstance().IcomOn)
            {
                TurnOn();
                g_ICR2500_databag.GetInstance().IcomOn = true;
            }
            var data = g_ICR2500_databag.GetInstance();
            switch (data.M_Type)
            {
                case "Level":
                    IcomManager.AutoUpdate(true);
                    //RS:: send units
                    var freq = g_ICR2500_databag.GetInstance().CurrentFreq;

                    freq = g_ICR2500_utils.ParseFullFrecuency(freq);
                    var filter = data.Filter;
                    var mode = data.Mode;
                    var att = data.Attenuator;


                    IcomManager.SetFrequency(freq, filter, mode);
                    IcomManager.SetBaudRate("05");
                    //IcomManager.SetVolume("00");
                    //IcomManager.SetSquelch("00");
                    IcomManager.SetAttenuator(att);

                    break;

                case "Scan Level":
                    IcomManager.SetBaudRate("05");
                    //IcomManager.SetVolume("00");
                    //IcomManager.SetSquelch("00");
                    data.CurrentFreq = data.StartFreq;
                    g_ICR2500_decl.ACK_RCV = true;
                    Thread bandscope = new Thread(BandScopeFunction_DSCAN);
                    data.BandScopeScan = true;
                    Logger.LogEx("Nuevo hilo.");
                    bandscope.Start();
                    if (g_ICR2500_decl.f != null && g_ICR2500_decl.f.DSCANTab != null)
                        g_ICR2500_decl.f.DSCANTab.ActivateTimer();
                    break;
            }


        }

        private void BandScopeFunction_DSCAN()
        {
            try
            {
                var data = g_ICR2500_databag.GetInstance();

                int pos = 0;
                double stepAux = double.Parse(data.Step);
                double endFreq = double.Parse(data.EndFreq);
                double starFreq = double.Parse(data.StartFreq);
                int cantMeas = Convert.ToInt32(Math.Ceiling((endFreq - starFreq) / stepAux));
                cantMeas += (cantMeas % 2);
                if (data.scanMeas == null)
                    data.scanMeas = new g_ICR2500_constants.FrequencyMeasure[cantMeas];
                data.scanFull = false;
                while (!(double.Parse(data.CurrentFreq) > double.Parse(data.EndFreq)))
                {
                    string currFreq = g_ICR2500_utils.ParseFullFrecuency(data.CurrentFreq);

                    IcomManager.SetFrequency(currFreq, data.Filter, data.Mode);
                    IcomManager.AskFrequencyStrength();

                    g_ICR2500_databag.GetInstance().CurrentFreq = currFreq;



                    g_ICR2500_constants.FrequencyMeasure AddFreq = new g_ICR2500_constants.FrequencyMeasure(currFreq, data.SignalStrength);
                    int cont = 0;
                    while (AddFreq.Value == null && cont < 100)
                    {
                        IcomManager.AskFrequencyStrength();
                        Thread.Sleep(20);
                        AddFreq.Value = data.SignalStrength;
                        cont++;
                    }

                    if (data.scanMeas.Length > pos)
                    {
                        data.scanMeas[pos] = AddFreq;
                        pos++;
                    }
                    Thread.Sleep(50);
                    double currentFreqAux = double.Parse(data.CurrentFreq);
                    stepAux = double.Parse(data.Step);
                    data.CurrentFreq = g_ICR2500_utils.ParseFullFrecuency((currentFreqAux + stepAux).ToString());
                }

                data.CurrentFreq = data.StartFreq;//1 lap
                data.scanFull = true;
                Thread.Sleep(1);
                data.scanFull = false;
                pos = 0;
                stop = true;
            }
            catch (Exception ex)
            {
                Logger.LogEx(ex.Message);
            }
        }


        private void TurnOn()
        {
            IcomManager.TurnOn();
            g_ICR2500_databag.GetInstance().IcomOn = true;
        }

        private void TurnOff()
        {
            IcomManager.TurnOff();
            g_ICR2500_databag.GetInstance().IcomOn = false;
        }


        private void StartMeas()
        {

        }

        #endregion IDciDriver Members

        private void BuildRegPath(string sRegPath)
        {
            g_ICR2500_decl.REG_PATH = sRegPath;
            g_ICR2500_decl.REG_DIR = (string)Assembly.GetExecutingAssembly().GetName().Name;
        }

        private void LoadSettingsFromRegistry()
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rsk;

            //Set default values.

            g_ICR2500_decl.RcvSettings.Version = g_ICR2500_decl.C_VERSION;
            g_ICR2500_decl.RcvSettings.ClassCode = g_ICR2500_decl.C_CLASSCODE;
            g_ICR2500_decl.RcvSettings.Logname = g_ICR2500_decl.DEFAULT_LOGNAME;
            g_ICR2500_decl.RcvSettings.Drvmode = g_ICR2500_decl.DEFAULT_DRVMODE;

            rsk = rk.OpenSubKey(g_ICR2500_decl.REG_PATH + g_ICR2500_decl.REG_DIR, false);
            if (rsk != null)
            {
                if (g_ICR2500_decl.RcvSettings.Version == Convert.ToString(rsk.GetValue("Version")))
                {
                    //Load physical settings.
                    //...
                }
                rsk.Close();
                rk.Close();
            }
        }

        public static void StartMeasRemote()
        {
            object o = null;
            dci_SetRemote((int)e_Commands.DH_MEAS_START, 0, ref o);
        }

        public static void SendMeasResultToArgus()
        {
            if (!g_ICR2500_decl.bPhysical)
            {
                //R&S physical should be caalled over timer only if you have problems
                //delivering data direcly as you get them from the device

                // R&S virtual mode
                Random rand = new Random();
                string Selected_Freq = g_ICR2500_utils.ParseFullFrecuency(g_ICR2500_databag.GetInstance().CurrentFreq);

                object oVarRes = new MarshalAsAttribute(UnmanagedType.LPArray);
                double[,] dMeasResult = new double[2, 1];
                dMeasResult[0, 0] = Convert.ToDouble(Selected_Freq);	//Frequency
                //dMeasResult[1,0] = dc.RES_CTCSS;	//CTCSS result in TesDec sample.
                dMeasResult[1, 0] = rand.NextDouble() * (-10); //for some Level

                oVarRes = dMeasResult;
                dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                            (Int32)e_Commands.NFY_RESULT,
                            ref oVarRes);

            }
            else
            {

                UInt32 measmode = g_ICR2500_decl.UsedParams & g_ICR2500_decl.MEAS_PAGE;
                switch (measmode)
                {
                    case g_ICR2500_decl.MEAS_SING:
                        {
                            string Selected_Freq = g_ICR2500_utils.ParseFullFrecuency(g_ICR2500_databag.GetInstance().CurrentFreq);

                            double[,] dMeasResult = new double[2, 1];
                            dMeasResult[0, 0] = Convert.ToDouble(Selected_Freq);	//Frequency
                            if (!string.IsNullOrEmpty(g_ICR2500_databag.GetInstance().SignalStrength))
                                dMeasResult[1, 0] = double.Parse(g_ICR2500_databag.GetInstance().SignalStrength);
                            else
                                dMeasResult[1, 0] = 0;

                            object oVarRes = new MarshalAsAttribute(UnmanagedType.LPArray);
                            oVarRes = dMeasResult;
                            dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                        (Int32)e_Commands.NFY_RESULT,
                                        ref oVarRes);
                        }
                        break;

                    case g_ICR2500_decl.MEAS_DSCAN:
                    // R&S as far as data is concerned it's the same type of array
                    case g_ICR2500_decl.MEAS_SCAN:
                        {
                            var data = g_ICR2500_databag.GetInstance();
                            object oVarRes = new MarshalAsAttribute(UnmanagedType.SafeArray);
                            oVarRes = UnmanagedType.R8;
                            //oVarRes = UnmanagedType;

                            double start = Convert.ToDouble(g_ICR2500_databag.GetInstance().StartFreq);
                            double step = Convert.ToDouble(g_ICR2500_databag.GetInstance().Step);
                            double end = Convert.ToDouble(g_ICR2500_databag.GetInstance().EndFreq);

                            while (!data.scanFull) { };

                            lock (data.scanMeas)
                            {
                                int iSize = data.scanMeas.Length;
                                double[,] dMeasResult = new double[2, iSize];

                                // reorder so as to respect structure of unmanaged SAFEARRAY

                                // there should be a method to set the marshaller to automatically use the right
                                // order by setting the correct values to	SAFEARRAYBOUND	sab [2]; 
                                // sab[0].lLbound = 0; sab[0].cElements = iCols;
                                // sab[1].lLbound = 0; sab[1].cElements = MeasRes.iSize;
                                // as soon as I find it, I'll send it to you 

                                int f = 0;
                                int j = 0, i = 0;
                                for (int k = 0; k < iSize; k++)
                                {
                                    j = k % 2;
                                    dMeasResult[j, i] = start + k * step;
                                    if (j == 1) i++;
                                    j++;
                                }
                                for (int k = iSize; k < 2 * iSize; k++)
                                {
                                    j = k % 2;
                                    //dMeasResult[j, i] = rand.NextDouble() * (-10);
                                    g_ICR2500_constants.FrequencyMeasure measData = null;
                                    if (f < data.scanMeas.Length)
                                    {
                                        measData = data.scanMeas[f];
                                        f++;
                                    }
                                    if (measData != null && !String.IsNullOrEmpty(measData.Value))
                                        dMeasResult[j, i] = Int32.Parse(measData.Value);
                                    else
                                        dMeasResult[j, i] = 0;
                                    if (j == 1) i++;
                                    j++;
                                }

                                oVarRes = dMeasResult;
                            }
                            stop = true;
                            while (!g_ICR2500_decl.ACK_RCV) { }
                            g_ICR2500_decl.ACK_RCV = false;
                            if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                            {
                                dci_SetRemote((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                        (Int32)e_Commands.NFY_RESULT,
                                        ref oVarRes);
                            }
                            else
                            {
                                dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                            (Int32)e_Commands.NFY_RESULT,
                                            ref oVarRes);
                            }

                        }
                        break;
                }

            }
        }

        public static void SendMeasResultToArgusDMM(UInt32 measmode)
        {

            switch (measmode)
            {
                case g_ICR2500_decl.MEAS_SING:
                    {
                        string Selected_Freq = g_ICR2500_utils.ParseFullFrecuency(g_ICR2500_databag.GetInstance().CurrentFreq);

                        double[,] dMeasResult = new double[2, 1];
                        dMeasResult[0, 0] = Convert.ToDouble(Selected_Freq);	//Frequency
                        if (!string.IsNullOrEmpty(g_ICR2500_databag.GetInstance().SignalStrength))
                            dMeasResult[1, 0] = double.Parse(g_ICR2500_databag.GetInstance().SignalStrength);
                        else
                            dMeasResult[1, 0] = 0;

                        object oVarRes = new MarshalAsAttribute(UnmanagedType.LPArray);
                        oVarRes = dMeasResult;

                        dci_SetRemote((Int32)e_Commands.DH_SETT,
                                  (Int32)e_Commands.MEAS,
                                   ref oVarRes);
                        //dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                        //              (Int32)e_Commands.NFY_RESULT,
                        //              ref oVarRes);


                    }
                    break;

                case g_ICR2500_decl.MEAS_DSCAN:
                // R&S as far as data is concerned it's the same type of array
                case g_ICR2500_decl.MEAS_SCAN:
                    {
                        var data = g_ICR2500_databag.GetInstance();
                        object oVarRes = new MarshalAsAttribute(UnmanagedType.SafeArray);
                        oVarRes = UnmanagedType.R8;
                        //oVarRes = UnmanagedType;

                        double start = Convert.ToDouble(g_ICR2500_databag.GetInstance().StartFreq);
                        double step = Convert.ToDouble(g_ICR2500_databag.GetInstance().Step);
                        double end = Convert.ToDouble(g_ICR2500_databag.GetInstance().EndFreq);

                        while (!data.scanFull) { };

                        lock (data.scanMeas)
                        {
                            int iSize = data.scanMeas.Length;
                            double[,] dMeasResult = new double[2, iSize];

                            // reorder so as to respect structure of unmanaged SAFEARRAY

                            // there should be a method to set the marshaller to automatically use the right
                            // order by setting the correct values to	SAFEARRAYBOUND	sab [2]; 
                            // sab[0].lLbound = 0; sab[0].cElements = iCols;
                            // sab[1].lLbound = 0; sab[1].cElements = MeasRes.iSize;
                            // as soon as I find it, I'll send it to you 

                            int f = 0;
                            int j = 0, i = 0;
                            for (int k = 0; k < iSize; k++)
                            {
                                j = k % 2;
                                dMeasResult[j, i] = start + k * step;
                                if (j == 1) i++;
                                j++;
                            }
                            for (int k = iSize; k < 2 * iSize; k++)
                            {
                                j = k % 2;
                                //dMeasResult[j, i] = rand.NextDouble() * (-10);
                                g_ICR2500_constants.FrequencyMeasure measData = null;
                                if (f < data.scanMeas.Length)
                                {
                                    measData = data.scanMeas[f];
                                    f++;
                                }
                                if (measData != null && !String.IsNullOrEmpty(measData.Value))
                                    dMeasResult[j, i] = Int32.Parse(measData.Value);
                                else
                                    dMeasResult[j, i] = 0;
                                if (j == 1) i++;
                                j++;
                            }

                            oVarRes = dMeasResult;
                        }
                        stop = true;
                        while (!g_ICR2500_decl.ACK_RCV) { }
                        g_ICR2500_decl.ACK_RCV = false;
                        if (g_ICR2500_decl.STATIONMODE == (int)g_ICR2500_decl.UNIT.C)
                        {
                            dci_SetRemote((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                    (Int32)e_Commands.NFY_RESULT,
                                    ref oVarRes);
                        }
                        else
                        {
                            dci_Data((Int32)e_Commands.DH_NFY_MEAS_DATA,
                                        (Int32)e_Commands.NFY_RESULT,
                                        ref oVarRes);
                        }

                    }
                    break;


            }
        }

        public static void dci_SetRemote(Int32 lCommand, Int32 lSize, ref object pVar)
        {
            string sEmpty = "";
            g_ICR2500_decl.nfy.dci_SetDeviceRemote(lCommand, lSize, ref pVar, ref sEmpty);

        }//End of dci_SetRemote()

        public static void dci_Data(Int32 lCommand, Int32 lType, ref object pVar)
        {
            try
            {
                string sEmpty = null;
                g_ICR2500_decl.nfy.dci_DeviceData(lCommand, lType, ref pVar, ref sEmpty);
            }
            catch (Exception)
            {

            }


        }//End of dci_Data()
    }
}