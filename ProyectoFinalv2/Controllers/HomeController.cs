﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalv2.Models;
namespace ProyectoFinalv2.Controllers
{
    public class HomeController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       
    }
}