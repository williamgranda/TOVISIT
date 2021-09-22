using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;

namespace TOVISIT.APP.Negocio
{
    public class NActividad
    {
        #region MantenimientoActividad
        /// <summary>
        /// Mantenimiento de actividades
        /// </summary>
        /// <param name="entUsuario"></param>
        /// <returns></returns>
        static public DataSet MantenimientoActividades(EActividad entActividad)
        {
            DataSet valorRetorno = new DataSet();
            valorRetorno = ADActividad.MantenimientoActividad(entActividad);
            return valorRetorno;
        }
        #endregion

        
    }


}