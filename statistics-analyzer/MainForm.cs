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

        private void UpdateInfo()
        {

        }

        private void apartmentPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void medianSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTable()
        {

        }

        private void UpdateChart()
        {

        }

        private void UpdateSummary()
        {

        }
    }
}
