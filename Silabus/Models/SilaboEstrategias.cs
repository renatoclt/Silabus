using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboEstrategias
    {
        public int Id { get; set; }
        public int IdEstrategia { get; set; }
        [ForeignKey("IdEstrategia")]
        public virtual Estrategias Estrategia { get; set; }
        public int IdSilaboFasesSaberes { get; set; }
        [ForeignKey("IdSilaboFasesSaberes")]
        public virtual SilaboFasesSaberes SilaboFasesSaberes { get; set; }
        public String Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
    }
}