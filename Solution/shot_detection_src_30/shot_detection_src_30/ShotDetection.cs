using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shot_detection_src_30
{
    class ShotDetection
    {
        public List<byte[]> frameList;
        public int width;
        public int height;
        public ShotDetection(String file){
            Frames framegetter = new Frames(file);
            frameList = framegetter.getframes();
            width = framegetter.getWidth();
            height = framegetter.getHeight();
        }
        public List<String> PixelDifferenceSD(double threshold1, double threshold2)
        {
            List<int> detectedShots = new List<int>();
            //The first frame is always the start of a new shot
            detectedShots.Add(0);
            //Loop over all the frames
            for (int i = 1; i < frameList.Count(); i++)
            {   
                int sumofdiffpixels = 0;
                //Loop over all pixels
                for (int x = 0; x < width; x++){
                     for (int y = 0; y < height; y++){
                        //Loop over the three colors
                         int sumofcolors = 0;
                         for (int c = 0; c < 3; c++) {
                             sumofcolors += Math.Abs(frameList[i - 1][(y * width + x) * 3 + c] - frameList[i][(y * width + x) * 3 + c]);
                         }
                         //compare the value found with threshold1, for that one pixel
                         if (sumofcolors > threshold1) sumofdiffpixels++;
                    }
                }
                //compare the number of pixels the two frames differ with the threshold.
                if (sumofdiffpixels > threshold2) detectedShots.Add(i);
            }
            List<String> shotList = new List<String>();
            for (int i = 0; i < detectedShots.Count()-1; i++) {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
            }
            shotList.Add(detectedShots[detectedShots.Count()-1] + "-" + (frameList.Count()-1));
            return shotList;
        }

        public List<String> GlobalHistogramSD(double threshold, int bins)
        {
            List<int> detectedShots = new List<int>();
            //The first frame is always the start of a new shot
            detectedShots.Add(0);
            int[] prevhistoR = getHistogram(frameList[0], bins, 0);
            int[] prevhistoG = getHistogram(frameList[0], bins, 1);
            int[] prevhistoB = getHistogram(frameList[0], bins, 2);
            //loop over all frames
            for (int i = 1; i < frameList.Count(); i++)
            {
                int[] curhistoR = getHistogram(frameList[i], bins, 0);
                int[] curhistoG = getHistogram(frameList[i], bins, 1);
                int[] curhistoB = getHistogram(frameList[i], bins, 2); 
                //calculate diff between prev and cur
                int diff = 0;
                for (int j = 0; j < bins; j++)
                { 
                    diff += Math.Abs(prevhistoR[j] - curhistoR[j]);
                    diff += Math.Abs(prevhistoG[j] - curhistoG[j]);
                    diff += Math.Abs(prevhistoB[j] - curhistoB[j]);
                }
                //compare diff to treshold
                if (diff > threshold)
                    //add to list of detected shots
                    detectedShots.Add(i);
                // put cur in prev
                prevhistoB = curhistoB;
                prevhistoG = curhistoG;
                prevhistoR = curhistoR;
            }
            List<String> shotList = new List<String>();
            for (int i = 0; i < detectedShots.Count() - 1; i++)
            {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
            }
            shotList.Add(detectedShots[detectedShots.Count() - 1] + "-" + (frameList.Count() - 1));
            return shotList;
        }

        public int[] getHistogram(Byte[] frame, int bins, int c) {
            int[] histogram = new int[bins];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    histogram[(frame[(y * width + x) * 3 + c]) / (int)Math.Ceiling(256.0 / bins)]++;
                }
            }
            return histogram;
        }
    }
}
