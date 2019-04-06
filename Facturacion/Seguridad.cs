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
    public partial class frmSeguridad : Form
    {
        clsAdminSeguridad Capanegocios_admin = new clsAdminSeguridad();
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
            //Acceso_datos ad = new Acceso_datos();
            //dt = ad.CargarTabla("TBLEMPLEADO", "");
            dt = Capanegocios_admin.ConsultaEmpleados();

            cbCodigoEmpleado.DataSource = dt;
            cbCodigoEmpleado.DisplayMember = "strNombre";
            cbCodigoEmpleado.ValueMember = "IdEmpleado";
            //ad.CerrarBd();
        }
        private Boolean validar()
        {
            Boolean errorCampos = true;
            if (txtUsuario.Text == string.Empty)
            {
                MensajeError.SetError(txtUsuario, "debe ingresar  un valor de Usuario");
                txtUsuario.Focus(); errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtUsuario, "");
            }

            if (txtClave.Text == "")
            {
                MensajeError.SetError(txtClave, "Debe ingresar  un valor de cédula");
                txtClave.Focus();
                errorCampos = false;
            }
            else
            {
                MensajeError.SetError(txtClave, "");
            }

            return errorCampos;
        }

        //metodo para validar si los valores son numericos         
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public void Guardar()
        {
            string mensaje = "";
            if (validar())
            {
                try
                {
                    //  actualizamos valores de seguridad
                    Capanegocios_admin.IdEmpleado = Convert.ToInt32(cbCodigoEmpleado.SelectedValue);
                    Capanegocios_admin.StrUsuario = txtUsuario.Text;
                    Capanegocios_admin.StrClave = txtClave.Text;
                    Capanegocios_admin.C_UsuarioModifica = "javier";
                    mensaje = Capanegocios_admin.Actualizaseguridad();
                    MessageBox.Show(mensaje);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("falló Actualización: " + ex);
                }
            }
            /*
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
            return actualizado;*/
        }
        
        /*
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
        }*/

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
