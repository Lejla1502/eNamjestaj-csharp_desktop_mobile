using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eProdajaNamjestaja_UI
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.eNamjestajConnectionString);
            cn.Open();
            return cn;
        }
    }
}