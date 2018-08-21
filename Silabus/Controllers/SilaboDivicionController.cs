using Silabus.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Controllers
{
    public class SilaboDivicionController : Controller
    {
        private SilaboRepositorio _repo;
        public SilaboDivicionController()
        {
            _repo = new SilaboRepositorio();
        }
        // GET: SilaboDivicion
        public ActionResult Index()
        {
            var model = _repo.ObtenerDiviciones();
            return View(model);
        }


        // GET: SilaboDivicion/Edit/5
        public ActionResult Edit(int id)
        {
            _repo.EditarDivicion(id);
            return RedirectToAction("Index"); ;
        }

        // GET: SilaboDivicion/Edit/5
        public ActionResult EditOk(int id)
        {
            _repo.EditarDivicionOk(id);
            return RedirectToAction("Index"); ;
        }

        // GET: SilaboDivicion/Edit/5
        public ActionResult EditCancel(int id)
        {
            _repo.EditarDivicionCancel(id);
            return RedirectToAction("Index"); ;
        }
    }
}
