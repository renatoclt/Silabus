using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboFaseUnidades
    {
        public int Id { get; set; }
        public int IdSilaboFase { get; set; }
        public int IdSilaboUnidad { get; set; }
        public int Unidad { get; set; }
        public int SubUnidad { get; set; }
        public int estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        SilaboFaseUnidades()
        {

        }
    }
}