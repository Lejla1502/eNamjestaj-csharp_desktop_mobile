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

namespace eProdajaNamjestaja_UI.Stocks
{
    public partial class PretragaSkladista : Form
    {
        WeAPIHelper skladistaService = new WeAPIHelper("http://localhost:5966/", "api/Skladista");

        public PretragaSkladista()
        {
            InitializeComponent();
            dtSkladista.AutoGenerateColumns = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovoSkladiste_Click(object sender, EventArgs e)
        {
            AddSkladiste f= new AddSkladiste();
            f.ShowDialog();
            BindForm();
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = skladistaService.GetActionResponse("SearchSkladista", txtNaziv.Text.Trim());
            if (response.IsSuccessStatusCode)
            {
                List<Skladista> skladista = response.Content.ReadAsAsync<List<Skladista>>().Result;
                dtSkladista.DataSource = skladista;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void PretragaSkladista_Load(object sender, EventArgs e)
        {
            BindForm();
        }

        private void BindForm()
        {
            HttpResponseMessage response = skladistaService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Skladista> skladista = response.Content.ReadAsAsync<List<Skladista>>().Result;
                
                dtSkladista.DataSource = skladista;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }
    }
}
