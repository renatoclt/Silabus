using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class PlanFuncionamiento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime anio { get; set; }

        [Required]
        public int semestre { get; set; }

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

        public PlanFuncionamiento()
        {

        }
    }
}