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
        private Course aCourse = new Course();
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        

        //public string HasRegNo(string regNo)
        //{
        //    if ((HasThisRegNo(aStudent.RegNo)))
        //    {
        //        return aStudent.Name;
                
                


        //    }
        //    else
        //    {
        //        string msg = "Regno Invalid";
        //        return msg;
        //    } 
        //}

        public string HasThisRegNo(string regNo)
        {
            return aStudentGateway.HasThisRegNoExist(regNo);
        }

        public List<Course> GetAllShop()
        {
            return aStudentGateway.GetAllCourse();
        }
    }
}
