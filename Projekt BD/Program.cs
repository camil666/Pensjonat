
namespace Projekt_BD
{
    using System;
    using System.Windows.Forms;

    using Projekt_BD.View;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AdminForm());
            //Application.Run(new LoginForm());
            //Application.Run(new ReceptionistForm());
            Application.Run(ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form);
            
            //Application.Run(new EmployeeForm());
        }
    }
}
