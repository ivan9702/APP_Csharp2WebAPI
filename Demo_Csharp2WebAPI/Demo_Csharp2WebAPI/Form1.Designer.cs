namespace Demo_Csharp2WebAPI
{
    partial class Csharp2WebAPI
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
            this.button_enroll = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_verify = new System.Windows.Forms.Button();
            this.button_identify = new System.Windows.Forms.Button();
            this.richTextBox_serverip = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_finger = new System.Windows.Forms.ComboBox();
            this.richTextBox_id = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_https = new System.Windows.Forms.CheckBox();
            this.richTextBox_port = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_privilege = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_enroll
            // 
            this.button_enroll.Location = new System.Drawing.Point(67, 89);
            this.button_enroll.Name = "button_enroll";
            this.button_enroll.Size = new System.Drawing.Size(112, 46);
            this.button_enroll.TabIndex = 0;
            this.button_enroll.Text = "enroll";
            this.button_enroll.UseVisualStyleBackColor = true;
            this.button_enroll.Click += new System.EventHandler(this.button_enroll_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(67, 318);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(112, 45);
            this.button_delete.TabIndex = 1;
            this.button_delete.Text = "delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_verify
            // 
            this.button_verify.Location = new System.Drawing.Point(67, 159);
            this.button_verify.Name = "button_verify";
            this.button_verify.Size = new System.Drawing.Size(112, 51);
            this.button_verify.TabIndex = 2;
            this.button_verify.Text = "verify";
            this.button_verify.UseVisualStyleBackColor = true;
            this.button_verify.Click += new System.EventHandler(this.button_verify_Click);
            // 
            // button_identify
            // 
            this.button_identify.Location = new System.Drawing.Point(67, 238);
            this.button_identify.Name = "button_identify";
            this.button_identify.Size = new System.Drawing.Size(112, 51);
            this.button_identify.TabIndex = 3;
            this.button_identify.Text = "identify";
            this.button_identify.UseVisualStyleBackColor = true;
            this.button_identify.Click += new System.EventHandler(this.button_identify_Click);
            // 
            // richTextBox_serverip
            // 
            this.richTextBox_serverip.Location = new System.Drawing.Point(108, 44);
            this.richTextBox_serverip.Name = "richTextBox_serverip";
            this.richTextBox_serverip.Size = new System.Drawing.Size(212, 24);
            this.richTextBox_serverip.TabIndex = 4;
            this.richTextBox_serverip.Text = "192.168.1.76";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server IP";
            // 
            // comboBox_finger
            // 
            this.comboBox_finger.FormattingEnabled = true;
            this.comboBox_finger.Location = new System.Drawing.Point(378, 105);
            this.comboBox_finger.Name = "comboBox_finger";
            this.comboBox_finger.Size = new System.Drawing.Size(140, 20);
            this.comboBox_finger.TabIndex = 22;
            // 
            // richTextBox_id
            // 
            this.richTextBox_id.Location = new System.Drawing.Point(240, 103);
            this.richTextBox_id.Name = "richTextBox_id";
            this.richTextBox_id.Size = new System.Drawing.Size(54, 24);
            this.richTextBox_id.TabIndex = 23;
            this.richTextBox_id.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "FP Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "ID";
            // 
            // checkBox_https
            // 
            this.checkBox_https.AutoSize = true;
            this.checkBox_https.Checked = true;
            this.checkBox_https.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_https.Location = new System.Drawing.Point(535, 46);
            this.checkBox_https.Name = "checkBox_https";
            this.checkBox_https.Size = new System.Drawing.Size(91, 16);
            this.checkBox_https.TabIndex = 27;
            this.checkBox_https.Text = "HTTPS enable";
            this.checkBox_https.UseVisualStyleBackColor = true;
            // 
            // richTextBox_port
            // 
            this.richTextBox_port.Location = new System.Drawing.Point(376, 44);
            this.richTextBox_port.Name = "richTextBox_port";
            this.richTextBox_port.Size = new System.Drawing.Size(140, 24);
            this.richTextBox_port.TabIndex = 26;
            this.richTextBox_port.Text = "8444";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "Port";
            // 
            // richTextBox_privilege
            // 
            this.richTextBox_privilege.Location = new System.Drawing.Point(604, 101);
            this.richTextBox_privilege.Name = "richTextBox_privilege";
            this.richTextBox_privilege.Size = new System.Drawing.Size(54, 24);
            this.richTextBox_privilege.TabIndex = 29;
            this.richTextBox_privilege.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "Privilege";
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(378, 238);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(534, 125);
            this.richTextBox_log.TabIndex = 31;
            this.richTextBox_log.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "log";
            // 
            // Csharp2WebAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 455);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox_log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox_privilege);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_https);
            this.Controls.Add(this.richTextBox_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_id);
            this.Controls.Add(this.comboBox_finger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_serverip);
            this.Controls.Add(this.button_identify);
            this.Controls.Add(this.button_verify);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_enroll);
            this.Name = "Csharp2WebAPI";
            this.Text = "Csharp2WebAPI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_enroll;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_verify;
        private System.Windows.Forms.Button button_identify;
        private System.Windows.Forms.RichTextBox richTextBox_serverip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_finger;
        private System.Windows.Forms.RichTextBox richTextBox_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_https;
        private System.Windows.Forms.RichTextBox richTextBox_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox_privilege;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Label label6;
    }
}

