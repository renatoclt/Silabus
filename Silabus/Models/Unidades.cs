using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Unidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdAsignatura { get; set; }
        [ForeignKey("IdAsignatura")]
        public virtual Asignaturas Asignaturas{ get; set; }
        public virtual ICollection<SilaboFaseUnidades> SilaboFaseUnidades { get; set; }
        public int Estado { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Unidades()
        {
            SilaboFaseUnidades = new HashSet<SilaboFaseUnidades>();
        }
    }
}