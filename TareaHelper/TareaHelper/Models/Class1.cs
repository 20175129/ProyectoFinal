using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TareaHelper.Models
{
    public class Class1
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor inserte una cedula")]
        public int Cedula { get; set; }
        [Required(ErrorMessage = "Por favor inserte su nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor inserte su Apellido")]
        public string Apellido { get; set; }
        [Range(15, 100, ErrorMessage = "Tiene que ser mayor de 15")]
        public int Edad { get; set; }
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

    }
    public enum Genero
    {
        Masculino,
        Femenino
    }
}