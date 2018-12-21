using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MyClass
    {
        static int I1 = 0, J1 = 0, I2, J2;

        public double x1 = -0.1, y1 = -1, x2 = 3.1, y2 = 16;

        public delegate int IJ(double x);

        public Pen MyPen1;
        public Pen MyPen2;

        public void Pen(int count)
        {
            switch (count)
            {
                case 0:
                    MyPen1.Color = Color.Black;
                    break;
                case 1:
                    MyPen1.Color = Color.Blue;
                    break;
                case 2:
                    MyPen1.Color = Color.Yellow;
                    break;
                case 3:
                    MyPen1.Color = Color.Green;
                    break;
            }
        }

        public int[] Pen2(int counter)
        {
             int a = 0;
             int b = 0;
             int c = 0;
               
            
            switch (counter)
            {
                case 0:
                    a = 250;
                    b = 255;
                    c = 255;

                    break;
                case 1:
                    a = 250;
                    b = 0;
                    c = 0;
                    
                   break;
                case 2:
                    a = 238;
                    b = 130;
                    c = 238;

                    break;
                case 3:
                    a = 128;
                    b = 129;
                    c = 128;
                    break;
            }
            int[] Pen2 = { a, b, c };
            return Pen2;
        }

        public MyClass()
        {
            MyPen1 = new Pen(Brushes.Black, 3);
            MyPen1.Color = Color.Black; //.Yellow; // .Black;
            //MyPen1.DashStyle = DashStyle.Dot;
            MyPen2 = new Pen(Brushes.Black, 2);
            MyPen2.Color = Color.Black; //.LightBlue; // .Black;
        }

        int II(double x)
        {
            return I1 + (int)((x - x1) * (I2 - I1) / (x2 - x1));
        }

        public double XX(int I)
        {
            return x1 + (I - I1) * (x2 - x1) / (I2 - I1);
        }

        int JJ(double y)
        {
            return J2 + (int)((y - y1) * (J1 - J2) / (y2 - y1));
        }

        public double YY(int J)
        {
            return y1 + (J - J2) * (y2 - y1) / (J1 - J2);
        }

        public int a = 1;
        public int b = 0;
        public int c = 0;
        public double F(double x, byte flFunc)
        {
            switch (flFunc)
            {
                case 0:
                    return a * (x - b) * (x - b) + c;
                case 2:
                    return a * x + b;
                default:
                    return 0;
            }
        }
         

        

        double HH(double a1, double a2)
        {
            double Result = 1;
            while (Math.Abs(a2 - a1) / Result < 1)
                Result /= 10.0;
            while (Math.Abs(a2 - a1) / Result >= 10)
                Result *= 10.0;
            if (Math.Abs(a2 - a1) / Result < 2.0)
                Result /= 5.0;
            if (Math.Abs(a2 - a1) / Result < 5.0)
                Result /= 2.0;
            return Result;
        }

        byte GetDigits(double dx)
        {
            byte Result;
            if (dx >= 5) Result = 0;
            else
                if (dx >= 0.5) Result = 1;
            else
                    if (dx >= 0.05) Result = 2;
            else
                        if (dx >= 0.005) Result = 3;
            else
                            if (dx >= 0.0005) Result = 4; else Result = 5;
            return Result;
        }

        Font aFont;


        void OX(IJ II, IJ JJ, Graphics g)
        {
            g.DrawLine(Pens.Black, II(x1), JJ(0), II(x2), JJ(0));
            double h1 = HH(x1, x2);
            int k1 = (int)Math.Round(x1 / h1) - 1;
            int k2 = (int)Math.Round(x2 / h1);
            byte Digits = GetDigits(Math.Abs(x2 - x1));
            for (int i = k1; i <= k2; i++)
            {
                g.DrawLine(MyPen2, II(i * h1), JJ(0) - 7, II(i * h1), JJ(0) + 7);
                for (int j = 1; j <= 9; j++)
                    g.DrawLine(MyPen2, II(i * h1 + j * h1 / 10), JJ(0) - 3, II(i * h1 + j * h1 / 10), JJ(0) + 3);
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, II(i * h1) - 5, JJ(0) - 13);
            }
        }


        void OY(IJ II, IJ JJ, Graphics g)
        {
            g.DrawLine(Pens.Black, II(0), JJ(y1), II(0), JJ(y2));
            double h1 = HH(y1, y2); int k1 = (int)Math.Round(y1 / h1) - 1;
            int k2 = (int)Math.Round(y2 / h1);
            int Digits = GetDigits(Math.Abs(y2 - y1));
            for (int i = k1; i <= k2; i++)
            {
                g.DrawLine(MyPen2, II(0) - 7, JJ(i * h1), II(0) + 7, JJ(i * h1));
                for (int j = 1; j <= 9; j++)
                    g.DrawLine(MyPen2, II(0) - 3, JJ(i * h1 + j * h1 / 10), II(0) + 3, JJ(i * h1 + j * h1 / 10));
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, II(0) + 5, JJ(i * h1) - 5);
            }
        }


        public void Draw(Graphics g, Rectangle ClientRectangle, int count, int counter, byte flFunc)
        {
            I2 = ClientRectangle.Width; // Size.Width - 17; 
            J2 = ClientRectangle.Height; // Size.Height - 40;
            const int n = 50;
            try
            {
                int[] a = Pen2(counter);
                
                Color cl = Color.FromArgb(a[0], a[1], a[2]);
                g.Clear(cl);
                Rectangle r = ClientRectangle;

                aFont = new Font("Arial", 8, FontStyle.Bold);
                OX(II, JJ, g); OY(II, JJ, g);
                aFont.Dispose();

                Pen(count);
               

                // график функции
                double h = (x2 - x1) / n;
                //double h = x1 * x2;
                for (int i = 1; i < n; i++)
                    g.DrawLine(MyPen1, II(x1 + (i - 1) * h), JJ(F(x1 + (i - 1) * h, flFunc)),
                                       II(x1 + i * h), JJ(F(x1 + i * h, flFunc)));
            }
            finally
            {
            }

        }
        
        /*private void MyDrawLine(int x1, int y1, int x2, int y2, Bitmap btm, Graphics g) //Брезенхем
        {
            int x = x1; int y = y1;
            int Dx = x2 - x1; int Dy = y2 - y1;
            int e = 2 * Dy - Dx;
            for (int i = 1; i <= Dx; i++)
            {
                //g.FillRectangle(Brushes.Black, x, y, 1, 1);
                if (x > 0 && x < btm.Width && y > 0 && y < btm.Height)
                    btm.SetPixel(x, y, Color.Black);
                if (e >= 0)
                {
                    y++;
                    e += -2 * Dx + 2 * Dy;
                }
                else
                    e += 2 * Dy;
                x++;
            }
        }*/
    }
    }
