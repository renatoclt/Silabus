using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDocente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Silabus")]
        public int IdSilabus { get; set; }
        public Silabus Silabus { get; set; }

        [ForeignKey("Docente")]
        public int IdDocente { get; set; }
        public Docente Docente { get; set; }

        [Required]
        [MaxLength(100)]
        public String funcion { get; set; }

        [Required]
        [MaxLength(50)]
        public String cargo { get; set; }

    }
}