using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaDeNegocios;

namespace Capa_presentacion_Web
{
    public partial class FrmAdminEmpleado : System.Web.UI.Page
    {
        clsEmpleado capa_empleado = new clsEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void idActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";

                if (Validados())
                {
                    capa_empleado.C_IdEmpleado = 0;
                    capa_empleado.C_Nombre = txtNombre.Text;
                    capa_empleado.C_Documento = double.Parse(TxtDocumento.Text);
                    //capa_empleado.C_Direccion = ;
                    capa_empleado.C_Telefono = txtTelefono.Text;
                    capa_empleado.C_email = txtEmail.Text;
                    capa_empleado.C_UsuarioModifica = "Admin(Esteban)";
                    capa_empleado.C_IdRolEmpleado = txtRol.Text;
                    capa_empleado.C_DatosAdicionales = txtDatosAdicionales.Text;

                    mensaje = capa_empleado.ActualizaEmpleado();
                    Response.Write("<script>alert('LOS DATOS FUERON ACTUALIZADOS')</script>");
                    BORRA_CAMPOS();
                }

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('error al actualizar {ex}')</script>");
            }

        }
        private void BORRA_CAMPOS()
        {
            txtNombre.Text = "";
            TxtDocumento.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDatosAdicionales.Text = "";
            txtRol.Text = "";
        }
        private Boolean Validados()
        {
            Boolean CamposValidos = true;

            if (txtNombre.Text == "")
            {
                Response.Write("<script>alert('SE DEBE INGRESAR UN NOMBRE')</script>");
                CamposValidos = false;
            }
            else if (TxtDocumento.Text == "")
            {
                Response.Write("<script>alert('SE DEBE INGRESAR DOCUMENTO')</script>");
                CamposValidos = false;
            }
            else if (txtEmail.Text == "")
            {
                Response.Write("<script>alert('SE DEBE INGRESAR CORREO')</script>");
                CamposValidos = false;
            }
            return CamposValidos;
        }

        protected void IdCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WF_listaEmpleados.aspx");
        }
    }
}