namespace eProdajaNamjestaja_UI.Reports
{
    partial class Frm_Racun
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource
            // 
            this.esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource.DataSource = typeof(eProdajaNamjestaja_API.Models.esp_NarudzbeStavke_SelectByNarudzbaID_Result);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eProdajaNamjestaja_UI.Reports.OrederDetailsReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(488, 315);
            this.reportViewer1.TabIndex = 0;
            // 
            // Frm_Racun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 315);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Racun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Racun";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Racun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource esp_NarudzbeStavke_SelectByNarudzbaID_ResultBindingSource;
    }
}