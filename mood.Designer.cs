namespace WindowsFormsApp2
{
    partial class mood
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mood));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stressed = new System.Windows.Forms.PictureBox();
            this.angry = new System.Windows.Forms.PictureBox();
            this.sad = new System.Windows.Forms.PictureBox();
            this.relaxed = new System.Windows.Forms.PictureBox();
            this.happy = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stressed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relaxed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(133, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Mood";
            // 
            // txtEntry
            // 
            this.txtEntry.BackColor = System.Drawing.Color.SteelBlue;
            this.txtEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntry.Location = new System.Drawing.Point(279, 284);
            this.txtEntry.Multiline = true;
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(125, 109);
            this.txtEntry.TabIndex = 4;
            this.txtEntry.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(304, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(29, 412);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(387, 184);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Navy;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Myanmar Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(304, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 41);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 36);
            this.label5.TabIndex = 17;
            this.label5.Text = "Relaxed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 36);
            this.label2.TabIndex = 18;
            this.label2.Text = "Angry";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 36);
            this.label3.TabIndex = 19;
            this.label3.Text = "Stressed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 36);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 36);
            this.label6.TabIndex = 21;
            this.label6.Text = "Happy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(284, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 30);
            this.label7.TabIndex = 22;
            this.label7.Text = "Description:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 32);
            this.button3.TabIndex = 23;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(29, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 344);
            this.panel1.TabIndex = 24;
            // 
            // stressed
            // 
            this.stressed.BackColor = System.Drawing.SystemColors.Control;
            this.stressed.Image = ((System.Drawing.Image)(resources.GetObject("stressed.Image")));
            this.stressed.Location = new System.Drawing.Point(29, 340);
            this.stressed.Name = "stressed";
            this.stressed.Size = new System.Drawing.Size(71, 66);
            this.stressed.TabIndex = 13;
            this.stressed.TabStop = false;
            this.stressed.Click += new System.EventHandler(this.stressed_Click);
            // 
            // angry
            // 
            this.angry.BackColor = System.Drawing.SystemColors.Control;
            this.angry.Image = ((System.Drawing.Image)(resources.GetObject("angry.Image")));
            this.angry.Location = new System.Drawing.Point(29, 269);
            this.angry.Name = "angry";
            this.angry.Size = new System.Drawing.Size(71, 65);
            this.angry.TabIndex = 12;
            this.angry.TabStop = false;
            this.angry.Click += new System.EventHandler(this.angry_Click);
            // 
            // sad
            // 
            this.sad.BackColor = System.Drawing.SystemColors.Control;
            this.sad.Image = ((System.Drawing.Image)(resources.GetObject("sad.Image")));
            this.sad.Location = new System.Drawing.Point(29, 198);
            this.sad.Name = "sad";
            this.sad.Size = new System.Drawing.Size(71, 65);
            this.sad.TabIndex = 11;
            this.sad.TabStop = false;
            this.sad.Click += new System.EventHandler(this.sad_Click);
            // 
            // relaxed
            // 
            this.relaxed.BackColor = System.Drawing.SystemColors.Control;
            this.relaxed.Image = ((System.Drawing.Image)(resources.GetObject("relaxed.Image")));
            this.relaxed.Location = new System.Drawing.Point(29, 135);
            this.relaxed.Name = "relaxed";
            this.relaxed.Size = new System.Drawing.Size(71, 66);
            this.relaxed.TabIndex = 10;
            this.relaxed.TabStop = false;
            this.relaxed.Click += new System.EventHandler(this.relaxed_Click);
            // 
            // happy
            // 
            this.happy.BackColor = System.Drawing.SystemColors.Control;
            this.happy.Image = ((System.Drawing.Image)(resources.GetObject("happy.Image")));
            this.happy.Location = new System.Drawing.Point(29, 62);
            this.happy.Name = "happy";
            this.happy.Size = new System.Drawing.Size(71, 73);
            this.happy.TabIndex = 9;
            this.happy.TabStop = false;
            this.happy.Click += new System.EventHandler(this.happy_Click);
            // 
            // mood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(439, 620);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stressed);
            this.Controls.Add(this.angry);
            this.Controls.Add(this.sad);
            this.Controls.Add(this.relaxed);
            this.Controls.Add(this.happy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "mood";
            this.Text = "mood";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stressed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relaxed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox happy;
        private System.Windows.Forms.PictureBox relaxed;
        private System.Windows.Forms.PictureBox sad;
        private System.Windows.Forms.PictureBox angry;
        private System.Windows.Forms.PictureBox stressed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
    }
}