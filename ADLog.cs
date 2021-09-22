using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos.Enumeraciones;
using TOVISIT.APP.AccesoDatos.Utilitarios;

namespace TOVISIT.APP.AccesoDatos
{
    public class ADLog
    {
        #region InsertarLog
        /// Funcion que inserta log de transacciones y de error en base de datos        
        public static void InsertarLog(ELog entLog)
        {
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.INSERTAR_LOG, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.INSERTAR_LOG.tipoAccion.ToString(), entLog.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.INSERTAR_LOG.descripcion.ToString(), entLog.Descripcion);
                cmd.Parameters.AddWithValue(ADParametros.INSERTAR_LOG.usuario.ToString(), entLog.Usuario);
                cmd.Parameters.AddWithValue(ADParametros.INSERTAR_LOG.host.ToString(), entLog.Host);
                SqlDataReader dr = cmd.ExecuteReader();
                conn.Close();
            }
        }
        #endregion
    }
}