using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malovani1
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool mouseDown;
        Point lastPosition;
        int colour;
        Pen currentPen;
        bool deafultPen;
        bool darkHighlighter;
        bool mediumHighlighter;
        bool lightHighlighter;
        bool airbrush;
        bool erasor;
        bool sharpPen;
        int brushSize = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Red(object sender, EventArgs e)
        {
            colour = 1;
        }

        private void Orange(object sender, EventArgs e)
        {
            colour = 2;
        }

        private void Yellow(object sender, EventArgs e)
        {
            colour = 3;
        }

        private void Green(object sender, EventArgs e)
        {
            colour = 4;
        }

        private void LightBlue(object sender, EventArgs e)
        {
            colour = 5;
        }

        private void DarkBlue(object sender, EventArgs e)
        {
            colour = 6;
        }

        private void Purple(object sender, EventArgs e)
        {
            colour = 7;
        }

        private void Pink(object sender, EventArgs e)
        {
            colour = 8;
        }

        private void Brown(object sender, EventArgs e)
        {
            colour = 9;
        }

        private void Black(object sender, EventArgs e)
        {
            colour = 10;
        }

        private void Gray(object sender, EventArgs e)
        {
            colour = 11;
        }

        private void White(object sender, EventArgs e)
        {
            colour = 12;
        }

        private void panel1MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastPosition = e.Location;
        }

        private void panel1MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1Draw(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                if (darkHighlighter == true)
                {
                    Pen darkHighlightor = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Red));
                    }
                    else if (colour == 2)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.DarkOrange));
                    }
                    else if (colour == 3)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Gold));
                    }
                    else if (colour == 4)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.SeaGreen));
                    }
                    else if (colour == 5)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.SteelBlue));
                    }
                    else if (colour == 6)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.MidnightBlue));
                    }
                    else if (colour == 7)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.DarkSlateBlue));
                    }
                    else if (colour == 8)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.PaleVioletRed));
                    }
                    else if (colour == 9)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Sienna));
                    }
                    else if (colour == 10)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Black));
                    }
                    else if (colour == 11)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Gray));
                    }
                    else if (colour == 12)
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.White));
                    }
                    else
                    {
                        darkHighlightor.Color = (Color.FromArgb(75, Color.Black));
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(darkHighlightor, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(darkHighlightor.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
                else if (deafultPen == true)
                {
                    Pen pen = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        pen.Color = Color.Red;
                    }
                    else if (colour == 2)
                    {
                        pen.Color = Color.DarkOrange;
                    }
                    else if (colour == 3)
                    {
                        pen.Color = Color.Gold;
                    }
                    else if (colour == 4)
                    {
                        pen.Color = Color.SeaGreen;
                    }
                    else if (colour == 5)
                    {
                        pen.Color = Color.SteelBlue;
                    }
                    else if (colour == 6)
                    {
                        pen.Color = Color.MidnightBlue;
                    }
                    else if (colour == 7)
                    {
                        pen.Color = Color.DarkSlateBlue;
                    }
                    else if (colour == 8)
                    {
                        pen.Color = Color.PaleVioletRed;
                    }
                    else if (colour == 9)
                    {
                        pen.Color = Color.Sienna;
                    }
                    else if (colour == 10)
                    {
                        pen.Color = Color.Black;
                    }
                    else if (colour == 11)
                    {
                        pen.Color = Color.Gray;
                    }
                    else if (colour == 12)
                    {
                        pen.Color = Color.White;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(pen, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(pen.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
                else if (mediumHighlighter == true)
                {
                    Pen highlightor = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Red));
                    }
                    else if (colour == 2)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.DarkOrange));
                    }
                    else if (colour == 3)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Gold));
                    }
                    else if (colour == 4)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.SeaGreen));
                    }
                    else if (colour == 5)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.SteelBlue));
                    }
                    else if (colour == 6)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.MidnightBlue));
                    }
                    else if (colour == 7)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.DarkSlateBlue));
                    }
                    else if (colour == 8)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.PaleVioletRed));
                    }
                    else if (colour == 9)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Sienna));
                    }
                    else if (colour == 10)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Black));
                    }
                    else if (colour == 11)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Gray));
                    }
                    else if (colour == 12)
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.White));
                    }
                    else
                    {
                        highlightor.Color = (Color.FromArgb(50, Color.Black));
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(highlightor, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(highlightor.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
                else if (lightHighlighter == true)
                {
                    Pen lightHighlightor = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Red));
                    }
                    else if (colour == 2)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.DarkOrange));
                    }
                    else if (colour == 3)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Gold));
                    }
                    else if (colour == 4)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.SeaGreen));
                    }
                    else if (colour == 5)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.SteelBlue));
                    }
                    else if (colour == 6)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.MidnightBlue));
                    }
                    else if (colour == 7)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.DarkSlateBlue));
                    }
                    else if (colour == 8)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.PaleVioletRed));
                    }
                    else if (colour == 9)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Sienna));
                    }
                    else if (colour == 10)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Black));
                    }
                    else if (colour == 11)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Gray));
                    }
                    else if (colour == 12)
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.White));
                    }
                    else
                    {
                        lightHighlightor.Color = (Color.FromArgb(25, Color.Black));
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(lightHighlightor, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(lightHighlightor.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
                else if (airbrush == true)
                {
                    Pen airbrush1 = new Pen(Brushes.Black, brushSize / 4);
                    Pen airbrush2 = new Pen(Brushes.Black, brushSize / 2);
                    Pen airbrush3 = new Pen(Brushes.Black, (brushSize / 4) * 3);
                    Pen airbrush4 = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        airbrush1.Color = Color.Red;
                        airbrush2.Color = (Color.FromArgb(75, Color.Red));
                        airbrush3.Color = (Color.FromArgb(50, Color.Red));
                        airbrush4.Color = (Color.FromArgb(25, Color.Red));
                    }
                    else if (colour == 2)
                    {
                        airbrush1.Color = Color.DarkOrange;
                        airbrush2.Color = (Color.FromArgb(75, Color.DarkOrange));
                        airbrush3.Color = (Color.FromArgb(50, Color.DarkOrange));
                        airbrush4.Color = (Color.FromArgb(25, Color.DarkOrange));
                    }
                    else if (colour == 3)
                    {
                        airbrush1.Color = Color.Gold;
                        airbrush2.Color = (Color.FromArgb(75, Color.Gold));
                        airbrush3.Color = (Color.FromArgb(50, Color.Gold));
                        airbrush4.Color = (Color.FromArgb(25, Color.Gold));
                    }
                    else if (colour == 4)
                    {
                        airbrush1.Color = Color.SeaGreen;
                        airbrush2.Color = (Color.FromArgb(75, Color.SeaGreen));
                        airbrush3.Color = (Color.FromArgb(50, Color.SeaGreen));
                        airbrush4.Color = (Color.FromArgb(25, Color.SeaGreen));
                    }
                    else if (colour == 5)
                    {
                        airbrush1.Color = Color.SteelBlue;
                        airbrush2.Color = (Color.FromArgb(75, Color.SteelBlue));
                        airbrush3.Color = (Color.FromArgb(50, Color.SteelBlue));
                        airbrush4.Color = (Color.FromArgb(25, Color.SteelBlue));
                    }
                    else if (colour == 6)
                    {
                        airbrush1.Color = Color.MidnightBlue;
                        airbrush2.Color = (Color.FromArgb(75, Color.MidnightBlue));
                        airbrush3.Color = (Color.FromArgb(50, Color.MidnightBlue));
                        airbrush4.Color = (Color.FromArgb(25, Color.MidnightBlue));
                    }
                    else if (colour == 7)
                    {
                        airbrush1.Color = Color.DarkSlateBlue;
                        airbrush2.Color = (Color.FromArgb(75, Color.DarkSlateBlue));
                        airbrush3.Color = (Color.FromArgb(50, Color.DarkSlateBlue));
                        airbrush4.Color = (Color.FromArgb(25, Color.DarkSlateBlue));
                    }
                    else if (colour == 8)
                    {
                        airbrush1.Color = Color.PaleVioletRed;
                        airbrush2.Color = (Color.FromArgb(75, Color.PaleVioletRed));
                        airbrush3.Color = (Color.FromArgb(50, Color.PaleVioletRed));
                        airbrush4.Color = (Color.FromArgb(25, Color.PaleVioletRed));
                    }
                    else if (colour == 9)
                    {
                        airbrush1.Color = Color.Sienna;
                        airbrush2.Color = (Color.FromArgb(75, Color.Sienna));
                        airbrush3.Color = (Color.FromArgb(50, Color.Sienna));
                        airbrush4.Color = (Color.FromArgb(25, Color.Sienna));
                    }
                    else if (colour == 10)
                    {
                        airbrush1.Color = Color.Black;
                        airbrush2.Color = (Color.FromArgb(75, Color.Black));
                        airbrush3.Color = (Color.FromArgb(50, Color.Black));
                        airbrush4.Color = (Color.FromArgb(25, Color.Black));
                    }
                    else if (colour == 11)
                    {
                        airbrush1.Color = Color.Gray;
                        airbrush2.Color = (Color.FromArgb(75, Color.Gray));
                        airbrush3.Color = (Color.FromArgb(50, Color.Gray));
                        airbrush4.Color = (Color.FromArgb(25, Color.Gray));
                    }
                    else if (colour == 12)
                    {
                        airbrush1.Color = Color.White;
                        airbrush2.Color = (Color.FromArgb(75, Color.White));
                        airbrush3.Color = (Color.FromArgb(50, Color.White));
                        airbrush4.Color = (Color.FromArgb(25, Color.White));
                    }
                    else
                    {
                        airbrush1.Color = Color.Black;
                        airbrush2.Color = (Color.FromArgb(75, Color.Black));
                        airbrush3.Color = (Color.FromArgb(50, Color.Black));
                        airbrush4.Color = (Color.FromArgb(25, Color.Black));
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(airbrush1, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(airbrush1.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                        g.DrawLine(airbrush2, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(airbrush2.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize + 5, brushSize + 5);
                        g.DrawLine(airbrush2, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(airbrush3.Color), e.X - brushSize / 2, e.Y - brushSize, brushSize + 10, brushSize + 10);
                        g.DrawLine(airbrush2, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(airbrush4.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize + 15, brushSize + 15);
                    }
                    lastPosition = e.Location;
                }
                else if (sharpPen == true)
                {
                    Pen penSharp = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        penSharp.Color = Color.Red;
                    }
                    else if (colour == 2)
                    {
                        penSharp.Color = Color.DarkOrange;
                    }
                    else if (colour == 3)
                    {
                        penSharp.Color = Color.Gold;
                    }
                    else if (colour == 4)
                    {
                        penSharp.Color = Color.SeaGreen;
                    }
                    else if (colour == 5)
                    {
                        penSharp.Color = Color.SteelBlue;
                    }
                    else if (colour == 6)
                    {
                        penSharp.Color = Color.MidnightBlue;
                    }
                    else if (colour == 7)
                    {
                        penSharp.Color = Color.DarkSlateBlue;
                    }
                    else if (colour == 8)
                    {
                        penSharp.Color = Color.PaleVioletRed;
                    }
                    else if (colour == 9)
                    {
                        penSharp.Color = Color.Sienna;
                    }
                    else if (colour == 10)
                    {
                        penSharp.Color = Color.Black;
                    }
                    else if (colour == 11)
                    {
                        penSharp.Color = Color.Gray;
                    }
                    else if (colour == 12)
                    {
                        penSharp.Color = Color.White;
                    }
                    else
                    {
                        penSharp.Color = Color.Black;
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        penSharp.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
                        penSharp.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;
                        g.DrawLine(penSharp, e.Location, lastPosition);
                    }
                    lastPosition = e.Location;
                }
                else if (erasor == true)
                {
                    Pen erasor = new Pen(panel1.BackColor, brushSize);
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(erasor, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(panel1.BackColor), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
                else
                {
                    Pen pen = new Pen(Brushes.Black, brushSize);
                    if (colour == 1)
                    {
                        pen.Color = Color.Red;
                    }
                    else if (colour == 2)
                    {
                        pen.Color = Color.DarkOrange;
                    }
                    else if (colour == 3)
                    {
                        pen.Color = Color.Gold;
                    }
                    else if (colour == 4)
                    {
                        pen.Color = Color.SeaGreen;
                    }
                    else if (colour == 5)
                    {
                        pen.Color = Color.SteelBlue;
                    }
                    else if (colour == 6)
                    {
                        pen.Color = Color.MidnightBlue;
                    }
                    else if (colour == 7)
                    {
                        pen.Color = Color.DarkSlateBlue;
                    }
                    else if (colour == 8)
                    {
                        pen.Color = Color.PaleVioletRed;
                    }
                    else if (colour == 9)
                    {
                        pen.Color = Color.Sienna;
                    }
                    else if (colour == 10)
                    {
                        pen.Color = Color.Black;
                    }
                    else if (colour == 11)
                    {
                        pen.Color = Color.Gray;
                    }
                    else if (colour == 12)
                    {
                        pen.Color = Color.White;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                    }
                    using (Graphics g = panel1.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(pen, e.Location, lastPosition);
                        g.FillEllipse(new SolidBrush(pen.Color), e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                    lastPosition = e.Location;
                }
            }
        }

        private void Clear(object sender, MouseEventArgs e)
        {
            panel1.Invalidate();
            panel1.Update();
        }

        private void highlighterDark(object sender, EventArgs e)
        {
            darkHighlighter = true;
            mediumHighlighter = false;
            lightHighlighter = false;
            deafultPen = false;
            airbrush = false;
            erasor = false;
            sharpPen = false;
        }

        private void highlighter(object sender, EventArgs e)
        {
            mediumHighlighter = true;
            darkHighlighter = false;
            lightHighlighter = false;
            deafultPen = false;
            airbrush = false;
            erasor = false;
            sharpPen = false;
        }

        private void highlighterLight(object sender, EventArgs e)
        {
            lightHighlighter = true;
            darkHighlighter = false;
            mediumHighlighter = false;
            deafultPen = false;
            airbrush = false;
            erasor = false;
            sharpPen = false;
        }

        private void Pen(object sender, EventArgs e)
        {
            deafultPen = true;
            darkHighlighter = false;
            mediumHighlighter = false;
            lightHighlighter = false;
            airbrush = false;
            erasor = false;
            sharpPen = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            brushSize = trackBar1.Value;
        }

        private void Erasor(object sender, EventArgs e)
        {
            erasor = true;
            deafultPen = false;
            darkHighlighter = false;
            mediumHighlighter = false;
            lightHighlighter = false;
            airbrush = false;
            sharpPen = false;
        }

        private void BackGround(object sender, EventArgs e)
        {
            if (colour == 1)
            {
                panel1.BackColor = Color.Red;
            }
            else if (colour == 2)
            {
                panel1.BackColor = Color.DarkOrange;
            }
            else if (colour == 3)
            {
                panel1.BackColor = Color.Gold;
            }
            else if (colour == 4)
            {
                panel1.BackColor = Color.SeaGreen;
            }
            else if (colour == 5)
            {
                panel1.BackColor = Color.SteelBlue;
            }
            else if (colour == 6)
            {
                panel1.BackColor = Color.MidnightBlue;
            }
            else if (colour == 7)
            {
                panel1.BackColor = Color.DarkSlateBlue;
            }
            else if (colour == 8)
            {
                panel1.BackColor = Color.PaleVioletRed;
            }
            else if (colour == 9)
            {
                panel1.BackColor = Color.Sienna;
            }
            else if (colour == 10)
            {
                panel1.BackColor = Color.Black;
            }
            else if (colour == 11)
            {
                panel1.BackColor = Color.Gray;
            }
            else if (colour == 12)
            {
                panel1.BackColor = Color.White;
            }
            else
            {
                panel1.BackColor = Color.White;
            }
        }

        private void Airbrush(object sender, EventArgs e)
        {
            airbrush = true;
            deafultPen = false;
            darkHighlighter = false;
            mediumHighlighter = false;
            lightHighlighter = false;
            erasor = false;
            sharpPen = false;
        }

        private void PenPointy(object sender, EventArgs e)
        {
            sharpPen = true;
            airbrush = false;
            deafultPen = false;
            darkHighlighter = false;
            mediumHighlighter = false;
            lightHighlighter = false;
            erasor = false;
        }
    }
}

//Zdroje
//ChatGPT (nevěděla jsem si rady, proč mi něco nefunguje lol)

