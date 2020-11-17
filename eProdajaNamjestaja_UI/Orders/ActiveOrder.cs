using eProdajaNamjestaja_API.Models;
using eProdajaNamjestaja_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaNamjestaja_UI.Orders
{
    public partial class ActiveOrder : Form
    {
        WeAPIHelper serviceNarudzbe = new WeAPIHelper("http://localhost:5966/", "api/Narudzbe");
        private List<esp_Narudzbe_SelectAktivne_Result> narudzbe { get; set; }

        
        public ActiveOrder()
        {
            InitializeComponent();
            narudzbeGrid.AutoGenerateColumns = true;
            
        }

        private void ActiveOrder_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            
                HttpResponseMessage response = serviceNarudzbe.GetActionResponse("GetAktivneNarudzbe");

                if (response.IsSuccessStatusCode)
                {
                    narudzbe = response.Content.ReadAsAsync<List<esp_Narudzbe_SelectAktivne_Result>>().Result;
                    narudzbeGrid.DataSource = narudzbe;
                    narudzbeGrid.Columns[0].Visible = false;
                    narudzbeGrid.Columns[2].Visible = false;
                }
                else
                    MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
            
        }

        private void narudzbeGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            OrderDetails frm = new OrderDetails(narudzbe[e.RowIndex]);
            frm.ShowDialog();
            BindGrid();
        }
    }
}
