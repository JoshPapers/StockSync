namespace StockSync
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Show Splash Screen (Loading Screen)
            using (LoadingSC splash = new LoadingSC())
            {
                splash.Show();
                Application.DoEvents(); // Process UI events while waiting
                System.Threading.Thread.Sleep(4000);
                splash.Close();
            }

            // Open Login Form After Splash Screen
            Application.Run(new LoginForm());
        }
    }
}