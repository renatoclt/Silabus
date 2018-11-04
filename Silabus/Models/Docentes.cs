﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Docentes
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public String Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public String ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public String ApellidoMaterno { get; set; }
        [Required]
        [MaxLength(50)]
        public String Nombres { get; set; }
        public int IdTipoDocentes { get; set; }
        [ForeignKey("IdTipoDocentes")]
        public virtual TipoDocentes TipoDocentes { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        [MaxLength(50)]
        public String UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [MaxLength(50)]
        public String UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Docentes()
        {

        }
    }
}