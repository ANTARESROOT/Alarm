using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;


namespace SecureCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //bool x = true;
            
            //while (x = true)
            //{
                
            //}

        }

        public void check()
        {
            string Check = new System.Net.WebClient().DownloadString(textBox1.Text);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\bsound.wav");

            if (Check.Contains("System blocked"))
            {
                

                player.Play();
                
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                player.Stop();
                

                //timer1.Start();
            }
        }
        public void alarm()
        {
            cx:
            string Check = new System.Net.WebClient().DownloadString(textBox1.Text);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\bsound.wav");

            bool x = true;
            while (x)
            
            {
                if (Check.Contains("System blocked"))
                {
                    Thread.Sleep(100);
                    label1.ForeColor = Color.Red;
                    label1.Text = "ТРЕВОГА!!!";
                    player.Play();
                    System.Threading.Thread.Sleep(20000);
                    player.Stop();
                    
                    goto cx;

                }
            else
                {
                    label1.ForeColor = Color.LightGreen;
                    label1.Text = "ВСЁ В ПОРЯДКЕ";
                    System.Threading.Thread.Sleep(1000);
                    goto cx;

                
                }
            }
           
                
               
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
           
            button1.Enabled = false;
            Thread myThread = new Thread(alarm);
            //alarm();
            myThread.Start();
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            
            check();
            button2.Enabled = true;
        }
    }
}
