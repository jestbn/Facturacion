using System;
using System.Windows.Forms;
using CapaLogicaDeNegocios;

namespace Facturacion
{
    public partial class FRMLOGIN : Form
    {
        Validar_Usuario Clase_validarusuario = new Validar_Usuario();
        public FRMLOGIN()
        {
            InitializeComponent();
        }
        private void BtnValidar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtContraseña.Text != string.Empty)
            {
                Clase_validarusuario.C_StrClave = txtContraseña.Text;
                Clase_validarusuario.C_StrUsuario = txtUsuario.Text;
                Clase_validarusuario.ValidarUsuario();
                if (Clase_validarusuario.C_IdEmpleado != 0)
                {
                    FRM_MDI_PRINCIPAL clientes = new FRM_MDI_PRINCIPAL();
                    clientes.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y clave no encontrados");
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un usuario y una clave");
            }
        }
        /* COMENTADO POR NUEVAS FUNCIONALIDADES PRESENTADAS EN EL TERCER TRABAJO.
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
        */

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
