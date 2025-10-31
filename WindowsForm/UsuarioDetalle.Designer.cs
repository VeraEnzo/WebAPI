namespace WindowsForms
{
    partial class UsuarioDetalle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label contrasenaLabel;
        private System.Windows.Forms.TextBox contrasenaTextBox;
        private System.Windows.Forms.CheckBox adminCheckBox;
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
            this.apellidoLabel = new System.Windows.Forms.Label();
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.contrasenaLabel = new System.Windows.Forms.Label();
            this.contrasenaTextBox = new System.Windows.Forms.TextBox();
            this.adminCheckBox = new System.Windows.Forms.CheckBox();
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
            // apellidoLabel
            // 
            this.apellidoLabel.AutoSize = true;
            this.apellidoLabel.Location = new System.Drawing.Point(30, 110);
            this.apellidoLabel.Name = "apellidoLabel";
            this.apellidoLabel.Size = new System.Drawing.Size(51, 15);
            this.apellidoLabel.TabIndex = 4;
            this.apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            this.apellidoTextBox.Location = new System.Drawing.Point(120, 107);
            this.apellidoTextBox.Name = "apellidoTextBox";
            this.apellidoTextBox.Size = new System.Drawing.Size(200, 23);
            this.apellidoTextBox.TabIndex = 5;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(30, 150);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(36, 15);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(120, 147);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 23);
            this.emailTextBox.TabIndex = 7;
            // 
            // contrasenaLabel
            // 
            this.contrasenaLabel.AutoSize = true;
            this.contrasenaLabel.Location = new System.Drawing.Point(30, 190);
            this.contrasenaLabel.Name = "contrasenaLabel";
            this.contrasenaLabel.Size = new System.Drawing.Size(67, 15);
            this.contrasenaLabel.TabIndex = 8;
            this.contrasenaLabel.Text = "Contraseña";
            // 
            // contrasenaTextBox
            // 
            this.contrasenaTextBox.Location = new System.Drawing.Point(120, 187);
            this.contrasenaTextBox.Name = "contrasenaTextBox";
            this.contrasenaTextBox.PasswordChar = '*';
            this.contrasenaTextBox.Size = new System.Drawing.Size(200, 23);
            this.contrasenaTextBox.TabIndex = 9;
            // 
            // adminCheckBox
            // 
            this.adminCheckBox.AutoSize = true;
            this.adminCheckBox.Location = new System.Drawing.Point(120, 230);
            this.adminCheckBox.Name = "adminCheckBox";
            this.adminCheckBox.Size = new System.Drawing.Size(97, 19);
            this.adminCheckBox.TabIndex = 10;
            this.adminCheckBox.Text = "Es Administrador";
            this.adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(164, 270);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 11;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(245, 270);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 12;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // UsuarioDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 311);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.adminCheckBox);
            this.Controls.Add(this.contrasenaTextBox);
            this.Controls.Add(this.contrasenaLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.apellidoTextBox);
            this.Controls.Add(this.apellidoLabel);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Usuario";
            this.Load += new System.EventHandler(this.UsuarioDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}