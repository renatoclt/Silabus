using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboCompetencia
    {

        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilaboFases")]
        public virtual Silabo Silabo { get; set; }
        public int IdDivicion { get; set; }
        [ForeignKey("IdDivicion")]
        public virtual Divicion Divicion { get; set; }
        SilaboCompetencia()
        {

        }
    }
}