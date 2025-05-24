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

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        SqlConnection connection;

        public Form3()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\OneDrive\Desktop\Documents\UsersDatabase.mdf;Integrated Security=True");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtpassword.Text == "" || txtComPassword.Text == "")
            {
                MessageBox.Show("Enter all fields!", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtpassword.Text != txtComPassword.Text)
            {
                MessageBox.Show("Password does not match!", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtpassword.Clear();
                txtComPassword.Clear();
                txtUsername.Focus();
                return;
            }

            if (!IsValidPassword(txtpassword.Text))
            {
                MessageBox.Show("Password must be at least 8 characters and contain uppercase, lowercase, and numbers.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                int usernameExists = (int)checkCmd.ExecuteScalar();

                if (usernameExists > 0)
                {
                    MessageBox.Show("Username already taken! Try another one.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                insertCmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("You have been registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Clear();
                txtpassword.Clear();
                txtComPassword.Clear();
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = false, hasLower = false, hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }
            return hasUpper && hasLower && hasDigit;
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void Form3_Load(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtComPassword.Clear();
            txtUsername.Focus();
        }
        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtUsername_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
    }
}