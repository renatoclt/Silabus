using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDocentes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabos Silabos { get; set; }
        public int IdDocente { get; set; }
        [Required]
        [MaxLength(50)]
        public string Funcion { get; set; }
        [Required]
        [MaxLength(50)]
        public string Categoria { get; set; }
        [ForeignKey("IdDocente")]
        public virtual Docentes Docentes { get; set; }
        public int Estado { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Required]
        [MaxLength(50)]
        public String Cargo { get; set; }
        
    }
}