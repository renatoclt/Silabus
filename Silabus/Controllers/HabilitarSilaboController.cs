using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Silabus.Servicios;
using System.Web.Mvc;
using Silabus.Services;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

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
            //ViewBag.ListarEstado = VisualizarSilabo.ListarEstado();
            return View(visualizarSilabos);
        }
        [HttpPost]
        public ActionResult Index(string FilEscuelaProfesional, string FilCodigoDocentes, string FilDocentes, string FilCurso, string ListaAnioSemestre)
        {
            ViewBag.ListaAnioSemestre = VisualizarSilabo.ListarAnioSemestre(DateTime.Now.Year);
            //ViewBag.ListarEstado = VisualizarSilabo.ListarEstado();
            var model = VisualizarSilabo.ObtenerInformacion(FilEscuelaProfesional, FilCodigoDocentes, FilDocentes, FilCurso, ListaAnioSemestre,"HAB");

            /*VisualizarSilabo visualizarSilabo = new VisualizarSilabo();
            visualizarSilabo.VisualizarInformacion(escuelaProfesional, codigoDocentes, nombreDocentes, nombreCurso, añoSemestre);
            return View(visualizarSilabo);*/
            return View(model);
        }


        [HttpPost]
        //public ActionResult ActualizarEstado(/*Json en asp - serializar o deserializar/ asp mvc5 rest*/) {
        public JsonResult ActualizarEstado(int idSilabo, int codigoEstado) {
            try
            {
                int Actualizar = 0;
                Actualizar = VisualizarSilabo.ActualizarEstado(idSilabo, codigoEstado);
                //return exitoso 200
                if (Actualizar==1)
                    return Json(new { success = true, responseText = "Se actualizó correctamente el estado!" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { success = true, responseText = "Hubo un problema al momento de registrar la opción!" }, JsonRequestBehavior.AllowGet);

                
            }
            catch (Exception ex)
            {
                //error cod 500 como retornar el error

                return Json(new { success = false, responseText = "Ocurrio un error al momento de intentar conectarse con el servidor." }, JsonRequestBehavior.AllowGet);

            }
           
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
