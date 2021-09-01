﻿using System;
using System.IO.Ports;
using System.Management;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace CTRL_Arduino
{
    public partial class Burn_GSH5072 : Form
    {
        public Burn_GSH5072()
        {
            InitializeComponent();
            Find_Arduino_Comport();

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += "  " +version.ToString(); 
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
                    if (Msg == "!NG!")
                        Target_Label.ForeColor = System.Drawing.Color.Red;
                    else
                        Target_Label.ForeColor = System.Drawing.Color.Black;
                    Target_Label.Text = Msg;
                }
            }
            catch (Exception eer)
            {
                //MessageBox.Show(eer.Message, "Label Renew Error !!");
            }
        }
        public void New_Thread_LabelRenew(object smsg)
        {
            LabelRenew(label_Recive, (string)smsg);
        }
        public void Renew_TextBox_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_LabelRenew));
            NT.Start(Dmsg);
        }

        public void New_Thread_Label_Burn_Result_1_Renew(object smsg)
        {
            LabelRenew(label_Data1, (string)smsg);
        }
        public void Renew_Burn_Result_1_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_Label_Burn_Result_1_Renew));
            NT.Start(Dmsg);
        }

        public void New_Thread_Label_Burn_Result_2_Renew(object smsg)
        {
            LabelRenew(label_Data2, (string)smsg);
        }
        public void Renew_Burn_Result_2_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_Label_Burn_Result_2_Renew));
            NT.Start(Dmsg);
        }

        public void New_Thread_Label_Burn_Result_String_Renew(object smsg)
        {
            LabelRenew(label_Juedge_Result, (string)smsg);
        }
        public void Renew_Burn_Result_String_Message(string Dmsg)
        {
            Thread NT = new Thread(new ParameterizedThreadStart(New_Thread_Label_Burn_Result_String_Renew));
            NT.Start(Dmsg);
        }




        public delegate void ItemRenewCallback(Control Target_Label, bool En);
        public void ItemRenew(Control Target_Item, bool En)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    ItemRenewCallback d = ItemRenew;
                    this.Invoke(d, Target_Item, En);
                }
                else
                {
                    if ((Target_Item.Name == "comboBox_Comport_List") || (Target_Item.Name == "button_Search_ComPort")) { }
                    else
                        Target_Item.Enabled = En;
                }
            }
            catch (Exception eer)
            {
                //MessageBox.Show(eer.Message, "Label Renew Error !!");
            }
        }

        public delegate void ItemNumberAddCallback(Control Target_Label);
        public void ItemNumberAdd(Control Target_TextBox)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    ItemNumberAddCallback d = ItemNumberAdd;
                    this.Invoke(d, Target_TextBox);
                }
                else
                {
                    Target_TextBox.Text = (Int64.Parse(Target_TextBox.Text) + 1).ToString();
                }
            }
            catch (Exception eer)
            {
                //MessageBox.Show(eer.Message, "Label Renew Error !!");
            }
        }



        public string GetFullComputerDevices(ComboBox CB)
        {

            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            string ComPort_number = "No COM Port device recognized";
            try
            {
                foreach (ManagementObject property in Ports)
                {
                    //if (property.GetPropertyValue("Name").ToString().Contains("Prolific USB-to-Serial Comm Port"));  //以顯示名稱為Prolific USB-to-Serial Comm Port的UART轉USB晶片PL2303為基底的裝置為例
                    bool atg = property.GetPropertyValue("Name").ToString().Contains("USB-SERIAL CH340");
                    if (atg)   //以顯示名稱為Prolific USB-to-Serial Comm Port的UART轉USB晶片PL2303為基底的裝置為例
                    {
                        ComPort_number = property.GetPropertyValue("Name").ToString();
                        ComPort_number = ComPort_number.Substring(ComPort_number.IndexOf("COM")).TrimEnd(')'); //取得COMx的字串並將其放置到ComPort_number這個string變數
                        CB.Items.Add(ComPort_number);
                        CB.SelectedIndex = 0;
                        //微軟的String.Substring方法教學
                        //微軟的String.TrimEnd方法教學:
                    }
                }
            }
            catch (Exception rrr)
            {

            }

            return ComPort_number; //回傳字串，如果都沒有就會回傳預設的"No COM Port device recognized"字串
        }

        private void Check_USB_PlugIn_State()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            //EventType = 1是對insert和remove都有反應; 
            //EventType = 2是只有對insert有反應; 
            //EventType = 3是只有對remove有反應
            //以上可以視情況宣告為全域instances 方便一些應用

            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Query = query;
            watcher.Start();
            //如果要停掉watcher就呼叫watcher.Stop(); 不用時可以dispose()掉
            //注意上述這些初始動作要在serial port init之前
        }
        int con = 0;
        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //看你想在EventHandler函式裡面做什麼應用
            ComboBox NCB = new ComboBox();
            //GetFullComputerDevices(NCB);

            //if(NCB.Items.Count > this.comboBox_Comport_List.Items.Count)
            //{
            //    if (serialPort_Arduino.IsOpen)
            //        serialPort_Arduino.Close();
            //    MessageBox.Show("偵測到新裝置!!", "裝置偵測");
            //    //comboBox_Comport_List.Items.Clear();
            //    this.comboBox_Comport_List = NCB;
            //    Thread.Sleep(500);
            //    Update();
            //}
            //else if(NCB.Items.Count < this.comboBox_Comport_List.Items.Count)
            //{
            //    if (serialPort_Arduino.IsOpen)
            //        serialPort_Arduino.Close();
            //    MessageBox.Show("裝置已經移出!!", "裝置偵測");
            //    //comboBox_Comport_List.Items.Clear();
            //    this.comboBox_Comport_List = NCB;
            //    Thread.Sleep(500);
            //    Update();
            //}
           Renew_TextBox_Message(e.NewEvent.ClassPath.ClassName.ToString() + con.ToString());
            con++;
        }


        #region Find USB (no use)
        // custom struct with our desired values
        struct ComPort
        {
            public string name;
            public string description;

            public ComPort(string name, string description)
            {
                this.name = name;
                this.description = description;
            }
        }

        // Method 2 function
        private List<ComPort> GetSerialPort2()
        {
            List<ComPort> ports = new List<ComPort>();
            var searcher = new ManagementObjectSearcher("SELECT DeviceID,Caption,Description FROM WIN32_SerialPort");
            foreach (ManagementObject port in searcher.Get())
            {
                // show the service
                ComPort c = new ComPort();
                c.name = port.GetPropertyValue("DeviceID").ToString();
                c.description = port.GetPropertyValue("Caption").ToString();
                ports.Add(c);
            }
            return ports;
        }

        private List<ComPort> GetAllPorts()
        {
            // Method 2
            List<ComPort> ports = GetSerialPort2();
            //foreach (ComPort port in ports)
            //{
            //    ports.Add(port);
            //}
            // Method 1
            string[] ports2 = SerialPort.GetPortNames();
            foreach (string port in ports2)
            {
                // Only need to check the Port Name
                if (!ports.Exists(x => x.name == port))
                {
                    ports.Add(new ComPort(port, port));
                }
            }


            return ports;
        }
        #endregion



        private void Find_Arduino_Comport()
        {
            //Check_USB_PlugIn_State();

            //List<ComPort> ports =  GetSerialPort2();
            //foreach(ComPort CP in ports)
            //    comboBox_Comport_List.Items.Add(CP.name + "("+ CP.description+")");

            //GetFullComputerDevices(comboBox_Comport_List);

            string[] ports = SerialPort.GetPortNames();
            foreach (string pname in ports)
                comboBox_Comport_List.Items.Add(pname);
            comboBox_Comport_List.SelectedIndex = ports.Length - 1;

            if (comboBox_Comport_List.Items.Count == 1)
            {
                // comboBox_Comport_List.SelectedIndex = 0;
                object obj = new object();
                EventArgs ea = new EventArgs();
                button_Connect_Comport_Click(obj, ea);
            }

        }
        private void button_Connect_Comport_Click(object sender, EventArgs e)
        {
            if (button_Connect_Comport.Text == "連線")
            {
                if (serialPort_Arduino == null)
                    serialPort_Arduino = new SerialPort();

                serialPort_Arduino.PortName = comboBox_Comport_List.SelectedItem.ToString();
                serialPort_Arduino.Open();
                button_Connect_Comport.Text = "斷線";
                button_Burn.Enabled = true;
                comboBox_Comport_List.Enabled = false;
                button_Search_ComPort.Enabled = false;
            }
            else
            {
                serialPort_Arduino.Close();
                serialPort_Arduino.Dispose();
                button_Connect_Comport.Text = "連線";
                button_Burn.Enabled = false;
                comboBox_Comport_List.Enabled = true;
                button_Search_ComPort.Enabled = true;
            }
        }

        private bool FirstTimeDetech = true;
        private bool showOneTime = true;
        private void serialPort_Arduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string value = "";
            try
            {
                if (serialPort_Arduino != null && serialPort_Arduino.BytesToRead > 0)
                {
                    value = serialPort_Arduino.ReadExisting();

                    if (value.Length < 10)
                    {
                        WriteOutInfo(value);
                        a2 = DateTime.Now;
                        TimeSpan ts = a2 - a1;
                        Renew_TextBox_Message("花費時間：" + ts.ToString("s\\.fff") + "秒");

                        if(checkBox_Auto_Add.Checked)
                            ItemNumberAdd(textBox_Device_Number);

                        int Close_Time = ((int)numericUpDown_Close_Delay_Time.Value)*1000;
                        Thread.Sleep(Close_Time);
                        serialPort_Arduino.Write("CCam");
                    }
                    else
                    {
                        if (showOneTime)
                        {
                            if (value == "Start Wating Burn Command:\r\n")
                            {
                                if (!FirstTimeDetech)
                                    MessageBox.Show("找不到裝置", " 裝置錯誤 ");
                                FirstTimeDetech = false;
                            }
                            else
                            {
                                MessageBox.Show(value, " 燒錄錯誤 ");
                                showOneTime = false;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取串口數據發生錯誤：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Enable_Button(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort_Arduino.IsOpen)
                serialPort_Arduino.Close();
        }

        private void Enable_Button(bool En)
        {
            foreach (Control obj in this.Controls)
                ItemRenew(obj, En);
        }

        DateTime a1, a2;

        private void button_Burn_Click(object sender, EventArgs e)
        {
            string BurnStyle = "";
            if (checkBox_Burn_Check.Checked)
                BurnStyle = "BurnChk";
            else
                BurnStyle = "Burn";

            Enable_Button(false);
            progressBar1.Visible = true;
            FirstTimeDetech = false;

            a1 = DateTime.Now;
            serialPort_Arduino.Write(BurnStyle);
            showOneTime = true;
        }

        private void button_Burn_EnabledChanged(object sender, EventArgs e)
        {
            if (button_Burn.Enabled)
                progressBar1.Visible = false;

        }

        private void button_Search_ComPort_Click(object sender, EventArgs e)
        {
            comboBox_Comport_List.Items.Clear();
            GetFullComputerDevices(comboBox_Comport_List);
        }

        private void WriteOutInfo(string sData)
        {
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime nDT = DateTime.Now;
            string nowTime = nDT.ToString("MMdd");
            string[] sVolt = sData.Split(',');
            float[] Catch_Volt = new float[2];


            for (int i = 0; i < sVolt.Length; i++)
                Catch_Volt[i] = (float.Parse(sVolt[i]) / 1024) * 4.65f; //// [(simple/total)*max-Voltage]


            string new_SData = "[" + nDT.ToString("HH:mm:ss") + "] 編號= " + textBox_Device_Number.Text + " , " + Catch_Volt[0].ToString("0.00") + " V, " + Catch_Volt[1].ToString("0.00") + " V  ";

            //Renew_TextBox_Message(sData + " ; " + new_SData);
            Renew_Burn_Result_2_Message(label_Data1.Text);
            Renew_Burn_Result_1_Message(new_SData);

            Renew_Juedge_Value();

            Renew_Burn_Result_String_Message(Juedge_OK_NG(Catch_Volt));
            List<string> BufferList = new List<string>(); 
            try
            {
                StreamReader sr = new StreamReader(nowTime + ".txt", true);
                while (true)
                {
                    if (sr.Peek() == -1) break;
                    BufferList.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception wwe) { }

            StreamWriter sw = new StreamWriter(nowTime + ".txt");

            sw.WriteLine(new_SData + label_Juedge_Result.Text);
            for(int i = 0; i < BufferList.Count; i++)
                sw.WriteLine(BufferList[i]);

            sw.Close();

        }

        private string Juedge_OK_NG(float[] catch_Volt)
        {
            string J_Result = "";

            float JV1_P = JV1 + (JV1 * (JV1_err / 100f));
            float JV1_N = JV1 - (JV1 * (JV1_err / 100f));

            float JV2_P = JV2 + (JV2 * (JV2_err / 100f));
            float JV2_N = JV2 - (JV2 * (JV2_err / 100f));

            bool JV1_OK = Juedge_Rule(JV1_P, catch_Volt[0], JV1_N);
            bool JV2_OK = Juedge_Rule(JV2_P, catch_Volt[1], JV2_N);

            if (JV1_OK && JV2_OK)
                J_Result = "~OK~";
            else
                J_Result = "!NG!";

            return J_Result;
        }

        private bool Juedge_Rule(float jV1_P, float v, float jV1_N)
        {
            if(jV1_P > v)
                if(jV1_N < v)
                    return true;
            return false;
        }

        //// Note: "The quick brown fox jumps over the lazy dog"

        float JV1 = 3.3f;
        float JV2 = 1.8f;
        float JV1_err = 1.0f;
        float JV2_err = 1.0f;

        private void Renew_Juedge_Value()
        {
            try
            {
                JV1 = float.Parse(textBox_JV1.Text);
                JV2 = float.Parse(textBox_JV2.Text);
                JV1_err = float.Parse(textBox_JV1_err.Text);
                JV2_err = float.Parse(textBox_JV2_err.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "判斷電壓輸入格式有誤 !!");
            }


        }




    }
}
