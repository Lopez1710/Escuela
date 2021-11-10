using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Entidades
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }
        
        public int CourseID { get; set; }
        
        public int StudentID { get; set; }
        
        public Grade? Grade { get; set; }

        public Course Course { get; set; }

        public Students Student { get; set; }

    }
}
