using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;

namespace TOVISIT.APP.Negocio
{
    public class NUsuario
    {
        #region MantenimientoUsuario
        /// <summary>
        /// Mantenimiento de los usuarios
        /// </summary>
        /// <param name="entUsuario"></param>
        /// <returns></returns>
        static public DataSet MantenimientoUsuario(EUsuario entUsuario)
        {
            DataSet valorRetorno = new DataSet();
            valorRetorno = ADUsuario.MantenimientoUsuario(entUsuario);
            return valorRetorno;
        }
        #endregion

        #region MantenimientoUsuario
        /// <summary>
        /// Mantenimiento de los usuarios
        /// </summary>
        /// <param name="entUsuario"></param>
        /// <returns></returns>
        static public DataSet MantenimientoSuperUsuario(EUsuario entUsuario)
        {
            DataSet valorRetorno = new DataSet();
            valorRetorno = ADUsuario.MantenimientoSuperUsuario(entUsuario);
            return valorRetorno;
        }
        #endregion
    }
}