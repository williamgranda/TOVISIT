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
    public class ADLugar
    {
        #region MantenimientoLugar
        /// Funcion que ingresa  lugares
        public static DataSet MantenimientoLugar(ELugar entLugar)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = ADConexionBase.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(Componentes.Procedimientos.MANTENIMIENTO_USUARIO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.tipoAccion.ToString(), entLugar.TipoAccion);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.id_tipo_lugar.ToString(), entLugar.Id_tipo_lugar);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.usuario.ToString(), entLugar.Usuario);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.nombre_lugar.ToString(), entLugar.Nombre_lugar);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.descripcion_lugar.ToString(), entLugar.Descripcion_lugar);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.imagen_lugar.ToString(), entLugar.Imagen_lugar);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.coordenadas.ToString(), entLugar.Coordenadas);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.lat.ToString(), entLugar.Lat);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.lng.ToString(), entLugar.Lng);
                cmd.Parameters.AddWithValue(ADParametros.MANTENIMIENTO_LUGAR.estado.ToString(), entLugar.Estado);              
                                
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        #endregion


        
    }
}