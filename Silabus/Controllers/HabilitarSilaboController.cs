using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Silabus.Servicios;
using System.Web.Mvc;
using Silabus.Services;

namespace Silabus.Controllers
{
    public class HabilitarSilaboController : Controller
    {
        private VisualizarSilabo VisualizarSilabo;

        public HabilitarSilaboController()
        {
            VisualizarSilabo = new VisualizarSilabo();
        }
        // GET: VisualizarSilabo


        [HttpGet]
        public ActionResult Index()
        {
            List<VisualizarSilabo> visualizarSilabos = new List<VisualizarSilabo>();
            ViewBag.ListaAnioSemestre = VisualizarSilabo.ListarAnioSemestre(DateTime.Now.Year);
            return View(visualizarSilabos);
        }
        [HttpPost]
        public ActionResult Index(string FilEscuelaProfesional, string FilCodigoDocente, string FilDocente, string FilCurso, string ListaAnioSemestre)
        {
            ViewBag.ListaAnioSemestre = VisualizarSilabo.ListarAnioSemestre(DateTime.Now.Year);
            var model = VisualizarSilabo.ObtenerInformacion(FilEscuelaProfesional, FilCodigoDocente, FilDocente, FilCurso, ListaAnioSemestre);

            /*VisualizarSilabo visualizarSilabo = new VisualizarSilabo();
            visualizarSilabo.VisualizarInformacion(escuelaProfesional, codigoDocente, nombreDocente, nombreCurso, añoSemestre);
            return View(visualizarSilabo);*/
            return View(model);
        }

        public ActionResult Acciones () {
            return View();
        }
        // GET: HabilitarSilabo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HabilitarSilabo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabilitarSilabo/Create
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

        // GET: HabilitarSilabo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HabilitarSilabo/Edit/5
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

        // GET: HabilitarSilabo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HabilitarSilabo/Delete/5
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
