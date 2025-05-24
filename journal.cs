using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class journal : Form
    {
        SqlConnection connection;
        private List<DiaryEntry> entries = new List<DiaryEntry>();

        public journal()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\OneDrive\Desktop\Documents\UsersDatabase.mdf;Integrated Security=True");
        }

        private void journal_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            loadEntries();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entryText = txtEntry.Text.Trim();
            if (!string.IsNullOrEmpty(entryText))
            {
                saveEntry(entryText);
                txtEntry.Clear();
                loadEntries();
            }
            else
            {
                MessageBox.Show("Please enter some text.", "Empty Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveEntry(string text)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string insertQuery = "INSERT INTO JournalEntries (UserId, Date, EntryText) VALUES (@UserId, @Date, @EntryText)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@UserId", Form1.UserId);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@EntryText", text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving journal entry: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void loadEntries()
        {
            listBox1.Items.Clear();
            entries.Clear();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string selectQuery = "SELECT Date, EntryText FROM JournalEntries WHERE UserId=@UserId ORDER BY Date DESC";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@UserId", Form1.UserId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string text = reader["EntryText"].ToString();

                    DiaryEntry entry = new DiaryEntry
                    {
                        Date = date,
                        Text = text
                    };

                    entries.Add(entry);
                    listBox1.Items.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading journal entries: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public class DiaryEntry
        {
            public DateTime Date { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                if (Text.Length > 30)
                {
                    return $"{Date.ToString("MMMM dd, yyyy")}: {Text.Substring(0, 30)}...";
                }
                else
                {
                    return $"{Date.ToString("MMMM dd, yyyy")}: {Text}";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEntry_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
