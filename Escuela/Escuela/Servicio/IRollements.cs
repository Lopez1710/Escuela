using Escuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
    public interface IRollements
    {
        void Insertar(Enrollment E);

        void Delete(Enrollment E);

        void Buscar(Enrollment E);

        void Update(Enrollment E);

        List<Enrollment> ListarEnrrollments();
    }
}
