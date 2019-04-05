using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reto1.Models
{
    public class UsuarioModel
    {
        [Display(Name = "Usuario ID")]
        [Range(1000,9999,ErrorMessage = "Necesitas insertar un ID Valido.")]
        public  int UsuarioId { get; set; }


        [Display(Name = "Nombre de Usuario")]
        [Required (ErrorMessage = "Necesitas insertar tu usuario!")]
        public string UsuarioNombre { get; set; }

        [Display(Name = "Nombre")]
        [Required (ErrorMessage = "Necesitas insertar tu Nombre!")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required (ErrorMessage = "Necesitas insertar tu Apellido!")]
        public string Apellido { get; set; }

        [Display (Name = "Contrasena")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Necesitas insertar tu contrasena")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Tu contrasena debe de ser mas de 8 caracteres.")]
        public string Contrasena { get; set; }

        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage ="La constrasena insertada no son iguales!")]
        public string ConfirmarContra { get; set; }

        [Required(ErrorMessage = "Necesitas insertar tu edad")]
        public int edad { get; set; }
        
        
       
       

    }
}