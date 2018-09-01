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
        public DbSet<AsignaturaCompetencias> AsignaturaCompetencias { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Unidad> Unidads { get; set; }
        public DbSet<SilaboFase> SilabosFase { get; set; }
        public DbSet<SilaboFaseUnidades> SilaboFaseUnidades { get; set; }
        public DbSet<Saberes> Saberes { get; set; }
        public DbSet<Evidencias>Evidencias { get; set; }
        public DbSet<Criterios> Criterios { get; set; }
        public DbSet<SilaboFasesSaberes> SilaboFasesSaberes { get; set; }
        public DbSet<SilaboEvidencias> SilaboEvidencias { get; set; }
        public DbSet<SilaboCriterios> SilaboCriterios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}