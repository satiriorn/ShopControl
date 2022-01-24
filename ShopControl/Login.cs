using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ShopControl
{
    public partial class CLoginForm : KryptonForm
    {
        public CLoginForm()
        {
            InitializeComponent();
            textBox1.Text = "Satiriorn";
            textBox2.Text = "123456789";
        }

        private void textBox2_TextChanged(object sender, EventArgs e) => textBox2.PasswordChar = '*';


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/satiriorn");
            Process.Start(sInfo);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string ConnectionString = Environment.GetEnvironmentVariable("ConnectToDatabase");
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
                            Form form = new CMenu();
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
    }
}
