//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class datos
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        [Range(18, 100)]
        public Nullable<int> Edad { get; set; }

        public string Carrera { get; set; }

        public Nullable<int> Cuatrimestre { get; set; }
    }
}
