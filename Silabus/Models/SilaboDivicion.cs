using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDivicion
    {
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabo Silabo { get; set; }
        public int IdDivicion { get; set; }
        [ForeignKey("IdDivicion")]
        public virtual Divicion Divicion { get; set; }
        //public SilaboDivicion()
        //{
                
        //}
        //public SilaboDivicion(string vista, int id, string sumilla)
        //{
        //    this.Silabo = new Silabo();
        //    this.Silabo.Id = id;
        //    this.Silabo.Sumilla = sumilla;
        //    this.Divicion = new Divicion();
        //    this.Divicion.Vista = vista;
        //}
    }
}