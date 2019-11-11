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


namespace ReportDeployment.GUI
{
    public static class Run 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1() );
            
        }



    }
}

