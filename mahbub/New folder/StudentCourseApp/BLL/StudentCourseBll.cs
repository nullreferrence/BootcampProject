using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoothCampStudentCourseApp.DAL.DAO;
using BoothCampStudentCourseApp.DAL.Gateway;

namespace BoothCampStudentCourseApp.BLL
{
    class StudentCourseBll
    {
        Student aStudent = new Student();
        private StudentGateway aStudentGateway = new StudentGateway();
        private CourseGateway aCourseGateway = new CourseGateway();
        private Course aCourse = new Course();
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        
        public string HasThisRegNo(string regNo)
        {
            return "StudentGateway.HasThisRegNoExist(regNo)";
;        }

       
        public string GetStudentName(string regNo)
        {
            return aStudentGateway.GetStudentNameByRegNo(regNo);
        }

        public string GetEmailAddress(string regNo)
        {
            return aStudentGateway.GetEmailAddressByRegNo(regNo);
        }

        public int GetStudentID(string regNo)
        {
            return aStudentGateway.GetStudentIdByRegNo(regNo);
        }

        public List<StudentCourses> GetEnrolledCoursByStudetID(int studentId)
        {
            List<StudentCourses> allEnrolledCourseses = aCourseGateway.GetAllEnrolledCourses(studentId);
            return allEnrolledCourseses;
        }


        public List<Course> GetCourseComboBoxList()
        {
            List<Course> aCourseNameList = aCourseGateway.GetCourseNameList();
            return aCourseNameList;
        }

        public string Save(Course aCourse)
        {
            if (CourseHasBeenTaken(aCourse))
                return "Course has already been Taken";

            aCourseGateway.Save(aCourse);
            return "Course Enrollment Successfull";
        }

        private bool CourseHasBeenTaken(Course aCourse)
        {
            List<StudentCourses> allEnrolledCourseses = GetEnrolledCourses(aCourse.StudentID);
            foreach (var anEnrolledCourse in allEnrolledCourseses)
            {
                if (anEnrolledCourse.CourseId == aCourse.CourseID)
                {
                    return true;
                }
            }
            return false;
        }

        private List<StudentCourses> GetEnrolledCourses(int studentId)
        {
            List<StudentCourses> allEnrolledCourseses = aCourseGateway.GetAllEnrolledCourses(studentId);
            return allEnrolledCourseses;
        }
    }
}
