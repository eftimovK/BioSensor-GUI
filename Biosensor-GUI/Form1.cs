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

namespace Biosensor_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /*
         * When receiving Data from the serial port than this command is executed
         */
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            textBoxLog.AppendText("Data received" + Environment.NewLine);
        }

        /*
         * starts the predefined measurenment sequence
         */
        private void start_meas_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                byte cmdToSend = (byte)(1); // one means 'start-measurement'

                try
                {
                    serialPort.Write(new byte[] { cmdToSend }, 0, 1);
                    textBoxLog.AppendText("START cmd sent" + Environment.NewLine);

                    //enable or disable buttons
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

                if (serialPort.PortName != selectedPort && serialPort.IsOpen)
                {
                    serialPort.Close();
                    textBoxLog.AppendText("Disconnected from " + serialPort.PortName + Environment.NewLine);

                    serialPort.PortName = selectedPort;
                    serialPort.Open();
                    textBoxLog.AppendText("Connexted to " + serialPort.PortName + Environment.NewLine);
                }
                else
                {
                    serialPort.PortName = selectedPort;
                    serialPort.Open();
                    textBoxLog.AppendText("Connexted to " + serialPort.PortName + Environment.NewLine);
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
