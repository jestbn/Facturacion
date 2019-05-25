using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaDeNegocios;

namespace Capa_presentacion_Web
{
    public partial class FrmAdminClientes : System.Web.UI.Page
    {
        ClsClientes Capa_clientes = new ClsClientes();
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
                    Capa_clientes.C_IdCliente = 0;
                    Capa_clientes.C_Nombre = txtNombre.Text;
                    Capa_clientes.C_Documento = double.Parse(TxtDocumento.Text);
                    Capa_clientes.C_Direccion = txtDireccion.Text;
                    Capa_clientes.C_Telefono = txtTelefono.Text;
                    Capa_clientes.C_email = txtEmail.Text;
                    Capa_clientes.C_UsuarioModifica = "Admin(Esteban)";
                    mensaje = Capa_clientes.ActualizaCliente();
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
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
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
            Response.Redirect("WF_listaClientes1.aspx");
        }
    }
}