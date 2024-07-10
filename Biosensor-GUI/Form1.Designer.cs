namespace Biosensor_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageMeasure = new System.Windows.Forms.TabPage();
            this.stopMeasBtn = new System.Windows.Forms.Button();
            this.saveDataBut = new System.Windows.Forms.Button();
            this.startFluidBtn = new System.Windows.Forms.Button();
            this.chartPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startMeasBtn = new System.Windows.Forms.Button();
            this.groupBoxSignalType = new System.Windows.Forms.GroupBox();
            this.radioBtnConstV = new System.Windows.Forms.RadioButton();
            this.radioBtnCV = new System.Windows.Forms.RadioButton();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.labelCVDur = new System.Windows.Forms.Label();
            this.textBoxCVDur = new System.Windows.Forms.TextBox();
            this.checkBoxCVMeas = new System.Windows.Forms.CheckBox();
            this.checkBoxConstMeas = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCVVoltage2 = new System.Windows.Forms.TextBox();
            this.cvMeasParamBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCVVoltage1 = new System.Windows.Forms.TextBox();
            this.textBoxCVSlopeDur = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataPathBox = new System.Windows.Forms.TextBox();
            this.comSelBox = new System.Windows.Forms.ComboBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.constMeasParamBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelConstVDur = new System.Windows.Forms.Label();
            this.textBoxConstVoltage = new System.Windows.Forms.TextBox();
            this.textBoxConstVDur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fluidParamBtn = new System.Windows.Forms.Button();
            this.textBoxPumpPressure = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPumpTime = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
            this.groupBoxSignalType.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DataReceived);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(620, 370);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 7);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageMeasure);
            this.tabControl2.Controls.Add(this.tabPageConfig);
            this.tabControl2.Location = new System.Drawing.Point(13, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1236, 826);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPageMeasure
            // 
            this.tabPageMeasure.Controls.Add(this.stopMeasBtn);
            this.tabPageMeasure.Controls.Add(this.saveDataBut);
            this.tabPageMeasure.Controls.Add(this.startFluidBtn);
            this.tabPageMeasure.Controls.Add(this.chartPlot);
            this.tabPageMeasure.Controls.Add(this.startMeasBtn);
            this.tabPageMeasure.Controls.Add(this.groupBoxSignalType);
            this.tabPageMeasure.Location = new System.Drawing.Point(4, 25);
            this.tabPageMeasure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMeasure.Name = "tabPageMeasure";
            this.tabPageMeasure.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMeasure.Size = new System.Drawing.Size(1228, 797);
            this.tabPageMeasure.TabIndex = 0;
            this.tabPageMeasure.Text = "Measure";
            this.tabPageMeasure.UseVisualStyleBackColor = true;
            // 
            // stopMeasBtn
            // 
            this.stopMeasBtn.Enabled = false;
            this.stopMeasBtn.Location = new System.Drawing.Point(512, 27);
            this.stopMeasBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopMeasBtn.Name = "stopMeasBtn";
            this.stopMeasBtn.Size = new System.Drawing.Size(96, 32);
            this.stopMeasBtn.TabIndex = 41;
            this.stopMeasBtn.Text = "STOP";
            this.stopMeasBtn.UseVisualStyleBackColor = true;
            this.stopMeasBtn.Click += new System.EventHandler(this.stopMeasBtn_Click);
            // 
            // saveDataBut
            // 
            this.saveDataBut.Location = new System.Drawing.Point(512, 95);
            this.saveDataBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveDataBut.Name = "saveDataBut";
            this.saveDataBut.Size = new System.Drawing.Size(96, 32);
            this.saveDataBut.TabIndex = 40;
            this.saveDataBut.Text = "Save Data";
            this.saveDataBut.UseVisualStyleBackColor = true;
            this.saveDataBut.Click += new System.EventHandler(this.saveDataBut_Click);
            // 
            // startFluidBtn
            // 
            this.startFluidBtn.Enabled = false;
            this.startFluidBtn.Location = new System.Drawing.Point(947, 49);
            this.startFluidBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startFluidBtn.Name = "startFluidBtn";
            this.startFluidBtn.Size = new System.Drawing.Size(184, 54);
            this.startFluidBtn.TabIndex = 24;
            this.startFluidBtn.Text = "Start Intermediate Fluid";
            this.startFluidBtn.UseVisualStyleBackColor = true;
            // 
            // chartPlot
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPlot.Legends.Add(legend1);
            this.chartPlot.Location = new System.Drawing.Point(27, 143);
            this.chartPlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartPlot.Name = "chartPlot";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Data Received";
            this.chartPlot.Series.Add(series1);
            this.chartPlot.Size = new System.Drawing.Size(1141, 592);
            this.chartPlot.TabIndex = 18;
            this.chartPlot.Text = "chart1";
            // 
            // startMeasBtn
            // 
            this.startMeasBtn.Location = new System.Drawing.Point(264, 39);
            this.startMeasBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startMeasBtn.Name = "startMeasBtn";
            this.startMeasBtn.Size = new System.Drawing.Size(211, 75);
            this.startMeasBtn.TabIndex = 0;
            this.startMeasBtn.Text = "Start Measurement";
            this.startMeasBtn.UseVisualStyleBackColor = true;
            this.startMeasBtn.Click += new System.EventHandler(this.startMeasBtn_Click);
            // 
            // groupBoxSignalType
            // 
            this.groupBoxSignalType.Controls.Add(this.radioBtnConstV);
            this.groupBoxSignalType.Controls.Add(this.radioBtnCV);
            this.groupBoxSignalType.Location = new System.Drawing.Point(27, 27);
            this.groupBoxSignalType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSignalType.Name = "groupBoxSignalType";
            this.groupBoxSignalType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSignalType.Size = new System.Drawing.Size(203, 110);
            this.groupBoxSignalType.TabIndex = 45;
            this.groupBoxSignalType.TabStop = false;
            this.groupBoxSignalType.Text = "Excitation Signal";
            // 
            // radioBtnConstV
            // 
            this.radioBtnConstV.AutoSize = true;
            this.radioBtnConstV.Location = new System.Drawing.Point(24, 39);
            this.radioBtnConstV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioBtnConstV.Name = "radioBtnConstV";
            this.radioBtnConstV.Size = new System.Drawing.Size(108, 20);
            this.radioBtnConstV.TabIndex = 46;
            this.radioBtnConstV.TabStop = true;
            this.radioBtnConstV.Text = "const voltage";
            this.radioBtnConstV.UseVisualStyleBackColor = true;
            // 
            // radioBtnCV
            // 
            this.radioBtnCV.AutoSize = true;
            this.radioBtnCV.Location = new System.Drawing.Point(24, 70);
            this.radioBtnCV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioBtnCV.Name = "radioBtnCV";
            this.radioBtnCV.Size = new System.Drawing.Size(138, 20);
            this.radioBtnCV.TabIndex = 0;
            this.radioBtnCV.TabStop = true;
            this.radioBtnCV.Text = "cyclic voltammetry";
            this.radioBtnCV.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.labelCVDur);
            this.tabPageConfig.Controls.Add(this.textBoxCVDur);
            this.tabPageConfig.Controls.Add(this.checkBoxCVMeas);
            this.tabPageConfig.Controls.Add(this.checkBoxConstMeas);
            this.tabPageConfig.Controls.Add(this.label13);
            this.tabPageConfig.Controls.Add(this.textBoxCVVoltage2);
            this.tabPageConfig.Controls.Add(this.cvMeasParamBtn);
            this.tabPageConfig.Controls.Add(this.label8);
            this.tabPageConfig.Controls.Add(this.label11);
            this.tabPageConfig.Controls.Add(this.textBoxCVVoltage1);
            this.tabPageConfig.Controls.Add(this.textBoxCVSlopeDur);
            this.tabPageConfig.Controls.Add(this.label12);
            this.tabPageConfig.Controls.Add(this.label3);
            this.tabPageConfig.Controls.Add(this.label10);
            this.tabPageConfig.Controls.Add(this.fileNameBox);
            this.tabPageConfig.Controls.Add(this.label4);
            this.tabPageConfig.Controls.Add(this.dataPathBox);
            this.tabPageConfig.Controls.Add(this.comSelBox);
            this.tabPageConfig.Controls.Add(this.refreshBtn);
            this.tabPageConfig.Controls.Add(this.constMeasParamBtn);
            this.tabPageConfig.Controls.Add(this.label7);
            this.tabPageConfig.Controls.Add(this.labelConstVDur);
            this.tabPageConfig.Controls.Add(this.textBoxConstVoltage);
            this.tabPageConfig.Controls.Add(this.textBoxConstVDur);
            this.tabPageConfig.Controls.Add(this.label1);
            this.tabPageConfig.Controls.Add(this.fluidParamBtn);
            this.tabPageConfig.Controls.Add(this.textBoxPumpPressure);
            this.tabPageConfig.Controls.Add(this.label9);
            this.tabPageConfig.Controls.Add(this.label5);
            this.tabPageConfig.Controls.Add(this.label2);
            this.tabPageConfig.Controls.Add(this.textBoxPumpTime);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageConfig.Size = new System.Drawing.Size(1228, 797);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // labelCVDur
            // 
            this.labelCVDur.AutoSize = true;
            this.labelCVDur.Location = new System.Drawing.Point(691, 208);
            this.labelCVDur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCVDur.Name = "labelCVDur";
            this.labelCVDur.Size = new System.Drawing.Size(75, 16);
            this.labelCVDur.TabIndex = 57;
            this.labelCVDur.Text = "Duration [s]";
            // 
            // textBoxCVDur
            // 
            this.textBoxCVDur.Location = new System.Drawing.Point(472, 199);
            this.textBoxCVDur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCVDur.Name = "textBoxCVDur";
            this.textBoxCVDur.Size = new System.Drawing.Size(192, 22);
            this.textBoxCVDur.TabIndex = 56;
            this.textBoxCVDur.Text = "10";
            this.textBoxCVDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxCVMeas
            // 
            this.checkBoxCVMeas.AutoSize = true;
            this.checkBoxCVMeas.Location = new System.Drawing.Point(515, 276);
            this.checkBoxCVMeas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCVMeas.Name = "checkBoxCVMeas";
            this.checkBoxCVMeas.Size = new System.Drawing.Size(103, 20);
            this.checkBoxCVMeas.TabIndex = 55;
            this.checkBoxCVMeas.Text = "continuous ?";
            this.checkBoxCVMeas.UseVisualStyleBackColor = true;
            this.checkBoxCVMeas.CheckedChanged += new System.EventHandler(this.checkBoxCVMeas_CheckedChanged);
            // 
            // checkBoxConstMeas
            // 
            this.checkBoxConstMeas.AutoSize = true;
            this.checkBoxConstMeas.Location = new System.Drawing.Point(120, 182);
            this.checkBoxConstMeas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxConstMeas.Name = "checkBoxConstMeas";
            this.checkBoxConstMeas.Size = new System.Drawing.Size(103, 20);
            this.checkBoxConstMeas.TabIndex = 54;
            this.checkBoxConstMeas.Text = "continuous ?";
            this.checkBoxConstMeas.UseVisualStyleBackColor = true;
            this.checkBoxConstMeas.CheckedChanged += new System.EventHandler(this.checkBoxConstMeas_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(691, 158);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 53;
            this.label13.Text = "Voltage 2 [mV]";
            // 
            // textBoxCVVoltage2
            // 
            this.textBoxCVVoltage2.Location = new System.Drawing.Point(472, 154);
            this.textBoxCVVoltage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCVVoltage2.Name = "textBoxCVVoltage2";
            this.textBoxCVVoltage2.Size = new System.Drawing.Size(192, 22);
            this.textBoxCVVoltage2.TabIndex = 52;
            this.textBoxCVVoltage2.Text = "100";
            this.textBoxCVVoltage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cvMeasParamBtn
            // 
            this.cvMeasParamBtn.Location = new System.Drawing.Point(481, 324);
            this.cvMeasParamBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cvMeasParamBtn.Name = "cvMeasParamBtn";
            this.cvMeasParamBtn.Size = new System.Drawing.Size(172, 91);
            this.cvMeasParamBtn.TabIndex = 51;
            this.cvMeasParamBtn.Text = "Change Parameters";
            this.cvMeasParamBtn.UseVisualStyleBackColor = true;
            this.cvMeasParamBtn.Click += new System.EventHandler(this.cvMeasParamBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(691, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "Voltage 1 [mV]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(689, 245);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 32);
            this.label11.TabIndex = 49;
            this.label11.Text = "Slope Duration [s]\r\n     (max. 1.6 s)";
            // 
            // textBoxCVVoltage1
            // 
            this.textBoxCVVoltage1.Location = new System.Drawing.Point(472, 112);
            this.textBoxCVVoltage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCVVoltage1.Name = "textBoxCVVoltage1";
            this.textBoxCVVoltage1.Size = new System.Drawing.Size(192, 22);
            this.textBoxCVVoltage1.TabIndex = 48;
            this.textBoxCVVoltage1.Text = "0";
            this.textBoxCVVoltage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCVSlopeDur
            // 
            this.textBoxCVSlopeDur.Location = new System.Drawing.Point(471, 240);
            this.textBoxCVSlopeDur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCVSlopeDur.Name = "textBoxCVSlopeDur";
            this.textBoxCVSlopeDur.Size = new System.Drawing.Size(192, 22);
            this.textBoxCVSlopeDur.TabIndex = 47;
            this.textBoxCVSlopeDur.Text = "1";
            this.textBoxCVSlopeDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(477, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 25);
            this.label12.TabIndex = 46;
            this.label12.Text = "CV Measurement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(872, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "USB connection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(872, 240);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "File Name";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(875, 261);
            this.fileNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileNameBox.Multiline = true;
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(207, 67);
            this.fileNameBox.TabIndex = 43;
            this.fileNameBox.Text = "Measurement ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(872, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Data Path";
            // 
            // dataPathBox
            // 
            this.dataPathBox.Location = new System.Drawing.Point(875, 166);
            this.dataPathBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataPathBox.Multiline = true;
            this.dataPathBox.Name = "dataPathBox";
            this.dataPathBox.Size = new System.Drawing.Size(207, 67);
            this.dataPathBox.TabIndex = 41;
            this.dataPathBox.Text = "C:\\Users\\Isaac\\Documents\\Studium\\SensUs\\Data\\SensUsGui";
            // 
            // comSelBox
            // 
            this.comSelBox.FormattingEnabled = true;
            this.comSelBox.Location = new System.Drawing.Point(875, 85);
            this.comSelBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comSelBox.Name = "comSelBox";
            this.comSelBox.Size = new System.Drawing.Size(183, 24);
            this.comSelBox.TabIndex = 40;
            this.comSelBox.SelectedIndexChanged += new System.EventHandler(this.comSelBox_SelectedIndexChanged);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(1076, 80);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(96, 32);
            this.refreshBtn.TabIndex = 39;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // constMeasParamBtn
            // 
            this.constMeasParamBtn.Location = new System.Drawing.Point(84, 226);
            this.constMeasParamBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.constMeasParamBtn.Name = "constMeasParamBtn";
            this.constMeasParamBtn.Size = new System.Drawing.Size(172, 91);
            this.constMeasParamBtn.TabIndex = 37;
            this.constMeasParamBtn.Text = "Change Parameters";
            this.constMeasParamBtn.UseVisualStyleBackColor = true;
            this.constMeasParamBtn.Click += new System.EventHandler(this.measParamBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Voltage [mV]";
            // 
            // labelConstVDur
            // 
            this.labelConstVDur.AutoSize = true;
            this.labelConstVDur.Location = new System.Drawing.Point(291, 154);
            this.labelConstVDur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConstVDur.Name = "labelConstVDur";
            this.labelConstVDur.Size = new System.Drawing.Size(75, 16);
            this.labelConstVDur.TabIndex = 34;
            this.labelConstVDur.Text = "Duration [s]";
            // 
            // textBoxConstVoltage
            // 
            this.textBoxConstVoltage.Location = new System.Drawing.Point(75, 112);
            this.textBoxConstVoltage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxConstVoltage.Name = "textBoxConstVoltage";
            this.textBoxConstVoltage.Size = new System.Drawing.Size(192, 22);
            this.textBoxConstVoltage.TabIndex = 31;
            this.textBoxConstVoltage.Text = "0";
            this.textBoxConstVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxConstVDur
            // 
            this.textBoxConstVDur.Location = new System.Drawing.Point(75, 149);
            this.textBoxConstVDur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxConstVDur.Name = "textBoxConstVDur";
            this.textBoxConstVDur.Size = new System.Drawing.Size(192, 22);
            this.textBoxConstVDur.TabIndex = 30;
            this.textBoxConstVDur.Text = "10";
            this.textBoxConstVDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Const. Voltage Measurement";
            // 
            // fluidParamBtn
            // 
            this.fluidParamBtn.Enabled = false;
            this.fluidParamBtn.Location = new System.Drawing.Point(85, 609);
            this.fluidParamBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluidParamBtn.Name = "fluidParamBtn";
            this.fluidParamBtn.Size = new System.Drawing.Size(171, 91);
            this.fluidParamBtn.TabIndex = 27;
            this.fluidParamBtn.Text = "Change Parameters";
            this.fluidParamBtn.UseVisualStyleBackColor = true;
            // 
            // textBoxPumpPressure
            // 
            this.textBoxPumpPressure.Enabled = false;
            this.textBoxPumpPressure.Location = new System.Drawing.Point(75, 553);
            this.textBoxPumpPressure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPumpPressure.Name = "textBoxPumpPressure";
            this.textBoxPumpPressure.Size = new System.Drawing.Size(192, 22);
            this.textBoxPumpPressure.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(276, 512);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Pump time [s]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(276, 556);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pump pressure ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 450);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Pump";
            // 
            // textBoxPumpTime
            // 
            this.textBoxPumpTime.Enabled = false;
            this.textBoxPumpTime.Location = new System.Drawing.Point(75, 508);
            this.textBoxPumpTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPumpTime.Name = "textBoxPumpTime";
            this.textBoxPumpTime.Size = new System.Drawing.Size(192, 22);
            this.textBoxPumpTime.TabIndex = 22;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(1272, 170);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(223, 242);
            this.textBoxLog.TabIndex = 39;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(484, 0);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(11, 10);
            this.tabControl3.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Size = new System.Drawing.Size(3, 0);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Size = new System.Drawing.Size(3, 0);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 849);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).EndInit();
            this.groupBoxSignalType.ResumeLayout(false);
            this.groupBoxSignalType.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageMeasure;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.Button startMeasBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlot;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button startFluidBtn;
        private System.Windows.Forms.Button fluidParamBtn;
        private System.Windows.Forms.TextBox textBoxPumpPressure;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPumpTime;
        private System.Windows.Forms.Button constMeasParamBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelConstVDur;
        private System.Windows.Forms.TextBox textBoxConstVoltage;
        private System.Windows.Forms.TextBox textBoxConstVDur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSelBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button saveDataBut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataPathBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCVVoltage2;
        private System.Windows.Forms.Button cvMeasParamBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxCVVoltage1;
        private System.Windows.Forms.TextBox textBoxCVSlopeDur;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBoxCVMeas;
        private System.Windows.Forms.CheckBox checkBoxConstMeas;
        private System.Windows.Forms.Button stopMeasBtn;
        private System.Windows.Forms.GroupBox groupBoxSignalType;
        private System.Windows.Forms.RadioButton radioBtnConstV;
        private System.Windows.Forms.RadioButton radioBtnCV;
        private System.Windows.Forms.TextBox textBoxCVDur;
        private System.Windows.Forms.Label labelCVDur;
    }
}

