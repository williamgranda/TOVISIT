using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOVISIT.APP.Entidades
{
    public class EActividad
    {

        private int tipoAccion;

        public int TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }


        private int id_lugar;

        public int Id_lugar
        {
            get { return id_lugar; }
            set { id_lugar = value; }
        }

        private int id_actividad;

        public int Id_actividad
        {
            get { return id_actividad; }
            set { id_actividad = value; }
        }


        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string nombre_actividad;

        public string Nombre_actividad
        {
            get { return nombre_actividad; }
            set { nombre_actividad = value; }
        }
        private string descripcion_actividad;

        public string Descripcion_actividad
        {
            get { return descripcion_actividad; }
            set { descripcion_actividad = value; }
        }


        private string fecha_incio;

        public string Fecha_incio
        {
            get { return fecha_incio; }
            set { fecha_incio = value; }
        }
        private string fecha_fin;

        public string Fecha_fin
        {
            get { return fecha_fin; }
            set { fecha_fin = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
    }
}