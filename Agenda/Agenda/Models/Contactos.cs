using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public class Contactos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public string Evento { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
    }
}