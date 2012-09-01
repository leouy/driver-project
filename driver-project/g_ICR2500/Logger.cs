using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace g_ICR2500
{
    public static class Logger
    {
        public static void LogEx(string message)
        {
            try
            { 

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = File.AppendText("C:\\Log.txt");
                //Write a line of text
                sw.WriteLine(message);

                //Write a second line of text
                sw.WriteLine("--------------------------");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
