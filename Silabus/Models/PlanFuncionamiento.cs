using System;

namespace Silabus.Models
{
    public class PlanFuncionamiento
    {
        public int Id { get; set; }
        public DateTime Anio { get; set; }
        public String Semestre { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
    }
}