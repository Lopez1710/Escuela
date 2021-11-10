using Escuela.Data;
using Escuela.Entidades;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollmentRepositorio : IRollements
    {
        private ApplicationDBContext DB;
        public EnrollmentRepositorio(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Buscar(Enrollment E)
        {
            DB.Enrollments.Find(E);
        }

        public void Delete(Enrollment E)
        {
            DB.Enrollments.Remove(E);
            DB.SaveChanges();
        }

        public void Insertar(Enrollment E)
        {
            DB.Enrollments.Add(E);
            DB.SaveChanges();
        }

        public void Update(Enrollment E)
        {
            DB.Enrollments.Update(E);
            DB.SaveChanges();
        }


        public List<Enrollment> ListarEnrrollments()
        {
            var union = DB.Enrollments.Include(e => e.Student).Include(c => c.Course).ToList();
            return union;
        }

        
    }
}
