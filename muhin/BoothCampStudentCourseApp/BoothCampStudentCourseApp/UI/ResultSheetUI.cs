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

        private  StudentCourseBll aStudentCourseBll = new StudentCourseBll();
        private void findResultSheetButton_Click(object sender, EventArgs e)
        {
            Student aStudent = aStudentCourseBll.Find(regnoTextBox.Text);
            studentNameTextBox.Text = aStudent.Name;
            emailTextBox.Text = aStudent.Email;

        }

       
        
    }
}
