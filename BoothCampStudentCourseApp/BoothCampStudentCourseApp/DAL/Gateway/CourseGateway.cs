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
    class CourseGateway
    {

        private SqlConnection connection;

        public CourseGateway()
        {
            connection  = new SqlConnection();
            string conn = @"server= MINHAZ ;database= StudentCourse ;integrated security=true";
            connection.ConnectionString = conn;
            connection.Open();
        }
        

       public string HasThisRegNo(string RegNo)
        {
            SqlConnection connection = new SqlConnection();
            string conn = @"server=MINHAZ; database=StudentCourse; integrated security=true";
            connection.ConnectionString = conn;
            connection.Open();

            string query = String.Format("SELECT * FROM t_Student WHERE RegNo=@input");
           
            
            SqlCommand command = new SqlCommand(query, connection);

           command.Parameters.Add("@input", SqlDbType.VarChar).Value = RegNo;
            SqlDataReader aReader = command.ExecuteReader();
            //bool hasRows = aReader.HasRows;
            if (aReader.Read())
            {
                return aReader["Name"].ToString();
            }
           connection.Close();
            //return hasRows;
           return "regNo invalid";
        }



    }
}
