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
            Silabos silabo = _repo.ObtenerSilabo(id);
            return View(silabo);
        }

        public ActionResult Edit(int id, int idDivision)
        {
            _repo.EditarDivision(idDivision);
            return RedirectToAction("Silabos", id); ;
        }

        public ActionResult EditCancel(int id, int idDivision)
        {
            _repo.EditarDivisionCancel(idDivision);
            return RedirectToAction("Silabos", id); ;
        }

        public ActionResult GuardarSumilla(Silabos silabo)
        {
            silabo = _repo.GuardarSumilla(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDSUMILLA)).FirstOrDefault().Divisiones.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarCompetencias(Silabos silabo)
        {
            silabo = _repo.GuardarCompetencias(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDCOMPETENCIAS)).FirstOrDefault().Divisiones.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }

        public ActionResult GuardarUnidad(Silabos silabo)
        {
            silabo = _repo.GuardarUnidades(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDUNIDADES)).FirstOrDefault().Divisiones.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarEvaluacion(Silabos silabo)
        {
            silabo = _repo.GuardarEvaluacion(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDEVALUACION)).FirstOrDefault().Divisiones.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }

        public ActionResult CambiarFaseEvaluacion(Silabos silaboTem)
        {
            Silabos silabo = _repo.ObtenerSilabo(silaboTem.Id);
            silabo.SelectedSilaboFase = silaboTem.SelectedSilaboFase;
            return View("Silabos", silabo);
        }

    }
}