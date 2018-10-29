using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Silabos
    {
        public int Id { get; set; }
        public int ? IdPlanFuncionamiento { get; set; }
        [ForeignKey("IdPlanFuncionamiento")]
        public virtual PlanFuncionamientos PlanFuncionamientos { get; set; }
        public int IdAsignatura { get; set; }
        [ForeignKey("IdAsignatura")]
        public virtual Asignaturas Asignaturas { get; set; }
        [DataType(DataType.MultilineText)]
        public string Sumilla { get; set; }
        public string AmbienteTeoria { get; set; }
        public string AmbientePractica { get; set; }
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
        public int EstadoAuditoria { get; set; }
        public int AnioAcademico { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public int ? SelectedSilaboFase { get; set; }
        public virtual ICollection<SilaboFases> SilaboFases { get; set; }
        public virtual ICollection<SilaboDocentes> SilaboDocentes { get; set; }
        public virtual ICollection<SilaboDivisiones> SilaboDivisiones { get; set; }
        public Silabos()
        {
            SilaboFases = new HashSet<SilaboFases>();
            SilaboDocentes = new HashSet<SilaboDocentes>();
            SilaboDivisiones = new HashSet<SilaboDivisiones>();
        }
    }
}