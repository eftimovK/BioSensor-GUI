using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Biosensor_GUI
{
    public partial class Form1 : Form
    {
        private int dataRxCount = 0;
        private int measCounter = 1;

        private int dataPointsMax = 4000;   // max. number of points displayed in the plot
        List<int> dataPointsX = new List<int>();    // X-axis data (time or sample number)
        List<int> dataPointsY = new List<int>();    // Y-axis data (received values)
        bool readConfigData = false;                // marks whether the data received refers to the config cmds
        int configSuccess = -1;                     // -1 denotes that no return value (0 or 1) was read from the port
        private System.Timers.Timer stopMeasTimer;

        public Form1()
        {
            InitializeComponent();

            textBoxLog.AppendText("-----Log-----" + Environment.NewLine + Environment.NewLine);

            refreshBtn_Click(this, EventArgs.Empty);
            // init plot
            InitializePlot();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            stopMeasTimer = new System.Timers.Timer();
            stopMeasTimer.Elapsed += new ElapsedEventHandler(stopMeasTimerFcn);
            // stopMeasTimer.Interval = 10; // placeholder
            //stopMeasTimer.Tick += stopMeasTimerFcn;
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
            // TODO: change approach => use an encoding for the data received
            
            if (readConfigData) // incoming data refers to config cmds
            {
                // set config bool flag based on return value
                byte[] byteArray = new byte[1] { 0 };
                serialPort.Read(byteArray, 0, 1);

                configSuccess = byteArray[0];
            }
            else    // we receive data for plotting
            {
                string data = serialPort.ReadLine();

                this.BeginInvoke(new Action(() =>
                {
                    updateUI(data);
                }));
            }
        }

        private bool ConfigSuccess()
        {
            // TODO: implement a timeout in addition to waiting indefinitely for the configSuccess to change
            bool configSuccessTemp = false;
            while (configSuccess == -1) // wait until the config success bool was sent from the uC and read from the serialPort
            {
            }
            configSuccessTemp = (configSuccess == 1);
            // config success bool was read from serial port => reset it for the next time
            configSuccess = -1;

            return configSuccessTemp;
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
                // check which measurement type is selected and send the corresponding cmd
                byte measType;
                bool continuousMeasurement; // store whether corresponding meas. is continuous or fixed duration
                string measDurationStr;   // obtain from the textBox [s]
                if (radioBtnConstV.Checked)
                {
                    measType = CommandSet.START_MEAS_CONST;
                    continuousMeasurement = checkBoxConstMeas.Checked;
                    measDurationStr = textBoxConstVDur.Text;
                }
                else if (radioBtnCV.Checked)
                {
                    measType = CommandSet.START_MEAS_CV;
                    continuousMeasurement = checkBoxCVMeas.Checked;
                    measDurationStr = textBoxCVDur.Text;
                }
                else // no measurement was selected => return
                {
                    MessageBox.Show("Select a measurement type (excitation signal) before clicking start.");
                    return;
                }
                
                float measDuration;
                if ((float.TryParse(measDurationStr, out measDuration) == false) && !continuousMeasurement)
                {
                    MessageBox.Show("Could not read the measurement duration as a decimal number. Check settings in the config tab.");
                    return;
                }

                try
                {
                    serialPort.Write(new byte[] {measType}, 0, 1);
                    textBoxLog.AppendText("START cmd sent" + Environment.NewLine);

                    //enable or disable buttons
                    startMeasBtn.Enabled = false;
                    if (continuousMeasurement)
                    {
                        // then measurement needs to be stopped manually
                        stopMeasBtn.Enabled = true;
                        textBoxLog.AppendText("Continuous measurement..." + Environment.NewLine + "\t=> stop manually" + Environment.NewLine);
                    }
                    else
                    {
                        // measurement stop based on the duration
                        stopMeasTimer.Interval = (int)(measDuration*1000);
                        stopMeasTimer.Start();
                        textBoxLog.AppendText("Running for " + measDuration.ToString() + " sec." + Environment.NewLine);
                    }
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

        /*
         * stops the selected measurement sequence that is running
         */
        private void stopMeasBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(new byte[] { CommandSet.STOP_MEAS }, 0, 1);
                    textBoxLog.AppendText("STOP cmd sent" + Environment.NewLine);

                    startMeasBtn.Enabled = true;
                    stopMeasBtn.Enabled = false;

                    // save Data ?
                    // update UI ? (buttons, etc.)
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
        private void stopMeasTimerFcn(object sender, EventArgs e)
        {
            stopMeasTimer.Stop();

            this.BeginInvoke(new Action(() =>
            {
                // call stop button function
                stopMeasBtn_Click(this, EventArgs.Empty);
            }));
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
                        textBoxLog.AppendText("Connected to " + selectedPort + Environment.NewLine);
                        comSelBox.BackColor = System.Drawing.Color.PaleGreen;
                    }
                }
                else
                {
                    serialPort.PortName = selectedPort;
                    serialPort.Open();
                    textBoxLog.AppendText("Connected to " + selectedPort + Environment.NewLine);
                    comSelBox.BackColor = System.Drawing.Color.PaleGreen;
                }

            }
        }

        //Refresh the com selection Box  
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            comSelBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                comSelBox.Items.AddRange(ports);
            }
        }

        private void measParamBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    readConfigData = true;  // mark that incoming data refers to config cmd return values
                    string logText = "";

                    // start config
                    serialPort.Write(new byte[] { CommandSet.START_CONFIG }, 0, 1);
                    textBoxLog.AppendText("Started parameter config" + Environment.NewLine);

                    // set voltage
                    string voltageStr = textBoxConstVoltage.Text;
                    if (Int32.TryParse(voltageStr, out int voltageInt))
                    {
                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(voltageInt);

                        // set voltage (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_VOLTAGE_STEP }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Voltage set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Voltage set to " + voltageStr + " mV";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid voltage integer within the correct range.");
                    }

                    // set duration not needed, as waiting is done in GUI, not on the uC

                    // stop config
                    serialPort.Write(new byte[] { CommandSet.STOP_CONFIG }, 0, 1);
                    logText = "Stop parameter config failed";
                    if (ConfigSuccess())
                    {
                        logText = "Stopped parameter config";
                    }
                    textBoxLog.AppendText(logText + Environment.NewLine);

                    readConfigData = false;
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
        private void cvMeasParamBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    readConfigData = true;  // mark that incoming data refers to config cmd return values
                    string logText = "";

                    // start config
                    serialPort.Write(new byte[] { CommandSet.START_CONFIG }, 0, 1);
                    textBoxLog.AppendText("Started parameter config" + Environment.NewLine);

                    // set voltage level 1
                    string voltage1Str = textBoxCVVoltage1.Text;
                    if (Int32.TryParse(voltage1Str, out int voltage1Int))
                    {
                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(voltage1Int);

                        // set voltage (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_VOLTAGE1_CV }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Voltage set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Voltage set to " + voltage1Str + " mV";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid voltage 1 integer within the correct range.");
                    }

                    // set voltage level 2
                    string voltage2Str = textBoxCVVoltage2.Text;
                    if (Int32.TryParse(voltage2Str, out int voltage2Int))
                    {
                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(voltage2Int);

                        // set voltage (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_VOLTAGE2_CV }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Voltage set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Voltage set to " + voltage2Str + " mV";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid voltage 2 integer within the correct range.");
                    }

                    // set slope duration
                    string slopeDurStr = textBoxCVSlopeDur.Text;
                    if (float.TryParse(slopeDurStr, out float slopeDurFloat))
                    {
                        // convert the float representing seconds [s] to int in microseconds [us]
                        Int32 slopeDurInt = (Int32)(slopeDurFloat*1000000);

                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(slopeDurInt);

                        // set voltage (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_SLOPE_TIME_CV }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Slope duration set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Slope duration set to " + slopeDurStr + " s";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid slope duration less than the maximum.");
                    }

                    // stop config
                    serialPort.Write(new byte[] { CommandSet.STOP_CONFIG }, 0, 1);
                    logText = "Stop parameter config failed";
                    if (ConfigSuccess())
                    {
                        logText = "Stopped parameter config";
                    }
                    textBoxLog.AppendText(logText + Environment.NewLine);

                    readConfigData = false;
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

        private void saveDataBut_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPath = dataPathBox.Text + "/" + fileNameBox.Text + measCounter + ".txt";

                //var writeDataX = string.Join(" ", dataPointsX);
                //var writeDataY = string.Join(" ", dataPointsY);
                //string[] writeData = { writeDataX, writeDataY };

                // Create an array to hold the lines
                string[] writeData = new string[dataPointsX.Count];

                // Populate the lines array
                for (int i = 0; i < dataPointsX.Count; i++)
                {
                    writeData[i] = $"{dataPointsX[i]} {dataPointsY[i]}";
                }
                // Write all lines to the file
                File.WriteAllLines(dataPath, writeData);
                textBoxLog.AppendText("Succesfull save of " + fileNameBox.Text + measCounter + ".txt" + Environment.NewLine);

                measCounter += 1;
            }
            catch
            {
                textBoxLog.AppendText("Saving not succesfull " + Environment.NewLine);
            }
        }

        private void checkBoxConstMeas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxConstMeas.Checked)
            {
                textBoxConstVDur.Enabled = false;
                labelConstVDur.Enabled = false;
            }
            else
            {
                textBoxConstVDur.Enabled = true;
                labelConstVDur.Enabled = true;
            }
        }

        private void checkBoxCVMeas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVMeas.Checked)
            {
                textBoxCVDur.Enabled = false;
                labelCVDur.Enabled = false;
            }
            else
            {
                textBoxCVDur.Enabled = true;
                labelCVDur.Enabled = true;
            }
        }
    }
}
