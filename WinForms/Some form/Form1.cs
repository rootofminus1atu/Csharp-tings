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

namespace Some_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int[] frequencies = { 22, 27, 41, 44, 37, 18, 11 };

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            for (int i = 0; i < 50; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, rdn.Next(0, 10));
            }
            chart3.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart3.Series["Series1"].Color = Color.Red;
        }
    }
}
