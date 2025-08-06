namespace WindowsForms
{
    partial class LoginForm
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
            emailLabel = new Label();
            contrasenaLabel = new Label();
            emailTextBox = new TextBox();
            contrasenaTextBox = new TextBox();
            ingresarButton = new Button();
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
            contrasenaLabel.Text = "Contrasena";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(121, 33);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 2;
            // 
            // contrasenaTextBox
            // 
            contrasenaTextBox.Location = new Point(122, 77);
            contrasenaTextBox.Name = "contrasenaTextBox";
            contrasenaTextBox.Size = new Size(100, 23);
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
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 213);
            Controls.Add(ingresarButton);
            Controls.Add(contrasenaTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(contrasenaLabel);
            Controls.Add(emailLabel);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label emailLabel;
        private Label contrasenaLabel;
        private TextBox emailTextBox;
        private TextBox contrasenaTextBox;
        private Button ingresarButton;
    }
}