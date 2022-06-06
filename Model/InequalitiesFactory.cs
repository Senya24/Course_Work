using System;
using System.Text.RegularExpressions;

namespace Kursova.Model
{
    public class InequalitiesFactory
    {
      /// <summary>
      ///  The class that stores our inequalities and their sources
      /// </summary>
        public static string[] Sources = new string[4];
        public static Inequality[] Inequalities;

        // a method that analizes sources and gets inequalities
        public static void SetInequalities()
        {
            int inequalitiesAmount = 0;
            foreach (string source in Sources) if (source.Length > 0) inequalitiesAmount++;
            Inequality[] inequalities = new Inequality[inequalitiesAmount];
            int i = 0;
            foreach (string source in Sources)
            {
                if (source=="") continue;
                var groups = Regex.Match(source, @"^(.*)x(.*)(<=|>=|<|>)(.+)$").Groups;
                int a = groups[1].Value == "" ? 1 : groups[1].Value == "-" ? -1 : Int32.Parse(groups[1].Value);
                int b = groups[2].Value == "" ? 0 : Int32.Parse(groups[2].Value);
                string Operator = groups[3].Value;
                int c = Int32.Parse(groups[4].Value);
                inequalities[i] = new Inequality(a, b, Operator, c);
                i++;
            }
            Inequalities = inequalities;
        }
    }
}
