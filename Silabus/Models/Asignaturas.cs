using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
<<<<<<< HEAD
    public class Asignaturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public String Codigo { get; set; }
        [Required]
        public int Semestre { get; set; }
        [Required]
        public float HorasSemanalesTeoricas { get; set; }
        [Required]
        public float HorasSemanalesPracticaAula { get; set; }
        [Required]
        public float HorasSemanalesPracticaJefe { get; set; }
        [Required]
        public float HorasSemanalesVirtuales { get; set; }
        [Required]
        public float HorasSemestralesTeorica { get; set; }
        [Required]
        public float HorasSemestralesPractica { get; set; }
        [Required]
        public float HorasSemestralesVirtuales { get; set; }
        [Required]
        public int Creditos { get; set; }
        [Required]
        public int IdPlanEstudio { get; set; }
        [ForeignKey("IdPlanEstudio")]
        public virtual PlanEstudio PlanEstudio { get; set; }
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamento { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [MaxLength(50)]
        private String UsuarioCreacion { get; set; }
        [MaxLength(50)]
        private String UsuarioModificacion { get; set; }
        public virtual ICollection<AsignaturaCompetencias> AsignaturaCompetencias { get; set; }
        public IEnumerable<Fase> Fase { get; set; }
        public ICollection<Unidad> Unidads { get; set; }
        Asignaturas()
        {
            AsignaturaCompetencias = new HashSet<AsignaturaCompetencias>();
            Unidads = new HashSet<Unidad>();
     
        }
    }
}