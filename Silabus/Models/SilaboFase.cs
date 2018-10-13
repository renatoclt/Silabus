using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboFase
    {
        public int Id { get; set; }
        public int IdFases { get; set; }
        [ForeignKey("IdFases")]
        public virtual Fase Fase{ get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabo Silabo { get; set; }
        [Display(Name = "Titulo de fase")]
        public string Titulo { get; set; }
        public int HoraFase { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<SilaboFasesSaberes> SilaboFasesSaberes { get; set; }
        public virtual ICollection<SilaboFaseUnidades> SilaboFaseUnidades { get; set; }
        public virtual IEnumerable<Saberes> Saberes { get; set; }
        public SilaboFase()
        {

        }
    }
}