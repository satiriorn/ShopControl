﻿using System;
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
        private Point location;
        public bool full_camera = false;
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

        private void btnFullCamera_Click(object sender, EventArgs e)
        {
            if (full_camera)
            {
                this.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                CameraBox1.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                full_camera = false;
                this.Location = location;
            }
            else
            {
                this.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                CameraBox1.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                location = this.Location;
                this.Location = new Point(0, 4);
                full_camera = true;
            }
        }
    }
}
