using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Estado
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public String descripcion { get; set; }

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


    }
}