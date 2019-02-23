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
        frmAbout AcercaDe;
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

        private void AdminProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Productos is null)
            {
                Productos = new frmProductos
                {
                    MdiParent = this
                };
                Productos.FormClosed += new FormClosedEventHandler(Productos_FormClosed);
                Productos.Show();
            }
            else
            {
                Productos.Activate();
            }
        }

        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Productos = null;
        }

        private void adminEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Empleado is null)
            {
                Empleado = new frmEmpleado
                {
                    MdiParent = this
                };
                Empleado.FormClosed += new FormClosedEventHandler(Empleado_FormClosed);
                Empleado.Show();
            }
            else
            {
                Empleado.Activate();
            }
        }

        private void Empleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Empleado = null;
        }

        private void SeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Seguridad is null)
            {
                Seguridad = new frmSeguridad
                {
                    MdiParent = this
                };
                Seguridad.FormClosed += new FormClosedEventHandler(Seguridad_FormClosed);
                Seguridad.Show();
            }
            else
            {
                Seguridad.Activate();
            }
        }

        private void Seguridad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Seguridad = null;
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AcercaDe is null)
            {
                AcercaDe = new frmAbout
                {
                    MdiParent = this
                };
                AcercaDe.FormClosed += new FormClosedEventHandler(AcercaDe_FormClosed);
                AcercaDe.Show();
            }
            else
            {
                AcercaDe.Activate();
            }
        }

        private void AcercaDe_FormClosed(object sender, FormClosedEventArgs e)
        {
            AcercaDe = null;
        }
    }
}
