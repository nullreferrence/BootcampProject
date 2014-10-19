using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using BoothCampStudentCourseApp.BLL;
using BoothCampStudentCourseApp.DAL.DAO;

namespace BoothCampStudentCourseApp.UI
{
    public partial class CourseEnrollmentUI : Form
    {
        private CourseEnrollmentBLL aCourseEnrollmentBll;
        private Student aStudent;

        public CourseEnrollmentUI()
        {
            InitializeComponent();
            ShowCourseNameComboBox();
        }


        private void ShowCourseNameComboBox()
        {
            aCourseEnrollmentBll = new CourseEnrollmentBLL();
            List<Course> courseNameList = aCourseEnrollmentBll.GetCourseNameList();
            foreach (Course courseName in courseNameList)
            {
                courseComboBox.Items.Add(courseName);
            }
            courseComboBox.DisplayMember = "CourseName";


        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
            Course aCourse = new Course();
            aCourse = (Course)courseComboBox.SelectedItem;
            aCourse.StudentID = aStudent.StudentID;
            aCourse.EnrollmentDate = enrollDateTimePicker.Text;
            string msg = aCourseEnrollmentBll.Save(aCourse);
            ShowEnrolledCourses();
            MessageBox.Show(msg);
        }

        private void findButton_Click_1(object sender, EventArgs e)
        {
            aCourseEnrollmentBll = new CourseEnrollmentBLL();
            aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            studentNameTextBox.Text = aCourseEnrollmentBll.GetStudentName(aStudent.RegNo);
            emailTextBox.Text = aCourseEnrollmentBll.GetStudentEmail(aStudent.RegNo);
            aStudent.StudentID = aCourseEnrollmentBll.GetStudentID(aStudent.RegNo);
            ShowEnrolledCourses();
        }

        public void ShowEnrolledCourses()
        {
            enrolledCoursesListView.Items.Clear();

           // List<ViewEnrolledCourses> allEnrolledCourseses = aCourseEnrollmentBll.GetEnrolledCourses(aStudent.StudentID);
            //foreach (var anEnrolledCourse in allEnrolledCourseses)
            //{
                //ListViewItem item = new ListViewItem(anEnrolledCourse.CourseTitle);
                //item.SubItems.Add(anEnrolledCourse.CourseName);
                //item.SubItems.Add(anEnrolledCourse.EnrollmentDate);
                //enrolledCoursesListView.Items.Add(item);
            }
        }
    }

    

