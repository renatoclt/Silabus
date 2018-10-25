using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDivision
    {
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabo Silabo { get; set; }
        public int IdDivision { get; set; }
        [ForeignKey("IdDivision")]
        public virtual Division Division { get; set; }
        //public SilaboDivision()
        //{
                
        //}
        //public SilaboDivision(string vista, int id, string sumilla)
        //{
        //    this.Silabo = new Silabo();
        //    this.Silabo.Id = id;
        //    this.Silabo.Sumilla = sumilla;
        //    this.Division = new Division();
        //    this.Division.Vista = vista;
        //}
    }
}