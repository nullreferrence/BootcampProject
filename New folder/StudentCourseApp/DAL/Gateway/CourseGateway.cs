using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            string conn = ConfigurationManager.ConnectionStrings["StudentCourse"].ConnectionString;
            connection = new SqlConnection(conn);
            connection.ConnectionString = conn;
        }

         public List<StudentCourses> GetAllEnrolledCourses(int studentId)
         {
             connection.Open();
             string query = String.Format("SELECT* FROM t_StudentCourse");
             SqlCommand command = new SqlCommand(query, connection);
             SqlDataReader aReader = command.ExecuteReader();
             List<StudentCourses> allEnrolledCourses = new List<StudentCourses>();


             if (aReader.HasRows)
             {
                 while (aReader.Read())
                 {
                     StudentCourses anStudentCourses = new StudentCourses();
                     if (studentId == (int)aReader[1])
                     {
                         anStudentCourses.CourseId = (int)aReader[2];
                         anStudentCourses.CourseName = aReader[3].ToString();
                         anStudentCourses.CourseTitle = aReader[4].ToString();
                         anStudentCourses.EnrollmentDate = aReader[5].ToString();
                         allEnrolledCourses.Add(anStudentCourses);
                     }
                 }
             }
             connection.Close();
             return allEnrolledCourses;
         }

         public void Save(Course aCourse)
         {
             connection.Open();
             string query = string.Format("INSERT INTO t_StudentCourse VALUES(@StudentID,@CourseID,@CourseCode,@CourseName,@EnrollmentDate)");
             //string query = "INSERT INTO EnrollmentCourses (StudentID,CourseID,CourseName,CourseTitle,EnrollmentDate) Values(@0,@1,@2,@3,@4)";
             SqlCommand command = new SqlCommand(query, connection);
             command.Parameters.Add(new SqlParameter("@StudentID", aCourse.StudentID));
             command.Parameters.Add(new SqlParameter("@CourseID", aCourse.CourseID));
             command.Parameters.Add(new SqlParameter("@CourseCode", aCourse.CourseCode));
             command.Parameters.Add(new SqlParameter("@CourseName", aCourse.CourseName));
             command.Parameters.Add(new SqlParameter("@EnrollmentDate", aCourse.EnrollmentDate));

             //command.Parameters.AddWithValue("@0", aCourse.StudentID);
             //command.Parameters.AddWithValue("@1", aCourse.CourseID);
             //command.Parameters.AddWithValue("@2", null);
             //command.Parameters.AddWithValue("@3", aCourse.CourseName);
             //command.Parameters.AddWithValue("@4", aCourse.EnrollmentDate);
             command.ExecuteNonQuery();
             connection.Close();
         }

         public List<Course> GetCourseNameList()
         {
             connection.Open();
             string query = String.Format("SELECT* FROM t_Course");
             SqlCommand command = new SqlCommand(query, connection);
             SqlDataReader aReader = command.ExecuteReader();
             List<Course> courseNameList = new List<Course>();

             if (aReader.HasRows)
             {
                 while (aReader.Read())
                 {
                     Course aCourse = new Course();
                     aCourse.CourseID = (int)aReader[0];
                     aCourse.CourseCode= aReader[1].ToString();
                     aCourse.CourseName = aReader[2].ToString();
                     courseNameList.Add(aCourse);
                 }
             }
             connection.Close();
             return courseNameList;
         }
      
       
    }
}
