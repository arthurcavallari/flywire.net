using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Windows.Forms;
using System.Diagnostics;


namespace Flywire_WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            // Remove the original default trace listener.
            //Trace.Listeners.RemoveAt(0);

            // Create and add a new default trace listener.
            DefaultTraceListener defaultListener;
            defaultListener = new DefaultTraceListener();
            
            Trace.Listeners.Add(defaultListener);
            defaultListener.LogFileName = Settings.LogPath + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
            
            Program.LogWrite("Flywire.net starting up.");
            try
            {
                Settings.checkPaths(); 

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Program.LogWrite("Flywire.net closed.");
                
            }
            catch (Exception e)
            {
                Program.LogWrite("Programm::Main(): Unhandled error reached Main() => " + e.ToString());
                MessageBox.Show(e.ToString());
            }

            defaultListener.Flush();
            Trace.Listeners.Remove(defaultListener);
            defaultListener.Close();
        }

        public static void LogWrite(string Message)
        {
            Trace.WriteLine(DateTime.Now.ToString("hh:mm:ss tt") + ": " + Message);
        }
    }
}
