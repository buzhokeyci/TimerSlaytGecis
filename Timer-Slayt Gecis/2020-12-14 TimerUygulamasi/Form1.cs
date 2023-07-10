using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_12_14_TimerUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer sadece ekleme ve olayını oluşturma ile çalışmaya başlamaz. Bu işlemleri yaptıktan sonra başla demek zorundasınız.
            //Tick anında yazılan kodları, belirtilen sürede bir çalıştırır.
            //MessageBox.Show("Test");

            int index = rnd.Next(0, imgList.Images.Count);

            pcbPicture.Image = imgList.Images[index];

            pcbPicture.Tag = index;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.Text = "Timer = Aktif";
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            //timer1.Enabled
            if (timer1.Enabled)
            {
                timer1.Stop();
                this.Text = "Timer = Pasif";
            }
            else
            {
                timer1.Start();
                this.Text = "Timer = Aktif";
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
            pcbPicture.Image = imgList.Images[0];
            pcbPicture.Tag = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
            pcbPicture.Image = imgList.Images[imgList.Images.Count - 1];
            pcbPicture.Tag = imgList.Images.Count - 1;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) // eğer timer çalışıyosa bu resmi değiştirecektir. biz değiştirmesin son atacağımız resim ekranda kalsın istiyoruz. bu nedenle timer çalışıyorsa durduralım
                timer1.Stop();

            int sonResminIndexi = Convert.ToInt32(pcbPicture.Tag);
            sonResminIndexi--;

            if (Math.Sign(sonResminIndexi) == -1)
                sonResminIndexi = imgList.Images.Count - 1;

            pcbPicture.Image = imgList.Images[sonResminIndexi];

            pcbPicture.Tag = sonResminIndexi;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(pcbPicture.Tag);
            index++;

            if (index == imgList.Images.Count)
                index = 0;

            pcbPicture.Image = imgList.Images[index];

            pcbPicture.Tag = index;
        }

        private void pcbPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
