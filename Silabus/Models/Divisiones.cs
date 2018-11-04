using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Divisiones
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
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

        public Divisiones()
        {
        }
    }
}