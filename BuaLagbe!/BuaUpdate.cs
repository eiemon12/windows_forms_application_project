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
    public partial class BuaUpdate : Form
    {
        public BuaUpdate()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminPanel adminPanel = new adminPanel();
            adminPanel.Show();
        }

        private void clearB_Click(object sender, EventArgs e)
        {
            nameT.Clear();
            location.Clear();
            ageT.Clear();
            salaryT.Clear();
            workexpT.Clear();
            phoneT.Clear();
            nameT.Focus();

        }

        private void addbtn_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateB_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
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

        private void searchB_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=CrudeOperatin;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from BuaTable where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", searchT.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
                SqlCommand cmd = new SqlCommand(@"select UserName,Full_Name,Age,Phone,Location,Salary,Work_Experience,Gender From BuaTable", con);
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
