using Escuela.Entidades;
using Escuela.Repositorio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class EnrrollmentController : Controller
    {
        private IRollements irollements;
        private ICourse icourse;
        private IStudent istudent;

        public EnrrollmentController(IRollements irollements, ICourse icourse, IStudent istudent)
        {
            this.irollements = irollements;
            this.icourse = icourse;
            this.istudent = istudent;
        }
        public IActionResult Index()
        {
            var listado = irollements.ListarEnrrollments();
            var arreglo = (from datos in listado
                           where datos.Course.Estado == 1 &&
                           datos.Student.Estado == 1
                           select datos).ToList();
                          
            return View(arreglo);
        }
        public IActionResult Datos()
        {          
                var Grado = Enum.GetValues(typeof(Grade));
                var Cursos = icourse.ListarCursos().Where(x=>x.Estado == 1).Select(x=>x);
                var Estudiantes = istudent.ListarEstudiantes().Where(x=>x.Estado == 1).Select(x=>x);
                List<SelectListItem> ItemGrado = new List<SelectListItem>();
                List<SelectListItem> ItemCurso = new List<SelectListItem>();
                List<SelectListItem> ItemEstudiantes = new List<SelectListItem>();
                foreach (var items in Cursos)
                {
                    ItemCurso.Add(
                        new SelectListItem
                        {
                             Text = items.Title,
                            Value = items.CourseId.ToString(),
                            
                        });
                        ViewBag.Cursos = ItemCurso;
                }
                foreach (var items in Estudiantes)
                {
                    ItemEstudiantes.Add(
                        new SelectListItem
                        {
                            Text = (items.FirstMidName +" "+ items.LastName),
                            Value = items.StudentId.ToString()
                        });
                        ViewBag.Estudiantes = ItemEstudiantes;
                }
                foreach (var items in Grado)
                {
                    ItemGrado.Add(
                        new SelectListItem
                        {
                            Text = Enum.GetName(typeof(Grade),items),
                            Value = ((int)items).ToString()
                        });
                    ViewBag.Grado = ItemGrado;
                }
                return View();
        }
        public IActionResult Guardar(Enrollment Et)
        {
            
             Enrollment e = new Enrollment();
                
                e.StudentID = Et.StudentID;
                e.CourseID = Et.CourseID;
                e.Grade = Et.Grade;
                irollements.Insertar(e);

                return RedirectToAction("Index");
           
        }

        public IActionResult Delete(int id)
        {
            Enrollment en = irollements.ListarEnrrollments().Where(x=>x.EnrollmentId == id).Select(x=>x).FirstOrDefault();
            irollements.Delete(en);
            return RedirectToAction("Index");
        }
    }
}
