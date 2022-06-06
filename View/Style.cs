using System.Drawing;

namespace Kursova.View
{
    public static class Style
    {
      /// <summary>
      ///  A class that stores information about program styles : colors, fonts and object sizes
      /// </summary>

        public static Color NextButtonColor = Color.RoyalBlue;
        public static Color ResetButtonColor = Color.DarkGray;
        public static Color NextButtonForeColor = Color.Azure;
        public static Color ResetButtonForeColor = Color.Black;

        public static readonly Font TextFieldFont = new ("Arial", 14F,
            FontStyle.Regular, GraphicsUnit.Point, 204);
        public static readonly Font TitleLabelFont = new ("Arial", 15.75F,
            FontStyle.Regular, GraphicsUnit.Point, 204);
        public static readonly Font InequalityFont = new ("Arial", 14F,
            FontStyle.Regular, GraphicsUnit.Point, 204);
        public static readonly Font NumerationLabelFont = new ("Arial", 14F,
            FontStyle.Regular, GraphicsUnit.Point, 204);

        public static Size ButtonSize = new (80, 35);
        public static Size NumerationLabelSize = new (28, 19);
        public static Size TitleLabelSize = new (277, 20);
        public static Size TextFieldSize = new (340, 30);
        public static Size InequalityLabelSize = new (320, 20);
        public static Size NormalFormLabelSize = new (160, 20);
        public static Size ArrowLabelSize = new (50, 20);

    }
}
