namespace Projekt_BD.View
{
    using System.Windows.Forms;
    using Domain;

    public partial class NewEmployeeForm : Form
    {
        public Employee ActualEmployee { get; set; }

        public int EmployeeId { get; set; }

        public NewEmployeeForm()
        {
            InitializeComponent(); 
        }
    }
}
