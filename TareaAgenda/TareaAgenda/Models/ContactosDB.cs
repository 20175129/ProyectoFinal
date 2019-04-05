using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TareaAgenda.Models
{
    public class ContactosDB : DbContext
    {
        public DbSet<Agenda> Agenda { get; set; }
    }
}