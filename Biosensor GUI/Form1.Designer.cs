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
            button2 = new Button();
            textBoxLog = new TextBox();
            pictureBox1 = new PictureBox();
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
            // button2
            // 
            button2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(877, 243);
            button2.Name = "button2";
            button2.Size = new Size(87, 43);
            button2.TabIndex = 2;
            button2.Text = "stop";
            button2.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 702);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxLog);
            Controls.Add(button2);
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
        private Button button2;
        private TextBox textBoxLog;
        private PictureBox pictureBox1;
    }
}
