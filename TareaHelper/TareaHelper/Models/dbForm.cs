using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TareaHelper.Models
{
    public class dbForm : DbContext
    {
        public DbSet<Class1> Class1 { get; set; }
    }
}