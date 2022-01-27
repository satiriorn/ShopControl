using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using MySql.Data.MySqlClient;

namespace ShopControl
{
    public partial class StreamCameraControl : UserControl
    {
        private MJPEGStream stream;
        private Point location;
        private Size normal_size;
        private Size normal_camerabox_size;
        public bool full_camera = false;
        private bool load_camera = false;
        public StreamCameraControl(string link = "")
        {
            InitializeComponent();
            if (link != "") { 
                Connect(link);
                load_camera = true;
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e) => textBox1.PasswordChar = '*';
        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            CameraBox1.Image = bmp;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect(textBox1.Text);
        }
        private void Connect(string link)
        {
            try {
                textBox1.Text = link;
                stream = new MJPEGStream(link);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Something went wrong:{0}", ex.ToString()));
            }

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
            BtnClose.Visible = true;
            BtnFullCamera.Visible = true;
            if (load_camera == false)
                BtnAddIntoDb.Visible = true;
            
        }

        private void StreamCameraControl_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.Visible = false;
            BtnFullCamera.Visible = false;
        }

        private void btnFullCamera_Click(object sender, EventArgs e)
        {
            if (full_camera)
            {
                this.Location = location;
                this.Size = normal_size;
                CameraBox1.Size = normal_camerabox_size;
                full_camera = false;
                BtnFullCamera.Text = "🞑";
            }
            else
            {
                normal_size = this.Size;
                normal_camerabox_size = CameraBox1.Size;
                location = this.Location;
                this.Location = new Point(4, 30);
                this.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                CameraBox1.Size = new Size(Parent.Size.Width - 5, Parent.Size.Height - 75);
                full_camera = true;
                BtnFullCamera.Text = "⧉";
            }
        }

        private void BtnAddIntoDb_Click(object sender, EventArgs e)
        {
            if(stream != null) { 
                if (stream.IsRunning) {
                    try { 
                        string ConnectionString = Environment.GetEnvironmentVariable("ConnectToDatabase");
                        MySqlConnection cnn = new MySqlConnection(ConnectionString);
                        MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO StreamCamera(Link)values('{0}');", textBox1.Text), cnn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Something went wrong:{0}", ex.ToString()));
                    }
                }
            }
        }

        private void BtnRemoveFromDB_Click(object sender, EventArgs e)
        {

        }
    }
}
