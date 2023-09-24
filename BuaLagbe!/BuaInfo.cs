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
    public partial class BuaInfo : Form
    {
        private string Username;
        public BuaInfo(string Username)
        {
            InitializeComponent();
            this.Username = Username;
            userNT.Text = Username;
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
            phoneT.Clear();
            location.Clear();
            salaryT.Clear();
            workexpT.Clear();
            nameT.Focus();
        }

        private void add_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("insert into BuaTable values (@Username,@Full_Name,@age,@Phone,@Location,@Salary,@Work_Experience,@Gender)", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.Parameters.AddWithValue("@Full_Name", nameT.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(ageT.Text));
                cmd.Parameters.AddWithValue("@Phone", int.Parse(phoneT.Text));
                cmd.Parameters.AddWithValue("@Location", location.Text);
                cmd.Parameters.AddWithValue("@Salary", float.Parse(salaryT.Text));
                cmd.Parameters.AddWithValue("@Work_Experience", int.Parse(workexpT.Text));
                cmd.Parameters.AddWithValue("@Gender", rdbtn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add SuccessFully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete BuaTable where Username=@UserName", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted SuccessFully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("update BuaTable set Username=@Username,Full_Name=@Full_Name,Age=@Age,Phone=@Phone,Loacation=@Location,Gender=@Gender)", con);
                cmd.Parameters.AddWithValue("@Username", userNT.Text);
                cmd.Parameters.AddWithValue("@Full_Name", nameT.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(ageT.Text));
                cmd.Parameters.AddWithValue("@Phone", int.Parse(phoneT.Text));
                cmd.Parameters.AddWithValue("@Location", location.Text);
                cmd.Parameters.AddWithValue("@Gender", rdbtn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated SuccessFully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
