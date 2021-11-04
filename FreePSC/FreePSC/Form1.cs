using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FreePSC
{
    public partial class Form1 : Form
    {
        #region poruszanie oknem
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.BackColor = Color.White;
            Form2 regulamin = new Form2();
            regulamin.ShowDialog();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            progressBar1.Value = 0;
            textBox1.Text = "";

            if(checkBox1.Checked == true)
            {
                GenerowanieTimer.Start();
            }else
            {
                checkBox1.BackColor = Color.IndianRed;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void GenerowanieTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            
            if(progressBar1.Value >= 100)
            {
                GenerowanieTimer.Stop();
                string output = "";
                int number;
                Random rnd = new Random();

                for(int i = 0; i <= 16; i++)
                {
                    number = rnd.Next(0,9);
                    output += number.ToString();
                }
                textBox1.Text = output;
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "proszę przeczytać punkt 16 z regulaminu";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tiktok.com/@youngdevpl?");
        }
    }
}
