using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Unidad
    {
        private int estado;
        private List<UnidadCurso> unidades;


        public Unidad()
        {
            estado = 0;

        }

        public Unidad(int estado, List<UnidadCurso> unidades)
        {
            this.estado = estado;
            this.unidades = unidades;
        }

        
        public int Estado { get => estado; set => estado = value; }
        public List<UnidadCurso> Unidades { get => unidades; set => unidades = value; }

        public void SortList(Unidad unidadTem)
        {
            
            Unidades.Sort(delegate (UnidadCurso a, UnidadCurso b)
            {
                int xdiff = a.Id.CompareTo(b.Id);
                if (xdiff != 0) return xdiff;
                else return a.SubUnidad.CompareTo(b.SubUnidad);
            });
        }
    }
}