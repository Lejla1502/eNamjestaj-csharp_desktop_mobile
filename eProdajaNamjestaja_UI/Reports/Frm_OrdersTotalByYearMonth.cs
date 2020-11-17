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
    public partial class Frm_OrdersTotalByYearMonth : Form
    {
        DSOrders dsOrders = new DSOrders();
        public Frm_OrdersTotalByYearMonth()
        {
            InitializeComponent();
        }

        private void Frm_OrdersTotalByYearMonth_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eProdajaNamjestaja_UI.Reports.OrdersTotalByYearMonth.rdlc";
            DAOrders.SelectOrdersTotal(dsOrders.OrdersTotal);
            bindingSource1.DataSource = dsOrders.OrdersTotal;
            ReportDataSource rds = new ReportDataSource("OrdersTotal", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
