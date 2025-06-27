using Shop_Management_System;
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

namespace Hospital_Management_System
{
    public partial class USER_LOGIN : Form
    {
        public USER_LOGIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arafat\Desktop\Shop_Management_System-master\Mobile MS.mdf;Integrated Security=True");


        private void button1login_Click(object sender, EventArgs e)
        {

           
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter the user name and password to proceed");
            }
            else
            {

                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Enter the user name and password to proceed");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from passTbl where Uname= '" + txtUsername.Text + "' and Upass = '" + txtPassword.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        home Page = new home();
                        Page.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("wrong user name and password");
                    }
                    Con.Close();

                }

            }


        }

        private void USER_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void btncClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

            create Obj = new create();
            Obj.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
