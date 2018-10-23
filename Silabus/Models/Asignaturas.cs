using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> master
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
<<<<<<< HEAD
    public class Asignaturas 
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public int Semestre { get; set; }
        public float HorasSemanalesTeoricas { get; set; }
        public float HorasSemanalesPracticaAula { get; set; }
        public float HorasSemanalesPracticaJefe { get; set; }
        public float HorasSemanalesVirtuales { get; set; }
        public float HorasSemestralesTeorica { get; set; }
        public float HorasSemestralesPractica { get; set; }
        public float HorasSemestralesVirtuales { get; set; }
        public int Creditos { get; set; }
        public int IdPlanEstudio { get; set; }
        [ForeignKey("IdPlanEstudio")]
        public virtual PlanEstudio PlanEstudio { get; set; }
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamento { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        public virtual ICollection<AsignaturaCompetencias> AsignaturaCompetencias { get; set; }
        public IEnumerable<Fase> Fase { get; set; }
        public ICollection<Unidad> Unidads { get; set; }
        Asignaturas()
        {
            AsignaturaCompetencias = new HashSet<AsignaturaCompetencias>();
            Unidads = new HashSet<Unidad>();
=======
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

>>>>>>> master
        }
    }
}