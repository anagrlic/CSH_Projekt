using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSH_Projekt
{
    public partial class Form1 : Form
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int trig = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            hours = Convert.ToInt32(Math.Round(numericUpDownHours.Value, 3));
            minutes = Convert.ToInt32(Math.Round(numericUpDownMinutes.Value, 3));
            seconds = Convert.ToInt32(Math.Round(numericUpDownSeconds.Value, 3));

            lblHours.Text = hours.ToString();
            lblMinutes.Text = minutes.ToString();
            lblSeconds.Text = seconds.ToString();

            if (trig == 0)
            {
                timer1 = new Timer();
                timer1.Tick += Timer1_Tick;
                timer1.Interval = 1000; //1 sekunda
                trig = 1;
            }

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds <= 0)
            {
                if (minutes > 0 || hours > 0)
                {
                    if (minutes == 0)
                    {
                        if (hours >= 0)
                        {
                            hours = hours - 1;
                            minutes = 60;
                            if (hours < 0)
                            {
                                hours = 0;
                            }
                        }
                    }

                    minutes = minutes - 1;
                    seconds = 59;
                    timer1 = new Timer();
                    timer1.Interval = 1000;
                    timer1.Start();
                    lblHours.Text = hours.ToString();
                    lblMinutes.Text = minutes.ToString();
                    lblSeconds.Text = seconds .ToString();

                    if (minutes < 0)
                    {
                        minutes = 0;
                    }
                }
                if (seconds < 0)
                {
                    seconds = 0;
                }
                timer1.Stop();
            }

            if (seconds < 60 && minutes < 5)
            {
                if (seconds % 2 == 0)
                {
                    lblHours.ForeColor = Color.Red;
                    lblSeconds.ForeColor = Color.Red;
                    lblMinutes.ForeColor = Color.Red;
                }
                else
                {
                    lblHours.ForeColor = Color.Black;
                    lblMinutes.ForeColor = Color.Black;
                    lblSeconds.ForeColor = Color.Black;
                }
                
            }

            lblHours.Text = hours.ToString();
            lblMinutes.Text = minutes.ToString();
            lblSeconds.Text = seconds.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
    }
}
