using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Services
{
    public class VisualizarSilabo
    {
        public string escuelaProfesional;
        //public int codigoDocente;
        public string nombreDocente;
        public string nombreCurso;
        public int semestre;
        public string anioSemestre;
        public string estado;
        public List<SelectListItem> ListaAnioSemestre { get; set; }

        public List<VisualizarSilabo> ObtenerInformacion(string escuelaProfesional,
                                                   string codigoDocente,
                                                   string nombreDocente,
                                                   string nombreCurso,
                                                   string añoSemestre)
        {
            
            using (var db = new SilaboContext())
            {
                int CodControl = 1;
                int año = DateTime.Now.Year;
                int semes = Int32.Parse(añoSemestre);
                var semestre = from se in db.Parametricas
                               where se.CodigoControl == CodControl && se.valor == semes  && se.Auxiliar01 == año 
                               select se.Auxiliar02.Value;
                semes = Int32.Parse(semestre.First().ToString());

                int estadoHabilitado = 1;
                int tipoDocente = 3;
                var model = from sildoc in db.SilabusDocente
                            join docente in db.Docente on sildoc.IdDocente equals docente.Id
                            join silabus in db.Silabus on sildoc.IdSilabus equals silabus.Id
                            join curso in db.Asignaturas on silabus.IdAsignaturas equals curso.Id
                            join planEst in db.PlanEstudio on curso.IdPlanEstudio equals planEst.Id
                            join escuela in db.Escuela on planEst.IdEscuela equals escuela.Id
                            join estado in db.Estado on silabus.IdEstado equals estado.Id
                            where docente.estado == estadoHabilitado && docente.IdTipoDocente == tipoDocente && (codigoDocente==""  || docente.codigo.Contains(codigoDocente.ToUpper())) &&
                                  (docente.Nombres + " " + docente.apellidoPaterno + " " + docente.apellidoMaterno).ToUpper().Contains(nombreDocente.ToUpper()) &&
                                  //silabus.estado == estadoHabilitado && 
                                  curso.estado == estadoHabilitado && (nombreCurso == "" || curso.Nombres.Contains(nombreCurso.ToUpper())) && (semes == 0 || curso.semestre.Equals(semes)) &&
                                  planEst.estado == estadoHabilitado &&
                                  escuela.estado == estadoHabilitado && (escuelaProfesional == "" || escuela.nombre.Contains(escuelaProfesional.ToUpper())) &&
                                  estado.estado == estadoHabilitado
                            select new VisualizarSilabo
                            {
                                escuelaProfesional = escuela.nombre,
                                nombreCurso = curso.Nombres,
                                nombreDocente = docente.Nombres + " " + docente.apellidoPaterno + " " + docente.apellidoMaterno,
                                semestre = curso.semestre,
                                estado = estado.descripcion,
     

                            };

                List<VisualizarSilabo> visualizarSilabos = new List<VisualizarSilabo>();
                visualizarSilabos = model.ToList();

                for (int i = 0; i < model.Count(); i++)
                {
                    visualizarSilabos.ToArray()[i].anioSemestre = ConversionSemestre(model.ToArray()[i].semestre);
                }

                return visualizarSilabos.ToList();
            }
        }
        public string ConversionSemestre(int semestre)
        {
            string Semestre = "";
            switch (semestre)
            {
                case 1:
                    Semestre = "I";
                    break;
                case 2:
                    Semestre = "II";
                    break;
                case 3:
                    Semestre = "III";
                    break;
                case 4:
                    Semestre = "IV";
                    break;
                case 5:
                    Semestre = "V";
                    break;
                case 6:
                    Semestre = "VI";
                    break;
                case 7:
                    Semestre = "VII";
                    break;
                case 8:
                    Semestre = "VIII";
                    break;
                case 9:
                    Semestre = "IX";
                    break;
                case 10:
                    Semestre = "X";
                    break;
                case 11:
                    Semestre = "XI";
                    break;
                case 12:
                    Semestre = "XII";
                    break;
                case 13:
                    Semestre = "XIII";
                    break;

            }
            return Semestre;
        }

        public List<SelectListItem> ListarAnioSemestre(int anio)
        {
            int CodControl = 1;
            using (var db = new SilaboContext())
            {

                ListaAnioSemestre = new List<SelectListItem>();
                var Valores = from lista in db.Parametricas
                              where lista.Auxiliar01 == anio && lista.CodigoControl == CodControl
                              select lista;

                foreach (var item in Valores)
                {
                    ListaAnioSemestre.Add(new SelectListItem()
                    {
                        Value = item.valor.ToString(),
                        Text = item.texto
                    });
                }
                return ListaAnioSemestre;
            }
        }

        
    }
}