using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BoothCampStudentCourseApp.BLL;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.UI
{
    public partial class ResultEntryUI : Form
    {
        public ResultEntryUI()
        {
            InitializeComponent();
        }

        private Student aStudent = new Student();
        private Course aCourse = new Course();
        private StudentCourseBll aStudentCourseBll = new StudentCourseBll();
        private StudentCourses anStudentCourses = new StudentCourses();
        private int StudentID ;
        private void findButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            studentNameTextBox.Text = aStudentCourseBll.GetStudentName(aStudent.RegNo);
            emailTextBox.Text = aStudentCourseBll.GetEmailAddress(aStudent.RegNo);
            aStudent.StudentId = aStudentCourseBll.GetStudentID(aStudent.RegNo);
            StudentID = aStudent.StudentId;
           ShowEnrolledCourseDropdown();
        }

        private void ShowEnrolledCourseDropdown()
        {
            aStudentCourseBll = new StudentCourseBll();
            aStudent.StudentId = aStudentCourseBll.GetStudentID(aStudent.RegNo);
            List<StudentCourses> courseNameList = aStudentCourseBll.GetOnlyEnrolledCourseComboBoxList(aStudent.StudentId);
            foreach (var courseName in courseNameList)
            {
                courseComboBox.Items.Add(courseName);
            }
            courseComboBox.DisplayMember = "CourseCode";
        }

        private void viewResultSheetButton_Click(object sender, EventArgs e)
        {
            ResultSheetUI aResultSheetUi = new ResultSheetUI();
            aResultSheetUi.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            anStudentCourses = new StudentCourses();
            anStudentCourses = (StudentCourses) courseComboBox.SelectedItem;
            anStudentCourses.StudentId = aStudent.StudentId;
            anStudentCourses.ResultPublishDate = resultPublishDateTimePicker.Text;
            anStudentCourses.ScorePerchantage = Convert.ToDouble(scorePercentageTextBox.Text);
            string msg = aStudentCourseBll.SaveResult(anStudentCourses);
            MessageBox.Show(msg);

        }
    }
}
