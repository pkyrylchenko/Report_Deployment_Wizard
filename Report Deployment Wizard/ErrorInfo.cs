using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDeployment.Logic
{
    public class ErrorInfo
    {
        #region Properties
        public bool IsOk { get; set; }

        public string ErrCode { get; set; }

        public string ErrMessage { get; set; }
        #endregion
    }
}
