using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;

namespace TOVISIT.APP.Negocio
{
    public class NLugar
    {
        #region MantenimientoLugares
        /// <summary>
        /// Mantenimiento de lugares
        /// </summary>
        /// <param name="entUsuario"></param>
        /// <returns></returns>
        static public DataSet MantenimientoLugares(ELugar entLugar)
        {
            DataSet valorRetorno = new DataSet();
            valorRetorno = ADLugar.MantenimientoLugar(entLugar);
            return valorRetorno;
        }
        #endregion

        
    }
}