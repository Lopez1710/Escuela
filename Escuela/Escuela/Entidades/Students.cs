using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Entidades
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
       
        public string LastName { get; set; }
        
        public string FirstMidName { get; set; }
        
        public int Estado { get; set; } // 1 es activo y 0 es inactivo
        
        public DateTime EnrollmentsDate { get; set; }

        public ICollection<Enrollment> enrollments { get; set; }
    }
}
