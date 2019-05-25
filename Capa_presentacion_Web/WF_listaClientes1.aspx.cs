using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaDeNegocios;

namespace Capa_presentacion_Web
{
    public partial class WF_listaClientes1 : System.Web.UI.Page
    {
        ClsClientes Capa_clientes = new ClsClientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgClientes.DataSource = Capa_clientes.ConsultaCliente();
            dgClientes.DataBind();
        }

        protected void dgClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDCliente = ""; string mensaje = "";

            GridViewRow row = dgClientes.SelectedRow; // sentencia que indica la fila seleccionada
            // realizamos el borrado del registro seleccionado 
            IDCliente = row.Cells[0].Text; // DE LA FILA SELECCIONADA , LEEMOS EL PRIMER CAMPO QUE ES EL ID
            Capa_clientes.C_IdCliente = Int16.Parse(IDCliente);
            mensaje = Capa_clientes.EliminaCliente();
            MessageLabel.Text= mensaje;             // cargamos de nuevo los datos en el grid             
            dgClientes.DataSource = Capa_clientes.ConsultaCliente();
            dgClientes.DataBind();
            Response.Write("<script>alert('EL REGISTRO FUE ELIMINADO')</script>");
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text !="")
            {
                dgClientes.DataSource = Capa_clientes.ConsultaCliente(txtbuscar.Text);
                dgClientes.DataBind();
            }
            else
            {
                dgClientes.DataSource = Capa_clientes.ConsultaCliente();
                dgClientes.DataBind();
            }
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAdminClientes.aspx");
        }
    }
}