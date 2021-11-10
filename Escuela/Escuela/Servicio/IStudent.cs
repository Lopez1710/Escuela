using Escuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
    public interface IStudent
    {
        void Insertar(Students S);

        void Delete(Students S);

        void Buscar(Students S);

        void Update(Students S);

        List<Students> ListarEstudiantes();
    }
}
