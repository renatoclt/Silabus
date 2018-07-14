using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Sumilla
    {
        private string contenido;
        private int estado;

        public Sumilla(string _contenido, int _estado)
        {
            Contenido = _contenido;
            Estado = _estado;
        }

        public string Contenido { get => contenido; set => contenido = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}