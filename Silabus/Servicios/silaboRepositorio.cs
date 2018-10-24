using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Silabus.Servicios
{
    public class SilaboRepositorio
    {
        private int estadoActivo;
        public SilaboRepositorio()
        {
            this.estadoActivo = 1;
        }

        public List<SilaboDivisiones> ObtenerDivisiones(int idSilabo)
        {
            using (var db = new SilaboContext())
            {
                var silaboDivisions = db.SilaboDivisiones.Where(s => s.Silabos.Id == idSilabo).Include(s => s.Divisiones)
                    .Include(s => s.Silabos.Asignaturas.PlanEstudios.Escuelas.Facultads)
                    .Include(s => s.Silabos.SilaboFases)
                    .Include("Silabos.SilaboFases.Fases")
                    .Include("Silabos.SilaboFases.SilaboFasesSaberes")
                    .Include("Silabos.SilaboFases.SilaboFaseUnidades")
                    .Include("Silabos.Asignaturas.AsignaturaCompetencias")
                    .Include("Silabos.Asignaturas.AsignaturaCompetencias.Competencia");
                return silaboDivisions.ToList();
            }
        }

        internal Silabos ObtenerSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.Where(s => s.Id == id)
                    .Include(s => s.SilaboDivisiones.Select(sd => sd.Divisiones))
                    .Include(s => s.Asignaturas.PlanEstudios.Escuelas.Facultads)
                    .Include(s => s.Asignaturas.Departamentos)
                    .Include(s => s.Asignaturas.Unidads.Select(u => u.SilaboFaseUnidades))
                    .Include(s => s.SilaboDocentes.Select(sd => sd.Docentes.TipoDocentes))
                    .Include(s => s.Asignaturas.AsignaturaCompetencias.Select(a => a.Competencia))
                    .Include(s => s.SilaboFases.Select(sf => sf.Fases))
                    .Include(s => s.SilaboFases.Select(sf => sf.AsignaturaCompetencias.Select(ac => ac.Competencia)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.Saberes)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFaseUnidades.Select(sfu => sfu.Unidades)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboCriterios.Select(se => se.Criterios))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEvidencias.Select(se => se.Evidencias))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEstrategias.Select(se => se.Estrategia))));
                return silabo.First();
            }
            
        }

        public List<Fases> ObtenerFases()
        {
           using (var db = new SilaboContext())
            {
                var fases = db.Fases.Where(f => f.Estado == this.estadoActivo).OrderBy(f=>f.Orden);
                return fases.ToList();                
            }
        }

        public List<Unidades> ObtenerUnidades(int id)
        {
            using (var db = new SilaboContext())
            {
                var unidades = db.Unidades.Where(u => u.Estado == this.estadoActivo).Where(u=> u.IdAsignatura == id);
                return unidades.ToList();
            }
        }
        public List<Saberes> ObtenerSaberes()
        {
            using (var db = new SilaboContext())
            {
                var saberes = db.Saberes.Where(s => s.Estado == this.estadoActivo).OrderBy(s => s.Orden);
                return saberes.ToList();
            }
        }

        public Divisiones GetDivision(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Divisiones.Where(d => d.Id == id).FirstOrDefault();

            }
        }
        
        public Silabos GetSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Silabos.Where(s => s.Id == id).FirstOrDefault();

            }
        }

        internal void EditarDivisionCancel(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                Divisiones.Estado = 1;
                db.SaveChanges();
            }
        }

        internal Silabos GuardarUnidades(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if(silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarCompetencias(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarEvaluacion(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarSumilla(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    silabo.Sumilla = silaboSave.Sumilla;
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal void EditarDivision(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                Divisiones.Estado = 3;
                db.SaveChanges();
            }
        }

        internal void EditarDivisionOk(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                if(Divisiones != null)
                    Divisiones.Estado = 1;
                db.SaveChanges();
            }
        }
    }
}