using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureSpike
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"M:\Desktop\år2\SystemProgramvaruutveckling\Diving B&W versions\101 (a).jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = Image.FromFile(@"M:\Desktop\år2\SystemProgramvaruutveckling\divingpictures_small\" + textBox1.Text + ".jpg");
            pictureBox1.Image = image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klicka ej");
            return;

            const string filepath = @"M:\Desktop\år2\SystemProgramvaruutveckling\divingpictures\";
            var directory = new DirectoryInfo(filepath);

            foreach (var file in directory.GetFiles("*.jpg"))
            {
                var image = resizeImage(Image.FromFile(file.FullName), new Size(395, 621));
                image.Save(@"M:\Desktop\år2\SystemProgramvaruutveckling\divingpictures_small\" + file.Name);
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
