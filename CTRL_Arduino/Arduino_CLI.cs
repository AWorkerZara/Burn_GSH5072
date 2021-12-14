using System;
using System.Collections.Generic;
using System.Management;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;



namespace CTRL_Arduino
{

    /// <summary>
    /// Remember :
    /// 1.Driver
    /// 2.Arduino_Cli.exe Need download board library.
    /// 
    /// </summary>
    public partial class Arduino_CLI : Form
    {

        Process CLI_CMD = new Process();

        public Arduino_CLI()
        {
            InitializeComponent();

            CLI_CMD.StartInfo.FileName = "arduino-cli.exe";
            CLI_CMD.StartInfo.UseShellExecute = false;  //是否使用作業系統shell啟動 
            CLI_CMD.StartInfo.CreateNoWindow = true;  //是否在新視窗中啟動該程序的值 (不顯示程式視窗)
            CLI_CMD.StartInfo.RedirectStandardOutput = true;  // 由呼叫程式獲取輸出資訊0
            CLI_CMD.StartInfo.RedirectStandardInput = true; // 接受來自呼叫程式的輸入資訊 
            CLI_CMD.StartInfo.RedirectStandardError = true;  //重定向標準錯誤輸出

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                comboBox_Port_List.Items.Add(port);
            comboBox_Port_List.SelectedIndex = ports.Length - 1;

        }

        private void button_Burn_Click(object sender, EventArgs e)
        {
            if (comboBox_Port_List.Text == "")
            {
                MessageBox.Show("裝置未連接!!", "治具更新");
                return;
            }
            if(textBox_BurnFile_Name.Text == "")
            {
                MessageBox.Show("尚未選擇燒錄檔!!", "治具更新");
                return;
            }
            Arduino_Port = comboBox_Port_List.Text;
            MoveBurnFile();
            Thread CMDTH = new Thread(CommandThread);
            CMDTH.Start();
        }

        string Arduino_Port = "";
        string BurnFilePath = "";
        private void CommandThread()
        {
            this.Invoke(new Action(() => UI_Set(false)));
            this.Invoke(new Action(() => textBox_Msg.Text += "~~~ Start Burning : " + textBox_BurnFile_Name.Text + " ~~~\r\n"));
            try
            {
                CLI_CMD.StartInfo.Arguments = " compile --fqbn arduino:avr:mini -upload -p " + Arduino_Port + " " + BurnFilePath + "\\Burn_GSH5072.ino";
                CLI_CMD.Start();
                //// this code have more smooth on UI response, but for OP use may more danger.///////////////////////////////
                //if (onetime)
                //{
                //    CLI_CMD.BeginOutputReadLine();
                //    onetime = false;
                //}
                //CLI_CMD.OutputDataReceived += (_, er) => this.Invoke(new Action(() => Renew_TextBoxMsg_String(er.Data)));
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string resp = CLI_CMD.StandardOutput.ReadToEnd() + Environment.NewLine;
                CLI_CMD.WaitForExit();
                this.Invoke(new Action(() => textBox_Msg.AppendText(resp)));
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Burn");
            }
            this.Invoke(new Action(() => UI_Set(true)));
            this.Invoke(new Action(() => textBox_Msg.Text += "~~~ Burn End ~~~\r\n"));

            DeleteFolder(BurnFilePath);
        }

        private void Renew_TextBoxMsg_String(string NewMsg)
        {
            if(NewMsg != null)
                textBox_Msg.AppendText(NewMsg);
        }
        private void UI_Set(bool CanUse)
        {
            comboBox_Port_List.Enabled = CanUse;
            button_ReFlash.Enabled = CanUse;
            button_Burn.Enabled = CanUse;
            progressBar_Burn.Visible = !CanUse;
        }

        private void MoveBurnFile()
        {
            string Target_Burn_File = textBox_BurnFile_Name.Text;
            BurnFilePath = Environment.CurrentDirectory + "\\Burn_GSH5072";
            if(Directory.Exists(BurnFilePath))
                DeleteFolder(BurnFilePath);

            Directory.CreateDirectory(BurnFilePath);
            string[] files = System.IO.Directory.GetFiles(Environment.CurrentDirectory);
            // Copy the files and overwrite destination files if they already exist.
            System.IO.File.Copy(TargetFile_Path, System.IO.Path.Combine(BurnFilePath, "BinFile.ino"), true);
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                string fileName = System.IO.Path.GetFileName(s);
                //if (fileName == textBox_BurnFile_Name.Text)
                //{
                //    string destFile = System.IO.Path.Combine(BurnFilePath, "BinFile.ino");
                //    System.IO.File.Copy(s, destFile, true);
                //}
                switch (fileName)
                {
                    case "arduino-cli.exe":
                    case "Burn_GSH5072.ino":
                    case "I2C_Ctrl_Read.ino":
                    case "I2C_Ctrl_Write.ino":
                        {
                            string destFile = System.IO.Path.Combine(BurnFilePath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                        }
                        break;
                }
            }
        }

        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (System.IO.File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    System.IO.File.Delete(d);
                }
                else
                    DeleteFolder(d);
            }
            Directory.Delete(dir);
        }

        // custom struct with our desired values
        struct ComPort
        {
            public string name;
            public string description;
            public string vid;
            public string pid;

            public ComPort(string name, string description,string vid,string pid)
            {
                this.name = name;
                this.description = description;
                this.vid = vid;
                this.pid = pid;
            }
        }

        private void button_ReFlash_Click(object sender, EventArgs e)
        {
            comboBox_Port_List.Items.Clear();
            GetFullComputerDevices(comboBox_Port_List);
        }

        #region Catch Comport 
    
        #region Solution 1
        // Method 2 function
        private List<ComPort> GetSerialPort2()
        {
            List<ComPort> ports = new List<ComPort>();
            var searcher = new ManagementObjectSearcher("SELECT DeviceID,Caption FROM WIN32_SerialPort");
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
            foreach (ComPort port in ports)
            {
                ports.Add(port);
            }
            // Method 1
            string[] ports2 = SerialPort.GetPortNames();
            foreach (string port in ports2)
            {
                // Only need to check the Port Name
                if (!ports.Exists(x => x.name == port))
                {
                    ports.Add(new ComPort(port, port,"",""));
                }
            }
            return ports;
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
        #endregion

        #region Solution 2
        private const string vidPattern = @"VID_([0-9A-F]{4})";
        private const string pidPattern = @"PID_([0-9A-F]{4})";
        private List<ComPort> GetSerialPorts()
        {
            using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                return ports.Select(p =>
                {
                    ComPort c = new ComPort();
                    c.name = p.GetPropertyValue("DeviceID").ToString();
                    c.vid = p.GetPropertyValue("PNPDeviceID").ToString();
                    c.description = p.GetPropertyValue("Caption").ToString();

                    Match mVID = Regex.Match(c.vid, vidPattern, RegexOptions.IgnoreCase);
                    Match mPID = Regex.Match(c.vid, pidPattern, RegexOptions.IgnoreCase);

                    if (mVID.Success)
                        c.vid = mVID.Groups[1].Value;
                    if (mPID.Success)
                        c.pid = mPID.Groups[1].Value;

                    return c;

                }).ToList();
            }
        }




        #endregion

        #endregion

        string TargetFile_Path;
        private void button_Choose_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = Environment.CurrentDirectory;
            OFD.Filter = "Bin files (*.bin)|*.bin|All files (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                TargetFile_Path = OFD.FileName;
                textBox_BurnFile_Name.Text = OFD.SafeFileName;
            }
        }
            

        
    }
}
