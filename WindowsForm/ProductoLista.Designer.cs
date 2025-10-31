namespace WindowsForms
{
    partial class ProductoLista
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            productosDataGridView = new DataGridView();
            modificarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            cantidadNumericUpDown = new NumericUpDown();
            agregarAlCarritoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)productosDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cantidadNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // productosDataGridView
            // 
            productosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productosDataGridView.Location = new Point(20, 18);
            productosDataGridView.MultiSelect = false;
            productosDataGridView.Name = "productosDataGridView";
            productosDataGridView.ReadOnly = true;
            productosDataGridView.RowHeadersWidth = 82;
            productosDataGridView.RowTemplate.Height = 41;
            productosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productosDataGridView.Size = new Size(768, 300);
            productosDataGridView.TabIndex = 0;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(613, 343);
            modificarButton.Margin = new Padding(2, 1, 2, 1);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(81, 22);
            modificarButton.TabIndex = 6;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(521, 343);
            eliminarButton.Margin = new Padding(2, 1, 2, 1);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(81, 22);
            eliminarButton.TabIndex = 5;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(706, 343);
            agregarButton.Margin = new Padding(2, 1, 2, 1);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(81, 22);
            agregarButton.TabIndex = 4;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // cantidadNumericUpDown
            // 
            cantidadNumericUpDown.Location = new Point(20, 342);
            cantidadNumericUpDown.Name = "cantidadNumericUpDown";
            cantidadNumericUpDown.Size = new Size(120, 23);
            cantidadNumericUpDown.TabIndex = 7;
            // 
            // agregarAlCarritoButton
            // 
            agregarAlCarritoButton.Location = new Point(146, 342);
            agregarAlCarritoButton.Name = "agregarAlCarritoButton";
            agregarAlCarritoButton.Size = new Size(114, 23);
            agregarAlCarritoButton.TabIndex = 8;
            agregarAlCarritoButton.Text = "Agregar al pedido";
            agregarAlCarritoButton.UseVisualStyleBackColor = true;
            agregarAlCarritoButton.Click += agregarAlCarritoButton_Click;
            // 
            // ProductoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(agregarAlCarritoButton);
            Controls.Add(cantidadNumericUpDown);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(productosDataGridView);
            Name = "ProductoLista";
            Text = "Form1";
            Load += ProductoLista_Load;
            ((System.ComponentModel.ISupportInitialize)productosDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)cantidadNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView productosDataGridView;
        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private NumericUpDown cantidadNumericUpDown;
        private Button agregarAlCarritoButton;
    }
}
