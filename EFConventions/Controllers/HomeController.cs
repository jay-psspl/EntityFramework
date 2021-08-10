using EFConventions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFConventions.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataContext db = new Models.DataContext();
            var data = db.employees.ToList();
            return View(data);
        }
    }
}