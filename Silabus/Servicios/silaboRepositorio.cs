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

        public List<SilaboDivicion> ObtenerDiviciones(int idSilabo)
        {
            using (var db = new SilaboContext())
            {
                var silaboDivicions = db.SilaboDivicions.Where(s => s.Silabo.Id == idSilabo).Include(s => s.Divicion)
                    .Include(s => s.Silabo.Asignaturas.PlanEstudio.Escuela.Facultads)
                    .Include(s => s.Silabo.SilaboFases)
                    .Include("Silabo.SilaboFases.Fase")
                    .Include("Silabo.SilaboFases.SilaboFasesSaberes")
                    .Include("Silabo.SilaboFases.SilaboFaseUnidades")
                    .Include("Silabo.Asignaturas.AsignaturaCompetencias")
                    .Include("Silabo.Asignaturas.AsignaturaCompetencias.Competencia");
                return silaboDivicions.ToList();
            }
        }

        internal Silabo ObtenerSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.Where(s => s.Id == id)
                    .Include(s => s.SilaboDiviciones.Select(sd => sd.Divicion))
                    .Include(s => s.Asignaturas.PlanEstudio.Escuela.Facultads)
                    .Include(s => s.Asignaturas.Departamento)
                    .Include(s => s.Asignaturas.Unidads.Select(u => u.SilaboFaseUnidades))
                    .Include(s => s.SilaboDocentes.Select(sd => sd.Docente.TipoDocente))
                    .Include(s => s.Asignaturas.AsignaturaCompetencias.Select(a => a.Competencia))
                    .Include(s => s.SilaboFases.Select(sf => sf.Fase))
                    .Include(s => s.SilaboFases.Select(sf => sf.AsignaturaCompetencias.Select(ac => ac.Competencia)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.Saberes)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFaseUnidades.Select(sfu => sfu.Unidad)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboCriterios.Select(se => se.Criterios))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEvidencias.Select(se => se.Evidencias))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEstrategias.Select(se => se.Estrategia))));
                return silabo.First();
            }
            
        }

        public List<Fase> ObtenerFases()
        {
           using (var db = new SilaboContext())
            {
                var fases = db.Fases.Where(f => f.Estado == this.estadoActivo).OrderBy(f=>f.Orden);
                return fases.ToList();                
            }
        }

        public List<Unidad> ObtenerUnidades(int id)
        {
            using (var db = new SilaboContext())
            {
                var unidades = db.Unidads.Where(u => u.Estado == this.estadoActivo).Where(u=> u.IdAsignatura == id);
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

        public Divicion GetDivicion(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Diviciones.Where(d => d.Id == id).FirstOrDefault();

            }
        }
        
        public Silabo GetSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Silabo.Where(s => s.Id == id).FirstOrDefault();

            }
        }

        internal void EditarDivicionCancel(int id)
        {
            using (var db = new SilaboContext())
            {
                Divicion divicion = db.Diviciones.Find(id);
                divicion.Estado = 1;
                db.SaveChanges();
            }
        }

        internal Silabo GuardarUnidades(Silabo silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.SingleOrDefault(s => s.Id == silaboSave.Id);
                if(silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabo GuardarCompetencias(Silabo silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabo GuardarEvaluacion(Silabo silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabo GuardarSumilla(Silabo silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    silabo.Sumilla = silaboSave.Sumilla;
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal void EditarDivicion(int id)
        {
            using (var db = new SilaboContext())
            {
                Divicion divicion = db.Diviciones.Find(id);
                divicion.Estado = 3;
                db.SaveChanges();
            }
        }

        internal void EditarDivicionOk(int id)
        {
            using (var db = new SilaboContext())
            {
                Divicion divicion = db.Diviciones.Find(id);
                if(divicion != null)
                    divicion.Estado = 1;
                db.SaveChanges();
            }
        }
    }
}