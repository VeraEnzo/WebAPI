namespace WindowsForms
{
    partial class CarritoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView carritoDataGridView;
        private System.Windows.Forms.Button disminuirButton;
        private System.Windows.Forms.Button aumentarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button finalizarPedidoButton;

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
            this.carritoDataGridView = new System.Windows.Forms.DataGridView();
            this.disminuirButton = new System.Windows.Forms.Button();
            this.aumentarButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.finalizarPedidoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carritoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // carritoDataGridView
            // 
            this.carritoDataGridView.AllowUserToAddRows = false;
            this.carritoDataGridView.AllowUserToDeleteRows = false;
            this.carritoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carritoDataGridView.Location = new System.Drawing.Point(12, 12);
            this.carritoDataGridView.MultiSelect = false;
            this.carritoDataGridView.Name = "carritoDataGridView";
            this.carritoDataGridView.ReadOnly = true;
            this.carritoDataGridView.RowTemplate.Height = 25;
            this.carritoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.carritoDataGridView.Size = new System.Drawing.Size(550, 380);
            this.carritoDataGridView.TabIndex = 0;
            // 
            // disminuirButton
            // 
            this.disminuirButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.disminuirButton.Location = new System.Drawing.Point(580, 12);
            this.disminuirButton.Name = "disminuirButton";
            this.disminuirButton.Size = new System.Drawing.Size(30, 30);
            this.disminuirButton.TabIndex = 1;
            this.disminuirButton.Text = "-";
            this.disminuirButton.UseVisualStyleBackColor = true;
            this.disminuirButton.Click += new System.EventHandler(this.disminuirButton_Click);
            // 
            // aumentarButton
            // 
            this.aumentarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.aumentarButton.Location = new System.Drawing.Point(616, 12);
            this.aumentarButton.Name = "aumentarButton";
            this.aumentarButton.Size = new System.Drawing.Size(30, 30);
            this.aumentarButton.TabIndex = 2;
            this.aumentarButton.Text = "+";
            this.aumentarButton.UseVisualStyleBackColor = true;
            this.aumentarButton.Click += new System.EventHandler(this.aumentarButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(580, 57);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(66, 30);
            this.eliminarButton.TabIndex = 3;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalLabel.Location = new System.Drawing.Point(408, 408);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(154, 21);
            this.totalLabel.TabIndex = 4;
            this.totalLabel.Text = "$ 0.00";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(347, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total:";
            // 
            // finalizarPedidoButton
            // 
            this.finalizarPedidoButton.BackColor = System.Drawing.Color.PaleGreen;
            this.finalizarPedidoButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finalizarPedidoButton.Location = new System.Drawing.Point(580, 398);
            this.finalizarPedidoButton.Name = "finalizarPedidoButton";
            this.finalizarPedidoButton.Size = new System.Drawing.Size(66, 40);
            this.finalizarPedidoButton.TabIndex = 6;
            this.finalizarPedidoButton.Text = "Finalizar Pedido";
            this.finalizarPedidoButton.UseVisualStyleBackColor = false;
            this.finalizarPedidoButton.Click += new System.EventHandler(this.finalizarPedidoButton_Click);
            // 
            // CarritoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 450);
            this.Controls.Add(this.finalizarPedidoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.aumentarButton);
            this.Controls.Add(this.disminuirButton);
            this.Controls.Add(this.carritoDataGridView);
            this.Name = "CarritoForm";
            this.Text = "Carrito de Compras";
            this.Load += new System.EventHandler(this.CarritoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carritoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}