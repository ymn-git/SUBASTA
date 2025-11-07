using SubastaWinForms.Views;
using SubastaWinForms.Data;

namespace SubastaWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var dbInit = new DatabaseInitializer();
            dbInit.CrearBaseSiNoExiste();

            Application.Run(new TestView());
        }
    }
}