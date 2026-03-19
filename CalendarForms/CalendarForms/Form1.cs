using CalendarManagementAppService;

namespace CalendarForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Handle the submit button click event
            MessageBox.Show("Submit button clicked!");

            CalendarAppService appService = new CalendarAppService();
     
        
        }
    }
}
