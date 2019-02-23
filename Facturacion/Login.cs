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
    public partial class FRMLOGIN : Form
    {
        public FRMLOGIN()
        {
            InitializeComponent();
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "javier" && txtContraseña.Text=="1234")
            {
                //MessageBox.Show("Test");
                FRM_MDI_PRINCIPAL abrir = new FRM_MDI_PRINCIPAL();
                abrir.Show();
                this.Hide();
            }
            else
            {
                txtUsuario.Clear();
                txtContraseña.Clear();
                MessageBox.Show("Error, contraseña o usuario incorrecto.");
                txtUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
