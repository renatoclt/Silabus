using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Libros
    {
        private String autor;
        private String nombre;
        private String editorial;
        private String lugarPublicacion;
        private String anioPublicacion;

        public Libros(string autor, string nombre, string editorial, string lugarPublicacion, string anioPublicacion)
        {
            this.autor = autor;
            this.nombre = nombre;
            this.editorial = editorial;
            this.lugarPublicacion = lugarPublicacion;
            this.anioPublicacion = anioPublicacion;
        }

        public string Autor { get => autor; set => autor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Editorial { get => editorial; set => editorial = value; }
        public string LugarPublicacion { get => lugarPublicacion; set => lugarPublicacion = value; }
        public string AnioPublicacion { get => anioPublicacion; set => anioPublicacion = value; }
    }
}