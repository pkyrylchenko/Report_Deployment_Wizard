using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Deployment_Wizard
{
    public class _const
    {
        #region script const
        public const string C_CreateDataSource = "dsCreate.ps1"; 
        #endregion
        #region shared ds path
        public const string C_SharedDSPath = "/";
        #endregion
        #region ERP DS name
        public const string C_ERPSharedDSName = "LYNQmomERP";
        #endregion
        #region LYNQ DS name
        public const string C_LYNQSharedDSName = "LYNQmom";
        #endregion
        #region RS.EXE path
        public const string C_RS_EXE_PATH = @"C:\Program Files\Microsoft SQL Server Reporting Services\Shared Tools";
        #endregion
        #region deploy reports script path
        public const string C_DeployReportsScriptPath = @"C:\Tools\RDL\rss\deploy.rss";
        #endregion
        #region registry ssrs location
        public const string C_RegistrySSRSLocation = @"SOFTWARE\Microsoft\Microsoft SQL Server\SSRS";
        #endregion
    }
}
