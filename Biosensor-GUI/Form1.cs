using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Biosensor_GUI
{
    public partial class Form1 : Form
    {
        private int dataRxCount = 0;
        private int measCounter = 1;

        private int dataPointsMax = 4000;   // max. number of points displayed in the plot
        private int dataPointsPerSec = 1000;   // samples per second, determined by the sampling freq. on the uC
        List<double> dataPointsX = new List<double>();    // X-axis data for const voltage excitation & CV (time in sec.)
        List<double> dataPointsY = new List<double>();    // Y-axis data for const voltage excitation & CV (current in uA)
        List<double> xDataEIS = new List<double>();    // X-axis data for EIS (real part of measured impedance)
        List<double> yDataEIS = new List<double>();    // Y-axis data for EIS (imaginary part of measured impedance)
        List<int> freqDataEIS = new List<int>();    // frequencies for EIS, corresponding (index-wise) to the measured impedance
        bool readConfigData = false;                // marks whether the data received refers to the config cmds
        int configSuccess = -1;                     // -1 denotes that no return value (0 or 1) was read from the port
        private const int calibrationResistor = 1000;   // [Ohm]
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
        }
        private void InitializePlot()
        {
            // do inital plot displaying a cool curve, or draw the Aixsense logo (animation)

            // initial chart config

            chartPlot.ChartAreas[0].AxisX.Minimum = 0;  // address the first ChartArea
            chartPlot.ChartAreas[0].AxisX.Maximum = dataPointsMax / dataPointsPerSec;
            chartPlot.ChartAreas[0].AxisY.Minimum = 0;
            chartPlot.ChartAreas[0].AxisY.Maximum = 10;

            // add a point to the series to display the plot
            chartPlot.Series[0].Points.AddXY(0, 0); // address the first Series of the chart
        }
        private void SetupPlot(byte measType)
        {
            foreach (var series in chartPlot.Series)
            {
               series.Points.Clear();
            }

            /* const voltage setup:
                it receives a single value representing the current over time, 
                thus the x-axis display the past x amount of seconds.
            */
            if (measType == CommandSet.START_MEAS_CONST)
            {
                // clear data from previous measurement
                dataPointsX.Clear();
                dataPointsY.Clear();

                chartPlot.ChartAreas[0].AxisX.Minimum = 0;
                chartPlot.ChartAreas[0].AxisX.Maximum = dataPointsMax / dataPointsPerSec;
                chartPlot.ChartAreas[0].AxisY.Minimum = -50;
                chartPlot.ChartAreas[0].AxisY.Maximum = 50;

                // Custom labels for the x- & y-axis with 2 decimal places
                chartPlot.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
                chartPlot.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";

                chartPlot.ChartAreas[0].AxisX.Title = "Time [s]";
                chartPlot.ChartAreas[0].AxisY.Title = "Current [uA]";
            }

            /* CV setup:
                it receives a single value representing the current over the applied voltage, 
                which is swept between two values over multiple cycles. 
                Thus, in best case, we plot a separate curve for each cycle & add it in the legend.
            */
            if (measType == CommandSet.START_MEAS_CV)
            {
                // clear data from previous measurement
                dataPointsX.Clear();
                dataPointsY.Clear();

                // TODO: set x-axis limits based on the voltage range of the CV
                chartPlot.ChartAreas[0].AxisX.Minimum = 0;
                chartPlot.ChartAreas[0].AxisX.Maximum = dataPointsMax / dataPointsPerSec;
                // TODO: set y-axis limits based on the max/min current values
                chartPlot.ChartAreas[0].AxisY.Minimum = -50;
                chartPlot.ChartAreas[0].AxisY.Maximum = 50;

                // Custom labels for the x- & y-axis with 2 decimal places
                chartPlot.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
                chartPlot.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";
                
                chartPlot.ChartAreas[0].AxisX.Title = "Voltage [V]";
                chartPlot.ChartAreas[0].AxisY.Title = "Current [uA]";
            }

            /* EIS setup:
                it receives multiple values from which the real & imaginary part 
                of the measured impedance can be plotted, on the x- & y-axis correspondingly.
            */
            if (measType == CommandSet.START_MEAS_EIS)
            {
                chartPlot.ChartAreas[0].AxisX.Minimum = 0;
                chartPlot.ChartAreas[0].AxisX.Maximum = 10;
                chartPlot.ChartAreas[0].AxisY.Minimum = 0;
                chartPlot.ChartAreas[0].AxisY.Maximum = 10;

                chartPlot.ChartAreas[0].AxisX.Title = "Re {Zx}";
                chartPlot.ChartAreas[0].AxisY.Title = "Im {Zx}";
            }
        }
        private void emptyRxBuffer()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                if (serialPort.BytesToRead > 0)
                {
                    serialPort.DiscardInBuffer();
                }
            }
        }

        /*
         * When receiving Data from the serial port than this command is executed
         */
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // TODO: use an encoding for the data received; 
            //      => currently implemented for the measurement data received, but not for config return values
            
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

            int dataIdx = 0;    // index of the next data to be read from the dataValues array

            // parse data string, resulting in 1 byte (for ID) and an array of integers (data values)
            data = data.TrimEnd('\r', '\n');
            string[] stringValues = data.Split(':');
            int[] dataValues = new int[stringValues.Length];
            for (int i = 0; i < stringValues.Length; i++)
            {
                dataValues[i] = Convert.ToInt32(stringValues[i]);   // TODO: deal with stringValues that are not numbers
            }

            byte measurementID = Convert.ToByte(dataValues[dataIdx++]);

            // update plot
            if (measurementID == CommandSet.DATA_MEAS_CONST || measurementID == CommandSet.DATA_MEAS_CV)
            {
                /*  Constant voltage / amperometric :
                            receive :
                                ADC code of measured current
                            plot :
                                current [uA] against time [s]
                */
                
                int dacValue = dataValues[dataIdx++];   // DAC code of the measured current

                /* Map DAC to microamps based on figure 4 from the Amperometric Example / Application Note (AN-1281) */
                double slope = -0.004883;   // pre-calculated slope of current---DAC line
                double current_uA = Math.Round(100 + (dacValue - 12288) * slope, 2, MidpointRounding.AwayFromZero);   // 12288 is the decimal for '0x3000' (min. DAC code in hex)
                //current_uA *= 5;    // adjustment factor ?

                int currentDataCount = chartPlot.Series[0].Points.Count;
                double time_s = Math.Round((double)(currentDataCount) / dataPointsPerSec, 2, MidpointRounding.AwayFromZero); // 1000 == number of samples per second from the uC

                // add data to plot
                chartPlot.Series[0].Points.AddXY(time_s, current_uA);

                // store the new data in the data variables outside of the plot
                dataPointsY.Add(current_uA);
                dataPointsX.Add(time_s); 

                // scroll chart along with new data
                if (currentDataCount > dataPointsMax)
                {
                    chartPlot.ChartAreas[0].AxisX.Minimum = dataPointsX[currentDataCount - dataPointsMax - 1];
                    chartPlot.ChartAreas[0].AxisX.Maximum = dataPointsX[currentDataCount-1];
                }

                // set the y-axis limits within the min/max of the past values
                int lastValuesCount = Math.Min(currentDataCount, dataPointsMax );
                List<double> lastValues = dataPointsY.Skip(currentDataCount - lastValuesCount).ToList();

                double maxLastValues = lastValues.Max();
                double minLastValues = lastValues.Min();

                chartPlot.ChartAreas[0].AxisY.Minimum = minLastValues - 5;
                chartPlot.ChartAreas[0].AxisY.Maximum = maxLastValues + 5;
            }
            else if (measurementID == CommandSet.DATA_MEAS_EIS)
            {
                /*  EIS
                        receive : 
                            frequency
                            Rcal - real part
                            Rcal - imag part
                            Zm (measured impedance) - real part
                            Zm (measured impedance) - imag part
                        plot :
                            imag against real part of estimated unknown impedance
                */

                int frequency = dataValues[dataIdx++];
                int Rcal_re   = dataValues[dataIdx++];
                int Rcal_im   = dataValues[dataIdx++];
                int Zm_re     = dataValues[dataIdx++];
                int Zm_im     = dataValues[dataIdx++];

                // calc magnitude & phase of Rcal
                double Rcal_mag     = Math.Sqrt(Rcal_re*Rcal_re + Rcal_im*Rcal_im);
                double Rcal_phase   = Math.Atan2(Rcal_im, Rcal_re);
                // calc magnitude & phase of Zm
                double Zm_mag       = Math.Sqrt(Zm_re*Zm_re + Zm_im*Zm_im);
                double Zm_phase     = Math.Atan2(Zm_im, Zm_re);

                // calc magniture & phase of unknown impedance Zx:= |Rcal|/|Zm| * calibrationResistor
                double Zx_mag    = Rcal_mag/Zm_mag * calibrationResistor;
                if (Zm_mag == 0)    // TODO: handle Zx_mag of infinity
                {
                    Zx_mag = 0;
                }
                double Zx_phase  = Zm_phase - Rcal_phase;

                // for the plot we need Re(Zx) & Im(Zx), which we
                // finally calculate from the magnitude and phase of Zx
                double Zx_re = Math.Round(Zx_mag * Math.Cos(Zx_phase), 2, MidpointRounding.AwayFromZero);
                double Zx_im = Math.Round(Zx_mag * Math.Sin(Zx_phase), 2, MidpointRounding.AwayFromZero);

                // the real part is x-value
                // the imag part is y-value
                chartPlot.Series[0].Points.AddXY(Zx_re, Zx_im);

                // set the y-axis limits within the min/max of the max values
                if (Zx_re > chartPlot.ChartAreas[0].AxisX.Maximum) { 
                    chartPlot.ChartAreas[0].AxisX.Maximum = Zx_re + 50;
                }
                if (Zx_re < chartPlot.ChartAreas[0].AxisX.Minimum) { 
                    chartPlot.ChartAreas[0].AxisX.Minimum = Zx_re - 50;
                }
                if (Zx_im > chartPlot.ChartAreas[0].AxisY.Maximum) {
                    chartPlot.ChartAreas[0].AxisY.Maximum = Zx_im + 50;
                }
                if (Zx_im < chartPlot.ChartAreas[0].AxisY.Minimum)
                {
                    chartPlot.ChartAreas[0].AxisY.Minimum = Zx_im - 50;
                }

                xDataEIS.Add(Zx_re);
                yDataEIS.Add(Zx_im);
                freqDataEIS.Add(frequency);

                // how to plot/denote the frequency in the 2D Chart ? add annotation ?
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
                else if (radioBtnEIS.Checked)
                {
                    measType = CommandSet.START_MEAS_EIS;
                    continuousMeasurement = false;

                    // Duration is hard-coded in the firmware atm ! 
                    // AC excitation at each frequency lasts 1 seconds (+0.2s buffer?)
                    measDurationStr = "x";
                    if (Int32.TryParse(textBoxPointsEIS.Text, out int pointsEIS))
                    {
                        float tempDur = (float)(1.2* pointsEIS);
                        measDurationStr = tempDur.ToString();
                    }
                }
                else // no measurement was selected => return
                {
                    MessageBox.Show("Select a measurement type (excitation signal) before clicking start.");
                    return;
                }
                
                float measDuration;
                if ((float.TryParse(measDurationStr, out measDuration) == false) && !continuousMeasurement)
                {
                    MessageBox.Show("Could not read the measurement duration as a decimal number or the number of points for EIS as an integer.\nCheck settings in the config tab.");
                    return;
                }

                try
                {
                    serialPort.Write(new byte[] {measType}, 0, 1);
                    textBoxLog.AppendText("START cmd sent" + Environment.NewLine);

                    SetupPlot(measType);

                    //enable or disable buttons
                    startMeasBtn.Enabled = false;
                    // do not allow configuration while measuring
                    tabPageConfig.Enabled = false;
                    // do not allow changing the measurement type while measuring
                    groupBoxSignalType.Enabled = false;

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
                    if (radioBtnConstV.Checked || radioBtnCV.Checked)   // do not send STOP cmd for EIS measurement
                    {
                        serialPort.Write(new byte[] { CommandSet.STOP_MEAS }, 0, 1);
                        textBoxLog.AppendText("STOP cmd sent" + Environment.NewLine);
                    }

                    startMeasBtn.Enabled = true;
                    stopMeasBtn.Enabled = false;
                    tabPageConfig.Enabled = true;
                    groupBoxSignalType.Enabled = true;

                    saveDataBut.PerformClick();
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
                    // TODO: check that the values from input fields are within the correct range!

                    readConfigData = true;  // mark that incoming data refers to config cmd return values
                    string logText = "";

                    // empty the receive buffer
                     emptyRxBuffer();

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
                    // TODO: check that the values from input fields are within the correct range!

                    readConfigData = true;  // mark that incoming data refers to config cmd return values
                    string logText = "";

                    // empty the receive buffer
                    emptyRxBuffer();

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

                        // set slope time (1 byte as cmd ID + 4 bytes for the value)
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

        private void eisMeasParamBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // TODO: check that the values from input fields are within the correct range!

                    readConfigData = true;  // mark that incoming data refers to config cmd return values
                    string logText = "";

                    // empty the receive buffer
                    emptyRxBuffer();

                    // start config
                    serialPort.Write(new byte[] { CommandSet.START_CONFIG }, 0, 1);
                    textBoxLog.AppendText("Started parameter config" + Environment.NewLine);

                    // set AC voltage peak
                    string voltageStr = textBoxEISVoltage.Text;
                    if (float.TryParse(voltageStr, out float voltageFloat))
                    {
                        // convert the float representing milli [mV] to int in microvolts [uV]
                        Int32 voltageInt = (Int32)(voltageFloat * 1000 + 0.5);

                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(voltageInt);

                        // set voltage (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_VOLTAGE_EIS }, 0, 1);
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

                    // set EIS start frequency
                    string startFreqStr = textBoxStartFreqEIS.Text;
                    if (Int32.TryParse(startFreqStr, out int startFreqInt))
                    {
                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(startFreqInt);

                        // set frequency (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_START_FREQ_EIS }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Start frequency set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Start frequency set to " + startFreqStr + " Hz";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid start frequency in the correct range.");
                    }
                    // TODO: check that EIS stop frequency is larger than start frequency
                    // set EIS stop frequency
                    string stopFreqStr = textBoxStopFreqEIS.Text;
                    if (Int32.TryParse(stopFreqStr, out int stopFreqInt))
                    {
                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(stopFreqInt);

                        // set frequency (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_STOP_FREQ_EIS }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Stop frequency set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Stop frequency set to " + stopFreqStr + " Hz";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid stop frequency in the correct range.");
                    }
                    
                    // set number of frequency points (thereby the step frequency)
                    string freqPointsStr = textBoxPointsEIS.Text;
                    if (Int32.TryParse(freqPointsStr, out int freqPointsInt))
                    {
                        // get step frequency from the number of points
                        Int32 stepFreqInt = (stopFreqInt - startFreqInt) / freqPointsInt;

                        // Convert Int32 to byte array
                        byte[] intBytes = BitConverter.GetBytes(stepFreqInt);

                        // set frequency (1 byte as cmd ID + 4 bytes for the value)
                        serialPort.Write(new byte[] { CommandSet.SET_STEP_FREQ_EIS }, 0, 1);
                        serialPort.Write(intBytes, 0, intBytes.Length);

                        logText = "Step frequency set failed";
                        if (ConfigSuccess())
                        {
                            logText = "Step frequency set to " + stepFreqInt.ToString() + " Hz";
                        }
                        textBoxLog.AppendText(logText + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter an integer number of frequency points.");
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
          
            if (radioBtnConstV.Checked || radioBtnConstV.Checked) {

                try
                {
                    // TODO: differentiate saving results from all measurement types

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
            else if (radioBtnEIS.Checked)
            {
                try
                {
               
                    // TODO: differentiate saving results from all measurement types
                    string dataPath = dataPathBox.Text + "/" + fileNameBox.Text + measCounter + "EIS.txt";

                    // Create an array to hold the lines
                    string[] writeData = new string[xDataEIS.Count];

                    // Populate the lines array
                    for (int i = 0; i < xDataEIS.Count; i++)
                    {
                        writeData[i] = $"{xDataEIS[i]} {yDataEIS[i]} {freqDataEIS[i]}";
                    }
                    // Write all lines to the file
                    File.WriteAllLines(dataPath, writeData);
                    textBoxLog.AppendText("Succesfull save of " + fileNameBox.Text + measCounter + "EIS.txt" + Environment.NewLine);

                    measCounter += 1;
                }
                catch
                {
                    textBoxLog.AppendText("Saving not succesfull " + Environment.NewLine);
                }
               
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageInfo;
        }
    }
}