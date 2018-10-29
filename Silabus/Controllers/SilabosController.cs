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
            this.CompetenciaBag(silabo);
            this.UnidadBag(silabo);
            return View(silabo);
        }

        private void CompetenciaBag(Silabos silabo)
        {
            ICollection<AsignaturaCompetencias> asignaturaCompetenciasTem;
            if (Session["AsignaturasCompetencia"] == null)
            {
                asignaturaCompetenciasTem = silabo.Asignaturas.AsignaturaCompetencias;
            }
            else
            {
                asignaturaCompetenciasTem = (ICollection<AsignaturaCompetencias>)Session["AsignaturasCompetencia"];
                Console.WriteLine(asignaturaCompetenciasTem);
            }
            asignaturaCompetenciasTem.ToList().ForEach(asignaturaCompetencias =>
            {
                asignaturaCompetencias.Fases = new SelectList(silabo.PlanFuncionamientos.Fases, "Id", "Nombre", asignaturaCompetencias.IdSilaboFase);
            });
            ViewBag.AsignaturasCompetencia = asignaturaCompetenciasTem.ToList();
            Session["AsignaturasCompetencia"] = ViewBag.AsignaturasCompetencia;
        }

        private void UnidadBag(Silabos silabo)
        {
            ICollection<SilaboFases> silaboFases = new HashSet<SilaboFases>();
            ICollection<SilaboFaseUnidades> silaboFaseUnidades = new HashSet<SilaboFaseUnidades>();
            if (Session["Unidades"] == null)
            {
                silaboFases = silabo.SilaboFases;
                silaboFases.ToList().ForEach(silaboFase =>
                {
                    silabo.SilaboFases.Where(sf => sf.Equals(silaboFase)).FirstOrDefault().SilaboFaseUnidades.ToList().ForEach(silaboFaseUnidad =>
                    {
                        silaboFaseUnidades.Add(silaboFaseUnidad);
                    });
                });
                silabo.Asignaturas.Unidads.ToList().ForEach( unidad =>
                {
                    if(silaboFaseUnidades.Count == 0 || silaboFaseUnidades.Where(sfu => sfu.Unidades.Id.Equals(unidad.Id)).FirstOrDefault().Equals(null))
                    {
                        SilaboFaseUnidades silaboFaseUnidadesTem = new SilaboFaseUnidades
                        {
                            Unidades = unidad,
                        };
                        silaboFaseUnidades.Add(silaboFaseUnidadesTem);
                    }
                });
            }
            ViewBag.Unidades = silaboFaseUnidades.ToList();
        }

        public ActionResult GetProduct(SelectListItem fd, string afd)
        {
            return RedirectToAction("Silabos", 1);
        }

        public ActionResult Edit(int id, int idDivision)
        {
            _repo.EditarDivision(idDivision);
            return RedirectToAction("Silabos", id); ;
        }

        public ActionResult EditCancel(int id, int idDivision)
        {
            _repo.EditarDivisionCancel(idDivision);
            Session["AsignaturasCompetencia"] = null;
            return RedirectToAction("Silabos", id);
        }

        public ActionResult GuardarSumilla(Silabos silabo)
        {
            silabo = _repo.GuardarSumilla(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDSUMILLA)).FirstOrDefault().Divisiones.Id);
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarCompetencias(Silabos silabo)
        {
            silabo = _repo.GuardarCompetencias(silabo, (ICollection<AsignaturaCompetencias>)Session["AsignaturasCompetencia"]);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDCOMPETENCIAS)).FirstOrDefault().Divisiones.Id);
            Session["AsignaturasCompetencia"] = null;
            return RedirectToAction("Silabos", silabo.Id);
        }

        [HttpPost]
        public ActionResult AgregarFaseCompetencias(int id, int idAsignatura, int idFase, int idCompetencia)
        {
            AsignaturaCompetencias tempAsignaturaCompetencias = new AsignaturaCompetencias
            {
                IdAsignatura = idAsignatura,
                IdSilaboFase = idFase,
                IdCompetencia = idCompetencia
            };
            ICollection<AsignaturaCompetencias> asignaturaCompetenciasTemp = (ICollection<AsignaturaCompetencias>)Session["AsignaturasCompetencia"];
            asignaturaCompetenciasTemp.Add(tempAsignaturaCompetencias);
            return RedirectToAction("Silabos", "Silabos", id);
        }

        public ActionResult CambiarFaseCompetencia(int id, int idAsignaturaCompetencia, int? idFase)
        {
            ICollection<AsignaturaCompetencias> asignaturaCompetenciasTemp = (ICollection<AsignaturaCompetencias>)Session["AsignaturasCompetencia"];
            asignaturaCompetenciasTemp.Where(ac => ac.Id.Equals(idAsignaturaCompetencia)).FirstOrDefault().IdSilaboFase = idFase;
            ViewBag.AsignaturasCompetencia = ViewBag.AsignaturasCompetencia;
            return RedirectToAction("Silabos", id);
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