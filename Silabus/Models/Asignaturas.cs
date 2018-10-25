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
        public String Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public String Codigo { get; set; }
        [Required]
        public String Semestre { get; set; }
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
        public virtual PlanEstudios PlanEstudios { get; set; }
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamentos Departamentos { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public virtual ICollection<AsignaturaCompetencias> AsignaturaCompetencias { get; set; }
        public IEnumerable<Fases> Fases { get; set; }
        public ICollection<Unidades> Unidads { get; set; }
        public Asignaturas()
        {
            AsignaturaCompetencias = new HashSet<AsignaturaCompetencias>();
            Unidads = new HashSet<Unidades>();
     
        }
    }
}