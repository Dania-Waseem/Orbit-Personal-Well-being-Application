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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new mood().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new journal().Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

      //  private void button2_Click(object sender, EventArgs e)
        //{
        //    new overview().Show();
        //    this.Hide();
       // }

        private void button5_Click(object sender, EventArgs e)
        {
            new habit().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new meditation().Show();
            this.Hide();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            new habit().Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new todo().Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new meditation().Show();
            this.Hide();
        }
    }
}
