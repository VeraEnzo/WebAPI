namespace WindowsForms
{
    partial class UsuarioLista
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
            usuariosDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // usuariosDataGridView
            // 
            usuariosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usuariosDataGridView.Location = new Point(20, 12);
            usuariosDataGridView.MultiSelect = false;
            usuariosDataGridView.Name = "usuariosDataGridView";
            usuariosDataGridView.ReadOnly = true;
            usuariosDataGridView.RowHeadersWidth = 82;
            usuariosDataGridView.RowTemplate.Height = 41;
            usuariosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usuariosDataGridView.Size = new Size(755, 300);
            usuariosDataGridView.TabIndex = 1;
            // 
            // UsuarioLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(usuariosDataGridView);
            Name = "UsuarioLista";
            Text = "Usuarios";
            Load += UsuarioLista_Load;
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usuariosDataGridView;
    }
}