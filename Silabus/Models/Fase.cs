using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Fase
    { 
        private int codigo;
        private string descripcion;

        public Fase(int codigo, string descripcion)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}