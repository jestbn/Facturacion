using System;
using System.Data;
using System.Windows.Forms;

namespace Facturacion
{
	public partial class frmEmpleado : Form
	{
		public frmEmpleado()
		{
			InitializeComponent();
		}

		private void frmEmpleado_Load(object sender, EventArgs e)
		{
			Llenar_Grid();
		}

		private void Llenar_Grid()
		{
			DataTable dt = new DataTable();
			Acceso_datos acceso = new Acceso_datos();
			dt = acceso.CargarTabla("TBLEMPLEADO", "");
			dgEmpleados.DataSource = dt;

			dt = acceso.CargarTabla("TBLROLES", "");
			cbRol.DataSource = dt;
			cbRol.DisplayMember = "strDescripcion";
			cbRol.ValueMember = "IdRolEmpleado";
		}

		private void dgEmpleados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			int posActual = 0;
			posActual = dgEmpleados.CurrentRow.Index;

			txtCodigoEmpleado.Text = dgEmpleados[0, posActual].Value.ToString();
			txtNombre.Text = dgEmpleados[1, posActual].Value.ToString();
			txtDocumento.Text = dgEmpleados[2, posActual].Value.ToString();
			txtDireccion.Text = dgEmpleados[3, posActual].Value.ToString();
			txtTelefono.Text = dgEmpleados[4, posActual].Value.ToString();
			txtEmail.Text = dgEmpleados[5, posActual].Value.ToString();
			cbRol.SelectedItem = Convert.ToInt16(dgEmpleados[6, posActual].Value.ToString());
			dtmIngreso.Value = Convert.ToDateTime(dgEmpleados[7, posActual].Value.ToString());
			if (dgEmpleados[8, posActual].Value.ToString() != "")
			{
				dtmRetiro.Value = Convert.ToDateTime(dgEmpleados[8, posActual].Value.ToString());
			}
			else
			{
				dtmRetiro.Value = Convert.ToDateTime("01/01/1900");
			}
			txtDatosAdicionales.Text = dgEmpleados[9, posActual].Value.ToString();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Guardar();
		}

		public bool Guardar()
		{
			bool actualizado = false;

			if (Validar())
			{
				try
				{
					Acceso_datos acceso = new Acceso_datos();
					string sentencia = $"Exec actualizar_Empleado '{txtNombre.Text}'," +
						$"'{txtDocumento.Text}'," +
						$"'{txtDireccion.Text}'," +
						$"'{txtTelefono.Text}'," +
						$"'{txtEmail.Text}'," +
						$"{Convert.ToInt32(cbRol.SelectedValue)}," +
						$" '{dtmIngreso.Value.Date.ToString("dd/MM/yy")}', " +
                        $" '{dtmRetiro.Value.Date.ToString("dd/MM/yy")}'," +
						$"'{txtDatosAdicionales.Text}'," +
                        $" '{DateTime.Now.Date.ToString("dd/MM/yy")}', " +
						$"'ADMIN' ";/*
                         @strNombre varchar(50), 
			             @NumDocumento  bigint,
			             @StrDireccion varchar(50)   
			            ,@StrTelefono  varchar(20)   
			            ,@StrEmail  varchar(50)   
			            ,@IdRolEmpleado int  
			            ,@DtmIngreso  datetime  
			            ,@DtmRetiro  datetime  
			            ,@strDatosAdicionales  nvarchar(250)  
			            ,@DtmFechaModifica  datetime  
			            ,@StrUsuarioModifico  varchar(20)  

                     */
                    MessageBox.Show(acceso.EjecutarComando(sentencia));
					Llenar_Grid();
					actualizado = true;
				}
				catch (Exception e)
				{

					MessageBox.Show($"Falló la inserción '{e}'");
					actualizado = false;
				}
			}
            return actualizado;
        }

		private Boolean Validar()
		{
			Boolean errorCampos = true;
			if (txtNombre.Text == string.Empty)
			{
				MensajeError.SetError(txtNombre, "debe ingresar el nombre del empleado");
				txtNombre.Focus();
				errorCampos = false;
			}
			else
			{
				MensajeError.SetError(txtNombre, "");
			}
			if (txtDocumento.Text == string.Empty)
			{
				MensajeError.SetError(txtNombre, "debe ingresar el documento del empleado");
				txtDocumento.Focus();
				errorCampos = false;
			}
			else
			{
				MensajeError.SetError(txtDocumento, "");
			}
			if (!esNumerico(txtDocumento.Text))
			{
				MensajeError.SetError(txtNombre, "debe documento debe ser numerico");
				txtDocumento.Focus();
				errorCampos = false;
			}
			else
			{
				MensajeError.SetError(txtDocumento, "");
			}
			return errorCampos;
		}

		private bool esNumerico(string num)
		{
			try
			{
				double x = Convert.ToDouble(num);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            Acceso_datos acceso = new Acceso_datos();
            string sentencia = $"Exec Eliminar_Empleado '{Convert.ToInt32(txtCodigoEmpleado.Text)}'";
            MessageBox.Show(acceso.EjecutarComando(sentencia));
            Llenar_Grid();
        }

        private void btnReEstablecer_Click(object sender, EventArgs e)
        {
            txtCodigoEmpleado.Clear();
            txtDatosAdicionales.Clear();
            txtDireccion.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            cbRol.SelectedIndex = 0;
            dtmIngreso.Value = DateTime.Now;
            dtmRetiro.Value = Convert.ToDateTime("01/01/1900");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta;
            rta = MessageBox.Show("Desea salir de la edición ?", "Mensaje de advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}