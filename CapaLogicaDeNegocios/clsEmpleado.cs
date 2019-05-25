using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;


namespace CapaLogicaDeNegocios
{
    public class clsEmpleado
    {
        //Definicion de atributos de la clase
        public int C_IdEmpleado { get; set; }
        public string C_Nombre { get; set; }
        public double C_Documento { get; set; }
        public string C_Direccion { get; set; }
        public string C_Telefono { get; set; }
        public string C_email { get; set; }
        public string C_UsuarioModifica { get; set; }
        public string C_IdRolEmpleado { get; set; }
        public string C_DatosAdicionales { get; set; }

        Acceso_datos Acceso = new Acceso_datos();
        //Generacion del respectivo CRUD para los Clientes
        /// <summary>
        /// Actualizacion del cliente
        /// </summary>
        /// <returns>Retorna mensaje de cliente actualizado.</returns>
        public string ActualizaEmpleado()
        {
            string mensaje = "";
            try
            {
                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@StrNombre", C_Nombre));
                //lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
                lst.Add(new Cls_parametros("@NumDocumento", C_Documento));
                lst.Add(new Cls_parametros("@StrDireccion", C_Direccion));
                lst.Add(new Cls_parametros("@StrTelefono", C_Telefono));
                lst.Add(new Cls_parametros("@StrEmail", C_email));
                lst.Add(new Cls_parametros("@IdRolEmpleado", C_IdRolEmpleado));
                lst.Add(new Cls_parametros("@DtmIngreso", DateTime.Now));
                lst.Add(new Cls_parametros("@DtmRetiro", DateTime.Now));
                lst.Add(new Cls_parametros("@strDatosAdicionales", C_DatosAdicionales));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                lst.Add(new Cls_parametros("@StrUsuarioModifico", C_UsuarioModifica));
                mensaje = Acceso.Ejecutar_procedimiento("actualizar_Empleado", lst);
            }
            catch (Exception ex)
            {
                mensaje = "Falló la actualización del cliente" + ex;
            }
            return mensaje;
        }
        /// <summary>
        /// Elimina el empleado
        /// </summary>
        /// <returns>Retorna numero de filas afectadas.</returns>
        public string EliminaEmpleado()
        {
            string mensaje = "";
            try
            {
                string sentencia = $"Exec Eliminar_Empleado {C_IdEmpleado}";
                mensaje = Acceso.EjecutarComando(sentencia);
            }
            catch (Exception ex)
            {
                mensaje = "Falló la eliminación del empleado" + ex;
            }
            return mensaje;
        }
        /// <summary>
        /// Consulta de toda la tabla de la base de datos
        /// </summary>
        /// <returns>Retorna un datatable de la tabla</returns>
        public DataTable ConsultaEmpleado()
        {
            string sentencia;
            try
            {
                sentencia = "Select * from TBLEMPLEADO";
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
        //Sobrecarga del metodo ConsultaEmpleado para fitrar por un parametro
        public DataTable ConsultaEmpleado(string filtro)
        {
            string sentencia;
            try
            {
                sentencia = $"Select * from TBLEMPLEADO where strnombre like '%{filtro}%'";
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
}
