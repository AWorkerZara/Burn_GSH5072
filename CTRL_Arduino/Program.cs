using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTRL_Arduino
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Analog_Input());
            Application.Run(new Burn_GSH5072());
            //Application.Run(new Test_Arduino_Code());
            //Application.Run(new Arduino_CLI());
        }
    }
}
