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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxElectrodePins = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxElectrodePins = new System.Windows.Forms.PictureBox();
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
            this.radioBtnEIS = new System.Windows.Forms.RadioButton();
            this.radioBtnConstV = new System.Windows.Forms.RadioButton();
            this.radioBtnCV = new System.Windows.Forms.RadioButton();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.checkBoxLogDistribution = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxEISVoltage = new System.Windows.Forms.TextBox();
            this.eisMeasParamBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxPointsEIS = new System.Windows.Forms.TextBox();
            this.textBoxStopFreqEIS = new System.Windows.Forms.TextBox();
            this.textBoxStartFreqEIS = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxElectrodePins)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
            this.groupBoxSignalType.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.label14);
            this.tabPageInfo.Controls.Add(this.label6);
            this.tabPageInfo.Controls.Add(this.richTextBox1);
            this.tabPageInfo.Controls.Add(this.richTextBoxElectrodePins);
            this.tabPageInfo.Controls.Add(this.pictureBox1);
            this.tabPageInfo.Controls.Add(this.pictureBoxElectrodePins);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPageInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Size = new System.Drawing.Size(954, 641);
            this.tabPageInfo.TabIndex = 2;
            this.tabPageInfo.Text = "Help";
            this.tabPageInfo.ToolTipText = "information and hints";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 28);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 19);
            this.label14.TabIndex = 7;
            this.label14.Text = "Before measuring :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 185);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "CV configuration :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(31, 61);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(364, 102);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "• Check range of voltage : [-800, 800] mV\n• Check range of slope duration : [0, 1" +
    ".6] seconds\n• Check connected pins on microcontroller board\n";
            // 
            // richTextBoxElectrodePins
            // 
            this.richTextBoxElectrodePins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxElectrodePins.BulletIndent = 10;
            this.richTextBoxElectrodePins.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxElectrodePins.Location = new System.Drawing.Point(592, 17);
            this.richTextBoxElectrodePins.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxElectrodePins.Name = "richTextBoxElectrodePins";
            this.richTextBoxElectrodePins.Size = new System.Drawing.Size(274, 146);
            this.richTextBoxElectrodePins.TabIndex = 2;
            this.richTextBoxElectrodePins.Text = "Hard-coded 4-wire electrode pins on microcontroller board:\n\n\tCE     == AFE7   (LK" +
    "6)\n\tREF+ == AFE6   (LK5)\n            REF- == AFE2   (LK4)\n            WE    == A" +
    "FE3   (LK3)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Biosensor_GUI.Properties.Resources.cv_signal;
            this.pictureBox1.Location = new System.Drawing.Point(32, 230);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxElectrodePins
            // 
            this.pictureBoxElectrodePins.Image = global::Biosensor_GUI.Properties.Resources.electrode_pins_marked;
            this.pictureBoxElectrodePins.Location = new System.Drawing.Point(550, 130);
            this.pictureBoxElectrodePins.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxElectrodePins.Name = "pictureBoxElectrodePins";
            this.pictureBoxElectrodePins.Size = new System.Drawing.Size(354, 491);
            this.pictureBoxElectrodePins.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxElectrodePins.TabIndex = 0;
            this.pictureBoxElectrodePins.TabStop = false;
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
            this.tabControl2.Controls.Add(this.tabPageInfo);
            this.tabControl2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ItemSize = new System.Drawing.Size(120, 22);
            this.tabControl2.Location = new System.Drawing.Point(10, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.ShowToolTips = true;
            this.tabControl2.Size = new System.Drawing.Size(968, 684);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
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
            this.tabPageMeasure.Location = new System.Drawing.Point(4, 26);
            this.tabPageMeasure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMeasure.Name = "tabPageMeasure";
            this.tabPageMeasure.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMeasure.Size = new System.Drawing.Size(960, 654);
            this.tabPageMeasure.TabIndex = 0;
            this.tabPageMeasure.Text = "Measurement";
            this.tabPageMeasure.ToolTipText = "measure, plot and save";
            this.tabPageMeasure.UseVisualStyleBackColor = true;
            // 
            // stopMeasBtn
            // 
            this.stopMeasBtn.Enabled = false;
            this.stopMeasBtn.Location = new System.Drawing.Point(496, 30);
            this.stopMeasBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopMeasBtn.Name = "stopMeasBtn";
            this.stopMeasBtn.Size = new System.Drawing.Size(72, 26);
            this.stopMeasBtn.TabIndex = 41;
            this.stopMeasBtn.Text = "STOP";
            this.stopMeasBtn.UseVisualStyleBackColor = true;
            this.stopMeasBtn.Click += new System.EventHandler(this.stopMeasBtn_Click);
            // 
            // saveDataBut
            // 
            this.saveDataBut.Location = new System.Drawing.Point(496, 85);
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
            this.startFluidBtn.Visible = false;
            // 
            // chartPlot
            // 
            chartArea11.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea11.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea11.BackColor = System.Drawing.Color.White;
            chartArea11.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chartPlot.Legends.Add(legend11);
            this.chartPlot.Location = new System.Drawing.Point(20, 128);
            this.chartPlot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartPlot.Name = "chartPlot";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.MarkerSize = 10;
            series11.Name = "Data Received";
            this.chartPlot.Series.Add(series11);
            this.chartPlot.Size = new System.Drawing.Size(910, 509);
            this.chartPlot.TabIndex = 18;
            this.chartPlot.Text = "chart1";
            // 
            // startMeasBtn
            // 
            this.startMeasBtn.Location = new System.Drawing.Point(310, 40);
            this.startMeasBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startMeasBtn.Name = "startMeasBtn";
            this.startMeasBtn.Size = new System.Drawing.Size(158, 61);
            this.startMeasBtn.TabIndex = 0;
            this.startMeasBtn.Text = "Start Measurement";
            this.startMeasBtn.UseVisualStyleBackColor = true;
            this.startMeasBtn.Click += new System.EventHandler(this.startMeasBtn_Click);
            // 
            // groupBoxSignalType
            // 
            this.groupBoxSignalType.Controls.Add(this.radioBtnEIS);
            this.groupBoxSignalType.Controls.Add(this.radioBtnConstV);
            this.groupBoxSignalType.Controls.Add(this.radioBtnCV);
            this.groupBoxSignalType.Location = new System.Drawing.Point(39, 25);
            this.groupBoxSignalType.Name = "groupBoxSignalType";
            this.groupBoxSignalType.Size = new System.Drawing.Size(194, 98);
            this.groupBoxSignalType.TabIndex = 45;
            this.groupBoxSignalType.TabStop = false;
            this.groupBoxSignalType.Text = "Excitation Signal";
            // 
            // radioBtnEIS
            // 
            this.radioBtnEIS.AutoSize = true;
            this.radioBtnEIS.Location = new System.Drawing.Point(18, 72);
            this.radioBtnEIS.Name = "radioBtnEIS";
            this.radioBtnEIS.Size = new System.Drawing.Size(51, 23);
            this.radioBtnEIS.TabIndex = 47;
            this.radioBtnEIS.TabStop = true;
            this.radioBtnEIS.Text = "EIS";
            this.radioBtnEIS.UseVisualStyleBackColor = true;
            // 
            // radioBtnConstV
            // 
            this.radioBtnConstV.AutoSize = true;
            this.radioBtnConstV.Location = new System.Drawing.Point(18, 26);
            this.radioBtnConstV.Name = "radioBtnConstV";
            this.radioBtnConstV.Size = new System.Drawing.Size(124, 23);
            this.radioBtnConstV.TabIndex = 46;
            this.radioBtnConstV.TabStop = true;
            this.radioBtnConstV.Text = "const voltage";
            this.radioBtnConstV.UseVisualStyleBackColor = true;
            // 
            // radioBtnCV
            // 
            this.radioBtnCV.AutoSize = true;
            this.radioBtnCV.Location = new System.Drawing.Point(18, 49);
            this.radioBtnCV.Name = "radioBtnCV";
            this.radioBtnCV.Size = new System.Drawing.Size(165, 23);
            this.radioBtnCV.TabIndex = 0;
            this.radioBtnCV.TabStop = true;
            this.radioBtnCV.Text = "cyclic voltammetry";
            this.radioBtnCV.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.checkBoxLogDistribution);
            this.tabPageConfig.Controls.Add(this.label22);
            this.tabPageConfig.Controls.Add(this.label21);
            this.tabPageConfig.Controls.Add(this.label20);
            this.tabPageConfig.Controls.Add(this.label19);
            this.tabPageConfig.Controls.Add(this.textBoxEISVoltage);
            this.tabPageConfig.Controls.Add(this.eisMeasParamBtn);
            this.tabPageConfig.Controls.Add(this.label18);
            this.tabPageConfig.Controls.Add(this.label17);
            this.tabPageConfig.Controls.Add(this.label16);
            this.tabPageConfig.Controls.Add(this.textBoxPointsEIS);
            this.tabPageConfig.Controls.Add(this.textBoxStopFreqEIS);
            this.tabPageConfig.Controls.Add(this.textBoxStartFreqEIS);
            this.tabPageConfig.Controls.Add(this.label15);
            this.tabPageConfig.Controls.Add(this.pictureBox2);
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
            this.tabPageConfig.Location = new System.Drawing.Point(4, 26);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConfig.Size = new System.Drawing.Size(960, 654);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.ToolTipText = "configure parameters";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // checkBoxLogDistribution
            // 
            this.checkBoxLogDistribution.AutoSize = true;
            this.checkBoxLogDistribution.Location = new System.Drawing.Point(808, 261);
            this.checkBoxLogDistribution.Name = "checkBoxLogDistribution";
            this.checkBoxLogDistribution.Size = new System.Drawing.Size(111, 42);
            this.checkBoxLogDistribution.TabIndex = 72;
            this.checkBoxLogDistribution.Text = "logarithmic\r\ndistribution";
            this.checkBoxLogDistribution.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(322, 424);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 20);
            this.label22.TabIndex = 71;
            this.label22.Text = "Save Plot Data";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(52, 424);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 20);
            this.label21.TabIndex = 70;
            this.label21.Text = "USB connection";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(50, 349);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(757, 36);
            this.label20.TabIndex = 69;
            this.label20.Text = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(794, 94);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(161, 19);
            this.label19.TabIndex = 68;
            this.label19.Text = "AC Voltage Peak [mV]";
            // 
            // textBoxEISVoltage
            // 
            this.textBoxEISVoltage.Location = new System.Drawing.Point(631, 91);
            this.textBoxEISVoltage.Name = "textBoxEISVoltage";
            this.textBoxEISVoltage.Size = new System.Drawing.Size(145, 27);
            this.textBoxEISVoltage.TabIndex = 67;
            this.textBoxEISVoltage.Text = "10";
            this.textBoxEISVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxEISVoltage, "from 0 to 20 mV");
            // 
            // eisMeasParamBtn
            // 
            this.eisMeasParamBtn.Location = new System.Drawing.Point(640, 261);
            this.eisMeasParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eisMeasParamBtn.Name = "eisMeasParamBtn";
            this.eisMeasParamBtn.Size = new System.Drawing.Size(129, 64);
            this.eisMeasParamBtn.TabIndex = 66;
            this.eisMeasParamBtn.Text = "Change Parameters";
            this.eisMeasParamBtn.UseVisualStyleBackColor = true;
            this.eisMeasParamBtn.Click += new System.EventHandler(this.eisMeasParamBtn_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(793, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(137, 19);
            this.label18.TabIndex = 65;
            this.label18.Text = "Points In Between";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(794, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 19);
            this.label17.TabIndex = 64;
            this.label17.Text = "Stop Frequency [Hz]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(794, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 19);
            this.label16.TabIndex = 63;
            this.label16.Text = "Start Frequency [Hz]";
            // 
            // textBoxPointsEIS
            // 
            this.textBoxPointsEIS.Location = new System.Drawing.Point(631, 221);
            this.textBoxPointsEIS.Name = "textBoxPointsEIS";
            this.textBoxPointsEIS.Size = new System.Drawing.Size(145, 27);
            this.textBoxPointsEIS.TabIndex = 62;
            this.textBoxPointsEIS.Text = "40";
            this.textBoxPointsEIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxPointsEIS, "determines the step frequency (min: 0.5 Hz)");
            // 
            // textBoxStopFreqEIS
            // 
            this.textBoxStopFreqEIS.Location = new System.Drawing.Point(631, 176);
            this.textBoxStopFreqEIS.Name = "textBoxStopFreqEIS";
            this.textBoxStopFreqEIS.Size = new System.Drawing.Size(145, 27);
            this.textBoxStopFreqEIS.TabIndex = 61;
            this.textBoxStopFreqEIS.Text = "100";
            this.textBoxStopFreqEIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxStopFreqEIS, "from StartFrequency to 80 kHz");
            // 
            // textBoxStartFreqEIS
            // 
            this.textBoxStartFreqEIS.Location = new System.Drawing.Point(631, 131);
            this.textBoxStartFreqEIS.Name = "textBoxStartFreqEIS";
            this.textBoxStartFreqEIS.Size = new System.Drawing.Size(145, 27);
            this.textBoxStartFreqEIS.TabIndex = 60;
            this.textBoxStartFreqEIS.Text = "10000";
            this.textBoxStartFreqEIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxStartFreqEIS, "from 100 Hz to 80 kHz");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(602, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(225, 24);
            this.label15.TabIndex = 59;
            this.label15.Text = "Impedance Spectroscopy";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Biosensor_GUI.Properties.Resources.info_icon;
            this.pictureBox2.Location = new System.Drawing.Point(475, 41);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "parameter info");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelCVDur
            // 
            this.labelCVDur.AutoSize = true;
            this.labelCVDur.Location = new System.Drawing.Point(490, 169);
            this.labelCVDur.Name = "labelCVDur";
            this.labelCVDur.Size = new System.Drawing.Size(94, 19);
            this.labelCVDur.TabIndex = 57;
            this.labelCVDur.Text = "Duration [s]";
            // 
            // textBoxCVDur
            // 
            this.textBoxCVDur.Location = new System.Drawing.Point(326, 162);
            this.textBoxCVDur.Name = "textBoxCVDur";
            this.textBoxCVDur.Size = new System.Drawing.Size(145, 27);
            this.textBoxCVDur.TabIndex = 56;
            this.textBoxCVDur.Text = "10";
            this.textBoxCVDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxCVDur, "total measurement duration");
            // 
            // checkBoxCVMeas
            // 
            this.checkBoxCVMeas.AutoSize = true;
            this.checkBoxCVMeas.Location = new System.Drawing.Point(358, 224);
            this.checkBoxCVMeas.Name = "checkBoxCVMeas";
            this.checkBoxCVMeas.Size = new System.Drawing.Size(118, 23);
            this.checkBoxCVMeas.TabIndex = 55;
            this.checkBoxCVMeas.Text = "continuous ?";
            this.checkBoxCVMeas.UseVisualStyleBackColor = true;
            this.checkBoxCVMeas.CheckedChanged += new System.EventHandler(this.checkBoxCVMeas_CheckedChanged);
            // 
            // checkBoxConstMeas
            // 
            this.checkBoxConstMeas.AutoSize = true;
            this.checkBoxConstMeas.Location = new System.Drawing.Point(90, 148);
            this.checkBoxConstMeas.Name = "checkBoxConstMeas";
            this.checkBoxConstMeas.Size = new System.Drawing.Size(118, 23);
            this.checkBoxConstMeas.TabIndex = 54;
            this.checkBoxConstMeas.Text = "continuous ?";
            this.checkBoxConstMeas.UseVisualStyleBackColor = true;
            this.checkBoxConstMeas.CheckedChanged += new System.EventHandler(this.checkBoxConstMeas_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(490, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 19);
            this.label13.TabIndex = 53;
            this.label13.Text = "Voltage 2 [mV]";
            // 
            // textBoxCVVoltage2
            // 
            this.textBoxCVVoltage2.Location = new System.Drawing.Point(326, 125);
            this.textBoxCVVoltage2.Name = "textBoxCVVoltage2";
            this.textBoxCVVoltage2.Size = new System.Drawing.Size(145, 27);
            this.textBoxCVVoltage2.TabIndex = 52;
            this.textBoxCVVoltage2.Text = "100";
            this.textBoxCVVoltage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxCVVoltage2, "from -800 to 800 mV");
            // 
            // cvMeasParamBtn
            // 
            this.cvMeasParamBtn.Location = new System.Drawing.Point(332, 263);
            this.cvMeasParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cvMeasParamBtn.Name = "cvMeasParamBtn";
            this.cvMeasParamBtn.Size = new System.Drawing.Size(129, 74);
            this.cvMeasParamBtn.TabIndex = 51;
            this.cvMeasParamBtn.Text = "Change Parameters";
            this.cvMeasParamBtn.UseVisualStyleBackColor = true;
            this.cvMeasParamBtn.Click += new System.EventHandler(this.cvMeasParamBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(490, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = "Voltage 1 [mV]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(488, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 38);
            this.label11.TabIndex = 49;
            this.label11.Text = "Slope Duration [s]\r\n     (max. 1.6 s)";
            // 
            // textBoxCVVoltage1
            // 
            this.textBoxCVVoltage1.Location = new System.Drawing.Point(326, 91);
            this.textBoxCVVoltage1.Name = "textBoxCVVoltage1";
            this.textBoxCVVoltage1.Size = new System.Drawing.Size(145, 27);
            this.textBoxCVVoltage1.TabIndex = 48;
            this.textBoxCVVoltage1.Text = "0";
            this.textBoxCVVoltage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxCVVoltage1, "from -800 to 800 mV");
            // 
            // textBoxCVSlopeDur
            // 
            this.textBoxCVSlopeDur.Location = new System.Drawing.Point(325, 195);
            this.textBoxCVSlopeDur.Name = "textBoxCVSlopeDur";
            this.textBoxCVSlopeDur.Size = new System.Drawing.Size(145, 27);
            this.textBoxCVSlopeDur.TabIndex = 47;
            this.textBoxCVSlopeDur.Text = "1";
            this.textBoxCVSlopeDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxCVSlopeDur, "time between voltage 1 and 2\r\n--> maximum 1.6 seconds");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(313, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 24);
            this.label12.TabIndex = 46;
            this.label12.Text = "CV Measurement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "Select Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(511, 473);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "File Name";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(514, 492);
            this.fileNameBox.Multiline = true;
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(156, 55);
            this.fileNameBox.TabIndex = 43;
            this.fileNameBox.Text = "Measurement ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 42;
            this.label4.Text = "File Path";
            // 
            // dataPathBox
            // 
            this.dataPathBox.Location = new System.Drawing.Point(306, 492);
            this.dataPathBox.Multiline = true;
            this.dataPathBox.Name = "dataPathBox";
            this.dataPathBox.Size = new System.Drawing.Size(156, 90);
            this.dataPathBox.TabIndex = 41;
            this.dataPathBox.Text = "C:\\Users\\Isaac\\Documents\\Studium\\SensUs\\Data\\SensUsGui";
            // 
            // comSelBox
            // 
            this.comSelBox.FormattingEnabled = true;
            this.comSelBox.Location = new System.Drawing.Point(56, 492);
            this.comSelBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comSelBox.Name = "comSelBox";
            this.comSelBox.Size = new System.Drawing.Size(138, 27);
            this.comSelBox.TabIndex = 40;
            this.comSelBox.SelectedIndexChanged += new System.EventHandler(this.comSelBox_SelectedIndexChanged);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(85, 532);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(82, 26);
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
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "Voltage [mV]";
            // 
            // labelConstVDur
            // 
            this.labelConstVDur.AutoSize = true;
            this.labelConstVDur.Location = new System.Drawing.Point(218, 125);
            this.labelConstVDur.Name = "labelConstVDur";
            this.labelConstVDur.Size = new System.Drawing.Size(94, 19);
            this.labelConstVDur.TabIndex = 34;
            this.labelConstVDur.Text = "Duration [s]";
            // 
            // textBoxConstVoltage
            // 
            this.textBoxConstVoltage.Location = new System.Drawing.Point(56, 91);
            this.textBoxConstVoltage.Name = "textBoxConstVoltage";
            this.textBoxConstVoltage.Size = new System.Drawing.Size(145, 27);
            this.textBoxConstVoltage.TabIndex = 31;
            this.textBoxConstVoltage.Text = "0";
            this.textBoxConstVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxConstVoltage, "from -800 to 800 mV");
            // 
            // textBoxConstVDur
            // 
            this.textBoxConstVDur.Location = new System.Drawing.Point(56, 121);
            this.textBoxConstVDur.Name = "textBoxConstVDur";
            this.textBoxConstVDur.Size = new System.Drawing.Size(145, 27);
            this.textBoxConstVDur.TabIndex = 30;
            this.textBoxConstVDur.Text = "10";
            this.textBoxConstVDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxConstVDur, "total measurement duration");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Const. Voltage Measurement";
            // 
            // fluidParamBtn
            // 
            this.fluidParamBtn.Enabled = false;
            this.fluidParamBtn.Location = new System.Drawing.Point(699, 522);
            this.fluidParamBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fluidParamBtn.Name = "fluidParamBtn";
            this.fluidParamBtn.Size = new System.Drawing.Size(128, 74);
            this.fluidParamBtn.TabIndex = 27;
            this.fluidParamBtn.Text = "Change Parameters";
            this.fluidParamBtn.UseVisualStyleBackColor = true;
            this.fluidParamBtn.Visible = false;
            // 
            // textBoxPumpPressure
            // 
            this.textBoxPumpPressure.Enabled = false;
            this.textBoxPumpPressure.Location = new System.Drawing.Point(691, 476);
            this.textBoxPumpPressure.Name = "textBoxPumpPressure";
            this.textBoxPumpPressure.Size = new System.Drawing.Size(145, 27);
            this.textBoxPumpPressure.TabIndex = 26;
            this.textBoxPumpPressure.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(842, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 19);
            this.label9.TabIndex = 25;
            this.label9.Text = "Pump time [s]";
            this.label9.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(842, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pump pressure ";
            this.label5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(746, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Pump";
            this.label2.Visible = false;
            // 
            // textBoxPumpTime
            // 
            this.textBoxPumpTime.Enabled = false;
            this.textBoxPumpTime.Location = new System.Drawing.Point(691, 440);
            this.textBoxPumpTime.Name = "textBoxPumpTime";
            this.textBoxPumpTime.Size = new System.Drawing.Size(145, 27);
            this.textBoxPumpTime.TabIndex = 22;
            this.textBoxPumpTime.Visible = false;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.Location = new System.Drawing.Point(998, 143);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(146, 197);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 695);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxElectrodePins)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).EndInit();
            this.groupBoxSignalType.ResumeLayout(false);
            this.groupBoxSignalType.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxElectrodePins;
        private System.Windows.Forms.RichTextBox richTextBoxElectrodePins;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TextBox textBoxStartFreqEIS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxStopFreqEIS;
        private System.Windows.Forms.TextBox textBoxPointsEIS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button eisMeasParamBtn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxEISVoltage;
        private System.Windows.Forms.RadioButton radioBtnEIS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox checkBoxLogDistribution;
    }
}

