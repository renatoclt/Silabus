using System;
using Silabus.Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silabus.Models;
using Silabus.Services;

namespace Silabus.Controllers
{
    public class VisualizarSilaboController : Controller
    {

        //private SilaboRepositorio _repo;
        private VisualizarSilabo VisualizarSilabo;

        public VisualizarSilaboController()
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
        public ActionResult Index(string FilEscuelaProfesional, string FilCodigoDocentes, string FilDocentes, string FilCurso, string ListaAnioSemestre)
        {
            ViewBag.ListaAnioSemestre = VisualizarSilabo.ListarAnioSemestre(DateTime.Now.Year);
            var model = VisualizarSilabo.ObtenerInformacion(FilEscuelaProfesional, FilCodigoDocentes, FilDocentes, FilCurso, ListaAnioSemestre,"VIS");

            /*VisualizarSilabo visualizarSilabo = new VisualizarSilabo();
            visualizarSilabo.VisualizarInformacion(escuelaProfesional, codigoDocentes, nombreDocentes, nombreCurso, añoSemestre);
            return View(visualizarSilabo);*/
            return View(model);
        }

        public ActionResult Ir()
        {
            return View();
        }

        // GET: VisualizarSilabo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisualizarSilabo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisualizarSilabo/Create
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

        // GET: VisualizarSilabo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VisualizarSilabo/Edit/5
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

        // GET: VisualizarSilabo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisualizarSilabo/Delete/5
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
