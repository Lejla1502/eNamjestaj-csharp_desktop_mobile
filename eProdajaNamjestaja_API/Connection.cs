using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eProdajaNamjestaja_API
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection("");
            cn.Open();
            return cn;
        }
    }
}