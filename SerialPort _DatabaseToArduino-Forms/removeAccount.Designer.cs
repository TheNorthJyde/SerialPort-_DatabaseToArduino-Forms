namespace SerialPort__DatabaseToArduino_Forms
{
    partial class removeAccount
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
            this.id = new System.Windows.Forms.TextBox();
            this.removeAccount_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(12, 29);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 22);
            this.id.TabIndex = 0;
            // 
            // removeAccount_button
            // 
            this.removeAccount_button.Location = new System.Drawing.Point(134, 28);
            this.removeAccount_button.Name = "removeAccount_button";
            this.removeAccount_button.Size = new System.Drawing.Size(125, 23);
            this.removeAccount_button.TabIndex = 1;
            this.removeAccount_button.Text = "Remove Account";
            this.removeAccount_button.UseVisualStyleBackColor = true;
            this.removeAccount_button.Click += new System.EventHandler(this.removeAccount_button_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "          ID";
            // 
            // removeAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 74);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeAccount_button);
            this.Controls.Add(this.id);
            this.Name = "removeAccount";
            this.Text = "Remove Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button removeAccount_button;
        private System.Windows.Forms.Label label1;
    }
}