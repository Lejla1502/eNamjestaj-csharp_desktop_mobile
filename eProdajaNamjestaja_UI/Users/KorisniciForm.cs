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
using eProdajaNamjestaja_API.Models;
using System.Net.Mail;

namespace eProdajaNamjestaja_UI.Users
{
    public partial class KorisniciForm : Form
    {
        private WeAPIHelper korisniciService = new WeAPIHelper("http://localhost:5966/", "/api/Korisnici");
        private WeAPIHelper ulogeService = new WeAPIHelper("http://localhost:5966/", "/api/Uloge");
        private WeAPIHelper spolService = new WeAPIHelper("http://localhost:5966/", "/api/Spol");
        private WeAPIHelper gradService = new WeAPIHelper("http://localhost:5966/", "/api/Gradovi");
        private Korisnici k { get; set; }
        int korisnikId_passed = 0;
        public KorisniciForm(int id)
        {
            InitializeComponent();
            korisniciGrid.AutoGenerateColumns = false;
            this.AutoValidate = AutoValidate.Disable;
            korisnikId_passed = id;
        }

        private void KorisniciForm_Load(object sender, EventArgs e)
        {
            BindSpol();
            BindGradovi();
            BindUloge();
            if (korisnikId_passed != 0)
            {
                LoadForm();
            }
            
            BindForm();
            
            
        }

        private void BindGradovi()
        {
            HttpResponseMessage response = gradService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Gradovi> gradovi = response.Content.ReadAsAsync<List<Gradovi>>().Result;
                Gradovi g = new Gradovi();
                g.GradID = 0;
                g.Naziv = "Odaberite grad";
                gradovi.Insert(0, g);
                cbxGrad.DataSource = gradovi;
                cbxGrad.DisplayMember = "Naziv";
                cbxGrad.ValueMember = "GradID";
            }
        }

