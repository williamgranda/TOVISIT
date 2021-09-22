using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOVISIT.APP.Entidades
{
    public class ELugar
    {

        private int tipoAccion;

        public int TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }


        private int id_tipo_lugar;

        public int Id_tipo_lugar
        {
            get { return id_tipo_lugar; }
            set { id_tipo_lugar = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string nombre_lugar;

        public string Nombre_lugar
        {
            get { return nombre_lugar; }
            set { nombre_lugar = value; }
        }
        private string descripcion_lugar;

        public string Descripcion_lugar
        {
            get { return descripcion_lugar; }
            set { descripcion_lugar = value; }
        }
        private string imagen_lugar;

        public string Imagen_lugar
        {
            get { return imagen_lugar; }
            set { imagen_lugar = value; }
        }
        private string coordenadas;

        public string Coordenadas
        {
            get { return coordenadas; }
            set { coordenadas = value; }
        }
        private string lat;

        public string Lat
        {
            get { return lat; }
            set { lat = value; }
        }
        private string lng;

        public string Lng
        {
            get { return lng; }
            set { lng = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
    }
}