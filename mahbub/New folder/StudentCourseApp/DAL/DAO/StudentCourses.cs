using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothCampStudentCourseApp.DAL.DAO
{
    class StudentCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseName { get; set; }
        public string EnrollmentDate { get; set; }
    }
}
