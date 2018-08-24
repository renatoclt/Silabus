using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Silabus.Models;

namespace Silabus.Controllers
{
    public class SilaboDocentesController : Controller
    {
        private SilaboContext db = new SilaboContext();

        // GET: SilaboDocentes
        public ActionResult Index()
        {
            var silaboDocentes = db.SilaboDocentes.Where(s => s.Docente.Id == 2).Include(s => s.Silabo);
            return View(silaboDocentes.ToList());
        }

        // GET: SilaboDocentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SilaboDocente silaboDocente = db.SilaboDocentes.Find(id);
            if (silaboDocente == null)
            {
                return HttpNotFound();
            }
            return View(silaboDocente);
        }

        // GET: SilaboDocentes/Create
        public ActionResult Create()
        {
            ViewBag.IdDocente = new SelectList(db.Docentes, "Id", "Codidgo");
            ViewBag.IdSilabo = new SelectList(db.Silabo, "Id", "Sumilla");
            return View();
        }

        // POST: SilaboDocentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSilabo,IdDocente,Estado,FechaModificacion,FechaCreacion")] SilaboDocente silaboDocente)
        {
            if (ModelState.IsValid)
            {
                db.SilaboDocentes.Add(silaboDocente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDocente = new SelectList(db.Docentes, "Id", "Codidgo", silaboDocente.IdDocente);
            ViewBag.IdSilabo = new SelectList(db.Silabo, "Id", "Sumilla", silaboDocente.IdSilabo);
            return View(silaboDocente);
        }

        // GET: SilaboDocentes/Edit/5
        public ActionResult Edit(int? idSilabo)
        {
            return RedirectToAction("Index", "SilaboDivicion", new { id = idSilabo });
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SilaboDocente silaboDocente = db.SilaboDocentes.Find(id);
            //if (silaboDocente == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.IdDocente = new SelectList(db.Docentes, "Id", "Codidgo", silaboDocente.IdDocente);
            //ViewBag.IdSilabo = new SelectList(db.Silabo, "Id", "Sumilla", silaboDocente.IdSilabo);
            //return View(silaboDocente);
        }

        // POST: SilaboDocentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSilabo,IdDocente,Estado,FechaModificacion,FechaCreacion")] SilaboDocente silaboDocente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(silaboDocente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDocente = new SelectList(db.Docentes, "Id", "Codidgo", silaboDocente.IdDocente);
            ViewBag.IdSilabo = new SelectList(db.Silabo, "Id", "Sumilla", silaboDocente.IdSilabo);
            return View(silaboDocente);
        }

        // GET: SilaboDocentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SilaboDocente silaboDocente = db.SilaboDocentes.Find(id);
            if (silaboDocente == null)
            {
                return HttpNotFound();
            }
            return View(silaboDocente);
        }

        // POST: SilaboDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SilaboDocente silaboDocente = db.SilaboDocentes.Find(id);
            db.SilaboDocentes.Remove(silaboDocente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
