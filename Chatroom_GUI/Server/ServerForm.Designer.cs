﻿namespace Chatroom_GUI
{
    partial class ServerForm
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
            this.bStartServer = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bStartServer
            // 
            this.bStartServer.Location = new System.Drawing.Point(1070, 18);
            this.bStartServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bStartServer.Name = "bStartServer";
            this.bStartServer.Size = new System.Drawing.Size(112, 35);
            this.bStartServer.TabIndex = 0;
            this.bStartServer.Text = "StartServer";
            this.bStartServer.UseVisualStyleBackColor = true;
            this.bStartServer.Click += new System.EventHandler(this.bStartServer_Click);
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(18, 18);
            this.serverTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serverTextBox.Multiline = true;
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverTextBox.Size = new System.Drawing.Size(1040, 653);
            this.serverTextBox.TabIndex = 1;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.bStartServer);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartServer;
        private System.Windows.Forms.TextBox serverTextBox;
    }
}

