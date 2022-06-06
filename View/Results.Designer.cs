using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.DataVisualization.Charting;
using Kursova.Model;

namespace Kursova.View
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iterationTitle = new System.Windows.Forms.Label();
            this.chart = new Chart();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.inequalities = new Label[InequalitiesFactory.Inequalities.Length * 3];
            this.resultTitle = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.result = new Range(null, null);
            this.SuspendLayout();
            // 
            // IterationTitle
            // 
            this.iterationTitle.Font = Style.TitleLabelFont;
            this.iterationTitle.Location = new System.Drawing.Point(162, 50);
            this.iterationTitle.Name = "iterationTitle";
            this.iterationTitle.Size = Style.TitleLabelSize;
            this.iterationTitle.TabIndex = 0;
            this.iterationTitle.Text = "Iteration 0:";
            this.iterationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Inequalities
            //
            int[] xCoors = { 50, 380, 430 };
            System.Drawing.ContentAlignment[] alignments = new[]
            {
                System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleCenter,
                System.Drawing.ContentAlignment.MiddleRight
            };
            for (int i = 0; i < InequalitiesFactory.Inequalities.Length*3; i++)
            {
                inequalities[i] = new System.Windows.Forms.Label();
                inequalities[i].Font = Style.InequalityFont;
                inequalities[i].Location = new System.Drawing.Point(xCoors[i%3], 125+30*(i/3));
                inequalities[i].TabIndex = i+1;
                inequalities[i].TextAlign = alignments[i%3];
                inequalities[i].Visible = false;

                switch (i%3)
                {
                    case 0:
                        inequalities[i].Name = $"ineq{i/3+1}";
                        inequalities[i].Size = Style.InequalityLabelSize;
                        inequalities[i].Text = InequalitiesFactory.Inequalities[i/3].ToString();
                        break;
                    case 1:
                        inequalities[i].Name = $"=>{i/3+1}";
                        inequalities[i].Size = Style.ArrowLabelSize;
                        inequalities[i].Text = "=>";
                        break;
                    case 2:
                        inequalities[i].Name = $"norm{i/3+1}";
                        inequalities[i].Size = Style.NormalFormLabelSize;
                        inequalities[i].Text = "x" + InequalitiesFactory.Inequalities[i / 3].NormalFormOperator +
                                               InequalitiesFactory.Inequalities[i / 3].NormalFormC;
                        break;
                }
                this.Controls.Add(inequalities[i]);
            }
            // 
            // ResultTitle
            // 
            this.resultTitle.Font = Style.TitleLabelFont; 
            this.resultTitle.Location = new System.Drawing.Point(162, 130+30*InequalitiesFactory.Inequalities.Length);
            this.resultTitle.Name = "resultTitle";
            this.resultTitle.Size = Style.TitleLabelSize;
            this.resultTitle.TabIndex = InequalitiesFactory.Inequalities.Length*3+1;
            this.resultTitle.Text = InequalitiesFactory.Inequalities.Length>0?"Current result:":"Final result:";
            this.resultTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ResultChart
            //
            chartArea.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea);
            this.chart.Location = new System.Drawing.Point(50, 160+30*InequalitiesFactory.Inequalities.Length);
            this.chart.Name = "resultChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "Series2";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 0.3;
            this.chart.Size = new System.Drawing.Size(520, 70);
            this.chart.TabIndex = InequalitiesFactory.Inequalities.Length*3+2;
            title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title.ForeColor = System.Drawing.Color.DimGray;
            title.Name = "Title1";
            title.Text = result.ToString();
            this.chart.Titles.Add(title);
            this.FillChart();
            //
            // nextButton
            //
            this.nextButton.BackColor = Style.NextButtonColor;
            this.nextButton.ForeColor = Style.NextButtonForeColor;
            this.nextButton.Location = new System.Drawing.Point(430, 260+30*InequalitiesFactory.Inequalities.Length);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = Style.ButtonSize;
            this.nextButton.TabIndex = InequalitiesFactory.Inequalities.Length*3+3;
            this.nextButton.Text = InequalitiesFactory.Inequalities.Length>0?"Continue":"Close";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.Continue);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 330+30*InequalitiesFactory.Inequalities.Length);
            this.Controls.Add(this.iterationTitle);
            this.Controls.Add(this.resultTitle);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.nextButton);
            this.Name = "ResultForm";
            this.Text = "Inequalities Calculator";
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label iterationTitle;
        private System.Windows.Forms.Label resultTitle;
        private System.Windows.Forms.Label[] inequalities;
        private Range result;
        private System.Windows.Forms.Button nextButton;
        private Chart chart;

        #endregion
    }
}