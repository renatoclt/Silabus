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
        // GET: Silabo
        public ActionResult Silabo()
        {
            //Divicion[] input = { new Divicion("IDENTIFICACIÓN ACADEMICA ", 0, DateTime.Today , null),
            //                     new Divicion("SUMILLA",1, DateTime.Today, "nombre Docente"),
            //                     new Divicion("COMPETENCIAS DE LA ASIGNATURA QUE APOYAN AL EPERFIL DE EGRESO ",0, DateTime.Today, "nombre Docente"),
            //                     new Divicion("CONTENIDOS BASICOS POR UNIDADES DE APRENDIZAJE",0, DateTime.Today, "nombre Docente"),
            //                     new Divicion("EVALUACION DE COMPETENCIAS ADQUIRIDAS",1, DateTime.Today, "nombre Docente"),
            //                     new Divicion("BIBLIOGRAFIA",1, DateTime.Today, "nombre Docente"),};
            //List<Divicion> diviciones = new List<Divicion>(input);
            //return View(diviciones);
            return null;
        }


        public ActionResult IdentificacionAcademica()
        {
            IdentificacionAcademicaModel identificacionAcademica = new IdentificacionAcademicaModel("CIENCIAS E INGENIERIAS FISICAS Y FORMALES", "INGENIERIA INDUSTRIAL",4,2,2,2,0,36,72,0);
            ViewBag.IdentificacionAcademica = identificacionAcademica;
            return View();
        }

        public ActionResult Sumilla()
        {
            Sumilla sumilla = new Sumilla("texto de la sumilla", 0);
            ViewBag.Sumilla = sumilla;
            return View();
        }

        public ActionResult Competencia()
        {
            //List<Fase> fases = new List<Fase>();
            //fases.Add(new Fase(1, "Fase I"));
            //fases.Add(new Fase(2, "Fase II"));
            //fases.Add(new Fase(3, "Fase III"));
            //fases.Add(new Fase(0, "Ninguna"));
            //ViewBag.Fases = fases;
            //List<CompetenciaCurso> competencias = new List<CompetenciaCurso>();
            //competencias.Add(new CompetenciaCurso(1, "competencia 1", 1));
            //competencias.Add(new CompetenciaCurso(2, "competencia 2", 2));
            ////Competencia competencia = new Competencia(0, competencias );

            //ViewBag.Competencia = competencia;
            return View();
        }
        public ActionResult Unidad(int accion = 0, Unidad unidadTem = null)
        {
            List<UnidadCurso> unidadesCurso = new List<UnidadCurso>();
            unidadesCurso.Add(new UnidadCurso(1, 0, "Estudio del Trabajo "));
            unidadesCurso.Add(new UnidadCurso(3, 1, "Estudio del Trabajo 1 "));
            unidadesCurso.Add(new UnidadCurso(1, 2, "Estudio del Trabajo 2 "));
            unidadesCurso.Add(new UnidadCurso(2, 0, "Estudio del Trabajo "));
            unidadesCurso.Add(new UnidadCurso(2, 3, "Estudio del Trabajo 3"));
            unidadesCurso.Add(new UnidadCurso(2, 2, "Estudio del Trabajo 4"));
            Unidad unidades = new Unidad(0, unidadesCurso);
            if (accion == 1)
            {
                unidades.SortList(unidadTem);
            }
            ViewBag.Unidad = unidades;
            return View();
        }
        public ActionResult Bibliografia(int accion = 0, Unidad unidadTem = null)
        {
            List<Libros> libros = new List<Libros>();
            libros.Add(new Libros("Pepito", "libro algebra", "planeta", "2018", "Peru"));
            Bibliografia bibliografia = new Bibliografia(0, libros);
            ViewBag.Bibliografia = bibliografia;
            return View();
        }
    }
}
