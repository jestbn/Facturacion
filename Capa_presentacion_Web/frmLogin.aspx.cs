using CapaLogicaDeNegocios;
using System;

namespace Capa_presentacion_Web
{
    public partial class frmLogin : System.Web.UI.Page
    {
        Validar_Usuario Clase_validaUsuario = new Validar_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            Clase_validaUsuario.C_StrClave = txtpassword.Text;
            Clase_validaUsuario.C_StrUsuario = txtusuario.Text;
            Clase_validaUsuario.ValidarUsuario();

            if (Clase_validaUsuario.C_IdEmpleado != 0)
            {   //  mostramos mensaje               
                Response.Write("<script>alert('usuario válido')</script>");  //  mensaje                              
                Response.Redirect("WF_listaClientes1.aspx"); //luego quitamos el comentario para redireccionar a la página  de clientes

            }
            else
            {   //  mostramos mensaje                   
                Response.Write("<script>alert('clave usuario incorrectos')</script>");
            }
        }
    }
}