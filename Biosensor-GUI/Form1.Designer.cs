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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageMeasure = new System.Windows.Forms.TabPage();
            this.startFluidBtn = new System.Windows.Forms.Button();
            this.chartPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startMeasBtn = new System.Windows.Forms.Button();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.comSelBox = new System.Windows.Forms.ComboBox();
            this.refrBut = new System.Windows.Forms.Button();
            this.meas_para = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fluid_para = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlot)).BeginInit();
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
            this.tabControl1.Location = new System.Drawing.Point(465, 301);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(6, 6);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageMeasure);
            this.tabControl2.Controls.Add(this.tabPageConfig);
            this.tabControl2.Location = new System.Drawing.Point(11, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(927, 671);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPageMeasure
            // 
            this.tabPageMeasure.Controls.Add(this.startFluidBtn);
            this.tabPageMeasure.Controls.Add(this.chartPlot);
            this.tabPageMeasure.Controls.Add(this.startMeasBtn);
            this.tabPageMeasure.Location = new System.Drawing.Point(4, 22);
            this.tabPageMeasure.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMeasure.Name = "tabPageMeasure";
            this.tabPageMeasure.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMeasure.Size = new System.Drawing.Size(919, 645);
            this.tabPageMeasure.TabIndex = 0;
            this.tabPageMeasure.Text = "Measure";
            this.tabPageMeasure.UseVisualStyleBackColor = true;
            // 
            // startFluidBtn
            // 
            this.startFluidBtn.Location = new System.Drawing.Point(485, 29);
            this.startFluidBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startFluidBtn.Name = "startFluidBtn";
            this.startFluidBtn.Size = new System.Drawing.Size(154, 64);
            this.startFluidBtn.TabIndex = 24;
            this.startFluidBtn.Text = "Start Intermediate Fluid";
            this.startFluidBtn.UseVisualStyleBackColor = true;
            // 
            // chartPlot
            // 
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chartPlot.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPlot.Legends.Add(legend2);
            this.chartPlot.Location = new System.Drawing.Point(19, 116);
            this.chartPlot.Margin = new System.Windows.Forms.Padding(2);
            this.chartPlot.Name = "chartPlot";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Data Received";
            this.chartPlot.Series.Add(series2);
            this.chartPlot.Size = new System.Drawing.Size(856, 481);
            this.chartPlot.TabIndex = 18;
            this.chartPlot.Text = "chart1";
            // 
            // startMeasBtn
            // 
            this.startMeasBtn.Location = new System.Drawing.Point(198, 32);
            this.startMeasBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startMeasBtn.Name = "startMeasBtn";
            this.startMeasBtn.Size = new System.Drawing.Size(158, 61);
            this.startMeasBtn.TabIndex = 0;
            this.startMeasBtn.Text = "Start Measurement";
            this.startMeasBtn.UseVisualStyleBackColor = true;
            this.startMeasBtn.Click += new System.EventHandler(this.startMeasBtn_Click);
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.comSelBox);
            this.tabPageConfig.Controls.Add(this.refrBut);
            this.tabPageConfig.Controls.Add(this.meas_para);
            this.tabPageConfig.Controls.Add(this.label8);
            this.tabPageConfig.Controls.Add(this.label7);
            this.tabPageConfig.Controls.Add(this.label6);
            this.tabPageConfig.Controls.Add(this.label3);
            this.tabPageConfig.Controls.Add(this.textBox5);
            this.tabPageConfig.Controls.Add(this.textBox4);
            this.tabPageConfig.Controls.Add(this.textBox3);
            this.tabPageConfig.Controls.Add(this.textBox1);
            this.tabPageConfig.Controls.Add(this.label1);
            this.tabPageConfig.Controls.Add(this.fluid_para);
            this.tabPageConfig.Controls.Add(this.textBox6);
            this.tabPageConfig.Controls.Add(this.label9);
            this.tabPageConfig.Controls.Add(this.label5);
            this.tabPageConfig.Controls.Add(this.label2);
            this.tabPageConfig.Controls.Add(this.textBox2);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Size = new System.Drawing.Size(919, 645);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // comSelBox
            // 
            this.comSelBox.FormattingEnabled = true;
            this.comSelBox.Location = new System.Drawing.Point(658, 90);
            this.comSelBox.Margin = new System.Windows.Forms.Padding(2);
            this.comSelBox.Name = "comSelBox";
            this.comSelBox.Size = new System.Drawing.Size(137, 21);
            this.comSelBox.TabIndex = 40;
            this.comSelBox.SelectedIndexChanged += new System.EventHandler(this.comSelBox_SelectedIndexChanged);
            // 
            // refrBut
            // 
            this.refrBut.Location = new System.Drawing.Point(691, 50);
            this.refrBut.Margin = new System.Windows.Forms.Padding(2);
            this.refrBut.Name = "refrBut";
            this.refrBut.Size = new System.Drawing.Size(72, 26);
            this.refrBut.TabIndex = 39;
            this.refrBut.Text = "Refresh";
            this.refrBut.UseVisualStyleBackColor = true;
            this.refrBut.Click += new System.EventHandler(this.refrBut_Click);
            // 
            // meas_para
            // 
            this.meas_para.Location = new System.Drawing.Point(55, 221);
            this.meas_para.Margin = new System.Windows.Forms.Padding(2);
            this.meas_para.Name = "meas_para";
            this.meas_para.Size = new System.Drawing.Size(159, 94);
            this.meas_para.TabIndex = 37;
            this.meas_para.Text = "Change Parameters";
            this.meas_para.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Pump pressure";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Voltage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Voltage Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Pump time (s)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(53, 121);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(145, 20);
            this.textBox5.TabIndex = 32;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(53, 151);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(145, 20);
            this.textBox4.TabIndex = 31;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(53, 181);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 20);
            this.textBox3.TabIndex = 30;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Change Measurenment Parameters";
            // 
            // fluid_para
            // 
            this.fluid_para.Location = new System.Drawing.Point(359, 170);
            this.fluid_para.Margin = new System.Windows.Forms.Padding(2);
            this.fluid_para.Name = "fluid_para";
            this.fluid_para.Size = new System.Drawing.Size(150, 94);
            this.fluid_para.TabIndex = 27;
            this.fluid_para.Text = "Change Parameters";
            this.fluid_para.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(344, 124);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(145, 20);
            this.textBox6.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Pump time (s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pump pressure ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Change Measurenment Parameters";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(344, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 20);
            this.textBox2.TabIndex = 22;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(954, 138);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(167, 197);
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
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(0, 0);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(0, 0);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button fluid_para;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button meas_para;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSelBox;
        private System.Windows.Forms.Button refrBut;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}

