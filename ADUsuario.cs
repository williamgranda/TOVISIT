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
    public class ADUsuario
    {
        #region MantenimientoUsuario
        /// Funcion que ingresa a los datos del usuario
        public static DataSet MantenimientoUsuario(EUsuario entUsuario)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.MANTENIMIENTO_USUARIO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.tipoAccion.ToString(), entUsuario.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.usuario.ToString(), entUsuario.Usuario);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.contrasena.ToString(), entUsuario.Contrasena);
                 
                 
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        #endregion


        #region MantenimientoUsuario
        /// Funcion que ingresa a los datos del usuario
        public static DataSet MantenimientoSuperUsuario(EUsuario entUsuario)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.MANTENIMIENTO_USUARIO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.tipoAccion.ToString(), entUsuario.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.codigo.ToString(), entUsuario.Codigo);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.usuario.ToString(), entUsuario.Usuario);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.contrasena.ToString(), entUsuario.Contrasena);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.correo.ToString(), entUsuario.Correo);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_USUARIO.estado.ToString(), entUsuario.Estado);
               

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        #endregion
    }
}