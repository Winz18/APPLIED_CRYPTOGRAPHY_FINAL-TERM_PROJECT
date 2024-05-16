namespace Project_WLS_PMKID_Cracker
{
    partial class MainForm
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
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.txtPMKID = new System.Windows.Forms.TextBox();
            this.txtWordlistPath = new System.Windows.Forms.TextBox();
            this.txtClientMAC = new System.Windows.Forms.TextBox();
            this.txtBSSID = new System.Windows.Forms.TextBox();
            this.lbSSID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHelp = new System.Windows.Forms.RichTextBox();
            this.btnCrack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(102, 28);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(652, 22);
            this.txtSSID.TabIndex = 0;
            // 
            // txtPMKID
            // 
            this.txtPMKID.Location = new System.Drawing.Point(102, 181);
            this.txtPMKID.Name = "txtPMKID";
            this.txtPMKID.Size = new System.Drawing.Size(652, 22);
            this.txtPMKID.TabIndex = 1;
            // 
            // txtWordlistPath
            // 
            this.txtWordlistPath.Location = new System.Drawing.Point(102, 233);
            this.txtWordlistPath.Name = "txtWordlistPath";
            this.txtWordlistPath.Size = new System.Drawing.Size(652, 22);
            this.txtWordlistPath.TabIndex = 2;
            // 
            // txtClientMAC
            // 
            this.txtClientMAC.Location = new System.Drawing.Point(102, 128);
            this.txtClientMAC.Name = "txtClientMAC";
            this.txtClientMAC.Size = new System.Drawing.Size(652, 22);
            this.txtClientMAC.TabIndex = 3;
            // 
            // txtBSSID
            // 
            this.txtBSSID.Location = new System.Drawing.Point(102, 78);
            this.txtBSSID.Name = "txtBSSID";
            this.txtBSSID.Size = new System.Drawing.Size(652, 22);
            this.txtBSSID.TabIndex = 4;
            // 
            // lbSSID
            // 
            this.lbSSID.AutoSize = true;
            this.lbSSID.Location = new System.Drawing.Point(12, 28);
            this.lbSSID.Name = "lbSSID";
            this.lbSSID.Size = new System.Drawing.Size(38, 16);
            this.lbSSID.TabIndex = 5;
            this.lbSSID.Text = "SSID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "BSSID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Client Mac";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "PMKID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dictionary";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = " <3 Help <3";
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(102, 323);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(652, 202);
            this.txtHelp.TabIndex = 11;
            this.txtHelp.Text = "";
            // 
            // btnCrack
            // 
            this.btnCrack.Location = new System.Drawing.Point(582, 270);
            this.btnCrack.Name = "btnCrack";
            this.btnCrack.Size = new System.Drawing.Size(172, 47);
            this.btnCrack.TabIndex = 12;
            this.btnCrack.Text = "Crack";
            this.btnCrack.UseVisualStyleBackColor = true;
            this.btnCrack.Click += new System.EventHandler(this.btnCrack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 537);
            this.Controls.Add(this.btnCrack);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSSID);
            this.Controls.Add(this.txtBSSID);
            this.Controls.Add(this.txtClientMAC);
            this.Controls.Add(this.txtWordlistPath);
            this.Controls.Add(this.txtPMKID);
            this.Controls.Add(this.txtSSID);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PMKID Cracker ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbSSID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSSID;
        public System.Windows.Forms.TextBox txtBSSID;
        public System.Windows.Forms.TextBox txtClientMAC;
        public System.Windows.Forms.TextBox txtPMKID;
        public System.Windows.Forms.TextBox txtWordlistPath;
        public System.Windows.Forms.RichTextBox txtHelp;
        public System.Windows.Forms.Button btnCrack;
    }
}