        private void BindSpol()
        {

            HttpResponseMessage response = spolService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Spol> spol = response.Content.ReadAsAsync<List<Spol>>().Result;
                Spol s = new Spol();
                s.SpolID = 0;
                s.Opis = "Odaberite spol";
                spol.Insert(0, s);
                cbxSpol.DataSource = spol;
                cbxSpol.DisplayMember = "Opis";
                cbxSpol.ValueMember = "SpolID";
            }
        }

        private void LoadForm()
        {
            HttpResponseMessage response = korisniciService.GetActionDbResponse("UserByID", korisnikId_passed);

            if (response.IsSuccessStatusCode)
            {
                k = response.Content.ReadAsAsync<Korisnici>().Result;

                txbIme.Text = k.Ime;
                tbxPrezime.Text = k.Prezime;
                tbxMail.Text = k.Mail;
                tbxTelefon.Text = k.Telefon;
                tbxKorisnickoIme.Text = k.KorisnickoIme;
                cbxGrad.SelectedValue = k.GradID;
                cbxSpol.SelectedValue =k.SpolID;

                HttpResponseMessage response1 = ulogeService.GetActionDbResponse("UlogeByKorisnikID", k.KorisnikID);
                if (response1.IsSuccessStatusCode)
                {
                    List<Uloge> uloge = response1.Content.ReadAsAsync<List<Uloge>>().Result;
                    IEnumerable<Uloge> ul = ulogeList.Items.Cast<Uloge>();
                        
                    for(int i=0;i<ul.Count();i++)
                    {
                        foreach (Uloge u in uloge)
                            {
                                if (ul.ElementAt(i).UlogaID==u.UlogaID) 
                                    ulogeList.SetItemChecked(i, true);
                            }
                        }
                }

                

            }

            
        }

        private void BindUloge()
        {
            HttpResponseMessage response = ulogeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                ((ListBox)ulogeList).DataSource = response.Content.ReadAsAsync<List<Uloge>>().Result;
                ((ListBox)ulogeList).DisplayMember = "Naziv";
                ((ListBox)ulogeList).ValueMember = "UlogaID";
                ulogeList.ClearSelected();
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }

        private void BindForm()
        {
            
            HttpResponseMessage response = korisniciService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<esp_Korisnici_SelectAll_Result> korisnici = response.Content.ReadAsAsync<List<esp_Korisnici_SelectAll_Result>>().Result;
                korisniciGrid.DataSource = korisnici;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
            {
                if (k == null)
                    k = new Korisnici();
                k.Ime = txbIme.Text;
                k.Prezime = tbxPrezime.Text;
                k.Mail = tbxMail.Text;
                k.Telefon = tbxTelefon.Text;
                k.KorisnickoIme = tbxKorisnickoIme.Text;
                k.LozinkaSalt = Util.UIHelper.GenerateSalt();
                k.LozinkaHash = UIHelper.GenerateHash(tbxLozinka.Text, k.LozinkaSalt);

                k.Statusa = true;
                k.SpolID = Convert.ToInt32(cbxSpol.SelectedValue);
                k.GradID = Convert.ToInt32(cbxGrad.SelectedValue);
                k.Uloge = ulogeList.CheckedItems.Cast<Uloge>().ToList();

                
                HttpResponseMessage response1;

                if (k.KorisnikID == 0)
                    response1 = korisniciService.PostResponse(k);
                else
                {
                    response1 = korisniciService.PutResponse(k.KorisnikID, k);
                }

                if (response1.IsSuccessStatusCode)
                {
                    MessageBox.Show(Global.GetMessage("korisnik_succ") , "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindForm();
                    ClearInput();

                }
                else
                {
                    MessageBox.Show((response1.StatusCode) + Environment.NewLine +" Message: " + response1.ReasonPhrase);
                }
               
            }
            
                
            
        }

        private void ClearInput()
        {
            txbIme.Text = tbxMail.Text = tbxPrezime.Text = tbxTelefon.Text = tbxLozinka.Text = tbxKorisnickoIme.Text = "";
            cbxGrad.SelectedIndex = cbxSpol.SelectedIndex = 0;
            for (int i = 0; i < ulogeList.Items.Count; i++)
            {
                if(ulogeList.GetItemChecked(i))
                   ulogeList.SetItemChecked(i, false);
            }
            ulogeList.ClearSelected();
            k = null;
        }

        private void txbIme_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txbIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbIme, Global.GetMessage("fname_req"));
            }
            else if (txbIme.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txbIme, Global.GetMessage("fname_req_length"));
            }
            else
                errorProvider1.SetError(txbIme, "");
        }

        private void tbxMail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbxMail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxMail, Global.GetMessage("mail_req"));
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(tbxMail.Text);
                    errorProvider1.SetError(tbxMail, "");
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbxMail, Global.GetMessage("mail_error"));
                    
                }
            }
        }

        private void tbxPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPrezime.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxPrezime, Global.GetMessage("lname_req"));
            }
            else if (tbxPrezime.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxPrezime, Global.GetMessage("lname_req_length"));
            }
            else 
            {
                errorProvider1.SetError(tbxPrezime, "");
            }
        }

        private void tbxTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (!tbxTelefon.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxTelefon, Global.GetMessage("phone_req"));
            }
            else
            {
                errorProvider1.SetError(tbxTelefon, "");
            }
        }

        private void tbxKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxKorisnickoIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxKorisnickoIme, Global.GetMessage("username_req"));
            }
            else if (tbxKorisnickoIme.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxKorisnickoIme,Global.GetMessage("username_req_length") );
            }
            else
            {
                errorProvider1.SetError(tbxKorisnickoIme, "");
            }
        }

        private void tbxLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLozinka.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxLozinka, Global.GetMessage("pass_req"));
            }
            else if (tbxLozinka.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxLozinka, Global.GetMessage("pass_req_length"));
            }
            else
            {
                errorProvider1.SetError(tbxLozinka, "");
            }
        }

        private void ulogeList_Validating(object sender, CancelEventArgs e)
        {
            if (ulogeList.CheckedItems.Count == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(ulogeList, Global.GetMessage("roles_req"));
            }
            else
            {
                errorProvider1.SetError(ulogeList, "");
            }
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            Global.selektovaniKorisnik = null;
            this.Close();
            PretragaKorisnika frm = new PretragaKorisnika();
            frm.Show();
        }

        private void cbxSpol_Validating(object sender, CancelEventArgs e)
        {
            if (cbxSpol.SelectedIndex == 0 || cbxSpol.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbxSpol,Global.GetMessage("spol_req") );
            }
            else
            {
                errorProvider1.SetError(cbxSpol, "");
            }
        }

        private void cbxGrad_Validating(object sender, CancelEventArgs e)
        {
            if (cbxGrad.SelectedIndex == 0 || cbxGrad.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbxGrad,Global.GetMessage("grad_req"));
            }
            else
            {
                errorProvider1.SetError(cbxGrad, "");
            }
        }
    }



    
}
