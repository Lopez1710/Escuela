using Escuela.Entidades;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class StudentController : Controller
    {
        private IStudent istudent;

        public StudentController(IStudent istudent)
        {
            this.istudent = istudent;
        }
        public IActionResult Index()
        {
            var listado = istudent.ListarEstudiantes().Where(x => x.Estado == 1).Select(x => x).ToList();

            return View(listado);
        }
        public IActionResult Datos(int id)
        {
            if (id != 0) {
                Students st = istudent.ListarEstudiantes().Where(x => x.StudentId == id).Select(x => x).FirstOrDefault();
                return View(st);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Guardar(Students st)
        {
            Students s = new Students();

            if (st.StudentId != 0)
            {
                s.StudentId = st.StudentId;
                s.FirstMidName = st.FirstMidName;
                s.LastName = st.LastName;
                s.EnrollmentsDate = st.EnrollmentsDate;
                s.Estado = 1;
                istudent.Update(s);

                return RedirectToAction("Index");

            }
            else
            {

                s.FirstMidName = st.FirstMidName;
                s.LastName = st.LastName;
                s.EnrollmentsDate = st.EnrollmentsDate;
                s.Estado = 1;
                istudent.Insertar(s);

                return RedirectToAction("Index");
            }

        }
        public IActionResult Confirmacion(int id)
        {
            /*hice esta vista por que si ocupaba el lamda directamente en delete me daba un error, fue la unica
            solucion que encontre*/
            Students st = istudent.ListarEstudiantes().Where(x => x.StudentId == id).Select(x => x).FirstOrDefault();
            return View(st);
        }

        [HttpPost]
        public IActionResult Delete(Students st)
        {
            
            Students s = new Students();
            s.StudentId = st.StudentId;
            s.FirstMidName = st.FirstMidName;
            s.LastName = st.LastName;
            s.EnrollmentsDate = st.EnrollmentsDate;
            s.Estado = 0;
            istudent.Update(s);
            return Redirect("/Student/Index");
        }

    }
}
