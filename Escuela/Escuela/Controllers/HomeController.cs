using Escuela.Entidades;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICourse icourse;

        public HomeController(ILogger<HomeController> logger, ICourse icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(Course c)
        {
            Course course = new Course();
            course.Title = c.Title;
            course.Credits = c.Credits;
            icourse.Insertar(course);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
