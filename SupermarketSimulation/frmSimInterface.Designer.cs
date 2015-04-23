namespace SupermarketSimulation
{
    partial class frmSimInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimInterface));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtRegisters = new System.Windows.Forms.TextBox();
            this.txtCheckoutDurationMinutes = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSimulationVisual = new System.Windows.Forms.TextBox();
            this.lblArrivals = new System.Windows.Forms.Label();
            this.lblDepartures = new System.Windows.Forms.Label();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblLongestQueue = new System.Windows.Forms.Label();
            this.lblAvgWait = new System.Windows.Forms.Label();
            this.lblShortestWait = new System.Windows.Forms.Label();
            this.lblLongestWait = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckoutDurationSeconds = new System.Windows.Forms.TextBox();
            this.SimulationSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinimumMinutes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMinimumSeconds = new System.Windows.Forms.TextBox();
            this.pgbSimulationProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Customers: ";
            // 
            // txtCustomers
            // 
            this.txtCustomers.Location = new System.Drawing.Point(179, 32);
            this.txtCustomers.MaxLength = 4;
            this.txtCustomers.Name = "txtCustomers";
            this.txtCustomers.Size = new System.Drawing.Size(55, 20);
            this.txtCustomers.TabIndex = 1;
            this.txtCustomers.Text = "600";
            this.txtCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustomers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidation_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Hours of Operation: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of Registers: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Expected Checkout Duration: ";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(179, 58);
            this.txtHours.MaxLength = 4;
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(55, 20);
            this.txtHours.TabIndex = 5;
            this.txtHours.Text = "16";
            this.txtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidation_KeyPress);
            // 
            // txtRegisters
            // 
            this.txtRegisters.Location = new System.Drawing.Point(179, 83);
            this.txtRegisters.MaxLength = 4;
            this.txtRegisters.Name = "txtRegisters";
            this.txtRegisters.Size = new System.Drawing.Size(55, 20);
            this.txtRegisters.TabIndex = 6;
            this.txtRegisters.Text = "6";
            this.txtRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRegisters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidation_KeyPress);
            // 
            // txtCheckoutDurationMinutes
            // 
            this.txtCheckoutDurationMinutes.Location = new System.Drawing.Point(114, 139);
            this.txtCheckoutDurationMinutes.MaxLength = 2;
            this.txtCheckoutDurationMinutes.Name = "txtCheckoutDurationMinutes";
            this.txtCheckoutDurationMinutes.Size = new System.Drawing.Size(46, 20);
            this.txtCheckoutDurationMinutes.TabIndex = 7;
            this.txtCheckoutDurationMinutes.Text = "6";
            this.txtCheckoutDurationMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheckoutDurationMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidation_KeyPress);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 262);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(103, 38);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Run Simulation";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(647, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSimulationVisual
            // 
            this.txtSimulationVisual.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSimulationVisual.Location = new System.Drawing.Point(358, 12);
            this.txtSimulationVisual.Multiline = true;
            this.txtSimulationVisual.Name = "txtSimulationVisual";
            this.txtSimulationVisual.ReadOnly = true;
            this.txtSimulationVisual.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSimulationVisual.Size = new System.Drawing.Size(364, 177);
            this.txtSimulationVisual.TabIndex = 10;
            this.txtSimulationVisual.WordWrap = false;
            // 
            // lblArrivals
            // 
            this.lblArrivals.AutoSize = true;
            this.lblArrivals.Location = new System.Drawing.Point(355, 192);
            this.lblArrivals.Name = "lblArrivals";
            this.lblArrivals.Size = new System.Drawing.Size(47, 13);
            this.lblArrivals.TabIndex = 11;
            this.lblArrivals.Text = "Arrivals: ";
            // 
            // lblDepartures
            // 
            this.lblDepartures.AutoSize = true;
            this.lblDepartures.Location = new System.Drawing.Point(506, 192);
            this.lblDepartures.Name = "lblDepartures";
            this.lblDepartures.Size = new System.Drawing.Size(62, 13);
            this.lblDepartures.TabIndex = 12;
            this.lblDepartures.Text = "Departures:";
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Location = new System.Drawing.Point(355, 205);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(99, 13);
            this.lblEvents.TabIndex = 13;
            this.lblEvents.Text = "Events Processed: ";
            // 
            // lblLongestQueue
            // 
            this.lblLongestQueue.AutoSize = true;
            this.lblLongestQueue.Location = new System.Drawing.Point(355, 218);
            this.lblLongestQueue.Name = "lblLongestQueue";
            this.lblLongestQueue.Size = new System.Drawing.Size(150, 13);
            this.lblLongestQueue.TabIndex = 14;
            this.lblLongestQueue.Text = "Longest Queue Encountered: ";
            // 
            // lblAvgWait
            // 
            this.lblAvgWait.AutoSize = true;
            this.lblAvgWait.Location = new System.Drawing.Point(355, 262);
            this.lblAvgWait.Name = "lblAvgWait";
            this.lblAvgWait.Size = new System.Drawing.Size(101, 13);
            this.lblAvgWait.TabIndex = 15;
            this.lblAvgWait.Text = "Average Wait Time:";
            // 
            // lblShortestWait
            // 
            this.lblShortestWait.AutoSize = true;
            this.lblShortestWait.Location = new System.Drawing.Point(355, 246);
            this.lblShortestWait.Name = "lblShortestWait";
            this.lblShortestWait.Size = new System.Drawing.Size(74, 13);
            this.lblShortestWait.TabIndex = 16;
            this.lblShortestWait.Text = "Shortest Wait:";
            // 
            // lblLongestWait
            // 
            this.lblLongestWait.AutoSize = true;
            this.lblLongestWait.Location = new System.Drawing.Point(506, 246);
            this.lblLongestWait.Name = "lblLongestWait";
            this.lblLongestWait.Size = new System.Drawing.Size(73, 13);
            this.lblLongestWait.TabIndex = 17;
            this.lblLongestWait.Text = "Longest Wait:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Minutes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Seconds: ";
            // 
            // txtCheckoutDurationSeconds
            // 
            this.txtCheckoutDurationSeconds.Location = new System.Drawing.Point(230, 142);
            this.txtCheckoutDurationSeconds.MaxLength = 2;
            this.txtCheckoutDurationSeconds.Name = "txtCheckoutDurationSeconds";
            this.txtCheckoutDurationSeconds.Size = new System.Drawing.Size(46, 20);
            this.txtCheckoutDurationSeconds.TabIndex = 8;
            this.txtCheckoutDurationSeconds.Text = "15";
            this.txtCheckoutDurationSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheckoutDurationSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidation_KeyPress);
            // 
            // SimulationSpeed
            // 
            this.SimulationSpeed.Location = new System.Drawing.Point(240, 262);
            this.SimulationSpeed.Maximum = 99;
            this.SimulationSpeed.Minimum = 1;
            this.SimulationSpeed.Name = "SimulationSpeed";
            this.SimulationSpeed.Size = new System.Drawing.Size(104, 45);
            this.SimulationSpeed.TabIndex = 21;
            this.SimulationSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SimulationSpeed.Value = 89;
            this.SimulationSpeed.Scroll += new System.EventHandler(this.SimulationSpeed_Scroll);
            this.SimulationSpeed.ValueChanged += new System.EventHandler(this.SimulationSpeed_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(237, 246);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(116, 13);
            this.lblSpeed.TabIndex = 22;
            this.lblSpeed.Text = "1100 Millisecond Delay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Expected Minimum Checkout Duration: ";
            // 
            // txtMinimumMinutes
            // 
            this.txtMinimumMinutes.Location = new System.Drawing.Point(114, 180);
            this.txtMinimumMinutes.MaxLength = 2;
            this.txtMinimumMinutes.Name = "txtMinimumMinutes";
            this.txtMinimumMinutes.Size = new System.Drawing.Size(46, 20);
            this.txtMinimumMinutes.TabIndex = 24;
            this.txtMinimumMinutes.Text = "2";
            this.txtMinimumMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Minutes:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Seconds: ";
            // 
            // txtMinimumSeconds
            // 
            this.txtMinimumSeconds.Location = new System.Drawing.Point(230, 180);
            this.txtMinimumSeconds.MaxLength = 2;
            this.txtMinimumSeconds.Name = "txtMinimumSeconds";
            this.txtMinimumSeconds.Size = new System.Drawing.Size(46, 20);
            this.txtMinimumSeconds.TabIndex = 27;
            this.txtMinimumSeconds.Text = "0";
            this.txtMinimumSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pgbSimulationProgress
            // 
            this.pgbSimulationProgress.BackColor = System.Drawing.Color.Chocolate;
            this.pgbSimulationProgress.Location = new System.Drawing.Point(12, 306);
            this.pgbSimulationProgress.Name = "pgbSimulationProgress";
            this.pgbSimulationProgress.Size = new System.Drawing.Size(710, 25);
            this.pgbSimulationProgress.TabIndex = 28;
            // 
            // frmSimInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 337);
            this.Controls.Add(this.pgbSimulationProgress);
            this.Controls.Add(this.txtMinimumSeconds);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMinimumMinutes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.SimulationSpeed);
            this.Controls.Add(this.txtCheckoutDurationSeconds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLongestWait);
            this.Controls.Add(this.lblShortestWait);
            this.Controls.Add(this.lblAvgWait);
            this.Controls.Add(this.lblLongestQueue);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.lblDepartures);
            this.Controls.Add(this.lblArrivals);
            this.Controls.Add(this.txtSimulationVisual);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtCheckoutDurationMinutes);
            this.Controls.Add(this.txtRegisters);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomers);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 375);
            this.MinimumSize = new System.Drawing.Size(750, 375);
            this.Name = "frmSimInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supermarket Simulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSimInterface_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtRegisters;
        private System.Windows.Forms.TextBox txtCheckoutDurationMinutes;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSimulationVisual;
        private System.Windows.Forms.Label lblArrivals;
        private System.Windows.Forms.Label lblDepartures;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblLongestQueue;
        private System.Windows.Forms.Label lblAvgWait;
        private System.Windows.Forms.Label lblShortestWait;
        private System.Windows.Forms.Label lblLongestWait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCheckoutDurationSeconds;
        private System.Windows.Forms.TrackBar SimulationSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMinimumMinutes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinimumSeconds;
        private System.Windows.Forms.ProgressBar pgbSimulationProgress;
    }
}

