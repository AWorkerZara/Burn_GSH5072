namespace CTRL_Arduino
{
    partial class Form1
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
            this.serialPort_Arduino = new System.IO.Ports.SerialPort(this.components);
            this.textBox_MSG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Comport_List = new System.Windows.Forms.ComboBox();
            this.button_Connect_Comport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Send_MSG = new System.Windows.Forms.TextBox();
            this.button_Send_MSG = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort_Arduino
            // 
            this.serialPort_Arduino.PortName = "COM5";
            this.serialPort_Arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_Arduino_DataReceived);
            // 
            // textBox_MSG
            // 
            this.textBox_MSG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MSG.Location = new System.Drawing.Point(116, 50);
            this.textBox_MSG.MaxLength = 0;
            this.textBox_MSG.Multiline = true;
            this.textBox_MSG.Name = "textBox_MSG";
            this.textBox_MSG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MSG.Size = new System.Drawing.Size(465, 308);
            this.textBox_MSG.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arduino Port :";
            // 
            // comboBox_Comport_List
            // 
            this.comboBox_Comport_List.FormattingEnabled = true;
            this.comboBox_Comport_List.Location = new System.Drawing.Point(152, 12);
            this.comboBox_Comport_List.Name = "comboBox_Comport_List";
            this.comboBox_Comport_List.Size = new System.Drawing.Size(121, 32);
            this.comboBox_Comport_List.TabIndex = 2;
            // 
            // button_Connect_Comport
            // 
            this.button_Connect_Comport.Location = new System.Drawing.Point(279, 11);
            this.button_Connect_Comport.Name = "button_Connect_Comport";
            this.button_Connect_Comport.Size = new System.Drawing.Size(142, 32);
            this.button_Connect_Comport.TabIndex = 3;
            this.button_Connect_Comport.Text = "Connect";
            this.button_Connect_Comport.UseVisualStyleBackColor = true;
            this.button_Connect_Comport.Click += new System.EventHandler(this.button_Connect_Comport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Receive :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transmit :";
            // 
            // textBox_Send_MSG
            // 
            this.textBox_Send_MSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Send_MSG.Location = new System.Drawing.Point(116, 379);
            this.textBox_Send_MSG.Name = "textBox_Send_MSG";
            this.textBox_Send_MSG.Size = new System.Drawing.Size(465, 33);
            this.textBox_Send_MSG.TabIndex = 6;
            this.textBox_Send_MSG.Text = "R1880000";
            // 
            // button_Send_MSG
            // 
            this.button_Send_MSG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_MSG.Location = new System.Drawing.Point(478, 418);
            this.button_Send_MSG.Name = "button_Send_MSG";
            this.button_Send_MSG.Size = new System.Drawing.Size(103, 33);
            this.button_Send_MSG.TabIndex = 7;
            this.button_Send_MSG.Text = "Send";
            this.button_Send_MSG.UseVisualStyleBackColor = true;
            this.button_Send_MSG.Click += new System.EventHandler(this.button_Send_MSG_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(16, 77);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 34);
            this.button_Clear.TabIndex = 8;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 475);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Send_MSG);
            this.Controls.Add(this.textBox_Send_MSG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Connect_Comport);
            this.Controls.Add(this.comboBox_Comport_List);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_MSG);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Arduino Nano";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort_Arduino;
        private System.Windows.Forms.TextBox textBox_MSG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Comport_List;
        private System.Windows.Forms.Button button_Connect_Comport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Send_MSG;
        private System.Windows.Forms.Button button_Send_MSG;
        private System.Windows.Forms.Button button_Clear;
    }
}

