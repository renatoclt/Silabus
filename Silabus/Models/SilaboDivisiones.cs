using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDivisiones
    {
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabos Silabos { get; set; }
        public int IdDivision { get; set; }
        [ForeignKey("IdDivision")]
        public virtual Divisiones Divisiones { get; set; }
        //public SilaboDivisiones()
        //{
                
        //}
        //public SilaboDivisiones(string vista, int id, string sumilla)
        //{
        //    this.Silabos = new Silabos();
        //    this.Silabos.Id = id;
        //    this.Silabos.Sumilla = sumilla;
        //    this.Divisiones = new Divisiones();
        //    this.Divisiones.Vista = vista;
        //}
    }
}