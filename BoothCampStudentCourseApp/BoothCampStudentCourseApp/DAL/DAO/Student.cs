using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothCampStudentCourseApp.DAL.DAO
{
    class Student
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

    }
}
