using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oyun
{
    public partial class Form1 : Form
    {
        string[] harfler = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "İ", "Ç", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };
     
        List<Tuple<string, int>> puanlar = new List<Tuple<string, int>>();

        int saniye = 0;
        bool harfSecildi = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnl_txt.Enabled = false;
            timer1.Interval = 1000;
           // YeniHarfSec();
        }

        private void YeniHarfSec()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(harfler.Length);
            label1.Text = harfler[sayi];
            harfSecildi = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            YeniHarfSec();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (saniye < 60)
            {
                if (harfSecildi)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Harf seçilmedi");
                   
                   
                }
                
            }
            
            else
            {
                MessageBox.Show("Zaman doldu! Yeniden başlamak için harf seçin.");
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            pnl_txt.Enabled = true;
            label2.Text = "Zaman : " + saniye.ToString();
            if (saniye == 60)
            {
                timer1.Enabled = false;
                pnl_txt.Enabled = false;
                label1.Text = "";
                saniye = 0;
                harfSecildi = false;
                MessageBox.Show("Zaman Bitti!");
                // Süre dolduğunda "Kontrol Et" butonuna otomatik olarak tıklanmış gibi davran
                button3_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Zamanı sıfırla
            saniye = 0;
            label2.Text = "Zaman : " + saniye.ToString();

            // Harf seçilmedi uyarısı ver
            if (!harfSecildi)
            {
                MessageBox.Show("Harf seçilmedi");
                return;
            }

            // Puan hesapla ve göster
            timer1.Enabled = false;
            pnl_txt.Enabled = false;

            string harf = label1.Text.ToUpper();
            int puan = 0;

            if (textBox1.Text.ToUpper().StartsWith(harf) && textBox1.Text.Length > 0) { puan += 10; }
            if (textBox2.Text.ToUpper().StartsWith(harf) && textBox2.Text.Length > 0) { puan += 10; }
            if (textBox3.Text.ToUpper().StartsWith(harf) && textBox3.Text.Length > 0) { puan += 10; }
            if (textBox4.Text.ToUpper().StartsWith(harf) && textBox4.Text.Length > 0) { puan += 10; }
            if (textBox5.Text.ToUpper().StartsWith(harf) && textBox5.Text.Length > 0) { puan += 10; }
            if (textBox6.Text.ToUpper().StartsWith(harf) && textBox6.Text.Length > 0) { puan += 10; }

            MessageBox.Show("Puanınız: " + puan.ToString());
            MessageBox.Show("Lütfen harf değiştirip devam ediniz");
            label9.Text = " Toplam Puan : " + puan.ToString();
            puanlar.Add(new Tuple<string, int>(harf, puan));
            GuncellePuanlar();

            Temizle();
        }

        private void GuncellePuanlar()
        {
            listBox1.Items.Clear();
            int toplamPuan = 0;
            foreach (var puan in puanlar)
            {
                listBox1.Items.Add("Harf: " + puan.Item1 + ", Puan: " + puan.Item2);
                toplamPuan += puan.Item2;
            }
            label9.Text = "Toplam Puan : " + toplamPuan.ToString();
        }


        private void Temizle()
        {
            foreach (TextBox textBox in pnl_txt.Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }
        }

       

      
    }
}
