using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace картинки
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap originalImage;
        Bitmap currentImage;
        private void button3_Click(object sender, EventArgs e)
        {
            // показать диалоговое окно для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // загрузить выбранный файл как изображение
                originalImage = new Bitmap(openFileDialog.FileName);
                currentImage = originalImage;

                // отобразить исходное изображение в PictureBox
                pictureBox1.Image = originalImage;
            }
        }




        private Bitmap ConvertToGray(Bitmap original)
        {
            int width = original.Width;
            int height = original.Height;

            Bitmap grayImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(grayImage);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
            new float[] {0.299f, 0.299f, 0.299f, 0, 0},
            new float[] {0.587f, 0.587f, 0.587f, 0, 0},
            new float[] {0.114f, 0.114f, 0.114f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
                });

            using (ImageAttributes attributes = new ImageAttributes())
            {
                attributes.SetColorMatrix(colorMatrix);
                graphics.DrawImage(original, new Rectangle(0, 0, width, height),
                    0, 0, width, height, GraphicsUnit.Pixel, attributes);
            }

            graphics.Dispose();

            return grayImage;
        }




        public Bitmap ConvertToRed(Bitmap original)
        {
            // создать новое изображение той же ширины и высоты
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            // проход по каждому пикселю исходного изображения
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);

                    // вычислить оттенок красного
                    int redValue = originalColor.R;
                    Color newColor = Color.FromArgb(redValue, 0, 0);

                    // установка нового цвета пикселя в новом изображении
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }

        public Bitmap ConvertToBlue(Bitmap original)
        {
            // создать новое изображение той же ширины и высоты
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            // проход по каждому пикселю исходного изображения
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);

                    // вычислить оттенок синего
                    int blueValue = originalColor.B;
                    Color newColor = Color.FromArgb(0, 0, blueValue);

                    // установка нового цвета пикселя в новом изображении
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }


        public Bitmap ConvertToGreen(Bitmap original)
        {
            // создать новое изображение той же ширины и высоты
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            // проход по каждому пикселю исходного изображения
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);

                    // вычислить оттенок зеленого
                    int greenValue = originalColor.G;
                    Color newColor = Color.FromArgb(0, greenValue, 0);

                    // установка нового цвета пикселя в новом изображении
                    newImage.SetPixel(i, j, newColor);
                }
            }

            return newImage;
        }







        private void button4_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                // преобразовать изображение в оттенки серого
                Bitmap grayImage = ConvertToGray(currentImage);
                currentImage = grayImage;

                // отобразить новое изображение в PictureBox
                pictureBox1.Image = grayImage;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                currentImage = originalImage;
                pictureBox1.Image = originalImage;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                // преобразовать изображение в оттенок красного
                Bitmap redImage = ConvertToRed(currentImage);
                currentImage = redImage;

                // отобразить новое изображение в PictureBox
                pictureBox1.Image = redImage;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                // преобразовать изображение в оттенок синего
                Bitmap blueImage = ConvertToBlue(currentImage);
                currentImage = blueImage;

                // отобразить новое изображение в PictureBox
                pictureBox1.Image = blueImage;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                if (currentImage != null)
                {
                    // преобразовать изображение в оттенок зеленого
                    Bitmap greenImage = ConvertToGreen(currentImage);
                    currentImage = greenImage;

                    // отобразить новое изображение в PictureBox
                    pictureBox1.Image = greenImage;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // сохраняем изображение в том же формате файла, в котором оно было открыто
                    currentImage.Save(saveFileDialog.FileName, currentImage.RawFormat);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}


