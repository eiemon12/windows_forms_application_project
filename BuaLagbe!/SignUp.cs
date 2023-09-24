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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void label5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text != "")
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        SqlConnection con = new SqlConnection("Data Source=EIEMON;Initial Catalog=BuaLagbe!;Integrated Security=True");
                        SqlCommand cmd = new SqlCommand("INSERT INTO Login (Username,Role,Password) Values (@Username,@Role,@Password)", con);
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Role", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Signup Successful!");
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't match");
                    }
                }
                else
                {
                    MessageBox.Show("Fill all the blanks");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    textBox2.UseSystemPasswordChar = true;
                    textBox3.UseSystemPasswordChar = true;
                }
                else
                {
                    textBox2.UseSystemPasswordChar = false;
                    textBox3.UseSystemPasswordChar = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            logIn login = new logIn();
            login.Show();
        }
    }
}
