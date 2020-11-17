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

namespace eProdajaNamjestaja_UI.Products
{
    public partial class PretragaProizvoda : Form
    {
        WeAPIHelper vrsteService = new WeAPIHelper("http://localhost:5966/", "/api/VrsteProizvoda");
        WeAPIHelper modelService = new WeAPIHelper("http://localhost:5966/", "/api/ModelProizvoda");
        WeAPIHelper tipService = new WeAPIHelper("http://localhost:5966/", "/api/TipProizvoda");
        WeAPIHelper proizvodiService = new WeAPIHelper("http://localhost:5966/", "/api/Proizvodi");
        public PretragaProizvoda()
        {
            InitializeComponent();
            dtProizvodi.AutoGenerateColumns = false;

        }

        private void PretragaProizvoda_Load(object sender, EventArgs e)
        {
            BindForm();
            BindVrsteProizvoda();
            BindModeliProizvoda();
            BindTipoviProizvoda();
        }

        private void BindTipoviProizvoda()
        {
            HttpResponseMessage response = tipService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<TipProizvoda> tipoviProizvoda = response.Content.ReadAsAsync<List<TipProizvoda>>().Result;
                tipoviProizvoda.Insert(0, new TipProizvoda());
                cbxTip.DataSource = tipoviProizvoda;
                cbxTip.DisplayMember = "Naziv";
                cbxTip.ValueMember = "TipID";
            }
        }

        private void BindModeliProizvoda()
        {
            HttpResponseMessage response = modelService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<ModelProizvoda> modeli = response.Content.ReadAsAsync<List<ModelProizvoda>>().Result;
                modeli.Insert(0, new ModelProizvoda());
                cbxModel.DataSource = modeli;
                cbxModel.DisplayMember = "Naziv";
                cbxModel.ValueMember = "ModelID";
            }
        }

        private void BindVrsteProizvoda()
        {
            HttpResponseMessage response = vrsteService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<VrsteProizvoda> vrste = response.Content.ReadAsAsync<List<VrsteProizvoda>>().Result;
                vrste.Insert(0, new VrsteProizvoda());
                cbxVrsta.DataSource = vrste;
                cbxVrsta.DisplayMember = "Naziv";
                cbxVrsta.ValueMember = "VrstaProizvoda";
            }
        }

        private void BindForm()
        {
            string vrsta = cbxVrsta.Text;
            string model = cbxModel.Text;
            string tip = cbxTip.Text;



            if (vrsta == "")
                vrsta = "Null";


            if (model == "")
                model = "Null";

            if (tip == "")
                tip = "Null";

            HttpResponseMessage response = proizvodiService.GetActionResponse3("SearchProizvodiByVrstaModelTip", vrsta, model, tip);

            if (response.IsSuccessStatusCode)
            {
                List<esp_SelectProizvodiByVrstaModelTip_Result> proizvodi = response.Content.ReadAsAsync<List<esp_SelectProizvodiByVrstaModelTip_Result>>().Result;
                dtProizvodi.DataSource = proizvodi;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindForm();

            

        }

        private void btnNoviProizvod_Click(object sender, EventArgs e)
        {
            AddProizvod frm = new AddProizvod();
          
            frm.ShowDialog();
            BindForm();
        }
    }
}
