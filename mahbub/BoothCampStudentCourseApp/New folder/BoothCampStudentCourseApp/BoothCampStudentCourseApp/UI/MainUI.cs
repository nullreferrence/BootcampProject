using System;
using System.Windows.Forms;

namespace BoothCampStudentCourseApp.UI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
            CourseEnrollmentUI anCourseEnrollmentUi=new CourseEnrollmentUI();
            anCourseEnrollmentUi.Show();
        }

        private void enterResultButton_Click(object sender, EventArgs e)
        {
            ResultEntryUI anResultEntryUi=new ResultEntryUI();
            anResultEntryUi.Show();
        }

        private void showResultSheetButton_Click(object sender, EventArgs e)
        {
            ResultSheetUI aResultSheetUi = new ResultSheetUI();
            aResultSheetUi.Show();
        }
    }
}
