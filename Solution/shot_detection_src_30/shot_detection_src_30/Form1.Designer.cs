using DirectShowLib;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Drawing;


namespace shot_detection_src_30
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
            // Make sure to release the DxPlay object to avoid hanging
            if (m_play != null)
            {
                m_play.Dispose();
            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtThreshold1 = new System.Windows.Forms.TextBox();
            this.txtThreshold2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartPixelDifferenceSD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBins = new System.Windows.Forms.TextBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.btnStartGlobalHistogramSD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnoutputfolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBlocks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBinsLocalHistogram = new System.Windows.Forms.TextBox();
            this.txtThresholdLocalHistogram = new System.Windows.Forms.TextBox();
            this.btnStartLocalHistogramSD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWindowSizeMotionEstimation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBlockSizeMotionEstimation = new System.Windows.Forms.TextBox();
            this.txtThresholdMotionEstimation = new System.Windows.Forms.TextBox();
            this.btnStartMotionEstimationSD = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtBlocksGeneralized = new System.Windows.Forms.TextBox();
            this.txtBinsGeneralized = new System.Windows.Forms.TextBox();
            this.btnStartGeneralizedSD = new System.Windows.Forms.Button();
            this.lblBlocksGeneralized = new System.Windows.Forms.Label();
            this.lblBinsGeneralized = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmbAnnotation = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnPlayShot = new System.Windows.Forms.Button();
            this.btnAnnotate = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lstShots = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 108);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(15, 23);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(55, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(89, 23);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(204, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(114, 108);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(15, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 276);
            this.panel1.TabIndex = 0;
            // 
            // txtThreshold1
            // 
            this.txtThreshold1.Location = new System.Drawing.Point(162, 22);
            this.txtThreshold1.Name = "txtThreshold1";
            this.txtThreshold1.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold1.TabIndex = 6;
            // 
            // txtThreshold2
            // 
            this.txtThreshold2.Location = new System.Drawing.Point(162, 45);
            this.txtThreshold2.Name = "txtThreshold2";
            this.txtThreshold2.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartPixelDifferenceSD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtThreshold1);
            this.groupBox1.Controls.Add(this.txtThreshold2);
            this.groupBox1.Location = new System.Drawing.Point(385, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pixel Difference ShotDetection";
            // 
            // btnStartPixelDifferenceSD
            // 
            this.btnStartPixelDifferenceSD.Location = new System.Drawing.Point(83, 108);
            this.btnStartPixelDifferenceSD.Name = "btnStartPixelDifferenceSD";
            this.btnStartPixelDifferenceSD.Size = new System.Drawing.Size(75, 23);
            this.btnStartPixelDifferenceSD.TabIndex = 10;
            this.btnStartPixelDifferenceSD.Text = "Start SD";
            this.btnStartPixelDifferenceSD.UseVisualStyleBackColor = true;
            this.btnStartPixelDifferenceSD.Click += new System.EventHandler(this.StartPixelDifferenceSD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Threshold 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Threshold 1:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBins);
            this.groupBox2.Controls.Add(this.txtThreshold);
            this.groupBox2.Controls.Add(this.btnStartGlobalHistogramSD);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(385, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 137);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Global Histogram ShotDetection";
            // 
            // txtBins
            // 
            this.txtBins.Location = new System.Drawing.Point(162, 49);
            this.txtBins.Name = "txtBins";
            this.txtBins.Size = new System.Drawing.Size(100, 20);
            this.txtBins.TabIndex = 13;
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(162, 24);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(100, 20);
            this.txtThreshold.TabIndex = 12;
            // 
            // btnStartGlobalHistogramSD
            // 
            this.btnStartGlobalHistogramSD.Location = new System.Drawing.Point(83, 108);
            this.btnStartGlobalHistogramSD.Name = "btnStartGlobalHistogramSD";
            this.btnStartGlobalHistogramSD.Size = new System.Drawing.Size(75, 23);
            this.btnStartGlobalHistogramSD.TabIndex = 11;
            this.btnStartGlobalHistogramSD.Text = "Start SD";
            this.btnStartGlobalHistogramSD.UseVisualStyleBackColor = true;
            this.btnStartGlobalHistogramSD.Click += new System.EventHandler(this.StartGlobalHistogramSD_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number of bins:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Threshold:";
            // 
            // btnoutputfolder
            // 
            this.btnoutputfolder.Location = new System.Drawing.Point(204, 60);
            this.btnoutputfolder.Name = "btnoutputfolder";
            this.btnoutputfolder.Size = new System.Drawing.Size(75, 23);
            this.btnoutputfolder.TabIndex = 16;
            this.btnoutputfolder.Text = "Browse";
            this.btnoutputfolder.UseVisualStyleBackColor = true;
            this.btnoutputfolder.Click += new System.EventHandler(this.btnoutputfolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Outputfolder:";
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(89, 60);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(100, 20);
            this.txtoutput.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBlocks);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtBinsLocalHistogram);
            this.groupBox3.Controls.Add(this.txtThresholdLocalHistogram);
            this.groupBox3.Controls.Add(this.btnStartLocalHistogramSD);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(665, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 137);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Histogram ShotDetection";
            // 
            // txtBlocks
            // 
            this.txtBlocks.Location = new System.Drawing.Point(162, 73);
            this.txtBlocks.Name = "txtBlocks";
            this.txtBlocks.Size = new System.Drawing.Size(100, 20);
            this.txtBlocks.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Blocks:";
            // 
            // txtBinsLocalHistogram
            // 
            this.txtBinsLocalHistogram.Location = new System.Drawing.Point(162, 49);
            this.txtBinsLocalHistogram.Name = "txtBinsLocalHistogram";
            this.txtBinsLocalHistogram.Size = new System.Drawing.Size(100, 20);
            this.txtBinsLocalHistogram.TabIndex = 13;
            // 
            // txtThresholdLocalHistogram
            // 
            this.txtThresholdLocalHistogram.Location = new System.Drawing.Point(162, 24);
            this.txtThresholdLocalHistogram.Name = "txtThresholdLocalHistogram";
            this.txtThresholdLocalHistogram.Size = new System.Drawing.Size(100, 20);
            this.txtThresholdLocalHistogram.TabIndex = 12;
            // 
            // btnStartLocalHistogramSD
            // 
            this.btnStartLocalHistogramSD.Location = new System.Drawing.Point(83, 108);
            this.btnStartLocalHistogramSD.Name = "btnStartLocalHistogramSD";
            this.btnStartLocalHistogramSD.Size = new System.Drawing.Size(75, 23);
            this.btnStartLocalHistogramSD.TabIndex = 11;
            this.btnStartLocalHistogramSD.Text = "Start SD";
            this.btnStartLocalHistogramSD.UseVisualStyleBackColor = true;
            this.btnStartLocalHistogramSD.Click += new System.EventHandler(this.StartLocalHistogramSD_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Number of bins:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Threshold:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWindowSizeMotionEstimation);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtBlockSizeMotionEstimation);
            this.groupBox4.Controls.Add(this.txtThresholdMotionEstimation);
            this.groupBox4.Controls.Add(this.btnStartMotionEstimationSD);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(665, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 137);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Motion Estimation ShotDetection";
            // 
            // txtWindowSizeMotionEstimation
            // 
            this.txtWindowSizeMotionEstimation.Location = new System.Drawing.Point(162, 73);
            this.txtWindowSizeMotionEstimation.Name = "txtWindowSizeMotionEstimation";
            this.txtWindowSizeMotionEstimation.Size = new System.Drawing.Size(100, 20);
            this.txtWindowSizeMotionEstimation.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Window size:";
            // 
            // txtBlockSizeMotionEstimation
            // 
            this.txtBlockSizeMotionEstimation.Location = new System.Drawing.Point(162, 49);
            this.txtBlockSizeMotionEstimation.Name = "txtBlockSizeMotionEstimation";
            this.txtBlockSizeMotionEstimation.Size = new System.Drawing.Size(100, 20);
            this.txtBlockSizeMotionEstimation.TabIndex = 13;
            // 
            // txtThresholdMotionEstimation
            // 
            this.txtThresholdMotionEstimation.Location = new System.Drawing.Point(162, 24);
            this.txtThresholdMotionEstimation.Name = "txtThresholdMotionEstimation";
            this.txtThresholdMotionEstimation.Size = new System.Drawing.Size(100, 20);
            this.txtThresholdMotionEstimation.TabIndex = 12;
            // 
            // btnStartMotionEstimationSD
            // 
            this.btnStartMotionEstimationSD.Location = new System.Drawing.Point(83, 108);
            this.btnStartMotionEstimationSD.Name = "btnStartMotionEstimationSD";
            this.btnStartMotionEstimationSD.Size = new System.Drawing.Size(75, 23);
            this.btnStartMotionEstimationSD.TabIndex = 11;
            this.btnStartMotionEstimationSD.Text = "Start SD";
            this.btnStartMotionEstimationSD.UseVisualStyleBackColor = true;
            this.btnStartMotionEstimationSD.Click += new System.EventHandler(this.StartMotionEstimationSD_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Block size:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Threshold:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtBlocksGeneralized);
            this.groupBox5.Controls.Add(this.txtBinsGeneralized);
            this.groupBox5.Controls.Add(this.btnStartGeneralizedSD);
            this.groupBox5.Controls.Add(this.lblBlocksGeneralized);
            this.groupBox5.Controls.Add(this.lblBinsGeneralized);
            this.groupBox5.Location = new System.Drawing.Point(665, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 137);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generalized ShotDetection";
            // 
            // txtBlocksGeneralized
            // 
            this.txtBlocksGeneralized.Location = new System.Drawing.Point(162, 49);
            this.txtBlocksGeneralized.Name = "txtBlocksGeneralized";
            this.txtBlocksGeneralized.Size = new System.Drawing.Size(100, 20);
            this.txtBlocksGeneralized.TabIndex = 13;
            // 
            // txtBinsGeneralized
            // 
            this.txtBinsGeneralized.Location = new System.Drawing.Point(162, 24);
            this.txtBinsGeneralized.Name = "txtBinsGeneralized";
            this.txtBinsGeneralized.Size = new System.Drawing.Size(100, 20);
            this.txtBinsGeneralized.TabIndex = 12;
            // 
            // btnStartGeneralizedSD
            // 
            this.btnStartGeneralizedSD.Location = new System.Drawing.Point(83, 108);
            this.btnStartGeneralizedSD.Name = "btnStartGeneralizedSD";
            this.btnStartGeneralizedSD.Size = new System.Drawing.Size(75, 23);
            this.btnStartGeneralizedSD.TabIndex = 11;
            this.btnStartGeneralizedSD.Text = "Start SD";
            this.btnStartGeneralizedSD.UseVisualStyleBackColor = true;
            this.btnStartGeneralizedSD.Click += new System.EventHandler(this.StartGeneralizedSD_Click);
            // 
            // lblBlocksGeneralized
            // 
            this.lblBlocksGeneralized.AutoSize = true;
            this.lblBlocksGeneralized.Location = new System.Drawing.Point(9, 49);
            this.lblBlocksGeneralized.Name = "lblBlocksGeneralized";
            this.lblBlocksGeneralized.Size = new System.Drawing.Size(42, 13);
            this.lblBlocksGeneralized.TabIndex = 10;
            this.lblBlocksGeneralized.Text = "Blocks:";
            // 
            // lblBinsGeneralized
            // 
            this.lblBinsGeneralized.AutoSize = true;
            this.lblBinsGeneralized.Location = new System.Drawing.Point(9, 27);
            this.lblBinsGeneralized.Name = "lblBinsGeneralized";
            this.lblBinsGeneralized.Size = new System.Drawing.Size(81, 13);
            this.lblBinsGeneralized.TabIndex = 9;
            this.lblBinsGeneralized.Text = "Number of bins:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblFileName);
            this.groupBox6.Controls.Add(this.txtFileName);
            this.groupBox6.Controls.Add(this.btnBrowse);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.btnoutputfolder);
            this.groupBox6.Controls.Add(this.btnPause);
            this.groupBox6.Controls.Add(this.txtoutput);
            this.groupBox6.Controls.Add(this.btnStart);
            this.groupBox6.Location = new System.Drawing.Point(15, 294);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 137);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Play/Pause video";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.progressBar1);
            this.groupBox7.Controls.Add(this.cmbAnnotation);
            this.groupBox7.Controls.Add(this.btnExport);
            this.groupBox7.Controls.Add(this.btnRetrieve);
            this.groupBox7.Controls.Add(this.btnPlayShot);
            this.groupBox7.Controls.Add(this.btnAnnotate);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.lstShots);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Location = new System.Drawing.Point(385, 294);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(268, 141);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Shots";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(81, 18);
            this.progressBar1.Maximum = 1736;
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Step = 200;
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // cmbAnnotation
            // 
            this.cmbAnnotation.Enabled = false;
            this.cmbAnnotation.FormattingEnabled = true;
            this.cmbAnnotation.Location = new System.Drawing.Point(141, 59);
            this.cmbAnnotation.Name = "cmbAnnotation";
            this.cmbAnnotation.Size = new System.Drawing.Size(121, 21);
            this.cmbAnnotation.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(28, 107);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Enabled = false;
            this.btnRetrieve.Location = new System.Drawing.Point(187, 107);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 6;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnPlayShot
            // 
            this.btnPlayShot.Enabled = false;
            this.btnPlayShot.Location = new System.Drawing.Point(187, 18);
            this.btnPlayShot.Name = "btnPlayShot";
            this.btnPlayShot.Size = new System.Drawing.Size(75, 23);
            this.btnPlayShot.TabIndex = 5;
            this.btnPlayShot.Text = "Play shot";
            this.btnPlayShot.UseVisualStyleBackColor = true;
            this.btnPlayShot.Click += new System.EventHandler(this.btnPlayShot_Click);
            // 
            // btnAnnotate
            // 
            this.btnAnnotate.Enabled = false;
            this.btnAnnotate.Location = new System.Drawing.Point(109, 107);
            this.btnAnnotate.Name = "btnAnnotate";
            this.btnAnnotate.Size = new System.Drawing.Size(72, 23);
            this.btnAnnotate.TabIndex = 4;
            this.btnAnnotate.Text = "Annotate";
            this.btnAnnotate.UseVisualStyleBackColor = true;
            this.btnAnnotate.Click += new System.EventHandler(this.btnAnnotate_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Annotation:";
            // 
            // lstShots
            // 
            this.lstShots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstShots.Enabled = false;
            this.lstShots.FormattingEnabled = true;
            this.lstShots.Location = new System.Drawing.Point(83, 20);
            this.lstShots.Name = "lstShots";
            this.lstShots.Size = new System.Drawing.Size(98, 21);
            this.lstShots.TabIndex = 1;
            this.lstShots.SelectedIndexChanged += new System.EventHandler(this.lstShotsChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Select shot:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 447);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Video Shot Detection, Annotation and Retrieval";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel panel1;

        enum State
        {
            Uninit,
            Stopped,
            Paused,
            Playing,
            ShotPlaying,
            ShotPaused
        }
        State m_State = State.Uninit;
        DxPlay m_play = null;
        Frames frames;

        //click on start button
        private void btnStart_Click(object sender, System.EventArgs e)
        {

            // If necessary, close the old file
            if (m_State == State.Stopped)
            {
                // Did the filename change?
                if (txtFileName.Text != m_play.FileName)
                {
                    // File name changed, close the old file
                    m_play.Dispose();
                    m_play = null;
                    m_State = State.Uninit;
                }
            }

            // If we have no file open
            if (m_play == null)
            {
                try
                {
                    // Open the file, provide a handle to play it in
                    m_play = new DxPlay(panel1, txtFileName.Text);

                    // Let us know when the file is finished playing
                    m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlay);
                    m_State = State.Stopped;
                }
                catch (COMException ce)
                {
                    MessageBox.Show("Failed to open file: " + ce.Message, "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (m_State == State.ShotPaused)
            {
                btnPlayShot.Text = "Play shot";
                m_State = State.Stopped;
                m_play.Rewind();
            }
            // If we were stopped, start
            if (m_State == State.Stopped)
            {
                btnStart.Text = "Stop";
                m_play.Start();
                btnPause.Enabled = true;
                btnPlayShot.Enabled = false;
                //btnRetrieve.Enabled = false;
                //btnAnnotate.Enabled = false;
                //btnExport.Enabled = false;
                txtFileName.Enabled = false;
                //cmbAnnotation.Enabled = false;
                //lstShots.Enabled = false;
                btnBrowse.Enabled = false;
                m_State = State.Playing;
            }

            // If we are playing or paused, stop
            else if (m_State == State.Playing || m_State == State.Paused)
            {
                m_play.Stop();
                btnPause.Enabled = false;
                txtFileName.Enabled = true;
                btnBrowse.Enabled = true;
                if (lstShots.Items.Count != 0)
                {
                    //lstShots.Enabled = true;
                    //btnRetrieve.Enabled = true;
                    //btnExport.Enabled = true;
                    //cmbAnnotation.Enabled = true;
                    if (lstShots.SelectedItem != null)
                    {
                        btnPlayShot.Enabled = true;
                        //btnAnnotate.Enabled = true;
                    }
                }
                btnStart.Text = "Start";
                btnPause.Text = "Pause";
                m_State = State.Stopped;
            }
        }

        //click on pause button
        private void btnPause_Click(object sender, System.EventArgs e)
        {
            // If we are playing, pause
            if (m_State == State.Playing)
            {
                m_play.Pause();
                btnPause.Text = "Resume";
                m_State = State.Paused;
            }
            // If we are paused, start
            else
            {
                m_play.Start();
                btnPause.Text = "Pause";
                m_State = State.Playing;
            }
        }

        //click on browse button to show a file browser
        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                lstShots.Items.Clear();
                lstShots.Enabled = false;
                btnPlayShot.Enabled = false;
                btnRetrieve.Enabled = false;
                btnAnnotate.Enabled = false;
                btnExport.Enabled = false;
                cmbAnnotation.Items.Clear();
                cmbAnnotation.Enabled = false;

            }
        }

        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender)
        {
            // This isn't the right way to do this, but heck, it's only a sample
            CheckForIllegalCrossThreadCalls = false;

            btnStart.Enabled = true;
            btnPause.Enabled = false;
            txtFileName.Enabled = true;
            btnBrowse.Enabled = true;
            btnStart.Text = "Start";
            btnPause.Text = "Pause";
            btnPlayShot.Text = "Play shot";
            if (lstShots.Items.Count != 0)
            {
                //lstShots.Enabled = true;
                //btnRetrieve.Enabled = true;
                //btnExport.Enabled = true;
                //cmbAnnotation.Enabled = true;
                if (lstShots.SelectedItem != null)
                {
                    btnPlayShot.Enabled = true;
                    btnAnnotate.Enabled = true;
                }
            }

            CheckForIllegalCrossThreadCalls = true;

            m_State = State.Stopped;

            // Rewind clip to beginning to allow DxPlay.Start to work again.
            m_play.Rewind();
        }
        //Select output
        private void btnoutputfolder_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog  fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtoutput.Text = fbd.SelectedPath;
            }
        }

        private void btnPlayShot_Click(object sender, System.EventArgs e)
        {
            char[] delimiterChars = { '-' };
            string[] frames = lstShots.SelectedItem.ToString().Split(delimiterChars);

            // If necessary, close the old file
            if (m_State == State.Stopped)
            {
                // Did the filename change?
                if (txtFileName.Text != m_play.FileName)
                {
                    // File name changed, close the old file
                    m_play.Dispose();
                    m_play = null;
                    m_State = State.Uninit;
                }
            }

            // If we have no file open
            if (m_play == null)
            {
                try
                {
                    // Open the file, provide a handle to play it in
                    m_play = new DxPlay(panel1, txtFileName.Text);

                    // Let us know when the file is finished playing
                    m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlay);
                    m_State = State.Stopped;
                }
                catch (COMException ce)
                {
                    MessageBox.Show("Failed to open file: " + ce.Message, "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (m_State == State.Stopped)
            {
                m_play.playShot((long)Int16.Parse(frames[0]), (long)Int16.Parse(frames[1]));
                btnStart.Enabled = false;
                btnPlayShot.Text = "Pause shot";
                m_State = State.ShotPlaying;
            }
            else if (m_State == State.ShotPlaying)
            {
                m_play.Pause();
                btnStart.Enabled = true;
                btnPlayShot.Text = "Resume shot";
                m_State = State.ShotPaused;
            }
            // If we are paused, start
            else if (m_State == State.ShotPaused)
            {
                m_play.Start();
                btnStart.Enabled = false;
                btnPlayShot.Text = "Pause shot";
                m_State = State.ShotPlaying;
            }
        }

        public void DisplayProgress()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DetectionAlgorithm.ProgressDelegate(DisplayProgress));
            }
            else
            {
                this.progressBar1.PerformStep();
            }
        }

        private void StartPixelDifferenceSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();            
            lstShots.Items.Clear();
            int temp;
            if (txtFileName.Text == "") 
            {
                MessageBox.Show("No input file selected.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!((int.TryParse(txtThreshold1.Text, out temp)) && (int.TryParse(txtThreshold2.Text, out temp))))
            {
                MessageBox.Show("Wrong input format for parameters.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DetectionAlgorithm pd = new PixelDifference(Int16.Parse(txtThreshold1.Text), Int16.Parse(txtThreshold2.Text));
                pd.Progress += new DetectionAlgorithm.ProgressDelegate(DisplayProgress);
                progressBar1.Visible = true;
                // Begin timing
                stopwatch.Start();
                frames = new Frames(txtFileName.Text, pd);
                progressBar1.Maximum = (int)frames.getFrameCount();
                frames.Start();
                frames.WaitUntilDone();
                pd.addLastFrame();
                stopwatch.Stop();
                List<int> detectedShots = pd.getDetectedShots();
                for (int i = 0; i < detectedShots.Count() - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
                progressBar1.Value = 1;
                progressBar1.Visible = false;
                lstShots.Enabled = true;
                btnExport.Enabled = true;
                btnRetrieve.Enabled = true;
                cmbAnnotation.Enabled = true;
                MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        
            }
        }

        

        private void StartGlobalHistogramSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.GlobalHistogramSD(Double.Parse(txtThreshold.Text), Int32.Parse(txtBins.Text));
            lstShots.Items.Clear();
            int temp;
            if (txtFileName.Text == "")
            {
                MessageBox.Show("No input file selected.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!((int.TryParse(txtThreshold.Text, out temp)) && (int.TryParse(txtBins.Text, out temp))))
            {
                MessageBox.Show("Wrong input format for parameters.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if( Int32.Parse(txtBins.Text)<1 || Int32.Parse(txtBins.Text) > 256 )
            {
                MessageBox.Show("Number of bins should be between 1 and 256.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);           
            }
            else
            {
                DetectionAlgorithm ghSD = new GlobalHistogramSD(Double.Parse(txtThreshold.Text), Int32.Parse(txtBins.Text));
                ghSD.Progress += new DetectionAlgorithm.ProgressDelegate(DisplayProgress);
                progressBar1.Visible = true;
                // Begin timing
                stopwatch.Start();
                frames = new Frames(txtFileName.Text, ghSD);
                progressBar1.Maximum = (int)frames.getFrameCount();
                frames.Start();
                frames.WaitUntilDone();
                ghSD.addLastFrame();
                stopwatch.Stop();
                List<int> detectedShots = ghSD.getDetectedShots();
                for (int i = 0; i < detectedShots.Count() - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
                progressBar1.Value = 1;
                progressBar1.Visible = false;
                lstShots.Enabled = true;
                btnExport.Enabled = true;
                btnRetrieve.Enabled = true;
                cmbAnnotation.Enabled = true;
                MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void StartLocalHistogramSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.LocalHistogramSD(Double.Parse(txtThresholdLocalHistogram.Text), Int32.Parse(txtBinsLocalHistogram.Text),Int32.Parse(txtRegionsize.Text));
            lstShots.Items.Clear();
            int temp;
            if (txtFileName.Text == "")
            {
                MessageBox.Show("No input file selected.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!((int.TryParse(txtThresholdLocalHistogram.Text, out temp)) && (int.TryParse(txtBinsLocalHistogram.Text, out temp)) && (int.TryParse(txtBlocks.Text, out temp))))
            {
                MessageBox.Show("Wrong input format for parameters.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if( Int32.Parse(txtBinsLocalHistogram.Text)<1 || Int32.Parse(txtBinsLocalHistogram.Text) > 256 )
            {
                MessageBox.Show("Number of bins should be between 1 and 256.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);           
            }
            else if (Math.Pow(Math.Sqrt(temp), 2) != temp)
            {
                MessageBox.Show("Amount of blocks should be a square.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DetectionAlgorithm lhSD = new LocalHistogramSD(double.Parse(txtThresholdLocalHistogram.Text), Int32.Parse(txtBinsLocalHistogram.Text), Int32.Parse(txtBlocks.Text));
                lhSD.Progress += new DetectionAlgorithm.ProgressDelegate(DisplayProgress);
                progressBar1.Visible = true;
                // Begin timing
                stopwatch.Start();
                frames = new Frames(txtFileName.Text, lhSD);
                progressBar1.Maximum = (int)frames.getFrameCount();
                frames.Start();
                frames.WaitUntilDone();
                lhSD.addLastFrame();
                stopwatch.Stop();
                List<int> detectedShots = lhSD.getDetectedShots();
                for (int i = 0; i < detectedShots.Count() - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
                progressBar1.Value = 1;
                progressBar1.Visible = false;
                lstShots.Enabled = true;
                btnExport.Enabled = true;
                btnRetrieve.Enabled = true;
                cmbAnnotation.Enabled = true;
                MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void StartMotionEstimationSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.LocalHistogramSD(Double.Parse(txtThresholdLocalHistogram.Text), Int32.Parse(txtBinsLocalHistogram.Text),Int32.Parse(txtRegionsize.Text));
            lstShots.Items.Clear();
            int temp;
            if (txtFileName.Text == "")
            {
                MessageBox.Show("No input file selected.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!((int.TryParse(txtThresholdMotionEstimation.Text, out temp)) && (int.TryParse(txtBlockSizeMotionEstimation.Text, out temp)) && (int.TryParse(txtWindowSizeMotionEstimation.Text, out temp))))
            {
                MessageBox.Show("Wrong input format for parameters.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DetectionAlgorithm meSD = new MotionEstimation(double.Parse(txtThresholdMotionEstimation.Text), Int32.Parse(txtBlockSizeMotionEstimation.Text), Int32.Parse(txtWindowSizeMotionEstimation.Text));
                meSD.Progress += new DetectionAlgorithm.ProgressDelegate(DisplayProgress);
                progressBar1.Visible = true;
                // Begin timing
                stopwatch.Start();
                frames = new Frames(txtFileName.Text, meSD);
                progressBar1.Maximum = (int)frames.getFrameCount();
                frames.Start();
                frames.WaitUntilDone();
                meSD.addLastFrame();
                stopwatch.Stop();
                List<int> detectedShots = meSD.getDetectedShots();
                for (int i = 0; i < detectedShots.Count() - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
                progressBar1.Value = 1;
                progressBar1.Visible = false;
                lstShots.Enabled = true;
                btnExport.Enabled = true;
                btnRetrieve.Enabled = true;
                cmbAnnotation.Enabled = true;
                MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void StartGeneralizedSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();            
            lstShots.Items.Clear();
            int temp;
            if (txtFileName.Text == "")
            {
                MessageBox.Show("No input file selected.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!((int.TryParse(txtBinsGeneralized.Text, out temp)) && (int.TryParse(txtBlocksGeneralized.Text, out temp))))
            {
                MessageBox.Show("Wrong input format for parameters.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if( Int32.Parse(txtBinsGeneralized.Text)<1 || Int32.Parse(txtBinsGeneralized.Text) > 256 )
            {
                MessageBox.Show("Number of bins should be between 1 and 256.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);           
            }
            else if (Math.Pow(Math.Sqrt(temp), 2) != temp)
            {
                MessageBox.Show("Amount of blocks should be a square.", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                GeneralizedSD gSD = new GeneralizedSD(Int32.Parse(txtBinsGeneralized.Text), Int32.Parse(txtBlocksGeneralized.Text));
                gSD.Progress += new DetectionAlgorithm.ProgressDelegate(DisplayProgress);
                progressBar1.Visible = true;
                // Begin timing
                stopwatch.Start();
                frames = new Frames(txtFileName.Text, gSD);
                progressBar1.Maximum = (int)frames.getFrameCount();
                frames.Start();
                frames.WaitUntilDone();
                gSD.detectGradualTransitions();
                gSD.addLastFrame();
                stopwatch.Stop();
                List<int> detectedShots = gSD.getDetectedShots();
                for (int i = 0; i < detectedShots.Count() - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
                progressBar1.Value = 1;
                progressBar1.Visible = false;
                lstShots.Enabled = true;
                btnExport.Enabled = true;
                btnRetrieve.Enabled = true;
                cmbAnnotation.Enabled = true;
                MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //when the user clicks on the export button, the shot information found is exported to an XML-file
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtoutput.Text == "")
            {
                MessageBox.Show("No output folder selected", "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DetectionAlgorithm algo = frames.getDetectionAlgo();
                List<int> detectedShots = algo.getDetectedShots();
                char[] delimiterChars = { '\\' };
                string[] path = txtFileName.Text.Split(delimiterChars);
                //export the XML-files
                algo.export(path[path.Length - 1], txtoutput.Text);

                //fill the list with the correct framenumbers
                algo.fillFramesToExport();

                //check if the folder exists  or not
                bool exists = System.IO.Directory.Exists(txtoutput.Text + "\\shots");

                //if it does not exist, create it
                if (!exists)
                    System.IO.Directory.CreateDirectory(txtoutput.Text + "\\shots");

                //set the outputfile location for the exported frames
                algo.setOutputFile(txtoutput.Text + "\\shots");
                frames = new Frames(txtFileName.Text, algo);
                frames.Start();
                frames.WaitUntilDone();
            }
        }

        private void btnAnnotate_Click(object sender, EventArgs e)
        {
            string annotation = cmbAnnotation.Text;
            //if the user has filled in something and it isn't in the list yet
            if (annotation != null && annotation != "" && !cmbAnnotation.Items.Contains(annotation))
            {
                //get the starting frame of the shot, this is to be able to get the index 
                //in the annoation array
                char[] delimiterChars = { '-' };
                string[] frame = lstShots.SelectedItem.ToString().Split(delimiterChars);

                DetectionAlgorithm algo = frames.getDetectionAlgo();
                //get the index of the shot in the list, this is the same index as in the annotations array
                int index = algo.getDetectedShots().IndexOf(Int16.Parse(frame[0]));
                algo.annotate(index, annotation);
                cmbAnnotation.Items.Add(annotation);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string annotation = cmbAnnotation.Text;
            //reset the shots so it can be filled with the shots which has the specific annotation
            lstShots.ResetText();
            lstShots.Items.Clear();
            DetectionAlgorithm algo = frames.getDetectionAlgo();
            List<int> detectedShots = algo.getDetectedShots();
            List<string>[] annotations = algo.getAnnotations();
            //if an annotation has been filled in, retrieve the shots with that annotation
            if (annotation != null && annotation != "")
            {
                //if the array exists, if there is at least one annotation
                if (annotations != null)
                {
                    for (int i = 0; i < annotations.Length; i++)
                    {
                        //if there is at least one annotation for this shot and the annotation exists
                        if (annotations[i] != null && annotations[i].Contains(annotation))
                        {
                            lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                        }
                    }
                }
            }
            //else fill the list with all the shots
            else
            {
                for (int i = 0; i < detectedShots.Count - 1; i++)
                {
                    lstShots.Items.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                }
            }
            cmbAnnotation.ResetText();
            cmbAnnotation.Items.Clear();
        }

        //event listener for when the user selects a specific shot
        private void lstShotsChanged(object sender, EventArgs e)
        {
            if (!btnStart.Text.Equals("Stop"))
                btnPlayShot.Enabled = true;
            btnAnnotate.Enabled = true;
            //btnRetrieve.Enabled = true;
            cmbAnnotation.Enabled = true;
            cmbAnnotation.ResetText();
            cmbAnnotation.Items.Clear();
            //workaround for the visual bug which showed a large white box instead of an empty dropdown
            cmbAnnotation.Items.Add("");
            cmbAnnotation.Items.Clear();
            List<string>[] annotations = frames.getDetectionAlgo().getAnnotations();
            //fill the annotations at the correct shots
            if (annotations != null)
            {
                //get the starting frame of the shot, to get the index of the annotations array
                char[] delimiterChars = { '-' };
                string[] frame = lstShots.SelectedItem.ToString().Split(delimiterChars);

                DetectionAlgorithm algo = frames.getDetectionAlgo();
                int index = algo.getDetectedShots().IndexOf(Int16.Parse(frame[0]));
                //fill the annotations combobox
                if (annotations[index] != null)
                {
                    for (int i = 0; i < annotations[index].Count; i++)
                    {
                        cmbAnnotation.Items.Add(annotations[index][i]);
                    }
                }
            }
        }

        private TextBox txtThreshold1;
        private TextBox txtThreshold2;
        private GroupBox groupBox1;
        private Button btnStartPixelDifferenceSD;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private TextBox txtBins;
        private TextBox txtThreshold;
        private Button btnStartGlobalHistogramSD;
        private Button btnoutputfolder;
        private Label label3;
        private TextBox txtoutput;
        private GroupBox groupBox3;
        private TextBox txtBlocks;
        private Label label8;
        private TextBox txtBinsLocalHistogram;
        private TextBox txtThresholdLocalHistogram;
        private Button btnStartLocalHistogramSD;
        private Label label6;
        private Label label7;
        private GroupBox groupBox4;
        private TextBox txtWindowSizeMotionEstimation;
        private Label label9;
        private TextBox txtBlockSizeMotionEstimation;
        private TextBox txtThresholdMotionEstimation;
        private Button btnStartMotionEstimationSD;
        private Label label10;
        private Label label11;
        private GroupBox groupBox5;
        private TextBox txtBlocksGeneralized;
        private TextBox txtBinsGeneralized;
        private Button btnStartGeneralizedSD;
        private Label lblBlocksGeneralized;
        private Label lblBinsGeneralized;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private Label label12;
        private ComboBox lstShots;
        private Button btnAnnotate;
        private Label label13;
        private Button btnPlayShot;
        private Button btnRetrieve;
        private Button btnExport;
        private ComboBox cmbAnnotation;
        private ProgressBar progressBar1;
        
    }
}

