using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Bitmap image;
               public Form1()
        {
            InitializeComponent();
        }


        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All Files (*.*) | *.*";
           
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();

            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void полутоновыйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new IncreaseBrightness();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void фильтрПовышающийРезкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpenFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void волны2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves1();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void эффектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TurningFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щаррToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void пьрюиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PruittFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.Png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayWorld filter = new GrayWorld();
            Bitmap resultImage = filter.processImage(image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();

        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PerfectReflector filter = new PerfectReflector();
           Bitmap resultImage = filter.processImage(image);
           pictureBox1.Image = resultImage;
           pictureBox1.Refresh();
        }

        private void линейноеРастяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            gist filter = new gist();
            Bitmap resultImage = filter.processimage(image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
           
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new opening();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new closing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlackHat();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TopHat();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedianFilter filter = new MedianFilter();
            Bitmap resultImage = filter.create_new_bitmap(7, image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
    }
}
