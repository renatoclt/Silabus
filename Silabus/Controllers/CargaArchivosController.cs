using Silabus.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Controllers
{
    public class CargaArchivosController : Controller
    {
        // GET: CargaArchivos
        private SilaboRepositorio _repo;

        public CargaArchivosController()
        {
            _repo = new SilaboRepositorio();
        } 
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult CargaPlanEstudio() {

        //    var model = _repo.cargaArchivoPlanEstudios();
        //    return View(model);
        //}
        //public ActionResult CargaArchivoDocentes()
        //{
        //    var model = _repo.CargaArchivoArchivoDocentes();
        //    return View(model);
        //}
        //public ActionResult CargaAcademica()
        //{
        //    var model = _repo.cargaArchivoCargaAcademicas();
        //    return View(model);
        //}
        //public ActionResult CargaBibliografiass()
        //{
        //    var model = _repo.cargaArchivoBibliografiass();
        //    return View(model);
        //}

        // GET: CargaArchivos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CargaArchivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargaArchivos/Create
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

        // GET: CargaArchivos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CargaArchivos/Edit/5
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

        // GET: CargaArchivos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CargaArchivos/Delete/5
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
