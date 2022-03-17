using System;
using System.Drawing;
using System.Windows.Forms;

namespace PixelColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuStrip1.BackColor = BackColor;
            KeyDown += Form1_KeyDown;
            timer1.Interval = 10;
            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point position = MousePosition;
            Color color = ColorPixel.GetColor(position);
            panel1.BackColor = color;

            int val     = ColorPixel.ColorToInt(color);
            uint dec    = ColorPixel.ColorToDec(color);
            string hex  = ColorPixel.ColorToHex(color);
            string name = ColorPixel.GetNameByHex(hex);

            label1.Text = string.Format("X = {0} Y = {1}\nName = {2}\nR = {3}\nG = {4}\nB = {5}\nHEX = {6}\nINT  = {7}\nDEC = {8}",
                position.X, position.Y, name, color.R, color.G, color.B, hex, val, dec);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                ColorPixel.AddColors(fileName);
            }
        }
    }
}