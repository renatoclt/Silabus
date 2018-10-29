
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Facultades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }
        [Required]
        public int Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public virtual IEnumerable<Escuelas> Escuelas { get; set; }
        public Facultades()
        {

        }

    }
}