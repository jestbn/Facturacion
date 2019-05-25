using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Cls_parametros
    {
        //Definimos parametros
        public string Nombre { get; set; }
        public object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamaño { get; set; }
        public ParameterDirection Direccionparametro { get; set; }
        //Constructor parametros de entrada
        public Cls_parametros(string Objnombre, Object ObjValor)
        {
            Nombre = Objnombre;
            Valor = ObjValor;
            Direccionparametro = ParameterDirection.Input;
        }
        //Constructor parametros de salida
        public Cls_parametros(string Objnombre, SqlDbType ObjTipoDato, Int32 ObjTamaño)
        {
            Nombre = Objnombre;
            TipoDato = ObjTipoDato;
            Tamaño = ObjTamaño;
            Direccionparametro = ParameterDirection.Output;
        }
    }
    public class Acceso_datos
    {
        SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader LectorDatos = null;
        SqlDataAdapter da;
        DataTable dt;
        public string AbrirBD()
        {
            string resultado = "";
            try
            {
                conexion = new SqlConnection(
                    "Data Source=PCMR\\SQLEXPRESS;" +
                    "Initial Catalog =DbFactura;" +
                    "Integrated Security = True"
                    );
                conexion.Open();
            }
            catch (Exception ex)
            {
                resultado = "falló conexión " + ex;
            }
            return resultado;
        }
        public string CerrarDb()
        {
            string resultado = "";
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                resultado = "falló al cerrar la conexión " + ex;
            }
            return resultado;
        }
        //Metodo usado prar ejecutar un procedimiento almacenado en la base de datos
        public string Ejecutar_procedimiento(string procedimiento, List<Cls_parametros> lst)
        {
            string salida = "";
            try
            {
                int retornado;
                AbrirBD();
                SqlCommand comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccionparametro == ParameterDirection.Input)
                        {
                            comando.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        }
                        if (lst[i].Direccionparametro == ParameterDirection.Output)
                        {
                            comando.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i]. Tamaño).Direction = ParameterDirection.Output;
                        }
                    }
                }
                retornado = comando.ExecuteNonQuery();
                CerrarDb();
                if (retornado > 0)
                {
                    salida = "Los datos fueron actualizados";
                }
                else
                {
                    salida = "Los datos NO fueron actualizados";
                }
            }
            catch (Exception ex)
            {
                salida = "Falló la operación" + ex;
            }
            return salida;
        }
        //Metodo ejecutar comando útil para update, insert, delete , que retorna un mensaje indicando si actualizo o no.
        public string EjecutarComando(string sentencia)
        {
            string salida = "";
            try
            {
                int retornado;
                AbrirBD();
                cmd = new SqlCommand(sentencia, conexion);
                retornado = cmd.ExecuteNonQuery();
                CerrarDb();
                if (retornado > 0)
                {
                    salida = "Los datos fueron actualizados";
                }
                else
                {
                    salida = "Los datos NO fueron actualizados";
                }
            }
            catch (Exception ex)
            {
                salida = "Fallo operación: " + ex;
            }
            return salida;
        }
        //Metodo ejecutaconsulta permite ejecutar sentencias de consulta que retornan un conjunto de datos, retornados por datatable
        public DataTable EjecutarConsulta(string cmd)
        {
            try
            {
                AbrirBD();
                da = new SqlDataAdapter(cmd, conexion);
                dt = new DataTable();
                da.Fill(dt);
                CerrarDb();
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
