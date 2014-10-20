using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BoothCampStudentCourseApp.BLL;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.UI
{
    public partial class ResultEntryUI : Form
    {
        private  StudentCourseBll aStudentCourseBll=new StudentCourseBll();
        public ResultEntryUI()
        {
            InitializeComponent();
            ShowCourseNameComboBox();
        }

        private void ShowCourseNameComboBox()
        {
           
            List<Course> courseNameList = aStudentCourseBll.GetCourseNameList();
            foreach (Course courseName in courseNameList)
            {
                resultcourseComboBox.Items.Add(courseName);
            }
            resultcourseComboBox.DisplayMember = "Course_Name";
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            Student aStudent = aStudentCourseBll.Find(regnoTextBox.Text);
            studentNameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;
        }

        private void viewResultSheetButton_Click(object sender, EventArgs e)
        {
            ResultSheetUI aResultSheetUi = new ResultSheetUI();
            aResultSheetUi.Show();
        }
    }
}
