using System.Text.RegularExpressions;

namespace Kursova.Model
{
    public class InputValidator
    {
      /// <summary>
      ///  The class for input validating and reformating
      /// </summary>
        private static Regex regex = new Regex(@"^ *[\+-]? *(?:\d+ *\*? *)?x *(?:[\+-] *\d+)? *[><]=? *[\+-]? *\d+ *$");
        
        public static bool ValidateInput(string textFieldContent)
        {
            if (string.IsNullOrEmpty(textFieldContent) || regex.IsMatch(textFieldContent)) return true;
            return false;
        }


        public static string ReformatInput(string input)
        {
            input = Regex.Replace(input, @" ", ""); // deleting all whitespaces
            if (input.Length == 0) return input;
            input = Regex.Replace(input, @"\*", ""); // deleting * symbols
            if (input[0] == '+') input = input.Remove(0, 1); // deleting redundant sign +
            return input;
        }
    }
}
