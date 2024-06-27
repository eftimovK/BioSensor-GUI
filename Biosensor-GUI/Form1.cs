using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
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
            textBoxLog.AppendText("Data receive" + Environment.NewLine);
        }

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
