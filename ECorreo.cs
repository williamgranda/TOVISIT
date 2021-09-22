using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOVISIT.APP.Entidades
{
    public class ECorreo
    {
        private string desde;

        public string Desde
        {
            get { return desde; }
            set { desde = value; }
        }
        private string para;

        public string Para
        {
            get { return para; }
            set { para = value; }
        }
        private string asunto;

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }
        private string cuerpo;

        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }
        private string html;

        public string Html
        {
            get { return html; }
            set { html = value; }
        }

    }
}