namespace WindowsForms
{
    partial class RegistroForm
    {
        private System.ComponentModel.IContainer components = null;

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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            contrasenaLabel = new Label();
            contrasenaTextBox = new TextBox();
            confirmarContrasenaLabel = new Label();
            confirmarContrasenaTextBox = new TextBox();
            guardarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(40, 30);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(180, 27);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(200, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(40, 70);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(51, 15);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(180, 67);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(200, 23);
            apellidoTextBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(40, 110);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(180, 107);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(200, 23);
            emailTextBox.TabIndex = 3;
            // 
            // contrasenaLabel
            // 
            contrasenaLabel.AutoSize = true;
            contrasenaLabel.Location = new Point(40, 150);
            contrasenaLabel.Name = "contrasenaLabel";
            contrasenaLabel.Size = new Size(67, 15);
            contrasenaLabel.TabIndex = 6;
            contrasenaLabel.Text = "Contraseña";
            // 
            // contrasenaTextBox
            // 
            contrasenaTextBox.Location = new Point(180, 147);
            contrasenaTextBox.Name = "contrasenaTextBox";
            contrasenaTextBox.PasswordChar = '*';
            contrasenaTextBox.Size = new Size(200, 23);
            contrasenaTextBox.TabIndex = 4;
            // 
            // confirmarContrasenaLabel
            // 
            confirmarContrasenaLabel.AutoSize = true;
            confirmarContrasenaLabel.Location = new Point(40, 190);
            confirmarContrasenaLabel.Name = "confirmarContrasenaLabel";
            confirmarContrasenaLabel.Size = new Size(124, 15);
            confirmarContrasenaLabel.TabIndex = 8;
            confirmarContrasenaLabel.Text = "Confirmar Contraseña";
            // 
            // confirmarContrasenaTextBox
            // 
            confirmarContrasenaTextBox.Location = new Point(180, 187);
            confirmarContrasenaTextBox.Name = "confirmarContrasenaTextBox";
            confirmarContrasenaTextBox.PasswordChar = '*';
            confirmarContrasenaTextBox.Size = new Size(200, 23);
            confirmarContrasenaTextBox.TabIndex = 5;
            // 
            // guardarButton
            // 
            guardarButton.Location = new Point(224, 240);
            guardarButton.Name = "guardarButton";
            guardarButton.Size = new Size(75, 23);
            guardarButton.TabIndex = 6;
            guardarButton.Text = "Guardar";
            guardarButton.UseVisualStyleBackColor = true;
            guardarButton.Click += guardarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(305, 240);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // RegistroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 291);
            Controls.Add(cancelarButton);
            Controls.Add(guardarButton);
            Controls.Add(confirmarContrasenaTextBox);
            Controls.Add(confirmarContrasenaLabel);
            Controls.Add(contrasenaTextBox);
            Controls.Add(contrasenaLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(nombreLabel);
            Name = "RegistroForm";
            Text = "Registro de Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreLabel;
        private TextBox nombreTextBox;
        private Label apellidoLabel;
        private TextBox apellidoTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label contrasenaLabel;
        private TextBox contrasenaTextBox;
        private Label confirmarContrasenaLabel;
        private TextBox confirmarContrasenaTextBox;
        private Button guardarButton;
        private Button cancelarButton;
    }
}