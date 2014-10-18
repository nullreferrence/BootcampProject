using System;
using System.Collections.Generic;
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
            //connection  = new SqlConnection();
            //string conn = @"server= BITM-401-PC28\SQLEXPRESS ;database= StudentCourse ;integrated security=true";
            //connection.ConnectionString = conn;
            //connection.Open();
        }
        public string HasThisRegNoExist(string regNo)
        {
            //connection.Open();
            //string query = string.Format("SELECT * FROM t_Student WHERE regNo=@RegNo");
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.Add(new SqlParameter("@RegNo", regNo));
            //SqlDataReader aReader = command.ExecuteReader();
            //bool Hasrow = aReader.HasRows;
            //connection.Close();
            //return Hasrow;


            SqlConnection connection = new SqlConnection();
            string conn = @"server=MINHAZ; database=StudentCourse; integrated security=true";
            connection.ConnectionString = conn;
            connection.Open();

            string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@input");


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@input", SqlDbType.VarChar).Value = regNo;
            SqlDataReader aReader = command.ExecuteReader();
            //bool hasRows = aReader.HasRows;
            if (aReader.Read())
            {
                string name = aReader["Name"].ToString();
                string email = aReader["Email"].ToString();
                return name;
                
                
            }
            connection.Close();
            //return hasRows;
            //MessageBox.Show("regNo invalid");
        }

        public List<Course> GetAllCourse()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Course");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Course> courses= new List<Course>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Course aCourse = new Course();

                    aCourse.Name = aReader[1].ToString();
                    aCourse.EnrollmentDate = aReader[2].ToString();
                    aCourse.Score = (double) aReader[3];
                    aCourse.ResultPublishingDate = aReader[4].ToString();

                    courses.Add(aCourse);
                }
            }
            connection.Close();
            return courses;
        }
    }
}
