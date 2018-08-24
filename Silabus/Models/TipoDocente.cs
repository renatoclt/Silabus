using System;

namespace Silabus.Models
{
    public class TipoDocente
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
    }
}