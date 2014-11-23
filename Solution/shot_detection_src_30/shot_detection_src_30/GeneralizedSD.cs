using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int regionsize;
        private List<int> differences = new List<int>();
        private double highTresh;
        private double lowTresh;

        public GeneralizedSD(int bins, int regionsize)
        {
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
                differences.Add(diff);
            }
        }

        private int[] getLocalHistogram(Byte[] frame, int bins, int c, int curhor, int curvert, int regionsize)
        {
            //sets up the local histogram of the current frame
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

        private void setTreshes()
        {
            //sets the treshes
            //low thresh is equal to the average of the differences
            //high tresh is equal to the mean of the differences + alpha * the standard deviation of the differences
            //the best results are with alpha = 5 (got this from a paper)
            double avg = differences.Average();
            double sumOfSquaresOfDifferences = differences.Select(val => (val - avg) * (val - avg)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / differences.Count);

            const double alpha = 5.0;
            lowTresh = avg;
            highTresh = avg + alpha * sd;
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
                if (differences[i] > lowTresh && differences[i] < highTresh)
                {
                    //loop over consecutive frames until the difference is lower than the lower tresh.
                    while (i < differences.Count && differences[i] > lowTresh)
                    {
                        sum += differences[i];
                        i++; //dont forget to adjust the for iterator!!!
                    }
                    //check if the sum surpasses the higher tresh, if it does there was a gradual transition
                    if (sum >= highTresh && i < differences.Count)
                    {
                        detectedShots.Add(i);
                    }
                }
            }
        }
    }
}
