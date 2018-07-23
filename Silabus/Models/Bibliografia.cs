using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Bibliografia
    {
        private int estado;
        private List<Libros> libros;

        public Bibliografia(int estado, List<Libros> libros)
        {
            this.estado = estado;
            this.libros = libros;
        }

        public int Estado { get => estado; set => estado = value; }
        public List<Libros> Libros { get => libros; set => libros = value; }
    }
}