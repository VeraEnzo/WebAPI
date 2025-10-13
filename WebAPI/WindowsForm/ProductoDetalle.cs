using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WindowsForms
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class ProductoDetalle : Form
    {
        private ProductoDTO producto;
        private FormMode mode;

        public ProductoDTO Producto
        {
            get { return producto; }
            set
            {
                producto = value;
                this.SetProducto();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        public ProductoDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateProducto())
            {
                try
                {
                    this.Producto.Nombre = nombreTextBox.Text;
                    this.Producto.Descripcion = descripciónTextBox.Text;
                    this.Producto.Precio = decimal.Parse(precioTextBox.Text);
                    this.Producto.Stock = int.Parse(stockTextBox.Text);
                    this.Producto.CategoriaId = int.Parse(categoriaTextBox.Text);
                    this.Producto.ProveedorId = int.Parse(proveedorTextBox.Text);

                    if (this.Mode == FormMode.Update)
                    {
                        await ProductoApiClient.UpdateAsync(this.Producto);
                    }
                    else
                    {
                        await ProductoApiClient.AddAsync(this.Producto);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetProducto()
        {
            this.idTextBox.Text = this.Producto.Id.ToString();
            this.nombreTextBox.Text = this.Producto.Nombre;
            this.descripciónTextBox.Text = this.Producto.Descripcion;
            this.precioTextBox.Text = this.Producto.Precio.ToString();
            this.stockTextBox.Text = this.Producto.Stock.ToString();
            this.categoriaTextBox.Text = this.Producto.CategoriaId.ToString();
            this.proveedorTextBox.Text = this.Producto.ProveedorId.ToString();
        }

        private bool ValidateProducto()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(descripciónTextBox, string.Empty);
            errorProvider.SetError(precioTextBox, string.Empty);
            errorProvider.SetError(stockTextBox, string.Empty);
            errorProvider.SetError(categoriaTextBox, string.Empty);
            errorProvider.SetError(proveedorTextBox, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El nombre es Requerido");
            }

            if (this.descripciónTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(descripciónTextBox, "La descripción es Requerido");
            }

            if (this.precioTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(precioTextBox, "El precio es Requerido");
            }

            if (this.stockTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(stockTextBox, "El stock es Requerido");
            }

            if (this.categoriaTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(categoriaTextBox, "La categoria es Requerido");
            }

            if (this.proveedorTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(proveedorTextBox, "El proveedor es Requerido");
            }

            return isValid;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

    }
}
