using System.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // <-- ADD THIS
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp2
{
    public partial class meditation : Form
    {
        Dictionary<string, int> meditationLog = new Dictionary<string, int>();
        int seconds;

        SoundPlayer oceanPlayer;
        SoundPlayer birdsPlayer;
        SoundPlayer rainPlayer;
        SoundPlayer guitarPlayer;
        SoundPlayer whiteNoisePlayer;

        bool isOceanPlaying = false;
        bool isBirdsPlaying = false;
        bool isRainPlaying = false;
        bool isGuitarPlaying = false;
        bool isWhiteNoisePlaying = false;

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\OneDrive\Desktop\Documents\UsersDatabase.mdf;Integrated Security=True");

        public meditation()
        {
            InitializeComponent();

            oceanPlayer = new SoundPlayer(Properties.Resources.ocean);
            birdsPlayer = new SoundPlayer(Properties.Resources.birds);
            rainPlayer = new SoundPlayer(Properties.Resources.rain);
            guitarPlayer = new SoundPlayer(Properties.Resources.guitar);
            whiteNoisePlayer = new SoundPlayer(Properties.Resources.comfort);
        }

        private void meditation_Load(object sender, EventArgs e)
        {
            LoadMeditationHistoryFromDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)  //start button
        {
            seconds = Convert.ToInt32(textBox1.Text);
            textBox1.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = seconds--.ToString();

            if (seconds < 0)
            {
                timer1.Stop();
                textBox1.Enabled = true;

                string today = DateTime.Now.ToShortDateString();
                int duration = Convert.ToInt32(textBox1.Text);

                if (meditationLog.ContainsKey(today))
                    meditationLog[today] += duration;
                else
                    meditationLog[today] = duration;

                SaveMeditationToDatabase(today, duration);
                UpdateMeditationHistory();
            }
        }

        private void SaveMeditationToDatabase(string date, int duration)
        {
            try
            {
                connection.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM MeditationRecords WHERE UserId=@userId AND MeditationDate=@date", connection);
                checkCmd.Parameters.AddWithValue("@userId", Form1.UserId);
                checkCmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE MeditationRecords SET DurationSeconds = DurationSeconds + @duration WHERE UserId=@userId AND MeditationDate = @date", connection);
                    updateCmd.Parameters.AddWithValue("@duration", duration);
                    updateCmd.Parameters.AddWithValue("@userId", Form1.UserId);
                    updateCmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO MeditationRecords (UserId, MeditationDate, DurationSeconds) VALUES (@userId, @date, @duration)", connection);
                    insertCmd.Parameters.AddWithValue("@userId", Form1.UserId);
                    insertCmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
                    insertCmd.Parameters.AddWithValue("@duration", duration);
                    insertCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadMeditationHistoryFromDatabase()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT MeditationDate, DurationSeconds FROM MeditationRecords WHERE UserId=@userId", connection);
                cmd.Parameters.AddWithValue("@userId", Form1.UserId);

                SqlDataReader reader = cmd.ExecuteReader();
                meditationLog.Clear();

                while (reader.Read())
                {
                    string date = Convert.ToDateTime(reader["MeditationDate"]).ToShortDateString();
                    int duration = Convert.ToInt32(reader["DurationSeconds"]);
                    meditationLog[date] = duration;
                }
                reader.Close();

                UpdateMeditationHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading from database: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateMeditationHistory()
        {
            listBox1.Items.Clear();
            foreach (var entry in meditationLog)
            {
                listBox1.Items.Add($"{entry.Key}: {entry.Value} seconds meditated");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e) // Ocean
        {
            if (!isOceanPlaying)
            {
                oceanPlayer.PlayLooping();
                isOceanPlaying = true;
                button3.Text = "Stop";
            }
            else
            {
                oceanPlayer.Stop();
                isOceanPlaying = false;
                button3.Text = "Ocean";
            }
        }

        private void button4_Click(object sender, EventArgs e) // Birds
        {
            if (!isBirdsPlaying)
            {
                birdsPlayer.PlayLooping();
                isBirdsPlaying = true;
                button4.Text = "Stop";
            }
            else
            {
                birdsPlayer.Stop();
                isBirdsPlaying = false;
                button4.Text = "Birds";
            }
        }

        private void button5_Click(object sender, EventArgs e) // Rain
        {
            if (!isRainPlaying)
            {
                rainPlayer.PlayLooping();
                isRainPlaying = true;
                button5.Text = "Stop";
            }
            else
            {
                rainPlayer.Stop();
                isRainPlaying = false;
                button5.Text = "Rain";
            }
        }

        private void button6_Click(object sender, EventArgs e) // Guitar
        {
            if (!isGuitarPlaying)
            {
                guitarPlayer.PlayLooping();
                isGuitarPlaying = true;
                button6.Text = "Stop";
            }
            else
            {
                guitarPlayer.Stop();
                isGuitarPlaying = false;
                button6.Text = "Guitar";
            }
        }

        private void button7_Click(object sender, EventArgs e) // Comfort/WhiteNoise
        {
            if (!isWhiteNoisePlaying)
            {
                whiteNoisePlayer.PlayLooping();
                isWhiteNoisePlaying = true;
                button7.Text = "Stop";
            }
            else
            {
                whiteNoisePlayer.Stop();
                isWhiteNoisePlaying = false;
                button7.Text = "Comfort";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
