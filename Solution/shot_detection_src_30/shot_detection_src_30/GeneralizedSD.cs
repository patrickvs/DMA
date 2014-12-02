using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    class GeneralizedSD : DetectionAlgorithm
    {

        /* used papers:
         * http://www.moivre.usherbrooke.ca/sites/default/files/1.pdf
         * http://www.roman10.net/video-boundary-detectionpart-2-gradual-transition-and-its-matlab-implementation/
         * http://roman10.net/src/gradual_transition_detection.m
         * http://hrcak.srce.hr/file/40946
         */

        private int bins;
        private int blocks;
        private List<int> differences = new List<int>();
        private double highTresh;
        private double lowTresh;

        public GeneralizedSD(int bins, int blocks)
        {
            this.bins = bins;
            this.blocks = blocks;
            detectedShots.Add(0); //first frame is start of a shot
        }

        public override void compareFrames(byte[] p, byte[] c, int frameNumber)
        {
            if (frameNumber != 0)
            {
                int sqrtBlocks = (int)Math.Sqrt(blocks);
                int hor = m_videoWidth / sqrtBlocks;
                int ver = m_videoHeight / sqrtBlocks;

                int diff = 0;
                //loop over all regions
                for (int r = 0; r < sqrtBlocks; r++)
                {
                    for (int q = 0; q < sqrtBlocks; q++)
                    {
                        int[] prevhistoR = getLocalHistogram(p, bins, 0, r, q, hor, ver);
                        int[] prevhistoG = getLocalHistogram(p, bins, 1, r, q, hor, ver);
                        int[] prevhistoB = getLocalHistogram(p, bins, 2, r, q, hor, ver);
                        int[] curhistoR = getLocalHistogram(c, bins, 0, r, q, hor, ver);
                        int[] curhistoG = getLocalHistogram(c, bins, 1, r, q, hor, ver);
                        int[] curhistoB = getLocalHistogram(c, bins, 2, r, q, hor, ver);
                        //calculate diff between prev and cur for selected region
                        for (int j = 0; j < bins; j++)
                        {
                            diff += Math.Abs(prevhistoR[j] - curhistoR[j]);
                            diff += Math.Abs(prevhistoG[j] - curhistoG[j]);
                            diff += Math.Abs(prevhistoB[j] - curhistoB[j]);
                        }
                    }
                }
                differences.Add(diff);
            }
        }

        private int[] getLocalHistogram(Byte[] frame, int bins, int c, int curhor, int curvert, int hor, int ver)
        {
            int[] histogram = new int[bins];
            for (int x = curhor * hor; x < ((curhor + 1) * hor); x++)
            {
                for (int y = curvert * ver; y < ((curvert + 1) * ver); y++)
                {
                    histogram[(frame[(y * m_videoWidth + x) * 3 + c]) / (int)Math.Ceiling(256.0 / bins)]++;
                }
            }
            return histogram;
        }

        private void setTreshes()
        {
            //sets the treshes
            //low thresh is equal to the average of the differences
            //high tresh is equal to the mean of the differences + alpha * the standard deviation of the differences
            //the best results are with alpha = 5 (got this from a paper)
            double avg = differences.Average();
            double sumOfSquaresOfDifferences = differences.Select(val => (val - avg) * (val - avg)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / differences.Count);
            double median = getMedian();

            const double alpha = 5.0;
            lowTresh = Math.Max(median, avg);
            highTresh = avg + alpha * sd;
        }
        private double getMedian()
        {
            List<int> sorted = new List<int>(differences);
            sorted.Sort();
            int size = sorted.Count;
            int mid = size / 2;
            return (size % 2 == 0) ? sorted[mid] : (sorted[mid] + sorted[mid - 1]) / 2;
        }

        public void detectGradualTransitions()
        {
            //first set the treshes calculated with the differences between the local histograms
            setTreshes();
            //loop over all the differences
            for (int i = 0; i < differences.Count; i++)
            {
                double sum = 0.0;//sum of the differences in consecutive frames
                //if there is a difference higher than the lower tresh and smaller than the higher tresh
                //enter the if statement. This is the start of a gradual transition.

                //detect cuts
                if (differences[i] >= highTresh && i + 1 - detectedShots[detectedShots.Count - 1] > 5)
                {
                    detectedShots.Add(i + 1);
                }
                else if (differences[i] > lowTresh)
                {
                    //loop over consecutive frames until the difference is lower than the lower tresh.
                    while (i < differences.Count && differences[i] >= lowTresh && differences[i] < highTresh)
                    {
                        sum += differences[i];

                        i++; //dont forget to adjust the for iterator!!!
                    }
                    //if left the while because there was a difference greater than the higher tresh -> cut
                    if (differences[i] >= highTresh && i < differences.Count - 1 && i + 1 - detectedShots[detectedShots.Count - 1] > 5)
                    {
                        detectedShots.Add(i + 1);
                    }
                    //check if the sum surpasses the higher tresh, if it does there was a gradual transition
                    else if (sum >= highTresh && i < differences.Count && i - detectedShots[detectedShots.Count - 1] > 5)
                    {
                        detectedShots.Add(i);
                    }
                }
            }
        }

        public override void export(string inputfile, string outputfolder)
        {
            XDocument doc = new XDocument(
                    new XElement("ShotDetection", new XAttribute("file", inputfile),
                        new XElement("method", new XAttribute("nr", 5),
                        new XElement("param1", bins),
                        new XElement("param2", blocks))
                    )
            );
            addShotInformation(doc);
            //Save the document to a file.
            doc.Save(outputfolder + "\\GeneralizedSD.xml"); 
        }
    }
}
