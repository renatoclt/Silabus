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
                return db.diviciones.ToList();
            }
        }


    }
}