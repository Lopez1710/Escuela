using Escuela.Data;
using Escuela.Entidades;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourse
    {
        private ApplicationDBContext app;

        public CourseRepositorio (ApplicationDBContext app)
        {
            this.app = app;
        }

        public void Buscar(Course c)
        {
            app.Courses.Find(c);
        }

        public void Delete(Course c)
        {
            app.Courses.Remove(c);
            app.SaveChanges();
        }

        public void Insertar(Course c)
        {
            app.Courses.Add(c);
            app.SaveChanges();
        }

        public void Update(Course c)
        {
            app.Courses.Update(c);
            app.SaveChanges();
        }

        public ICollection<Course> ListarCursos()
        {
            return app.Courses.ToList();
        }
    }
}
