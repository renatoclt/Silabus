using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Silabus.Models
{
    public class AsignaturaCompetencias
    {
        public int Id { get; set; }
        public int IdCompetencia { get; set; }
        [ForeignKey("IdCompetencia")]
        public virtual Competencia Competencia { get; set; }
        public int IdAsignatura { get; set; }
        [ForeignKey("IdAsignatura")]
        public virtual Asignaturas Asignaturas { get; set; }
        public int ? IdSilaboFase { get; set; }
        [ForeignKey("IdSilaboFase")]
        public virtual SilaboFases SilaboFases { get; set; }
        public int Estado { get; set; }
        public String UsuarioCreacion { get; set; }
        public String UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [NotMapped]
        public SelectList Fases { get; set; }
        public AsignaturaCompetencias()
        {
        }
    }
}