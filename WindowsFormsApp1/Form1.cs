using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                button1.PerformClick();
        }
        static int x = 0,y=0;
        private void textPressed(object sender, MouseEventArgs e)
        {
            if (x++ == 0)
            {
                switch (MouseButtons)
                {
                    case MouseButtons.Left:
                        textBox1.Text = "";
                        textBox1.ForeColor = Color.Black;
                        break;
                }
            }
        }
        private void text2Pressed(object sender, MouseEventArgs e)
        {
            if (y++ == 0)
            {
                switch (MouseButtons)
                {
                    case MouseButtons.Left:
                        textBox2.Text = "";
                        textBox2.ForeColor = Color.Black;
                        break;
                }
            }
        }
        private void calculate(object sender, EventArgs e)
        {
            double value, speed;
            if (comboBox1.Text == "MB")
            {
                value = Double.Parse(textBox1.Text);
                speed = Double.Parse(textBox2.Text);
            }
            else
            {
                value = Double.Parse(textBox1.Text)*1000;
                speed = Double.Parse(textBox2.Text);
            }
                int seconds = Convert.ToInt32(value / speed);
                int mins = seconds / 60;
                int hours = mins / 60;
                int days = hours / 24;
                int[] ar = { hours, mins, seconds ,days};
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (ar[i] == 0)
                        count++;
                }
                switch (count)
                {
                    case 0:
                        hours = hours - days*24; 
                        mins =mins- hours * 60-days*1440;
                        seconds =seconds- mins * 60-hours*3600-days*86400;
                        label1.Text =days.ToString()+" days "+ hours.ToString() + " hours " + mins.ToString() + " minutes " + seconds.ToString() + " seconds.";
                        break;
                    case 1:
                        mins -= hours * 60;
                        seconds =seconds- mins * 60  - hours * 3600;
                        label1.Text = hours.ToString()+" hours "+mins.ToString() + " minutes " + seconds.ToString() + " seconds. ";
                        break;
                    case 2:
                        seconds = seconds - mins * 60  - hours * 3600;
                        label1.Text =mins.ToString()+" minutes "+ seconds.ToString() + " seconds. ";
                        break;
                    case 3:
                        label1.Text = seconds.ToString() + " seconds. ";
                        break;
                }
            
        }

    }
}
