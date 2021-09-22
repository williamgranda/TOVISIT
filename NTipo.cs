using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;

namespace TOVISIT.APP.Negocio
{
    public class NTipo
    {
        #region MantenimientoTipos
        /// <summary>
        /// Mantenimiento de los tipos de los lugares
        /// </summary>
        /// <param name="entUsuario"></param>
        /// <returns></returns>
        static public DataSet MantenimientoTipo(ETipo entTipo)
        {
            DataSet valorRetorno = new DataSet();
            valorRetorno = ADTipo.MantenimientoTipo(entTipo);
            return valorRetorno;
        }
        #endregion

        
    }
}