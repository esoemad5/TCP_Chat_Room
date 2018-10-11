namespace Chatroom_GUI
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
            this.serverTextBos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bStartServer
            // 
            this.bStartServer.Location = new System.Drawing.Point(713, 12);
            this.bStartServer.Name = "bStartServer";
            this.bStartServer.Size = new System.Drawing.Size(75, 23);
            this.bStartServer.TabIndex = 0;
            this.bStartServer.Text = "StartServer";
            this.bStartServer.UseVisualStyleBackColor = true;
            // 
            // serverTextBos
            // 
            this.serverTextBos.Location = new System.Drawing.Point(12, 12);
            this.serverTextBos.Multiline = true;
            this.serverTextBos.Name = "serverTextBos";
            this.serverTextBos.Size = new System.Drawing.Size(695, 426);
            this.serverTextBos.TabIndex = 1;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.serverTextBos);
            this.Controls.Add(this.bStartServer);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartServer;
        private System.Windows.Forms.TextBox serverTextBos;
    }
}

