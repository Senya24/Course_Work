using System;
using System.Windows.Forms;
using Kursova.Controller;
using Kursova.Model;
using Kursova.View;

namespace Kursova
{
    static class Program
    {
        public static bool Form1Closed = true;
        public static int InequalityCounter;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (!Form1Closed)
            {
                InequalitiesFactory.SetInequalities();
                InequalityCounter = 0;
                Application.Run(new ResultForm());
            }
        }
    }
}