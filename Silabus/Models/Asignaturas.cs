using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Asignaturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public String codigo { get; set; }

        [Required]
        public int semestre { get; set; }

        [Required]
        public float horasSemanalesTeoricas { get; set; }

        [Required]
        public float horasSemanalesPracticaAula { get; set; }

        [Required]
        public float horasSemanalesPracticaJefe { get; set; }

        [Required]
        public float horasSemanalesVirtuales { get; set; }

        [Required]
        public float horasSemestralesPractica { get; set; }

        [Required]
        public float horasSemestralesTeorica { get; set; }

        [Required]
        public float horasSemestralesVirtuales { get; set; }

        [Required]
        public int creditos { get; set; }

        [Required]
        public int estado { get; set; }

        [ForeignKey("PlanEstudio")]
        public int IdPlanEstudio { get; set; }
        public PlanEstudio PlanEstudio { get; set; }

        [Required]
        [MaxLength(50)]
        public String usuarioCreacion { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }
        

        public Asignaturas()
        {

        }
    }
}