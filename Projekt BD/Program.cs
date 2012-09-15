namespace Projekt_BD
{
    using System;
    using System.Windows.Forms;

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

            Application.Run(ControllerFactory.Instance.Create(ControllerTypes.ReceptionistForm).Form);
            //Application.Run(ControllerFactory.Instance.Create(ControllerTypes.LoginForm).Form);
        }
    }
}
