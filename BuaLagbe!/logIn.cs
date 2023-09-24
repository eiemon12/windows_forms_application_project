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

namespace BuaLagbe_
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select * from Login where username = '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string cmbItemvalue = comboBox1.SelectedItem.ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Role"].ToString() == cmbItemvalue)
                        {
                            if (comboBox1.SelectedIndex == 0)
                            {
                                this.Hide();
                                adminPanel adminPanel = new adminPanel();
                                adminPanel.Show();
                            }
                            else if (comboBox1.SelectedIndex == 1)
                            {
                                this.Hide();
                                ClientInfo clientInfo = new ClientInfo(txtUserName.Text);
                                clientInfo.Show();
                            }
                            else
                            {
                                this.Hide();
                                BuaInfo buaInfo = new BuaInfo(txtUserName.Text);
                                buaInfo.Show();
                            }
                        }
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            this.Hide();
            signup.Show();
        }

        private void logIn_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
