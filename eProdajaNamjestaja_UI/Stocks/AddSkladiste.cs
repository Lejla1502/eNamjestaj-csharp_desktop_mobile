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
    public partial class AddSkladiste : Form
    {
        WeAPIHelper skladistaService = new WeAPIHelper("http://localhost:5966/", "api/Skladista");

        

        public AddSkladiste()
        {
            InitializeComponent();
            dtSkladista.AutoGenerateColumns = false;
            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddSkladiste_Load(object sender, EventArgs e)
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
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Skladista s = new Skladista();
                s.Naziv = txtNaziv.Text;
                s.Adresa = txtAdresa.Text;
                s.Opis = txtOpis.Text;

                HttpResponseMessage response1 = skladistaService.GetActionResponse("ProvjeraNaziv", txtNaziv.Text);
                if (response1.IsSuccessStatusCode)
                {
                    int id = response1.Content.ReadAsAsync<int>().Result;
                    if (id != 0)
                    {
                        MessageBox.Show(txtNaziv, Global.GetMessage("skladiste_exists"));
                        txtNaziv.Text = "";
                    }
                    else
                    {
                        HttpResponseMessage response = skladistaService.PostResponse(s);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show(Global.GetMessage("skladiste_succ"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindForm();
                            ClearInput();
                        }
                        else
                        {
                            MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
                        }
                    }
                }
            }
        }

        private void ClearInput()
        {
            txtNaziv.Text = txtAdresa.Text = txtOpis.Text = "";
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNaziv.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, Global.GetMessage("naziv_req"));

            }
            else if (txtNaziv.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, Global.GetMessage("naziv_req_lenth"));
            }
            else
            {
                errorProvider1.SetError(txtNaziv, "");
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAdresa.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdresa, Global.GetMessage("adresa_req"));

            }
            else if (txtAdresa.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdresa, Global.GetMessage("adresa_req_length"));
            }
            else
            {
                errorProvider1.SetError(txtAdresa, "");
            }
        }

       
    }
}
