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
        public DbSet<Divisiones> Divisiones { get; set; }
        public DbSet<Facultades> Facultades { get; set; }
        public DbSet<Escuelas> Escuelas { get; set; }
        public DbSet<PlanEstudios> PlanEstudios { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Silabos> Silabos { get; set; }
        public DbSet<PlanFuncionamientos> PlanFuncionamientos { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<TipoDocentes> TipoDocentes { get; set; }
        public DbSet<SilaboDocentes> SilaboDocentes { get; set; }
        public DbSet<SilaboDivisiones> SilaboDivisiones { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<AsignaturaCompetencias> AsignaturaCompetencias { get; set; }
        public DbSet<Fases> Fases { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<SilaboFases> SilabosFases { get; set; }
        public DbSet<SilaboFaseUnidades> SilaboFaseUnidades { get; set; }
        public DbSet<Saberes> Saberes { get; set; }
        public DbSet<Evidencias>Evidencias { get; set; }
        public DbSet<Criterios> Criterios { get; set; }
        public DbSet<SilaboFasesSaberes> SilaboFasesSaberes { get; set; }
        public DbSet<SilaboEvidencias> SilaboEvidencias { get; set; }
        public DbSet<SilaboCriterios> SilaboCriterios { get; set; }
        public DbSet<Estrategias> Estrategias { get; set; }
        public DbSet<SilaboEstrategias> SilaboEstrategias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Parametricas> Parametricas { get; set; }
        //public DbSet<PlanEstudios> PlanEstudios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        
        //public DbSet<PlanFuncionamientos> PlanFuncionamientos { get; set; }
        
        //public DbSet<SilaboDocentes> SilaboDocentes { get; set; }
        
    }
}