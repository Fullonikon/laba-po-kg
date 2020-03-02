using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap image;
        private Bitmap invimage;

        static public Int32 Clamp(Int32 a, Int32 min, Int32 max)
        {
            Int32 res = a;
            if (a < min) res = min;
            else if (a > max) res = max;
            return res;
        }

        //abstract class Filters
        //{
        //    public abstract Color calculatenewpixelcolor(Bitmap SourceImage, int i, int j);
        //}
        //class MatrixFilters : Filters
        //{
        //    protected float[,] kernel = null;

        //    public override Color calculatenewpixelcolor(Bitmap SourceImage, int x, int y)
        //    {
        //    int rX = kernel.GetLength(0) / 2;
        //    int rY = kernel.GetLength(1) / 2;
        //    float resR = 0;
        //    float resG = 0;
        //    float resB = 0;
        //            for (int l = -rY; l <= rY; l++)
        //                for (int k = -rX; k <= rX; k++)
        //                {
        //                    int idX = Clamp(x + k, 0, SourceImage.Width - 1);
        //    int idY = Clamp(y + l, 0, SourceImage.Height - 1);
        //    Color nColor = SourceImage.GetPixel(idX, idY);
        //    resR += nColor.R* kernel[k + rX, l + rY];
        //    resG += nColor.G* kernel[k + rX, l + rY];
        //    resB += nColor.B* kernel[k + rX, l + rY];
        //}
        //            return Color.FromArgb(Clamp((int) resR, 0, 255), Clamp((int) resG, 0, 255), Clamp((int) resB, 0, 255));
        //    }
        //    class BlurFilter : MatrixFilters
        //    {
        //        public BlurFilter()
        //        {
        //int sizeX = 3;
        //int sizeY = 3;
        //kernel = new float[sizeX, sizeY];
        //            for (int i = 0; i<sizeX; i++)
        //                for (int j = 0; j<sizeY; j++)
        //                {
        //                    kernel[i, j] = 1.0f / (float) (sizeX* sizeY);
        //                }
    //        }
    //    }
    //    static Filters filter = new BlurFilter();
    //}
    // инверсия цвета       я хз почему так функция пишется
    public Color invert(Color c) => Color.FromArgb(c.A, 0xFF - c.R, 0xFF - c.G, 0xFF - c.B);
        // полутон, в скобках чёрно белый фильтр
        public Color poluton(Color c) => Color.FromArgb(c.A, (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B), (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B), (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B));
        // сепия
        public Color sepia(Color c)
        {
            Int32 intensity = (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
            double k = 20;
            Int32 R = Clamp((Int32)(intensity + 2 * k), 0, 255);
            Int32 G = Clamp((Int32)(intensity + 0.5 * k), 0, 255);
            Int32 B = Clamp((Int32)(intensity - 1 * k), 0, 255);
            return Color.FromArgb(c.A, R, G, B);
        }
        // увеличить яркость 
        public Color increse(Color c, int inc)
        {
            return Color.FromArgb(c.A, Clamp(c.R + inc, 0, 255), Clamp(c.G + inc, 0, 255), Clamp(c.B + inc, 0, 255));
        }

        public Color blur (Bitmap source, int x, int y, float[,] kernel)
        {
            int rX = kernel.GetLength(0) / 2;
            int rY = kernel.GetLength(1) / 2;
            float resR = 0;
            float resG = 0;
            float resB = 0;
            for (int l = -rY; l <= rY; l++)
                for (int k = -rX; k <= rX; k++)
                {
                    int idX = Clamp(x + k, 0, source.Width - 1);
                    int idY = Clamp(y + l, 0, source.Height - 1);
                    Color nColor = source.GetPixel(idX, idY);
                    resR += nColor.R * kernel[k + rX, l + rY];
                    resG += nColor.G * kernel[k + rX, l + rY];
                    resB += nColor.B * kernel[k + rX, l + rY];
                }
            return Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255));
        }
        private void button1_Click(object sender, EventArgs e) // главная кнопочка. батон хлеба
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@".\267464-werecat.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@".\267464-werecat.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, sepia(invimage.GetPixel(i, j))); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда лут";
            label2.Text = "отсюда гуд";
        }

        private void button2_Click(object sender, EventArgs e) // яркость
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@".\267464-werecat.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@".\267464-werecat.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            int inc = (int)numericUpDown1.Value;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, increse(invimage.GetPixel(i, j), inc));
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float [,] kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@".\267464-werecat.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@".\267464-werecat.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, blur(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда лут";
            label2.Text = "отсюда гуд";
        }
    }
}