using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonClicker
{
    public partial class Form1 : Form
    {
        private float timeLeft;
        private Button clickButton;
        private int bonus;

        public Form1()
        {
            InitializeComponent();
            bonus = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            timeLeft = 5.0f;
            labelTime.Text = timeLeft.ToString("0.00");
            timer1.Enabled = true;

            createButton();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timeLeft < 0.1f)
            {
                timer1.Enabled = false;
                Controls.Remove(clickButton);
                MessageBox.Show("Ваш счёт: " + labelScore.Text);
            }
            else
            {
                timeLeft -= 0.1f;
            }

            labelTime.Text = timeLeft.ToString("0.00");
        }
        private void createButton()
        {

            clickButton = new Button();
            Random randVal = new Random();
            int x = randVal.Next(10, 460), y = randVal.Next(100, 370);
            clickButton.Location = new System.Drawing.Point(x, y);
            clickButton.Name = "clickButton";
            clickButton.Size = new System.Drawing.Size(30, 30);
            clickButton.Text = "+";
            clickButton.UseVisualStyleBackColor = true;
            clickButton.Click += new System.EventHandler(clickButton_Click);

            this.SuspendLayout();
            Controls.Add(clickButton);
            this.ResumeLayout(false);
        }


        private void clickButton_Click(object sender, EventArgs e)
        {
            labelScore.Text = (int.Parse(labelScore.Text) + 10 + bonus).ToString();
            bonus += 1;
            Controls.Remove(clickButton);
            createButton();
        }
    }
}
