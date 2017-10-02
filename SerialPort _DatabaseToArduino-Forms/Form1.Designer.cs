namespace SerialPort__DatabaseToArduino_Forms
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
            this.connect = new System.Windows.Forms.Button();
            this.comPort = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.output = new System.Windows.Forms.ListBox();
            this.clear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAccounts = new System.Windows.Forms.Button();
            this.showLog = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(211, 177);
            this.connect.Margin = new System.Windows.Forms.Padding(2);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 19);
            this.connect.TabIndex = 1;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // comPort
            // 
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(92, 176);
            this.comPort.Margin = new System.Windows.Forms.Padding(2);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(115, 21);
            this.comPort.TabIndex = 2;
            this.comPort.SelectedIndexChanged += new System.EventHandler(this.comPort_SelectedIndexChanged);
            // 
            // output
            // 
            this.output.FormattingEnabled = true;
            this.output.Location = new System.Drawing.Point(9, 25);
            this.output.Margin = new System.Windows.Forms.Padding(2);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(278, 121);
            this.output.TabIndex = 3;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(9, 177);
            this.clear.Margin = new System.Windows.Forms.Padding(2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 19);
            this.clear.TabIndex = 4;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(295, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.removeUserToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.filToolStripMenuItem.Text = "Settings";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeUserToolStripMenuItem.Text = "Remove User";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // showAccounts
            // 
            this.showAccounts.Location = new System.Drawing.Point(193, 154);
            this.showAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.showAccounts.Name = "showAccounts";
            this.showAccounts.Size = new System.Drawing.Size(93, 19);
            this.showAccounts.TabIndex = 6;
            this.showAccounts.Text = "Show Accounts";
            this.showAccounts.UseVisualStyleBackColor = true;
            this.showAccounts.Click += new System.EventHandler(this.showAccounts_Click);
            // 
            // showLog
            // 
            this.showLog.Location = new System.Drawing.Point(9, 150);
            this.showLog.Margin = new System.Windows.Forms.Padding(2);
            this.showLog.Name = "showLog";
            this.showLog.Size = new System.Drawing.Size(75, 23);
            this.showLog.TabIndex = 7;
            this.showLog.Text = "Show Log";
            this.showLog.UseVisualStyleBackColor = true;
            this.showLog.Click += new System.EventHandler(this.showLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 206);
            this.Controls.Add(this.showLog);
            this.Controls.Add(this.showAccounts);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.output);
            this.Controls.Add(this.comPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "A";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.ComboBox comPort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.Button showAccounts;
        private System.Windows.Forms.Button showLog;
    }
}

