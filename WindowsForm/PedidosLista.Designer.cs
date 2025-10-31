namespace WindowsForms
{
    partial class PedidosLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView pedidosDataGridView;
        private System.Windows.Forms.Panel filtroPanel; // Panel para filtros de Admin
        private System.Windows.Forms.TextBox idFiltroTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreFiltroTextBox;
        private System.Windows.Forms.Button verDetalleButton;

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
            this.pedidosDataGridView = new System.Windows.Forms.DataGridView();
            this.filtroPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.idFiltroTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreFiltroTextBox = new System.Windows.Forms.TextBox();
            this.verDetalleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosDataGridView)).BeginInit();
            this.filtroPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pedidosDataGridView
            // 
            this.pedidosDataGridView.AllowUserToAddRows = false;
            this.pedidosDataGridView.AllowUserToDeleteRows = false;
            this.pedidosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pedidosDataGridView.Location = new System.Drawing.Point(12, 70);
            this.pedidosDataGridView.MultiSelect = false;
            this.pedidosDataGridView.Name = "pedidosDataGridView";
            this.pedidosDataGridView.ReadOnly = true;
            this.pedidosDataGridView.RowTemplate.Height = 25;
            this.pedidosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pedidosDataGridView.Size = new System.Drawing.Size(776, 320);
            this.pedidosDataGridView.TabIndex = 0;
            // 
            // filtroPanel
            // 
            this.filtroPanel.Controls.Add(this.label2);
            this.filtroPanel.Controls.Add(this.nombreFiltroTextBox);
            this.filtroPanel.Controls.Add(this.label1);
            this.filtroPanel.Controls.Add(this.idFiltroTextBox);
            this.filtroPanel.Location = new System.Drawing.Point(12, 12);
            this.filtroPanel.Name = "filtroPanel";
            this.filtroPanel.Size = new System.Drawing.Size(776, 52);
            this.filtroPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtrar por ID:";
            // 
            // idFiltroTextBox
            // 
            this.idFiltroTextBox.Location = new System.Drawing.Point(105, 15);
            this.idFiltroTextBox.Name = "idFiltroTextBox";
            this.idFiltroTextBox.Size = new System.Drawing.Size(100, 23);
            this.idFiltroTextBox.TabIndex = 0;
            this.idFiltroTextBox.TextChanged += new System.EventHandler(this.filtros_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtrar por Usuario:";
            // 
            // nombreFiltroTextBox
            // 
            this.nombreFiltroTextBox.Location = new System.Drawing.Point(357, 15);
            this.nombreFiltroTextBox.Name = "nombreFiltroTextBox";
            this.nombreFiltroTextBox.Size = new System.Drawing.Size(150, 23);
            this.nombreFiltroTextBox.TabIndex = 2;
            this.nombreFiltroTextBox.TextChanged += new System.EventHandler(this.filtros_TextChanged);
            // 
            // verDetalleButton
            // 
            this.verDetalleButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.verDetalleButton.Location = new System.Drawing.Point(688, 405);
            this.verDetalleButton.Name = "verDetalleButton";
            this.verDetalleButton.Size = new System.Drawing.Size(100, 33);
            this.verDetalleButton.TabIndex = 2;
            this.verDetalleButton.Text = "Ver Detalle";
            this.verDetalleButton.UseVisualStyleBackColor = true;
            this.verDetalleButton.Click += new System.EventHandler(this.verDetalleButton_Click);
            // 
            // PedidosLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.verDetalleButton);
            this.Controls.Add(this.filtroPanel);
            this.Controls.Add(this.pedidosDataGridView);
            this.Name = "PedidosLista";
            this.Text = "Historial de Pedidos";
            this.Load += new System.EventHandler(this.PedidosLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pedidosDataGridView)).EndInit();
            this.filtroPanel.ResumeLayout(false);
            this.filtroPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}