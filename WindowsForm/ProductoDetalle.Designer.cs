namespace WindowsForms
{
    partial class ProductoDetalle
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
            components = new System.ComponentModel.Container();
            idLabel = new Label();
            idTextBox = new TextBox();
            precioLabel = new Label();
            precioTextBox = new TextBox();
            descripciónLabel = new Label();
            errorProvider = new ErrorProvider(components);
            descripciónTextBox = new TextBox();
            cancelarButton = new Button();
            aceptarButton = new Button();
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            categoriaLabel = new Label();
            categoriaTextBox = new TextBox();
            stockLabel = new Label();
            stockTextBox = new TextBox();
            proveedorLabel = new Label();
            proveedorTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(11, 9);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(17, 15);
            idLabel.TabIndex = 23;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(118, 9);
            idTextBox.Margin = new Padding(2, 1, 2, 1);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(110, 23);
            idTextBox.TabIndex = 12;
            idTextBox.TabStop = false;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new Point(11, 113);
            precioLabel.Margin = new Padding(2, 0, 2, 0);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new Size(40, 15);
            precioLabel.TabIndex = 21;
            precioLabel.Text = "Precio";
            // 
            // precioTextBox
            // 
            precioTextBox.Location = new Point(118, 113);
            precioTextBox.Margin = new Padding(2, 1, 2, 1);
            precioTextBox.Name = "precioTextBox";
            precioTextBox.Size = new Size(110, 23);
            precioTextBox.TabIndex = 17;
            // 
            // descripciónLabel
            // 
            descripciónLabel.AutoSize = true;
            descripciónLabel.Location = new Point(11, 76);
            descripciónLabel.Margin = new Padding(2, 0, 2, 0);
            descripciónLabel.Name = "descripciónLabel";
            descripciónLabel.Size = new Size(69, 15);
            descripciónLabel.TabIndex = 20;
            descripciónLabel.Text = "Descripción";
            // 
            // descripciónTextBox
            // 
            descripciónTextBox.Location = new Point(118, 76);
            descripciónTextBox.Margin = new Padding(2, 1, 2, 1);
            descripciónTextBox.Name = "descripciónTextBox";
            descripciónTextBox.Size = new Size(110, 23);
            descripciónTextBox.TabIndex = 15;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(410, 246);
            cancelarButton.Margin = new Padding(2, 1, 2, 1);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(81, 22);
            cancelarButton.TabIndex = 19;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(318, 246);
            aceptarButton.Margin = new Padding(2, 1, 2, 1);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(81, 22);
            aceptarButton.TabIndex = 18;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(11, 45);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 16;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(118, 45);
            nombreTextBox.Margin = new Padding(2, 1, 2, 1);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(110, 23);
            nombreTextBox.TabIndex = 14;
            // 
            // categoriaLabel
            // 
            categoriaLabel.AutoSize = true;
            categoriaLabel.Location = new Point(11, 185);
            categoriaLabel.Margin = new Padding(2, 0, 2, 0);
            categoriaLabel.Name = "categoriaLabel";
            categoriaLabel.Size = new Size(58, 15);
            categoriaLabel.TabIndex = 27;
            categoriaLabel.Text = "Categoria";
            // 
            // categoriaTextBox
            // 
            categoriaTextBox.Location = new Point(118, 185);
            categoriaTextBox.Margin = new Padding(2, 1, 2, 1);
            categoriaTextBox.Name = "categoriaTextBox";
            categoriaTextBox.Size = new Size(110, 23);
            categoriaTextBox.TabIndex = 25;
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(11, 148);
            stockLabel.Margin = new Padding(2, 0, 2, 0);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(36, 15);
            stockLabel.TabIndex = 26;
            stockLabel.Text = "Stock";
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(118, 148);
            stockTextBox.Margin = new Padding(2, 1, 2, 1);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(110, 23);
            stockTextBox.TabIndex = 24;
            // 
            // proveedorLabel
            // 
            proveedorLabel.AutoSize = true;
            proveedorLabel.Location = new Point(11, 224);
            proveedorLabel.Margin = new Padding(2, 0, 2, 0);
            proveedorLabel.Name = "proveedorLabel";
            proveedorLabel.Size = new Size(61, 15);
            proveedorLabel.TabIndex = 29;
            proveedorLabel.Text = "Proveedor";
            // 
            // proveedorTextBox
            // 
            proveedorTextBox.Location = new Point(118, 224);
            proveedorTextBox.Margin = new Padding(2, 1, 2, 1);
            proveedorTextBox.Name = "proveedorTextBox";
            proveedorTextBox.Size = new Size(110, 23);
            proveedorTextBox.TabIndex = 28;
            // 
            // ProductoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 288);
            Controls.Add(proveedorLabel);
            Controls.Add(proveedorTextBox);
            Controls.Add(categoriaLabel);
            Controls.Add(categoriaTextBox);
            Controls.Add(stockLabel);
            Controls.Add(stockTextBox);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            Controls.Add(precioLabel);
            Controls.Add(precioTextBox);
            Controls.Add(descripciónLabel);
            Controls.Add(descripciónTextBox);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Name = "ProductoDetalle";
            Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Button aceptarButton;
        private ErrorProvider errorProvider;
        private Button cancelarButton;
        private Label precioLabel;
        private TextBox precioTextBox;
        private Label descripciónLabel;
        private TextBox descripciónTextBox;
        private Label nombreLabel;
        private TextBox nombreTextBox;
        private Label categoriaLabel;
        private TextBox categoriaTextBox;
        private Label stockLabel;
        private TextBox stockTextBox;
        private Label proveedorLabel;
        private TextBox proveedorTextBox;
    }
}