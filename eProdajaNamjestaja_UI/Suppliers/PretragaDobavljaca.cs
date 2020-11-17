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

namespace eProdajaNamjestaja_UI.Suppliers
{
    public partial class PretragaDobavljaca : Form
    {
        WeAPIHelper dobavljaciService = new WeAPIHelper("http://localhost:5966/", "api/Dobavljaci");

        public PretragaDobavljaca()
        {
            InitializeComponent();
            dtDobavljaci.AutoGenerateColumns = false;
        }

        private void PretragaDobavljaca_Load(object sender, EventArgs e)
        {
            BindForm();
        }

        private void BindForm()
        {
            HttpResponseMessage response = dobavljaciService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Dobavljaci> dobavljaci = response.Content.ReadAsAsync<List<Dobavljaci>>().Result;

                dtDobavljaci.DataSource = dobavljaci;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = dobavljaciService.GetActionResponse("SearchDobavljaci", txtNaziv.Text.Trim());
            if (response.IsSuccessStatusCode)
            {
                List<Dobavljaci> dobavljaci = response.Content.ReadAsAsync<List<Dobavljaci>>().Result;
                dtDobavljaci.AutoGenerateColumns = false;
                dtDobavljaci.DataSource = dobavljaci;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNoviDobavljac_Click(object sender, EventArgs e)
        {
            AddDobavljac ad = new AddDobavljac();
            ad.ShowDialog();
            BindForm();
        }
    }
}
