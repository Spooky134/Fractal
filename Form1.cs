using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SurFractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        public void drawF(int x, int y,double len,double angle,Color col,float w,int white,Color sec)
        {
            Graphics g = pictureBox1.CreateGraphics();
            double x1, y1;
            x1 = x + len * Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + len * Math.Cos(angle * Math.PI * 2 / 360.0);
            g.DrawLine(new Pen(col, w), x, pictureBox1.Height - y, (int)x1, pictureBox1.Height - (int)y1);
            
            if (len > 2 & len < 10)
            {
                drawF((int)x1, (int)y1, len / (rnd.NextDouble() + 1), angle + rnd.Next(0, 40),sec,w/3,white,sec);
                drawF((int)x1, (int)y1, len / (rnd.NextDouble() + 1), angle - rnd.Next(0, 40),sec,w/3,white, sec);
            }
            if (len > 10 & len < 50)
            {
                drawF((int)x1, (int)y1, len / (rnd.NextDouble() + 1), angle + rnd.Next(0, 40),Color.FromArgb(white + 30, white + 30, white + 30), w/2,white, sec);
                drawF((int)x1, (int)y1, len / (rnd.NextDouble() + 1), angle - rnd.Next(0, 40),Color.FromArgb(white + 30, white + 30, white + 30), w/2,white, sec);
            }
            if (len > 50)
            {
                drawF((int)x1, (int)y1, (len / (rnd.NextDouble() + 1)), angle + rnd.Next(0, 40),Color.FromArgb(white + 30, white + 30, white + 30),w,white, sec);
                drawF((int)x1, (int)y1, (len / (rnd.NextDouble() + 1)), angle - rnd.Next(0, 40),Color.FromArgb(white + 30, white + 30, white + 30), w,white, sec);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawAsync();
        }
         async void DrawAsync()
        {
            int ang = 0;
            while (ang < 360)
            {
                await Task.Run(() => drawF(pictureBox1.Width / 2, pictureBox1.Height / 2, 15.0 + rnd.Next(30, 60), ang, Color.FromArgb(255, 255, 255), 2 + rnd.Next(1, 4), 225, Color.BlueViolet));
                ang += rnd.Next(20, 35);
            }
            ang = 0;
            while (ang < 360){
                await Task.Run(() => drawF(pictureBox1.Width / 2, pictureBox1.Height / 2, 15.0 + rnd.Next(30, 60), ang, Color.FromArgb(255, 255, 255), 2 + rnd.Next(1, 4), 225, Color.HotPink));
                ang += rnd.Next(20, 35);
            }
            ang = 0;
            while (ang < 360)
            {
                await Task.Run(() => drawF(pictureBox1.Width / 2, pictureBox1.Height / 2, 15.0 + rnd.Next(30, 60), ang, Color.FromArgb(255, 255, 225), 2 + rnd.Next(1, 4), 225, Color.OrangeRed));
                ang += rnd.Next(20, 35);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
