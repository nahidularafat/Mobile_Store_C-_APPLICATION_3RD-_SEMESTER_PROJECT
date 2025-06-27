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
    public partial class mobile : Form
    {
        public mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arafat\Desktop\Shop_Management_System-master\Mobile MS.mdf;Integrated Security=True");


        void populate()
        {
            Con.Open();
            string query = " select * from MTBL";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVdoctors.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Missing Information ! Fill All details Carefully");
            }
            else
            {
                Con.Open();
                string query = "insert into MTBL (MName, Series, Storage, Price) values ('"
                + textBox4.Text + "', '"
                + textBox5.Text + "', '"
                + textBox2.Text + "', '"
                + textBox3.Text + "')";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Added Successfully ");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Missing Information ! Fill All details Carefully");
            }
            else
            {
                Con.Open();
                string query = "update MTBL set MName = '" + textBox4.Text + "', Series = '" + textBox5.Text + "', Storage ='" + textBox2.Text + "',Price='" + textBox3.Text + "' where MId = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Update Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The  ID ");
            }
            else
            {
                Con.Open();
                string query = "delete from MTBL where MId=" + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Deleted Successfully ");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DGVdoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = DGVdoctors.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = DGVdoctors.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = DGVdoctors.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = DGVdoctors.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = DGVdoctors.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }
    }
}
