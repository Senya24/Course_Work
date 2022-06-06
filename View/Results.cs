using System;
using System.Windows.Forms;
using Kursova.Model;

namespace Kursova.View
{
    public partial class ResultForm : Form
    {
      /// <summary>
      /// A form for result output
      /// </summary>
        public ResultForm()
        {
            InitializeComponent();
        }

        // A method for Continue button: switching to next iteration
        private void Continue(object sender, EventArgs e)
        {
            Program.InequalityCounter++;
            if (Program.InequalityCounter>InequalitiesFactory.Inequalities.Length) Close(); // Close if it was the last iteration
            iterationTitle.Text = $"Iteration {Program.InequalityCounter}:";
            for (int i = 0; i < 3; i++)
            {
                inequalities[(Program.InequalityCounter - 1) * 3 + i].Visible = true;
            }

            result &= InequalitiesFactory.Inequalities[(Program.InequalityCounter - 1)].Range;
            FillChart();
            if (Program.InequalityCounter == InequalitiesFactory.Inequalities.Length || result.IsNull)
            {
                Program.InequalityCounter = InequalitiesFactory.Inequalities.Length;
                resultTitle.Text = "Final result:";
                nextButton.Text = "Close";
                nextButton.BackColor = Style.ResetButtonColor;
                nextButton.ForeColor = Style.ResetButtonForeColor;
            }
            Refresh();
        }

        private void FillChart()
        {
          /// <summary>
          /// Fills chart according to current result value
          /// </summary>
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear(); // clear the chart
            chart.Titles[0].Text = result.IsNull ? "No answer" : result.ToString(); //Set answer as a title
            if (result.IsNull) return; //exit if there is no answer
            if (result.MinValue != null && result.MaxValue != null) //if we have two non-inf boundaries, add this points to chart
            {
                chart.Series[0].Points.AddXY(result.MinValue, 0.2);
                chart.Series[0].Points.AddXY(result.MaxValue, 0.2);
                chart.ChartAreas[0].AxisX.Interval = Math.Ceiling((result.MaxValue - result.MinValue).Value / 10); // set the axis interval for normal visualizing
                chart.ChartAreas[0].AxisX.Minimum = result.MinValue.Value-1;
                chart.ChartAreas[0].AxisX.IntervalOffset = 1;
                chart.ChartAreas[0].AxisX.Maximum = result.MaxValue.Value+1;
                if (result.MinIsIncluded) chart.Series[1].Points.AddXY(result.MinValue, 0.2); // if a boundary is included, set a red point to it
                if (result.MaxIsIncluded) chart.Series[1].Points.AddXY(result.MaxValue, 0.2);
                return;
            }

            double center = result.MinValue ?? result.MaxValue ?? 0; // if at least one of boundaries if inf, we need to choose a "pivot". It can be a non-inf boundary or 0, if both boundaries are infinite

            if (result.MinValue == null) // drawing a left arrow if minimum is infinite
            {
                chart.Series[0].Points.AddXY(center-4.2, 0.3);
                chart.Series[0].Points.AddXY(center-4.5, 0.2);
                chart.Series[0].Points.AddXY(center-4.2, 0.1);
                chart.Series[0].Points.AddXY(center-4.5, 0.2);
            }
            else  // if minimum is not-infinite value, add it to the chart
            {
                chart.Series[0].Points.AddXY(result.MinValue, 0.2);
                if (result.MinIsIncluded) chart.Series[1].Points.AddXY(result.MinValue, 0.2);
            }

            if (result.MaxValue == null) //same for right boundary
            {
                chart.Series[0].Points.AddXY(center+4.5, 0.2);
                chart.Series[0].Points.AddXY(center+4.2, 0.3);
                chart.Series[0].Points.AddXY(center+4.5, 0.2);
                chart.Series[0].Points.AddXY(center+4.2, 0.1);
            }
            else
            {
                chart.Series[0].Points.AddXY(result.MaxValue, 0.2);
                if (result.MaxIsIncluded) chart.Series[1].Points.AddXY(result.MaxValue, 0.2);
            }
        }
    }
}
