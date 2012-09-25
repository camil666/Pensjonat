namespace Projekt_BD
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main class of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>                                                    
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(ControllerFactory.Instance.Create(ControllerTypes.AdminForm).Form);
            //Application.Run(ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form);
            //Application.Run(ControllerFactory.Instance.Create(ControllerTypes.ManagerForm).Form);
            //Application.Run(ControllerFactory.Instance.Create(ControllerTypes.LoginForm).Form);
            //Application.Run(ControllerFactory.Instance.Create(ControllerTypes.EmployeeForm).Form);
        }
    }
}
