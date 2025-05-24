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

/*
namespace WindowsFormsApp2
{
    public partial class todo : Form
    {
        public todo()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isediting = false;
        private void todo_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Date and Time");

            dataGridView1.DataSource = todoList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            isediting = true;
            textBox2.Text = todoList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            textBox1.Text = todoList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) 
            {
                    Console.WriteLine("Error: " + ex);   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isediting)
            {
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = textBox2.Text;
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Description"] = textBox1.Text;
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Date and Time"] = dateTimePicker1.Value.ToString("g");
            }
            else
            {
                todoList.Rows.Add(textBox2.Text, textBox1.Text,dateTimePicker1.Value.ToString("g"));
            }

            textBox1.Text = "";
            textBox2.Text = "";
            isediting = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}

*/

namespace WindowsFormsApp2
{
    public partial class todo : Form
    {
        DataTable todoList = new DataTable();
        bool isediting = false;
        int editingId = -1; // Track which task is being edited

        // SQL Server LocalDB connection
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\OneDrive\Desktop\Documents\UsersDatabase.mdf;Integrated Security=True");

        public todo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void todo_Load(object sender, EventArgs e)
        {
            // No table creation here because you already created the table separately

            // Set up DataTable columns
            todoList.Columns.Add("Id");
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Date and Time");

            dataGridView1.DataSource = todoList;
            LoadTasks();
        }

        private void LoadTasks()
        {
            todoList.Rows.Clear();
            try
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Tasks";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    todoList.Rows.Add(
                        reader["Id"],
                        reader["Title"],
                        reader["Description"],
                        reader["DateTime"]
                    );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();
                if (isediting && editingId != -1)
                {
                    // UPDATE existing task
                    string updateQuery = "UPDATE Tasks SET Title=@Title, Description=@Description, DateTime=@DateTime WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Description", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DateTime", dateTimePicker1.Value.ToString("g"));
                    cmd.Parameters.AddWithValue("@Id", editingId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // INSERT new task
                    string insertQuery = "INSERT INTO Tasks (Title, Description, DateTime) VALUES (@Title, @Description, @DateTime)";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Description", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DateTime", dateTimePicker1.Value.ToString("g"));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving task: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // Reset fields
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            isediting = false;
            editingId = -1;

            LoadTasks();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    int idToDelete = Convert.ToInt32(todoList.Rows[rowIndex]["Id"]);

                    connection.Open();
                    string deleteQuery = "DELETE FROM Tasks WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@Id", idToDelete);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message);
            }
            finally
            {
                connection.Close();
                LoadTasks();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                editingId = Convert.ToInt32(todoList.Rows[rowIndex]["Id"]);
                textBox2.Text = todoList.Rows[rowIndex]["Title"].ToString();
                textBox1.Text = todoList.Rows[rowIndex]["Description"].ToString();

                if (DateTime.TryParse(todoList.Rows[rowIndex]["Date and Time"].ToString(), out DateTime dt))
                {
                    dateTimePicker1.Value = dt;
                }

                isediting = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}