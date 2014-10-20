using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            GetAllCourseInComboBox();
            ShowCourseNameComboBox();

        }

        private  Course aCourse = new Course();
        private void ShowCourseNameComboBox()
        {
            aStudentCourseBll = new StudentCourseBll();
            List<Course> courseNameList = aStudentCourseBll.GetAllCourse();
            foreach (Course courseName in courseNameList)
            {
                courseComboBox.Items.Add(courseName);
            }
            //courseComboBox.DisplayMember = "CourseName";
        }

        Student aStudent=new Student();
        

        private StudentCourseBll aStudentCourseBll = new StudentCourseBll();
        private void findButton_Click(object sender, EventArgs e)
        {
             Student aStudent = aStudentCourseBll.Find(regnoTextBox.Text);
            studentNameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;
            
         }
        private void GetAllCourseInComboBox()
        {
            List<Course> courses = aStudentCourseBll.GetAllCourse();
            foreach (Course aCourse in courses)
            {
                courseComboBox.Items.Add(aCourse);
            }
            //courseComboBox.DisplayMember == "Course_Name";
        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
           
        }

        
    }
    }

