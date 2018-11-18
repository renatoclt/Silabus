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
            silabo = this.Unidad(silabo);
            silabo = this.Evaluacion(silabo);
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

        private Silabos Unidad(Silabos silabo)
        {
            if (Session["Unidades"] == null)
            {
                ICollection<SilaboFases> silaboFases = new HashSet<SilaboFases>();
                SilaboFases SilaboFase = new SilaboFases();
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
                    silabo.Asignaturas.Unidads.ToList().ForEach(unidad =>
                    {
                        if (silaboFaseUnidades.Where(sfu => sfu.Unidades.Equals(unidad)).FirstOrDefault() == null)
                        {
                            SilaboFaseUnidades silaboFaseUnidadesTem = new SilaboFaseUnidades
                            {
                                Unidades = unidad,
                            };
                            SilaboFase.SilaboFaseUnidades.Add(silaboFaseUnidadesTem);
                        }
                    });
                    silaboFases.Add(SilaboFase);
                }
                Session["Unidades"] = silaboFases.ToList();
                return silabo;
            }
            else
            {
                return UnidadEdit(silabo);
            }
            
            
        }
        private Silabos UnidadEdit(Silabos silabo)
        {
            List<SilaboFases> silaboFases = (List<SilaboFases>)Session["Unidades"];
            int nroUnidad = 0;
            int nroSubUnidad = 0;
            silaboFases.ForEach(silaboFase =>
            {
                if(silaboFase.SilaboFaseUnidades.Count > 0)
                {
                    nroUnidad++;
                    nroSubUnidad = 0;
                    silaboFase.SilaboFaseUnidades.ToList().ForEach(silaboFaseUnidad =>
                    {
                        silaboFaseUnidad.NroUnidad = silaboFaseUnidad.NroUnidad.Equals(Constantes.CERO) ? nroUnidad : silaboFaseUnidad.NroUnidad;
                        if (silaboFaseUnidad.NroSubUnidad.Equals(Constantes.CERO))
                        {
                            nroSubUnidad++;
                            silaboFaseUnidad.NroSubUnidad = nroSubUnidad;
                            silaboFaseUnidad.Fases = new SelectList(silabo.PlanFuncionamientos.Fases, "Id", "Nombre", silaboFaseUnidad.IdSilaboFase);
                        }
                    });
                }
            });
            silabo.SilaboFases = silaboFases;
            return silabo;
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
            this.LimpiarSession(idDivision);
            return RedirectToAction("Silabos", id);
        }
        
        public void LimpiarSession(int idDivision)
        {
            switch (idDivision)
            {
                case Constantes.IDCOMPETENCIAS:
                    {
                        Session["AsignaturasCompetencia"] = null;
                        break;
                    }
                case Constantes.IDUNIDADES:
                    {
                        Session["Unidades"] = null;
                        break;
                    }
                case Constantes.IDEVALUACION:
                    {
                        Session["Evaluacion"] = null;
                        break;
                    }
            }
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
            Session["Unidades"] = null;
            return RedirectToAction("Silabos", silabo.Id);
        }
        public ActionResult GuardarEvaluacion(Silabos silabo)
        {
            silabo = _repo.GuardarEvaluacion(silabo);
            _repo.EditarDivisionCancel(silabo.SilaboDivisiones.Where(sd => sd.Divisiones.Id.Equals(Constantes.IDEVALUACION)).FirstOrDefault().Divisiones.Id);
            Session["Evaluacion"] = null;
            silabo= this.Unidad(silabo);
            this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }

        [HttpPost]
        public ActionResult CambiarFaseEvaluacion(Silabos silaboTem)
        {
            Silabos silabo = _repo.GuardarSelectedSilaboFase(silaboTem.Id, silaboTem.SelectedSilaboFase);
            this.CompetenciaBag(silabo);
            silabo = this.Unidad(silabo);
            silabo = this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }

        public ActionResult CambiarFaseEvaluacionEdit(int id, int idFase)
        {
            Silabos silabo = _repo.GuardarSelectedSilaboFase(id, idFase);
            this.CompetenciaBag(silabo);
            silabo = this.Unidad(silabo);
            silabo = this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }

        public ActionResult UnidadUp(int id, int idSilaboFase, int idUnidad)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.UnidadEdit(silabo);
            int nroSubUnidadTem = silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroSubUnidad;
            int nroUnidadTem = silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroUnidad;
            nroSubUnidadTem--;
            silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroSubUnidad = nroSubUnidadTem;
            silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroUnidad = nroUnidadTem;
            this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }
        public ActionResult UnidadDown(int id, int idSilaboFase, int idUnidad)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.UnidadEdit(silabo);
            int nroSubUnidadTem = silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroSubUnidad;
            int nroUnidadTem = silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroUnidad;
            nroSubUnidadTem++;
            silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroSubUnidad = nroSubUnidadTem;
            silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault().NroUnidad = nroUnidadTem;
            this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }
        public ActionResult UnidadTrash(int id, int idSilaboFase, int idUnidad)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.UnidadEdit(silabo);
            silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Remove(
                silabo.SilaboFases.Where(sf => sf.Id.Equals(idSilaboFase)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(idUnidad)).FirstOrDefault());
            this.Evaluacion(silabo);
            return View("Silabos", silabo);
        }

        public ActionResult UnidadAdd(int id)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.UnidadEdit(silabo);
            if(silabo.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault() == null)
            {
                silabo.SilaboFases.Add(new SilaboFases());
            }
            silabo.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault().SilaboFaseUnidades.Add(new SilaboFaseUnidades()
            {
                Unidades = new Unidades()
            });
            return View("Silabos", silabo);
        }

        public ActionResult EstrategiaAdd(int id )
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.Evaluacion(silabo);
            if (silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO))== null)
            {
                silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.Add(new SilaboFasesSaberes
                {
                    Id = Constantes.CERO
                });
            }
            silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO)).SilaboEstrategias.Add(new SilaboEstrategias());
            return View("Silabos", silabo);
        }

        public ActionResult EvidenciaAdd(int id)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.Evaluacion(silabo);
            if (silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO)) == null)
            {
                silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.Add(new SilaboFasesSaberes
                {
                    Id = Constantes.CERO
                });
            }
            silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO)).SilaboEvidencias.Add(new SilaboEvidencias());
            return View("Silabos", silabo);
        }

        public ActionResult CriterioAdd(int id)
        {
            Silabos silabo = _repo.ObtenerSilabo(id);
            silabo = this.Evaluacion(silabo);
            if (silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO)) == null)
            {
                silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.Add(new SilaboFasesSaberes
                {
                    Id = Constantes.CERO
                });
            }
            silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silabo.SelectedSilaboFase)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(Constantes.CERO)).SilaboCriterios.Add(new SilaboCriterios());
            return View("Silabos", silabo);
        }

        private Silabos Evaluacion(Silabos silabos)
        {
            if(Session["Evaluacion"] == null)
            {
                Session["Evaluacion"] = silabos.SilaboFases;
            }
            else
            {
                silabos.SilaboFases = (ICollection<SilaboFases>)Session["Evaluacion"];
            }
            ViewBag.Evidencias = new SelectList(_repo.ListarEvidencias(), "Id", "Nombre");
            ViewBag.Estrategias = new SelectList(_repo.ListarEstrategias(), "Id", "Nombre"); 
            ViewBag.Criterios = new SelectList(_repo.ListarCriterios(), "Id", "Nombre"); 
            ViewBag.Saberes = new SelectList(_repo.ListarSaberes(), "Id", "Nombre");
            return silabos;
        }

    }
}