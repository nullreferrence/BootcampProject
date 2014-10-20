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
    class StudentGateway
    {

        private SqlConnection connection;

        public StudentGateway()
        {
            string conn = ConfigurationManager.ConnectionStrings["StudentCourse"].ConnectionString;
            connection = new SqlConnection(conn);
            connection.ConnectionString = conn;
        }
        
        public string GetStudentNameByRegNo(string regNo)
        {
            connection.Open();
            string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@RegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@RegNo", regNo));
            SqlDataReader aReader = command.ExecuteReader();
            string name = "";
            if (aReader.HasRows)
            {
                aReader.Read();
                name = aReader["Name"].ToString();
            }
            connection.Close();
            return name;
        }

        public string GetEmailAddressByRegNo(string regNo)
        {
            connection.Open();
            string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@RegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@RegNo", regNo));
            SqlDataReader aReader = command.ExecuteReader();
            string email = "";
            if (aReader.HasRows)
            {
                aReader.Read();
                email = aReader["Email"].ToString();
            }
            connection.Close();
            return email;
        }


        public int GetStudentIdByRegNo(string regNo)
        {
            connection.Open();
            string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@RegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@RegNo", regNo));
            SqlDataReader aReader = command.ExecuteReader();
            int studentId = 0;
            if (aReader.HasRows)
            {
                aReader.Read();
                studentId = (int) aReader["StudentID"];
            }
            connection.Close();
            return studentId;
        }
        
        
        
        

        //    SqlConnection connection = new SqlConnection();
        //    string conn = @"server=MINHAZ; database=StudentCourse; integrated security=true";
        //    connection.ConnectionString = conn;
        //    connection.Open();

        //    string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@input");


        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.Add("@input", SqlDbType.VarChar).Value = regNo;
        //    SqlDataReader aReader = command.ExecuteReader();
        //    //bool hasRows = aReader.HasRows;
        //    if (aReader.Read())
        //    {
        //        string name = aReader["CourseName"].ToString();
        //        string email = aReader["Email"].ToString();
        //        return name;
                
                
        //    }
        //    connection.Close();
        //    //return hasRows;
        //    //MessageBox.Show("regNo invalid");
        //    return "sdfsdf";
        //}

        //public List<Course> GetAllCourse()
        //{
        //    connection.Open();
        //    string query = string.Format("SELECT * FROM t_Course");
        //    SqlCommand command = new SqlCommand(query, connection);
        //    SqlDataReader aReader = command.ExecuteReader();
        //    List<Course> courses= new List<Course>();
        //    if (aReader.HasRows)
        //    {
        //        while (aReader.Read())
        //        {
        //            Course aCourse = new Course();

        //            aCourse.CourseName = aReader[1].ToString();
        //            aCourse.EnrollmentDate = aReader[2].ToString();
        //            aCourse.Score = (double) aReader[3];
        //            aCourse.ResultPublishingDate = aReader[4].ToString();

        //            courses.Add(aCourse);
        //        }
        //    }
        //    connection.Close();
        //    return courses;
        //}


       
    }
}
