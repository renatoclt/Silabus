using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silabus.Services
{
    enum VariablesGlobales
    {
        CodControl_AnioSemestre = 1,
        estadoHabilitado = 1,
        tipoDocente = 3,

    }
    public static class VariablesGlobalesString
    {
        public const string Modo_Habilitar = "HAB";
        public const string Modo_Visualizar = "VIS";
    }
    public class VisualizarSilabo
    {
        public int idSilabo;
        public string escuelaProfesional;
        public int codigoEscuela;
        public int codigoDocente;
        public string nombreDocente;
        public int codigoCurso;
        public string nombreCurso;
        public int semestre;
        public string anioSemestre;
        public int codigoEstado;
        public string estado;
        public List<SelectListItem> ListaAnioSemestre { get; set; }
        public List<SelectListItem> ListaEstado { get; set; }

        public List<VisualizarSilabo> ObtenerInformacion(string escuelaProfesional,
                                                   string codigoDocente,
                                                   string nombreDocente,
                                                   string nombreCurso,
                                                   string añoSemestre,
                                                   string Modo)
        {

            using (var db = new SilaboContext())
            {

                int año = DateTime.Now.Year;
                int semes = Int32.Parse(añoSemestre);
                var semestre = from se in db.Parametricas
                               where se.CodigoControl == (int)VariablesGlobales.CodControl_AnioSemestre && se.valor == semes && se.Auxiliar01 == año
                               select se.Auxiliar02.Value;
                semes = Int32.Parse(semestre.First().ToString()); // se debe obtener mas adelante la dstinción de si es semestre par o impoar

                var model = from sildoc in db.SilaboDocentes
                            join docente in db.Docentes on sildoc.IdDocente equals docente.Id
                            join silabus in db.Silabos on sildoc.IdSilabo equals silabus.Id
                            join curso in db.Asignaturas on silabus.IdAsignatura equals curso.Id
                            join planEst in db.PlanEstudios on curso.IdPlanEstudio equals planEst.Id
                            join escuela in db.Escuelas on planEst.IdEscuela equals escuela.Id
                            join estado in db.Estados on silabus.IdEstado equals estado.Id
                            where docente.Estado == (int)VariablesGlobales.estadoHabilitado && docente.IdTipoDocentes == (int)VariablesGlobales.tipoDocente && (codigoDocente == "" || docente.Codigo.Contains(codigoDocente.ToUpper())) &&
                                  (docente.Nombres + " " + docente.ApellidoPaterno + " " + docente.ApellidoMaterno).ToUpper().Contains(nombreDocente.ToUpper()) &&
                                  silabus.EstadoAuditoria == (int)VariablesGlobales.estadoHabilitado &&
                                  curso.Estado == (int)VariablesGlobales.estadoHabilitado && (nombreCurso == "" || curso.Nombre.Contains(nombreCurso.ToUpper())) && (semes == 0 || curso.Semestre.Equals(semes)) &&
                                  planEst.Estado == (int)VariablesGlobales.estadoHabilitado &&
                                  escuela.Estado == (int)VariablesGlobales.estadoHabilitado && (escuelaProfesional == "" || escuela.Nombre.Contains(escuelaProfesional.ToUpper())) &&
                                  estado.estado == (int)VariablesGlobales.estadoHabilitado
                            select new VisualizarSilabo
                            {
                                codigoEscuela = escuela.Id,
                                escuelaProfesional = escuela.Nombre,
                                codigoCurso = curso.Id,
                                nombreCurso = curso.Nombre,
                                codigoDocente = docente.Id,
                                nombreDocente = docente.Nombres + " " + docente.ApellidoPaterno + " " + docente.ApellidoMaterno,
                                semestre = curso.Semestre,
                                idSilabo = silabus.Id,
                                codigoEstado = estado.Id,
                                estado = estado.Descripcion,
                            };

                List<VisualizarSilabo> visualizarSilabos = new List<VisualizarSilabo>();
                visualizarSilabos = model.ToList();

                for (int i = 0; i < model.Count(); i++)
                {
                    visualizarSilabos.ToArray()[i].anioSemestre = ConversionSemestre(model.ToArray()[i].semestre);
                    if (Modo == VariablesGlobalesString.Modo_Habilitar)
                    {
                        visualizarSilabos.ToArray()[i].ListaEstado = ListarEstado(visualizarSilabos.ToArray()[i].codigoEstado);
                    }

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

        public List<SelectListItem> ListarEstado(int codigoEstado)
        {
            using (var db = new SilaboContext())
            {

                List<SelectListItem> ListaEstados = new List<SelectListItem>();
                var Estados = from estado in db.Estados
                              where estado.estado == (int)VariablesGlobales.estadoHabilitado
                              select estado;

                foreach (var estado in Estados)
                {
                    if (codigoEstado == estado.Id)
                    {
                        ListaEstados.Add(new SelectListItem()
                        {
                            Value = estado.Id.ToString(),
                            Text = estado.Descripcion,
                            Selected = true
                        });
                    }
                    else
                    {
                        ListaEstados.Add(new SelectListItem()
                        {
                            Value = estado.Id.ToString(),
                            Text = estado.Descripcion,
                            Selected = false
                        });
                    }
                }
                return ListaEstados;
            }
        }
        public int ActualizarEstado(int idSilabo, int codigoEstado)
        {
            int exitoso = 0;
            using (var db = new SilaboContext())
            {
                var model = from silabus in db.Silabos
                            where silabus.Id.Equals(idSilabo)
                            select silabus;


                foreach (var silabo in model)
                {
                    silabo.IdEstado = codigoEstado;
                }
                return exitoso = db.SaveChanges();

            }

        }
    }
}