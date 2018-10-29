using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Fases
    { 
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Estado { get; set; }
        public int ? IdPlanFuncionamiento { get; set; }
        [ForeignKey("IdPlanFuncionamiento")]
        public virtual PlanFuncionamientos PlanFuncionamientos { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
    }
}