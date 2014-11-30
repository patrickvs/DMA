using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    public class PixelDifference : DetectionAlgorithm
    {
        private int tresh1;
        private int tresh2;

        public PixelDifference(int tresh1, int tresh2)
        {
            this.tresh1 = tresh1;
            this.tresh2 = tresh2;
            detectedShots.Add(0); //first frame must be in the list of shots
        }

        public override void compareFrames(byte[] p, byte[] c, int frameNumber)
        {
            if (frameNumber != 0)
            {
                int sumofdiffpixels = 0;
                //Loop over all pixels
                for (int x = 0; x < m_videoWidth; x++){
                     for (int y = 0; y < m_videoHeight; y++){
                        //Loop over the three colors
                         int sumofcolors = 0;
                         for (int i = 0; i < 3; i++) {
                             sumofcolors += Math.Abs(p[(y * m_videoWidth + x) * 3 + i] - c[(y * m_videoWidth + x) * 3 + i]);
                         }
                         //compare the value found with threshold1, for that one pixel
                         if (sumofcolors > tresh1) sumofdiffpixels++;
                    }
                }
                double test = 100.0 * sumofdiffpixels / (m_videoHeight * m_videoWidth);
                //compare the number of pixels the two frames differ with the threshold.
                if (100.0 * sumofdiffpixels / (m_videoHeight * m_videoWidth) > tresh2)
                {
                    detectedShots.Add(frameNumber);
                }
            }
        }

        public override void export(string inputfile, string outputfolder)
        {
            XDocument doc = new XDocument(
                    new XElement("ShotDetection", new XAttribute("file", inputfile),
                        new XElement("method", new XAttribute("nr", 1),
                        new XElement("param1", tresh1),
                        new XElement("param2", tresh2))
                    )
            );
            addShotInformation(doc);
            //Save the document to a file.
            doc.Save(outputfolder + "\\PixelDifferenceSD.xml"); 
        }
    }
}
