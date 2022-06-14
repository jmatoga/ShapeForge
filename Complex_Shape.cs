using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // aby móc pobierac informajce z okienka wyskakującego
using System.Runtime.InteropServices; // aby móc wyświetlić konsole !!! (trzeba włączyć narzędzia->opcje->debuggowanie->użyj zarządzanego trybu zgodności) jest to forma przestarzała ale inaczej nie działa Console.WriteLine


namespace ProjektOkienkowy
{
    public partial class Complex_Shape : Form //tworzenie drugiego okienka complex shape
    {
        // aby utworzyć konsole
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        //dlugopisy do rysowania
        private System.Drawing.Graphics g; // tworzenie zmiennej Grapihics do rysowania 
        public int count = 5;//licznik ile pozostało figur do narysowania - 5 bo ma być maksymalnie 5 figur
        private System.Drawing.Pen pen_circle = new System.Drawing.Pen(Color.Aquamarine, 3); // tworzenie dlugopisa do rysowania 
        private System.Drawing.Pen pen_triangle = new System.Drawing.Pen(Color.Purple, 3); // tworzenie dlugopisa do rysowania 
        private System.Drawing.Pen pen_figure = new System.Drawing.Pen(Color.LimeGreen, 3); // tworzenie dlugopisa do rysowania 
        int new_beginning_x = 0;//zeby byly obok siebie nowy poczatek wspolrzednej
        int new_beginning_y = 0;//nowy pozatek dla y
        int ifClicked = 0;//licznik do ile razy klikniete byl guzik

        public Complex_Shape()
        {
            InitializeComponent();
        }

        private void back_button_click(object sender, EventArgs e)
        {
            Simple_Shape back_to_Simple_Shape = new Simple_Shape();
            back_to_Simple_Shape.Show();
            this.Hide();
        }

        //guzik do circle
        private void read_Click(object sender, EventArgs e)
        {
            int radius = 0;
            if (count > 0)
            {
                string message = "Please give me the radius:", title = "Taking data", defaultValue = "For example 1";
                object Value;

                Value = Interaction.InputBox(message, title, defaultValue);
                if ((string)Value == "")
                {
                    Value = defaultValue;
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                }
                else
                {
                    string stringValue = (string)Value;

                    // sprawdzam czy podana wartosc jest intem
                    for (int i = 0; i < stringValue.Length; i++)
                        if (stringValue[i] < 48 || stringValue[i] > 57)
                        {
                            Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                            Environment.Exit(1);
                        }

                    radius = Int32.Parse(Value.ToString()); // konwertuje z stringa do int i przypisuje do wartosci radius
                }
                if (ifClicked > 0)
                {

                    int beginning_y = (new_beginning_y - (radius / 2));
                    g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                    g.DrawEllipse(pen_circle, new_beginning_x, beginning_y, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)
                                                                                             //zeby nowa figura byla na srednicy a nie kwadracie
                    new_beginning_x += radius;//x powiekoszne o sreddnice
                    new_beginning_y = beginning_y + radius / 2;//zeby bylo w srodku kola

                }
                else
                {
                    new_beginning_x += radius;
                    g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                    g.DrawEllipse(pen_circle, 0, 0, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)
                                                                     //zeby nowa figura byla na srednicy a nie kwadracie
                    new_beginning_x = radius;
                    new_beginning_y = radius / 2;
                }
                count--;
                label1.Text = "Figures left: " + count;

                ifClicked++;//jesli klikne to licznik w gore o jeden

            }
            else
            {
                read.Visible = false;
            }

            //}
            //else if (resultOfConsWindQuest == DialogResult.No)
            //{
            //    AllocConsole(); // otwiera konsole
            //    int radius = 0;
            //    string tempRadius;

            //    Console.Clear(); // czysci konsole
            //    Console.Write("Enter the radius\n>> ");

            //    try
            //    {
            //        tempRadius = Console.ReadLine();
            //        radius = Convert.ToInt32(tempRadius);

            //        if (radius <= 0)
            //        {
            //            MyExceptions error;
            //            error = new MyExceptions();
            //            throw error;
            //        }
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Error! Radius can't be zero!");
            //        Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
            //        Environment.Exit(1); // zamknięcie konsoli
            //    }

            int length = 2 * radius + 1;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (((i - radius) * (i - radius) + (j - radius) * (j - radius)) <= (radius * radius))
                        Console.Write("c");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine(); // działa jak endl
            }
        }


