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
    public class Escuela
    {
<<<<<<< HEAD
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
        public Escuela()
        {
        }
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String nombre { get; set; }

        [ForeignKey("Facultad")]
        public int IdFacultad { get; set; }
        public Facultad Facultad { get; set; }

        [Required]
        public int estado { get; set; }

        [Required]
        [MaxLength(50)]
        public String usuarioCreacion { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

>>>>>>> master
    }
}