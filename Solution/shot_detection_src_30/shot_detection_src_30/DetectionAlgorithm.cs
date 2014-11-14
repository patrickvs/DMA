using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shot_detection_src_30
{
    abstract public class DetectionAlgorithm : ISampleGrabberCB
    {
        //abstract class for all the algorithms used to detect shots

        protected int m_videoHeight;
        protected int m_videoWidth;
        protected int m_stride;
        protected List<int> detectedShots = new List<int>();

        private int frameNumber = 0;
        private byte[] p; //container for the previous frame
        private byte[] c; //container for the current frame

        public List<int> getDetectedShots()
        {
            return detectedShots;
        }

        public int getFrameNumber()
        {
            return frameNumber;
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

        //abstract method to compare frames
        abstract public void compareFrames(byte[] p, byte[] c, int frameNumber);


        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            //not used
            throw new NotImplementedException();
        }
    }
}
