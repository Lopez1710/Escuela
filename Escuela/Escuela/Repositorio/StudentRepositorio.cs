using Escuela.Data;
using Escuela.Entidades;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentRepositorio : IStudent
    {
        private ApplicationDBContext DB;
        public StudentRepositorio(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Buscar(Students S)
        {
            throw new NotImplementedException();
        }

        public void Delete(Students S)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Students S)
        {
            DB.Students.Add(S);
            DB.SaveChanges();
        }

        public List<Students> ListarEstudiantes()
        {
            return DB.Students.ToList();
        }

        public void Update(Students S)
        {
            DB.Students.Update(S);
            DB.SaveChanges();

        }
    }
}
