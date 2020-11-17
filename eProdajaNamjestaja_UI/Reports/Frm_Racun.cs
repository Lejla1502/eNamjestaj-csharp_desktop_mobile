using eProdajaNamjestaja_API.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaNamjestaja_UI.Reports
{
    public partial class Frm_Racun : Form
    {
        public esp_Narudzbe_SelectAktivne_Result narudzba { get; set; } 
        public Frm_Racun()
        {
            InitializeComponent();
        }

        private void Frm_Racun_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DSOrderDetails", narudzba.NarudzbaStavke);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Kupac", narudzba.Kupac));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("BrojNarudzbe", narudzba.BrojNarudzbe));
            this.reportViewer1.RefreshReport();
        }
    }
}
