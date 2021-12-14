using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTRL_Arduino
{
    public partial class Arduino_Message : Form
    {
        public Arduino_Message()
        {
            InitializeComponent();
        }

        public void Renew_Message(string msg)
        {
            this.Invoke(new Action(() =>
            {
                this.textBox_Msg.AppendText(msg);
            }));

        }
    }
}
