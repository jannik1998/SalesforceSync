namespace SalesforceSync
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSend = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonCheckCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(151, 230);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(114, 48);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Senden";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 200);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(253, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(253, 169);
            this.textBoxInfo.TabIndex = 2;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 184);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(56, 13);
            this.labelPath.TabIndex = 3;
            this.labelPath.Text = "Dateipfad:";
            // 
            // buttonCheckCsv
            // 
            this.buttonCheckCsv.Location = new System.Drawing.Point(12, 230);
            this.buttonCheckCsv.Name = "buttonCheckCsv";
            this.buttonCheckCsv.Size = new System.Drawing.Size(113, 48);
            this.buttonCheckCsv.TabIndex = 4;
            this.buttonCheckCsv.Text = ".csv Prüfen";
            this.buttonCheckCsv.UseVisualStyleBackColor = true;
            this.buttonCheckCsv.Click += new System.EventHandler(this.buttonCheckCsv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 290);
            this.Controls.Add(this.buttonCheckCsv);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Salesforce Synchronisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonCheckCsv;
    }
}

