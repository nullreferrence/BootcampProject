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
                         anStudentCourses.CourseCode = aReader[4].ToString();
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
             
             SqlCommand command = new SqlCommand(query, connection);
             command.Parameters.Add(new SqlParameter("@StudentID", aCourse.StudentID));
             command.Parameters.Add(new SqlParameter("@CourseID", aCourse.CourseID));
             command.Parameters.Add(new SqlParameter("@CourseCode", aCourse.CourseCode));
             command.Parameters.Add(new SqlParameter("@CourseName", aCourse.CourseName));
             command.Parameters.Add(new SqlParameter("@EnrollmentDate", aCourse.EnrollmentDate));
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

        
        public List<StudentCourses> GetEnrolledCourseName(int studentId)
        {
            connection.Open();
            string query = String.Format("SELECT* FROM t_StudentCourse WHERE StudentID = @StudentID");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@StudentID", studentId));
            SqlDataReader aReader = command.ExecuteReader();
            List<StudentCourses> courseNameList = new List<StudentCourses>();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    StudentCourses aStudeCourseCourse = new StudentCourses();
                    aStudeCourseCourse.ID = (int)aReader[0];
                    aStudeCourseCourse.CourseCode = aReader[3].ToString();
                    aStudeCourseCourse.CourseName = aReader[4].ToString();
                    courseNameList.Add(aStudeCourseCourse);
                }
            }
            connection.Close();
            return courseNameList;
        }


        public void SaveResult(StudentCourses anStudentCourses)
        {
            connection.Open();
            //string query = string.Format("INSERT INTO t_StudentCourse VALUES(@Score,@ResultPublishDate) WHERE StudentID =@StudentID and CourseID = @CourseID ");
            string query =
                string.Format(
                    "Insert into t_StudentCourse VALUES (@Score,@ResultPublishDate) where StudentID =@StudentID  Exists (SELECT StudentID,CourseID  From t_StudentCourse");
            

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@StudentID", anStudentCourses.StudentId));
            command.Parameters.Add(new SqlParameter("@CourseID", anStudentCourses.CourseId));
            command.Parameters.Add(new SqlParameter("@CourseCode", anStudentCourses.CourseCode));
            command.Parameters.Add(new SqlParameter("@CourseName", anStudentCourses.CourseName));
            command.Parameters.Add(new SqlParameter("@Score", anStudentCourses.ScorePerchantage));
            command.Parameters.Add(new SqlParameter("@ResultPublishDate", anStudentCourses.ResultPublishDate));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
