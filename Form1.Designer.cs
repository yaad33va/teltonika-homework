namespace teltonika_homework
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
            this.versionLabel = new System.Windows.Forms.Label();
            this.upTimeLabel = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtUptime = new System.Windows.Forms.TextBox();
            this.dataGridViewAccounts = new System.Windows.Forms.DataGridView();
            this.SaveConfigBtn = new System.Windows.Forms.Button();
            this.generatePswBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(12, 19);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            // 
            // upTimeLabel
            // 
            this.upTimeLabel.AutoSize = true;
            this.upTimeLabel.Location = new System.Drawing.Point(174, 19);
            this.upTimeLabel.Name = "upTimeLabel";
            this.upTimeLabel.Size = new System.Drawing.Size(43, 13);
            this.upTimeLabel.TabIndex = 1;
            this.upTimeLabel.Text = "Uptime:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(63, 16);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(100, 20);
            this.txtVersion.TabIndex = 2;
            // 
            // txtUptime
            // 
            this.txtUptime.Location = new System.Drawing.Point(223, 16);
            this.txtUptime.Name = "txtUptime";
            this.txtUptime.Size = new System.Drawing.Size(100, 20);
            this.txtUptime.TabIndex = 3;
            // 
            // dataGridViewAccounts
            // 
            this.dataGridViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounts.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewAccounts.Name = "dataGridViewAccounts";
            this.dataGridViewAccounts.Size = new System.Drawing.Size(564, 171);
            this.dataGridViewAccounts.TabIndex = 4;
            // 
            // SaveConfigBtn
            // 
            this.SaveConfigBtn.Location = new System.Drawing.Point(15, 230);
            this.SaveConfigBtn.Name = "SaveConfigBtn";
            this.SaveConfigBtn.Size = new System.Drawing.Size(124, 23);
            this.SaveConfigBtn.TabIndex = 5;
            this.SaveConfigBtn.Text = "Save Configuration";
            this.SaveConfigBtn.UseVisualStyleBackColor = true;
            // 
            // generatePswBtn
            // 
            this.generatePswBtn.Location = new System.Drawing.Point(177, 230);
            this.generatePswBtn.Name = "generatePswBtn";
            this.generatePswBtn.Size = new System.Drawing.Size(133, 23);
            this.generatePswBtn.TabIndex = 6;
            this.generatePswBtn.Text = "Generate Passwords";
            this.generatePswBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 318);
            this.Controls.Add(this.generatePswBtn);
            this.Controls.Add(this.SaveConfigBtn);
            this.Controls.Add(this.dataGridViewAccounts);
            this.Controls.Add(this.txtUptime);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.upTimeLabel);
            this.Controls.Add(this.versionLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label upTimeLabel;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtUptime;
        private System.Windows.Forms.DataGridView dataGridViewAccounts;
        private System.Windows.Forms.Button SaveConfigBtn;
        private System.Windows.Forms.Button generatePswBtn;
    }
}

