using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Models
{
    public class SilaboFaseUnidades
    {
        public int Id { get; set; }
        public int IdSilaboFase { get; set; }
        [ForeignKey("IdSilaboFase")]
        public virtual SilaboFases SilaboFases { get; set; }
        public int IdSilaboUnidad { get; set; }
        [ForeignKey("IdSilaboUnidad")]
        public virtual Unidades Unidades { get; set; }
        public int NroUnidad { get; set; }
        public int NroSubUnidad { get; set; }
        public int Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        [NotMapped]
        public SelectList Fases { get; set; }
        public SilaboFaseUnidades()
        {

        }
    }
}