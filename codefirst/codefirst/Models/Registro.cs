using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codefirst.Models
{
    public class Registro
    {
        public int id { get; set; }
        [Range(18,100)]
        public int edad { get; set; }
        public String nombre { get; set; }
        public String carrera { get; set; }
        public int cuatrimestre { get; set; }
    }
}