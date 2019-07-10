namespace ChartApp
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sysChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Disk_btn = new System.Windows.Forms.Button();
            this.Cpu_btn = new System.Windows.Forms.Button();
            this.Memory_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sysChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sysChart.ChartAreas.Add(chartArea1);
            this.sysChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.sysChart.Legends.Add(legend1);
            this.sysChart.Location = new System.Drawing.Point(0, 0);
            this.sysChart.Name = "sysChart";
            this.sysChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.sysChart.Series.Add(series1);
            this.sysChart.Size = new System.Drawing.Size(684, 446);
            this.sysChart.TabIndex = 0;
            this.sysChart.Text = "sysChart";
            // 
            // Disk_btn
            // 
            this.Disk_btn.Location = new System.Drawing.Point(582, 377);
            this.Disk_btn.Name = "Disk_btn";
            this.Disk_btn.Size = new System.Drawing.Size(75, 23);
            this.Disk_btn.TabIndex = 1;
            this.Disk_btn.Text = "DISK (OFF)";
            this.Disk_btn.UseVisualStyleBackColor = true;
            this.Disk_btn.Click += new System.EventHandler(this.Disk_btn_Click);
            // 
            // Cpu_btn
            // 
            this.Cpu_btn.Location = new System.Drawing.Point(582, 279);
            this.Cpu_btn.Name = "Cpu_btn";
            this.Cpu_btn.Size = new System.Drawing.Size(75, 23);
            this.Cpu_btn.TabIndex = 2;
            this.Cpu_btn.Text = "CPU";
            this.Cpu_btn.UseVisualStyleBackColor = true;
            this.Cpu_btn.Click += new System.EventHandler(this.Cpu_btn_Click);
            // 
            // Memory_btn
            // 
            this.Memory_btn.Location = new System.Drawing.Point(582, 320);
            this.Memory_btn.Name = "Memory_btn";
            this.Memory_btn.Size = new System.Drawing.Size(75, 23);
            this.Memory_btn.TabIndex = 3;
            this.Memory_btn.Text = "MEMORY (OFF)";
            this.Memory_btn.UseVisualStyleBackColor = true;
            this.Memory_btn.Click += new System.EventHandler(this.Memory_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 446);
            this.Controls.Add(this.Memory_btn);
            this.Controls.Add(this.Cpu_btn);
            this.Controls.Add(this.Disk_btn);
            this.Controls.Add(this.sysChart);
            this.Name = "Main";
            this.Text = "System Metrics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sysChart;
        private System.Windows.Forms.Button Disk_btn;
        private System.Windows.Forms.Button Cpu_btn;
        private System.Windows.Forms.Button Memory_btn;
    }
}

