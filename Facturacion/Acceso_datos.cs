using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Facturacion
{
    internal class Acceso_datos
    {
        SqlConnection conexion; // se define la variable para la conexión de tipo SqlConnection
        SqlCommand cmd; // se defie la variable para realizar comandos en la BD
        SqlDataReader LectorDatos = null;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds;
        public void AbrirBd() // método para abrir la base de datos
        {
            try // permite captura de un error en caso que se presente
            {
                // creamos un objeto de tipo conexión a la base de datos y se pasa como parámetro la cadena de conexión
                conexion = new SqlConnection(
                    "Data Source=PCMR\\SQLEXPRESS;" +
                    "Initial Catalog =DbFactura;" +
                    "Integrated Security = True"
                    );
                conexion.Open(); // invocamos método para abrir la base de datos
            }
            catch (Exception ex)// si hay error presenta el siguiente mensaje
            {
                MessageBox.Show("falló conexión " + ex);
            }
        }

        internal DataTable CargarTabla(string tabla, string condicion)
        {
            try
            {
                AbrirBd();
                string sql = $"Select * from {tabla} {condicion}";
                da = new SqlDataAdapter(sql, conexion);
                ds = new DataSet();
                da.Fill(ds, tabla);
                DataTable dt = new DataTable();
                dt = ds.Tables[tabla];
                CerrarBd();
                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error en la consulta {ex.ToString()}");
                return null;
            }
        }

        public void CerrarBd() // método para abrir la base de datos
        {
            try // permite captura de un error en caso que se presente
            {
                conexion.Close(); // invocamos método para abrir la base de datos
            }
            catch (Exception ex)// si hay error presenta el siguiente mensaje
            {
                MessageBox.Show("falló cerrar conexión " + ex);
            }
        }

        internal string ValidarUsuario(string Usuario, string Clave)
        {
            try
            {
                string strEmpleado = "";
                string sentencia = $"select e.strNombre, e.IdRolEmpleado from TBLSEGURIDAD S JOIN TBLEMPLEADO E ON S.IdEmpleado = E.IdEmpleado where StrUsuario ='{Usuario}' and StrClave = '{Clave}'";
                AbrirBd();
                cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = sentencia;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 10;
                LectorDatos = cmd.ExecuteReader();
                while (LectorDatos.Read())
                {
                    strEmpleado = Convert.ToString(LectorDatos.GetValue(0));
                }
                if (LectorDatos is null)
                {
                    LectorDatos.Close();
                }
                return strEmpleado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string EjecutarComando(string sentencia)
        {
            string salida ;
            try
            {
                int retornado;
                AbrirBd();
                cmd = new SqlCommand(sentencia, conexion);
                retornado = cmd.ExecuteNonQuery();
                CerrarBd();
                if (retornado > 0)
                {
                    salida = "Los datos fueron actualizados";
                }
                else
                {
                    salida = "Los datos no fueron actualizados";
                }
            }
            catch (Exception e)
            {

                salida = $"Falló la inserción '{e}'";
            }
            return salida;
        }

        internal DataTable EjecutarComandoDatos(string cmd)
        {
            try
            {
                AbrirBd();
                da = new SqlDataAdapter(cmd, conexion);
                dt = new DataTable();
                da.Fill(dt);
                CerrarBd();
                return dt;
            }
            catch (Exception e)
            {

                MessageBox.Show("Falló la operación "+ e);
                return null;
            }
        }
    }
}