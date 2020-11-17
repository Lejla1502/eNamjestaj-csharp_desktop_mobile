namespace eProdajaNamjestaja_UI.Users
{
    partial class PretragaKorisnika
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
            this.lblImePRezime = new System.Windows.Forms.Label();
            this.tbxImePRezime = new System.Windows.Forms.TextBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.dtKorisnici = new System.Windows.Forms.DataGridView();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statusa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNoviKorisnik = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImePRezime
            // 
            this.lblImePRezime.AutoSize = true;
            this.lblImePRezime.Location = new System.Drawing.Point(12, 23);
            this.lblImePRezime.Name = "lblImePRezime";
            this.lblImePRezime.Size = new System.Drawing.Size(68, 13);
            this.lblImePRezime.TabIndex = 0;
            this.lblImePRezime.Text = "Ime i prezime";
            // 
            // tbxImePRezime
            // 
            this.tbxImePRezime.Location = new System.Drawing.Point(86, 20);
            this.tbxImePRezime.Name = "tbxImePRezime";
            this.tbxImePRezime.Size = new System.Drawing.Size(268, 20);
            this.tbxImePRezime.TabIndex = 1;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(380, 20);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi.TabIndex = 2;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // dtKorisnici
            // 
            this.dtKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.Ime,
            this.Prezime,
            this.Mail,
            this.Telefon,
            this.KorisnickoIme,
            this.Statusa});
            this.dtKorisnici.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtKorisnici.Location = new System.Drawing.Point(0, 85);
            this.dtKorisnici.Name = "dtKorisnici";
            this.dtKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtKorisnici.Size = new System.Drawing.Size(646, 247);
            this.dtKorisnici.TabIndex = 3;
            this.dtKorisnici.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtKorisnici_CellDoubleClick);
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "Email";
            this.Mail.Name = "Mail";
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "KorisnickoIme";
            this.KorisnickoIme.Name = "KorisnickoIme";
            // 
            // Statusa
            // 
            this.Statusa.DataPropertyName = "Statusa";
            this.Statusa.HeaderText = "Aktivan";
            this.Statusa.Name = "Statusa";
            // 
            // btnNoviKorisnik
            // 
            this.btnNoviKorisnik.Location = new System.Drawing.Point(532, 23);
            this.btnNoviKorisnik.Name = "btnNoviKorisnik";
            this.btnNoviKorisnik.Size = new System.Drawing.Size(102, 23);
            this.btnNoviKorisnik.TabIndex = 4;
            this.btnNoviKorisnik.Text = "Novi korisnik";
            this.btnNoviKorisnik.UseVisualStyleBackColor = true;
            this.btnNoviKorisnik.Click += new System.EventHandler(this.btnNoviKorisnik_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "**Dvostrukim klikom otvara se forma za izmjenu korisnika.";
            // 
            // PretragaKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoviKorisnik);
            this.Controls.Add(this.dtKorisnici);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.tbxImePRezime);
            this.Controls.Add(this.lblImePRezime);
            this.Name = "PretragaKorisnika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PretragaKorisnika";
            this.Load += new System.EventHandler(this.PretragaKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImePRezime;
        private System.Windows.Forms.TextBox tbxImePRezime;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.DataGridView dtKorisnici;
        private System.Windows.Forms.Button btnNoviKorisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Statusa;
        private System.Windows.Forms.Label label1;
    }
}