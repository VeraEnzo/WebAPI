namespace WindowsForms
{
    partial class PedidoDetalleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView detalleDataGridView;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.detalleDataGridView = new System.Windows.Forms.DataGridView();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // detalleDataGridView
            // 
            this.detalleDataGridView.AllowUserToAddRows = false;
            this.detalleDataGridView.AllowUserToDeleteRows = false;
            this.detalleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalleDataGridView.Location = new System.Drawing.Point(12, 45);
            this.detalleDataGridView.Name = "detalleDataGridView";
            this.detalleDataGridView.ReadOnly = true;
            this.detalleDataGridView.RowTemplate.Height = 25;
            this.detalleDataGridView.Size = new System.Drawing.Size(560, 350);
            this.detalleDataGridView.TabIndex = 0;
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(155, 21);
            this.tituloLabel.TabIndex = 1;
            this.tituloLabel.Text = "Detalle del Pedido #";
            // 
            // totalLabel
            // 
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalLabel.Location = new System.Drawing.Point(418, 410);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(154, 21);
            this.totalLabel.TabIndex = 2;
            this.totalLabel.Text = "$ 0.00";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(357, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total:";
            // 
            // PedidoDetalleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.tituloLabel);
            this.Controls.Add(this.detalleDataGridView);
            this.Name = "PedidoDetalleForm";
            this.Text = "Detalle de Pedido";
            this.Load += new System.EventHandler(this.PedidoDetalleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detalleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}