﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboFasesSaberes
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public int IdSaberes { get; set; }
        [ForeignKey("IdSaberes")]
        public virtual Saberes Saberes { get; set; }
        public int IdSilaboFase { get; set; }
        [ForeignKey("IdSilaboFase")]
        public virtual SilaboFase SilaboFase { get; set; }
        public int ValorTeorico { get; set; }
        public int ValorPractico { get; set; }
        public String Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<SilaboEvidencias> SilaboEvidencias { get; set; }
        public virtual ICollection<SilaboCriterios> SilaboCriterios { get; set; }
        public virtual ICollection<SilaboEstrategias> SilaboEstrategias { get; set; }
        public SilaboFasesSaberes()
        {
            SilaboEvidencias = new HashSet<SilaboEvidencias>();
            SilaboCriterios = new HashSet<SilaboCriterios>();
            SilaboEstrategias = new HashSet<SilaboEstrategias>();
        }
    }
}