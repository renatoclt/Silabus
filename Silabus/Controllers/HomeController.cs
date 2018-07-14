using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult SilaboPrueba()
        {
            Divicion[] input = { new Divicion("IDENTIFICACIÓN ACADEMICA ", 0, DateTime.Today , null),
                                 new Divicion("SUMILLA",1, DateTime.Today, "nombre Docente"),
                                 new Divicion("COMPETENCIAS DE LA ASIGNATURA QUE APOYAN AL EPERFIL DE EGRESO ",0, DateTime.Today, "nombre Docente"),
                                 new Divicion("CONTENIDOS BASICOS POR UNIDADES DE APRENDIZAJE",0, DateTime.Today, "nombre Docente"),
                                 new Divicion("EVALUACION DE COMPETENCIAS ADQUIRIDAS",1, DateTime.Today, "nombre Docente"),
                                 new Divicion("BIBLIOGRAFIA",1, DateTime.Today, "nombre Docente"),};
            List<Divicion> diviciones = new List<Divicion>(input);
            ViewBag.Diviciones = diviciones;
            return View();
        }
    }
}