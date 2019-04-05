using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Agenda.Models
{
    public class AgendaDB : DbContext
    {
        public DbSet<Contactos> Agenda { get; set; }
    }
}