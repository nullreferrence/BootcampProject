using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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

        private StudentCourseBll aStudentCourseBll = new StudentCourseBll();
        private Student aStudent;
        private Course aCourse;

        private void ShowComboBoxItems()
        {
            aStudentCourseBll = new StudentCourseBll();
            List<Course> courseNameList = aStudentCourseBll.GetCourseComboBoxList();
            foreach (Course courseName in courseNameList)
            {
                courseComboBox.Items.Add(courseName); 
            }
            courseComboBox.DisplayMember = "CourseCode";
        }

       
        private void findButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            studentNameTextBox.Text = aStudentCourseBll.GetStudentName(aStudent.RegNo);
            emailTextBox.Text = aStudentCourseBll.GetEmailAddress(aStudent.RegNo);
            aStudent.StudentId = aStudentCourseBll.GetStudentID(aStudent.RegNo);
            ShowStudentCourseInListView();
            
        }

        private void ShowStudentCourseInListView()
        {
            enrolledCoursesListView.Items.Clear();
            List<StudentCourses> studentEnrolledCourseList = aStudentCourseBll.GetEnrolledCoursByStudetID(aStudent.StudentId);
            foreach (var studentCoursese in studentEnrolledCourseList)
            {
                ListViewItem anItem = new ListViewItem(studentCoursese.CourseCode);
                anItem.SubItems.Add(studentCoursese.CourseName);
                anItem.SubItems.Add(studentCoursese.EnrollmentDate);
                enrolledCoursesListView.Items.Add(anItem);
            }
        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
            aCourse = new Course();
            aCourse = (Course) courseComboBox.SelectedItem;
            aCourse.StudentID = aStudent.StudentId;
            aCourse.EnrollmentDate = enrollDateTimePicker.Text;
            string msg = aStudentCourseBll.Save(aCourse);
            ShowStudentCourseInListView();
            MessageBox.Show(msg);
        }
    }
}
