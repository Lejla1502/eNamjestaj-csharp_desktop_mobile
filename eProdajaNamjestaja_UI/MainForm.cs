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
    public partial class MainForm : Form
    {
        WeAPIHelper narudzbeService = new WeAPIHelper("http://localhost:5966/", "/api/Narudzbe");
        public MainForm()
        {
            InitializeComponent();
            
        }

       
        private void korisniciToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Users.PretragaKorisnika f = new Users.PretragaKorisnika();
            f.MdiParent = this;
            f.Show();
        }

        private void proizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.PretragaProizvoda f = new Products.PretragaProizvoda();
            f.MdiParent = this;
            f.Show();
        }

        private void dobavljačiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers.PretragaDobavljaca f = new Suppliers.PretragaDobavljaca();
            f.MdiParent = this;
            f.Show();
        }

        private void skladištaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stocks.PretragaSkladista ad = new Stocks.PretragaSkladista();
            ad.MdiParent = this;
            ad.Show();
        }

        private void kupciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumers.PretragaKupaca f = new Consumers.PretragaKupaca();
            f.MdiParent = this;
            f.Show();
        }

        private void evidencijaNabavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase.NabavkaProizvoda f = new Purchase.NabavkaProizvoda();
            f.MdiParent = this;
            f.Show();
        }

        private void narudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orders.ActiveOrder a = new Orders.ActiveOrder();
            a.MdiParent = this;
            a.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            HttpResponseMessage response = narudzbeService.GetActionResponse("GetBrojAktivnihNarudzbi");

            if (response.IsSuccessStatusCode)
            {
                int brNarudzbi = response.Content.ReadAsAsync<int>().Result;

                if (brNarudzbi > 0)
                {
                    notifyIcon1.ShowBalloonTip(4000, "Nove narudžbe", "Broj narudžbi: " + brNarudzbi, ToolTipIcon.Info);

                }
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Orders.ActiveOrder aktivneNarudzbeForm = new Orders.ActiveOrder();
            aktivneNarudzbeForm.MdiParent = this;
            aktivneNarudzbeForm.Show();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Orders.ActiveOrder aktivneNarudzbeForm = new Orders.ActiveOrder();
            aktivneNarudzbeForm.MdiParent = this;
            aktivneNarudzbeForm.Show();
        }

       

        private void narudzbeTotalgodineIMjeseciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Frm_OrdersTotalByYearMonth f = new Reports.Frm_OrdersTotalByYearMonth();
            f.Show();
        }

        private void najprodavanijiProizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Frm_Products f = new Reports.Frm_Products();
            f.Show();
        }
    }
}
