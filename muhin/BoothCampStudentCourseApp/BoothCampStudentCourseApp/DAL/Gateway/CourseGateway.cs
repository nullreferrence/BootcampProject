using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.DAL.Gateway
{
    class CourseGateway
    {

        private SqlConnection connection;

        public CourseGateway()
        {
            connection  = new SqlConnection();
            string conn = @"server= MOHINPC;database= StudentCourse ;integrated security=true";
            connection.ConnectionString = conn;
            connection.Open();
        }


        public List<Course> GetAllCourse()
        {
            Course aCourse;
            string qurey = string.Format("SELECT * FROM Course");
            SqlCommand cmd = new SqlCommand(qurey, connection);
            SqlDataReader aReader = cmd.ExecuteReader();
            List<Course> courses = new List<Course>();
            bool HasRow = aReader.HasRows;

            if (HasRow)
            {
                while (aReader.Read())
                {
                    aCourse = new Course();
                    aCourse.CourseName = aReader[0].ToString();
                    courses.Add(aCourse);
                }
                connection.Close();
            }
            return courses;
        }

        public void Save(Course aCourse)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetEnrolledCourses(object studentId)
        {
            throw new NotImplementedException();
        }
    }
}
