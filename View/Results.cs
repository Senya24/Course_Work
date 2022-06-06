using System;
using System.Windows.Forms;
using Kursova.Model;

namespace Kursova.View
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }
        
        private void Continue(object sender, EventArgs e)
        {
            Program.InequalityCounter++;
            if (Program.InequalityCounter>InequalitiesFactory.Inequalities.Length) Close();
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
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            chart.Titles[0].Text = result.IsNull ? "No answer" : result.ToString();
            if (result.IsNull) return;
            if (result.MinValue != null && result.MaxValue != null)
            {
                chart.Series[0].Points.AddXY(result.MinValue, 0.2);
                chart.Series[0].Points.AddXY(result.MaxValue, 0.2);
                chart.ChartAreas[0].AxisX.Interval = Math.Ceiling((result.MaxValue - result.MinValue).Value / 10);
                chart.ChartAreas[0].AxisX.Minimum = result.MinValue.Value-1;
                chart.ChartAreas[0].AxisX.IntervalOffset = 1;
                chart.ChartAreas[0].AxisX.Maximum = result.MaxValue.Value+1;
                if (result.MinIsIncluded) chart.Series[1].Points.AddXY(result.MinValue, 0.2);
                if (result.MaxIsIncluded) chart.Series[1].Points.AddXY(result.MaxValue, 0.2);
                return;
            }

            double center = result.MinValue ?? result.MaxValue ?? 0;

            if (result.MinValue == null)
            {
                chart.Series[0].Points.AddXY(center-4.2, 0.3);
                chart.Series[0].Points.AddXY(center-4.5, 0.2);
                chart.Series[0].Points.AddXY(center-4.2, 0.1);
                chart.Series[0].Points.AddXY(center-4.5, 0.2);
            }
            else
            {
                chart.Series[0].Points.AddXY(result.MinValue, 0.2);
                if (result.MinIsIncluded) chart.Series[1].Points.AddXY(result.MinValue, 0.2);
            }
            
            if (result.MaxValue == null)
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