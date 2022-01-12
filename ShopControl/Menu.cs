using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AForge;

namespace ShopControl
{
    public partial class CMenuForm : Form
    {
        private MJPEGStream stream;
        private string ConnectionString = "Data Source=eu-cdbr-west-01.cleardb.net;Initial Catalog=heroku_944d93c1a0e7204;User ID=bbdbecc8a2b4a4;Password=deff7c8b;CharSet=utf8";
        private MySqlConnection cnn;
        private BindingSource bindingSource;
        private DataSet ds;
        private DataTable dataTable;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2; 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public CMenuForm()
        {
            InitializeComponent();
            textBox1.Text = "";
            dataGridView1.ForeColor = Color.White;
            bindingSource = new BindingSource();
            cnn = new MySqlConnection(ConnectionString);
            ds = new DataSet();
            dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            cnn.Open();
            string sql = "SELECT * FROM PriceTag;";
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            UpdateGrid(cmd);
        }

        private void UpdateGrid(MySqlCommand cmd) {
            ds.Clear();
            dataTable.Clear();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);
                bindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = bindingSource;
                dataGridView1.DataSource = bindingSource.DataSource;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("");
            Process.Start(sInfo);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = (textBox1.Text.Length > 0)?  new MySqlCommand(String.Format("SELECT * FROM PriceTag Where id_Tag = {0};", textBox1.Text), cnn):
                new MySqlCommand("SELECT * FROM PriceTag;", cnn);
   
            UpdateGrid(cmd);
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Add new row");
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
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

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
