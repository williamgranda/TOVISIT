using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;
using System.Net.Mail;

namespace TOVISIT.APP.Negocio
{
    public class NCorreo
    {
        #region MantenimientoCorreos
        static public int MantenimientoCorreos(ECorreo entCorreo, MailMessage email)
        {
            int valorRetorno = 0;
            valorRetorno = ADCorreo.MantenimientoCorreos(entCorreo, email);
            return valorRetorno;
        }
        #endregion
    }
}