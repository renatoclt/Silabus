﻿using Silabus.Models;
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
        private const string sumilla = "_sumilla";
        private const string competencia = "_competencia";
        private const string unidad = "_competencia";
        private const string evaluacion = "_competencia";

        private SilaboRepositorio _repo;
        public SilaboDivicionController()
        {
            _repo = new SilaboRepositorio();
        }
        // GET: SilaboDivicion
        public ActionResult Index(int id=1)
        {
            List<SilaboDivicion> model = _repo.ObtenerDiviciones(id);
            var fase = _repo.ObtenerFases();
            var saberes = _repo.ObtenerSaberes();
            model.ForEach(divicion =>
            {
                divicion.Silabo.Asignaturas.Fase = fase;
                divicion.Silabo.Asignaturas.Unidads = _repo.ObtenerUnidades(divicion.Silabo.Asignaturas.Id);
                foreach(var div in divicion.Silabo.SilaboFases)
                {
                    div.Saberes = saberes;
                }
            });
            return View(model);
        }

        // GET: SilaboDivicion/Edit/5
        
        public ActionResult Edit(int id)
        {
            _repo.EditarDivicion(id);
            return RedirectToAction("Index"); ;
        }

        // GET: SilaboDivicion/Edit/5
        //[HttpPost]
        //public ActionResult EditOk(List<SilaboDivicion> silaboDivicion)
        public ActionResult EditOk(int id, int idSilabo, string sumilla)
        {
            _repo.EditarDivicionCancel(id);
            return RedirectToAction("Index"); ;
        }

        private bool GuardarSilaboDivicion(SilaboDivicion silaboDivicion)
        {
            switch (silaboDivicion.Divicion.Vista)
            {
                case sumilla:
                    {
                        this._repo.GuardarSumilla(silaboDivicion.Silabo);
                        return true;
                    }
                default:
                    return false;
            }
        }

        // GET: SilaboDivicion/Edit/5
        public ActionResult EditCancel(int id)
        {
            _repo.EditarDivicionCancel(id);
            return RedirectToAction("Index"); ;
        }
    }
}
