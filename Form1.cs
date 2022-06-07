using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // do rysowania 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // aby móc pobierac informajce z okienka wyskakującego


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
            int radius = 0;

            string message = "Please give me the radius:", title = "Taking data", defaultValue = "For example 1";
            object myValue;

            whiteboard.Image = null; // czysczenie textboxa

            myValue = Interaction.InputBox(message, title, defaultValue);
            if ((string)myValue == "")
            {
                myValue = defaultValue;
                Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
            }
            else
            {
                string stringMyValue = (string)myValue;

                // sprawdzam czy podana wartosc jest intem
                for (int i = 0; i < stringMyValue.Length; i++)
                    if (stringMyValue[i] < 48 || stringMyValue[i] > 57)
                    {
                        Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1. Fisrt letter of error in: " + stringMyValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                        Environment.Exit(1);
                    }

                radius = Int32.Parse(myValue.ToString()); // konwertuje z stringa do int i przypisuje do wartosci radius
            }

            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            g.DrawEllipse(pen, 100, 100, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            Point[] points = new Point[] { new Point { X = 100, Y = 100 }, new Point { X = 40, Y = 60 }, new Point { X = 60, Y = 140 } }; // ustawianie wierzchołków trójkąta
            g.DrawPolygon(pen, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki)
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            whiteboard.Image = null;
        }

        private void Parallelogram_Click(object sender, EventArgs e)
        {
            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
            Point[] points = new Point[] { new Point { X = 100, Y = 100 }, new Point { X = 120, Y = 50 }, new Point { X = 190, Y = 50 }, new Point { X = 170, Y = 100 } }; // ustawianie wierzchołków równoległoboku
            g.DrawPolygon(pen, points); // rysowanie wielokąta (w tym przypadku równoległobok bo 4 wierzchołki)
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
