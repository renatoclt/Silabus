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
        public List<SilaboDivicion> ObtenerDiviciones(int idSilabo)
        {
            using (var db = new SilaboContext())
            {
                var silaboDivicions = db.SilaboDivicions.Where(s => s.Silabo.Id == idSilabo).Include(s => s.Divicion)
                    .Include(s => s.Silabo.Asignaturas.PlanEstudio.Escuela.Facultads);
                return silaboDivicions.ToList();
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
                divicion.Estado = 1;
                db.SaveChanges();
            }
        }
    }
}