namespace eProdajaNamjestaja_UI.Purchase
{
    partial class NabavkaProizvoda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmx_proizvodi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtProizvodi = new System.Windows.Forms.DataGridView();
            this.Proizvod1ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSkladiste = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDobavljaci = new System.Windows.Forms.ComboBox();
            this.btnNovoSkladiste = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.btnNoviDobavljac = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBrojFakture = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.txtPDV = new System.Windows.Forms.TextBox();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEvidentiraj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtProizvodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmx_proizvodi
            // 
            this.cmx_proizvodi.FormattingEnabled = true;
            this.cmx_proizvodi.Location = new System.Drawing.Point(96, 34);
            this.cmx_proizvodi.Name = "cmx_proizvodi";
            this.cmx_proizvodi.Size = new System.Drawing.Size(141, 21);
            this.cmx_proizvodi.TabIndex = 0;
            this.cmx_proizvodi.SelectedValueChanged += new System.EventHandler(this.cmx_proizvodi_SelectedValueChanged);
            this.cmx_proizvodi.Validating += new System.ComponentModel.CancelEventHandler(this.cmx_proizvodi_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proizvod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kolicina";
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(96, 69);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(141, 20);
            this.txtKolicina.TabIndex = 3;
            this.txtKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKolicina_KeyPress_1);
            this.txtKolicina.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolicina_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cijena";
            // 
            // dtProizvodi
            // 
            this.dtProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProizvodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proizvod1ID,
            this.Naziv,
            this.Kolicina1,
            this.Cijena1});
            this.dtProizvodi.Location = new System.Drawing.Point(31, 247);
            this.dtProizvodi.Name = "dtProizvodi";
            this.dtProizvodi.Size = new System.Drawing.Size(343, 150);
            this.dtProizvodi.TabIndex = 7;
            // 
            // Proizvod1ID
            // 
            this.Proizvod1ID.DataPropertyName = "Proizvod1ID";
            this.Proizvod1ID.HeaderText = "ProizvodID";
            this.Proizvod1ID.Name = "Proizvod1ID";
            this.Proizvod1ID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Proizvod";
            this.Naziv.Name = "Naziv";
            // 
            // Kolicina1
            // 
            this.Kolicina1.DataPropertyName = "Kolicina1";
            this.Kolicina1.HeaderText = "Kolicina";
            this.Kolicina1.Name = "Kolicina1";
            // 
            // Cijena1
            // 
            this.Cijena1.DataPropertyName = "Cijena1";
            this.Cijena1.HeaderText = "Cijena";
            this.Cijena1.Name = "Cijena1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Skladišta";
            // 
            // cmbSkladiste
            // 
            this.cmbSkladiste.FormattingEnabled = true;
            this.cmbSkladiste.Location = new System.Drawing.Point(96, 183);
            this.cmbSkladiste.Name = "cmbSkladiste";
            this.cmbSkladiste.Size = new System.Drawing.Size(141, 21);
            this.cmbSkladiste.TabIndex = 9;
            this.cmbSkladiste.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSkladiste_Validating_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dobavljači";
            // 
            // cmbDobavljaci
            // 
            this.cmbDobavljaci.FormattingEnabled = true;
            this.cmbDobavljaci.Location = new System.Drawing.Point(96, 208);
            this.cmbDobavljaci.Name = "cmbDobavljaci";
            this.cmbDobavljaci.Size = new System.Drawing.Size(141, 21);
            this.cmbDobavljaci.TabIndex = 11;
            this.cmbDobavljaci.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDobavljaci_Validating_1);
            // 
            // btnNovoSkladiste
            // 
            this.btnNovoSkladiste.Location = new System.Drawing.Point(254, 182);
            this.btnNovoSkladiste.Name = "btnNovoSkladiste";
            this.btnNovoSkladiste.Size = new System.Drawing.Size(120, 23);
            this.btnNovoSkladiste.TabIndex = 13;
            this.btnNovoSkladiste.Text = "Novo skladište";
            this.btnNovoSkladiste.UseVisualStyleBackColor = true;
            this.btnNovoSkladiste.Click += new System.EventHandler(this.btnNovoSkladiste_Click);
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.Location = new System.Drawing.Point(254, 130);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Size = new System.Drawing.Size(120, 23);
            this.btnDodajProizvod.TabIndex = 14;
            this.btnDodajProizvod.Text = "Dodaj novi proizvod";
            this.btnDodajProizvod.UseVisualStyleBackColor = true;
            this.btnDodajProizvod.Click += new System.EventHandler(this.btnDodajProizvod_Click);
            // 
            // btnNoviDobavljac
            // 
            this.btnNoviDobavljac.Location = new System.Drawing.Point(254, 211);
            this.btnNoviDobavljac.Name = "btnNoviDobavljac";
            this.btnNoviDobavljac.Size = new System.Drawing.Size(120, 23);
            this.btnNoviDobavljac.TabIndex = 15;
            this.btnNoviDobavljac.Text = "Novi dobavljač";
            this.btnNoviDobavljac.UseVisualStyleBackColor = true;
            this.btnNoviDobavljac.Click += new System.EventHandler(this.btnNoviDobavljac_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Broj fakture";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Datum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Iznos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "PDV";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Napomena";
            // 
            // txtBrojFakture
            // 
            this.txtBrojFakture.Location = new System.Drawing.Point(507, 31);
            this.txtBrojFakture.Name = "txtBrojFakture";
            this.txtBrojFakture.Size = new System.Drawing.Size(141, 20);
            this.txtBrojFakture.TabIndex = 21;
            this.txtBrojFakture.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrojFakture_KeyPress_1);
            this.txtBrojFakture.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojFakture_Validating);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(507, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(507, 99);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.ReadOnly = true;
            this.txtIznos.Size = new System.Drawing.Size(85, 20);
            this.txtIznos.TabIndex = 23;
            // 
            // txtPDV
            // 
            this.txtPDV.Location = new System.Drawing.Point(507, 132);
            this.txtPDV.Name = "txtPDV";
            this.txtPDV.ReadOnly = true;
            this.txtPDV.Size = new System.Drawing.Size(63, 20);
            this.txtPDV.TabIndex = 24;
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(507, 165);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(141, 69);
            this.txtNapomena.TabIndex = 25;
            this.txtNapomena.Validating += new System.ComponentModel.CancelEventHandler(this.txtNapomena_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnEvidentiraj
            // 
            this.btnEvidentiraj.Location = new System.Drawing.Point(517, 259);
            this.btnEvidentiraj.Name = "btnEvidentiraj";
            this.btnEvidentiraj.Size = new System.Drawing.Size(114, 46);
            this.btnEvidentiraj.TabIndex = 26;
            this.btnEvidentiraj.Text = "Evidentiraj nabavku";
            this.btnEvidentiraj.UseVisualStyleBackColor = true;
            this.btnEvidentiraj.Click += new System.EventHandler(this.btnEvidentiraj_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(573, 363);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 27;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.Location = new System.Drawing.Point(446, 329);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(206, 13);
            this.lbl_error.TabIndex = 28;
            this.lbl_error.Text = "Ulazi nisu uneseni, provjerite sve podatke!";
            this.lbl_error.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Sifra";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(96, 132);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.ReadOnly = true;
            this.txtSifra.Size = new System.Drawing.Size(141, 20);
            this.txtSifra.TabIndex = 30;
            this.txtSifra.Validating += new System.ComponentModel.CancelEventHandler(this.txtSifra_Validating_1);
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(96, 99);
            this.txtCijena.Mask = "0,000.00";
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(141, 20);
            this.txtCijena.TabIndex = 31;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Dodaj stavku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NabavkaProizvoda
            // 
            this.ClientSize = new System.Drawing.Size(680, 409);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmx_proizvodi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnEvidentiraj);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.txtPDV);
            this.Controls.Add(this.btnDodajProizvod);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtBrojFakture);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNoviDobavljac);
            this.Controls.Add(this.btnNovoSkladiste);
            this.Controls.Add(this.cmbDobavljaci);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSkladiste);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtProizvodi);
            this.Name = "NabavkaProizvoda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija nabavke proizvoda";
            this.Load += new System.EventHandler(this.NabavkaProizvoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtProizvodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ComboBox cmx_proizvodi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.DataGridView dtProizvodi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSkladiste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDobavljaci;
        private System.Windows.Forms.Button btnNovoSkladiste;
        private System.Windows.Forms.Button btnNoviDobavljac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBrojFakture;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.TextBox txtPDV;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnEvidentiraj;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proizvod1ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena1;
        private System.Windows.Forms.MaskedTextBox txtCijena;
        private System.Windows.Forms.Button button1;
    }
}