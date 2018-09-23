using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class SilaboContext :DbContext
    {
        public SilaboContext() : base("SilaboDBContext")
        {

        }
        public DbSet<Divicion> Divicions { get; set; }
        public DbSet<TipoDocentes> TipoDocentes { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Escuela> Escuela { get; set; }
        public DbSet<PlanFuncionamiento> PlanFuncionamiento { get; set; }
        public DbSet<PlanEstudio> PlanEstudio { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Silabus> Silabus { get; set; }
        public DbSet<SilaboDocente> SilabusDocente { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Parametricas> Parametricas { get; set; }


    }
}