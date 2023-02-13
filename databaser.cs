using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace databser
{
    public partial class Form1 : Form                                      
    {
 
        public Form1()
        {
            InitializeComponent();
           
        }
    
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Felaktig inmatning i stad");
            }else if (textBox1.Text == "")
            {
                MessageBox.Show("Felaktig inmatning i id");
            }else if (textBox2.Text == "")
            {
                MessageBox.Show("Felaktig inmatning i förnamn");
            } else if (textBox3.Text == "")  
            {
                MessageBox.Show("Felaktig inmatning i efternamn");
            } else if (textBox5.Text=="")
            {
                MessageBox.Show("Felaktig inmatning´i service");
            }else
            {
                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Insert into customer values (@customerId, @FirstName, @LastName, @City, @Service)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@customerId", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                cmd.Parameters.AddWithValue("@City", textBox4.Text);
                cmd.Parameters.AddWithValue("@Service", textBox5.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Du är inskriven, tryck på show!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update customer set customerId=@customerId, FirstName=@FirstName, LastName=@LastName, City=@City, Service=@Service", con);
            cmd.Parameters.AddWithValue("@customerId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@City", textBox4.Text);
            cmd.Parameters.AddWithValue("@Service", textBox5.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Du är uptaterad, tryck på show!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Delete customer where customerId=@customerId", con);
            cmd.Parameters.AddWithValue("@customerId", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Du är raderad, tryck på show!");
        }
         
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from customer where customerId=@customerId", con);
            cmd.Parameters.AddWithValue("customerId",int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Service", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdatabase;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }
    }
}


