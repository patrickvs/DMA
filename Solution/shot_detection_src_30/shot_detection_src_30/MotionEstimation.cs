using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    public class MotionEstimation : DetectionAlgorithm
    {
        private double tresh;
        private int blockSize;
        private int windowSize;

        public MotionEstimation(double tresh, int blockSize, int windowSize)
        {
            this.tresh = tresh;
            this.blockSize = blockSize;
            this.windowSize = windowSize;
            detectedShots.Add(0); //first frame is the start of a shot
        }

        public override void compareFrames(byte[] p, byte[] c, int frameNumber)
        {
            if (frameNumber != 0)
            {
                int imagediff = 0;    
                //loop over all the blocks 
                for (int x = 0; x < (m_videoWidth-blockSize); x += blockSize) 
                {
                    for (int y = 0; y < (m_videoHeight-blockSize); y += blockSize)
                    {   
                        //loop over searchwindow
                        int searchwidth = 1;
                        int bestdiff = Int32.MaxValue;
                        while (searchwidth * blockSize <= windowSize) 
                        {
                            for (int i = -searchwidth; i <= searchwidth; i++) 
                            {
                                for (int j = -searchwidth; j <= searchwidth; j++) 
                                {
                                    if (x + (i * blockSize) >= 0 && x + ((i+1) * blockSize) < m_videoWidth && y + (j * blockSize) >= 0 && y + ((j+1) * blockSize) < m_videoHeight && x+blockSize<m_videoWidth && y+blockSize <m_videoHeight)
                                    {
                                       //calculate diff between two blocks
                                       int curdiff = calculateDiff(c, x, y, p, x + (i * blockSize), y + (j * blockSize), blockSize);
                                       if(curdiff < bestdiff) bestdiff = curdiff;
                                    }
                                }
                            }                                
                            searchwidth++;
                        }
                        imagediff +=bestdiff;                        
                    }
                }
                if (imagediff > tresh) detectedShots.Add(frameNumber);               
            }
        }

        public int calculateDiff(byte[] current, int x, int y, byte[] previous, int k, int l, int blockSize) {
            //To calculate the diff between two blocks, we take the sum of the pixels of each block, and define the diff as the difference between the two sums, instead of compare pixels on its own.
            int currentframevalue = 0;
            int previousframevalue = 0;
            for(int i=0;i<blockSize;i++)
            {
                for(int j=0;j<blockSize;j++)
                {                    
                    for (int c=0;c<3;c++)
                    {
                        currentframevalue += current[((y + j) * m_videoWidth + (x + i)) * 3 + c];
                        previousframevalue += previous[((l + j) * m_videoWidth + (k + i)) * 3 + c];
                    }
                }
            }
            return Math.Abs(currentframevalue - previousframevalue);
        }

        public override void export(string inputfile, string outputfolder)
        {
            XDocument doc = new XDocument(
                    new XElement("ShotDetection", new XAttribute("file", inputfile),
                        new XElement("method", new XAttribute("nr", 2),
                        new XElement("param1", tresh),
                        new XElement("param2", blockSize),
                        new XElement("param3", windowSize))
                    )
            );
            addShotInformation(doc);
            //Save the document to a file.
            doc.Save(outputfolder + "\\MotionEstimationSD.xml"); 
        }
    }
}
