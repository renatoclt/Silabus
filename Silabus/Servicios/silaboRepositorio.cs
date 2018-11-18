using Silabus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Silabus.utils;

namespace Silabus.Servicios
{
    public class SilaboRepositorio
    {
        private int estadoActivo;
        public SilaboRepositorio()
        {
            this.estadoActivo = 1;
        }

        internal Silabos ObtenerSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.Where(s => s.Id.Equals(id))
                    .Include(s => s.Asignaturas.AsignaturaCompetencias.Select(ac => ac.Competencia))
                    .Include(s => s.SilaboDivisiones.Select(sd => sd.Divisiones))
                    .Include(s => s.PlanFuncionamientos.Fases)
                    .Include(s => s.Asignaturas.PlanEstudios.Escuelas.Facultads)
                    .Include(s => s.Asignaturas.Departamentos)
                    .Include(s => s.Asignaturas.Unidads.Select(u => u.SilaboFaseUnidades))
                    .Include(s => s.SilaboDocentes.Select(sd => sd.Docentes.TipoDocentes))
                    .Include(s => s.SilaboFases.Select(sf => sf.Fases))
                    .Include(s => s.SilaboFases.Select(sf => sf.AsignaturaCompetencias.Select(ac => ac.Competencia)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.Saberes)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFaseUnidades.Select(sfu => sfu.Unidades)))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboCriterios.Select(se => se.Criterios))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEvidencias.Select(se => se.Evidencias))))
                    .Include(s => s.SilaboFases.Select(sf => sf.SilaboFasesSaberes.Select(sfs => sfs.SilaboEstrategias.Select(se => se.Estrategia))));
                return this.RegistrosHabilitados(silabo.FirstOrDefault());
            }

        }

        private Silabos RegistrosHabilitados(Silabos silabos)
        {
            silabos.Asignaturas.AsignaturaCompetencias = silabos.Asignaturas.AsignaturaCompetencias.Where(ac => ac.Estado.Equals(Constantes.ESTADOHABILITADO)).ToList();
            return silabos;
        }

        public List<Fases> ObtenerFases()
        {
            using (var db = new SilaboContext())
            {
                var fases = db.Fases.Where(f => f.Estado == this.estadoActivo);
                return fases.ToList();
            }
        }

        public List<Unidades> ObtenerUnidades(int id)
        {
            using (var db = new SilaboContext())
            {
                var unidades = db.Unidades.Where(u => u.Estado == this.estadoActivo).Where(u => u.IdAsignatura == id);
                return unidades.ToList();
            }
        }
        public List<Saberes> ObtenerSaberes()
        {
            using (var db = new SilaboContext())
            {
                var saberes = db.Saberes.Where(s => s.Estado == this.estadoActivo);
                return saberes.ToList();
            }
        }

        public Divisiones GetDivision(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Divisiones.Where(d => d.Id == id).FirstOrDefault();

            }
        }

        public Silabos GetSilabo(int id)
        {
            using (var db = new SilaboContext())
            {
                return db.Silabos.Where(s => s.Id == id).FirstOrDefault();

            }
        }

        internal void EditarDivisionCancel(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                Divisiones.Estado = 1;
                db.SaveChanges();
            }
        }

        internal Silabos GuardarUnidades(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    if (silaboSave.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault() != null)
                    {
                        silaboSave.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault().SilaboFaseUnidades.ToList().ForEach(sfu =>
                       {
                           if (silabo.Asignaturas.Unidads.Where(u => u.Id.Equals(sfu.Unidades.Id)).FirstOrDefault() == null)
                           {
                               silabo.Asignaturas.Unidads.Add(new Unidades
                               {
                                   Nombre = sfu.Unidades.Nombre,
                                   IdAsignatura = silabo.Asignaturas.Id,
                                   UsuarioCreacion = "prueba",
                                   FechaCreacion = DateTime.Now,
                                   Estado = Constantes.ESTADOHABILITADO
                               });
                           }
                       });
                        if (silaboSave.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault().SilaboFaseUnidades
                            .Where(sfu => sfu.IdSilaboFase != Constantes.CERO).ToList().Count.Equals(Constantes.CERO))
                        {
                            silaboSave.SilaboFases.Remove(silaboSave.SilaboFases.Where(sf => sf.Id.Equals(Constantes.CERO)).FirstOrDefault());
                        }
                    }
                    silaboSave.SilaboFases.ToList().ForEach(sft =>
                    {
                        sft.SilaboFaseUnidades.ToList().ForEach(sfut =>
                        {
                            if (sfut.Id.Equals(Constantes.CERO))
                            {
                                if (sft.Id.Equals(Constantes.CERO))
                                {
                                    sft.Id = sfut.IdSilaboFase;
                                }
                                silabo.SilaboFases.Where(sf => sf.Id.Equals(sft.Id)).FirstOrDefault().SilaboFaseUnidades.Add(new SilaboFaseUnidades
                                {
                                    NroUnidad = sfut.NroUnidad,
                                    NroSubUnidad = sfut.NroSubUnidad,
                                    IdSilaboUnidad = sfut.Unidades.Id,
                                    IdSilaboFase = sfut.IdSilaboFase,
                                    UsuarioCreacion = "prueba",
                                    FechaCreacion = DateTime.Now,
                                    Estado = Constantes.ESTADOHABILITADO
                                });
                            }
                            else
                            {
                                if (!sft.Id.Equals(Constantes.CERO))
                                {
                                    SilaboFaseUnidades silaboFaseUnidades = silabo.SilaboFases.Where(sf => sf.Id.Equals(sft.Id)).FirstOrDefault().SilaboFaseUnidades.Where(sfu => sfu.Id.Equals(sfut.Id)).FirstOrDefault();
                                    silaboFaseUnidades.NroUnidad = sfut.NroUnidad;
                                    silaboFaseUnidades.NroSubUnidad = sfut.NroSubUnidad;
                                    silaboFaseUnidades.IdSilaboFase = sfut.IdSilaboFase;
                                    silaboFaseUnidades.Unidades.Nombre = sfut.Unidades.Nombre;
                                }
                            }
                        });
                    });
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarCompetencias(Silabos silaboSave, ICollection<AsignaturaCompetencias> asignaturaCompetencias)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    asignaturaCompetencias.ToList().ForEach(asiCom =>
                    {
                        if (asiCom.Id.Equals(0))
                        {

                            Fases fase = silabo.PlanFuncionamientos.Fases.Where(f => f.Id.Equals(asiCom.IdSilaboFase)).FirstOrDefault();
                            AsignaturaCompetencias asignaturaCompetencia = silabo.Asignaturas.AsignaturaCompetencias
                            .Where(ac => ac.IdAsignatura.Equals(asiCom.IdAsignatura) &&
                                   ac.IdCompetencia.Equals(asiCom.IdCompetencia) &&
                                   ac.IdSilaboFase.Equals(fase.Id) &&
                                   ac.Estado.Equals(Constantes.ESTADOHABILITADO)).FirstOrDefault();
                            if (asignaturaCompetencia == null)
                            {
                                asignaturaCompetencia = silabo.Asignaturas.AsignaturaCompetencias
                                .Where(ac => ac.IdAsignatura.Equals(asiCom.IdAsignatura) &&
                                   ac.IdCompetencia.Equals(asiCom.IdCompetencia) &&
                                   ac.IdSilaboFase.Equals(null) &&
                                   ac.Estado.Equals(Constantes.ESTADOHABILITADO)).FirstOrDefault();
                                if (asignaturaCompetencia != null)
                                {
                                    asignaturaCompetencia.IdSilaboFase = asiCom.IdSilaboFase;
                                }
                                else
                                {
                                    asignaturaCompetencia = new AsignaturaCompetencias
                                    {
                                        IdAsignatura = asiCom.IdAsignatura,
                                        IdSilaboFase = silabo.SilaboFases.Where(sf => sf.Fases.Id.Equals(asiCom.IdSilaboFase)).FirstOrDefault().IdFases,
                                        IdCompetencia = asiCom.IdCompetencia,
                                        UsuarioCreacion = "prueba",
                                        FechaCreacion = DateTime.Now,
                                        Estado = 1
                                    };
                                    silabo.Asignaturas.AsignaturaCompetencias.Add(asignaturaCompetencia);
                                }
                            }
                        }
                        else
                        {
                            AsignaturaCompetencias asignaturaCompetencia = silabo.Asignaturas.AsignaturaCompetencias.Where(ac => ac.Id.Equals(asiCom.Id)).FirstOrDefault();
                            if (asignaturaCompetencia.IdAsignatura != asiCom.IdAsignatura ||
                                asignaturaCompetencia.IdCompetencia != asiCom.IdCompetencia ||
                                asignaturaCompetencia.IdSilaboFase != asiCom.IdSilaboFase)
                            {
                                if (asiCom.IdSilaboFase == null)
                                {
                                    int count = silabo.Asignaturas.AsignaturaCompetencias
                                    .Where(ac => ac.IdAsignatura.Equals(asiCom.IdAsignatura) &&
                                       ac.IdCompetencia.Equals(asiCom.IdCompetencia) &&
                                       ac.IdSilaboFase.Equals(null) &&
                                       ac.Estado.Equals(Constantes.ESTADOHABILITADO)).ToList().Count;
                                    if (count > 1)
                                        silabo.Asignaturas.AsignaturaCompetencias.Where(ac => ac.Id.Equals(asiCom.Id)).FirstOrDefault().Estado = Constantes.ESTADODESHABILITADO;
                                    else
                                        silabo.Asignaturas.AsignaturaCompetencias.Where(ac => ac.Id.Equals(asiCom.Id)).FirstOrDefault().IdSilaboFase = null;
                                }
                                else
                                {
                                    asignaturaCompetencia.IdAsignatura = asiCom.IdAsignatura;
                                    asignaturaCompetencia.IdCompetencia = asiCom.IdCompetencia;
                                    asignaturaCompetencia.IdSilaboFase = asiCom.IdSilaboFase;
                                }
                            }
                        }

                    });
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarEvaluacion(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    silaboSave.SilaboFases.ToList().ForEach(silaboFase =>
                    {
                        if (silaboFase.Id != Constantes.CERO)
                        {
                            silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silaboFase.Id)).Titulo = silaboFase.Titulo;
                            silaboFase.SilaboFasesSaberes.ToList().ForEach(silaboFaseSaber =>
                            {
                                if (silaboFaseSaber.Id != Constantes.CERO)
                                    silabo.SilaboFases.FirstOrDefault(sf => sf.Id.Equals(silaboFase.Id)).SilaboFasesSaberes.FirstOrDefault(sfs => sfs.Id.Equals(silaboFaseSaber.Id)).Descripcion = silaboFaseSaber.Descripcion;
                            });

                        }
                    });
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal Silabos GuardarSumilla(Silabos silaboSave)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == silaboSave.Id);
                if (silabo != null)
                {
                    silabo.Sumilla = silaboSave.Sumilla;
                    db.SaveChanges();
                }
                return ObtenerSilabo(silabo.Id);
            }
        }

        internal void EditarDivision(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                Divisiones.Estado = 3;
                db.SaveChanges();
            }
        }

        internal void EditarDivisionOk(int id)
        {
            using (var db = new SilaboContext())
            {
                Divisiones Divisiones = db.Divisiones.Find(id);
                if (Divisiones != null)
                    Divisiones.Estado = 1;
                db.SaveChanges();
            }
        }

        internal void AgregarCompetenciasAsignatura(int id, int idAsignatura, int idFase, int idCompetencia)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id == id);
                if (silabo != null)
                {

                }
            }
        }

        internal Silabos GuardarSelectedSilaboFase(int id, int? idSelectedSilaboFase)
        {
            using (var db = new SilaboContext())
            {
                var silabo = db.Silabos.SingleOrDefault(s => s.Id.Equals(id));
                if (silabo != null)
                {
                    silabo.SelectedSilaboFase = idSelectedSilaboFase;
                    db.SaveChanges();
                }
                return this.ObtenerSilabo(id);
            }
        }

        internal List<Evidencias> ListarEvidencias()
        {
            using (var db = new SilaboContext())
            {
                var evidencias = db.Evidencias.Where(e => e.Estado.Equals(Constantes.ESTADOHABILITADO));
                return evidencias.ToList();
            }
        }

        internal List<Criterios> ListarCriterios()
        {
            using (var db = new SilaboContext())
            {
                var criterios = db.Criterios.Where(e => e.Estado.Equals(Constantes.ESTADOHABILITADO));
                return criterios.ToList();
            }
        }

        internal List<Estrategias> ListarEstrategias()
        {
            using (var db = new SilaboContext())
            {
                var estrategias = db.Estrategias.Where(e => e.Estado.Equals(Constantes.ESTADOHABILITADO));
                return estrategias.ToList();
            }
        }

        internal List<Saberes> ListarSaberes()
        {
            using (var db = new SilaboContext())
            {
                var saberes = db.Saberes.Where(e => e.Estado.Equals(Constantes.ESTADOHABILITADO));
                return saberes.ToList();
            }
        }

    }
}