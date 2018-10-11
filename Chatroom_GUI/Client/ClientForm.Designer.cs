namespace Client
{
    partial class ClientForm
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
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.bConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(18, 18);
            this.clientTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clientTextBox.Multiline = true;
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(1105, 544);
            this.clientTextBox.TabIndex = 0;
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(1134, 18);
            this.bConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(112, 35);
            this.bConnect.TabIndex = 1;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 737);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.clientTextBox);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.Button bConnect;
    }
}

