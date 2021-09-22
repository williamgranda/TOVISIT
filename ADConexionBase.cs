using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using TOVISIT.APP.AccesoDatos.Enumeraciones;
using TOVISIT.APP.AccesoDatos.Utilitarios;

namespace TOVISIT.APP.AccesoDatos
{
    public class ADConexionBase
    {
        #region ObtenerCadenaConexion
        /// Retorna cadena de conexion de archivo de configuracion        
        public static string ObtenerCadenaConexion()
        {
            string CadenaConexion = string.Empty;
            CadenaConexion = ConfigurationManager.ConnectionStrings[Utilitarios.Componentes.Cadenas.SQL].ConnectionString;
            return CadenaConexion;
        }
        #endregion

        #region ObtenerConexion
        /// Devueve Conexion a base de datos        
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection(ObtenerCadenaConexion());
            Conn.Open();
            return Conn;
        }
        #endregion
    }
}