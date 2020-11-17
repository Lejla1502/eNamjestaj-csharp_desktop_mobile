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

namespace eProdajaNamjestaja_UI.Consumers
{
    public partial class PretragaKupaca : Form
    {
        WeAPIHelper kupciService = new WeAPIHelper("http://localhost:5966/", "api/Kupci");

        public PretragaKupaca()
        {
            InitializeComponent();
            dtKupci.AutoGenerateColumns = false;
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = kupciService.GetActionResponse("SearchKupci", txtImePrezime.Text.Trim());
            if (response.IsSuccessStatusCode)
            {
                List<Kupci> kupci = response.Content.ReadAsAsync<List<Kupci>>().Result;
                dtKupci.AutoGenerateColumns = false;
                dtKupci.DataSource = kupci;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
            }
        }

        private void BindForm()
        {
            HttpResponseMessage response = kupciService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<Kupci> kupci = response.Content.ReadAsAsync<List<Kupci>>().Result;
                dtKupci.DataSource = kupci;
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNarudzbe_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtKupci.SelectedRows[0].Cells[0].Value);
           
            NarudzbaKupaca a = new NarudzbaKupaca(id);
            a.Show();
        }

        private void PretragaKupaca_Load(object sender, EventArgs e)
        {
            BindForm();
        }
    }
}
