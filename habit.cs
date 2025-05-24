using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class habit : Form

    {
        private Dictionary<string, List<DateTime>> habitTracker;
        public habit()
        {
            InitializeComponent();
            habitTracker = new Dictionary<string,List<DateTime>>();
            UpdateList();
        }

        private void UpdateList()
        {
            listView1.Items.Clear();
            foreach (var habit in habitTracker.Keys)
            {
                listView1.Items.Add(habit);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void habit_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string habit = textBox1.Text;
            if(!string.IsNullOrWhiteSpace(habit) && !habitTracker.ContainsKey(habit))
            {
                habitTracker.Add(habit, new List<DateTime>());  
                textBox1.Clear();
                UpdateList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                string selectedHabits = listView1.SelectedItems[0].Text;
                if (habitTracker.ContainsKey(selectedHabits))
                {
                    habitTracker[selectedHabits].Add(DateTime.Today);
                    MessageBox.Show("Habit completed for today!", "Success");
                    UpdateCalendar();
                }
            }
        }

        private void UpdateCalendar()
        {
            monthCalendar1.RemoveAllBoldedDates();
            foreach (var habitdate in habitTracker.Values)
            {
                foreach (var date in habitdate)
                {
                    monthCalendar1.AddBoldedDate(date);
                }

            }

            monthCalendar1.UpdateBoldedDates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedHabits = listView1.SelectedItems[0].Text;
                if (habitTracker.ContainsKey(selectedHabits))
                {
                    int completedDays = habitTracker[selectedHabits].Count;
                    label1.Text = $"You completed ' {selectedHabits} ' for {completedDays} days";

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
