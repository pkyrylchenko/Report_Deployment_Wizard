namespace ReportDeployment.GUI
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
            this.txtERPServer = new System.Windows.Forms.TextBox();
            this.txtReportingServerURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtERPPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtERPUserName = new System.Windows.Forms.TextBox();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtERPDatabase = new System.Windows.Forms.TextBox();
            this.txtLynqDatabase = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLynqServer = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtSSRSPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSSRSUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLYNQPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLYNQUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtERPServer
            // 
            this.txtERPServer.Location = new System.Drawing.Point(275, 115);
            this.txtERPServer.Name = "txtERPServer";
            this.txtERPServer.Size = new System.Drawing.Size(172, 20);
            this.txtERPServer.TabIndex = 3;
            // 
            // txtReportingServerURL
            // 
            this.txtReportingServerURL.Location = new System.Drawing.Point(224, 33);
            this.txtReportingServerURL.Name = "txtReportingServerURL";
            this.txtReportingServerURL.Size = new System.Drawing.Size(477, 20);
            this.txtReportingServerURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Specify the reporting server URL:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ERP database connection: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "LYNQ database connection:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtERPPassword
            // 
            this.txtERPPassword.Location = new System.Drawing.Point(274, 266);
            this.txtERPPassword.Name = "txtERPPassword";
            this.txtERPPassword.Size = new System.Drawing.Size(173, 20);
            this.txtERPPassword.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "User name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "ERP Credentials";
            // 
            // txtERPUserName
            // 
            this.txtERPUserName.Location = new System.Drawing.Point(274, 223);
            this.txtERPUserName.Name = "txtERPUserName";
            this.txtERPUserName.Size = new System.Drawing.Size(173, 20);
            this.txtERPUserName.TabIndex = 7;
            this.txtERPUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(275, 308);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(173, 28);
            this.btnDeploy.TabIndex = 11;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Database";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(221, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Server";
            // 
            // txtERPDatabase
            // 
            this.txtERPDatabase.Location = new System.Drawing.Point(536, 115);
            this.txtERPDatabase.Name = "txtERPDatabase";
            this.txtERPDatabase.Size = new System.Drawing.Size(164, 20);
            this.txtERPDatabase.TabIndex = 4;
            this.txtERPDatabase.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtLynqDatabase
            // 
            this.txtLynqDatabase.Location = new System.Drawing.Point(536, 153);
            this.txtLynqDatabase.Name = "txtLynqDatabase";
            this.txtLynqDatabase.Size = new System.Drawing.Size(165, 20);
            this.txtLynqDatabase.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Server";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(470, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Database";
            // 
            // txtLynqServer
            // 
            this.txtLynqServer.Location = new System.Drawing.Point(276, 153);
            this.txtLynqServer.Name = "txtLynqServer";
            this.txtLynqServer.Size = new System.Drawing.Size(171, 20);
            this.txtLynqServer.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(473, 315);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(232, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "I dont have LYNQ folder on reporting server";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtSSRSPassword
            // 
            this.txtSSRSPassword.Location = new System.Drawing.Point(536, 70);
            this.txtSSRSPassword.Name = "txtSSRSPassword";
            this.txtSSRSPassword.Size = new System.Drawing.Size(165, 20);
            this.txtSSRSPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "User name:";
            // 
            // txtSSRSUserName
            // 
            this.txtSSRSUserName.Location = new System.Drawing.Point(288, 70);
            this.txtSSRSUserName.Name = "txtSSRSUserName";
            this.txtSSRSUserName.Size = new System.Drawing.Size(159, 20);
            this.txtSSRSUserName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "SSRS Credentials:";
            // 
            // txtLYNQPassword
            // 
            this.txtLYNQPassword.Location = new System.Drawing.Point(536, 266);
            this.txtLYNQPassword.Name = "txtLYNQPassword";
            this.txtLYNQPassword.Size = new System.Drawing.Size(173, 20);
            this.txtLYNQPassword.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(465, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Password:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(460, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "User name:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(533, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "LYNQ Credentials";
            // 
            // txtLYNQUserName
            // 
            this.txtLYNQUserName.Location = new System.Drawing.Point(536, 223);
            this.txtLYNQUserName.Name = "txtLYNQUserName";
            this.txtLYNQUserName.Size = new System.Drawing.Size(173, 20);
            this.txtLYNQUserName.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 358);
            this.Controls.Add(this.txtLYNQPassword);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtLYNQUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSSRSPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSSRSUserName);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtLynqDatabase);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtLynqServer);
            this.Controls.Add(this.txtERPDatabase);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.txtERPPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtERPUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReportingServerURL);
            this.Controls.Add(this.txtERPServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Deployment wizard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtERPServer;
        private System.Windows.Forms.TextBox txtReportingServerURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtERPPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtERPUserName;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtERPDatabase;
        private System.Windows.Forms.TextBox txtLynqDatabase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLynqServer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtSSRSPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSSRSUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLYNQPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLYNQUserName;
    }
}

