﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    public class GlobalHistogramSD : DetectionAlgorithm
    {
        private double tresh;
        private int bins;

        public GlobalHistogramSD(double tresh, int bins)
        {
            this.tresh = tresh;
            this.bins = bins;
            detectedShots.Add(0); //first frame is the start of a shot
        }

        public override void compareFrames(byte[] p, byte[] c, int frameNumber)
        {
            if (frameNumber != 0)
            {
                int[] prevhistoR = getHistogram(p, bins, 0);
                int[] prevhistoG = getHistogram(p, bins, 1);
                int[] prevhistoB = getHistogram(p, bins, 2);

                int[] curhistoR = getHistogram(c, bins, 0);
                int[] curhistoG = getHistogram(c, bins, 1);
                int[] curhistoB = getHistogram(c, bins, 2);
                //calculate diff between prev and cur
                int diff = 0;
                for (int j = 0; j < bins; j++)
                {
                    diff += Math.Abs(prevhistoR[j] - curhistoR[j]);
                    diff += Math.Abs(prevhistoG[j] - curhistoG[j]);
                    diff += Math.Abs(prevhistoB[j] - curhistoB[j]);
                }
                //compare diff to treshold
                if (diff > tresh)
                    //add to list of detected shots
                    detectedShots.Add(frameNumber);
            }
        }

        private int[] getHistogram(Byte[] frame, int bins, int c)
        {
            int[] histogram = new int[bins];
            for (int x = 0; x < m_videoWidth; x++)
            {
                for (int y = 0; y < m_videoHeight; y++)
                {
                    histogram[(frame[(y * m_videoWidth + x) * 3 + c]) / (int)Math.Ceiling(256.0 / bins)]++;
                }
            }
            return histogram;
        }

        public override void export(string inputfile, string outputfolder)
        {
            XDocument doc = new XDocument(
                    new XElement("ShotDetection", new XAttribute("file", inputfile),
                        new XElement("method", new XAttribute("nr", 3),
                        new XElement("param1", tresh),
                        new XElement("param2", bins))
                    )
            );
            addShotInformation(doc);
            //Save the document to a file.
            doc.Save(outputfolder + "\\GlobalHistogramSD.xml"); 
        }
    }
}
