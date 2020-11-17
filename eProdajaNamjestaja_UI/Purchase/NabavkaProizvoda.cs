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
using static eProdajaNamjestaja_UI.Global;

namespace eProdajaNamjestaja_UI.Purchase
{
    public partial class
        NabavkaProizvoda : Form
    {
        WeAPIHelper dobavljaciService = new WeAPIHelper("http://localhost:5966/", "api/Dobavljaci");
        WeAPIHelper skladistaService = new WeAPIHelper("http://localhost:5966/", "api/Skladista");
        WeAPIHelper proizvodiService = new WeAPIHelper("http://localhost:5966/", "api/Proizvodi");
        WeAPIHelper ulaziService = new WeAPIHelper("http://localhost:5966/", "api/Ulazi");

        List<PomProizvod> lista = new List<PomProizvod>();
        List<Proizvodi> listP = new List<Proizvodi>();
        List<Proizvodi> proizvod;
        int proizvodId = 0;
        int iznos = 0;


        public string a { get; set; }
        
        public NabavkaProizvoda()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            dtProizvodi.AutoGenerateColumns = false;
        }
        

        private void NabavkaProizvoda_Load(object sender, EventArgs e)
        {
            txtCijena.PromptChar = '0';
            LoadDobavljaci();
            LoadSkladista();
            LoadProizvodi();
        }

        private void LoadProizvodi()
        {
            HttpResponseMessage response = proizvodiService.GetResponse("SviProizvodi");

            if (response.IsSuccessStatusCode)
            {
                proizvod = response.Content.ReadAsAsync<List<Proizvodi>>().Result;
                proizvod.Insert(0, new Proizvodi());
                proizvod[0].Naziv = "Odberite proizvod";
                cmx_proizvodi.DataSource = proizvod;
                cmx_proizvodi.DisplayMember = "Naziv";
                cmx_proizvodi.ValueMember = "ProizvodID";
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void LoadSkladista()
        {
            HttpResponseMessage response = skladistaService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Skladista> skladista = response.Content.ReadAsAsync<List<Skladista>>().Result;
                skladista.Insert(0, new Skladista());
                skladista[0].Naziv = "Odberite skladiste";
                cmbSkladiste.DataSource = skladista;
                cmbSkladiste.DisplayMember = "Naziv";
                cmbSkladiste.ValueMember = "SkladistaID";
            }

            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void LoadDobavljaci()
        {
            HttpResponseMessage response = dobavljaciService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Dobavljaci> dobavljaci = response.Content.ReadAsAsync<List<Dobavljaci>>().Result;
                dobavljaci.Insert(0, new Dobavljaci());
                dobavljaci[0].Naziv = "Odaberite dobavljaca";
                cmbDobavljaci.DataSource = dobavljaci;
                cmbDobavljaci.DisplayMember = "Naziv";
                cmbDobavljaci.ValueMember = "DobavljacID";
            }
            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

            }
        }

        private void btnNovoSkladiste_Click(object sender, EventArgs e)
        {
            Stocks.AddSkladiste f = new Stocks.AddSkladiste();
            f.ShowDialog();
            LoadSkladista();
        }


