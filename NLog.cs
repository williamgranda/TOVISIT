using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.AccesoDatos;


namespace TOVISIT.APP.Negocio
{
    /// DESCRIPCION: Administracion de log
    public class NLog
    {
        #region InsertaLog
        /// Funcion que inserta log en base de datos        
        /// <param name="entLog">entidad de datos de log</param>
        static public void InsertaLog(ELog entLog)
        {
            string ipAddress = "";
            if (!String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"]))
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            else
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            string hostName = Dns.GetHostName();
            entLog.Host = ipAddress;
            ADLog.InsertarLog(entLog);
        }
        #endregion
    }
}