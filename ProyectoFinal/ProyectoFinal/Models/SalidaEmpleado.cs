//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalidaEmpleado
    {
        public int IdSalida { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoSalida { get; set; }
        public string Motivo { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
    
        public virtual MantenimientoEmpleado MantenimientoEmpleado { get; set; }
    }
}