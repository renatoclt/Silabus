using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class PlanEstudio
    {
        public int Id { get; set; }
        public int IdEscuela { get; set; }
        [ForeignKey("IdEscuela")]
        public virtual Escuela Escuela{ get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
    }
}