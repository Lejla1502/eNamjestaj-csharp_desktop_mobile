using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using eProdajaNamjestaja_API.Models;
using eProdajaNamjestaja_UI.Util;
using System.Net.Http;
using System.IO;
using System.Configuration;

namespace eProdajaNamjestaja_UI.Products
{
    public partial class AddProizvod : Form
    {
        WeAPIHelper vrsteService = new WeAPIHelper("http://localhost:5966/", "/api/VrsteProizvoda");
        WeAPIHelper modelService = new WeAPIHelper("http://localhost:5966/", "/api/ModelProizvoda");
        WeAPIHelper tipService = new WeAPIHelper("http://localhost:5966/", "/api/TipProizvoda");
        WeAPIHelper proizvodiService = new WeAPIHelper("http://localhost:5966/", "/api/Proizvodi");

        private Proizvodi proizvod { get; set; }
        

        public AddProizvod()
        {
            InitializeComponent();
            dtProizvodi.AutoGenerateColumns = false;
            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddProizvod_Load(object sender, EventArgs e)
        {
            txtCijena.PromptChar = '0';
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
                cbxVrsta.ValueMember="VrstaProizvoda";
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (proizvod == null)
                    proizvod = new Proizvodi();
            openFileDialog1.ShowDialog();
            tbxSlika.Text = openFileDialog1.FileName;

            Image image = Image.FromFile(tbxSlika.Text);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            proizvod.Slika = ms.ToArray();

            int resizedWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgWidth"]);
            int resizedHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgHeight"]);
            int croppedWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
            int croppedHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

            if (image.Width > resizedWidth)
            {
                Image resizedImage = UIHelper.ResizeImage(image, new Size(resizedWidth, resizedHeight));
                Image croppedImage = resizedImage;

                    int croppedXPosition = (resizedImage.Width - croppedWidth) / 2;
                int croppedYPosition = (resizedImage.Height - croppedHeight) / 2;


                    if (resizedImage.Width >= croppedWidth && resizedImage.Height >= croppedHeight)
                    {
                        croppedImage = UIHelper.CropImage(resizedImage, new Rectangle(croppedXPosition, croppedYPosition, croppedWidth, croppedHeight));
                        ms = new MemoryStream();
                        croppedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        proizvod.SlikaThumb = ms.ToArray();

                        pictureBox1.Image = croppedImage;
                    }
                    else
                    {

                        MessageBox.Show(Global.GetMessage("picture_size_war"), Global.GetMessage("warning"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        proizvod = null;
                        tbxSlika.Text = null;
                    }

            }
                else
                {
                    MessageBox.Show(Global.GetMessage("picture_war") + " " + resizedWidth + "x" + resizedHeight + ".", Global.GetMessage("warning"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    proizvod = null;
                    tbxSlika.Text = null;
                }
            }
            catch (Exception)
            {
                proizvod = null;
                pictureBox1.Image = null;
                MessageBox.Show("Odaberite sliku");
                tbxSlika.Text = "";
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (proizvod == null)
                    proizvod = new Proizvodi();

                

                if (cbxVrsta.SelectedIndex != 0)
                    proizvod.VrstaProizvoda = Convert.ToInt32(cbxVrsta.SelectedValue);

                proizvod.Sifra = tbxSifra.Text;
                proizvod.Naziv = tbxNaziv.Text;

                if (cbxTip.SelectedIndex != 0)
                    proizvod.TipID = Convert.ToInt32(cbxTip.SelectedValue);
                if (cbxModel.SelectedIndex != 0)
                    proizvod.ModelID = Convert.ToInt32(cbxModel.SelectedValue);

                proizvod.Cijena = Convert.ToDecimal(txtCijena.Text);
                proizvod.Statuss = true;


                    
                HttpResponseMessage response1 = proizvodiService.GetActionResponse("Provjera", tbxSifra.Text);
                if (response1.IsSuccessStatusCode)
                {
                    int id = response1.Content.ReadAsAsync<int>().Result;
                    if (id!=0 && id!=proizvod.ProizvodID)
                    {
                        MessageBox.Show(tbxSifra,Global.GetMessage("sifra_exists"));
                        tbxSifra.Text = "";
                    }
                    else
                    {
                        HttpResponseMessage response2 = proizvodiService.GetActionResponse("ProvjeraNaziv",tbxNaziv.Text);
                        if (response2.IsSuccessStatusCode)
                        {
                            int pId = response2.Content.ReadAsAsync<int>().Result;
                            if (pId == 0 || pId==proizvod.ProizvodID)
                            {
                                HttpResponseMessage response;
                                if (proizvod.ProizvodID == 0)
                                {
                                    response = proizvodiService.PostResponse( proizvod);
                                    MessageBox.Show(Global.GetMessage("product_add_succ"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    ClearInput();
                                    cbxVrsta.SelectedIndex = 0;
                                   

                                }
                                else
                                {
                                    response = proizvodiService.PutResponse(proizvod.ProizvodID,proizvod);
                                    if (response.IsSuccessStatusCode)
                                    {
                                        MessageBox.Show(Global.GetMessage("product_edit_succ"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                       
                                        ClearInput();
                                        cbxVrsta.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        MessageBox.Show(response.ReasonPhrase, Global.GetMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(tbxNaziv,Global.GetMessage("naziv_exists"));
                                tbxNaziv.Text = "";
                            }
                        }
                        
                    }
                }
            }
           
        }

        private void ClearInput()
        {
            proizvod = null;
            tbxSifra.Text = "";
            tbxNaziv.Text = "";
            txtCijena.Text = "";
            cbxTip.SelectedIndex = 0;
            cbxModel.SelectedIndex = 0;
            tbxSlika.Text = "";
            pictureBox1.Image = null;
        }

        private void BindForm()
        {

            HttpResponseMessage response = proizvodiService.GetActionResponse("SearchProizvodiByVrsta",cbxVrsta.SelectedValue.ToString());
            if (response.IsSuccessStatusCode)
            {
                List<esp_Proizvodi_SelectByVrsta_Result> proizvodi = response.Content.ReadAsAsync<List<esp_Proizvodi_SelectByVrsta_Result>>().Result;
                
                dtProizvodi.DataSource = proizvodi;
            }
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            this.Close();
            PretragaProizvoda f = new PretragaProizvoda();
            f.Show();
        }

        private void cbxVrsta_Validating(object sender, CancelEventArgs e)
        {
            if (cbxVrsta.SelectedIndex == 0 || cbxVrsta.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbxVrsta, Global.GetMessage("vrsta_req"));
            }
            else
            {
                errorProvider1.SetError(cbxVrsta, "");
            }
        }

        private void tbxNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbxNaziv.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxNaziv, Global.GetMessage("naziv_req"));

            }
            else if (tbxNaziv.TextLength < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxNaziv, Global.GetMessage("naziv_req_lenth"));
            }
            else
            {
                errorProvider1.SetError(tbxNaziv, "");
            }
        }

        private void tbxSifra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSifra.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxSifra, Global.GetMessage("sifra_req"));
            }
            else if (tbxSifra.TextLength < 7)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxSifra, Global.GetMessage("sifra_length"));
            }
            else
            {
                errorProvider1.SetError(tbxSifra, "");
            }
        }

        private void cbxTip_Validating(object sender, CancelEventArgs e)
        {
            if (cbxTip.SelectedIndex == 0 || cbxTip.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbxTip, Global.GetMessage("tip_req"));
            }
            else
            {
                errorProvider1.SetError(cbxTip, "");
            }
        }

