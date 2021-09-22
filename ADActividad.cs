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
    public class ADActividad
    {
        #region MantenimientoActividad
        /// Funcion que ingresa  Actividades
        public static DataSet MantenimientoActividad(EActividad entActividad)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.MANTENIMIENTO_USUARIO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.tipoAccion.ToString(), entActividad.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.id_lugar.ToString(), entActividad.Id_lugar);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.usuario.ToString(), entActividad.Usuario);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.nombre_actividad.ToString(), entActividad.Nombre_actividad);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.descripcion_actividad.ToString(), entActividad.Descripcion_actividad);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.fecha_inicio.ToString(), entActividad.Fecha_incio);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.fecha_fin.ToString(), entActividad.Fecha_fin);
                 cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_ACTIVIDAD.estado.ToString(), entActividad.Estado);              
                                
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        #endregion


        
    }
}