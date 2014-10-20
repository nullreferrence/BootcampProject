using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.DAL.Gateway
{
    class StudentGateway
    {

        private SqlConnection connection;

        public StudentGateway()
        {
            connection  = new SqlConnection();
            string conn = @"server= MOHINPC;database= StudentCourse ;integrated security=true";
            connection.ConnectionString = conn;
            connection.Open();
        }


        public Student Find(string regNo)
        {
            Student aStudent = new Student();
            
            string qurey = string.Format("SELECT * FROM t_Student WHERE regNo='{0}'", regNo);
            SqlCommand cmd = new SqlCommand(qurey, connection);
            SqlDataReader aReader = cmd.ExecuteReader();

            bool HasRow = aReader.HasRows;

            if (HasRow)
            {
                while (aReader.Read())
                {
                    aStudent.RegNo = aReader[0].ToString();
                    aStudent.Name = aReader[1].ToString();
                    aStudent.Email = aReader[2].ToString();
                }
                connection.Close();
            }

            return aStudent;
        }
    }
}
