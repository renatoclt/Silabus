using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Competencia
    {
        public int Id { get; set; }
        public int IdEscuelas {get; set;}
        [ForeignKey("IdEscuelas")]
        public virtual Escuelas Escuelas { get; set; }
        public String Descripcion { get; set; }
        public String Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        public Competencia()
        {
        }
    }
}