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
            //Divisiones[] input = { new Divisiones("IDENTIFICACIÓN ACADEMICA ", 0, DateTime.Today , null),
            //                     new Divisiones("SUMILLA",1, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("COMPETENCIAS DE LA ASIGNATURA QUE APOYAN AL EPERFIL DE EGRESO ",0, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("CONTENIDOS BASICOS POR UNIDADES DE APRENDIZAJE",0, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("EVALUACION DE COMPETENCIAS ADQUIRIDAS",1, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("Bibliografias",1, DateTime.Today, "nombre Docentes"),};
            //List<Divisiones> Divisiones = new List<Divisiones>(input);
            //ViewBag.Divisiones = Divisiones;
            return View();
        }
    }
}