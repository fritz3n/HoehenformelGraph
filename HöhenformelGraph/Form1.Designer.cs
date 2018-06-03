namespace HöhenformelGraph
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ZeroTempNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ZeroPressureNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.DensityNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.EndNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroTempNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroPressureNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Red;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(789, 523);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ZeroTempNum);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.ZeroPressureNum);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.DensityNum);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.EndNum);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.StartNum);
            this.splitContainer1.Size = new System.Drawing.Size(789, 580);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.TabIndex = 1;
            // 
            // ZeroTempNum
            // 
            this.ZeroTempNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ZeroTempNum.Location = new System.Drawing.Point(741, 14);
            this.ZeroTempNum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ZeroTempNum.Name = "ZeroTempNum";
            this.ZeroTempNum.Size = new System.Drawing.Size(38, 20);
            this.ZeroTempNum.TabIndex = 11;
            this.ZeroTempNum.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ZeroTempNum.ValueChanged += new System.EventHandler(this.ZeroTempNum_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(662, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zero Temp °C";
            // 
            // ZeroPressureNum
            // 
            this.ZeroPressureNum.DecimalPlaces = 2;
            this.ZeroPressureNum.Location = new System.Drawing.Point(597, 14);
            this.ZeroPressureNum.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ZeroPressureNum.Name = "ZeroPressureNum";
            this.ZeroPressureNum.Size = new System.Drawing.Size(59, 20);
            this.ZeroPressureNum.TabIndex = 9;
            this.ZeroPressureNum.Value = new decimal(new int[] {
            101325,
            0,
            0,
            131072});
            this.ZeroPressureNum.ValueChanged += new System.EventHandler(this.ZeroPressureNum_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zero Pressure hPa";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // DensityNum
            // 
            this.DensityNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DensityNum.Location = new System.Drawing.Point(370, 14);
            this.DensityNum.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.DensityNum.Name = "DensityNum";
            this.DensityNum.Size = new System.Drawing.Size(120, 20);
            this.DensityNum.TabIndex = 6;
            this.DensityNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DensityNum.ValueChanged += new System.EventHandler(this.DensityNum_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Density";
            // 
            // EndNum
            // 
            this.EndNum.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EndNum.Location = new System.Drawing.Point(196, 14);
            this.EndNum.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.EndNum.Name = "EndNum";
            this.EndNum.Size = new System.Drawing.Size(120, 20);
            this.EndNum.TabIndex = 4;
            this.EndNum.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EndNum.ValueChanged += new System.EventHandler(this.EndNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "End";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start";
            // 
            // StartNum
            // 
            this.StartNum.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.StartNum.Location = new System.Drawing.Point(38, 14);
            this.StartNum.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.StartNum.Name = "StartNum";
            this.StartNum.Size = new System.Drawing.Size(120, 20);
            this.StartNum.TabIndex = 0;
            this.StartNum.ValueChanged += new System.EventHandler(this.StartNum_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 580);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Höhenformel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZeroTempNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZeroPressureNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown DensityNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown EndNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown StartNum;
        private System.Windows.Forms.NumericUpDown ZeroPressureNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ZeroTempNum;
        private System.Windows.Forms.Label label5;
    }
}

