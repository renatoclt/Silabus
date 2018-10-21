using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Silabus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("PlanFuncionamiento")]
        public int IdPlanFuncionamiento { get; set; }
        public PlanFuncionamiento PlanFuncionamiento { get; set; }

        [ForeignKey("Asignaturas")]
        public int IdAsignaturas { get; set; }
        public Asignaturas Asignaturas { get; set; }

        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        [Required]
        [MaxLength(10)]
        public String sumilla { get; set; }

        [Required]
        [MaxLength(50)]
        public String usuarioCreacion { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public Silabus()
        {

        }
    }
}