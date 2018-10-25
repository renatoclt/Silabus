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
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        [Required]
        [MaxLength(50)]
        public String Cargo { get; set; }
        
    }
}