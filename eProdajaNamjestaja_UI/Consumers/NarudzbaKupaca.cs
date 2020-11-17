using eProdajaNamjestaja_API.Models;
using eProdajaNamjestaja_PCL1.Model;
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

namespace eProdajaNamjestaja_UI.Consumers
{
    public partial class NarudzbaKupaca : Form
    {
        WeAPIHelper serviceNarudzbe = new WeAPIHelper("http://localhost:5966/", "api/Narudzbe");
        
        private List<esp_Narudzbe_SelectByKupacId_Result> narudzbeByKupac { get; set; }

        int kupacId = 0;
        public NarudzbaKupaca(int kupacId)
        {
            InitializeComponent();
            this.kupacId = kupacId;
        }

        private void NarudzbaKupaca_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = serviceNarudzbe.GetActionResponse("GetNarudzbeByKupacId", kupacId.ToString());
            if (response.IsSuccessStatusCode)
            {
                narudzbeByKupac = response.Content.ReadAsAsync<List<esp_Narudzbe_SelectByKupacId_Result>>().Result;
                dataGridView1.DataSource = narudzbeByKupac;
            }
            else
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
        }
    }
}
