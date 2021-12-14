namespace CTRL_Arduino
{
    partial class Arduino_Message
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
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Msg.Location = new System.Drawing.Point(0, 0);
            this.textBox_Msg.MaxLength = 0;
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Msg.Size = new System.Drawing.Size(521, 522);
            this.textBox_Msg.TabIndex = 0;
            // 
            // Arduino_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 522);
            this.Controls.Add(this.textBox_Msg);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Arduino_Message";
            this.Text = "Arduino Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Msg;
    }
}