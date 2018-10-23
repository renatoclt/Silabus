using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
>>>>>>> master

namespace Silabus.Models
{
    public class PlanFuncionamiento
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public DateTime Anio { get; set; }
        public String Semestre { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        private String UsuarioCreacion { get; set; }
        private String UsuarioModificacion { get; set; }
        public PlanFuncionamiento()
        {
            
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime anio { get; set; }

        [Required]
        public int semestre { get; set; }

        [Required]
        public int estado { get; set; }

        [Required]
        [MaxLength(50)]
        public String usuarioCreacion { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }

        [MaxLength(50)]
        public String usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public PlanFuncionamiento()
        {

>>>>>>> master
        }
    }
}