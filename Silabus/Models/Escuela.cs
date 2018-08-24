using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Escuela
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public virtual Facultad Facultads { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
    }
}