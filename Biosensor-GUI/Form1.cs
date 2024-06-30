using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Biosensor_GUI
{
    public partial class Form1 : Form
    {
        private int dataRxCount = 0;

        private int dataPointsMax = 4000;   // max. number of points displayed in the plot
        List<int> dataPointsX = new List<int>();    // X-axis data (time or sample number)
        List<int> dataPointsY = new List<int>();    // Y-axis data (received values)

        public Form1()
        {
            InitializeComponent();

            textBoxLog.AppendText("-----Log-----" + Environment.NewLine + Environment.NewLine);

            // init plot
            InitializePlot();
        }
        private void InitializePlot()
        {
            // initial chart config

            chartPlot.ChartAreas[0].AxisX.Minimum = 0;  // address the first ChartArea
            chartPlot.ChartAreas[0].AxisX.Maximum = dataPointsMax;
            chartPlot.ChartAreas[0].AxisY.Minimum = 0;
            chartPlot.ChartAreas[0].AxisY.Maximum = 10;

            // add a point to the series to display the plot
            chartPlot.Series[0].Points.AddXY(0, 0); // address the first Series of the chart
        }

        /*
         * When receiving Data from the serial port than this command is executed
         */
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //this.Invoke(new Action<string>(updateUI), data);

            string data = serialPort.ReadLine();

            this.BeginInvoke(new Action(() =>
            {
                updateUI(data);
            }));
        }

        private void updateUI(string data)
        {
            // update log
            //string receiveLog = "Started receiving data...";
            //textBoxLog.AppendText(receiveLog + Environment.NewLine);

            // update plot
            data = data.TrimEnd('\r', '\n');
            int newValue;
            bool res = Int32.TryParse(data, out newValue);

            if (res)
            {
                dataRxCount++;
                
                chartPlot.Series[0].Points.AddY(newValue);

                int currentDataCount = chartPlot.Series[0].Points.Count;

                // store the new data in the data variables outside of the plot
                dataPointsY.Add(newValue);
                dataPointsX.Add(currentDataCount);

                // scroll chart along with new data
                if (chartPlot.Series[0].Points.Count > dataPointsMax)
                {
                    chartPlot.ChartAreas[0].AxisX.Minimum = currentDataCount - dataPointsMax;
                    chartPlot.ChartAreas[0].AxisX.Maximum = currentDataCount;
                }

                // set the y-axis limits within the min/max of the past values
                int lastValuesCount = Math.Min(currentDataCount, dataPointsMax );
                List<int> lastValues = dataPointsY.Skip(currentDataCount - lastValuesCount).ToList();

                int maxLastValues = lastValues.Max();
                int minLastValues = lastValues.Min();

                chartPlot.ChartAreas[0].AxisY.Minimum = minLastValues - 100;
                chartPlot.ChartAreas[0].AxisY.Maximum = maxLastValues + 100;
            }
        }

        /*
         * starts the predefined measurenment sequence
         */
        private void startMeasBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(new byte[] { CommandSet.START_MEAS }, 0, 1);
                    textBoxLog.AppendText("START cmd sent" + Environment.NewLine);

                    //enable or disable buttons
                    //startMeasBtn.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending a command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Select Com through selection box --> search for and select available Ports
        private void comSelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comSelBox.SelectedItem != null)
            {
                string selectedPort = comSelBox.SelectedItem.ToString();

                // TODO: if port initialization for the first time does not differ from reconnecting
                // then the code below can be shortened

                if (serialPort.IsOpen)
                {
                    string currentPort = serialPort.PortName;

                    serialPort.Close();
                    textBoxLog.AppendText("Disconnected from " + currentPort + Environment.NewLine);
                    comSelBox.BackColor = SystemColors.Window;

                    if (selectedPort != currentPort)
                    {
                        // reconnect if a new port was selected
                        serialPort.PortName = selectedPort;
                        serialPort.Open();
                        textBoxLog.AppendText("Connexted to " + selectedPort + Environment.NewLine);
                        comSelBox.BackColor = System.Drawing.Color.PaleGreen;
                    }
                }
                else
                {
                    serialPort.PortName = selectedPort;
                    serialPort.Open();
                    textBoxLog.AppendText("Connexted to " + selectedPort + Environment.NewLine);
                    comSelBox.BackColor = System.Drawing.Color.PaleGreen;
                }

            }
        }

        //Refresh the com selection Box  
        private void refrBut_Click(object sender, EventArgs e)
        {
            comSelBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                comSelBox.Items.AddRange(ports);
            }
        }
    }
}
