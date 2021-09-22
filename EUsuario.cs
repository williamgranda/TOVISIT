using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOVISIT.APP.Entidades
{
    public class EUsuario
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private int tipoAccion;
        public int TipoAccion
        {
            get { return tipoAccion; }
            set { tipoAccion = value; }
        }
        

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string correo;
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        private string contrasena;
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        private int estado;
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int tipo;
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private int id_unidad;
        public int Id_unidad
        {
            get { return id_unidad; }
            set { id_unidad = value; }
        }

        private byte[] archivo;
        public byte[] Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private string extensionArchivo;

        public string ExtensionArchivo
        {
            get { return extensionArchivo; }
            set { extensionArchivo = value; }
        }

        private string descripcionArchivo;

        public string DescripcionArchivo
        {
            get { return descripcionArchivo; }
            set { descripcionArchivo = value; }
        }

        private string rucMedio;

        public string RucMedio
        {
            get { return rucMedio; }
            set { rucMedio = value; }
        }

        private string razonSocial;

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private string nombreComercial;

        public string NombreComercial
        {
            get { return nombreComercial; }
            set { nombreComercial = value; }
        }

        private int codigoClasificacion;

        public int CodigoClasificacion
        {
            get { return codigoClasificacion; }
            set { codigoClasificacion = value; }
        }

        private string correoElectronico;

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        private int codigoInt;

        public int CodigoInt
        {
            get { return codigoInt; }
            set { codigoInt = value; }
        }
    }
}