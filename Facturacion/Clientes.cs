using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaDeNegocios;

namespace Facturacion
{
    public partial class frmClientes : Form
    {
        ClsClientes CapaClientes = new ClsClientes();
        public frmClientes()
        {
            InitializeComponent();
        }
        private Boolean Validados()
        {
            Boolean errorcampos = true;
            foreach (Control control in this.CLIENTE.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text=="")
                    {
                        MensajeError.SetError(control, "El Campo es obligatorio");
                        control.Focus();
                        errorcampos = false;
                    }
                    else
                    {
                        MensajeError.SetError(control,"");
                    }
                }
            }

            if (!IsNumeric(txtDocumento.Text))
            {
                MensajeError.SetError(txtDocumento,"El documento debe ser numerico");
                txtDocumento.Focus();
                return false;
            }
            MensajeError.SetError(txtDocumento, "");
            return errorcampos;
        }

        private bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
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
                    string sentencia = $"Exec actualizar_Cliente '{txtNombre.Text}'," +
                        $"{txtDocumento.Text}," +
                        $"'{txtDireccion.Text}'," +
                        $"'{txtTelefono.Text}'," +
                        $"'{txtEmail.Text}'," +
                        $"'{dtmIngreso.Value.Date.ToString("yyyy-MM-dd")}', " +
                        $"'ADMIN' ";
                    MessageBox.Show(acceso.EjecutarComando(sentencia));
                    Llenar_Grid();
                    actualizado = true;
                }
                catch (Exception e)
                {

                    MessageBox.Show($"Falló la inserción '{e}'");
                    actualizado = false;
                }
            }
            return actualizado;
        }
        /*
        private Boolean Validar()
        {
            Boolean errorCampos = true;
            if (txtNombre.Text == string.Empty)
            {
                MensajeError.SetError(txtNombre, "debe ingresar el nombre del Cliente");
                txtNombre.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtNombre, "");
            }
            if (txtDocumento.Text == string.Empty)
            {
                MensajeError.SetError(txtDocumento, "debe ingresar el documento del Cliente");
                txtDocumento.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtDocumento, "");
            }
            frmEmpleado empleado = new frmEmpleado();
            if (!empleado.esNumerico(txtDocumento.Text))
            {
                MensajeError.SetError(txtNombre, "El documento debe ser numerico");
                txtDocumento.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtDocumento, "");
            }
            return errorCampos;
        } */

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar();
            string mensaje = "";
            DialogResult rta;
            rta = MessageBox.Show("Desea borrar el registro actual?", "Mensaje de advertencia", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (rta == DialogResult.OK)
            {
                CapaClientes.C_IdCliente = Int16.Parse(txtCodigoCliente.Text);
                mensaje = CapaClientes.EliminaCliente();
                MessageBox.Show(mensaje);
                dgClientes.DataSource = CapaClientes.ConsultaCliente();
                Limpiar();
            }
        }

        /*private void Eliminar()
        {
            Acceso_datos acceso = new Acceso_datos();
            string sentencia = $"Exec Eliminar_Cliente '{Convert.ToInt32(txtCodigoCliente.Text)}'";
            MessageBox.Show(acceso.EjecutarComando(sentencia));
            Limpiar();
        }*/

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigoCliente.Clear();
            txtDireccion.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            dtmIngreso.Value = DateTime.Now;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta;
            rta = MessageBox.Show("Desea salir de la edición ?", "Mensaje de advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Llenar_Grid();
            dgClientes.DataSource = CapaClientes.ConsultaCliente();
        }
        /*
        private void Llenar_Grid()
        {
            DataTable dt = new DataTable();
            Acceso_datos acceso = new Acceso_datos();
            dt = acceso.CargarTabla("TBLCLIENTES", "");
            dgClientes.DataSource = dt;
        }*/

        private void dgClientes_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int posActual = 0;
            posActual = dgClientes.CurrentRow.Index;

            txtCodigoCliente.Text = dgClientes[0, posActual].Value.ToString();
            txtNombre.Text = dgClientes[1, posActual].Value.ToString();
            txtDocumento.Text = dgClientes[2, posActual].Value.ToString();
            txtDireccion.Text = dgClientes[3, posActual].Value.ToString();
            txtTelefono.Text = dgClientes[4, posActual].Value.ToString();
            txtEmail.Text = dgClientes[5, posActual].Value.ToString();
            //dtmIngreso.Value = Convert.ToDateTime(dgClientes[7, posActual].Value.ToString());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (Validados())
            {
                CapaClientes.C_IdCliente = Int16.Parse(txtCodigoCliente.Text);
                CapaClientes.C_Nombre = txtNombre.Text;
                CapaClientes.C_Documento = double.Parse(txtDocumento.Text);
                CapaClientes.C_Direccion = txtDireccion.Text;
                CapaClientes.C_Telefono = txtTelefono.Text;
                CapaClientes.C_email = txtEmail.Text;
                CapaClientes.C_UsuarioModifica = "Admin(EstebanGil)";
                mensaje = CapaClientes.ActualizaCliente();
                MessageBox.Show(mensaje);
                dgClientes.DataSource = CapaClientes.ConsultaCliente();
            }
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                dgClientes.DataSource = CapaClientes.ConsultaCliente(txtBuscar.Text);
            }
            else
            {
                dgClientes.DataSource = CapaClientes.ConsultaCliente();
            }
        }
    }
}