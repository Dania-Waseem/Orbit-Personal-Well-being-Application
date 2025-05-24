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
    public partial class mood : Form
    {
        private List<string> moods;
        string selectedMood;
        SqlConnection connection; // Added for database connection

        public mood()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\OneDrive\Desktop\Documents\UsersDatabase.mdf;Integrated Security=True");
            LoadMoodEntries();
        }

        
        private void LoadMoodEntries()
        {
            listBox1.Items.Clear();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string selectQuery = "SELECT Date, Time, Mood, Entry FROM MoodEntries WHERE UserId=@UserId ORDER BY Date, Time";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@UserId", Form1.UserId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader["Date"].ToString();
                    string time = reader["Time"].ToString();
                    string mood = reader["Mood"].ToString();
                    string entry = reader["Entry"].ToString();

                    string journalEntry = $"{date} {time} - Mood: {mood} - Entry: {entry}";
                    listBox1.Items.Add(journalEntry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading mood entries: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void saveEntry(string mood, string entry)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string insertQuery = "INSERT INTO MoodEntries (UserId, Date, Time, Mood, Entry) VALUES (@UserId, @Date, @Time, @Mood, @Entry)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@UserId", Form1.UserId);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("hh:mm tt"));
                cmd.Parameters.AddWithValue("@Mood", mood);
                cmd.Parameters.AddWithValue("@Entry", entry);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving mood entry: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string deleteQuery = "DELETE FROM MoodEntries WHERE UserId=@UserId";
                SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@UserId", Form1.UserId);
                cmd.ExecuteNonQuery();
                listBox1.Items.Clear();
                MessageBox.Show("Mood history cleared successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing mood entries: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mood = selectedMood;
            string entry = txtEntry.Text;
            if (!string.IsNullOrWhiteSpace(entry) && !string.IsNullOrWhiteSpace(mood))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO MoodEntries (UserId, Date, Time, Mood, Entry) VALUES (@UserId, @Date, @Time, @Mood, @Entry)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserId", Form1.UserId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("hh:mm tt")); // 04:15 PM format
                    cmd.Parameters.AddWithValue("@Mood", mood);
                    cmd.Parameters.AddWithValue("@Entry", entry);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Mood entry saved successfully!");
                    txtEntry.Clear();
                    LoadMoodEntries(); // Refresh list
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving mood: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a mood and write a description before adding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sad_Click(object sender, EventArgs e)
        {
            selectedMood = "Sad";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void happy_Click(object sender, EventArgs e)
        {
            selectedMood = "Happy";
        }

        private void relaxed_Click(object sender, EventArgs e)
        {
            selectedMood = "Relaxed";
        }

        private void angry_Click(object sender, EventArgs e)
        {
            selectedMood = "Angry";
        }

        private void stressed_Click(object sender, EventArgs e)
        {
            selectedMood = "Stressed";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
    }
}
