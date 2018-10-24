using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silabus.Models
{
    public class TipoDocentes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String descripcion { get; set; }

        public int estado { get; set; }

        [MaxLength(50)]
        [Required]
        public String usuarioCreacion { get; set; }

        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public TipoDocentes()
        {

        }
    }
}