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
        public String Descripcion { get; set; }

        public int Estado { get; set; }

        [MaxLength(50)]
        [Required]
        public String UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public TipoDocentes()
        {

        }
    }
}