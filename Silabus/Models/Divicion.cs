using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Divicion
    {
        private String titulo;
        private int estado;
        private DateTime fechaModificacion;
        private String docente;

        public Divicion(string _titulo, int _estado, DateTime _fechaModificacion, String _docente)
        {
            titulo = _titulo;
            estado = _estado;
            fechaModificacion = _fechaModificacion;
            docente = _docente;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public string Docente { get => docente; set => docente = value; }
    }
}