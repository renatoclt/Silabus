using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Silabus.Controllers
{
    public class SilaboController : Controller
    {
        // GET: Silabos
        public ActionResult Silabos()
        {
            //Divisiones[] input = { new Divisiones("IDENTIFICACIÓN ACADEMICA ", 0, DateTime.Today , null),
            //                     new Divisiones("SUMILLA",1, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("COMPETENCIAS DE LA ASIGNATURA QUE APOYAN AL EPERFIL DE EGRESO ",0, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("CONTENIDOS BASICOS POR UNIDADES DE APRENDIZAJE",0, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("EVALUACION DE COMPETENCIAS ADQUIRIDAS",1, DateTime.Today, "nombre Docentes"),
            //                     new Divisiones("Bibliografias",1, DateTime.Today, "nombre Docentes"),};
            //List<Divisiones> Divisiones = new List<Divisiones>(input);
            //return View(Divisiones);
            return null;
        }


        public ActionResult Competencia()
        {
            //List<Fases> fases = new List<Fases>();
            //fases.Add(new Fases(1, "Fases I"));
            //fases.Add(new Fases(2, "Fases II"));
            //fases.Add(new Fases(3, "Fases III"));
            //fases.Add(new Fases(0, "Ninguna"));
            //ViewBag.Fases = fases;
            //List<CompetenciaCurso> competencias = new List<CompetenciaCurso>();
            //competencias.Add(new CompetenciaCurso(1, "competencia 1", 1));
            //competencias.Add(new CompetenciaCurso(2, "competencia 2", 2));
            ////Competencia competencia = new Competencia(0, competencias );

            //ViewBag.Competencia = competencia;
            return View();
        }
        public ActionResult Unidades(int accion = 0, Unidades unidadTem = null)
        {
            //List<UnidadCurso> unidadesCurso = new List<UnidadCurso>();
            //unidadesCurso.Add(new UnidadCurso(1, 0, "Estudio del Trabajo "));
            //unidadesCurso.Add(new UnidadCurso(3, 1, "Estudio del Trabajo 1 "));
            //unidadesCurso.Add(new UnidadCurso(1, 2, "Estudio del Trabajo 2 "));
            //unidadesCurso.Add(new UnidadCurso(2, 0, "Estudio del Trabajo "));
            //unidadesCurso.Add(new UnidadCurso(2, 3, "Estudio del Trabajo 3"));
            //unidadesCurso.Add(new UnidadCurso(2, 2, "Estudio del Trabajo 4"));
            //Unidades unidades = new Unidades(0, unidadesCurso);
            //if (accion == 1)
            //{
            //    unidades.SortList(unidadTem);
            //}
            //ViewBag.Unidades = unidades;
            return View();
        }
        public ActionResult Bibliografias(int accion = 0, Unidades unidadTem = null)
        {
            List<Libros> libros = new List<Libros>();
            libros.Add(new Libros("Pepito", "libro algebra", "planeta", "2018", "Peru"));
            Bibliografiass Bibliografias = new Bibliografiass(0, libros);
            ViewBag.Bibliografias = Bibliografias;
            return View();
        }
    }
}
