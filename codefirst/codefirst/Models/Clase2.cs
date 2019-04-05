using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace codefirst.Models
{
    public class Clase2 : DbContext
    {
        public DbSet<Registro> data { get; set; }


        public Clase2()
         : base("Conexion")
        {
        }       

    }
}