using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaNamjestaja_UI
{
   public  class DAOrders
    {
        public static void SelectOrdersTotal(DSOrders.OrdersTotalDataTable dtOrdersTotal)
        {
            dtOrdersTotal.Clear();
            SqlConnection cn = Connection.GetConnection();

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("esp_Narudzbe_TotalByYearAndMonth", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOrdersTotal);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
