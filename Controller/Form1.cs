using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kursova.Model;

namespace Kursova.Controller
{
    public partial class Form1 : Form
    {
      /// <summary>
      /// A form for inequalities input
      /// </summary>

        public Form1()
        {
            InitializeComponent();
        }

        // A function for confirmation button, that is used to validate inputs and close the input window
        private void Continue(object sender, EventArgs e)
        {
            List<int> incorrectFields = new List<int>();
            // go through each textfield and validate them. pushing invalid fields numbers to incorrectFields
            for (int i = 0; i < textFields.Length; i++)
            {
                if (!InputValidator.ValidateInput(textFields[i].Text))
                {
                    incorrectFields.Add(i + 1);
                }
                else
                {
                    InequalitiesFactory.Sources[i] = InputValidator.ReformatInput(textFields[i].Text);
                }
            }

            if (incorrectFields.Count > 0) // if ther is some invalid fields, display the corresponding message
            {
                string errorMessage = "Incorrect input in field" + (incorrectFields.Count > 1 ? "s" : "") +
                                      $" {incorrectFields[0]}";
                for (int i = 1; i < incorrectFields.Count - 1; i++)
                {
                    errorMessage += $", {incorrectFields[i]}";
                }

                if (incorrectFields.Count > 1) errorMessage += $" and {incorrectFields[^1]}";
                MessageBox.Show(errorMessage);
            }
            else  // if there is no invalid fields, close the window.
            {
                Program.Form1Closed = false;
                Close();
            }
        }

        // just a method for Reset button
        private void ResetFields(object sender, EventArgs e)
        {
            foreach (var field in textFields)
            {
                field.Text = "";
            }
        }
    }
}
