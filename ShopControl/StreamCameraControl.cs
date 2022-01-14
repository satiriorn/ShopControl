using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;

namespace ShopControl
{
    public partial class StreamCameraControl : UserControl
    {
        private MJPEGStream stream;
        public StreamCameraControl()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.1.109:81/stream");
            stream.NewFrame += stream_NewFrame;
        }


        void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            CameraBox1.Image = bmp;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }
    }
}
