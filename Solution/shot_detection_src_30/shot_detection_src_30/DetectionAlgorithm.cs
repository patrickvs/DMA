using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shot_detection_src_30
{
    abstract public class DetectionAlgorithm : ISampleGrabberCB
    {
        //abstract class for all the algorithms used to detect shots

        protected int m_videoHeight;
        protected int m_videoWidth;
        protected int m_stride;
        protected List<int> detectedShots = new List<int>();
        private List<int> framesToExport = new List<int>(); //the framenumbers that need to be exported
        private List<string>[] annotations = null;
        private string outputFile;
        private int shotNumber = 0;


        public delegate void ProgressDelegate();
        public event ProgressDelegate Progress;

        private int frameNumber = 0;
        private byte[] p; //container for the previous frame
        private byte[] c; //container for the current frame

        public List<int> getDetectedShots()
        {
            return detectedShots;
        }

        //this method is called for each frame, pBuffer is a pointer to the first byte of the frame
        public unsafe int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            //if the algorithm still needs to run
            if (framesToExport.Count == 0)
            {
                c = new byte[m_videoHeight * m_videoWidth * 3];
                Marshal.Copy(pBuffer, c, 0, m_videoHeight * m_videoWidth * 3);
                compareFrames(p, c, frameNumber);
                p = c;
                if (frameNumber%200 == 0)
                    RaiseProgress();
            }
            //for the frames that  need to be exported
            else if (framesToExport.Contains(frameNumber))
            {
                Bitmap bm = IPToBmp(pBuffer);
                bm.Save(outputFile + "\\shot" + shotNumber + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                bm.Dispose();
                shotNumber++;
            }
            frameNumber++;
            return 0;
        }

        public int getHeight()
        {
            return m_videoHeight;
        }

        public int getWidth()
        {
            return m_videoWidth;
        }

        public int getStride()
        {
            return m_stride;
        }

        public void setHeight(int height)
        {
            this.m_videoHeight = height;
        }

        public void setWidth(int width)
        {
            this.m_videoWidth = width;
        }

        public void setStride(int stride)
        {
            this.m_stride = stride;
        }

        public void addLastFrame()
        {
            detectedShots.Add(frameNumber);
        }

        public List<string>[] getAnnotations()
        {
            return annotations;
        }

        //calculate the framenumbers that need to be exported, these are at the middle of a shot
        public void fillFramesToExport(){
            frameNumber = 0;
            shotNumber = 0;
            if (framesToExport.Count == 0)
            {
                for (int i = 0; i < detectedShots.Count - 1; i++)
                {
                    int frame = (int)(detectedShots[i] + (detectedShots[i + 1] - detectedShots[i]) / 2);
                    framesToExport.Add(frame);
                }
            }
        }

        public void setOutputFile(string outputFile)
        {
            this.outputFile = outputFile;
        }
        //abstract method to compare frames
        abstract public void compareFrames(byte[] p, byte[] c, int frameNumber);

        //abstract method to export the shot information found with a specific detection algorithm
        abstract public void export(string inputfile, string outputfolder);

        protected void addShotInformation(XDocument doc)
        {
            //adds the shots element
            doc.Root.Add(new XElement("shots"));
            List<string> shotList = new List<string>();
            //loops over all the shots and adds the shot with the corresponding annotations information
            for (int i = 0; i < detectedShots.Count() - 1; i++)
            {
                shotList.Add(detectedShots[i] + "-" + (detectedShots[i + 1] - 1));
                doc.Root.Element("shots").Add(new XElement("shot", shotList[i]));
                //if there are annotations for this shot
                if (annotations != null && annotations[i] != null){
                    doc.Root.Add(
                         new XElement("Annotations", new XAttribute("shot", shotList[i]), annotations[i].Select(x => new XElement("Annotation", x))));
                }
            }
            
        }

        // Convert a point to the raw pixel data to a .NET bitmap
        public Bitmap IPToBmp(IntPtr ip)
        {
            // We know the Bits Per Pixel is 24 (3 bytes) because we forced it 
            // to be with sampGrabber.SetMediaType()
            int iBufSize = m_videoWidth * m_videoHeight * 3;

            return new Bitmap(
                m_videoWidth,
                m_videoHeight,
                -m_stride,
                PixelFormat.Format24bppRgb,
                (IntPtr)(ip.ToInt32() + iBufSize - m_stride)
                );
        }


        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            //not used
            throw new NotImplementedException();
        }

        public void annotate(int index, string annotation)
        {
            if (annotations == null)
            {
                annotations = new List<string>[detectedShots.Count];
            }

            if (annotations[index] == null)
            {
                annotations[index] = new List<string>();
            }

            annotations[index].Add(annotation);
        }

        private void RaiseProgress()
        {
            if (Progress != null)
            {
                Progress();
            }
        }
    }
}
