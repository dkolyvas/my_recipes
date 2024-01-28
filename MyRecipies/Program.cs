using MyRecipies.Services;
using MyRecipies.Views;

namespace MyRecipies
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
            IAppServices services = new AppServices();
            HomeView homeView = new HomeView(services);
            
            
            Application.Run(homeView);
        }
    }
}