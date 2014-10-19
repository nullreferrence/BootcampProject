using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.DAL.Gatewat
{
    class CourseEnrollmentGateway
    {

        private static SqlConnection connection;
        private static SqlCommand command;
        private static string query;

        private static void GetConnection()
        {
            string conn = ConfigurationManager.ConnectionStrings["NullRefarance"].ConnectionString;
            connection = new SqlConnection(conn);
            connection.ConnectionString = conn;

        }
        public List<Course> GetCourseNameList()
        {
            GetConnection();
            connection.Open();
            query = String.Format("SELECT* FROM t_Course");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseID = (int)aReader[0];
                    //aCourse.CourseTitle = aReader[1].ToString();
                    aCourse.CourseName = aReader[1].ToString();
                    courseList.Add(aCourse);
                }
            }
            connection.Close();
            return courseList;
        }


        public string GetCourseName(string regNo)
        {

            GetConnection();
            connection.Open();
            query = String.Format("SELECT* FROM t_Student");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();

            string name = "";
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    if (regNo == aReader[1].ToString())
                        name = aReader[2].ToString();
                }
            }
            connection.Close();
            return name;
        }

        public string GetEmailAddress(string regNo)
        {
            GetConnection();
            connection.Open();
            query = String.Format("SELECT* FROM t_Student");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();

            string email = "";
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    if (regNo == aReader[1].ToString())
                        email = aReader[3].ToString();
                }
            }
            connection.Close();
            return email;
        }

        public void Save(Course aCourse)
        {
            GetConnection();
            connection.Open();
            query = "INSERT INTO EnrollmentCourses (StudentID,CourseName,CourseTitle,EnrollmentDate) Values(@0,@1,@2,@3,@4)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@0", aCourse.StudentID);
            command.Parameters.AddWithValue("@1", aCourse.CourseID);
            command.Parameters.AddWithValue("@2", aCourse.CourseTitle);
            command.Parameters.AddWithValue("@3", aCourse.CourseName);
            command.Parameters.AddWithValue("@4", aCourse.EnrollmentDate);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