        private void btnNoviDobavljac_Click(object sender, EventArgs e)
        {
            Suppliers.AddDobavljac f = new Suppliers.AddDobavljac();
            f.ShowDialog();
            LoadDobavljaci();
        }

        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (dtProizvodi.DataSource != null)
                {
                    int id = Global.prijavljeniKorisnik.KorisnikID;

                    Ulazi ulaz = new Ulazi();
                    ulaz.BrojFakture = txtBrojFakture.Text;
                    ulaz.Datum = dateTimePicker1.Value;
                    ulaz.KorisnikID = id;
                    ulaz.DobavljacID = Convert.ToInt32(cmbDobavljaci.SelectedValue);
                    ulaz.SkladisteID = Convert.ToInt32(cmbSkladiste.SelectedValue);
                    ulaz.IznosRacuna = Convert.ToDecimal(txtIznos.Text);
                    ulaz.PDV = Convert.ToDecimal(txtPDV.Text);
                    ulaz.Napomena = txtNapomena.Text;

                    int brojac = dtProizvodi.RowCount;
                    for (int i=0;i<lista.Count();i++)
                    {
                        UlaziStavke ulazStavka = new UlaziStavke();
                        ulazStavka.ProizvodID = lista[i].Proizvod1ID;
                        ulazStavka.Kolicina =lista[i].Kolicina1;
                        ulazStavka.Cijena =lista[i].Cijena1;
                        ulaz.UlaziStavke.Add(ulazStavka);
                    }

                    HttpResponseMessage response = ulaziService.PostResponse(ulaz);
                    if (response.IsSuccessStatusCode)
                    {

                        MessageBox.Show("Evidencija uspješno obavljena.");
                        Global.proizvodiNabavke = new List<PomProizvod>();
                        Global.proizvodiNabavke= lista;
                        ClearInput();
                        iznos = 0;
                        lista.Clear();
                        dtProizvodi.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
                    }
                }
                else
                {
                    MessageBox.Show("Dodajte proizvod!!");
                }

            }
            else
            {
                lbl_error.Visible = true;
                
            }

        }

        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            Products.AddProizvod aa = new Products.AddProizvod();
            aa.ShowDialog();
            LoadProizvodi();
        }




        private void ClearInput()
        {
            cmx_proizvodi.SelectedValue = "";
            txtBrojFakture.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtIznos.Text = null;
            txtCijena.Text = "";
            txtPDV.Text = null;
            txtSifra.Text = "";
            txtKolicina.Text = "";
            txtNapomena.Text = "";
            cmbSkladiste.SelectedValue = "";
            cmbDobavljaci.SelectedValue = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void txtKolicina_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }
        

        private void txtBrojFakture_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }

        private void txtSifra_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSifra.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSifra, Global.GetMessage("sifra_error"));
            }
            else
            {
                errorProvider1.SetError(txtSifra, "");
            }
        }

        private void txtKolicina_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKolicina.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKolicina, Global.GetMessage("Kolicina_error"));
            }
            else
            {
                errorProvider1.SetError(txtKolicina, "");
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            txtCijena.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (txtCijena.Text == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCijena, Global.GetMessage("cijena_req"));
            }


            else
            {
                txtCijena.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                errorProvider1.SetError(txtCijena, "");
            }
        }

        private void cmx_proizvodi_Validating(object sender, CancelEventArgs e)
        {
            if (cmx_proizvodi.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmx_proizvodi, "Obavezno odaberite proizvod !");
            }
            else
            {

                errorProvider1.SetError(cmx_proizvodi, "");
              }
        }

        private void cmbSkladiste_Validating_1(object sender, CancelEventArgs e)
        {
            if (cmbSkladiste.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbSkladiste, "Obavezno odaberite skladište !");
            }
            else
            {
                errorProvider1.SetError(cmbSkladiste, "");
            }
        }

        private void txtBrojFakture_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrojFakture.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBrojFakture, Global.GetMessage("faktura_error"));
            }
            else
            {
                errorProvider1.SetError(txtBrojFakture, "");
            }
        }

        private void cmbDobavljaci_Validating_1(object sender, CancelEventArgs e)
        {
            if (cmbDobavljaci.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbDobavljaci, "Obavezno odaberite dobavljača !");
            }
            else
            {
                errorProvider1.SetError(cmbDobavljaci, "");
            }
        }

        private void txtNapomena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNapomena.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNapomena, Global.GetMessage("napomena_error"));
            }
            else
            {
                errorProvider1.SetError(txtNapomena, "");
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDodajProizvod_Validating(object sender, CancelEventArgs e)
        {

            if (btnDodajProizvod == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(btnDodajProizvod, "EVIDENTIRAJ PROIZVOD!");
            }
            else
            {
                errorProvider1.SetError(btnDodajProizvod, "");
            }
        }

        private void btnProvjera_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response1 = proizvodiService.GetActionResponse("Provjera", txtSifra.Text);

            if (response1.IsSuccessStatusCode)
            {
                proizvodId = response1.Content.ReadAsAsync<int>().Result;

                if (proizvodId != 0)
                {
                    MessageBox.Show("Unesena ispravna sifra");


                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Proizvod sa ukucanom sifrom ne postoji, zelite li dodati proizvod?", "Proizvod", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        txtSifra.Text = "";
                        Products.AddProizvod frm = new Products.AddProizvod();
                        frm.Show();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        txtSifra.Text = "";
                    }
                }
            }
        }

        private void cmx_proizvodi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmx_proizvodi.SelectedIndex != 0)
                txtSifra.Text = proizvod.Where(x => x.ProizvodID == Convert.ToInt32(cmx_proizvodi.SelectedValue)).FirstOrDefault().Sifra;
            else
                txtSifra.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCijena.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (cmx_proizvodi.SelectedIndex == 0 || string.IsNullOrEmpty(txtKolicina.Text)
                || txtCijena.Text==string.Empty || string.IsNullOrEmpty(txtSifra.Text))
                MessageBox.Show("Popunite odgovarajuca polja (proizvod, kolicina i cijena)!");
            else
            {
                txtCijena.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                dtProizvodi.DataSource = null;
                bool postoji = false;
                for (int i = 0; i < lista.Count(); i++)
                {
                    if (Convert.ToInt32(cmx_proizvodi.SelectedValue) == lista[i].Proizvod1ID)
                    {
                        if (Convert.ToDecimal(txtCijena.Text) == lista[i].Cijena1)
                        {
                            lista[i].Kolicina1 += Convert.ToInt32(txtKolicina.Text);
                            iznos += (Convert.ToInt32(lista[i].Cijena1) * Convert.ToInt32(txtKolicina.Text));
                            postoji = true;
                        }
                        else
                        {
                            postoji = true;
                            MessageBox.Show("Pokušavate izvršiti nabavku za već odabrani proizvod s drukčijom cijenom!!!!");
                            break;
                        }
                    }
                }

                if (!postoji)
                {
                    PomProizvod p = new PomProizvod();
                    p.Kolicina1 = Convert.ToInt32(txtKolicina.Text);
                    p.Cijena1 = Convert.ToDecimal(txtCijena.Text.Trim());
                    p.Proizvod1ID = Convert.ToInt32(cmx_proizvodi.SelectedValue);
                    p.Naziv = cmx_proizvodi.Text;
                    lista.Add(p);
                    iznos += (Convert.ToInt32(p.Cijena1) * p.Kolicina1);
                    MessageBox.Show("Proizvod je uspješno dodan");


                }
                
                dtProizvodi.DataSource = lista;
                txtIznos.Text = Convert.ToDecimal(iznos).ToString();
                txtPDV.Text = Convert.ToString(Convert.ToDecimal(iznos) * 17 / 100);
            }
        }
    }
}
