using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace ShopControl
{
    public partial class CLoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public CLoginForm()
        {
            InitializeComponent();
            textBox1.Text = "Satiriorn";
            textBox2.Text = "123456789";
        }

        private void textBox2_TextChanged(object sender, EventArgs e) => textBox2.PasswordChar = '*';


        private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=eu-cdbr-west-01.cleardb.net;Initial Catalog=heroku_944d93c1a0e7204;User ID=bbdbecc8a2b4a4;Password=deff7c8b";
            MySqlConnection cnn;

            cnn = new MySqlConnection(ConnectionString);
            try
            {
                cnn.Open();
                
                string sql = String.Format("SELECT * FROM Admin Where Login = '{0}' and Password = '{1}';", textBox1.Text, textBox2.Text);
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Form form = new CMenuForm();
                            this.Hide();
                            form.Closed += (s, args) => this.Close();
                            form.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid login or password");
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/satiriorn");
            Process.Start(sInfo);
        }

    }
}
