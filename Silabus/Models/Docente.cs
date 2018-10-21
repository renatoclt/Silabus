using System;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
>>>>>>> master

namespace Silabus.Models
{
    public class Docente
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public String Codidgo { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Nombres { get; set; }
        public int idTipoDocente { get; set; }
        [ForeignKey("idTipoDocente")]
        public virtual TipoDocente TipoDocente { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        public Docente()
        {
            this.TipoDocente = new TipoDocente();
=======
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

>>>>>>> master
        }
    }
}