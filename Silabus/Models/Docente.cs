using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        public String Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public String ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public String ApellidoMaterno { get; set; }
        [Required]
        [MaxLength(50)]
        public String Nombres { get; set; }
        public int idTipoDocente { get; set; }
        [ForeignKey("idTipoDocente")]
        public virtual TipoDocente TipoDocente { get; set; }
        [Required]
        public int Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [MaxLength(50)]
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        [MaxLength(50)]
        private String UsuarioModificacion { get; set; }
        public Docente()
        {
            //this.TipoDocente = new TipoDocente();

        }
    }
}