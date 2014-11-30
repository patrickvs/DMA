using DirectShowLib;
using System;
using System.Collections.Generic;
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
        private List<string>[] annotations = null;

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
            c = new byte[m_videoHeight * m_videoWidth * 3];
            Marshal.Copy(pBuffer, c, 0, m_videoHeight * m_videoWidth * 3);
            compareFrames(p, c, frameNumber);
            frameNumber++;
            p = c;
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
                //if there are annotations for this shot
                if (annotations[i] != null){
                    //the \n and \t are for a better layout, nothing more!
                        doc.Root.Element("shots").Add(new XElement("shot", "\n\t" + shotList[i] + "\n\t",
                            new XElement("Annotations", "\n\t\t", annotations[i].Select(x => new XElement("Annotation", "\n\t\t\t" + x + "\n\t\t")), "\n\t")));
                }
                else
                {
                    doc.Root.Element("shots").Add(new XElement("shot", shotList[i]));
                }
            }
            
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
    }
}
