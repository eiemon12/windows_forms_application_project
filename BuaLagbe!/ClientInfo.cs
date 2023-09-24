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

namespace BuaLagbe_
{
    public partial class ClientInfo : Form
    {
        private string Username;
        
        public ClientInfo(string Username)
        {
            InitializeComponent();
            this.Username = Username;
            userNT.Text = Username;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=CrudeOperatin;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from BuaTable where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", searchB.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hireB_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            logIn login = new logIn();
            login.Show();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            nameT.Clear();
            ageT.Clear();
            location.Clear();
            phoneT.Clear();
            nameT.Focus();
        }

        private void addB_Click(object sender, EventArgs e)
        {
            string rdbtn = "";

            if (radioButton1.Checked)
            {
                rdbtn = "Male";
            }
            else if (radioButton2.Checked)
            {
                rdbtn = "Female";
            }

            try
            {               
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ClientTable values (@Username,@Full_Name,@Age,@Phone,@Location,@Gender)", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.Parameters.AddWithValue("@Full_Name", nameT.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(ageT.Text));
                cmd.Parameters.AddWithValue("@Phone", int.Parse(phoneT.Text));
                cmd.Parameters.AddWithValue("@Location", location.Text);
                cmd.Parameters.AddWithValue("@Gender", rdbtn);               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add SuccessFully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void updateB_Click(object sender, EventArgs e)
        {
            string rdbtn = "";

            if (radioButton1.Checked)
            {
                rdbtn = "Male";
            }
            else if (radioButton2.Checked)
            {
                rdbtn = "Female";
            }

            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("update ClientTable set Username=@Username,Full_Name=@Full_Name,Age=@Age,Phone=@Phone,Location=@Location,Gender=@Gender", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.Parameters.AddWithValue("@Full_Name", nameT.Text);
                cmd.Parameters.AddWithValue("@Age", Int32.Parse(ageT.Text));
                cmd.Parameters.AddWithValue("@Phone", Int32.Parse(phoneT.Text));
                cmd.Parameters.AddWithValue("@Location", location.Text);
                cmd.Parameters.AddWithValue("@Gender", rdbtn);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated SuccessFully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete ClientTable where Username=@UserName", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted SuccessFully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void showB_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select UserName,Full_Name,Age,Phone,Location,Gender From ClientTable", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
