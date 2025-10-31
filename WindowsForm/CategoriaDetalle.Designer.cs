namespace WindowsForms
{
    partial class CategoriaDetalle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.CheckBox activoCheckBox;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button cancelarButton;

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
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.activoCheckBox = new System.Windows.Forms.CheckBox();
            this.guardarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(30, 30);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 15);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(120, 27);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(100, 23);
            this.idTextBox.TabIndex = 1;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(30, 70);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(51, 15);
            this.nombreLabel.TabIndex = 2;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(120, 67);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(200, 23);
            this.nombreTextBox.TabIndex = 3;
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Location = new System.Drawing.Point(30, 110);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(69, 15);
            this.descripcionLabel.TabIndex = 4;
            this.descripcionLabel.Text = "Descripción";
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Location = new System.Drawing.Point(120, 107);
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(200, 60);
            this.descripcionTextBox.TabIndex = 5;
            // 
            // activoCheckBox
            // 
            this.activoCheckBox.AutoSize = true;
            this.activoCheckBox.Location = new System.Drawing.Point(120, 185);
            this.activoCheckBox.Name = "activoCheckBox";
            this.activoCheckBox.Size = new System.Drawing.Size(59, 19);
            this.activoCheckBox.TabIndex = 6;
            this.activoCheckBox.Text = "Activa";
            this.activoCheckBox.UseVisualStyleBackColor = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(164, 230);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 7;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(245, 230);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 8;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // CategoriaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 276);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.activoCheckBox);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(this.descripcionLabel);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoriaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Categoría";
            this.Load += new System.EventHandler(this.CategoriaDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}