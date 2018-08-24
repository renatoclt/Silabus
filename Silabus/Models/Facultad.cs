using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Facultad
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        public virtual IEnumerable<Escuela> Escuelas { get; set; }
        public Facultad()
        {

        }
    }
}