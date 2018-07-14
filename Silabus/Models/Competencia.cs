using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Competencia
    {
        private int estado;
        private List<CompetenciaCurso> competencias;

        public Competencia(int estado, List<CompetenciaCurso> competencias)
        {
            this.estado = estado;
            this.competencias = competencias;
        }

        public int Estado { get => estado; set => estado = value; }
        public List<CompetenciaCurso> Competencias { get => competencias; set => competencias = value; }
    }
}