using System;
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
            string Respuesta = ""; //Variable para controlar si el ususario se encontro en la base de datos
            if (txtUsuario.Text != "" && txtContraseña.Text != string.Empty) //verificacion del usuario y la contraseña no esten null
            {
                Acceso_datos Acceso = new Acceso_datos(); //objeto de la clase Acceso_datos
                Respuesta = Acceso.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
                if (Respuesta != "")
                {
                    MessageBox.Show($"Bienvenido :{Respuesta}");
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
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
