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
        private CourseEnrollmentBLL aCourseEnrollmentBll;
        private Student aStudent;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void findResultButton_Click(object sender, EventArgs e)
        {
            aCourseEnrollmentBll = new CourseEnrollmentBLL();
            aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            studentNameTextBox.Text = aCourseEnrollmentBll.GetStudentName(aStudent.RegNo);
            emailTextBox.Text = aCourseEnrollmentBll.GetStudentEmail(aStudent.RegNo);
            aStudent.StudentID = aCourseEnrollmentBll.GetStudentID(aStudent.RegNo);
            ShowEnrolledCourses();
        }

        private void ShowEnrolledCourses()
        {
            enrolledCoursesListView.Items.Clear();

        }

        private void enrolledCoursesListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
