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
        private StudentGateway aStudentGateway = new StudentGateway();

        private  CourseGateway aCourseGateway= new CourseGateway();
        public Student Find(string RegNo)
        {
           
            return aStudentGateway.Find(RegNo);
        }

        public List<Course> GetAllCourse()
        {
            List<Course> aCourselist = aCourseGateway.GetAllCourse();
           return aCourselist;
        }

        public List<Course> GetCourseNameList()
        {
            List<Course> aCourseNameList = aCourseGateway.GetAllCourse();
            return aCourseNameList;
        }
        
    }
}
