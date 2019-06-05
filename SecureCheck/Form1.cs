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
        }//Одноразовая проверка состояния блокировки
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
           
                
               
            
        }//метод постоянного контроля состояния

        public void button1_Click(object sender, EventArgs e)
        {
           
            button1.Enabled = false;
            button1.ForeColor = Color.LightGreen;
            Thread myThread = new Thread(alarm);
            //alarm();
            myThread.Start();
            
        
        }//Выполнение методов постоянной проверки состояния

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.ForeColor = Color.LightGreen;
            
            check();
            button2.Enabled = true;
        }//Выполнение методов одноразовой проверки состояния

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.LightYellow;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.LightYellow;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        public void ResetCommand()
        {
            string key = "";
            switch (comboBox1.SelectedItem.ToString().Trim())
            {
                case "Reset":
                    
                    key = "0xF0000001";//В этом случае отправится такой код и config.ini сбрасывается в 0
                    break;

                case "Block":
                    
                    key = "0xFF000001";//В этом случае в config.ini запишется 4 и 1
                    break;

                default:
                    MessageBox.Show("Не верное значение");
                    break;
            }

            string url = textBox2.Text;
            //string key = //textBox3.Text;
            string Data = "key=" + key + "&" + "done=send";

            System.Net.WebRequest req = System.Net.WebRequest.Create(url + "?" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();



        }//Метод сброса счётчика и прочие команды

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.ForeColor = Color.LightYellow;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.ForeColor = Color.LightGreen;
            button3.Enabled = false;

            ResetCommand();
            button3.Enabled = true;
        }//Выполнение команд метода сброса и т.д.
    }
}