        //guzik do trójkąta
        private void Triangle_Click(object sender, EventArgs e)
        {

            if (count == 0)
            {
                Triangle.Visible = false;//chowam guzik jesli nie moge juz wiecej figur miec
            }
            else
            {
                string message = "Please enter the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please enter the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;

                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                //whiteboard.Image = null; // czysczenie textboxa

                Value = Interaction.InputBox(message, title, defaultValue); // wyswietlamy pierwsze okienko

                // jesli uzytkownik kliknie anuluj lub samo enter czyli defaultValue bedzie
                if ((string)Value == "" || (string)Value == defaultValue) // zeby sie nie wyswietlilo Value1 czyli drugie okienko skoro w pierwszym juz jest blad
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else
                {
                    Value1 = Interaction.InputBox(message1, title1, defaultValue); // wyswietlamy drugie okienko
                    if ((string)Value1 == "" || (string)Value1 == defaultValue) // sprawdzamy czy podane dane sa dobre
                        Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                    else
                    {
                        string stringValue = (string)Value;
                        string stringValue1 = (string)Value1;

                        TakeData(sender, e, stringValue, args, 0, 1); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage
                        TakeData(sender, e, stringValue1, args, 2, 3); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage

                        // sprawdzam czy podana wartosc jest intem
                        for (int i = 0; i < stringValue.Length; i++)
                        {
                            // mozna uzyc tylko cyfr lub "-" lub spacji
                            if (stringValue[i] < 32 || (stringValue[i] > 32 && stringValue[i] < 45 && stringValue[i] > 45 && stringValue[i] < 48) || stringValue[i] > 57)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // do wywalenia
                        Microsoft.VisualBasic.Interaction.MsgBox("DDDDDD " + args[0] + " " + args[1] + " DD" + args[2] + " " + args[3], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "DDDD"); // do wywalenia

                        int x1_int = Convert.ToInt32(args[0]); // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);

                        if (ifClicked == 0)
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = 0, Y = 0 }, new Point { X = x1_int, Y = y1_int }, new Point { X = x2_int, Y = y2_int } }; // ustawianie wierzchołków trójkąta
                            new_beginning_x = points[2].X;//zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                            g.DrawPolygon(pen_triangle, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki )
                        }
                        else
                        {

                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = new_beginning_x, Y = new_beginning_y }, new Point { X = new_beginning_x + x1_int, Y = new_beginning_y + y1_int }, new Point { X = new_beginning_x + x2_int, Y = new_beginning_y + y2_int } }; // ustawianie wierzchołków trójkąta
                            g.DrawPolygon(pen_triangle, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki)
                            new_beginning_x = points[2].X;//zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        count--;
                        label1.Text = "Figures left: " + count;
                    }
                    ifClicked++;
                }
            }
        }
        private void TakeData(object sender, EventArgs e, string stringValue, double[] args, int data1, int data2)
        {
            bool ifSpace = false; // zmienna sprawdzajaca czy jestesmy juz po spacji (zeby wpisywac wartosci do Y)
            int j = 0; // zmienna do liczenia na ktorym elemencie po spacji jestesmy
            bool negation = false; // zmienna sprawdzajaca czy wystepuje minus przed liczba

            // przechodzimy po wszystkich elementach stringa i zamieniamy ta wartosc na inta, jesli napotkamy spacje to idziemy do przypisywania wartosci Y
            for (int i = 0; i < stringValue.Length; i++)
            {
                if (stringValue[i] == '-') // sprawdzamy czy wystepuje negacja
                    negation = true;
                else if (stringValue[i] != ' ' && ifSpace == false) // sprawdzamy stringa do napotkania spacji
                {
                    char tempChar = stringValue[i]; // tworzymy zmienna char zeby mozna wyciagnac tylko jeden znak do stringa ktorego naspetnie zamieniac bedziemy na inta
                    string tempString = Convert.ToString(tempChar);

                    // jesli napotkamy 0 to musimy pomnożyć przez 10 (jesli bedzie na poczatku to i tak sie nic nie zmieni a jesli pozniej to bedzie prawidlowo)
                    if (Int32.Parse(tempString) == 0) // zamieniamy stringa na inta i sprawdzamy
                        args[data1] = args[data1] * 10;
                    else if (negation == true) // jesli napotkamy negacje to musimy miec w wykladniku potegi i-1 poniewaz jednym znakiem bedzie minus
                        args[data1] += (Int32.Parse(tempString) * Math.Pow(10, i - 1));
                    else
                        args[data1] += (Int32.Parse(tempString) * Math.Pow(10, i));
                }
                else if (stringValue[i] == ' ') // jesli napotkamy spacje
                {
                    ifSpace = true;
                    if (negation == true) // sprawdzamy czy wystepuje negacja
                    {
                        args[data1] = -args[data1];
                        negation = false;
                    }
                }
                else if (stringValue[i] != ' ' && ifSpace == true) // sprawdzamy teraz stringa po spacji az do konca stringa
                {
                    char tempChar = stringValue[i];
                    string tempString = Convert.ToString(tempChar);

                    if (Int32.Parse(tempString) == 0)
                        args[data2] = args[data2] * 10;
                    else
                        args[data2] += (Int32.Parse(tempString) * Math.Pow(10, j));

                    j++;
                }
            }
            if (negation == true)
                args[data2] = -args[data2];
        }

        //guzik do rownolegloboku
        private void Parallelogram_Click(object sender, EventArgs e)
        {

            if (count == 0)
            {
                Parallelogram.Visible = false;
            }
            else
            {

                string message = "Please give me the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please give me the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;

                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                //     whiteboard.Image = null; // czysczenie textboxa

                Value = Interaction.InputBox(message, title, defaultValue); // wyswietlamy pierwsze okienko

                // jesli uzytkownik kliknie anuluj lub samo enter czyli defaultValue bedzie
                if ((string)Value == "" || (string)Value == defaultValue) // zeby sie nie wyswietlilo Value1 czyli drugie okienko skoro w pierwszym juz jest blad
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else
                {
                    Value1 = Interaction.InputBox(message1, title1, defaultValue); // wyswietlamy drugie okienko
                    if ((string)Value1 == "" || (string)Value1 == defaultValue) // sprawdzamy czy podane dane sa dobre
                        Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                    else
                    {
                        string stringValue = (string)Value;
                        string stringValue1 = (string)Value1;

                        TakeData(sender, e, stringValue, args, 0, 1); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage
                        TakeData(sender, e, stringValue1, args, 2, 3); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage

                        // sprawdzam czy podana wartosc jest intem
                        for (int i = 0; i < stringValue.Length; i++)
                        {
                            // mozna uzyc tylko cyfr lub "-" lub spacji
                            if (stringValue[i] < 32 || (stringValue[i] > 32 && stringValue[i] < 45 && stringValue[i] > 45 && stringValue[i] < 48) || stringValue[i] > 57)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // do wywalenia
                        Microsoft.VisualBasic.Interaction.MsgBox("DDDDDD " + args[0] + " " + args[1] + " DD" + args[2] + " " + args[3], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "DDDD"); // do wywalenia

                        int x1_int = Convert.ToInt32(args[0]); // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);



                        if (ifClicked > 0)
                        {

                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = new_beginning_x, Y = new_beginning_y }, new Point { X = new_beginning_x + x1_int, Y = new_beginning_y + y1_int }, new Point { X = new_beginning_x + x1_int + x2_int, Y = new_beginning_y + y1_int + y2_int }, new Point { X = new_beginning_x + x2_int, Y = new_beginning_y + y2_int } }; // ustawianie wierzchołków równoległoboku
                            g.DrawPolygon(pen_figure, points); // rysowanie wielokąta (w tym przypadku rownoleglobok bo 4 wierzchołki)
                            new_beginning_x = points[2].X;//zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        else
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = 0, Y = 0 }, new Point { X = new_beginning_x + x1_int, Y = new_beginning_y + y1_int }, new Point { X = new_beginning_x + x1_int + x2_int, Y = new_beginning_y + y1_int + y2_int }, new Point { X = new_beginning_x + x2_int, Y = new_beginning_y + y2_int } }; // ustawianie wierzchołków równoległoboku
                            g.DrawPolygon(pen_figure, points); // rysowanie wielokąta (w tym przypadku rownoleglobok bo 4 wierzchołki)
                            new_beginning_x = points[2].X;//zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        count--;
                        label1.Text = "Figures left: " + count;
                        ifClicked++;
                    }
                }
            }
        }

        //guzik clear
        private void Clear_Click(object sender, EventArgs e)
        {


            System.Windows.Forms.DialogResult resultOfConsWindQuest; // zmienna przechowujaca odpowiedz na poniższego messageboxa
            resultOfConsWindQuest = MessageBox.Show("Do you want to show you the figure in window?\nYes - window  No - console", "Choose console or window", MessageBoxButtons.YesNoCancel);
            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                whiteboard.Image = null;
                count = 5;
                label1.Text = "Figures left: " + count;
                ifClicked = 0;
                new_beginning_x = 0;
                new_beginning_y = 0;
                Parallelogram.Visible = true;
                read.Visible = true;
                Triangle.Visible = true;
            }
            else if (resultOfConsWindQuest == DialogResult.No)
            {
                AllocConsole(); // otwiera konsole
                int radius = 0;
                string tempRadius;

                Console.Clear(); // czysci konsole
                Console.Write("Enter the radius\n>> ");

                try
                {
                    tempRadius = Console.ReadLine();
                    radius = Convert.ToInt32(tempRadius);

                    if (radius <= 0)
                    {
                        MyExceptions error;
                        error = new MyExceptions();
                        throw error;
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Radius can't be zero!");
                    Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                    Environment.Exit(1); // zamknięcie konsoli
                }

            }


            //


            //DO WYWALENIA
            //    private void read_Click(object sender, EventArgs e)
            //    {
            //        //label1.Text = enter_how_many_figures.Text;
            //        data = enter_how_many_figures.Text;
            //        if(data == "d")
            //            this.Hide();
            //    }

            //    private void enter_how_many_figures_keyDown(object sender, KeyEventArgs e)
            //    {
            //        if(e.KeyCode == Keys.Enter)
            //        {
            //            MessageBox.Show("dasda");
            //        }
            //    }

            //    private void enter_how_many_figures_TextChanged(object sender, EventArgs e)
            //    {
            //        label1.Text = enter_how_many_figures.Text;
            //    }
            //}
        }
    }
}
