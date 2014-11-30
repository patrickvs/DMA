using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    public class LocalHistogramSD : DetectionAlgorithm
    {
        private double tresh;
        private int bins;
        private int regionsize;

        public LocalHistogramSD(double tresh, int bins, int regionsize)
        {
            this.tresh = tresh;
            this.bins = bins;
            this.regionsize = regionsize;
            detectedShots.Add(0); //first frame is start of a shot
        }

        public override void compareFrames(byte[] p, byte[] c, int frameNumber)
        {

            if (frameNumber != 0)
            {
                int horizontalregions = m_videoWidth / regionsize;
                int verticalregions = m_videoHeight / regionsize;

                int diff = 0;
                //loop over all regions
                for (int r = 0; r < horizontalregions; r++)
                {
                    for (int q = 0; q < verticalregions; q++)
                    {
                        int[] prevhistoR = getLocalHistogram(p, bins, 0, r, q, regionsize);
                        int[] prevhistoG = getLocalHistogram(p, bins, 1, r, q, regionsize);
                        int[] prevhistoB = getLocalHistogram(p, bins, 2, r, q, regionsize);
                        int[] curhistoR = getLocalHistogram(c, bins, 0, r, q, regionsize);
                        int[] curhistoG = getLocalHistogram(c, bins, 1, r, q, regionsize);
                        int[] curhistoB = getLocalHistogram(c, bins, 2, r, q, regionsize);
                        //calculate diff between prev and cur for selected region
                        for (int j = 0; j < bins; j++)
                        {
                            diff += Math.Abs(prevhistoR[j] - curhistoR[j]);
                            diff += Math.Abs(prevhistoG[j] - curhistoG[j]);
                            diff += Math.Abs(prevhistoB[j] - curhistoB[j]);
                        }
                    }
                }
                //compare diff to treshold
                if (diff > tresh)
                    //add to list of detected shots
                    detectedShots.Add(frameNumber);
            }
        }

        private int[] getLocalHistogram(Byte[] frame, int bins, int c, int curhor, int curvert, int regionsize)
        {
            int[] histogram = new int[bins];
            for (int x = curhor * regionsize; x < ((curhor + 1) * regionsize); x++)
            {
                for (int y = curvert * regionsize; y < ((curvert + 1) * regionsize); y++)
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
                        new XElement("method", new XAttribute("nr", 4),
                        new XElement("param1", tresh),
                        new XElement("param2", bins),
                        new XElement("param3", regionsize))
                    )
            );
            addShotInformation(doc);
            //Save the document to a file.
            doc.Save(outputfolder + "\\LocalHistogramSD.xml"); 
        }
    }
}
