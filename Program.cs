using DB2POCO.Services;
using System;
using System.Windows.Forms;

namespace DB2POCO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1 && "test" == args[0]) {
                new ConfigService();
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1( new ConfigService()));
        }
    }
}
