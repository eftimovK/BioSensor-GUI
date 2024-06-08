namespace Biosensor_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartBtn = new Button();
            dataPlot = new ScottPlot.WinForms.FormsPlot();
            StopBtn = new Button();
            textBoxLog = new TextBox();
            pictureBox1 = new PictureBox();
            comSelectBox = new ComboBox();
            refreshBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // StartBtn
            // 
            StartBtn.Font = new Font("Arial", 14F);
            StartBtn.Location = new Point(819, 132);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(196, 71);
            StartBtn.TabIndex = 0;
            StartBtn.Text = "Start\r\nmeasurement";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // dataPlot
            // 
            dataPlot.DisplayScale = 1.25F;
            dataPlot.Location = new Point(23, 132);
            dataPlot.Name = "dataPlot";
            dataPlot.Size = new Size(740, 491);
            dataPlot.TabIndex = 1;
            // 
            // StopBtn
            // 
            StopBtn.Enabled = false;
            StopBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StopBtn.Location = new Point(877, 243);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(87, 43);
            StopBtn.TabIndex = 2;
            StopBtn.Text = "stop";
            StopBtn.UseVisualStyleBackColor = true;
            StopBtn.Click += StopBtn_Click;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(819, 349);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(212, 212);
            textBoxLog.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_without_name_framed;
            pictureBox1.Location = new Point(346, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // comSelectBox
            // 
            comSelectBox.FormattingEnabled = true;
            comSelectBox.Location = new Point(774, 42);
            comSelectBox.Name = "comSelectBox";
            comSelectBox.Size = new Size(151, 28);
            comSelectBox.TabIndex = 5;
            comSelectBox.SelectedIndexChanged += comSelectBox_SelectedIndexChanged;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = SystemColors.Info;
            refreshBtn.Image = Properties.Resources.refresh_icon_32pix;
            refreshBtn.Location = new Point(942, 34);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(42, 42);
            refreshBtn.TabIndex = 6;
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 702);
            Controls.Add(refreshBtn);
            Controls.Add(comSelectBox);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxLog);
            Controls.Add(StopBtn);
            Controls.Add(dataPlot);
            Controls.Add(StartBtn);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartBtn;
        private ScottPlot.WinForms.FormsPlot dataPlot;
        private Button StopBtn;
        private TextBox textBoxLog;
        private PictureBox pictureBox1;
        private ComboBox comSelectBox;
        private Button refreshBtn;
    }
}
