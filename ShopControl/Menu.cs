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
        private BindingSource bindingSource;
        private DataSet ds;
        private DataTable dataTable;
        private Point location_stream_camera;
        private int counter_camera;
        private StreamCameraControl[] arrCamera;
        public CMenu()
        {
            InitializeComponent();
            counter_camera = 0;
            DataGridView1.ForeColor = Color.White;
            bindingSource = new BindingSource();
            ds = new DataSet();
            dataTable = new DataTable();
            arrCamera = new StreamCameraControl[50];
            ds.Tables.Add(dataTable);
            UpdateGrid();
        }
        private void UpdateGrid(MySqlCommand cmd = null)
        {
            ds.Clear();
            dataTable.Clear();
            if(cmd == null)
            {
                cmd = new MySqlCommand("SELECT * FROM PriceTag;", ConnectSql());
            }
            
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
            switch (this.ComboBoxForSearch.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("You didn't choose kind for search");
                    break;
                case 0:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where id_Tag = {0};", textBox1.Text), ConnectSql()));
                    break;
                case 1:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where title LIKE '%{0}%';", textBox1.Text), ConnectSql()));
                    break;
                case 2:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where Price = {0};", textBox1.Text), ConnectSql()));
                    break;
                case 3:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where Price >= {0};", textBox1.Text), ConnectSql()));
                    break;
                case 4:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where Price <= {0};", textBox1.Text), ConnectSql()));
                    break;
                case 5:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where Description LIKE '%{0}%';", textBox1.Text), ConnectSql()));
                    break;
                case 6:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where SalePrice = {0};", textBox1.Text), ConnectSql()));
                    break;
                case 7:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where SalePrice >= {0};", textBox1.Text), ConnectSql()));
                    break;
                case 8:
                    UpdateGrid(new MySqlCommand(String.Format("SELECT * FROM PriceTag Where SalePrice <= {0};", textBox1.Text), ConnectSql()));
                    break;
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var x = dataTable.Rows[e.RowIndex];
                var y = e.ColumnIndex;
                var name = dataTable.Columns[y];

                MySqlCommand cmd = (y == 3 || y == 5 || y == 6) ?
                new MySqlCommand(String.Format("UPDATE PriceTag SET {0}={1} WHERE id_Tag ={2};", name, x[y].ToString().Replace(",", "."), x[0]), ConnectSql()) :
                new MySqlCommand(String.Format("UPDATE PriceTag SET {0}='{1}' WHERE id_Tag ={2};", name, x[y].ToString(), x[0]), ConnectSql());
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
                }
            }
            camera.Location = location_stream_camera;
            camera.Name = String.Format("Camera{0}", counter_camera);
            this.kryptonPage2.Controls.Add(camera);
            arrCamera[counter_camera] = camera;
            counter_camera++;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {

        }
        private MySqlConnection ConnectSql()
        {
            MySqlConnection cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
            return cnn;
        }
        private void textbox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }
    }
}
