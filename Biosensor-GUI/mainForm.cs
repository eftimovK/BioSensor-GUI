using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Biosensor_GUI
{
    public partial class MainForm : Form
    {
        private int dataRxCount = 0;
        private int measCounter = 1;
        private int measCounterEIS = 1;

        private int dataPointsMax = 4000;   // max. number of points displayed in the plot
        private int dataPointsPerSec = 1000;   // samples per second, determined by the sampling freq. on the uC
        List<double> dataPointsX = new List<double>();    // X-axis data for const voltage excitation & CV (time in sec.)
        List<double> dataPointsY = new List<double>();    // Y-axis data for const voltage excitation & CV (current in uA)
        List<List<double>> xDataEIS = new List<List<double>>();    // X-axis data for EIS (real part of measured impedance)
        List<List<double>> yDataEIS = new List<List<double>>();    // Y-axis data for EIS (imaginary part of measured impedance)
        List<List<int>> freqDataEIS = new List<List<int>>();    // frequencies for EIS, corresponding (index-wise) to the measured impedance
        bool readConfigData = false;                // marks whether the data received refers to the config cmds
        int configSuccess = -1;                     // -1 denotes that no return value (0 or 1) was read from the port
        private const int calibrationResistor = 1000;   // [Ohm]
        private System.Timers.Timer stopMeasTimer;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Logo_without_name_ico;

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

            chartPlot.ChartAreas[0].AxisX.Minimum = 30;  // address the first ChartArea
            chartPlot.ChartAreas[0].AxisX.Maximum = 300;
            chartPlot.ChartAreas[0].AxisY.Minimum = 10;
            chartPlot.ChartAreas[0].AxisY.Maximum = 30;

            // add a point to the series to display the plot
            // chartPlot.Series[0].Points.AddXY(50, 60); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(70, 120); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(120, 150); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(150, 180); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(220, 220); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(280, 330); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(300, 350); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(280, 330); // address the first Series of the chart
            // chartPlot.Series[0].Points.AddXY(300, 350); // address the first Series of the chart

            // plot calib. curve:
            // extracted coeff. from calib curve in matlab
            double a = 2.03622;
            double b = 2.94777;
            double c = 6.82633;
            for (int i=30; i<=300; i+=25)
            {
                double creaValue = (double)(1/b) * Math.Exp((double)((i - c) / a));
                double zValue = a * Math.Log(b * i) + c;
                zValue = Math.Round(zValue);
                creaValue = Math.Round(creaValue);
                chartPlot.Series[0].Points.AddXY(i, zValue); // address the first Series of the chart
            }

            chartPlot.ChartAreas[0].AxisY.Title = "Y [a.u.]";
            chartPlot.ChartAreas[0].AxisX.Title = "Creatinine [uM]";
        }
        private void SetupPlot(byte measType)
        {
            dataRxCount = 0;

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
                if (measCounterEIS == 1)
                {
                    // clear the initial plot to reuse for meas. points
                    chartPlot.Series[0].Points.Clear();

                    // set up axes
                    chartPlot.ChartAreas[0].AxisX.Minimum = 10;
                    chartPlot.ChartAreas[0].AxisX.Maximum = 20;
                    chartPlot.ChartAreas[0].AxisY.Minimum = -1;
                    chartPlot.ChartAreas[0].AxisY.Maximum = 10;

                    // Custom labels for the x- & y-axis with 2 decimal places
                    chartPlot.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
                    chartPlot.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";

                    chartPlot.ChartAreas[0].AxisX.Title = "Re {Zx}";
                    chartPlot.ChartAreas[0].AxisY.Title = "-Im {Zx}";
                }
                else if (measCounterEIS > 1)
                {
                    // create a new series
                    Series newSeries = new Series();

                    // set properties the same as the first one
                    newSeries.ChartArea = chartPlot.Series[0].ChartArea;
                    newSeries.BorderDashStyle = chartPlot.Series[0].BorderDashStyle;
                    newSeries.BorderWidth = chartPlot.Series[0].BorderWidth;
                    newSeries.ChartType = chartPlot.Series[0].ChartType;
                    newSeries.MarkerSize = chartPlot.Series[0].MarkerSize;
                    newSeries.MarkerStyle = chartPlot.Series[0].MarkerStyle;

                    chartPlot.Series.Add(newSeries);
                }
                // set legend name based on save file name
                chartPlot.Series[measCounterEIS - 1].Name = fileNameBox.Text + "_" + measCounterEIS.ToString();
                
                xDataEIS.Add(new List<double>());
                yDataEIS.Add(new List<double>());
                freqDataEIS.Add(new List<int>());
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

        // TODO: to get rid of this fcn, do a serialport read right after the Serial.Write
        // that waits for data to be received (+timeout)
        // and just do a quick return in the DataReceived() if the readConfigData is true
        //
        // OR...
        // just implement a timeout in the fcn as previously planned
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
            // TODO: separate data processing from plotting (e.g. by using a Data class)

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

                // change sign of the imaginary part, since the y-axis is flipped
                Zx_im = -Zx_im;

                // the real part is x-value
                // the imag part is y-value
                chartPlot.Series[measCounterEIS - 1].Points.AddXY(Zx_re, Zx_im);

                // set the y-axis limits within the min/max of the max values
                if (Zx_re > chartPlot.ChartAreas[0].AxisX.Maximum) { 
                    chartPlot.ChartAreas[0].AxisX.Maximum = Zx_re + 10;
                }
                if (Zx_re < chartPlot.ChartAreas[0].AxisX.Minimum) { 
                    chartPlot.ChartAreas[0].AxisX.Minimum = Zx_re - 10;
                }
                if (Zx_im > chartPlot.ChartAreas[0].AxisY.Maximum) {
                    chartPlot.ChartAreas[0].AxisY.Maximum = Zx_im + 10;
                }
                if (Zx_im < chartPlot.ChartAreas[0].AxisY.Minimum)
                {
                    chartPlot.ChartAreas[0].AxisY.Minimum = Zx_im - 10;
                }

                xDataEIS[measCounterEIS - 1].Add(Zx_re);
                yDataEIS[measCounterEIS - 1].Add(Zx_im);
                freqDataEIS[measCounterEIS - 1].Add(frequency);

                // how to plot/denote the frequency in the 2D Chart ? add annotation ?
            }
            dataRxCount++;
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
                    // AC excitation at each frequency lasts 2 seconds (+0.2s buffer?)
                    measDurationStr = "x";
                    if (Int32.TryParse(textBoxPointsEIS.Text, out int pointsEIS))
                    {
                        float tempDur = (float)(2.2* pointsEIS);
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
                    stopMeasBtn.Enabled = true;
                    // do not allow configuration while measuring
                    tabPageConfig.Enabled = false;
                    // do not allow changing the measurement type while measuring
                    groupBoxSignalType.Enabled = false;

                    if (continuousMeasurement)
                    {
                        // then measurement needs to be stopped manually
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

                    // calc & display crea value

                    // save measurement data
                    saveDataBut_Click(this, EventArgs.Empty);
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

            // call stop cmd iff the btn was not yet pressed (and thus disabled)
            // a btn press before timer elapses should be regarded as "Abort measurement"
            if (stopMeasBtn.Enabled)
            {
                // wait until we reach the amount of data expected by the data rate of the uC
                while (dataRxCount < dataPointsPerSec * (stopMeasTimer.Interval / 1000) && !radioBtnEIS.Checked)
                {
                    // TODO: implement timeout for this wait
                    Thread.Sleep(5);
                }
                this.BeginInvoke(new Action(() =>
                {
                    // call stop button function
                    stopMeasBtn_Click(this, EventArgs.Empty);
                }));
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
            if (serialPort == null || !serialPort.IsOpen)
            {
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // TODO: check that the values from input fields are within the correct range!

                readConfigData = true;  // mark that incoming data refers to config cmd return values
                string logText = "";

                // empty the receive buffer
                serialPort.EmptyRxBuffer();

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
        private void cvMeasParamBtn_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // TODO: check that the values from input fields are within the correct range!

                readConfigData = true;  // mark that incoming data refers to config cmd return values
                string logText = "";

                // empty the receive buffer
                serialPort.EmptyRxBuffer();

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

        private void eisMeasParamBtn_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // TODO: check that the values from input fields are within the correct range!

                readConfigData = true;  // mark that incoming data refers to config cmd return values
                string logText = "";

                // empty the receive buffer
                serialPort.EmptyRxBuffer();

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

                // set number of frequency points and the frequencies distributed between start- and stop-frequency
                string startFreqStr = textBoxStartFreqEIS.Text;
                string stopFreqStr = textBoxStopFreqEIS.Text;
                string freqPointsStr = textBoxPointsEIS.Text;
                if (Int32.TryParse(freqPointsStr, out int freqPointsInt) && Int32.TryParse(startFreqStr, out int startFreqInt) && Int32.TryParse(stopFreqStr, out int stopFreqInt))
                {
                    // Convert Int32 to byte array
                    byte[] intBytes = BitConverter.GetBytes(freqPointsInt);

                    // set frequency (1 byte as cmd ID + 4 bytes for the value)
                    serialPort.Write(new byte[] { CommandSet.SET_NUM_FREQ_EIS }, 0, 1);
                    serialPort.Write(intBytes, 0, intBytes.Length);

                    Int32[] frequenciesEIS = new Int32[freqPointsInt];
                    string logTextLinLog = "";
                    if (checkBoxLogDistribution.Checked)
                    {
                        logTextLinLog = "Logarithmically";
                        Utils.Logspace(startFreqInt, stopFreqInt, freqPointsInt, frequenciesEIS);
                    }
                    else // linear spacing of frequency range
                    {
                        logTextLinLog = "Linearly";
                        Utils.Linspace(startFreqInt, stopFreqInt, freqPointsInt, frequenciesEIS);
                    }

                    // send the frequency points
                    for (int i = 0; i < freqPointsInt; i++)
                    {
                        intBytes = BitConverter.GetBytes(frequenciesEIS[i]);
                        serialPort.Write(intBytes, 0, intBytes.Length);
                    }

                    logText = "Frequency points set failed";
                    if (ConfigSuccess())
                    {
                        logText = logTextLinLog + " distributed " + freqPointsStr + " frequency points;" + Environment.NewLine
                        + "--> range: " + startFreqStr + " - " + stopFreqStr + " Hz";
                    }
                    textBoxLog.AppendText(logText + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter integers for start/stop frequencies and the number of frequency points.");
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

        private void saveDataBut_Click(object sender, EventArgs e)
        {
            // TODO: separate measCounter for each measurement type

            if (radioBtnConstV.Checked || radioBtnCV.Checked)
            {
                string measTypeStr = "amperometric";
                if (radioBtnCV.Checked)
                    measTypeStr = "CV";
                try
                {

                    string dataPath = dataPathBox.Text + "/" + fileNameBox.Text + measTypeStr + measCounter + ".txt";

                    // Create an array to hold the lines
                    string[] writeData = new string[dataPointsX.Count];

                    // Populate the lines array
                    for (int i = 0; i < dataPointsX.Count; i++)
                    {
                        writeData[i] = $"{dataPointsX[i]} {dataPointsY[i]}";
                    }
                    // Write all lines to the file
                    File.WriteAllLines(dataPath, writeData);
                    textBoxLog.AppendText("Succesfull save of " + fileNameBox.Text + measTypeStr + measCounter + ".txt" + Environment.NewLine);

                    measCounter += 1;
                }
                catch
                {
                    textBoxLog.AppendText("Saving " + measTypeStr + " not succesfull " + Environment.NewLine);
                }
            }
            else if (radioBtnEIS.Checked)
            {
                try
                {
                    string dataPath = dataPathBox.Text + "/" + fileNameBox.Text + "EIS" + measCounterEIS + ".txt";

                    // Create an array to hold the lines
                    string[] writeData = new string[xDataEIS[measCounterEIS - 1].Count];

                    // Populate the lines array
                    for (int i = 0; i < xDataEIS[measCounterEIS - 1].Count; i++)
                    {
                        writeData[i] = $"{xDataEIS[measCounterEIS - 1][i]} {yDataEIS[measCounterEIS - 1][i]} {freqDataEIS[measCounterEIS - 1][i]}";
                    }
                    // Write all lines to the file
                    File.WriteAllLines(dataPath, writeData);
                    textBoxLog.AppendText("Succesfull save of " + fileNameBox.Text + "EIS" + measCounterEIS + ".txt" + Environment.NewLine);

                    measCounterEIS += 1;
                    // TODO: or maybe increase after this fcn call, in the stop btn click, so that even unsuccessfull save increments the measurement counter
                }
                catch
                {
                    textBoxLog.AppendText("Saving EIS not succesfull " + Environment.NewLine);
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

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}