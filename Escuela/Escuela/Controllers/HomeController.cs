using Escuela.Entidades;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    /*este controlador era donde hacia las pruevas de clases*/ /*ingnorar xd*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourse icourse;
        private IRollements irollements;
        private IStudent istudent;

        public HomeController(ILogger<HomeController> logger, ICourse icourse,IRollements irollements, IStudent istudent)
        {
            this.icourse = icourse;
            _logger = logger;
            this.irollements = irollements;
            this.istudent=istudent;
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
        public IActionResult ListaUnida()
        {
            var listado = irollements.ListarEnrrollments();
           
            return View(listado);
        }
        public IActionResult ComboBox()
        {
            var infoconbobox = icourse.ListarCursos();
            var studentconbobox = istudent.ListarEstudiantes();
            List<SelectListItem> itemcourse = new List<SelectListItem>();
            List<SelectListItem> itemstudent = new List<SelectListItem>();

            foreach (var items in infoconbobox)
            {
                itemcourse.Add(
                    new SelectListItem{

                        Text=items.Title,
                        Value= items.CourseId.ToString(),
                        


                });
                ViewBag.listacourse = itemcourse;
            }
            foreach (var items in studentconbobox)
            {
                itemstudent.Add(
                    new SelectListItem
                    {

                        Text = items.FirstMidName,
                        Value = items.StudentId.ToString(),



                    });
                ViewBag.listastudent = itemstudent;
            }
            return View();
        }
        public IActionResult getcombobox(Enrollment e)
        {
            _ = e;
            return View("ComboBox");
        }

        public IActionResult GetAllJoin()
        {
            var listado = irollements.ListarEnrrollments();
            var arreglos = (from union in listado
                            select new
                            {
                                union.Course.Title,
                                union.Student.LastName,
                                union.Student.FirstMidName,
                                union.Grade
                            }).ToList();
            return Json(new { arreglos});
        }
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();
            return Json(new { data=DandoFormatoJson});
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
