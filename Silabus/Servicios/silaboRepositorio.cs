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
                    .Include("Silabo.SilaboFases.Fase")
                    .Include("Silabo.SilaboFases.SilaboFasesSaberes")
                    .Include("Silabo.Asignaturas.AsignaturaCompetencias.Competencia");
                return silaboDivicions.ToList();

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

        

        internal void EditarDivicionCancel(int id)
        {
            using (var db = new SilaboContext())
            {
                Divicion divicion = db.Diviciones.Find(id);
                divicion.Estado = 1;
                db.SaveChanges();
            }
        }

        internal void GuardarSumilla(Silabo silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabo.Where(s => s.Id == silaboSave.Id).FirstOrDefault();
                silabo.Sumilla = silaboSave.Sumilla;
                db.SaveChanges();
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