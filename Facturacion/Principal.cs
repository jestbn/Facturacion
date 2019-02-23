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
    public partial class FRM_MDI_PRINCIPAL : Form
    {
        frmClientes Clientes;
        frmEmpleado Empleado;
        frmProductos Productos;
        frmSeguridad Seguridad;
        private int childFormNumber = 0;

        public FRM_MDI_PRINCIPAL()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clientes is null)
            {
                Clientes = new frmClientes
                {
                    MdiParent = this
                };
                Clientes.FormClosed += new FormClosedEventHandler(Clientes_FormClosed);
                Clientes.Show();
            }
            else
            {
                Clientes.Activate();
            }
        }

        private void Clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clientes = null;
        }
    }
}
