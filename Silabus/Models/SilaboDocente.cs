using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> master
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDocente
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabo Silabo { get; set; }
        public int IdDocente { get; set; }
        public string Funcion { get; set; }
        [ForeignKey("IdDocente")]
        public virtual Docente Docente { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Silabus")]
        public int IdSilabus { get; set; }
        public Silabus Silabus { get; set; }

        [ForeignKey("Docente")]
        public int IdDocente { get; set; }
        public Docente Docente { get; set; }

        [Required]
        [MaxLength(100)]
        public String funcion { get; set; }

        [Required]
        [MaxLength(50)]
        public String cargo { get; set; }

>>>>>>> master
    }
}