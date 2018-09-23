using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Docente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public String codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public String apellidoPaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public String apellidoMaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nombres { get; set; }

        [ForeignKey("TipoDocentes")]
        public int IdTipoDocente { get; set; }
        public TipoDocentes TipoDocentes { get; set; }

        [Required]
        public int estado { get; set; }

        [MaxLength(50)]
        public String usuarioCreacion { get; set; }

        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }


        public Docente()
        {

        }
    }
}