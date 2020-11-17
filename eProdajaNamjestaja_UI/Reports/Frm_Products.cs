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
    public partial class Frm_Products : Form
    {
        public Frm_Products()
        {
            InitializeComponent();
        }

        private void Frm_Products_Load(object sender, EventArgs e)
        {
            DSProducts dsProducts = new DSProducts();
            DSProductsTableAdapters.ProductsTableAdapter adapter = new DSProductsTableAdapters.ProductsTableAdapter();
            adapter.Fill(dsProducts.Products);
            bindingSource1.DataSource = dsProducts.Products;

            ReportDataSource rds = new ReportDataSource("Products", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
