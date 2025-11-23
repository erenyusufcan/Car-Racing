using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Car_Racing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;
        int rodevelocity = 8;
        int mycarvelocity = 5;

        bool leftway = false;
        bool rightway = false;

        int carsvelocity = 10;

        Random rnd = new Random();


        public void startgame()
        {

            timer1.Interval = 16; // Yaklaşık 60 FPS

            btn_startgame.Enabled = false;
            crash.Visible = false;

             mycarvelocity = 8;
             carsvelocity = 10;
             score = 0;

            mycar.Left = 160;
            mycar.Top = 300;

            car1.Left = 30;
            car1.Top = 50;

            car2.Left = 320;
            car2.Top = 50;

            leftway = false;
            rightway = false;

            crash.Top = 294;
            crash.Left = 165;

            timer1.Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            startgame();
            
        }

       



        private void timer1_Tick(object sender, EventArgs e)
        {
            score++;
            lbl_score.Text = score.ToString();

            rode.Top += rodevelocity;
            if (rode.Top > 400)
            {
                rode.Top = -100;
            }

            if (leftway)
            {
                mycar.Left -= mycarvelocity; 
            }

            if (rightway)
            {
                mycar.Left += mycarvelocity;
            }

            if (mycar.Left < 1) { leftway = false; }
            else if (mycar.Left + mycar.Width > 510) { rightway = false; }

            car1.Top += carsvelocity;
            car2.Top += carsvelocity;

            if(car1.Top>panel1.Height)
            {
                changethecar1();
                car1.Left = rnd.Next(70,300);
                car1.Top=rnd.Next(40,140) * -1;
            }

            if (car2.Top > panel1.Height)
            {
                changethecar2();
                car2.Left = rnd.Next(70, 300);
                car2.Top = rnd.Next(40, 140) * -1;
            }

            if(mycar.Bounds.IntersectsWith(car1.Bounds) || mycar.Bounds.IntersectsWith(car2.Bounds))
             {
                gameover();
             }
        }

        private void changethecar1()
        {
            int sıra = rnd.Next(1, 7);
            switch (sıra)
            {
                case 1: car1.Image = Properties.Resources.araba9; break;
                case 2: car1.Image = Properties.Resources.araba2; break;
                case 3: car1.Image = Properties.Resources.araba3; break;
                case 4: car1.Image = Properties.Resources.araba4; break;
                case 5: car1.Image = Properties.Resources.araba6; break;
                case 6: car1.Image = Properties.Resources.araba7; break;
                case 7: car1.Image = Properties.Resources.araba8; break;
            }
        }

        private void changethecar2()
        {
            int sıra = rnd.Next(1, 7);
            switch (sıra)
            {
                case 1:car2.Image = Properties.Resources.araba9;break;
                case 2:car2.Image= Properties.Resources.araba2; break;
                case 3:car2.Image=Properties.Resources.araba3; break;
                case 4: car2.Image = Properties.Resources.araba4; break;
                case 5: car2.Image = Properties.Resources.araba6; break;
                case 6: car2.Image = Properties.Resources.araba7; break;
                case 7: car2.Image = Properties.Resources.araba8; break;
            }
        }

        private void gameover()
        {
            timer1.Stop();
            btn_startgame.Enabled =true;
            crash.Visible = true;
            mycar.Controls.Add(crash);
            crash.Location=new Point(7,-5);
            crash.BringToFront();
            crash.BackColor = Color.Transparent;
            MessageBox.Show("Your score is: " + lbl_score.Text,"Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btn_startgame_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && mycar.Left>0) { leftway = true; }
            if(e.KeyCode == Keys.Right && mycar.Right + mycar.Width<panel1.Width) { rightway = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) {  leftway = false; }
            if (e.KeyCode == Keys.Right) { rightway = false; }
        }
    }
}
