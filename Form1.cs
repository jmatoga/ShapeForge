using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // do rysowania 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjektOkienkowy
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g; // tworzenie zmiennej Grapihics do rysowania 
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Aqua, 3); // tworzenie dlugopisa do rysowania 
        public Form1()
        {
            InitializeComponent(); // to sie robi samo - metoda wymagana do obsługi projektanta 
        }

        private void Circle_click(object sender, EventArgs e)
        {
            
            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            g.DrawEllipse(pen, 100, 100, 200, 200);

        }

        private void Triangle_Click(object sender, EventArgs e)
        {

           
            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            Point[] points = new Point[] { new Point { X = 100, Y = 100 }, new Point { X = 40, Y = 60 }, new Point { X = 60, Y = 140 } };
            g.DrawPolygon(pen, points);
            

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            
            whiteboard.Image = null;
        }

        private void Parallelogram_Click(object sender, EventArgs e)
        {
            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            Point[] points = new Point[] { new Point { X = 100, Y = 100 }, new Point { X = 120, Y = 50 }, new Point { X = 190, Y = 50 }, new Point { X = 170, Y = 100 } };
            g.DrawPolygon(pen, points);
        }

        private void Complex_Click(object sender, EventArgs e)
        {
            
            Form2 complex_shape_window = new Form2();
            complex_shape_window.Show();
            this.Hide();
        }

        private void whiteboard_Click(object sender, EventArgs e)
        {

        }
    }
}
