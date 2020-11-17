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

namespace eProdajaNamjestaja_UI.Orders
{
    public partial class OrderDetails : Form
    {
        WeAPIHelper serviceNarudzbe = new WeAPIHelper("http://localhost:5966/", "api/Narudzbe");
        WeAPIHelper serviceSkladista = new WeAPIHelper("http://localhost:5966/", "api/Skladista");
        WeAPIHelper serviceSkladistaProizvod = new WeAPIHelper("http://localhost:5966/", "api/SkladistaProizvod");


        public esp_Narudzbe_SelectAktivne_Result narudzba { get; set; }
        public OrderDetails(esp_Narudzbe_SelectAktivne_Result narudzba)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            if(narudzba!=null)
            this.narudzba = narudzba;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            BindSkladista();
            BindForm();
        }

        private void BindSkladista()
        {
            HttpResponseMessage response = serviceSkladista.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Skladista> skladista = response.Content.ReadAsAsync<List<Skladista>>().Result;
                skladista.Insert(0, new Skladista());
                skladistaList.DataSource = skladista;
                skladistaList.DisplayMember = "Naziv";
                skladistaList.ValueMember = "SkladistaID";
            }
        }

        private void BindForm()
        {
            brNarudzbeLabel.Text = narudzba.BrojNarudzbe;
            datumLabel.Text = narudzba.Datum.ToShortDateString();
            kupacLabel.Text = narudzba.Kupac;
            iznosNarudzbeLabel.Text = narudzba.Iznos.ToString() + "KM";

            HttpResponseMessage response = serviceNarudzbe.GetActionResponse("GetStavkeNarudzbe", narudzba.NarudzbaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                narudzba.NarudzbaStavke = response.Content.ReadAsAsync<List<esp_NarudzbeStavke_SelectByNarudzbaID_Result>>().Result;
                stavkeNarudzbeGrid.DataSource = narudzba.NarudzbaStavke;
                stavkeNarudzbeGrid.Columns[0].Visible = false;
                stavkeNarudzbeGrid.Columns[1].Visible = false;
                stavkeNarudzbeGrid.ClearSelection();
            }
        }

        private void procesirajButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {


                Izlazi izlaz = new Izlazi();

                izlaz.NarudzbaID = narudzba.NarudzbaID;
                izlaz.IznosSaPDV = (decimal)narudzba.Iznos;
                izlaz.IznosBezPDV = (decimal)narudzba.Iznos / (decimal)1.17;
                izlaz.SkladisteID = Convert.ToInt32(skladistaList.SelectedValue);
                izlaz.KorisnikID = Global.prijavljeniKorisnik.KorisnikID;
                esp_Narudzbe_SelectAktivne_Result temp = narudzba;
                HttpResponseMessage response = serviceNarudzbe.PostActionResponse("ProcesirajNarudzbu", izlaz);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(Global.GetMessage("order_succ"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();

                    Reports.Frm_Racun f = new Reports.Frm_Racun();
                    f.narudzba = narudzba;
                    f.Show();


                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode + Environment.NewLine + "Message: " + response.ReasonPhrase);
                }



            }
        }

        private void skladistaList_Validating(object sender, CancelEventArgs e)
        {
            if (skladistaList.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(skladistaList, "Obavezno odaberite skladiste !");
            }
            else
            {

                errorProvider1.SetError(skladistaList, "");

            }
        }
        

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            Narudzbe n = new Narudzbe();
            n.NarudzbaID = narudzba.NarudzbaID;
            n.BrojNarudzbe = narudzba.BrojNarudzbe;
            n.Datum = narudzba.Datum;
            n.KupacID = narudzba.KupacID;
            n.Statuss = false;
            n.Otkazano = true;
            HttpResponseMessage response = serviceNarudzbe.PutResponse(narudzba.NarudzbaID,n);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(Global.GetMessage("order_cancel"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + response.StatusCode + Environment.NewLine + "Message: " + response.ReasonPhrase);
            }
        }

        private void btnProvjera_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(skladistaList.SelectedValue) == 0 || Convert.ToInt32(skladistaList.SelectedValue) == -1)
            {
                MessageBox.Show("Odaberite skladiste!");
                return;
            }
            int skladisteID = Convert.ToInt32(skladistaList.SelectedValue);
            int? stanje = 0;
            string message = "";
            foreach (var x in narudzba.NarudzbaStavke)
            {
                HttpResponseMessage response1 = serviceSkladistaProizvod.GetActionResponse2("ProvjeraStanja", x.ProizvodID, skladisteID);
                if (response1.IsSuccessStatusCode)
                {
                    stanje = response1.Content.ReadAsAsync<int?>().Result;
                    if (stanje == 0 || stanje == null)
                    {
                        message += "Proizvoda " + x.Naziv + " nema na odabranom skladištu. \n";
                    }
                    else if (stanje < x.Kolicina)
                    {
                        message += "Proizvoda " + x.Naziv + " nema u dovoljnoj količini (stanje: " + stanje + " ; tražena količina: " + x.Kolicina + " ) \n";
                        
                    }
                   
                }
            }

            labelStanje.Visible = true;
            labelStanje.Text = message;

            if (message == "")
                procesirajButton.Visible = true;
            
        }

        private void skladistaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            procesirajButton.Visible = false;
        }

    }
}
