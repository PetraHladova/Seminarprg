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
        bool mouseDown;
        Point lastPosition;
        int colour;
        Pen currentPen;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void red(object sender, EventArgs e)
        {
            colour = 1;
        }

        public void orange(object sender, EventArgs e)
        {
            Pen pen = Pens.DarkOrange;
            Brush brush = Brushes.DarkOrange;
            colour = 2;
        }

        public void yellow(object sender, EventArgs e)
        {
            Pen pen = Pens.Gold;
            Brush brush = Brushes.Gold;
            colour = 3;
        }

        public void Green(object sender, EventArgs e)
        {
            Pen pen = Pens.SeaGreen;
            Brush brush = Brushes.SeaGreen;
            colour = 4;
        }

        public void blue(object sender, EventArgs e)
        {
            Pen pen = Pens.SteelBlue;
            Brush brush = Brushes.SteelBlue;
            colour = 5;
        }

        public void purple(object sender, EventArgs e)
        {
            Pen pen = Pens.DarkSlateBlue;
            Brush brush = Brushes.DarkSlateBlue;
            colour = 7;
        }

        public void pink(object sender, EventArgs e)
        {
            Pen pen = Pens.PaleVioletRed;
            Brush brush = Brushes.PaleVioletRed;
            colour = 8;
        }

        public void black(object sender, EventArgs e)
        {
            Pen pen = Pens.Black;
            Brush brush = Brushes.Black;
            colour = 10;
        }

        public void white(object sender, EventArgs e)
        {
            Pen pen = Pens.White;
            Brush brush = Brushes.White;
            colour = 11;
        }

        public void brown(object sender, EventArgs e)
        {
            Pen pen = Pens.Sienna;
            Brush brush = Brushes.Sienna;
            colour = 9;
        }

        public void draw(object sender, MouseEventArgs e)
        {
            
        }

        public void darkBlue(object sender, EventArgs e)
        {
            Pen pen = Pens.MidnightBlue;
            Brush brush = Brushes.MidnightBlue;
            colour = 6;
        }

        public void Clear(object sender, EventArgs e)
        {
            //g.Clear(Color.White);
        }

        
        private void highlighterDark(object sender, EventArgs e)
        {
            Color darkHighlightorColor = (Color.FromArgb(75, Color.Black));
        }

        private void highlighter(object sender, EventArgs e)
        {
            Color HighlightorColor = (Color.FromArgb(75, Color.Black));
        }

        private void highlighterLight(object sender, EventArgs e)
        {
            Color lightHighlightorColor = (Color.FromArgb(75, Color.Black));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void panel1MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1Draw(object sender, MouseEventArgs e)
        {            
            if (mouseDown == true)
            {
                Pen pen = new Pen(Brushes.Black);
                if (colour == 1)
                {
                    pen.Color = Color.Red;
                }
                else if (colour == 2)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.DarkOrange, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 3)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.Gold, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 4)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.SeaGreen, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 5)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.SteelBlue, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 6)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.MidnightBlue, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 7)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.DarkSlateBlue, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 8)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.PaleVioletRed, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 9)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.Sienna, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 10)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.Black, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else if (colour == 11)
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.White, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                else
                {
                    using (Graphics g = this.CreateGraphics())
                        g.DrawLine(Pens.Black, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawLine(pen, e.Location, lastPosition);
                }
                lastPosition = e.Location;
            }
        }

        private void panel1MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
