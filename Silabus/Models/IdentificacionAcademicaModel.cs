using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class IdentificacionAcademicaModel
    {
        private string escuela;
        private string facultad;
        private int credito;
        private int horasSemanalesTeorica;
        private int horasSemanalesPracticaAula;
        private int horasSemanalesPracticaJefe;
        private int horasSemanalesPracticaVirtual;
        private int horasSemestralesTeorica;
        private int horasSemestralesPractica;
        private int horasSemestralesVirtuales;

        public IdentificacionAcademicaModel(string _facultad, string _escuela, int credito,  int _horasSemanalesTeorica, int _horasSemanalesPracticaAula, int _horasSemanalesPracticaJefe, int _horasSemanalesPracticaVirtual, int _horasSemestralesTeorica, int _horasSemestralesPractica, int _horasSemestralesVirtuales)
        {
            Escuela = _escuela;
            Facultad = _facultad;
            HorasSemanalesTeorica = _horasSemanalesTeorica;
            HorasSemanalesPracticaAula = _horasSemanalesPracticaAula;
            HorasSemanalesPracticaJefe = _horasSemanalesPracticaJefe;
            HorasSemanalesPracticaVirtual = _horasSemanalesPracticaVirtual;
            HorasSemestralesTeorica = _horasSemestralesTeorica;
            HorasSemestralesPractica = _horasSemestralesPractica;
            HorasSemestralesVirtuales = _horasSemestralesVirtuales;
        }

        public string Escuela { get => escuela; set => escuela = value; }
        public string Facultad { get => facultad; set => facultad = value; }
        public int HorasSemanalesPracticaAula { get => horasSemanalesPracticaAula; set => horasSemanalesPracticaAula = value; }
        public int HorasSemanalesPracticaJefe { get => horasSemanalesPracticaJefe; set => horasSemanalesPracticaJefe = value; }
        public int HorasSemanalesPracticaVirtual { get => horasSemanalesPracticaVirtual; set => horasSemanalesPracticaVirtual = value; }
        public int HorasSemestralesTeorica { get => horasSemestralesTeorica; set => horasSemestralesTeorica = value; }
        public int HorasSemestralesPractica { get => horasSemestralesPractica; set => horasSemestralesPractica = value; }
        public int HorasSemestralesVirtuales { get => horasSemestralesVirtuales; set => horasSemestralesVirtuales = value; }
        public int Credito { get => credito; set => credito = value; }
        public int HorasSemanalesTeorica { get => horasSemanalesTeorica; set => horasSemanalesTeorica = value; }
    }
}