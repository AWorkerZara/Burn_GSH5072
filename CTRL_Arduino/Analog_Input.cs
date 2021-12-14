using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace CTRL_Arduino
{
    public partial class Analog_Input : Form
    {
        public Analog_Input()
        {
            InitializeComponent();
            Find_Arduino_Comport();
            T_Keep_Draw = new Thread(Keep_Draw_Chart);
            T_Keep_Draw.Start();
        }

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
            LabelRenew(label2, (string)smsg);
        }
        public void Renew_TextBox_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_LabelRenew));
            NT.Start(Dmsg);
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
                    value = serialPort_Arduino.ReadExisting();
                    Renew_TextBox_Message(value);
                    Ctrl_Msg_Renew(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取串口數據發生錯誤：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




        public void Renew_Chart_Value(string s_Val)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_Chart));
            NT.Start(s_Val);
        }

        public void New_Thread_Chart(object o_Val)
        {
            Ctrl_Msg_Renew(o_Val);
        }

         DateTime a1,a2;
        TimeSpan ats;
        public void Ctrl_Msg_Renew(object o_newPoint)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    Ctrl_Msg_RenewCallback d = Ctrl_Msg_Renew;
                    this.Invoke(d, o_newPoint);
                }
                else
                {
                    //a1 = DateTime.Now;
                    
                    string[] ss_val = ((string)o_newPoint).Split(';');
                    foreach (string sub_s in ss_val)
                    {
                        string[] s_val = (sub_s).Split(',');
                        if (s_val.Length <= 1)
                            return;
                        Int32 A1_Val = 0;
                        Int32.TryParse(s_val[0], out A1_Val);
                        Int32 A2_Val = 0;
                        Int32.TryParse(s_val[1], out A2_Val);
                        //a2 = DateTime.Now;
                        //ats = a2 - a1;

                        //a1 = DateTime.Now;
                        //for (int i = 0; i < A1_Array.Length - 1; i++)
                        //{
                        //    A1_Array[i] = A1_Array[i + 1];
                        //    A2_Array[i] = A2_Array[i + 1];
                        //}
                        A1_Array[A1_Array.Length - 1] = A1_Val;
                        A2_Array[A2_Array.Length - 1] = A2_Val;

                        //chart_Analog_input.Series[0].Points.Clear();
                        //chart_Analog_input.Series[1].Points.Clear();
                        ////a2 = DateTime.Now;
                        ////ats = a2 - a1;


                        ////// 匯入Chart1
                        //for (int i = 0; i < chartWhite; i++)
                        //{
                        //    chart_Analog_input.Series[0].Points.AddXY(i, A1_Array[i]);
                        //    chart_Analog_input.Series[1].Points.AddXY(i, A2_Array[i]);
                        //}

                        //chart_Analog_input.Update();
                    }
                }
            }
            catch (Exception ChartError)
            {
                //MessageBox.Show(ChartError.Message, "Chart Error !!");
            }
        }
        public delegate void Ctrl_Msg_RenewCallback(object o_newPoint);

        private int chartWhite = 300;
        private int[] A1_Array = new int[300];
        private int[] A2_Array = new int[300];
        bool keep_Draw = true;
        Thread T_Keep_Draw;
        private void Keep_Draw_Chart()
        {
            while (keep_Draw)
            {
                for (int i = 0; i < A1_Array.Length - 1; i++)
                {
                    A1_Array[i] = A1_Array[i + 1];
                    A2_Array[i] = A2_Array[i + 1];
                }
                //A1_Array[A1_Array.Length - 1] = A1_Val;
                //A2_Array[A2_Array.Length - 1] = A2_Val;
                this.Invoke(new Action(() =>
                {
                    chart_Analog_input.Series[0].Points.Clear();
                chart_Analog_input.Series[1].Points.Clear();
                }));
                //a2 = DateTime.Now;
                //ats = a2 - a1;


                //// 匯入Chart1
                for (int i = 0; i < chartWhite; i++)
                {
                    this.Invoke(new Action(() =>
                    {
                        chart_Analog_input.Series[0].Points.AddXY(i, A1_Array[i]);
                        chart_Analog_input.Series[1].Points.AddXY(i, A2_Array[i]);


                    }));
                }
                this.Invoke(new Action(() =>
                {
                    chart_Analog_input.Update();
                }));
            }
        }

        private void Analog_Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            keep_Draw = false;
            serialPort_Arduino.Close();
        }
    }
}
