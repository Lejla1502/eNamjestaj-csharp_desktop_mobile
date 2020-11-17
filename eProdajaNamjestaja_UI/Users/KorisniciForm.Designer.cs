namespace eProdajaNamjestaja_UI.Users
{
    partial class KorisniciForm
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
            this.lbIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblLozinka = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblKorisnickoIme = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.txbIme = new System.Windows.Forms.TextBox();
            this.tbxPrezime = new System.Windows.Forms.TextBox();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.tbxKorisnickoIme = new System.Windows.Forms.TextBox();
            this.tbxLozinka = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.korisniciGrid = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statusa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ulogeList = new System.Windows.Forms.CheckedListBox();
            this.lblUloge = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOdbaci = new System.Windows.Forms.Button();
            this.tbxTelefon = new System.Windows.Forms.MaskedTextBox();
            this.lblSpol = new System.Windows.Forms.Label();
            this.cbxSpol = new System.Windows.Forms.ComboBox();
            this.lblGrad = new System.Windows.Forms.Label();
            this.cbxGrad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.korisniciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIme
            // 
            this.lbIme.AutoSize = true;
            this.lbIme.Location = new System.Drawing.Point(12, 9);
            this.lbIme.Name = "lbIme";
            this.lbIme.Size = new System.Drawing.Size(24, 13);
            this.lbIme.TabIndex = 0;
            this.lbIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(12, 39);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(44, 13);
            this.lblPrezime.TabIndex = 1;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblLozinka
            // 
            this.lblLozinka.AutoSize = true;
            this.lblLozinka.Location = new System.Drawing.Point(319, 42);
            this.lblLozinka.Name = "lblLozinka";
            this.lblLozinka.Size = new System.Drawing.Size(44, 13);
            this.lblLozinka.TabIndex = 2;
            this.lblLozinka.Text = "Lozinka";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(12, 102);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 3;
            this.lblTelefon.Text = "Telefon";
            // 
            // lblKorisnickoIme
            // 
            this.lblKorisnickoIme.AutoSize = true;
            this.lblKorisnickoIme.Location = new System.Drawing.Point(319, 12);
            this.lblKorisnickoIme.Name = "lblKorisnickoIme";
            this.lblKorisnickoIme.Size = new System.Drawing.Size(75, 13);
            this.lblKorisnickoIme.TabIndex = 4;
            this.lblKorisnickoIme.Text = "Korisničko ime";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(12, 72);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(32, 13);
            this.lblMail.TabIndex = 5;
            this.lblMail.Text = "Email";
            // 
            // txbIme
            // 
            this.txbIme.Location = new System.Drawing.Point(85, 9);
            this.txbIme.Name = "txbIme";
            this.txbIme.Size = new System.Drawing.Size(187, 20);
            this.txbIme.TabIndex = 6;
            this.txbIme.Validating += new System.ComponentModel.CancelEventHandler(this.txbIme_Validating);
            // 
            // tbxPrezime
            // 
            this.tbxPrezime.Location = new System.Drawing.Point(85, 39);
            this.tbxPrezime.Name = "tbxPrezime";
            this.tbxPrezime.Size = new System.Drawing.Size(187, 20);
            this.tbxPrezime.TabIndex = 7;
            this.tbxPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPrezime_Validating);
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(85, 69);
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(187, 20);
            this.tbxMail.TabIndex = 8;
            this.tbxMail.Validating += new System.ComponentModel.CancelEventHandler(this.tbxMail_Validating);
            // 
            // tbxKorisnickoIme
            // 
            this.tbxKorisnickoIme.Location = new System.Drawing.Point(420, 10);
            this.tbxKorisnickoIme.Name = "tbxKorisnickoIme";
            this.tbxKorisnickoIme.Size = new System.Drawing.Size(187, 20);
            this.tbxKorisnickoIme.TabIndex = 10;
            this.tbxKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.tbxKorisnickoIme_Validating);
            // 
            // tbxLozinka
            // 
            this.tbxLozinka.Location = new System.Drawing.Point(420, 36);
            this.tbxLozinka.Name = "tbxLozinka";
            this.tbxLozinka.PasswordChar = '*';
            this.tbxLozinka.Size = new System.Drawing.Size(187, 20);
            this.tbxLozinka.TabIndex = 11;
            this.tbxLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.tbxLozinka_Validating);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(532, 149);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 12;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // korisniciGrid
            // 
            this.korisniciGrid.AllowUserToDeleteRows = false;
            this.korisniciGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.korisniciGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.KorisnikID,
            this.Prezime,
            this.Mail,
            this.Telefon,
            this.KorisnickoIme,
            this.Opis,
            this.Naziv,
            this.Statusa});
            this.korisniciGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.korisniciGrid.Location = new System.Drawing.Point(0, 208);
            this.korisniciGrid.Name = "korisniciGrid";
            this.korisniciGrid.ReadOnly = true;
            this.korisniciGrid.Size = new System.Drawing.Size(835, 221);
            this.korisniciGrid.TabIndex = 13;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.ReadOnly = true;
            this.KorisnikID.Visible = false;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "Email";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Korisnicko ime";
            this.KorisnickoIme.Name = "KorisnickoIme";
            this.KorisnickoIme.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Spol";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Grad";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Statusa
            // 
            this.Statusa.DataPropertyName = "Statusa";
            this.Statusa.HeaderText = "Aktivan";
            this.Statusa.Name = "Statusa";
            this.Statusa.ReadOnly = true;
            this.Statusa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Statusa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ulogeList
            // 
            this.ulogeList.FormattingEnabled = true;
            this.ulogeList.Location = new System.Drawing.Point(420, 62);
            this.ulogeList.Name = "ulogeList";
            this.ulogeList.Size = new System.Drawing.Size(187, 64);
            this.ulogeList.TabIndex = 14;
            this.ulogeList.Validating += new System.ComponentModel.CancelEventHandler(this.ulogeList_Validating);
            // 
            // lblUloge
            // 
            this.lblUloge.AutoSize = true;
            this.lblUloge.Location = new System.Drawing.Point(319, 76);
            this.lblUloge.Name = "lblUloge";
            this.lblUloge.Size = new System.Drawing.Size(35, 13);
            this.lblUloge.TabIndex = 15;
            this.lblUloge.Text = "Uloge";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnOdbaci
            // 
            this.btnOdbaci.Location = new System.Drawing.Point(420, 149);
            this.btnOdbaci.Name = "btnOdbaci";
            this.btnOdbaci.Size = new System.Drawing.Size(75, 23);
            this.btnOdbaci.TabIndex = 16;
            this.btnOdbaci.Text = "Odbaci";
            this.btnOdbaci.UseVisualStyleBackColor = true;
            this.btnOdbaci.Click += new System.EventHandler(this.btnOdbaci_Click);
            // 
            // tbxTelefon
            // 
            this.tbxTelefon.Location = new System.Drawing.Point(85, 102);
            this.tbxTelefon.Mask = "(999) 000-000";
            this.tbxTelefon.Name = "tbxTelefon";
            this.tbxTelefon.Size = new System.Drawing.Size(187, 20);
            this.tbxTelefon.TabIndex = 17;
            this.tbxTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.tbxTelefon_Validating);
            // 
            // lblSpol
            // 
            this.lblSpol.AutoSize = true;
            this.lblSpol.Location = new System.Drawing.Point(15, 135);
            this.lblSpol.Name = "lblSpol";
            this.lblSpol.Size = new System.Drawing.Size(28, 13);
            this.lblSpol.TabIndex = 18;
            this.lblSpol.Text = "Spol";
            // 
            // cbxSpol
            // 
            this.cbxSpol.FormattingEnabled = true;
            this.cbxSpol.Location = new System.Drawing.Point(85, 132);
            this.cbxSpol.Name = "cbxSpol";
            this.cbxSpol.Size = new System.Drawing.Size(187, 21);
            this.cbxSpol.TabIndex = 19;
            this.cbxSpol.Validating += new System.ComponentModel.CancelEventHandler(this.cbxSpol_Validating);
            // 
            // lblGrad
            // 
            this.lblGrad.AutoSize = true;
            this.lblGrad.Location = new System.Drawing.Point(15, 170);
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(30, 13);
            this.lblGrad.TabIndex = 20;
            this.lblGrad.Text = "Grad";
            // 
            // cbxGrad
            // 
            this.cbxGrad.FormattingEnabled = true;
            this.cbxGrad.Location = new System.Drawing.Point(85, 161);
            this.cbxGrad.Name = "cbxGrad";
            this.cbxGrad.Size = new System.Drawing.Size(187, 21);
            this.cbxGrad.TabIndex = 21;
            this.cbxGrad.Validating += new System.ComponentModel.CancelEventHandler(this.cbxGrad_Validating);
            // 
            // KorisniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 429);
            this.Controls.Add(this.cbxGrad);
            this.Controls.Add(this.lblGrad);
            this.Controls.Add(this.cbxSpol);
            this.Controls.Add(this.lblSpol);
            this.Controls.Add(this.tbxTelefon);
            this.Controls.Add(this.btnOdbaci);
            this.Controls.Add(this.lblUloge);
            this.Controls.Add(this.ulogeList);
            this.Controls.Add(this.korisniciGrid);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.tbxLozinka);
            this.Controls.Add(this.tbxKorisnickoIme);
            this.Controls.Add(this.tbxMail);
            this.Controls.Add(this.tbxPrezime);
            this.Controls.Add(this.txbIme);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblKorisnickoIme);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblLozinka);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lbIme);
            this.Name = "KorisniciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korisnici";
            this.Load += new System.EventHandler(this.KorisniciForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.korisniciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblLozinka;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblKorisnickoIme;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txbIme;
        private System.Windows.Forms.TextBox tbxPrezime;
        private System.Windows.Forms.TextBox tbxMail;
        private System.Windows.Forms.TextBox tbxKorisnickoIme;
        private System.Windows.Forms.TextBox tbxLozinka;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.DataGridView korisniciGrid;
        private System.Windows.Forms.CheckedListBox ulogeList;
        private System.Windows.Forms.Label lblUloge;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOdbaci;
        private System.Windows.Forms.MaskedTextBox tbxTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Statusa;
        private System.Windows.Forms.ComboBox cbxGrad;
        private System.Windows.Forms.Label lblGrad;
        private System.Windows.Forms.ComboBox cbxSpol;
        private System.Windows.Forms.Label lblSpol;
    }
}