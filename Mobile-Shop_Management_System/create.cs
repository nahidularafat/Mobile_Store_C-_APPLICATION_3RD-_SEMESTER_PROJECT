using Hospital_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class create : Form
    {
        public create()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arafat\Desktop\Shop_Management_System-master\Mobile MS.mdf;Integrated Security=True");

        private void create_Load(object sender, EventArgs e)
        {

        }

        private void button1login_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information ! Fill All details Carefully");
            }
            else
            {
                Con.Open();
                string query = "insert into passTbl values ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully ");
                Con.Close();
                
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_LOGIN Obj = new USER_LOGIN();
            Obj.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}