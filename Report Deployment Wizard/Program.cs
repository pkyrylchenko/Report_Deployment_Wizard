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
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using ReportDeployment.Logic.ReportService2010;
using System.Xml.Linq;


namespace ReportDeployment.Logic
{
    public static class Program 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            

          
            
        }

        /*
	     * Method:	LoadScript
	     * Purpose:	Builds a script string for shared data sources deployment from a .ps1 file
	     * Parameters:  file name as a string
	     * Return:	script string
	     */
        public static string LoadScript(string filename)
        {
            try
            {
                // Create an instance of StreamReader to read from our file. 
                // The using statement also closes the StreamReader. 
                using (StreamReader sr = new StreamReader(filename))
                {

                    // use a string builder to get all our lines from the file 
                    StringBuilder fileContents = new StringBuilder();

                    // string to hold the current line 
                    string curLine;

                    // loop through our file and read each line into our 
                    // stringbuilder as we go along 
                    while ((curLine = sr.ReadLine()) != null)
                    {
                        // read each line and MAKE SURE YOU ADD BACK THE 
                        // LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF 
                        fileContents.Append(curLine + "\n");
                    }

                    // call RunScript and pass in our file contents 
                    // converted to a string 
                    return fileContents.ToString();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong. 
                string errorText = "The file could not be read:";
                errorText += e.Message + "\n";
                return errorText;
            }

        }


        /*
	     * Method:	CreateFolder
	     * Purpose: Creates LYNQ folder on report server, using xml createFolder.xml document located in C:/Tools/RDL/createFolder/createFOlder.xml
	     * Parameters:  none
	     * Return:	bool	
	     */
        public static ErrorInfo CreateFolder(string url)
        {
            ErrorInfo result = new ErrorInfo();

            


            ReportService2010.ReportingService2010 reportingServicesClient = new ReportService2010.ReportingService2010();
            reportingServicesClient.Url = url + @"/ReportService2010.asmx";
            reportingServicesClient.Credentials = CredentialCache.DefaultCredentials;
            XDocument xmlDoc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "createFolder.xml"));
            try
            {
                var rowLst = from c in xmlDoc.Descendants("Folder")
                             select new
                             {
                                 name = (string)c.Element("Name").Value,
                                 parentFolder = (string)c.Element("ParentFolder").Value
                             };
                foreach (var row in rowLst)
                {
                    reportingServicesClient.CreateFolder(row.name, row.parentFolder, null);
                    Console.WriteLine(string.Format("Folder {0} created Successfully", row.name));
                    result.IsOk = true;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.IsOk = false;
                result.ErrCode = e.Message;
                result.ErrMessage = "LYNQ folder already exists";
                return result;
            }
        }
       
    


        /*
	     * Method:	    RunScript	
	     * Purpose:	    Creates two shared datasources on report server in home folder, by invoking powershell runspace
	     * Parameters:	sctipt string, int mode 1 - create ERP datasource 2 - create LYNQ datasource, reporting server URL as a string, server name as a string, database name as a string,
         *              user name as a string, password as a string
	     * Return:		void
	     */
        public static ErrorInfo RunScript(string scriptText, int mode, string txtReportingServerURL, string txtServer, string txtDatabase, string txtUserName, string txtPassword, string txtSSRSUserName, string txtSSRSPassword )
        {
            ErrorInfo result = new ErrorInfo();
            // create Powershell runspace 
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it 
            runspace.Open();

            // create a pipeline and feed it the script text 
            Pipeline pipeline = runspace.CreatePipeline();

            pipeline.Commands.AddScript(scriptText);


            pipeline.Invoke();
            pipeline.Commands.Clear();


            Command myCommand = new Command("New-SSRSDataSource");
            if (mode == 1)
            {

                CommandParameter dsName = new CommandParameter("DataSourceName", _const.C_ERPSharedDSName);
                myCommand.Parameters.Add(dsName);

                CommandParameter dsPath = new CommandParameter("path", _const.C_SharedDSPath);
                myCommand.Parameters.Add(dsPath);
                CommandParameter dsReportWebService = new CommandParameter("reportWebService", txtReportingServerURL);
                myCommand.Parameters.Add(dsReportWebService);
                CommandParameter dsConnectionString = new CommandParameter("connectString", "Data Source = " + txtServer + "; Initial Catalog = " + txtDatabase);
                myCommand.Parameters.Add(dsConnectionString);

            }
            else
            {

                CommandParameter dsName = new CommandParameter("DataSourceName", _const.C_LYNQSharedDSName);
                myCommand.Parameters.Add(dsName);
                CommandParameter dsPath = new CommandParameter("path", _const.C_SharedDSPath);
                myCommand.Parameters.Add(dsPath);
                CommandParameter dsReportWebService = new CommandParameter("reportWebService", txtReportingServerURL);
                myCommand.Parameters.Add(dsReportWebService);
                CommandParameter dsConnectionString = new CommandParameter("connectString", "Data Source = " + txtServer + "; Initial Catalog = " + txtDatabase);
                myCommand.Parameters.Add(dsConnectionString);

            }
            CommandParameter dsUserName = new CommandParameter("username", txtUserName);
            myCommand.Parameters.Add(dsUserName);
            CommandParameter dsPassword = new CommandParameter("password", txtPassword);
            myCommand.Parameters.Add(dsPassword);
            CommandParameter dsExtension = new CommandParameter("Extension", "SQL");
            myCommand.Parameters.Add(dsExtension);
            string passwordString = txtSSRSPassword;

            // create credential variable for connection to ssrs server
            System.Security.SecureString password = new System.Security.SecureString();
            for (int i = 0; i < passwordString.Length; i++)
            {
                password.AppendChar(passwordString[i]);
            }
            password.MakeReadOnly();
            PSCredential Credential = new PSCredential(txtSSRSUserName, password);
            CommandParameter dsCredentials = new CommandParameter("credentials", Credential);
            myCommand.Parameters.Add(dsCredentials);

            Pipeline pipeline1 = runspace.CreatePipeline();
            pipeline1.Commands.Add(myCommand);
            try
            {
                pipeline1.Invoke();
                result.IsOk = true;
                return result;
            }
            catch (System.Management.Automation.CmdletInvocationException ex)
            {
                result.IsOk = false;
                result.ErrCode = ex.Message;
                result.ErrMessage = "Invalid URL address or SSRS credentials";
                
                return result;
            }
            catch(Exception ex)
            {
                result.IsOk = false;
                result.ErrMessage = ex.Message;
                return result;
            }
            // close the runspace 
            finally
            {
                runspace.Close();
            }
            
        }


        /*
	     * Method:		deployReports
	     * Purpose:		deploys all reports from the C:/Tools/RDL folder (if needed to be changed change path in VB script in RDL/rss folder) to the LYNQ folder on reporting server by using cmd 
         *              and calling rs.exe which is by default located in C:\Program Files\Microsoft SQL Server Reporting Services\Shared Tools
	     * Parameters:	reporting server URL as a string
	     * Return:		void
	     */
        public static void deployReports (string txtReportingServerURL)
        {
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine("cd "+ _const.C_RS_EXE_PATH);
            cmdProcess.StandardInput.Flush();
            cmdProcess.StandardInput.WriteLine("rs.exe -i \"" + _const.C_DeployReportsScriptPath + "\" -s " + txtReportingServerURL);
            cmdProcess.StandardInput.Close();
            cmdProcess.WaitForExit();
            Console.WriteLine(cmdProcess.StandardOutput.ReadToEnd());
            
        }

        /*
	     * Method:		check for SSRS
	     * Purpose:		checks is SSRS is installed on users machine
	     * Parameters:	none
	     * Return:		bool
	     */
        public static ErrorInfo checkForSSRS() 
         {
            ErrorInfo result = new ErrorInfo();
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey RK = hklm.OpenSubKey(_const.C_RegistrySSRSLocation, false);
                result.IsOk = (RK != null);

                result.ErrMessage = "Microsoft SQL Server Reporting Services are not installed";
                return result;
            }
        }

        /*
	     * Method:		checkDatabaseConnection
	     * Purpose:		checks if application is able to connect to the database and server
	     * Parameters:	server name as a string, database name as a string, user name as a string, password as a string, int mode 1 - create ERP datasource 2 - create LYNQ datasource
	     * Return:		bool
	     */
        public static ErrorInfo checkDatabaseConnection(string txtServer, string txtDatabase, string txtUserName, string txtPassword, int mode)
        {
            ErrorInfo result = new ErrorInfo();
            string connString = "Data Source = " + txtServer + "; Initial Catalog = " + txtDatabase + ";User ID=" + txtUserName + ";Password=" + txtPassword;
            try
            {
                DynamicallyConnectionString.SqlHelper helper = new DynamicallyConnectionString.SqlHelper(connString);
                if(helper.isConnection)
                {
                    result.IsOk = true;
                    
                }
                return result;
            }
            catch (Exception ex)
            {
                
                result.IsOk = false;
                result.ErrCode = ex.Message;
                result.ErrMessage = "Unable to connect to the database";
                
                return result;
            }
           

        }
         /*
	     * Method:		checkURL
	     * Purpose:		checks if specified URL adress is valid and reachable from application
	     * Parameters:	reporting server URL as a string
	     * Return:		bool
	     */
        public static ErrorInfo checkURL (string txtReportingServerURL)
        {
            ErrorInfo result = new ErrorInfo();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(txtReportingServerURL);
                request.UseDefaultCredentials = true;
                request.PreAuthenticate = true;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                bool temp = (response != null || response.StatusCode == HttpStatusCode.OK);
                if (!temp)
                {
                    result.IsOk = false;
                    result.ErrMessage = "Invalid URL address";
                }
                response.Close();
                result.IsOk = true;
                return result;
            }
            catch(Exception ex)
            {
                result.IsOk = false;
                result.ErrCode = ex.Message;
                result.ErrMessage = "Invalid URL address";
                return result;
            }
           
           
        }

    }
}

