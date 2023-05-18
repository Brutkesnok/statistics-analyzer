using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace statistics_analyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateInfo(IStatisticsData statisticsData)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if (statisticsData.LoadData(openFileDialog.FileName))
            {
                UpdateTable(statisticsData.GetFields(), statisticsData.GetEntries());
                UpdateChart(statisticsData.GetFields(), statisticsData.GetEntries());
                UpdateSummary(statisticsData.GetSummary());
            }
            else
            {
                ShowError("Invalid data!");
            }
        }

        private void apartmentPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfo(new ApartmentPrices());
        }

        private void medianSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTable(string[] headers, List<string[]> data)
        {
            statisticsDataGridView.ColumnCount = headers.Length;
            statisticsDataGridView.Rows.Clear();
            for (int i = 0; i < headers.Length; ++i)
            {
                statisticsDataGridView.Columns[i].Name = headers[i];
            }
            for (int i = 0; i < data.Count; ++i)
            {
                statisticsDataGridView.Rows.Add(data[i]);
            }
        }

        private void UpdateChart(string[] fields, List<string[]> data)
        {
            timelineChart.Series.Clear();
            timelineChart.ChartAreas.Clear();
            timelineChart.ChartAreas.Add(new ChartArea());

            for (int j = 1; j < fields.Length; ++j)
            {
                Series series = new Series(fields[j]);
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                for (int i = 0; i < data.Count; ++i)
                    series.Points.AddXY(Convert.ToInt32(data[i][0]), Convert.ToInt32(data[i][j]));
                timelineChart.Series.Add(series);
            }
        }

        private void UpdateSummary(string summary)
        {
            summaryRichTextBox.Text = summary;
        }
    }
}
