using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Management;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace CTRL_Arduino
{
    public partial class Form1 : Form
    {

        public delegate void LabelRenewCallback(Control Target_Label, string Msg);
        public void LabelRenew(Control Target_Label, string Msg)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    LabelRenewCallback d = LabelRenew;
                    this.Invoke(d, Target_Label, Msg);
                }
                else
                {
                    if (Target_Label.Name == "textBox_MSG")
                    {
                        TextBox TBX = (TextBox)Target_Label;

                        if (Msg == "clr")
                            TBX.Text = "";
                        else
                            //TBX.Text = DateTime.Now.ToString("[HH:mm:ss] ") + Msg + "\r\n" + TBX.Text;
                            TBX.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + Msg + "\r\n");
                    }
                    else
                    {
                        Target_Label.Text = Msg;
                    }

                }
            }
            catch (Exception eer)
            {
                //MessageBox.Show(eer.Message, "Label Renew Error !!");
            }
        }
        public void New_Thread_LabelRenew(object smsg)
        {
            LabelRenew(textBox_MSG, (string)smsg);
        }
        public void Renew_TextBox_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_LabelRenew));
            NT.Start(Dmsg);
        }

        public Form1()
        {
            InitializeComponent();

            Find_Arduino_Comport();
        }

        private void Find_Arduino_Comport()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string pname in ports)
                comboBox_Comport_List.Items.Add(pname);

            comboBox_Comport_List.SelectedIndex = ports.Length - 1;

        }
        private void button_Connect_Comport_Click(object sender, EventArgs e)
        {
            if (button_Connect_Comport.Text == "Connect")
            {
                if (serialPort_Arduino == null)
                    serialPort_Arduino = new SerialPort();

                serialPort_Arduino.PortName = comboBox_Comport_List.SelectedItem.ToString();
                serialPort_Arduino.Open();
                comboBox_Comport_List.Enabled = false;
                button_Connect_Comport.Text = "Disconnect";
            }
            else
            {
                serialPort_Arduino.Close();
                comboBox_Comport_List.Enabled = true;
                button_Connect_Comport.Text = "Connect";
                serialPort_Arduino.Dispose();
            }
        }
        



        private void serialPort_Arduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string value = "";
            try
            {
                if (serialPort_Arduino != null && serialPort_Arduino.BytesToRead > 0)
                {
                    Renew_TextBox_Message(serialPort_Arduino.ReadExisting());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取串口數據發生錯誤：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serialPort_Arduino.IsOpen)
                serialPort_Arduino.Close();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_MSG.Text = "";
        }

        private void button_Send_MSG_Click(object sender, EventArgs e)
        {
            string semdCmd = textBox_Send_MSG.Text;
            serialPort_Arduino.Write(semdCmd);
        }

    }
}
