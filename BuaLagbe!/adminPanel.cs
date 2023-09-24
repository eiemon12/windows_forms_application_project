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
    public partial class adminPanel : Form
    {
        public adminPanel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientUpdate clientUpdate = new ClientUpdate();
            clientUpdate.Show();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuaUpdate buaUpdate = new BuaUpdate();
            buaUpdate.Show();
        }

        private void clientInfo_Click(object sender, EventArgs e)
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

        private void buaInfo_Click(object sender, EventArgs e)
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
