using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoothCampStudentCourseApp.BLL;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.UI
{
    public partial class ResultSheetUI : Form
    {
        public ResultSheetUI()
        {
            InitializeComponent();
        }

        private Student aStudent = new Student();
        private Course aCourse = new Course();
        private StudentCourseBll aStudentCourseBll = new StudentCourseBll();

        private void findResultSheetButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            studentNameTextBox.Text = aStudentCourseBll.GetStudentName(aStudent.RegNo);
            emailTextBox.Text = aStudentCourseBll.GetEmailAddress(aStudent.RegNo);
            aStudent.StudentId = aStudentCourseBll.GetStudentID(aStudent.RegNo);

        }

        
    }
}
