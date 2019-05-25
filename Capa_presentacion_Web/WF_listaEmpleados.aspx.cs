using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaDeNegocios;


namespace Capa_presentacion_Web
{
    public partial class WF_listaEmpleados : System.Web.UI.Page
    {
        clsEmpleado Capa_empleado = new clsEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgEmpleados.DataSource = Capa_empleado.ConsultaEmpleado();
            dgEmpleados.DataBind();
        }

        protected void dgEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDEmpleado = ""; string mensaje = "";

            GridViewRow row = dgEmpleados.SelectedRow;
            IDEmpleado = row.Cells[0].Text;
            Capa_empleado.C_IdEmpleado = Int16.Parse(IDEmpleado);
            mensaje = Capa_empleado.EliminaEmpleado();
            MessageLabel.Text = mensaje;
            dgEmpleados.DataSource = Capa_empleado.ConsultaEmpleado();
            dgEmpleados.DataBind();
            Response.Write("<script>alert('EL REGISTRO FUE ELIMINADO')</script>");

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                dgEmpleados.DataSource = Capa_empleado.ConsultaEmpleado(txtbuscar.Text);
                dgEmpleados.DataBind();
            }
            else
            {
                dgEmpleados.DataSource = Capa_empleado.ConsultaEmpleado();
                dgEmpleados.DataBind();
            }

        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAdminEmpleado.aspx");
        }
    }
}