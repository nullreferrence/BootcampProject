using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoothCampStudentCourseApp.DAL.DAO;
using BoothCampStudentCourseApp.DAL.Gatewat;

namespace BoothCampStudentCourseApp.BLL
{
    class CourseEnrollmentBLL
    {
        CourseEnrollmentGateway aCourseEnrollmentGateway = new CourseEnrollmentGateway();
        public List<Course> GetCourseNameList()
        {
            List<Course> aCourseNameList = aCourseEnrollmentGateway.GetCourseNameList();
            return aCourseNameList;
        }

        public string GetStudentName(string regNo)
        {
            string name = aCourseEnrollmentGateway.GetCourseName(regNo);
            return name;
        }

        public string GetStudentEmail(string regNo)
        {
            string email = aCourseEnrollmentGateway.GetEmailAddress(regNo);
            return email;
        }


        public string Save(Course aCourse)
        {
            //if (CourseTaken(aCourse))
                //return "Course has already been Taken";

            aCourseEnrollmentGateway.Save(aCourse);
            return "Course Enrollment Completed";
        }
    }
}
