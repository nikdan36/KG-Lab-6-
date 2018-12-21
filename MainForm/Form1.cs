using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        byte flFunc = 0;
        double coeff = 1;
        Graphics g;
       
        int count;
        int counter;
        MyClass G = new MyClass();

        private int X(int x)
        {
            int H = Form1.ActiveForm.Size.Height;
            int W = Form1.ActiveForm.Size.Width;
            int c_x = W / 2;
            int c_y = H / 2;
            x = c_x + x;
            return x;
        }
        private int Y(int y)
        {
            int H = Form1.ActiveForm.Size.Height;
            int W = Form1.ActiveForm.Size.Width;
            int c_x = W / 2;
            int c_y = H / 2;
            y = c_y - y;
            return y;
        }

        bool drawing = false;

        MouseEventArgs e0;
        Bitmap btm;
        PaintEventArgs e;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            btm = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, g);
            e = new PaintEventArgs(g, ClientRectangle);
        }
        public void MyDraw(Graphics g)
        {
            btm = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, g);
            g.Clear(Color.White);
            G.Draw(g, ClientRectangle, count, counter, flFunc);
            e.Graphics.DrawImage(btm, 0, 0, btm.Width, btm.Height);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            G.Draw(g, ClientRectangle, count, counter, flFunc);
            e.Graphics.DrawImage(btm, 0, 0, btm.Width, btm.Height);
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            double x = G.XX(e.X);
            double y = G.YY(e.Y);
            if (e.Delta < 0)
                coeff = 1.03;
            else
                coeff = 0.97;
            G.x1 = x - (x - G.x1) * coeff;
            G.x2 = x + (G.x2 - x) * coeff;
            G.y1 = y - (y - G.y1) * coeff;
            G.y2 = y + (G.y2 - y) * coeff;
            MyDraw(g);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                double dx = G.XX(e.X) - G.XX(e0.X);
                double dy = G.YY(e.Y) - G.YY(e0.Y);
                e0 = e;
                G.x1 -= dx; G.y1 -= dy;
                G.x2 -= dx; G.y2 -= dy;
                //Invalidate();
                MyDraw(g);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           // MyDraw(g);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            e0 = e;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            flFunc = 0;
            MyDraw(g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            G.a++;
            MyDraw(g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            G.a--;
            MyDraw(g);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            G.b++;
            MyDraw(g);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            G.b--;
            MyDraw(g);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            G.c++;
            MyDraw(g);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            G.c--;
            MyDraw(g);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string str = "х=" + e.X + ";" + "y=" + e.Y;
            Font aFont = new Font("Arial", 8, FontStyle.Bold);
            g.DrawString(str, aFont, Brushes.Black, e.X, e.Y);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            count = 1;
            MyDraw(g);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            count = 2;
            MyDraw(g);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            count = 3;
            MyDraw(g);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            counter = 0;
            MyDraw(g);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            counter = 1;
            MyDraw(g);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            counter = 2;
            MyDraw(g);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            counter = 3;
            MyDraw(g);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            flFunc = 2;
            MyDraw(g);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            G.a++;
            MyDraw(g);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            G.a--;
            MyDraw(g);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            G.b++;
            MyDraw(g);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            G.b--;
            MyDraw(g);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            G.c++;
            MyDraw(g);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            G.c--;
            MyDraw(g);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            count = 0;
            MyDraw(g);
        }
    }
}
