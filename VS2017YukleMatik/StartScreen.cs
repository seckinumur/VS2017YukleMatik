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

namespace VS2017YukleMatik
{
    public partial class StartScreen : MaterialForm
    { 
        public StartScreen()
        {
            InitializeComponent();
        }

        private async void StartScreen_Load(object sender, EventArgs e)
        {
                for (int i = 0; i <=100; i++)
                {
                    materialProgressBar1.Value = i;
                    await Task.Delay(10);
                }
            Form1 ac = new Form1();
            ac.Show();
            ac.notifyIcon1.Visible = false;
            this.Hide();
        }
    }
}
