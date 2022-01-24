using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ShopControl
{
    public partial class CMenu : KryptonForm
    {
        private string ConnectionString = Environment.GetEnvironmentVariable("ConnectToDatabase");
        private int camera_stream_width = 330;
        private int camera_stream_height = 260;
        private MySqlConnection cnn;
        private BindingSource bindingSource;
        private DataSet ds;
        private DataTable dataTable;
        private Point location_stream_camera;
        private int counter_camera;
        private StreamCameraControl[] arrCamera;
        public CMenu()
        {
            InitializeComponent();
            StreamCameraControl camera = new StreamCameraControl();
            if (camera == null)
                DataGridView1.ForeColor = Color.Black;
            camera.Size = new System.Drawing.Size(330, 260);
            camera.Location = new System.Drawing.Point(4, 29);
            camera.Visible = true;
            camera.Show();
            textBox1.Text = "";
            counter_camera = 0;
            DataGridView1.ForeColor = Color.White;
            bindingSource = new BindingSource();
            cnn = new MySqlConnection(ConnectionString);
            ds = new DataSet();
            dataTable = new DataTable();
            arrCamera = new StreamCameraControl[20];
            ds.Tables.Add(dataTable);
            cnn.Open();
            string sql = "SELECT * FROM PriceTag;";
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            UpdateGrid(cmd);
        }
        private void UpdateGrid(MySqlCommand cmd)
        {
            ds.Clear();
            dataTable.Clear();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);
                bindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = bindingSource;
                DataGridView1.DataSource = bindingSource.DataSource;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = (textBox1.Text.Length > 0) ? new MySqlCommand(String.Format("SELECT * FROM PriceTag Where id_Tag = {0};", textBox1.Text), cnn) :
                new MySqlCommand("SELECT * FROM PriceTag;", cnn);

            UpdateGrid(cmd);
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var x = dataTable.Rows[e.RowIndex];
                var y = e.ColumnIndex;
                var name = dataTable.Columns[y];

                MySqlCommand cmd = (y == 3 || y == 5 || y == 6) ?
                new MySqlCommand(String.Format("UPDATE PriceTag SET {0}={1} WHERE id_Tag ={2};", name, x[y].ToString().Replace(",", "."), x[0]), cnn) :
                new MySqlCommand(String.Format("UPDATE PriceTag SET {0}='{1}' WHERE id_Tag ={2};", name, x[y].ToString(), x[0]), cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(x[y].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnAddNewStreamCamera_Click(object sender, EventArgs e)
        {
            StreamCameraControl camera = new StreamCameraControl();
            camera.Size = new Size(camera_stream_width, camera_stream_height);
            if (counter_camera == 0)
            {
                location_stream_camera = new Point(4, 30);
            }
            else
            {
                if ((location_stream_camera.X + (camera_stream_width * 2)) < Screen.PrimaryScreen.Bounds.Width)
                    location_stream_camera.X += camera_stream_width;
                else
                {
                    location_stream_camera.Y += camera_stream_height;
                    location_stream_camera.X = 4;
                    // if ((location_stream_camera.Y*2) > Screen.PrimaryScreen.Bounds.Height) vScrollBar1.Visible = true;
                }
            }
            camera.Location = location_stream_camera;
            camera.Name = String.Format("Camera{0}", counter_camera);
            this.kryptonPage2.Controls.Add(camera);
            arrCamera[counter_camera] = camera;
            counter_camera++;
        }
    }
}
