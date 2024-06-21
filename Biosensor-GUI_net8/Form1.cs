using ScottPlot;
using System.Collections;
using System.IO;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biosensor_GUI
{
    public partial class Form1 : Form
    {
        // TODO: address every warning message

        private SerialPort serialPort;
        private int dataPointsMax = 4000;   // max. number of datapoints in the plot
        private int[] dataX;               // X-axis data (time or sample number)
        private int[] dataY;               // Y-axis data (received values)
        private int dataYmin = 32800;
        private int dataYmax = 32000;
        private ScottPlot.Plottables.DataStreamer streamerPlot;
        private bool receiveDataLogFlag = false;
        private bool serialReadFlag = false;    // true if serial read thread is active
        private Thread serialReadThread;
        readonly System.Windows.Forms.Timer UpdatePlotTimer = new() { Interval = 50, Enabled = true }; // TODO: start timer only when we start receiving data

        public Form1()
        {
            InitializeComponent();

            textBoxLog.AppendText("-----Log-----" + Environment.NewLine + Environment.NewLine);
            dataX = new int[dataPointsMax];
            dataY = new int[dataPointsMax];

            for (int i = 0; i < dataPointsMax; i++)
            {
                dataX[i] = i;
            }

            InitializePlot();
        }

        /*
         * Initializations
        */
        private void InitializeSerialPort(string portName)
        {
            serialPort = new SerialPort(portName);
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.Parity   = Parity.None;
            serialPort.StopBits = StopBits.One;
            
            serialPort.ReadTimeout = 3000;  // [ms]

            // needed to communicate with Arduino:
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;

            // serialPort.DataReceived += DataReceivedHandler; // Subscribe to the DataReceived event

            try
            {
                serialPort.Open();
                textBoxLog.AppendText("Connected to " + portName + Environment.NewLine);
                comSelectBox.BackColor = System.Drawing.Color.PaleGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializePlot()
        {
            UpdatePlotTimer.Tick += UpdatePlotTimer_Tick;
            streamerPlot = dataPlot.Plot.Add.DataStreamer(dataPointsMax);
            streamerPlot.Add(double.NaN);   // bottom label and x-axis not displayed properly if no data at start
            // dataPlot.Plot.Add.Scatter(dataX, dataY);
            dataPlot.Plot.Axes.SetLimits(0, dataPointsMax, 0, 100);
            dataPlot.Plot.Axes.Bottom.Label.Text = "Data Points";
            dataPlot.Plot.Axes.Left.Label.Text = "ADC code";
            dataPlot.Refresh();
        }

        private void UpdatePlotTimer_Tick(object sender, EventArgs e)
        {
            if (streamerPlot.CountTotal > dataPointsMax) // start shifting plot when we reach the end of the x-axis
                streamerPlot.ViewScrollLeft();
            dataPlot.Refresh();
        }

        /*
         * Data handling (receive and plot)
        */
        private void DataReceivedHandler()
        {
            while (serialReadFlag)
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    if (serialPort.BytesToRead > 0) // TODO: handle case: if no data is sent for a certain amount of time; set serialReadFlag to false and to do the same behaviour as STOP btn click
                    {
                        try
                        {
                            string data = serialPort.ReadLine();

                            // Update the UI in a thread-safe manner
                            Invoke(() =>
                            {
                                if (!receiveDataLogFlag)
                                {
                                    string receiveLog = "Started receiving data...";
                                    textBoxLog.AppendText(receiveLog + Environment.NewLine);
                                    receiveDataLogFlag = true;
                                }
                                if (!serialReadFlag)
                                    textBoxLog.AppendText("...stop after this final ReadLine()" + Environment.NewLine);

                                UpdateDataStreamPlot(data);

                            });
                        }
                        catch (TimeoutException)
                        {
                            Invoke(() =>
                            {
                                textBoxLog.AppendText("Stop by Timeout" + Environment.NewLine);
                            });
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error reading from serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            receiveDataLogFlag = false;
            // enable/disable buttons before closing the thread
            Invoke(() =>
            {
                StartBtn.Enabled = true;
                StopBtn.Enabled = false;
            });
        }

        private void UpdateDataStreamPlot(string data)
        {
            data = data.TrimEnd('\r', '\n');

            int newValue;
            bool res = Int32.TryParse(data, out newValue);

            if (res)
            {
                streamerPlot.Add(newValue);
                // TODO: set limits from min to max, but only from the last dataPointsMax of the streamerPlot
                dataPlot.Plot.Axes.SetLimits(0, dataPointsMax, streamerPlot.Data.DataMin - 10, streamerPlot.Data.DataMax + 10);
            }
        }

        /*
         * Button clicks
        */
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                byte cmdToSend = (byte)(1); // one means 'start-measurement'

                try
                {
                    serialPort.Write(new byte[] { cmdToSend }, 0, 1);
                    textBoxLog.AppendText("START cmd sent" + Environment.NewLine);

                    serialReadThread = new Thread(() => DataReceivedHandler() );  // do serial port read in separate thread
                    serialReadFlag = true;
                    serialReadThread.Start();

                    StartBtn.Enabled = false;
                    StopBtn.Enabled = true;
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                byte cmdToSend = (byte)(0); // zero means 'stop-measurement'

                try
                {
                    serialPort.Write(new byte[] { cmdToSend }, 0, 1);
                    textBoxLog.AppendText("STOP cmd sent" + Environment.NewLine);

                    serialReadFlag = false;

                    // start button enable takes place at the end of the thread function
                    // this ensures that the thread execution is over before we can start another one
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

        private void RefreshComPorts()
        {
            comSelectBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                comSelectBox.Items.AddRange(ports);
            }
        }

        private void comSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comSelectBox.SelectedItem != null)
            {
                string selectedPort = comSelectBox.SelectedItem.ToString();                

                if (serialPort != null && serialPort.IsOpen)
                {
                    string currentPort = serialPort.PortName;
                    if (selectedPort == currentPort)
                    {
                        // disconnect if we selected the currently open port
                        serialPort.Close();
                        textBoxLog.AppendText("Disconnected from " + currentPort + Environment.NewLine);
                        comSelectBox.BackColor = SystemColors.Window;
                    }
                    else
                    {
                        MessageBox.Show("Serial port " + currentPort + " is already open. Select it first to disconnect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    InitializeSerialPort(selectedPort);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // Refresh the list of COM ports when the picture box is clicked
            RefreshComPorts();
        }
    }
}
