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
        
        // инверсия цвета       я хз почему так функция пишется
        public Color invert(Color c) => Color.FromArgb(c.A, 0xFF - c.R, 0xFF - c.G, 0xFF - c.B);
        public Color poluton(Color c) => Color.FromArgb(c.A, (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B), (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B), (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B));
        public Color sepia(Color c)
        {
            Int32 intensity = (Int32)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
            int k = Math.Clamp(4, 1, 3);
            Int32 R = (Int32)((0.299 * c.R + 0.587 * c.G + 0.114 * c.B) * k);
            return Color.FromArgb(c.A, 0xFF - c.R, 0xFF - c.G, 0xFF - c.B);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            image = new Bitmap(@"E:\Cats\cat-art-images-wallpaper.jpg"); // полный путь до картинки
            pictureBox1.Image = image;
            invimage = new Bitmap(@"E:\Cats\cat-art-images-wallpaper.jpg"); // собака перед путём обязательно
            int imax = image.Width;
            int jmax = image.Height;
            for (int j = 0; j < jmax; j++)
            {
                for (int i = 0; i < imax; i++)
                {
                    invimage.SetPixel(i, j, poluton(invimage.GetPixel(i, j)));
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = invimage;
            label1.Text = "сюда лут";
        }
    }
}
