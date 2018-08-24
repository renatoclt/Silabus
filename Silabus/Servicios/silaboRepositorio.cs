using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Servicios
{
    public class SilaboRepositorio
    {
        public List<Divicion> ObtenerDiviciones()
        {
            using (var db = new SilaboContext())
            {
                return db.Diviciones.ToList();
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