using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Silabus.Models
{
    public class Parametricas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CodigoControl { get; set; } //--Código que se asgina al contro. Ejm: 1

        [Required]
        [MaxLength(50)]
        public string DescripcionControl { get; set; } //-- Descripción del control utilizado. Ejm: "ComboBox"

        [Required]
        [MaxLength(50)]
        public string Informacion { get; set; } //-- Información guardada. Ejm: "Año - Semestre"

        [Required]
        public int valor { get; set; } //-- Valor  . Ejm: "1"

        [Required]
        [MaxLength(50)]
        public string texto { get; set; } //-- Texto a mostrar . Ejm: "2018 - I"

        public int? Auxiliar01 { get; set; } //-- Valor auxiliar de tipo Int

        public int? Auxiliar02 { get; set; } //-- Valor auxilira de tipo Int

    }
}