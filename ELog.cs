using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOVISIT.APP.Entidades
{
    /// DESCRIPCION: Entidad para el registro de log del sistema
    public class ELog
    {
        #region Declaracion de variables
        private int tipoAccion;
        public int TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string host;
        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        #endregion

    }
}