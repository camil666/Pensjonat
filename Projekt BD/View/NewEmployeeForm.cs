namespace Projekt_BD.View
{
    using System.Windows.Forms;
    using Domain;

    public partial class NewEmployeeForm : Form
    {
        #region Constructors

        public NewEmployeeForm()
        {
            this.InitializeComponent();
        }

        #endregion

        public Employee ActualEmployee { get; set; }

        public int EmployeeId { get; set; }  
    }
}
