using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboFaseUnidades
    {
        public int Id { get; set; }
        public int IdSilaboFase { get; set; }
        [ForeignKey("IdSilaboFase")]
        public virtual SilaboFase SilaboFase { get; set; }
        public int IdSilaboUnidad { get; set; }
        [ForeignKey("IdSilaboUnidad")]
        public virtual Unidad Unidad { get; set; }
        public int UnidadI { get; set; }
        public int SubUnidad { get; set; }
        public int estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        SilaboFaseUnidades()
        {

        }
    }
}