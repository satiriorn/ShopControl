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
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => textBox1.PasswordChar = '*';
        void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            CameraBox1.Image = bmp;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            stream = new MJPEGStream(textBox1.Text);
            stream.NewFrame += stream_NewFrame;
            stream.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CameraBox1_MouseHover(object sender, EventArgs e)
        {
            ButtonClose.Visible = true;
            btnFullCamera.Visible = true;
        }

        private void StreamCameraControl_MouseLeave(object sender, EventArgs e)
        {
            ButtonClose.Visible = false;
            btnFullCamera.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = ParentForm.Size;
            CameraBox1.Size = ParentForm.Size; 
            CameraBox1.Location = new Point(0, 0);
        }
    }
}
