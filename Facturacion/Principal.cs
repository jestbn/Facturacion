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
        FRMLOGIN Login;
        private int childFormNumber = 0;

        public FRM_MDI_PRINCIPAL()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