        private void cbxModel_Validating(object sender, CancelEventArgs e)
        {
            if (cbxModel.SelectedIndex == 0 || cbxModel.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbxModel, Global.GetMessage("model_req"));
            }
            else
            {
                errorProvider1.SetError(cbxModel, "");
            }
        }

        private void tbxCijena_Validating(object sender, CancelEventArgs e)
        {
            txtCijena.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (txtCijena.Text==string.Empty)
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

        
        private void tbxSifra_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void tbxSlika_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSlika.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxSlika, Global.GetMessage("slika_req"));
            }
            else
            {
                errorProvider1.SetError(tbxSlika, "");
            }
        }

        private void cbxVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxVrsta.SelectedIndex != 0 && cbxVrsta.SelectedIndex != -1)
                BindForm();
            else
                dtProizvodi.DataSource = null;
            if (proizvod != null)
                ClearInput();
        }

        private void dtProizvodi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string proizvodID = dtProizvodi.SelectedRows[0].Cells[0].Value.ToString();
            HttpResponseMessage response = proizvodiService.GetResponse(proizvodID);

            if (response.IsSuccessStatusCode)
            {
                proizvod = response.Content.ReadAsAsync<Proizvodi>().Result;
                LoadData();
            }
        }

        private void LoadData()
        {
            cbxVrsta.SelectedValue = proizvod.VrstaProizvoda;
            tbxNaziv.Text = proizvod.Naziv;
            tbxSifra.Text = proizvod.Sifra;
            cbxTip.SelectedValue = proizvod.TipID;
            cbxModel.SelectedValue = proizvod.ModelID;
            txtCijena.Text = proizvod.Cijena.ToString("0,000");

            if (proizvod.SlikaThumb != null)
            {
                var ms = new MemoryStream(proizvod.SlikaThumb);
                Image croppedImage = Image.FromStream(ms);

                pictureBox1.Image = croppedImage;
            }
        }
    }
}
