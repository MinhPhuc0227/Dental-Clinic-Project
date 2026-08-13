using DentalClinic.App;
namespace DentalClinic.APP
{
    internal static class Programn
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
            // Init default data (Admin account)
            DentalClinic.DAL.DbInitializer.Seed();
            Application.Run(new Form_Login());
        }
    }
}