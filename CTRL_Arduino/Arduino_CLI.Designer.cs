namespace CTRL_Arduino
{
    partial class Arduino_CLI
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
            this.label_Comport = new System.Windows.Forms.Label();
            this.comboBox_Port_List = new System.Windows.Forms.ComboBox();
            this.button_Burn = new System.Windows.Forms.Button();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.progressBar_Burn = new System.Windows.Forms.ProgressBar();
            this.button_ReFlash = new System.Windows.Forms.Button();
            this.label_Choose_File = new System.Windows.Forms.Label();
            this.textBox_BurnFile_Name = new System.Windows.Forms.TextBox();
            this.button_Choose_File = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Comport
            // 
            this.label_Comport.AutoSize = true;
            this.label_Comport.Location = new System.Drawing.Point(12, 15);
            this.label_Comport.Name = "label_Comport";
            this.label_Comport.Size = new System.Drawing.Size(91, 24);
            this.label_Comport.TabIndex = 0;
            this.label_Comport.Text = "連接阜： ";
            // 
            // comboBox_Port_List
            // 
            this.comboBox_Port_List.FormattingEnabled = true;
            this.comboBox_Port_List.Location = new System.Drawing.Point(101, 11);
            this.comboBox_Port_List.Name = "comboBox_Port_List";
            this.comboBox_Port_List.Size = new System.Drawing.Size(121, 32);
            this.comboBox_Port_List.TabIndex = 1;
            // 
            // button_Burn
            // 
            this.button_Burn.Location = new System.Drawing.Point(329, 11);
            this.button_Burn.Name = "button_Burn";
            this.button_Burn.Size = new System.Drawing.Size(123, 32);
            this.button_Burn.TabIndex = 2;
            this.button_Burn.Text = "開始燒錄";
            this.button_Burn.UseVisualStyleBackColor = true;
            this.button_Burn.Click += new System.EventHandler(this.button_Burn_Click);
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Msg.Location = new System.Drawing.Point(16, 142);
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Msg.Size = new System.Drawing.Size(436, 167);
            this.textBox_Msg.TabIndex = 3;
            // 
            // progressBar_Burn
            // 
            this.progressBar_Burn.Location = new System.Drawing.Point(16, 126);
            this.progressBar_Burn.MarqueeAnimationSpeed = 1;
            this.progressBar_Burn.Name = "progressBar_Burn";
            this.progressBar_Burn.Size = new System.Drawing.Size(435, 10);
            this.progressBar_Burn.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Burn.TabIndex = 4;
            this.progressBar_Burn.Visible = false;
            // 
            // button_ReFlash
            // 
            this.button_ReFlash.Location = new System.Drawing.Point(228, 11);
            this.button_ReFlash.Name = "button_ReFlash";
            this.button_ReFlash.Size = new System.Drawing.Size(95, 32);
            this.button_ReFlash.TabIndex = 5;
            this.button_ReFlash.Text = "重新整理";
            this.button_ReFlash.UseVisualStyleBackColor = true;
            this.button_ReFlash.Click += new System.EventHandler(this.button_ReFlash_Click);
            // 
            // label_Choose_File
            // 
            this.label_Choose_File.AutoSize = true;
            this.label_Choose_File.Location = new System.Drawing.Point(12, 53);
            this.label_Choose_File.Name = "label_Choose_File";
            this.label_Choose_File.Size = new System.Drawing.Size(143, 24);
            this.label_Choose_File.TabIndex = 6;
            this.label_Choose_File.Text = "選擇燒錄檔案：";
            // 
            // textBox_BurnFile_Name
            // 
            this.textBox_BurnFile_Name.Location = new System.Drawing.Point(16, 87);
            this.textBox_BurnFile_Name.Name = "textBox_BurnFile_Name";
            this.textBox_BurnFile_Name.Size = new System.Drawing.Size(435, 33);
            this.textBox_BurnFile_Name.TabIndex = 7;
            // 
            // button_Choose_File
            // 
            this.button_Choose_File.Location = new System.Drawing.Point(161, 49);
            this.button_Choose_File.Name = "button_Choose_File";
            this.button_Choose_File.Size = new System.Drawing.Size(95, 32);
            this.button_Choose_File.TabIndex = 8;
            this.button_Choose_File.Text = "瀏覽";
            this.button_Choose_File.UseVisualStyleBackColor = true;
            this.button_Choose_File.Click += new System.EventHandler(this.button_Choose_File_Click);
            // 
            // Arduino_CLI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.button_Choose_File);
            this.Controls.Add(this.textBox_BurnFile_Name);
            this.Controls.Add(this.label_Choose_File);
            this.Controls.Add(this.button_ReFlash);
            this.Controls.Add(this.progressBar_Burn);
            this.Controls.Add(this.textBox_Msg);
            this.Controls.Add(this.button_Burn);
            this.Controls.Add(this.comboBox_Port_List);
            this.Controls.Add(this.label_Comport);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Arduino_CLI";
            this.Text = "治具更新";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Comport;
        private System.Windows.Forms.ComboBox comboBox_Port_List;
        private System.Windows.Forms.Button button_Burn;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.ProgressBar progressBar_Burn;
        private System.Windows.Forms.Button button_ReFlash;
        private System.Windows.Forms.Label label_Choose_File;
        private System.Windows.Forms.TextBox textBox_BurnFile_Name;
        private System.Windows.Forms.Button button_Choose_File;
    }
}