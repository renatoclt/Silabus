using Silabus.Models;
using Silabus.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Controllers
{
    public class SilaboDivisionController : Controller
    {
        private const string sumilla = "_sumilla";
        private const string competencia = "_competencia";
        private const string unidad = "_competencia";
        private const string evaluacion = "_competencia";

        private SilaboRepositorio _repo;
        public SilaboDivisionController()
        {
            _repo = new SilaboRepositorio();
        }
        // GET: SilaboDivisiones
        public ActionResult Index(int id=1)
        {
            List<SilaboDivisiones> model = _repo.ObtenerDivisiones(id);
            var fase = _repo.ObtenerFases();
            var saberes = _repo.ObtenerSaberes();
            model.ForEach(Divisiones =>
            {
                Divisiones.Silabos.Asignaturas.Fases = fase;
                Divisiones.Silabos.Asignaturas.Unidads = _repo.ObtenerUnidades(Divisiones.Silabos.Asignaturas.Id);
                foreach(var div in Divisiones.Silabos.SilaboFases)
                {
                    div.Saberes = saberes;
                }
            });
            return View(model);
        }


        // GET: SilaboDivisiones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SilaboDivisiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SilaboDivisiones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SilaboDivisiones/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditOk(SilaboDivisiones silaboDivision)
        {
            //silaboDivision.Divisiones = _repo.GetDivision(silaboDivision.IdDivision);
            //silaboDivision.Silabos = _repo.GetSilabo(silaboDivision.IdSilabo);
            //this.GuardarSilaboDivision(silaboDivision);
            //_repo.EditarDivisionCancel(id);
            _repo.EditarDivisionOk(silaboDivision.IdDivision);
            return RedirectToAction("Index"); ;
        }

        //[HttpPost]
        //public ActionResult EditOk()
        //{

        //    return RedirectToAction("Index"); ;
        //}
        //[HttpPost]
        //public ActionResult EditOk(SilaboDivisiones silaboDivision)
        //{

        //    return RedirectToAction("Index"); ;
        //}
        private bool GuardarSilaboDivision(SilaboDivisiones silaboDivision)
        {
            switch (silaboDivision.Divisiones.Vista)
            {
                case sumilla:
                    {
                        this._repo.GuardarUnidades(silaboDivision.Silabos);
                        return true;
                    }
                default:
                    return false;
            }
        }

        // GET: SilaboDivisiones/Edit/5
        //public ActionResult EditCancel(int id)

        // POST: SilaboDivisiones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SilaboDivisiones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SilaboDivisiones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
