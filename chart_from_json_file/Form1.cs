using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace chart_from_json_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Read data from the JSON file
            string jsonFilePath = "data.json"; // Replace with the actual path to your JSON file
            List<KeyValuePair<string, int>> dataPoints = ReadJsonFile(jsonFilePath);

            // Create a series
            Series series = new Series("YourSeries");
            series.ChartType = SeriesChartType.Column; // Choose the chart type (Column, Bar, Line, etc.)

            // Bind the series to the list
            foreach (var dataPoint in dataPoints)
            {
                series.Points.AddXY(dataPoint.Key, dataPoint.Value);
            }

            // Add the series to the chart
            chart1.Series.Add(series);

            // Customize chart appearance if needed
            chart1.ChartAreas[0].AxisX.Title = "X Axis";
            chart1.ChartAreas[0].AxisY.Title = "Y Axis";

        }

        private List<KeyValuePair<string, int>> ReadJsonFile(string filePath)
        {
            try
            {
                // Read the JSON file
                string jsonData = File.ReadAllText(filePath);

                // Deserialize JSON data to a list of KeyValuePair
                List<KeyValuePair<string, int>> dataPoints = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(jsonData);

                return dataPoints;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<KeyValuePair<string, int>>();
            }
        }



    }
}


