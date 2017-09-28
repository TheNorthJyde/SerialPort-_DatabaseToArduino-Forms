namespace SerialPort__DatabaseToArduino_Forms
{
    partial class Log
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
            this.log1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.clearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.log1)).BeginInit();
            this.SuspendLayout();
            // 
            // log1
            // 
            this.log1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.log1.Location = new System.Drawing.Point(12, 12);
            this.log1.Name = "log1";
            this.log1.Size = new System.Drawing.Size(502, 342);
            this.log1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(11, 365);
            this.clearLog.Margin = new System.Windows.Forms.Padding(2);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(101, 19);
            this.clearLog.TabIndex = 2;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 395);
            this.Controls.Add(this.clearLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.log1);
            this.Name = "Log";
            this.Text = "Log";
            ((System.ComponentModel.ISupportInitialize)(this.log1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView log1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearLog;
    }
}