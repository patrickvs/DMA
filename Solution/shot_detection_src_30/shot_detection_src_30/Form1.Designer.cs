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
            this.txtBinsLocalHistogram = new System.Windows.Forms.TextBox();
            this.txtThresholdLocalHistogram = new System.Windows.Forms.TextBox();
            this.btnStartLocalHistogramSD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRegionsize = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 458);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(13, 434);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(55, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.Location = new System.Drawing.Point(94, 431);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 20);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.Text = "c:\\test.avi";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.Location = new System.Drawing.Point(200, 429);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(94, 458);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 235);
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
            this.groupBox1.Location = new System.Drawing.Point(596, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 113);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pixel Difference ShotDetection";
            // 
            // btnStartPixelDifferenceSD
            // 
            this.btnStartPixelDifferenceSD.Location = new System.Drawing.Point(83, 79);
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
            this.groupBox2.Location = new System.Drawing.Point(596, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 116);
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
            this.btnStartGlobalHistogramSD.Location = new System.Drawing.Point(83, 80);
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
            this.btnoutputfolder.Location = new System.Drawing.Point(500, 431);
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
            this.label3.Location = new System.Drawing.Point(298, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Outputfolder:";
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(394, 431);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(100, 20);
            this.txtoutput.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRegionsize);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtBinsLocalHistogram);
            this.groupBox3.Controls.Add(this.txtThresholdLocalHistogram);
            this.groupBox3.Controls.Add(this.btnStartLocalHistogramSD);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(596, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 137);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Histogram ShotDetection";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Region size:";
            // 
            // txtRegionsize
            // 
            this.txtRegionsize.Location = new System.Drawing.Point(162, 73);
            this.txtRegionsize.Name = "txtRegionsize";
            this.txtRegionsize.Size = new System.Drawing.Size(100, 20);
            this.txtRegionsize.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 493);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnoutputfolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtoutput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Video Shot Detection, Annotation and Retrieval";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
            Playing
        }
        State m_State = State.Uninit;
        DxPlay m_play = null;

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

            // If we were stopped, start
            if (m_State == State.Stopped)
            {
                btnStart.Text = "Stop";
                m_play.Start();
                btnPause.Enabled = true;
                txtFileName.Enabled = false;
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
            }
        }

        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender)
        {
            // This isn't the right way to do this, but heck, it's only a sample
            CheckForIllegalCrossThreadCalls = false;

            btnPause.Enabled = false;
            txtFileName.Enabled = true;
            btnBrowse.Enabled = true;
            btnStart.Text = "Start";
            btnPause.Text = "Pause";

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
        private void StartPixelDifferenceSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing
            stopwatch.Start();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.PixelDifferenceSD(Double.Parse(txtThreshold1.Text), Double.Parse(txtThreshold2.Text)*SD.width*SD.height/100);

            DetectionAlgorithm pd = new PixelDifference(Int16.Parse(txtThreshold1.Text), Int16.Parse(txtThreshold2.Text));
            Frames frames = new Frames(txtFileName.Text, pd);
            List<int> detectedShots = pd.getDetectedShots();
            detectedShots.Add(pd.getFrameNumber());         
            stopwatch.Stop();
            List<String> shotList = new List<String>();
            for (int i = 0; i < detectedShots.Count() - 1; i++)
            {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
            }
            XDocument doc = new XDocument(
                    new XElement("ShotDetection",
                        new XElement("shot", shotList.Select(x => new XElement("shot", new XAttribute("value", x))))
                    )
            );
            //Save the document to a file.
            doc.Save(txtoutput.Text + "\\PixelDifferenceSD.xml"); 
            MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void StartGlobalHistogramSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing
            stopwatch.Start();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.GlobalHistogramSD(Double.Parse(txtThreshold.Text), Int32.Parse(txtBins.Text));

            DetectionAlgorithm ghSD = new GlobalHistogramSD(Double.Parse(txtThreshold.Text), Int32.Parse(txtBins.Text));
            Frames frames = new Frames(txtFileName.Text, ghSD);
            List<int> detectedShots = ghSD.getDetectedShots();
            detectedShots.Add(ghSD.getFrameNumber());
            stopwatch.Stop();
            List<String> shotList = new List<String>();
            for (int i = 0; i < detectedShots.Count() - 1; i++)
            {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
            }
            XDocument doc = new XDocument(
                    new XElement("ShotDetection",
                        new XElement("shot", shotList.Select(x => new XElement("shot", new XAttribute("value", x))))
                    )
            );
            MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //Save the document to a file.
            doc.Save(txtoutput.Text + "\\GlobalHistogramSD.xml");

        }

        private void StartLocalHistogramSD_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing
            stopwatch.Start();
            //ShotDetection SD = new ShotDetection(txtFileName.Text);
            //List<String> shotsDetected = SD.LocalHistogramSD(Double.Parse(txtThresholdLocalHistogram.Text), Int32.Parse(txtBinsLocalHistogram.Text),Int32.Parse(txtRegionsize.Text));
            DetectionAlgorithm lhSD = new LocalHistogramSD(double.Parse(txtThresholdLocalHistogram.Text), Int32.Parse(txtBinsLocalHistogram.Text), Int32.Parse(txtRegionsize.Text));
            Frames frames = new Frames(txtFileName.Text, lhSD);
            List<int> detectedShots = lhSD.getDetectedShots();
            detectedShots.Add(lhSD.getFrameNumber());
            stopwatch.Stop();
            List<String> shotList = new List<String>();
            for (int i = 0; i < detectedShots.Count() - 1; i++)
            {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
            }
            XDocument doc = new XDocument(
                    new XElement("ShotDetection",
                        new XElement("shot", shotList.Select(x => new XElement("shot", new XAttribute("value", x))))
                    )
            );
            MessageBox.Show("The Shot Detection is completed in " + stopwatch.Elapsed, "SD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //Save the document to a file.
            doc.Save(txtoutput.Text + "\\LocalHistogramSD.xml");

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
        private TextBox txtRegionsize;
        private Label label8;
        private TextBox txtBinsLocalHistogram;
        private TextBox txtThresholdLocalHistogram;
        private Button btnStartLocalHistogramSD;
        private Label label6;
        private Label label7;
        
    }
}

