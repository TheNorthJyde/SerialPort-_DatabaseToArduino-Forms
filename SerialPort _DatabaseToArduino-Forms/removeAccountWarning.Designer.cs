namespace SerialPort__DatabaseToArduino_Forms
{
    partial class removeAccountWarning
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
            this.label1 = new System.Windows.Forms.Label();
            this.removeAcc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.accountInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you sure you want to remove ";
            // 
            // removeAcc
            // 
            this.removeAcc.Location = new System.Drawing.Point(11, 85);
            this.removeAcc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeAcc.Name = "removeAcc";
            this.removeAcc.Size = new System.Drawing.Size(100, 19);
            this.removeAcc.TabIndex = 2;
            this.removeAcc.Text = "Remove Account";
            this.removeAcc.UseVisualStyleBackColor = true;
            this.removeAcc.Click += new System.EventHandler(this.removeAcc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // accountInfo
            // 
            this.accountInfo.AutoSize = true;
            this.accountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountInfo.Location = new System.Drawing.Point(12, 42);
            this.accountInfo.Name = "accountInfo";
            this.accountInfo.Size = new System.Drawing.Size(94, 20);
            this.accountInfo.TabIndex = 4;
            this.accountInfo.Text = "accountInfo";
            // 
            // removeAccountWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 125);
            this.Controls.Add(this.accountInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.removeAcc);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "removeAccountWarning";
            this.Text = "removeAccountWarning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeAcc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label accountInfo;
    }
}