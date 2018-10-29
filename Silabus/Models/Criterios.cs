﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Criterios
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime ? FechaModificacion { get; set; }
        public Criterios()
        {

        }
    }
}