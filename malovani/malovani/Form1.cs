using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malovani
{
    public partial class Form1 : Form
    {
        Graphics g;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void red(object sender, EventArgs e)
        {
            Pen pen = Pens.Red;
            Brush brush = Brushes.Red;
        }

        private void orange(object sender, EventArgs e)
        {
            Pen pen = Pens.DarkOrange;
            Brush brush = Brushes.DarkOrange;
        }

        private void yellow(object sender, EventArgs e)
        {
            Pen pen = Pens.Gold;
            Brush brush = Brushes.Gold;
        }

        private void Green(object sender, EventArgs e)
        {
            Pen pen = Pens.SeaGreen;
            Brush brush = Brushes.SeaGreen;
        }

        private void blue(object sender, EventArgs e)
        {
            Pen pen = Pens.SteelBlue;
            Brush brush = Brushes.SteelBlue;
        }

        private void purple(object sender, EventArgs e)
        {
            Pen pen = Pens.DarkSlateBlue;
            Brush brush = Brushes.DarkSlateBlue;
        }

        private void pink(object sender, EventArgs e)
        {
            Pen pen = Pens.PaleVioletRed;
            Brush brush = Brushes.PaleVioletRed;
        }

        private void black(object sender, EventArgs e)
        {
            Pen pen = Pens.Black;
            Brush brush = Brushes.Black;
        }

        private void white(object sender, EventArgs e)
        {
            Pen pen = Pens.White;
            Brush brush = Brushes.White;
        }

        private void brown(object sender, EventArgs e)
        {
            Pen pen = Pens.Sienna;
            Brush brush = Brushes.Sienna;
        }

        private void draw(object sender, MouseEventArgs e)
        {
            
        }

        private void darkBlue(object sender, EventArgs e)
        {
            Pen pen = Pens.MidnightBlue;
            Brush brush = Brushes.MidnightBlue;
        }

        private void Clear(object sender, EventArgs e)
        {

        }

        private void Draw(object sender, MouseEventArgs e)
        {
            Point lastPosition;
            bool isDrawing = true;
            lastPosition = e.Location;
        }

        private void drawmouse(object sender, MouseEventArgs e)
        {
            Point lastPosition;
            lastPosition = e.Location;
            g.DrawLine(Pens.Black, e.Location, lastPosition);
        }
    }
}
