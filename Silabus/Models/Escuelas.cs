using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Escuelas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }
        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public virtual Facultades Facultads { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Escuelas()
        {
        }

    }
}