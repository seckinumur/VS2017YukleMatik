using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using VS2017YukleMatik.dll;

namespace VS2017YukleMatik
{
    public partial class Form1 : MaterialForm
    {
        public string Dil1, Dil2, Adress= @"C:\vs2017";
        public bool TekDil=true;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 0;
            this.Height = 70;
            for (int i = 0; i <= 410;)
            {
                this.Width = i;
                await Task.Delay(1);
                i += 10;
            }
            for (int i = 70; i <= 360;)
            {
                this.Height = i;
                await Task.Delay(1);
                i += 10;
            }
            Karsilama.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            Karsilama.Visible = false;
            for (int i = 410; i <= 640;)
            {
                this.Width = i;
                await Task.Delay(1);
                i += 10;
            }
            for (int i = 360; i <= 480;)
            {
                this.Height = i;
                await Task.Delay(1);
                i += 10;
            }
            DilEkrani.Visible = true;
            bunifuCards1.Visible = true;
            Konumat.Text = Konum.Text;
            Dil1 = "en-US ";
        }

        private async void materialFlatButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            while (folderBrowserDialog1.SelectedPath == "C:\\" || folderBrowserDialog1.SelectedPath == "D:\\" || folderBrowserDialog1.SelectedPath == "E:\\" || folderBrowserDialog1.SelectedPath == "F:\\")
            {
                MessageBox.Show("Sadece Sürücülere İndirmeniz Tavsiye Edilmez! \nLütfen Sürücü İçersine Bir Klasör Oluşturmayı Deneyin", "Uyarı!");
                folderBrowserDialog1.ShowDialog();
            }
            Adress = @folderBrowserDialog1.SelectedPath;
            Konum.Text = folderBrowserDialog1.SelectedPath;
            varsayilan.Text = "Özel";
            varsayilan.ForeColor = Color.ForestGreen;
            Konum.ForeColor = Color.ForestGreen;
            for (int i = 0; i <= 100; i++)
            {
                materialProgressBar1.Value = i;
                await Task.Delay(10);
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked == true)
            {
                Ikincidilcombo.Visible = true;
                Ikincidillabel.Visible = true;
                birincidilcombo.selectedIndex = 2;
                TekDilLabel.Text = "İlk İndirilecek Dili Seçin";
                Ikincidillabel.Text = "İkinci İndirilecek dili Seçin";
                Ikincidilcombo.selectedIndex = 11;
                TekDil = false;
                Dil2 = "tr-TR ";
            }
            else
            {
                Ikincidilcombo.Visible = false;
                Ikincidillabel.Visible = false;
                TekDilLabel.Text = "İndirilecek Diliniz";
                birincidilcombo.selectedIndex = 2;
                TekDil = true;
            }
        }

        private void Ikincidilcombo_onItemSelected(object sender, EventArgs e)
        {
            if (Ikincidilcombo.selectedIndex == 0) { Dil2 = "cs-CZ "; }
            else if (Ikincidilcombo.selectedIndex == 1) { Dil2 = "de-DE "; }
            else if (Ikincidilcombo.selectedIndex == 2) { Dil2 = "en-US "; }
            else if (Ikincidilcombo.selectedIndex == 3) { Dil2 = "es-ES "; }
            else if (Ikincidilcombo.selectedIndex == 4) { Dil2 = "fr-FR "; }
            else if (Ikincidilcombo.selectedIndex == 5) { Dil2 = "it-IT "; }
            else if (Ikincidilcombo.selectedIndex == 6) { Dil2 = "ja-JP "; }
            else if (Ikincidilcombo.selectedIndex == 7) { Dil2 = "ko-KR "; }
            else if (Ikincidilcombo.selectedIndex == 8) { Dil2 = "pl-PL "; }
            else if (Ikincidilcombo.selectedIndex == 9) { Dil2 = "pt-BR "; }
            else if (Ikincidilcombo.selectedIndex == 10) { Dil2 = "ru-RU "; }
            else if (Ikincidilcombo.selectedIndex == 11) { Dil2 = "tr-TR "; }
            else if (Ikincidilcombo.selectedIndex == 12) { Dil2 = "zh-CN "; }
            else if (Ikincidilcombo.selectedIndex == 13) { Dil2 = "zh-TW "; }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.seckinumur.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/seckinumur");
        }

        private void materialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            string Komutsistemi;
            for (int i = 0; i <= 100; i++)
            {
                materialProgressBar2.Value = i;
                await Task.Delay(10);
            }
            if (TekDil == true)
            {
                Komutsistemi = @"vs_community.exe --layout " +@Adress + " --lang "+Dil1;
                //NotifyIcon1.ShowBalloonTip(Balonun kalma süresi(milisaniye), "Yazılacak başlık", "Yazılacak açıklama", Gözükecek İcon);
                this.Hide();
                notifyIcon1.ShowBalloonTip(15000, "Visual Studio 2017 İndiricisi Başlatıldı!", "İndirme İşlemi İnternet Bağlantınızın Hızına Göre Değişebilir. \nİndirme İşlemi Bitince Program Otomatik Olarak Kapanacaktır.", ToolTipIcon.Info);
                Komut.KomutCalistir(@Komutsistemi);
                Application.Exit();
            }
            else
            {
                Komutsistemi = @"vs_community.exe --layout " + @Adress + " --lang " + Dil1+Dil2;
                //NotifyIcon1.ShowBalloonTip(Balonun kalma süresi(milisaniye), "Yazılacak başlık", "Yazılacak açıklama", Gözükecek İcon);
                this.Hide();
                notifyIcon1.ShowBalloonTip(15000, "Visual Studio 2017 İndiricisi Başlatıldı!", "İndirme İşlemi İnternet Bağlantınızın Hızına Göre Değişebilir. \nİndirme İşlemi Bitince Program Otomatik Olarak Kapanacaktır.", ToolTipIcon.Info);
                Komut.KomutCalistir(@Komutsistemi);
                Application.Exit();
            }
        }

        private void birincidilcombo_onItemSelected(object sender, EventArgs e)
        {
            if (birincidilcombo.selectedIndex == 0) { Dil1 = "cs-CZ "; }
            else if (birincidilcombo.selectedIndex == 1) { Dil1 = "de-DE "; }
            else if (birincidilcombo.selectedIndex == 2) { Dil1 = "en-US "; }
            else if (birincidilcombo.selectedIndex == 3) { Dil1 = "es-ES "; }
            else if (birincidilcombo.selectedIndex == 4) { Dil1 = "fr-FR "; }
            else if (birincidilcombo.selectedIndex == 5) { Dil1 = "it-IT "; }
            else if (birincidilcombo.selectedIndex == 6) { Dil1 = "ja-JP "; }
            else if (birincidilcombo.selectedIndex == 7) { Dil1 = "ko-KR "; }
            else if (birincidilcombo.selectedIndex == 8) { Dil1 = "pl-PL "; }
            else if (birincidilcombo.selectedIndex == 9) { Dil1 = "pt-BR "; }
            else if (birincidilcombo.selectedIndex == 10) { Dil1 = "ru-RU "; }
            else if (birincidilcombo.selectedIndex == 11) { Dil1 = "tr-TR "; }
            else if (birincidilcombo.selectedIndex == 12) { Dil1 = "zh-CN "; }
            else if (birincidilcombo.selectedIndex == 13) { Dil1 = "zh-TW "; }
        }
    }
}
