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

namespace eProdajaNamjestaja_UI
{
    public partial class LoginForm : Form
    {
        private WeAPIHelper korisniciService = new WeAPIHelper("http://localhost:5966/", "/api/Korisnici");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = korisniciService.GetResponse(tbxKorisnickoIme.Text);
            if (response.IsSuccessStatusCode)
            {
                Korisnici k = response.Content.ReadAsAsync<Korisnici>().Result;
                
                if (UIHelper.GenerateHash(tbxLozinka.Text, k.LozinkaSalt) == k.LozinkaHash)
                {
                    Global.prijavljeniKorisnik=k;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Global.GetMessage("login_pass_error"),Global.GetMessage("warning"),MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Greska - Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }
    }
}
