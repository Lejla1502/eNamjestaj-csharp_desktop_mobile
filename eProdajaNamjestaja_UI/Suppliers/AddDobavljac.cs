using eProdajaNamjestaja_API.Models;
using eProdajaNamjestaja_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaNamjestaja_UI.Suppliers
{
    public partial class AddDobavljac : Form
    {
        WeAPIHelper dobavljaciService = new WeAPIHelper("http://localhost:5966/", "api/Dobavljaci");
        public AddDobavljac()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            dtDobavljaci.AutoGenerateColumns = false;
        }

        private void AddDobavljac_Load(object sender, EventArgs e)
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

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            this.Close();
            PretragaDobavljaca f = new PretragaDobavljaca();
            f.Show();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Dobavljaci d = new Dobavljaci();
                d.Naziv = txtNaziv.Text;
                d.KontaktOsoba = txtKontakt.Text;
                d.Adresa = txtAdresa.Text;
                d.Mail = txtMail.Text;
                d.Telefon = txtTelefon.Text;
                d.Fax = txtFaks.Text;
                d.Statusa = true;
                d.Web = txtWeb.Text;
                d.ZiroRacun = txtZiroRacun.Text;
                d.Napomena = txtNapomena.Text;

                HttpResponseMessage response1 = dobavljaciService.GetActionResponse("ProvjeraNaziv", txtNaziv.Text);
                if (response1.IsSuccessStatusCode)
                {
                    int id = response1.Content.ReadAsAsync<int>().Result;
                    if (id != 0)
                    {
                        MessageBox.Show(txtNaziv, Global.GetMessage("dobavljac_exists"));
                        txtNaziv.Text = "";
                    }
                    else
                    {
                        HttpResponseMessage r3 = dobavljaciService.GetActionResponse("ProvjeraZiroRacun", txtZiroRacun.Text);
                                if (r3.IsSuccessStatusCode)
                                {
                                    int id3 = r3.Content.ReadAsAsync<int>().Result;
                                    if (id3 != 0)
                                    {
                                        MessageBox.Show(txtZiroRacun, Global.GetMessage("dobavljac_zracun_exists"));
                                        txtZiroRacun.Text = "";
                                    }
                                    else
                                    {
                                        HttpResponseMessage response = dobavljaciService.PostResponse(d);

                                        if (response.IsSuccessStatusCode)
                                        {
                                            MessageBox.Show(Global.GetMessage("dobavljac_succ"));
                                            BindForm();
                                            ClearInput();

                                        }
                                        else
                                        {
                                            MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

                                        }
                                }
                            }
                        }
                    }
                else
                {
                    MessageBox.Show("Error Code:" + response1.StatusCode + "Message:" + response1.ReasonPhrase);
                }
            }
        }

        private void ClearInput()
        {
            txtNaziv.Text = txtKontakt.Text = txtAdresa.Text = txtMail.Text = txtTelefon.Text =txtWeb.Text=txtZiroRacun.Text=txtNapomena.Text= "";
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, Global.GetMessage("nazivDobavljaca_req"));
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

        private void txtKontakt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKontakt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKontakt, Global.GetMessage("kontakt_req"));
            }
            else if (txtKontakt.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKontakt, Global.GetMessage("kontakt_req_lenth"));
            }
            else
            {
                errorProvider1.SetError(txtKontakt, "");
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdresa.Text))
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

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            

            if (!txtTelefon.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTelefon, Global.GetMessage("telefon_req"));
            }
            else
            {
                errorProvider1.SetError(txtTelefon, "");
            }
        }

        private void txtFaks_Validating(object sender, CancelEventArgs e)
        {
            if (!txtFaks.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFaks, Global.GetMessage("faks_req"));
            }
            else if (txtFaks.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFaks, Global.GetMessage("faks_req_length"));
            }
            else
            {
               
                errorProvider1.SetError(txtFaks, "");
            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMail, Global.GetMessage("mail1_req"));
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(txtMail.Text);
                    errorProvider1.SetError(txtMail, "");
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtMail, Global.GetMessage("mail_error"));

                }
            }
        }

        private void txtWeb_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtWeb.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtWeb, Global.GetMessage("web_req"));
            }
            
            else
            {
                errorProvider1.SetError(txtWeb, "");
            }
        }

        private void txtZiroRacun_Validating(object sender, CancelEventArgs e)
        {
            if (!txtZiroRacun.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtZiroRacun, Global.GetMessage("ziroRac_req"));
            }
            else
            {
                errorProvider1.SetError(txtZiroRacun, "");
            }
        }
    }
}
