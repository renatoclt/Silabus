﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboDocente
    {
        public int Id { get; set; }
        public int IdSilabo { get; set; }
        [ForeignKey("IdSilabo")]
        public virtual Silabo Silabo { get; set; }
        public int IdDocente { get; set; }
        [ForeignKey("IdDocente")]
        public virtual Docente Docente { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
    }
}