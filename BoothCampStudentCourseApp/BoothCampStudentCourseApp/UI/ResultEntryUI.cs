using System;
using System.Windows.Forms;

namespace BoothCampStudentCourseApp.UI
{
    public partial class ResultEntryUI : Form
    {
        public ResultEntryUI()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {

        }

        private void viewResultSheetButton_Click(object sender, EventArgs e)
        {
            ResultSheetUI aResultSheetUi = new ResultSheetUI();
            aResultSheetUi.Show();
        }
    }
}
