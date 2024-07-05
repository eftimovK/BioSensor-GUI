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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageMeasure = new System.Windows.Forms.TabPage();
            this.saveDataBut = new System.Windows.Forms.Button();
            this.startFluidBtn = new System.Windows.Forms.Button();
            this.chartPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startMeasBtn = new System.Windows.Forms.Button();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
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
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxConstVoltage = new System.Windows.Forms.TextBox();
            this.textBoxConstMeasDur = new System.Windows.Forms.TextBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSignalType = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
            this.tabPageConfig.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.groupBoxSignalType.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(465, 301);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(6, 6);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageMeasure);
            this.tabControl2.Controls.Add(this.tabPageConfig);
            this.tabControl2.Location = new System.Drawing.Point(10, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(927, 671);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPageMeasure
            // 
            this.tabPageMeasure.Controls.Add(this.button1);
            this.tabPageMeasure.Controls.Add(this.saveDataBut);
            this.tabPageMeasure.Controls.Add(this.startFluidBtn);
            this.tabPageMeasure.Controls.Add(this.chartPlot);
            this.tabPageMeasure.Controls.Add(this.startMeasBtn);
            this.tabPageMeasure.Controls.Add(this.groupBoxSignalType);
            this.tabPageMeasure.Location = new System.Drawing.Point(4, 22);
            this.tabPageMeasure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMeasure.Name = "tabPageMeasure";
            this.tabPageMeasure.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMeasure.Size = new System.Drawing.Size(919, 645);
            this.tabPageMeasure.TabIndex = 0;
            this.tabPageMeasure.Text = "Measure";
            this.tabPageMeasure.UseVisualStyleBackColor = true;
            // 
            // saveDataBut
            // 
            this.saveDataBut.Location = new System.Drawing.Point(384, 77);
            this.saveDataBut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveDataBut.Name = "saveDataBut";
            this.saveDataBut.Size = new System.Drawing.Size(72, 26);
            this.saveDataBut.TabIndex = 40;
            this.saveDataBut.Text = "Save Data";
            this.saveDataBut.UseVisualStyleBackColor = true;
            this.saveDataBut.Click += new System.EventHandler(this.saveDataBut_Click);
            // 
            // startFluidBtn
            // 
            this.startFluidBtn.Enabled = false;
            this.startFluidBtn.Location = new System.Drawing.Point(710, 40);
            this.startFluidBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startFluidBtn.Name = "startFluidBtn";
            this.startFluidBtn.Size = new System.Drawing.Size(138, 44);
            this.startFluidBtn.TabIndex = 24;
            this.startFluidBtn.Text = "Start Intermediate Fluid";
            this.startFluidBtn.UseVisualStyleBackColor = true;
            // 
            // chartPlot
            // 
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPlot.Legends.Add(legend3);
            this.chartPlot.Location = new System.Drawing.Point(20, 116);
            this.chartPlot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartPlot.Name = "chartPlot";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Data Received";
            this.chartPlot.Series.Add(series3);
            this.chartPlot.Size = new System.Drawing.Size(856, 481);
            this.chartPlot.TabIndex = 18;
            this.chartPlot.Text = "chart1";
            // 
            // startMeasBtn
            // 
            this.startMeasBtn.Location = new System.Drawing.Point(198, 32);
            this.startMeasBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startMeasBtn.Name = "startMeasBtn";
            this.startMeasBtn.Size = new System.Drawing.Size(158, 61);
            this.startMeasBtn.TabIndex = 0;
            this.startMeasBtn.Text = "Start Measurement";
            this.startMeasBtn.UseVisualStyleBackColor = true;
            this.startMeasBtn.Click += new System.EventHandler(this.startMeasBtn_Click);
            // 
            // tabPageConfig
            // 
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
            this.tabPageConfig.Controls.Add(this.label6);
            this.tabPageConfig.Controls.Add(this.textBoxConstVoltage);
            this.tabPageConfig.Controls.Add(this.textBoxConstMeasDur);
            this.tabPageConfig.Controls.Add(this.label1);
            this.tabPageConfig.Controls.Add(this.fluidParamBtn);
            this.tabPageConfig.Controls.Add(this.textBoxPumpPressure);
            this.tabPageConfig.Controls.Add(this.label9);
            this.tabPageConfig.Controls.Add(this.label5);
            this.tabPageConfig.Controls.Add(this.label2);
            this.tabPageConfig.Controls.Add(this.textBoxPumpTime);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConfig.Size = new System.Drawing.Size(919, 645);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // checkBoxCVMeas
            // 
            this.checkBoxCVMeas.AutoSize = true;
            this.checkBoxCVMeas.Location = new System.Drawing.Point(387, 184);
            this.checkBoxCVMeas.Name = "checkBoxCVMeas";
            this.checkBoxCVMeas.Size = new System.Drawing.Size(87, 17);
            this.checkBoxCVMeas.TabIndex = 55;
            this.checkBoxCVMeas.Text = "continuous ?";
            this.checkBoxCVMeas.UseVisualStyleBackColor = true;
            // 
            // checkBoxConstMeas
            // 
            this.checkBoxConstMeas.AutoSize = true;
            this.checkBoxConstMeas.Location = new System.Drawing.Point(90, 148);
            this.checkBoxConstMeas.Name = "checkBoxConstMeas";
            this.checkBoxConstMeas.Size = new System.Drawing.Size(87, 17);
            this.checkBoxConstMeas.TabIndex = 54;
            this.checkBoxConstMeas.Text = "continuous ?";
            this.checkBoxConstMeas.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(518, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Voltage 2 [mV]";
            // 
            // textBoxCVVoltage2
            // 
            this.textBoxCVVoltage2.Location = new System.Drawing.Point(354, 125);
            this.textBoxCVVoltage2.Name = "textBoxCVVoltage2";
            this.textBoxCVVoltage2.Size = new System.Drawing.Size(145, 20);
            this.textBoxCVVoltage2.TabIndex = 52;
            this.textBoxCVVoltage2.Text = "100";
            this.textBoxCVVoltage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cvMeasParamBtn
            // 
            this.cvMeasParamBtn.Location = new System.Drawing.Point(362, 223);
            this.cvMeasParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cvMeasParamBtn.Name = "cvMeasParamBtn";
            this.cvMeasParamBtn.Size = new System.Drawing.Size(129, 74);
            this.cvMeasParamBtn.TabIndex = 51;
            this.cvMeasParamBtn.Text = "Change Parameters";
            this.cvMeasParamBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Voltage 1 [mV]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 26);
            this.label11.TabIndex = 49;
            this.label11.Text = "Slope Duration [s]\r\n     (max. 1.6 s)";
            // 
            // textBoxCVVoltage1
            // 
            this.textBoxCVVoltage1.Location = new System.Drawing.Point(354, 91);
            this.textBoxCVVoltage1.Name = "textBoxCVVoltage1";
            this.textBoxCVVoltage1.Size = new System.Drawing.Size(145, 20);
            this.textBoxCVVoltage1.TabIndex = 48;
            this.textBoxCVVoltage1.Text = "0";
            this.textBoxCVVoltage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCVSlopeDur
            // 
            this.textBoxCVSlopeDur.Location = new System.Drawing.Point(354, 155);
            this.textBoxCVSlopeDur.Name = "textBoxCVSlopeDur";
            this.textBoxCVSlopeDur.Size = new System.Drawing.Size(145, 20);
            this.textBoxCVSlopeDur.TabIndex = 47;
            this.textBoxCVSlopeDur.Text = "1";
            this.textBoxCVSlopeDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(358, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "CV Measurement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "USB connection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(654, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "File Name";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(656, 212);
            this.fileNameBox.Multiline = true;
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(156, 55);
            this.fileNameBox.TabIndex = 43;
            this.fileNameBox.Text = "Measurement ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Data Path";
            // 
            // dataPathBox
            // 
            this.dataPathBox.Location = new System.Drawing.Point(656, 135);
            this.dataPathBox.Multiline = true;
            this.dataPathBox.Name = "dataPathBox";
            this.dataPathBox.Size = new System.Drawing.Size(156, 55);
            this.dataPathBox.TabIndex = 41;
            this.dataPathBox.Text = "C:\\Users\\Isaac\\Documents\\Studium\\SensUs\\Data\\SensUsGui";
            // 
            // comSelBox
            // 
            this.comSelBox.FormattingEnabled = true;
            this.comSelBox.Location = new System.Drawing.Point(656, 69);
            this.comSelBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comSelBox.Name = "comSelBox";
            this.comSelBox.Size = new System.Drawing.Size(138, 21);
            this.comSelBox.TabIndex = 40;
            this.comSelBox.SelectedIndexChanged += new System.EventHandler(this.comSelBox_SelectedIndexChanged);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(807, 65);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(72, 26);
            this.refreshBtn.TabIndex = 39;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // constMeasParamBtn
            // 
            this.constMeasParamBtn.Location = new System.Drawing.Point(63, 184);
            this.constMeasParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.constMeasParamBtn.Name = "constMeasParamBtn";
            this.constMeasParamBtn.Size = new System.Drawing.Size(129, 74);
            this.constMeasParamBtn.TabIndex = 37;
            this.constMeasParamBtn.Text = "Change Parameters";
            this.constMeasParamBtn.UseVisualStyleBackColor = true;
            this.constMeasParamBtn.Click += new System.EventHandler(this.measParamBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Voltage [mV]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Duration [s]";
            // 
            // textBoxConstVoltage
            // 
            this.textBoxConstVoltage.Location = new System.Drawing.Point(56, 91);
            this.textBoxConstVoltage.Name = "textBoxConstVoltage";
            this.textBoxConstVoltage.Size = new System.Drawing.Size(145, 20);
            this.textBoxConstVoltage.TabIndex = 31;
            this.textBoxConstVoltage.Text = "0";
            this.textBoxConstVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxConstMeasDur
            // 
            this.textBoxConstMeasDur.Location = new System.Drawing.Point(56, 121);
            this.textBoxConstMeasDur.Name = "textBoxConstMeasDur";
            this.textBoxConstMeasDur.Size = new System.Drawing.Size(145, 20);
            this.textBoxConstMeasDur.TabIndex = 30;
            this.textBoxConstMeasDur.Text = "10";
            this.textBoxConstMeasDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Const. Voltage Measurement";
            // 
            // fluidParamBtn
            // 
            this.fluidParamBtn.Enabled = false;
            this.fluidParamBtn.Location = new System.Drawing.Point(64, 495);
            this.fluidParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fluidParamBtn.Name = "fluidParamBtn";
            this.fluidParamBtn.Size = new System.Drawing.Size(128, 74);
            this.fluidParamBtn.TabIndex = 27;
            this.fluidParamBtn.Text = "Change Parameters";
            this.fluidParamBtn.UseVisualStyleBackColor = true;
            // 
            // textBoxPumpPressure
            // 
            this.textBoxPumpPressure.Enabled = false;
            this.textBoxPumpPressure.Location = new System.Drawing.Point(56, 449);
            this.textBoxPumpPressure.Name = "textBoxPumpPressure";
            this.textBoxPumpPressure.Size = new System.Drawing.Size(145, 20);
            this.textBoxPumpPressure.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(207, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Pump time [s]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(207, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pump pressure ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Pump";
            // 
            // textBoxPumpTime
            // 
            this.textBoxPumpTime.Enabled = false;
            this.textBoxPumpTime.Location = new System.Drawing.Point(56, 413);
            this.textBoxPumpTime.Name = "textBoxPumpTime";
            this.textBoxPumpTime.Size = new System.Drawing.Size(145, 20);
            this.textBoxPumpTime.TabIndex = 22;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(954, 138);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(168, 197);
            this.textBoxLog.TabIndex = 39;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(363, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(8, 8);
            this.tabControl3.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage5.Size = new System.Drawing.Size(0, 0);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage6.Size = new System.Drawing.Size(0, 0);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 26);
            this.button1.TabIndex = 41;
            this.button1.Text = "STOP";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSignalType
            // 
            this.groupBoxSignalType.Controls.Add(this.radioButton3);
            this.groupBoxSignalType.Controls.Add(this.radioButton2);
            this.groupBoxSignalType.Location = new System.Drawing.Point(20, 22);
            this.groupBoxSignalType.Name = "groupBoxSignalType";
            this.groupBoxSignalType.Size = new System.Drawing.Size(152, 89);
            this.groupBoxSignalType.TabIndex = 45;
            this.groupBoxSignalType.TabStop = false;
            this.groupBoxSignalType.Text = "Excitation Signal";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "cyclic voltammetry";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(18, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(89, 17);
            this.radioButton3.TabIndex = 46;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "const voltage";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 690);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).EndInit();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.groupBoxSignalType.ResumeLayout(false);
            this.groupBoxSignalType.PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxConstVoltage;
        private System.Windows.Forms.TextBox textBoxConstMeasDur;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxSignalType;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

