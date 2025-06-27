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
    public partial class cus : Form
    {
        public cus()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arafat\Desktop\Shop_Management_System-master\Mobile MS.mdf;Integrated Security=True");


        void populateId()
        {
            string sql = "select * from MTBL";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader rdr;
            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("MId", typeof(int));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                CbPatientId.ValueMember = "MId";
                CbPatientId.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }
        string MobName;
        string mobmod;
        string bill;
        void fecthpatientname()
        {
            Con.Open();
            string mysql = "select * from MTBL where MId =" + CbPatientId.SelectedValue.ToString() + " ";
            SqlCommand cmd = new SqlCommand(@mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MobName = dr["MName"].ToString();
                textBox5.Text = MobName;

                mobmod = dr["Series"].ToString();
                textBox6.Text = mobmod;

                bill = dr["Price"].ToString();
                textBox4.Text = bill;
            }
            Con.Close();

        }

        void populate()
        {
            Con.Open();
            string query = " select * from CTBL ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGDaignosis.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Information ! Fill All details Carefully");
            }

      
            else
            {
                Con.Open();

                string query = "insert into CTBL (CName, Gender, Address, PurchasedMobile, Bill, Date, Model, MId, Storage) values('"
                                + textBox1.Text + "' ,'"
                                + CBgender.SelectedItem.ToString() + "', '"
                                + textBox3.Text + "' , '"
                                + textBox5.Text + "', '"
                                + textBox4.Text + "', '"
                                + this.datetime.Text + "', '"
                                + textBox6.Text + "', "
                                + CbPatientId.SelectedValue.ToString() + " , '"
                                + comboBox1.SelectedItem.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" ADDED Successfuly !");

                Con.Close();
                 populate();
                //  Reset();
            }
        }

        private void cus_Load(object sender, EventArgs e)
        {
            populateId();
            populate();


        }

        private void CbPatientId_SelectionChangeCommitted(object sender, EventArgs e)
        {
           fecthpatientname();
        }

        private void DGDaignosis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox2.Text = DGDaignosis.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = DGDaignosis.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = DGDaignosis.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = DGDaignosis.SelectedRows[0].Cells[4].Value.ToString();
         //   textBox4.Text = DGDaignosis.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = DGDaignosis.SelectedRows[0].Cells[7].Value.ToString();
            textBox4.Text = DGDaignosis.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Information ! Fill All details Carefully");
            }
            else
            {
                Con.Open();
                string query = "update CTBL set CName = '" + textBox1.Text + "', Address = '" + textBox3.Text + "', PurchasedMobile = '" + textBox5.Text + "' where CId = " + textBox2.Text;



                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Update successfully");
                Con.Close();
                populate();
                //Reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Enter the  id");
            else
            {
                Con.Open();
                string query = "delete from CTBL where CId = " + textBox2.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" deleted successfully");
                Con.Close();
                populate();
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
