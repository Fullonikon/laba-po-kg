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
        private Bitmap ii;

        static public Int32 Clamp(Int32 a, Int32 min, Int32 max)
        {
            Int32 res = a;
            if (a < min) res = min;
            else if (a > max) res = max;
            return res;
        }
    // инверсия цвета
    public Color invert(Color c) => Color.FromArgb(c.A, 0xFF - c.R, 0xFF - c.G, 0xFF - c.B);
        // полутон
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

        public Color CalcM (Bitmap source, int x, int y, float[,] kernel)
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
        public Color CalcT(Bitmap source, int x, int y, float[,] kernel)
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
                    resR += (nColor.R * kernel[k + rX, l + rY]);
                    resG += (nColor.G * kernel[k + rX, l + rY]);
                    resB += (nColor.B * kernel[k + rX, l + rY]);
                }
            resR = (resR + 255) / 2;
            resG = (resG + 255) / 2;
            resB = (resB + 255) / 2;
            return Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255));
        }
        public Color CalcV(Bitmap source, int x, int y, float[,] kernel, float [,] kernel1)
        {
            int rX = kernel.GetLength(0) / 2;
            int rY = kernel.GetLength(1) / 2;
            double resR = 0;
            double resG = 0;
            double resB = 0;
            double resR1 = 0;
            double resG1 = 0;
            double resB1 = 0;
            for (int l = -rY; l <= rY; l++)
                for (int k = -rX; k <= rX; k++)
                {
                    int idX = Clamp(x + k, 0, source.Width - 1);
                    int idY = Clamp(y + l, 0, source.Height - 1);
                    Color nColor = source.GetPixel(idX, idY);
                    resR += nColor.R * kernel[k + rX, l + rY];
                    resG += nColor.G * kernel[k + rX, l + rY];
                    resB += nColor.B * kernel[k + rX, l + rY];
                    resR1 += nColor.R * kernel[l + rY, k + rX];
                    resG1 += nColor.G * kernel[l + rY, k + rX];
                    resB1 += nColor.B * kernel[l + rY, k + rX];
                }
            resR = resR * resR + resR1 * resR1;
            resR = Math.Sqrt(resR);
            return Color.FromArgb(Clamp((int)resR, 0, 255), Clamp((int)resG, 0, 255), Clamp((int)resB, 0, 255));
        }
        private void button1_Click(object sender, EventArgs e) // точечный фильтр
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
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
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void button2_Click(object sender, EventArgs e) // яркость
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
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
            //for (int i = 0; i < sizeX; i++)
            //    for (int j = 0; j < sizeY; j++)
            //    {
            //        kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
            //    }
            kernel[0, 0] = -1;
            kernel[0, 1] = -2;
            kernel[0, 2] = -1;
            kernel[1, 0] = 0;
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;
            kernel[2, 0] = 1;
            kernel[2, 1] = 2;
            kernel[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void сепияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
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
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void полутонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, poluton(invimage.GetPixel(i, j))); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, invert(invimage.GetPixel(i, j))); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            float[,] kernel1 = new float[sizeX, sizeY];
            kernel[0, 0] = -1;
            kernel[0, 1] = -2;
            kernel[0, 2] = -1;
            kernel[1, 0] = 0;
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;
            kernel[2, 0] = 1;
            kernel[2, 1] = 2;
            kernel[2, 2] = 1;

            kernel1[0, 0] = -1;
            kernel1[0, 1] = 0;
            kernel1[0, 2] = 1;
            kernel1[1, 0] = -2;
            kernel1[1, 1] = 0;
            kernel1[1, 2] = 2;
            kernel1[2, 0] = -1;
            kernel1[2, 1] = 0;
            kernel1[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcV(image, i, j, kernel, kernel1));
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void блюрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void собельToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = -1;
            kernel[0, 1] = 0;
            kernel[0, 2] = 1;
            kernel[1, 0] = -2;
            kernel[1, 1] = 0;
            kernel[1, 2] = 2;
            kernel[2, 0] = -1;
            kernel[2, 1] = 0;
            kernel[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 0;
            kernel[0, 1] = -1;
            kernel[0, 2] = 0;
            kernel[1, 0] = -1;
            kernel[1, 1] = 5;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 0;
            kernel[0, 1] = 1;
            kernel[0, 2] = 0;
            kernel[1, 0] = 1;
            kernel[1, 1] = 0;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            ii = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg");
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    ii.SetPixel(i, j, poluton(image.GetPixel(i, j))); // сюда вставлять фильтры
                }
            }
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcT(ii, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void моушенБлюрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 1;
            kernel[0, 1] = 0;
            kernel[0, 2] = 0;
            kernel[1, 0] = 0;
            kernel[1, 1] = 1;
            kernel[1, 2] = 0;
            kernel[2, 0] = 0;
            kernel[2, 1] = 0;
            kernel[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void щаррToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            float[,] kernel1 = new float[sizeX, sizeY];
            kernel[0, 0] = 3;
            kernel[0, 1] = 10;
            kernel[0, 2] = 3;
            kernel[1, 0] = 0;
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;
            kernel[2, 0] = -3;
            kernel[2, 1] = -10;
            kernel[2, 2] = -3;

            kernel1[0, 0] = 3;
            kernel1[0, 1] = 0;
            kernel1[0, 2] = -3;
            kernel1[1, 0] = 10;
            kernel1[1, 1] = 0;
            kernel1[1, 2] = -10;
            kernel1[2, 0] = 3;
            kernel1[2, 1] = 0;
            kernel1[2, 2] = -3;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcV(image, i, j, kernel, kernel1)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void щаррToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 3;
            kernel[0, 1] = 0;
            kernel[0, 2] = -3;
            kernel[1, 0] = 10;
            kernel[1, 1] = 0;
            kernel[1, 2] = -10;
            kernel[2, 0] = 3;
            kernel[2, 1] = 0;
            kernel[2, 2] = -3;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void прюиттToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            float[,] kernel1 = new float[sizeX, sizeY];
            kernel[0, 0] = -1;
            kernel[0, 1] = -1;
            kernel[0, 2] = -1;
            kernel[1, 0] = 0;
            kernel[1, 1] = 0;
            kernel[1, 2] = 0;
            kernel[2, 0] = 1;
            kernel[2, 1] = 1;
            kernel[2, 2] = 1;

            kernel1[0, 0] = -1;
            kernel1[0, 1] = 0;
            kernel1[0, 2] = 1;
            kernel1[1, 0] = -1;
            kernel1[1, 1] = 0;
            kernel1[1, 2] = 1;
            kernel1[2, 0] = -1;
            kernel1[2, 1] = 0;
            kernel1[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcV(image, i, j, kernel, kernel1)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void прюиттToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int sizeX = 3;
            int sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];
            kernel[0, 0] = -1;
            kernel[0, 1] = 0;
            kernel[0, 2] = 1;
            kernel[1, 0] = -1;
            kernel[1, 1] = 0;
            kernel[1, 2] = 1;
            kernel[2, 0] = -1;
            kernel[2, 1] = 0;
            kernel[2, 2] = 1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, CalcM(image, i, j, kernel)); // сюда вставлять фильтры
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда вход";
            label2.Text = "отсюда выход";
        }

        private void сдвигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            int imax = image.Width;
            int jmax = image.Height;
            invimage = new Bitmap(imax, jmax); // собака перед путём обязательно
            for (int j=0; j<jmax; j++)
                for (int i=0; i<imax; i++)
                {
                    invimage.SetPixel(Clamp(i + 10, 0, imax-1), j, image.GetPixel(i, j));
                }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap(@"C:\Users\Tom\Desktop\laba-po-kg\image.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            int imax = image.Width;
            int jmax = image.Height;
            invimage = new Bitmap(imax, jmax); // собака перед путём обязательно
            for (int j = 0; j < jmax; j++)
                for (int i = 0; i < imax; i++)
                {
                    int l = Clamp((int)((i - imax / 2) * Math.Cos(30) - (i - jmax / 2) * Math.Sin(30) + imax), 0, imax-1);
                    int k = Clamp((int)((i - imax / 2) * Math.Sin(30) + (i - jmax / 2) * Math.Cos(30) + jmax), 0, jmax-1);
                    invimage.SetPixel(i, j, image.GetPixel(l, k));
                }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
        }
    }
}