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

namespace eProdajaNamjestaja_UI.Users
{
    public partial class PretragaKorisnika : Form
    {
         WeAPIHelper korisniciService = new WeAPIHelper("http://localhost:5966/", "/api/Korisnici");

        public PretragaKorisnika()
        {
            InitializeComponent();
            dtKorisnici.AutoGenerateColumns = false;
        }

        private void PretragaKorisnika_Load(object sender, EventArgs e)
        {
            BindForm();
        }

        private void BindForm()
        {
            HttpResponseMessage response = korisniciService.GetActionResponse("SearchKorisnici",tbxImePRezime.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<Korisnici> korisnici = response.Content.ReadAsAsync<List<Korisnici>>().Result;
                dtKorisnici.DataSource = korisnici;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }

        private void btnNoviKorisnik_Click(object sender, EventArgs e)
        {
            KorisniciForm frm = new KorisniciForm(0);
            frm.ShowDialog();
            BindForm();
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            BindForm();
        }

        private void dtKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            Global.selektovaniKorisnik=(Korisnici)dtKorisnici.CurrentRow.DataBoundItem;
            int id = Global.selektovaniKorisnik.KorisnikID;
            
            KorisniciForm frm = new KorisniciForm(id);
            frm.ShowDialog();
            BindForm();
            
        }

        
    }
}
