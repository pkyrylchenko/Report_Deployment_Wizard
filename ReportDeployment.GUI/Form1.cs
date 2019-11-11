using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;
using ReportDeployment.Logic;


namespace ReportDeployment.GUI
    

{
   
    public partial class Form1 : Form 
    {
        public ReportDeployment.Logic.ErrorInfo Error { get; set; }

        public Form1()
        {
            Error = new ErrorInfo();
            Error = ReportDeployment.Logic.Program.checkForSSRS();
            InitializeComponent();
            if (!Error.IsOk)
            {
                MessageBox.Show(Error.ErrMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click( object sender, EventArgs e )
        {

        }
        private void label3_Click( object sender, EventArgs e )
        {

        }
        private void label2_Click( object sender, EventArgs e )
        {

        }



        private void btnDeploy_Click(object sender, EventArgs e) 
        {
            Error = new ErrorInfo();


            string scriptFileDS = "";
            string scriptDS = "";
            scriptFileDS = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, _const.C_CreateDataSource);

            if( File.Exists( scriptFileDS ) )
            {
                // Read entire text file content in one string  
                scriptDS = File.ReadAllText( scriptFileDS );
                Console.WriteLine( scriptDS );
            }
            bool folderOK = true;
            if (checkBox1.Checked == true)
            {
                Error = Program.CreateFolder(txtReportingServerURL.Text);
            }
            else
            {
                Error.IsOk = true;
            }

            if (Error.IsOk)
            {
                Regex urlFormat = new Regex("http://*|https://*");
                // run our script
                if (folderOK)
                {
                    if (urlFormat.IsMatch(txtReportingServerURL.Text))
                    {
                        Error = Program.checkURL(txtReportingServerURL.Text);
                    
                        if (Error.IsOk)
                        {
                            if (txtERPDatabase.Text != "" && txtERPServer.Text != "" && txtReportingServerURL.Text != "" && txtERPUserName.Text != "" &&
                            txtERPPassword.Text != "" && txtLynqDatabase.Text != "" && txtLynqServer.Text != "")
                            {
                                Error = Program.checkDatabaseConnection(txtERPServer.Text, txtERPDatabase.Text, txtERPUserName.Text, txtERPPassword.Text, 1);
                                if (Error.IsOk)
                                {
                                    Error = Program.checkDatabaseConnection(txtLynqServer.Text, txtLynqDatabase.Text, txtERPUserName.Text, txtERPPassword.Text, 2);
                                    if(Error.IsOk)
                                    {
                                        Error = Program.RunScript(Program.LoadScript(scriptFileDS), 1, txtReportingServerURL.Text, txtERPServer.Text, txtERPDatabase.Text, txtERPUserName.Text, txtERPPassword.Text, txtSSRSUserName.Text, txtSSRSPassword.Text);
                                        if (Error.IsOk)
                                        {
                                            Error = Program.RunScript(Program.LoadScript(scriptFileDS), 2, txtReportingServerURL.Text, txtLynqServer.Text, txtLynqDatabase.Text, txtLYNQUserName.Text, txtLYNQPassword.Text, txtSSRSUserName.Text, txtSSRSPassword.Text);
                                            if (Error.IsOk)
                                            {
                                                Program.deployReports(txtReportingServerURL.Text);

                                                MessageBox.Show("Deployed Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            }
                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill in all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid URL format\nExample: http://ServerName/ReportServer ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (!Error.IsOk)
            {
                MessageBox.Show(Error.ErrMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
}

