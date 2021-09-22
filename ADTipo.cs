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
    public class ADTipo
    {
        #region MantenimientoTipo
        /// Funcion que ingresa los tipos de lugares
        public static DataSet MantenimientoTipo(ETipo entTipo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.MANTENIMIENTO_USUARIO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_TIPO.tipoAccion.ToString(), entTipo.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_TIPO.descripcion.ToString(), entTipo.Descripcion);
                 
                 
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        #endregion


        
    }
}