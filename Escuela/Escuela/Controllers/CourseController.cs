using Escuela.Entidades;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class CourseController : Controller
    {
        private ICourse icourses;
        public CourseController(ICourse icourses)
        {
            this.icourses = icourses;
        }
        public IActionResult Index()
        {
            var listado = icourses.ListarCursos().Where(x => x.Estado == 1).Select(x => x).ToList();

            return View(listado);
        }
        public IActionResult Datos(int id)
        {
            if (id != 0)
            {
                Course st = icourses.ListarCursos().Where(x => x.CourseId == id).Select(x => x).FirstOrDefault();
                return View(st);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Guardar(Course cs)
        {
            Course c = new Course();

            if (cs.CourseId != 0)
            {
                c.CourseId = cs.CourseId;
                c.Title = cs.Title;
                c.Credits = cs.Credits;
                c.Estado = 1;
                icourses.Update(c);

                return RedirectToAction("Index");

            }
            else
            {


                c.Title = cs.Title;
                c.Credits = cs.Credits;
                c.Estado = 1;
                icourses.Insertar(c);

                return RedirectToAction("Index");
            }

        }
        public IActionResult Confirmacion(int id)
        {
            /*hice esta vista por que si ocupaba el lamda directamente en delete me daba un error, fue la unica
            solucion que encontre*/
            Course cs = icourses.ListarCursos().Where(x => x.CourseId == id).Select(x => x).FirstOrDefault();
            return View(cs);
        }

        [HttpPost]
        public IActionResult Delete(Course cs)
        {
            Course c = new Course();
            c.CourseId = cs.CourseId;
            c.Title = cs.Title;
            c.Credits = cs.Credits;
            c.Estado = 0;
            icourses.Update(c);
            return Redirect("/Course/Index");
        }
    }
}
