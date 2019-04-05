using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaV.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }

        public string Evento { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }

    }
}