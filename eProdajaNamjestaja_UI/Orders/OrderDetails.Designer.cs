namespace eProdajaNamjestaja_UI.Orders
{
    partial class OrderDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.brNarudzbeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datumLabel = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.kupacLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iznosNarudzbeLabel = new System.Windows.Forms.Label();
            this.stavkeNarudzbeGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.skladistaList = new System.Windows.Forms.ComboBox();
            this.procesirajButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnProvjera = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStanje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stavkeNarudzbeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj narudžbe:";
            // 
            // brNarudzbeLabel
            // 
            this.brNarudzbeLabel.AutoSize = true;
            this.brNarudzbeLabel.Location = new System.Drawing.Point(135, 32);
            this.brNarudzbeLabel.Name = "brNarudzbeLabel";
            this.brNarudzbeLabel.Size = new System.Drawing.Size(72, 13);
            this.brNarudzbeLabel.TabIndex = 1;
            this.brNarudzbeLabel.Text = "Broj narudžbe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Datum:";
            // 
            // datumLabel
            // 
            this.datumLabel.AutoSize = true;
            this.datumLabel.Location = new System.Drawing.Point(135, 68);
            this.datumLabel.Name = "datumLabel";
            this.datumLabel.Size = new System.Drawing.Size(38, 13);
            this.datumLabel.TabIndex = 3;
            this.datumLabel.Text = "Datum";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(320, 32);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(41, 13);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Kupac:";
            // 
            // kupacLabel
            // 
            this.kupacLabel.AutoSize = true;
            this.kupacLabel.Location = new System.Drawing.Point(403, 32);
            this.kupacLabel.Name = "kupacLabel";
            this.kupacLabel.Size = new System.Drawing.Size(38, 13);
            this.kupacLabel.TabIndex = 5;
            this.kupacLabel.Text = "Kupac";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Iznos:";
            // 
            // iznosNarudzbeLabel
            // 
            this.iznosNarudzbeLabel.AutoSize = true;
            this.iznosNarudzbeLabel.Location = new System.Drawing.Point(406, 68);
            this.iznosNarudzbeLabel.Name = "iznosNarudzbeLabel";
            this.iznosNarudzbeLabel.Size = new System.Drawing.Size(32, 13);
            this.iznosNarudzbeLabel.TabIndex = 7;
            this.iznosNarudzbeLabel.Text = "Iznos";
            // 
            // stavkeNarudzbeGrid
            // 
            this.stavkeNarudzbeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stavkeNarudzbeGrid.Location = new System.Drawing.Point(43, 100);
            this.stavkeNarudzbeGrid.Name = "stavkeNarudzbeGrid";
            this.stavkeNarudzbeGrid.Size = new System.Drawing.Size(529, 192);
            this.stavkeNarudzbeGrid.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Skladište:";
            // 
            // skladistaList
            // 
            this.skladistaList.FormattingEnabled = true;
            this.skladistaList.Location = new System.Drawing.Point(601, 116);
            this.skladistaList.Name = "skladistaList";
            this.skladistaList.Size = new System.Drawing.Size(191, 21);
            this.skladistaList.TabIndex = 10;
            this.skladistaList.SelectedIndexChanged += new System.EventHandler(this.skladistaList_SelectedIndexChanged);
            this.skladistaList.Validating += new System.ComponentModel.CancelEventHandler(this.skladistaList_Validating);
            // 
            // procesirajButton
            // 
            this.procesirajButton.Location = new System.Drawing.Point(601, 218);
            this.procesirajButton.Name = "procesirajButton";
            this.procesirajButton.Size = new System.Drawing.Size(112, 23);
            this.procesirajButton.TabIndex = 11;
            this.procesirajButton.Text = "Procesiraj";
            this.procesirajButton.UseVisualStyleBackColor = true;
            this.procesirajButton.Visible = false;
            this.procesirajButton.Click += new System.EventHandler(this.procesirajButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(601, 269);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(112, 23);
            this.btnOtkazi.TabIndex = 16;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // btnProvjera
            // 
            this.btnProvjera.Location = new System.Drawing.Point(601, 170);
            this.btnProvjera.Name = "btnProvjera";
            this.btnProvjera.Size = new System.Drawing.Size(112, 23);
            this.btnProvjera.TabIndex = 17;
            this.btnProvjera.Text = "Provjera";
            this.btnProvjera.UseVisualStyleBackColor = true;
            this.btnProvjera.Click += new System.EventHandler(this.btnProvjera_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(43, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Provjera stanja:";
            // 
            // labelStanje
            // 
            this.labelStanje.AutoSize = true;
            this.labelStanje.Location = new System.Drawing.Point(46, 319);
            this.labelStanje.Name = "labelStanje";
            this.labelStanje.Size = new System.Drawing.Size(0, 13);
            this.labelStanje.TabIndex = 19;
            this.labelStanje.Visible = false;
            // 
            // OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 408);
            this.Controls.Add(this.labelStanje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnProvjera);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.procesirajButton);
            this.Controls.Add(this.skladistaList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stavkeNarudzbeGrid);
            this.Controls.Add(this.iznosNarudzbeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kupacLabel);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.datumLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.brNarudzbeLabel);
            this.Controls.Add(this.label1);
            this.Name = "OrderDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalji narudžbe";
            this.Load += new System.EventHandler(this.OrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stavkeNarudzbeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label brNarudzbeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label datumLabel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label kupacLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label iznosNarudzbeLabel;
        private System.Windows.Forms.DataGridView stavkeNarudzbeGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox skladistaList;
        private System.Windows.Forms.Button procesirajButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnProvjera;
        private System.Windows.Forms.Label labelStanje;
        private System.Windows.Forms.Label label5;
    }
}