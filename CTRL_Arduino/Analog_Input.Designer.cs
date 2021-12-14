namespace CTRL_Arduino
{
    partial class Analog_Input
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Connect_Comport = new System.Windows.Forms.Button();
            this.comboBox_Comport_List = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort_Arduino = new System.IO.Ports.SerialPort(this.components);
            this.chart_Analog_input = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Analog_input)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Connect_Comport
            // 
            this.button_Connect_Comport.Location = new System.Drawing.Point(279, 5);
            this.button_Connect_Comport.Name = "button_Connect_Comport";
            this.button_Connect_Comport.Size = new System.Drawing.Size(142, 32);
            this.button_Connect_Comport.TabIndex = 6;
            this.button_Connect_Comport.Text = "Connect";
            this.button_Connect_Comport.UseVisualStyleBackColor = true;
            this.button_Connect_Comport.Click += new System.EventHandler(this.button_Connect_Comport_Click);
            // 
            // comboBox_Comport_List
            // 
            this.comboBox_Comport_List.FormattingEnabled = true;
            this.comboBox_Comport_List.Location = new System.Drawing.Point(152, 6);
            this.comboBox_Comport_List.Name = "comboBox_Comport_List";
            this.comboBox_Comport_List.Size = new System.Drawing.Size(121, 32);
            this.comboBox_Comport_List.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arduino Port :";
            // 
            // serialPort_Arduino
            // 
            this.serialPort_Arduino.BaudRate = 115200;
            this.serialPort_Arduino.ReadBufferSize = 65536;
            this.serialPort_Arduino.ReceivedBytesThreshold = 5;
            this.serialPort_Arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_Arduino_DataReceived);
            // 
            // chart_Analog_input
            // 
            this.chart_Analog_input.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.Maximum = 1050D;
            chartArea2.AxisY.Minimum = -10D;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BorderColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart_Analog_input.ChartAreas.Add(chartArea2);
            this.chart_Analog_input.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.ForeColor = System.Drawing.Color.Silver;
            legend2.Name = "Legend1";
            this.chart_Analog_input.Legends.Add(legend2);
            this.chart_Analog_input.Location = new System.Drawing.Point(0, 0);
            this.chart_Analog_input.Name = "chart_Analog_input";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart_Analog_input.Series.Add(series3);
            this.chart_Analog_input.Series.Add(series4);
            this.chart_Analog_input.Size = new System.Drawing.Size(522, 451);
            this.chart_Analog_input.TabIndex = 0;
            this.chart_Analog_input.Text = "Analog Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart_Analog_input);
            this.panel1.Location = new System.Drawing.Point(1, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 451);
            this.panel1.TabIndex = 8;
            // 
            // Analog_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Connect_Comport);
            this.Controls.Add(this.comboBox_Comport_List);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Analog_Input";
            this.Text = "Analog Input";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Analog_Input_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Analog_input)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Connect_Comport;
        private System.Windows.Forms.ComboBox comboBox_Comport_List;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort_Arduino;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Analog_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}