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
    }
}
