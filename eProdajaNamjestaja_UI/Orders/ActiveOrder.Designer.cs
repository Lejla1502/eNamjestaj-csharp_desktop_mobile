namespace eProdajaNamjestaja_UI.Orders
{
    partial class ActiveOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 


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
            this.narudzbeGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.narudzbeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // narudzbeGrid
            // 
            this.narudzbeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.narudzbeGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.narudzbeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.narudzbeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.narudzbeGrid.Location = new System.Drawing.Point(0, 0);
            this.narudzbeGrid.Name = "narudzbeGrid";
            this.narudzbeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.narudzbeGrid.Size = new System.Drawing.Size(491, 384);
            this.narudzbeGrid.TabIndex = 0;
            this.narudzbeGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.narudzbeGrid_CellDoubleClick);
            // 
            // ActiveOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 384);
            this.Controls.Add(this.narudzbeGrid);
            this.Name = "ActiveOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktivne narudžbe";
            this.Load += new System.EventHandler(this.ActiveOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.narudzbeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView narudzbeGrid;
    }
}