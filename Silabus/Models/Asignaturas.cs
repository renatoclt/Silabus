using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
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
        public virtual IEnumerable<AsignaturaCompetencia> AsignaturaCompetencias { get; set; }
        public int IdPlanEstudio { get; set; }
        [ForeignKey("IdPlanEstudio")]
        public virtual PlanEstudio PlanEstudio { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        Asignaturas()
        {
            AsignaturaCompetencias = new HashSet<AsignaturaCompetencia>();
        }
    }
}