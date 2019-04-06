using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaDeNegocios
{
    public class ClsClientes
    {
        //Definicion de atributos de la clase
        public int C_IdCliente { get; set; }
        public string C_Nombre { get; set; }
        public double C_Documento { get; set; }
        public string C_Direccion { get; set; }
        public string C_Telefono { get; set; }
        public string C_email { get; set; }
        public string C_UsuarioModifica { get; set; }

        Acceso_datos Acceso = new Acceso_datos();
        //Generacion del respectivo CRUD para los Clientes
        /// <summary>
        /// Actualizacion del cliente
        /// </summary>
        /// <returns>Retorna mensaje de cliente actualizado.</returns>
        public string ActualizaCliente()
        {
            string mensaje = "";
            try
            {
                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdCliente", C_IdCliente));
                lst.Add(new Cls_parametros("@StrNombre", C_Nombre));
                lst.Add(new Cls_parametros("@NumDocumento", C_Documento));
                lst.Add(new Cls_parametros("@StrDireccion", C_Direccion));
                lst.Add(new Cls_parametros("@StrTelefono", C_Telefono));
                lst.Add(new Cls_parametros("@StrEmail", C_email));
                lst.Add(new Cls_parametros("@StrUsuarioModifica", C_UsuarioModifica));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                mensaje = Acceso.Ejecutar_procedimiento("actualizar_Cliente", lst);
            }
            catch (Exception ex)
            {
                mensaje = "Falló la actualización del cliente" + ex;
            }
            return mensaje;
        }
        /// <summary>
        /// Elimina el cliente
        /// </summary>
        /// <returns>Retorna numero de filas afectadas.</returns>
        public string EliminaCliente()
        {
            string mensaje = "";
            try
            {
                string sentencia = $"Exec Eliminar_Cliente {C_IdCliente}";
                mensaje = Acceso.EjecutarComando(sentencia);
            }
            catch (Exception ex)
            {
                mensaje = "Falló la eliminación del cliente" + ex;
            }
            return mensaje;
        }
        /// <summary>
        /// Consulta de toda la tabla de la base de datos
        /// </summary>
        /// <returns>Retorna un datatable de la tabla</returns>
        public DataTable ConsultaCliente()
        {
            string sentencia;
            try
            {
                sentencia = "Select * from TblClientes";
                DataTable dt = new DataTable();
                Acceso_datos Acceso = new Acceso_datos();
                dt = Acceso.EjecutarConsulta(sentencia);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Sobrecarga del metodo ConsultaCliente para fitrar por un parametro
        public DataTable ConsultaCliente( string filtro)
        {
            string sentencia;
            try
            {
                sentencia = $"Select * from TblClientes where strnombre like '%{filtro}%'";
                DataTable dt = new DataTable();
                Acceso_datos Acceso = new Acceso_datos();
                dt = Acceso.EjecutarConsulta(sentencia);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    public class Validar_Usuario
    {
        //Atributos de la clase
        public string C_StrUsuario { get; set; }
        public string C_StrClave { get; set; }
        public Int32 C_IdEmpleado { get; set; }

        public void ValidarUsuario()
        {
            try
            {
                string sentencia = $"Select IdEmpleado, StrUsuario " +
                    $"from TblSeguridad  where StrUsuario ='{C_StrUsuario}' and StrClave='{C_StrClave}'";
                DataTable dt = new DataTable();
                Acceso_datos acceso = new Acceso_datos();
                dt = acceso.EjecutarConsulta(sentencia);
                foreach (DataRow row in dt.Rows)
                {
                    C_IdEmpleado = int.Parse(row[0].ToString());
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class clsAdminSeguridad
    {
        //Atributos de la clase Admin Seguridad
        public int IdSeguridad { get; set; }
        public int IdEmpleado { get; set; }
        public string StrUsuario { get; set; }
        public string StrClave { get; set; }
        public string C_UsuarioModifica { get; set; }

        Acceso_datos Acceso = new Acceso_datos(); //Objeto acceso a datos
        /// <summary>
        /// Comsulta usada para extraer los empleados y sus id
        /// </summary>
        /// <returns>Retorna Datatable</returns>
        public DataTable ConsultaEmpleados()
        {
            string sentencia;
            try
            {
                sentencia = "Select IdEmpleado, StrNombre from TBLEMPLEADO";
                DataTable dt = new DataTable();
                Acceso_datos acceso = new Acceso_datos();
                dt = Acceso.EjecutarConsulta(sentencia);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Consulta por Id
        /// </summary>
        /// <param name="filtro">Filtro id empleado</param>
        /// <returns>datatable de consulta</returns>
        public DataTable ConsultaSeguridad (string filtro)
        {
            string sentencia;
            try
            {
                sentencia = $"Select * from TBLSEGURIDAD where IdEmpleado ={filtro}";
                DataTable dt = new DataTable();
                Acceso_datos acceso = new Acceso_datos();
                dt = Acceso.EjecutarConsulta(sentencia);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }/// <summary>
        /// Permite guardar los cambios realizados sobre la informacion de usuario o clave,
        /// tambien permite guardar un registro nuevo a un usuario nuevo para el empleado que no tiene usuario o clave
        /// </summary>
        /// <returns>mensaje de confirmacion</returns>
        public string Actualizaseguridad()
        {
            string mensaje;
            try
            {
                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdEmpleado", IdEmpleado));
                lst.Add(new Cls_parametros("@StrUsuario", StrUsuario));
                lst.Add(new Cls_parametros("@StrClave", StrClave));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                lst.Add(new Cls_parametros("@StrUsuarioModifico", C_UsuarioModifica));

                mensaje = Acceso.Ejecutar_procedimiento("actualizar_Seguridad",lst);
                mensaje = "Los datos fueron actualizados";
            }
            catch (Exception ex)
            {
                mensaje = "Falló la actualización en seguridad" + ex;
                throw;
            }
            return mensaje;
        }
    }


}