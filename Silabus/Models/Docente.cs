using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silabus.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public String Codidgo { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Nombres { get; set; }
        public int idTipoDocente { get; set; }
        [ForeignKey("idTipoDocente")]
        public virtual TipoDocente TipoDocente { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        public Docente()
        {
            this.TipoDocente = new TipoDocente();
        }
    }
}