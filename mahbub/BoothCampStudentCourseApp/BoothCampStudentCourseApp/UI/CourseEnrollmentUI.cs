using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using BoothCampStudentCourseApp.BLL;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.UI
{
    public partial class CourseEnrollmentUI : Form
    {
        public CourseEnrollmentUI()
        {
            InitializeComponent();
            ShowComboBoxItems();
        }

        private void ShowComboBoxItems()
        {
            courseComboBox.DataSource = aStudentCourseBll.Courses;
        }

        private StudentCourseBll aStudentCourseBll = new StudentCourseBll();
        private void findButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;

            studentNameTextBox.Text = aStudentCourseBll.HasThisRegNo(aStudent.RegNo);

            ////string msg = aStudentCourseBll.HasRegNo(aStudent.RegNo);
            ////studentNameTextBox.Text = aStudent.Name;
            ////emailTextBox.Text = aStudent.Email;

        }


    }
}
