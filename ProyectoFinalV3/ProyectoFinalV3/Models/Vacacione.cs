//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalV3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacacione
    {
        public int Vacaciones_ID { get; set; }
        public int Empleado { get; set; }
        public System.DateTime Desde { get; set; }
        public System.DateTime Hasta { get; set; }
        public System.DateTime Correspondiente_A { get; set; }
        public string Comentarios { get; set; }
    
        public virtual Empleado Empleado1 { get; set; }
    }
}
