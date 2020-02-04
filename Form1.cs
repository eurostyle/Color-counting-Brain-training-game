using System;
using System.Drawing;
using System.Windows.Forms;

namespace namuDarba7i_zaidimas
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        int ticks = 0;
        int ticks2 = 0;
        int redTicks = 0;
        int yellowTicks = 0;
        int rndNumGlobal = 0;
        int rndNumGlobal2 = 0;
        int currentScore = 0;
        int totalGames = 0;
        int topScore = 0;

        // start mygtuko nustatymai
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            totalGames++;
            label7.Text = totalGames.ToString();
            redTicks = 0;
            yellowTicks = 0;

            textBox2.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox2.Text = "";
            textBox4.Text = "";
            textBox2.BackColor = Color.White;
            textBox4.BackColor = Color.White;

            Random rnd = new Random();
            int rndNum = rnd.Next(1, 11);
            rndNumGlobal = rndNum;

            Random rnd2 = new Random();
            int rndNum2 = rnd2.Next(1, 15);
            rndNumGlobal2 = rndNum2;

            timer1.Interval = 1000;
            timer1.Start();
            timer2.Interval = 600;
            timer2.Start();

            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {   
            textBox1.BackColor = Color.White;
            //textBox1.Text = redTicks.ToString();
            ticks++;

            if (ticks % 2 == 0)
            {
                textBox1.BackColor = Color.Red;
                redTicks++;

                if (redTicks == rndNumGlobal)
                {
                    textBox1.BackColor = Color.White;
                    timer1.Stop();
                }
            }
        }
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
            //textBox3.Text = yellowTicks.ToString();
            ticks2++;

            if (ticks2 % 2 == 0)
            {              
                textBox3.BackColor = Color.Yellow;
                yellowTicks++;

                if (yellowTicks == rndNumGlobal2)
                {
                    textBox3.BackColor = Color.White;
                    timer2.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox2.ReadOnly = true;
            try
            {
                int answer = int.Parse(textBox2.Text);
                if (answer + 1 == redTicks)
                {
                    currentScore++;
                    textBox2.BackColor = Color.LightGreen;
                    label5.Text = currentScore.ToString();
                }
                else if (currentScore != 0)
                {
                    currentScore--;
                    label5.Text = currentScore.ToString();
                }
                else
                {
                    textBox1.Text = redTicks.ToString();
                    textBox1.ForeColor = Color.Red;
                    textBox2.BackColor = Color.HotPink;
                }
            }
            catch (FormatException)
            {
                textBox2.ReadOnly = false;
                textBox2.Text = "number";
            }
            if (topScore < currentScore)
            {
                topScore = currentScore;
                label6.Text = topScore.ToString();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
            try
            {
                int answer2 = int.Parse(textBox4.Text);
                if (answer2 + 1 == yellowTicks)
                {
                    currentScore++;
                    textBox4.BackColor = Color.LightGreen;
                    label5.Text = currentScore.ToString();
                }
                else if (currentScore != 0)
                {
                    currentScore--;
                    label5.Text = currentScore.ToString();
                }
                else
                {
                    textBox3.Text = yellowTicks.ToString();
                    textBox3.ForeColor = Color.Red;
                    textBox4.BackColor = Color.HotPink;
                }
            }catch (FormatException)
            {
                textBox4.ReadOnly = false;
                textBox4.Text = "number";
            }
            if (topScore < currentScore)
            {
                topScore = currentScore;
                label6.Text = topScore.ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == 13)
            {
                button2_Click(sender, null);

                if (textBox2.Text != "number")
                {
                    textBox2.ReadOnly = true;
                }
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click_1(sender, null);
                
                if (textBox4.Text != "number")
                {
                    textBox4.ReadOnly = true;
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }
    } 
}
