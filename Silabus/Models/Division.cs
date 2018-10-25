using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Division
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public String Docente { get; set; }
        public String Vista { get; set; }
        public Division()
        {
        }
    }
}