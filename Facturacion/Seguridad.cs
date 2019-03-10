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
    public partial class frmSeguridad : Form
    {
        public frmSeguridad()
        {
            InitializeComponent();
        }

        private void frmSeguridad_Load(object sender, EventArgs e)
        {
            llenar_combo_empleado();
        }

        private void llenar_combo_empleado()
        {
            DataTable dt = new DataTable();
            Acceso_datos ad = new Acceso_datos();
            dt = ad.CargarTabla("TBLEMPLEADO", "");

            cbCodigoEmpleado.DataSource = dt;
            cbCodigoEmpleado.DisplayMember = "strNombre";
            cbCodigoEmpleado.ValueMember = "IdEmpleado";
            ad.CerrarBd();
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
                    string sentencia = $"Exec actualizar_Seguridad '{Convert.ToInt32(cbCodigoEmpleado.SelectedValue)}'," +
                        $"'{txtUsuario.Text}'," +
                        $"'{txtClave.Text}'," +
                        $"{DateTime.Now.Date.ToString("dd/MM/yy")}," +
                        $"'ADMIN',";
                    MessageBox.Show(acceso.EjecutarComando(sentencia));
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

        private Boolean Validar()
        {
            Boolean errorCampos = true;
            if (txtUsuario.Text == string.Empty)
            {
                MensajeError.SetError(txtUsuario, "debe ingresar el Usuario del empleado");
                txtUsuario.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtUsuario, "");
            }
            if (txtClave.Text == string.Empty)
            {
                MensajeError.SetError(txtClave, "debe ingresar la clave del empleado");
                txtClave.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtClave, "");
            }
            return errorCampos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            Acceso_datos acceso = new Acceso_datos();
            string sentencia = $"Exec Eliminar_Seguridad '{Convert.ToInt32(cbCodigoEmpleado.SelectedValue)}'";
            MessageBox.Show(acceso.EjecutarComando(sentencia));
            txtClave.Clear();
            txtUsuario.Clear();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            DataTable dt = new DataTable();
            string sentencia = $"select strUsuario, strClave from TBLSEGURIDAD where IdEmpleado ='{cbCodigoEmpleado.SelectedValue.ToString()}'";
            Acceso_datos ad = new Acceso_datos();
            dt = ad.EjecutarComandoDatos(sentencia);
            if (dt.Rows.Count > 0)
            {
                txtUsuario.Text = dt.Rows[0]["StrUsuario"].ToString();
                txtClave.Text = dt.Rows[0]["StrClave"].ToString();
            }
            else
            {
                MessageBox.Show("El usuario no dispone de datos de ingreso");
                txtUsuario.Clear();
                txtClave.Clear();
            }
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
    }
}
