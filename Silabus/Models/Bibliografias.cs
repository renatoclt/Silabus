﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Bibliografiass
    {
        private int estado;
        private List<Libros> libros;    

        public Bibliografiass(int estado, List<Libros> libros)
        {
            this.estado = estado;
            this.libros = libros;
        }

        public int Estado { get => estado; set => estado = value; }
        public List<Libros> Libros { get => libros; set => libros = value; }
        public Bibliografiass()
        {

        }
    }
}