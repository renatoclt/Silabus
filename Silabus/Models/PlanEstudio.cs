using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class PlanEstudio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEscuela { get; set; }
        [ForeignKey("IdEscuela")]
        public virtual Escuela Escuela{ get; set; }
        [Required]
        public int Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [MaxLength(50)]
        private String UsuarioCreacion { get; set; }
        [MaxLength(50)]
        private String UsuarioModificacion { get; set; }
        public PlanEstudio()
        {
        }
    }
}