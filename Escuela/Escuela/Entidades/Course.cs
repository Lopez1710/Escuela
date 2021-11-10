using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Entidades
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int Estado { get; set; } /*activo 1 inactivo 0*/

        public ICollection<Enrollment> enrollments { get; set; }

    }
}
