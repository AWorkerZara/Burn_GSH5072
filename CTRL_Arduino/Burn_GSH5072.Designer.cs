﻿namespace CTRL_Arduino
{
    partial class Burn_GSH5072
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Burn_GSH5072));
            this.button_Connect_Comport = new System.Windows.Forms.Button();
            this.comboBox_Comport_List = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort_Arduino = new System.IO.Ports.SerialPort(this.components);
            this.button_Burn = new System.Windows.Forms.Button();
            this.label_Recive = new System.Windows.Forms.Label();
            this.textBox_Device_Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Auto_Add = new System.Windows.Forms.CheckBox();
            this.checkBox_Burn_Check = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_Search_ComPort = new System.Windows.Forms.Button();
            this.label_Data1 = new System.Windows.Forms.Label();
            this.label_Data2 = new System.Windows.Forms.Label();
            this.textBox_JV1 = new System.Windows.Forms.TextBox();
            this.textBox_JV2 = new System.Windows.Forms.TextBox();
            this.textBox_JV1_err = new System.Windows.Forms.TextBox();
            this.textBox_JV2_err = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_Juedge_Result = new System.Windows.Forms.Label();
            this.label_Set_Close_Delay_Time = new System.Windows.Forms.Label();
            this.numericUpDown_Close_Delay_Time = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Close_Delay_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Connect_Comport
            // 
            this.button_Connect_Comport.Location = new System.Drawing.Point(434, 5);
            this.button_Connect_Comport.Name = "button_Connect_Comport";
            this.button_Connect_Comport.Size = new System.Drawing.Size(152, 32);
            this.button_Connect_Comport.TabIndex = 6;
            this.button_Connect_Comport.Text = "連線";
            this.button_Connect_Comport.UseVisualStyleBackColor = true;
            this.button_Connect_Comport.Click += new System.EventHandler(this.button_Connect_Comport_Click);
            // 
            // comboBox_Comport_List
            // 
            this.comboBox_Comport_List.FormattingEnabled = true;
            this.comboBox_Comport_List.Location = new System.Drawing.Point(175, 6);
            this.comboBox_Comport_List.Name = "comboBox_Comport_List";
            this.comboBox_Comport_List.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Comport_List.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "燒錄裝置 連接阜 :";
            // 
            // serialPort_Arduino
            // 
            this.serialPort_Arduino.PortName = "COM5";
            this.serialPort_Arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_Arduino_DataReceived);
            // 
            // button_Burn
            // 
            this.button_Burn.Enabled = false;
            this.button_Burn.Font = new System.Drawing.Font("Microsoft JhengHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Burn.Location = new System.Drawing.Point(434, 43);
            this.button_Burn.Name = "button_Burn";
            this.button_Burn.Size = new System.Drawing.Size(152, 67);
            this.button_Burn.TabIndex = 7;
            this.button_Burn.Text = "燒錄";
            this.button_Burn.UseVisualStyleBackColor = true;
            this.button_Burn.EnabledChanged += new System.EventHandler(this.button_Burn_EnabledChanged);
            this.button_Burn.Click += new System.EventHandler(this.button_Burn_Click);
            // 
            // label_Recive
            // 
            this.label_Recive.AutoSize = true;
            this.label_Recive.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Recive.Location = new System.Drawing.Point(12, 115);
            this.label_Recive.Name = "label_Recive";
            this.label_Recive.Size = new System.Drawing.Size(176, 24);
            this.label_Recive.TabIndex = 8;
            this.label_Recive.Text = "花費時間：X.XXX秒";
            // 
            // textBox_Device_Number
            // 
            this.textBox_Device_Number.Location = new System.Drawing.Point(175, 43);
            this.textBox_Device_Number.MaxLength = 2147483647;
            this.textBox_Device_Number.Name = "textBox_Device_Number";
            this.textBox_Device_Number.Size = new System.Drawing.Size(250, 33);
            this.textBox_Device_Number.TabIndex = 9;
            this.textBox_Device_Number.Text = "1";
            this.textBox_Device_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "裝置號碼 :";
            // 
            // checkBox_Auto_Add
            // 
            this.checkBox_Auto_Add.AutoSize = true;
            this.checkBox_Auto_Add.Checked = true;
            this.checkBox_Auto_Add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Auto_Add.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_Auto_Add.Location = new System.Drawing.Point(215, 82);
            this.checkBox_Auto_Add.Name = "checkBox_Auto_Add";
            this.checkBox_Auto_Add.Size = new System.Drawing.Size(105, 28);
            this.checkBox_Auto_Add.TabIndex = 11;
            this.checkBox_Auto_Add.Text = "自動累加";
            this.checkBox_Auto_Add.UseVisualStyleBackColor = true;
            // 
            // checkBox_Burn_Check
            // 
            this.checkBox_Burn_Check.AutoSize = true;
            this.checkBox_Burn_Check.Checked = true;
            this.checkBox_Burn_Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Burn_Check.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_Burn_Check.Location = new System.Drawing.Point(317, 82);
            this.checkBox_Burn_Check.Name = "checkBox_Burn_Check";
            this.checkBox_Burn_Check.Size = new System.Drawing.Size(124, 28);
            this.checkBox_Burn_Check.TabIndex = 12;
            this.checkBox_Burn_Check.Text = "燒錄後檢查";
            this.checkBox_Burn_Check.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 223);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(590, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // button_Search_ComPort
            // 
            this.button_Search_ComPort.Location = new System.Drawing.Point(301, 6);
            this.button_Search_ComPort.Name = "button_Search_ComPort";
            this.button_Search_ComPort.Size = new System.Drawing.Size(124, 32);
            this.button_Search_ComPort.TabIndex = 14;
            this.button_Search_ComPort.Text = "重新整理";
            this.button_Search_ComPort.UseVisualStyleBackColor = true;
            this.button_Search_ComPort.Click += new System.EventHandler(this.button_Search_ComPort_Click);
            // 
            // label_Data1
            // 
            this.label_Data1.AutoSize = true;
            this.label_Data1.Location = new System.Drawing.Point(12, 151);
            this.label_Data1.Name = "label_Data1";
            this.label_Data1.Size = new System.Drawing.Size(162, 24);
            this.label_Data1.TabIndex = 15;
            this.label_Data1.Text = "-------------------";
            // 
            // label_Data2
            // 
            this.label_Data2.AutoSize = true;
            this.label_Data2.Location = new System.Drawing.Point(12, 190);
            this.label_Data2.Name = "label_Data2";
            this.label_Data2.Size = new System.Drawing.Size(162, 24);
            this.label_Data2.TabIndex = 16;
            this.label_Data2.Text = "-------------------";
            // 
            // textBox_JV1
            // 
            this.textBox_JV1.Location = new System.Drawing.Point(423, 142);
            this.textBox_JV1.Name = "textBox_JV1";
            this.textBox_JV1.Size = new System.Drawing.Size(41, 33);
            this.textBox_JV1.TabIndex = 17;
            this.textBox_JV1.Text = "1.2";
            this.textBox_JV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_JV2
            // 
            this.textBox_JV2.Location = new System.Drawing.Point(423, 181);
            this.textBox_JV2.Name = "textBox_JV2";
            this.textBox_JV2.Size = new System.Drawing.Size(41, 33);
            this.textBox_JV2.TabIndex = 18;
            this.textBox_JV2.Text = "3.3";
            this.textBox_JV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_JV1_err
            // 
            this.textBox_JV1_err.Location = new System.Drawing.Point(515, 142);
            this.textBox_JV1_err.Name = "textBox_JV1_err";
            this.textBox_JV1_err.Size = new System.Drawing.Size(41, 33);
            this.textBox_JV1_err.TabIndex = 19;
            this.textBox_JV1_err.Text = "5";
            this.textBox_JV1_err.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_JV2_err
            // 
            this.textBox_JV2_err.Location = new System.Drawing.Point(515, 181);
            this.textBox_JV2_err.Name = "textBox_JV2_err";
            this.textBox_JV2_err.Size = new System.Drawing.Size(41, 33);
            this.textBox_JV2_err.TabIndex = 20;
            this.textBox_JV2_err.Text = "5";
            this.textBox_JV2_err.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "V1 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "V2 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "標準值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "誤差值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 24);
            this.label7.TabIndex = 25;
            this.label7.Text = "V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(464, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 24);
            this.label8.TabIndex = 26;
            this.label8.Text = "V";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(556, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(557, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 24);
            this.label10.TabIndex = 28;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(484, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 30);
            this.label11.TabIndex = 29;
            this.label11.Text = "±";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(484, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 30);
            this.label12.TabIndex = 30;
            this.label12.Text = "±";
            // 
            // label_Juedge_Result
            // 
            this.label_Juedge_Result.AutoSize = true;
            this.label_Juedge_Result.Font = new System.Drawing.Font("Microsoft JhengHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Juedge_Result.Location = new System.Drawing.Point(221, 104);
            this.label_Juedge_Result.Name = "label_Juedge_Result";
            this.label_Juedge_Result.Size = new System.Drawing.Size(110, 47);
            this.label_Juedge_Result.TabIndex = 31;
            this.label_Juedge_Result.Text = "          ";
            // 
            // label_Set_Close_Delay_Time
            // 
            this.label_Set_Close_Delay_Time.AutoSize = true;
            this.label_Set_Close_Delay_Time.Location = new System.Drawing.Point(12, 83);
            this.label_Set_Close_Delay_Time.Name = "label_Set_Close_Delay_Time";
            this.label_Set_Close_Delay_Time.Size = new System.Drawing.Size(203, 24);
            this.label_Set_Close_Delay_Time.TabIndex = 32;
            this.label_Set_Close_Delay_Time.Text = "燒錄完後            秒斷電";
            // 
            // numericUpDown_Close_Delay_Time
            // 
            this.numericUpDown_Close_Delay_Time.Location = new System.Drawing.Point(100, 81);
            this.numericUpDown_Close_Delay_Time.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_Close_Delay_Time.Name = "numericUpDown_Close_Delay_Time";
            this.numericUpDown_Close_Delay_Time.Size = new System.Drawing.Size(46, 33);
            this.numericUpDown_Close_Delay_Time.TabIndex = 33;
            this.numericUpDown_Close_Delay_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Close_Delay_Time.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Burn_GSH5072
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 244);
            this.Controls.Add(this.button_Burn);
            this.Controls.Add(this.numericUpDown_Close_Delay_Time);
            this.Controls.Add(this.label_Set_Close_Delay_Time);
            this.Controls.Add(this.label_Juedge_Result);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_JV2_err);
            this.Controls.Add(this.textBox_JV1_err);
            this.Controls.Add(this.textBox_JV2);
            this.Controls.Add(this.textBox_JV1);
            this.Controls.Add(this.label_Data2);
            this.Controls.Add(this.label_Data1);
            this.Controls.Add(this.button_Search_ComPort);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox_Burn_Check);
            this.Controls.Add(this.checkBox_Auto_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Device_Number);
            this.Controls.Add(this.label_Recive);
            this.Controls.Add(this.button_Connect_Comport);
            this.Controls.Add(this.comboBox_Comport_List);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Burn_GSH5072";
            this.Text = "燒錄 GSH 5072";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Close_Delay_Time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Connect_Comport;
        private System.Windows.Forms.ComboBox comboBox_Comport_List;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort_Arduino;
        private System.Windows.Forms.Button button_Burn;
        private System.Windows.Forms.Label label_Recive;
        private System.Windows.Forms.TextBox textBox_Device_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_Auto_Add;
        private System.Windows.Forms.CheckBox checkBox_Burn_Check;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_Search_ComPort;
        private System.Windows.Forms.Label label_Data1;
        private System.Windows.Forms.Label label_Data2;
        private System.Windows.Forms.TextBox textBox_JV1;
        private System.Windows.Forms.TextBox textBox_JV2;
        private System.Windows.Forms.TextBox textBox_JV1_err;
        private System.Windows.Forms.TextBox textBox_JV2_err;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_Juedge_Result;
        private System.Windows.Forms.Label label_Set_Close_Delay_Time;
        private System.Windows.Forms.NumericUpDown numericUpDown_Close_Delay_Time;
    }
}