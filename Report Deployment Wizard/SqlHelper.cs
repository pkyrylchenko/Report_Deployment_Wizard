using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DynamicallyConnectionString
{
    
    public class SqlHelper
    {
        SqlConnection cn;
        /*
        * Method:		SqlHelper
        * Purpose:		constructor method for building SqlConnection object
        * Parameters:	database connection string
        * Return:		SqlConnection object
        */
        public SqlHelper (string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }

        /*
       * Method:		isConnection
       * Purpose:		checks if connection was succesfull
       * Parameters:	none
       * Return:		bool
       */
        public bool isConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }


    }
}
