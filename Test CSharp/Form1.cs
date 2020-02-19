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

        public Int32 Clamp(Int32 a, Int32 min, Int32 max)
        {
            Int32 res = a;
            if (a < min) res = min;
            else if (a > max) res = max;
            return res;
        }

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
        // увеличить яркость // работает по дэбильному
        public Color increse(Color c, int inc)
        {
            return Color.FromArgb(c.A, Clamp(c.R + inc, 0, 255), Clamp(c.G + inc, 0, 255), Clamp(c.B + inc, 0, 255));
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
    }
}