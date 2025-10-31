using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    // Asegúrate de que este enum (FormMode) esté accesible
    // (puedes moverlo a un archivo propio si lo usas en varios formularios)
    // public enum FormMode { Add, Update }

    public partial class CategoriaDetalle : Form
    {
        private FormMode _mode;
        private CategoriaDTO _categoria;

        public CategoriaDetalle(FormMode mode, CategoriaDTO? categoria = null)
        {
            InitializeComponent();
            _mode = mode;
            _categoria = categoria ?? new CategoriaDTO();
        }

        private void CategoriaDetalle_Load(object sender, EventArgs e)
        {
            if (_mode == FormMode.Update)
            {
                this.Text = "Modificar Categoría";

                // Llenar el formulario con los datos
                idTextBox.Text = _categoria.Id.ToString();
                nombreTextBox.Text = _categoria.Nombre;
                descripcionTextBox.Text = _categoria.Descripcion;
                activoCheckBox.Checked = _categoria.Activo;
            }
            else
            {
                this.Text = "Agregar Categoría";
                idTextBox.Text = "(Nuevo)";
                // Por defecto, una nueva categoría está activa
                activoCheckBox.Checked = true;
                // Ocultamos el checkbox al crear, ya que siempre es 'Activo = true'
                activoCheckBox.Visible = false;
            }
        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _categoria.Nombre = nombreTextBox.Text;
            _categoria.Descripcion = descripcionTextBox.Text;
            _categoria.Activo = activoCheckBox.Checked;

            try
            {
                if (_mode == FormMode.Add)
                {
                    await CategoriaApiClient.AddAsync(_categoria);
                    MessageBox.Show("Categoría creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await CategoriaApiClient.UpdateAsync(_categoria);
                    MessageBox.Show("Categoría modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}