using System.Xml.Linq;

namespace toyproject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static Login login;
        public static User user;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            login = new Login();
            user = new User();
            Application.Run(login);
        }
    }
}