using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta;
            rta = MessageBox.Show("Desea salir de la edición ?", "Mensaje de advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodProd.Clear();
            txtNombre.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtCategoria.Clear();
            txtDetalle.Clear();
            txtDetalle.Clear();
            txtFotoProd.Clear();
            txtCantStock.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public bool Guardar()
        {
            bool actualizado = false;

            if (Validar())
            {
                try
                {
                    Acceso_datos acceso = new Acceso_datos();
                    string sentencia = $"Exec actualizar_Producto '{txtNombre.Text}'," +
                        $"{txtCodProd.Text}," +
                        $"{txtPrecioCompra.Text}," +
                        $"{txtPrecioVenta.Text}," +
                        $"{txtCategoria.Text}," +
                        $"'{txtDetalle.Text}'," +
                        $"'{txtFotoProd.Text}'," +
                        $"{txtCantStock.Text}," +
                        $"'{DateTime.Now.Date.ToString("yyyy-MM-dd")}', " +
                        $"'ADMIN' ";
                    MessageBox.Show(acceso.EjecutarComando(sentencia));
                    actualizado = true;
                }
                catch (Exception e)
                {

                    MessageBox.Show($"Falló la inserción '{e}'");
                    actualizado = false;
                }
            }
            Llenar_Grid();
            return actualizado;
        }

        private bool Validar()
        {

            Boolean errorCampos = true;
            if (txtNombre.Text == string.Empty)
            {
                MensajeError.SetError(txtNombre, "debe ingresar el nombre del Producto");
                txtNombre.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtNombre, "");
            }
            if (txtPrecioCompra.Text == string.Empty)
            {
                MensajeError.SetError(txtPrecioCompra, "debe ingresar el precio de compra");
                txtPrecioCompra.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtPrecioCompra, "");
            }
            frmEmpleado empleado = new frmEmpleado();
            if (!empleado.esNumerico(txtPrecioCompra.Text))
            {
                MensajeError.SetError(txtPrecioCompra, "El precio debe ser numerico");
                txtPrecioCompra.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtPrecioCompra, "");
            }
            if (!empleado.esNumerico(txtPrecioVenta.Text))
            {
                MensajeError.SetError(txtPrecioVenta, "El precio debe ser numerico");
                txtPrecioVenta.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtPrecioVenta, "");
            }
            return errorCampos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Acceso_datos acceso = new Acceso_datos();
            string sentencia = $"Exec Eliminar_Producto '{Convert.ToInt32(txtCodProd.Text)}'";
            MessageBox.Show(acceso.EjecutarComando(sentencia));
            Limpiar();
            Llenar_Grid();

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            Llenar_Grid();
        }

        private void Llenar_Grid()
        {
            DataTable dt = new DataTable();
            Acceso_datos acceso = new Acceso_datos();
            dt = acceso.CargarTabla("TBLPRODUCTO", "");
            dgProductos.DataSource = dt;
        }

        private void dgProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int posActual = 0;
            posActual = dgProductos.CurrentRow.Index;

            txtCodProd.Text = dgProductos[0, posActual].Value.ToString();
            txtNombre.Text = dgProductos[1, posActual].Value.ToString();
            txtPrecioCompra.Text = dgProductos[2, posActual].Value.ToString();
            txtPrecioVenta.Text = dgProductos[3, posActual].Value.ToString();
            txtCategoria.Text = dgProductos[4, posActual].Value.ToString();
            txtDetalle.Text = dgProductos[5, posActual].Value.ToString();
            txtFotoProd.Text = dgProductos[5, posActual].Value.ToString();
            txtCantStock.Text = dgProductos[5, posActual].Value.ToString();
        }
    }
}
