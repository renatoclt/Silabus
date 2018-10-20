using Silabus.Models;
using Silabus.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Silabus.utils;
namespace Silabus.Controllers
{
    public class SilabosController : Controller
    {
        // GET: Silaboes
        private SilaboRepositorio _repo;
        public SilabosController()
        {
            _repo = new SilaboRepositorio();
        }
        public ActionResult Silabos(int id = 1)
        {
            Silabo silabo = _repo.ObtenerSilabo(id);
            return View(silabo);
        }

        public ActionResult Edit(int id, int idDivicion)
        {
            _repo.EditarDivicion(idDivicion);
            return RedirectToAction("Silabos", id); ;
        }

        public ActionResult EditCancel(int id, int idDivicion)
        {
            _repo.EditarDivicionCancel(idDivicion);
            return RedirectToAction("Silabos", id); ;
        }

        public ActionResult GuardarSumilla(Silabo silabo)
        {
            silabo = _repo.GuardarSumilla(silabo);
            _repo.EditarDivicionCancel(silabo.SilaboDiviciones.Where(sd => sd.Divicion.Id.Equals(Constantes.IDSUMILLA)).FirstOrDefault().Divicion.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarCompetencias(Silabo silabo)
        {
            silabo = _repo.GuardarCompetencias(silabo);
            _repo.EditarDivicionCancel(silabo.SilaboDiviciones.Where(sd => sd.Divicion.Id.Equals(Constantes.IDCOMPETENCIAS)).FirstOrDefault().Divicion.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }

        public ActionResult GuardarUnidad(Silabo silabo)
        {
            silabo = _repo.GuardarUnidades(silabo);
            _repo.EditarDivicionCancel(silabo.SilaboDiviciones.Where(sd => sd.Divicion.Id.Equals(Constantes.IDUNIDADES)).FirstOrDefault().Divicion.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarEvaluacion(Silabo silabo)
        {
            silabo = _repo.GuardarEvaluacion(silabo);
            _repo.EditarDivicionCancel(silabo.SilaboDiviciones.Where(sd => sd.Divicion.Id.Equals(Constantes.IDEVALUACION)).FirstOrDefault().Divicion.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }

        public ActionResult CambiarFaseEvaluacion(Silabo silaboTem)
        {
            Silabo silabo = _repo.ObtenerSilabo(silaboTem.Id);
            silabo.SelectedSilaboFase = silaboTem.SelectedSilaboFase;
            return View("Silabos", silabo);
        }

    }
}