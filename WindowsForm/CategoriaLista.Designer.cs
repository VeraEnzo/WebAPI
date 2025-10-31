namespace WindowsForms
{
    partial class CategoriaLista
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView categoriasDataGridView;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button eliminarButton;

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
            this.categoriasDataGridView = new System.Windows.Forms.DataGridView();
            this.agregarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriasDataGridView
            // 
            this.categoriasDataGridView.AllowUserToAddRows = false;
            this.categoriasDataGridView.AllowUserToDeleteRows = false;
            this.categoriasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriasDataGridView.Location = new System.Drawing.Point(12, 12);
            this.categoriasDataGridView.MultiSelect = false;
            this.categoriasDataGridView.Name = "categoriasDataGridView";
            this.categoriasDataGridView.ReadOnly = true;
            this.categoriasDataGridView.RowTemplate.Height = 25;
            this.categoriasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoriasDataGridView.Size = new System.Drawing.Size(776, 380);
            this.categoriasDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            this.agregarButton.Location = new System.Drawing.Point(713, 407);
            this.agregarButton.Name = "agregarButton";
            this.agregarButton.Size = new System.Drawing.Size(75, 23);
            this.agregarButton.TabIndex = 1;
            this.agregarButton.Text = "Agregar";
            this.agregarButton.UseVisualStyleBackColor = true;
            this.agregarButton.Click += new System.EventHandler(this.agregarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(632, 407);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 2;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(551, 407);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 3;
            this.eliminarButton.Text = "Desactivar"; // Cambiamos el texto
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // CategoriaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.agregarButton);
            this.Controls.Add(this.categoriasDataGridView);
            this.Name = "CategoriaLista";
            this.Text = "Gestión de Categorías";
            this.Load += new System.EventHandler(this.CategoriaLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoriasDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
    }
}