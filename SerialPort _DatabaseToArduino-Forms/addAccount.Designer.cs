﻿namespace SerialPort__DatabaseToArduino_Forms
{
    partial class addAccount
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
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.addAccount_button = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "   First name        Middle name        Last name                 ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(12, 30);
            this.firstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(100, 22);
            this.firstName.TabIndex = 1;
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(224, 30);
            this.lastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(100, 22);
            this.lastName.TabIndex = 3;
            // 
            // middleName
            // 
            this.middleName.Location = new System.Drawing.Point(117, 30);
            this.middleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(100, 22);
            this.middleName.TabIndex = 2;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(331, 30);
            this.id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id.MaxLength = 14;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 22);
            this.id.TabIndex = 4;
            // 
            // addAccount_button
            // 
            this.addAccount_button.Location = new System.Drawing.Point(325, 57);
            this.addAccount_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addAccount_button.Name = "addAccount_button";
            this.addAccount_button.Size = new System.Drawing.Size(100, 23);
            this.addAccount_button.TabIndex = 5;
            this.addAccount_button.Text = "Add Account";
            this.addAccount_button.UseVisualStyleBackColor = true;
            this.addAccount_button.Click += new System.EventHandler(this.addAccount_button_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(12, 59);
            this.clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(100, 23);
            this.clear.TabIndex = 6;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // addAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 92);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.addAccount_button);
            this.Controls.Add(this.id);
            this.Controls.Add(this.middleName);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "addAccount";
            this.Text = "Add Account";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button addAccount_button;
        private System.Windows.Forms.Button clear;
    }
}