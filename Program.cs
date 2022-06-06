using System;
using System.Windows.Forms;
using Kursova.Controller;
using Kursova.Model;
using Kursova.View;

namespace Kursova
{
    static class Program
    {
      /// <summary>
      ///  The main entry point for the application.
      /// </summary>
        public static bool Form1Closed = true; // the flag that displays if the user closed the program. Initial value - true, and when we need to programly close a window, but not a program, we set it False.
        public static int InequalityCounter;
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); // idk, some system automatic settings
            Application.Run(new Form1());
            if (!Form1Closed) // if the first window was closed programly, not by user - continue
            {
                InequalitiesFactory.SetInequalities();
                InequalityCounter = 0;
                Application.Run(new ResultForm()); // output the results
            }
        }
    }
}
