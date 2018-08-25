using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboContext : DbContext
    {
        public SilaboContext() : base("SilaboDBContext")
        {

        }
        public DbSet<Divicion> Diviciones { get; set; }
        public DbSet<IdentificacionAcademicaModel> IdentificacionAcademicas { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Escuela> Escuela { get; set; }
        public DbSet<PlanEstudio> PlanEstudios { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Silabo> Silabo { get; set; }
        public DbSet<PlanFuncionamiento> PlanFuncionamientos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<TipoDocente> TipoDocentes { get; set; }
        public DbSet<SilaboDocente> SilaboDocentes { get; set; }
        public DbSet<SilaboDivicion> SilaboDivicions { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<AsignaturaCompetencia> AsignaturaCompetencias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}