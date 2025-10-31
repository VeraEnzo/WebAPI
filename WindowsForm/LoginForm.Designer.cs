namespace WindowsForms
{
    partial class LoginForm
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
            emailLabel = new Label();
            contrasenaLabel = new Label();
            emailTextBox = new TextBox();
            contrasenaTextBox = new TextBox();
            ingresarButton = new Button();
            registrarButton = new Button(); // Botón de invitado reemplazado
            SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(58, 36);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 0;
            emailLabel.Text = "Email";
            // 
            // contrasenaLabel
            // 
            contrasenaLabel.AutoSize = true;
            contrasenaLabel.Location = new Point(27, 80);
            contrasenaLabel.Name = "contrasenaLabel";
            contrasenaLabel.Size = new Size(67, 15);
            contrasenaLabel.TabIndex = 1;
            contrasenaLabel.Text = "Contraseña";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(121, 33);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(160, 23);
            emailTextBox.TabIndex = 2;
            // 
            // contrasenaTextBox
            // 
            contrasenaTextBox.Location = new Point(122, 77);
            contrasenaTextBox.Name = "contrasenaTextBox";
            contrasenaTextBox.PasswordChar = '*';
            contrasenaTextBox.Size = new Size(160, 23);
            contrasenaTextBox.TabIndex = 3;
            // 
            // ingresarButton
            // 
            ingresarButton.Location = new Point(63, 139);
            ingresarButton.Name = "ingresarButton";
            ingresarButton.Size = new Size(75, 23);
            ingresarButton.TabIndex = 4;
            ingresarButton.Text = "Ingresar";
            ingresarButton.UseVisualStyleBackColor = true;
            ingresarButton.Click += ingresarButton_Click;
            // 
            // registrarButton
            // 
            registrarButton.Location = new Point(206, 139);
            registrarButton.Name = "registrarButton";
            registrarButton.Size = new Size(75, 23);
            registrarButton.TabIndex = 5;
            registrarButton.Text = "Registrar";
            registrarButton.UseVisualStyleBackColor = true;
            registrarButton.Click += registrarButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 213);
            Controls.Add(registrarButton);
            Controls.Add(ingresarButton);
            Controls.Add(contrasenaTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(contrasenaLabel);
            Controls.Add(emailLabel);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label emailLabel;
        private Label contrasenaLabel;
        private TextBox emailTextBox;
        private TextBox contrasenaTextBox;
        private Button ingresarButton;
        private Button registrarButton; // CheckBox y Botón de invitado eliminados
    }
}