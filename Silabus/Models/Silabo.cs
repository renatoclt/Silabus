using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Silabo
    {
        public int Id { get; set; }
        public int IdPlanFuncionamiento { get; set; }
        [ForeignKey("IdPlanFuncionamiento")]
        public virtual PlanFuncionamiento PlanFuncionamiento { get; set; }
        public int IdAsignatura { get; set; }
        [ForeignKey("IdAsignatura")]
        public virtual Asignaturas Asignaturas { get; set; }
        public string Sumilla { get; set; }
        public string AmbienteTeoria { get; set; }
        public string AmbientePractica { get; set; }
        public int Estado { get; set; }
        public int AnioAcademico { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public int SelectedSilaboFase { get; set; }
        public virtual ICollection<SilaboFase> SilaboFases { get; set; }
        public virtual ICollection<SilaboDocente> SilaboDocentes { get; set; }
        public virtual ICollection<SilaboDivicion> SilaboDiviciones { get; set; }
        public Silabo()
        {
            SilaboFases = new HashSet<SilaboFase>();
            SilaboDocentes = new HashSet<SilaboDocente>();
            SilaboDiviciones = new HashSet<SilaboDivicion>();
        }
        public Silabo(int id, int idPlanFuncionamiento, string sumilla)
        {
            SilaboFases = new HashSet<SilaboFase>();
        }
    }
}