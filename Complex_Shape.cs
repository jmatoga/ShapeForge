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
using System.Runtime.InteropServices; // aby móc wyświetlić konsole !!! (trzeba włączyć narzędzia->opcje->debuggowanie->użyj zarządzanego trybu zgodności) jest to forma przestarzała ale inaczej nie działa Console.WriteLine

namespace ProjektOkienkowy
{
    //tworzenie drugiego okienka complex shape
    public partial class Complex_Shape : Form
    {
        // aby utworzyć konsole
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private System.Drawing.Graphics g; // tworzenie zmiennej Grapihics do rysowania 
        public int count = 5; // licznik ile pozostało figur do narysowania - 5 bo ma być maksymalnie 5 figur

        // tworzenie dlugopisów do rysowania 
        private System.Drawing.Pen pen_circle = new System.Drawing.Pen(Color.Aquamarine, 3);
        private System.Drawing.Pen pen_triangle = new System.Drawing.Pen(Color.Purple, 3);
        private System.Drawing.Pen pen_figure = new System.Drawing.Pen(Color.LimeGreen, 3);

        int new_beginning_x = 0; // zeby byly obok siebie nowy początek wspolrzednej
        int new_beginning_y = 0; // nowy początek dla y
        int ifClicked = 0; // licznik ile razy został kliknięty guzik

        public Complex_Shape(System.Windows.Forms.DialogResult resultOfConsWindQuest)
        {
            InitializeComponent();
            ifWindowOrConsole(resultOfConsWindQuest); // aby zapytac sie czy uzytkownik chce dzialac w konsoli czy okienkowo przy przejsciu na complex shape
        }

        private void ifWindowOrConsole(System.Windows.Forms.DialogResult resultOfConsWindQuest)
        {
            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                whiteboard.Image = null;
                count = 5;
                LabelOfLeftFigures.Text = "Figures left: " + count;
                ifClicked = 0;
                new_beginning_x = 0;
                new_beginning_y = 0;
                Parallelogram.Visible = true;
                Circle.Visible = true;
                Triangle.Visible = true;
            }
            else if (resultOfConsWindQuest == DialogResult.No)
                Console_Complex_Shape();
        }

        private void back_button_click(object sender, EventArgs e)
        {
            Simple_Shape back_to_Simple_Shape = new Simple_Shape();
            back_to_Simple_Shape.Show();
            this.Hide();
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            int radius = 0;
            if (count > 0)
            {
                string message = "Please enter the radius:", title = "Taking data", defaultValue = "For example 1";
                object Value;

                Value = Interaction.InputBox(message, title, defaultValue);
                if ((string)Value == defaultValue)
                {
                    Value = defaultValue;
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                }
                else if ((string)Value == "") { } // gdy sie kliknie cancel
                else
                {
                    string stringValue = (string)Value;

                    // sprawdzam czy podana wartosc jest intem
                    for (int i = 0; i < stringValue.Length; i++)
                        if (stringValue[i] < 48 || stringValue[i] > 57)
                        {
                            Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                            Application.Exit();
                        }

                    radius = Int32.Parse(Value.ToString()); // konwertuje z stringa do int i przypisuje do wartosci radius

                    if (ifClicked > 0)
                    {
                        int beginning_y = (new_beginning_y - (radius / 2));
                        g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                        g.DrawEllipse(pen_circle, new_beginning_x, beginning_y, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)

                        // zeby nowa figura byla na srednicy a nie kwadracie
                        new_beginning_x += radius; // x powiekoszne o sreddnice
                        new_beginning_y = beginning_y + radius / 2; // zeby bylo w srodku kola
                    }
                    else
                    {
                        new_beginning_x += radius;
                        g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                        g.DrawEllipse(pen_circle, 0, 180, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)

                        // zeby nowa figura zaczynala sie od konca srednicy a nie kwadratu
                        new_beginning_x = radius;
                        new_beginning_y = radius / 2 + 180;
                    }
                    count--;
                    LabelOfLeftFigures.Text = "Figures left: " + count;

                    ifClicked++; // jesli klikne to licznik w gore o jeden
                }
            }
            else
                Circle.Visible = false;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            if (count == 0)
                Triangle.Visible = false; // chowam guzik jesli skonczyla sie liczba figur mozliwych do narysowania
            else
            {
                string message = "Please enter the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please enter the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;

                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                Value = Interaction.InputBox(message, title, defaultValue); // wyswietlamy pierwsze okienko

                // jesli uzytkownik kliknie anuluj lub samo enter czyli defaultValue bedzie
                if ((string)Value == defaultValue) // zeby sie nie wyswietlilo Value1 czyli drugie okienko skoro w pierwszym juz jest blad
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else if ((string)Value == "") { } // gdy sie kliknie cancel
                else
                {
                    Value1 = Interaction.InputBox(message1, title1, defaultValue); // wyswietlamy drugie okienko
                    if ((string)Value1 == defaultValue) // sprawdzamy czy podane dane sa dobre
                        Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                    else if ((string)Value1 == "") { } // gdy sie kliknie cancel
                    else
                    {
                        string stringValue = (string)Value;
                        string stringValue1 = (string)Value1;

                        TakeData(sender, e, stringValue, args, 0, 1); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage
                        TakeData(sender, e, stringValue1, args, 2, 3); // pobieranie danych od uzytkownika (2,3) ktore dane z args maja brac pod uwage

                        // sprawdzam czy podana wartosc jest intem
                        for (int i = 0; i < stringValue.Length; i++)
                        {
                            // mozna uzyc tylko cyfr lub "-" lub spacji
                            if (stringValue[i] < 32 || (stringValue[i] > 32 && stringValue[i] < 45 && stringValue[i] > 45 && stringValue[i] < 48) || stringValue[i] > 57)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Application.Exit(); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int x1_int = Convert.ToInt32(args[0]);
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);

                        if (ifClicked == 0)
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = 0, Y = 277 - y1_int }, new Point { X = x1_int, Y = y1_int + 277 - y1_int }, new Point { X = x2_int, Y = y2_int + 277 - y1_int } }; // ustawianie wierzchołków trójkąta
                            new_beginning_x = points[2].X; // zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                            g.DrawPolygon(pen_triangle, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki )
                        }
                        else
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = new_beginning_x, Y = new_beginning_y }, new Point { X = new_beginning_x + x1_int, Y = new_beginning_y + y1_int }, new Point { X = new_beginning_x + x2_int, Y = new_beginning_y + y2_int } }; // ustawianie wierzchołków trójkąta
                            g.DrawPolygon(pen_triangle, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki)
                            new_beginning_x = points[2].X; // zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        count--;
                        LabelOfLeftFigures.Text = "Figures left: " + count;
                        ifClicked++;
                    }
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

        private void Parallelogram_Click(object sender, EventArgs e)
        {
            if (count == 0)
                Parallelogram.Visible = false;
            else
            {
                string message = "Please enter the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please enter the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;
                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                Value = Interaction.InputBox(message, title, defaultValue); // wyswietlamy pierwsze okienko

                // jesli uzytkownik kliknie samo enter czyli bedzie defaultValue 
                if ((string)Value == defaultValue) // zeby sie nie wyswietlilo Value1 czyli drugie okienko skoro w pierwszym juz jest blad
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else if ((string)Value == "") { } // gdy sie kliknie cancel
                else
                {
                    Value1 = Interaction.InputBox(message1, title1, defaultValue); // wyswietlamy drugie okienko
                    if ((string)Value1 == defaultValue) // sprawdzamy czy podane dane sa dobre
                        Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                    else if ((string)Value1 == "") { } // gdy sie kliknie cancel
                    else
                    {
                        string stringValue = (string)Value;
                        string stringValue1 = (string)Value1;

                        TakeData(sender, e, stringValue, args, 0, 1); // pobieranie danych od uzytkownika (0,1) ktore dane z args maja brac pod uwage
                        TakeData(sender, e, stringValue1, args, 2, 3); // pobieranie danych od uzytkownika (2,3) ktore dane z args maja brac pod uwage

                        // sprawdzam czy podana wartosc jest intem
                        for (int i = 0; i < stringValue.Length; i++)
                        {
                            // mozna uzyc tylko cyfr lub "-" lub spacji
                            if (stringValue[i] < 32 || (stringValue[i] > 32 && stringValue[i] < 45 && stringValue[i] > 45 && stringValue[i] < 48) || stringValue[i] > 57)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3. Fisrt letter of error in: " + stringValue[i], MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Application.Exit(); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int x1_int = Convert.ToInt32(args[0]);
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);

                        if (ifClicked > 0)
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = new_beginning_x, Y = new_beginning_y }, new Point { X = new_beginning_x + x1_int, Y = new_beginning_y + y1_int }, new Point { X = new_beginning_x + x1_int + x2_int, Y = new_beginning_y + y1_int + y2_int }, new Point { X = new_beginning_x + x2_int, Y = new_beginning_y + y2_int } }; // ustawianie wierzchołków równoległoboku
                            g.DrawPolygon(pen_figure, points); // rysowanie wielokąta (w tym przypadku rownoleglobok bo 4 wierzchołki)
                            new_beginning_x = points[2].X; // zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        else
                        {
                            g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                            Point[] points = new Point[] { new Point { X = 0, Y = 277 - y1_int }, new Point { X = new_beginning_x + x1_int, Y = 277 - y1_int + new_beginning_y + y1_int }, new Point { X = new_beginning_x + x1_int + x2_int, Y = 277 + new_beginning_y - y1_int + y1_int + y2_int }, new Point { X = new_beginning_x + x2_int, Y = 277 - y1_int + new_beginning_y + y2_int } }; // ustawianie wierzchołków równoległoboku
                            g.DrawPolygon(pen_figure, points); // rysowanie wielokąta (w tym przypadku rownoleglobok bo 4 wierzchołki)
                            new_beginning_x = points[2].X; // zapamietuje poprzednie zeby byly poczatkiem nastepnego
                            new_beginning_y = points[2].Y;
                        }
                        count--;
                        LabelOfLeftFigures.Text = "Figures left: " + count;
                        ifClicked++;
                    }
                }
            }
        }

        public class ElementsOfFigures
        {
            // public nie na górze, tylko przed tworzeniem zmienncyh, bo działa inaczej niż w c++
            public int r; // dla kólka
            public int x1, y1; // dla trójkąta
            public int x2, y2;
            public double dx1, dy1; // dla równoległoboku
            public double dx2, dy2;

            // konstruktor domyślny
            public ElementsOfFigures(int t_r = 0, int t_x1 = 0, int t_y1 = 0, int t_x2 = 0, int t_y2 = 0)
            {
                r = t_r;
                x1 = t_x1;
                y1 = t_y1;
                x2 = t_x2;
                y2 = t_x2;
            }

            public ElementsOfFigures(double p_x1 = 0, double p_y1 = 0, double p_x2 = 0, double p_y2 = 0)
            {
                dx1 = p_x1;
                dy1 = p_y1;
                dx2 = p_x2;
                dy2 = p_x2;
            }
        }

        public void takeData_Circle(ElementsOfFigures[] arr, int i)
        {
            string tempRadius;
            Console.Clear(); // czysci konsole
            Console.Write("Enter the radius\n>> ");

            try
            {
                tempRadius = Console.ReadLine();
                arr[i] = new ElementsOfFigures(Convert.ToInt32(tempRadius));

                if (arr[i].r <= 0)
                {
                    MyExceptions error;
                    error = new MyExceptions("My Exception Occured");
                    error.ErrorMessage = "Error! Radius can't be zero!";
                    throw error;
                }
            }
            catch (MyExceptions error)
            {
                Console.WriteLine(error.ErrorMessage);
                Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                Application.Exit(); // zamknięcie konsoli
            }
        }

        public void draw_Circle(int radius)
        {
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

        public void takeData_Triangle(ElementsOfFigures[] args, int j)
        {
            string tempArg;
            Console.Clear(); // czysci konsole

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                        Console.Write("Enter X1\n>> ");
                    else if (i == 1)
                        Console.Write("Enter Y1\n>> ");
                    else if (i == 2)
                        Console.Write("Enter X2\n>> ");
                    else if (i == 3)
                        Console.Write("Enter Y2\n>> ");

                    tempArg = Console.ReadLine();

                    if (i == 0)
                        args[j] = new ElementsOfFigures(0, Convert.ToInt32(tempArg));
                    if (i == 1)
                        args[j].y1 = Convert.ToInt32(tempArg);
                    if (i == 2)
                        args[j].x2 = Convert.ToInt32(tempArg);
                    if (i == 3)
                        args[j].y2 = Convert.ToInt32(tempArg);

                    // sprawdzamy założenia
                    if (i == 3 && args[j].y2 >= 0)
                        Error("Error! Y2 must be negativ intiger");

                    // trzeba zrobic 3 ify zamiast jednego bo trzeba sie jakos odwolywac do elemntow klasy (x1 y1 x2 y2)
                    if (i == 0 && args[j].x1 < 0)
                        Error("Error! X1 can't be negativ intiger");
                    if (i == 1 && args[j].y1 < 0)
                        Error("Error! Y1 can't be negativ intiger");
                    if (i == 2 && args[j].x2 < 0)
                        Error("Error! X2 can't be negativ intiger");

                    if (i == 3 && (args[j].x1 == args[j].y1 || args[j].x2 == args[j].y2))
                        Error("Error! Badly matched coefficients");
                }
            }
            catch (MyExceptions error)
            {
                Console.WriteLine(error.ErrorMessage);
                Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                Application.Exit(); // zamknięcie konsoli
            }
        }

        public void draw_Triangle(int x1, int y1, int x2, int y2)
        {
            double vec1 = y1 / Convert.ToDouble(x1);
            double vec2 = y2 / Convert.ToDouble(x2);
            double vec3 = (x2 - x1) / Convert.ToDouble((y2 - y1)); // obliczony 3 wektor (czyli na obrazku z polecenia to prawa dolna krawedz trojkata)

            for (int y = y1; y >= y2; y--) // od górnego y do dolnego y -> czyli po całej długości igreków(y) przechodzimy
            {
                for (int x = 0; x <= x1 + x2; x++) // x = 0 bo nie moze byc ujemny, x<=x1+x2 żeby x nie wyszedł poza krawedzie trojkata 
                {
                    if (y <= vec1 * x && y >= (vec2 * x) && x <= (x1 - vec3 * (y1 - y)))
                        Console.Write("t");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void takeData_Parallelogram(ElementsOfFigures[] d_args, int j)
        {
            string tempArg;
            Console.Clear(); // czysci konsole

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                        Console.Write("Enter X1\n>> ");
                    else if (i == 1)
                        Console.Write("Enter Y1\n>> ");
                    else if (i == 2)
                        Console.Write("Enter X2\n>> ");
                    else if (i == 3)
                        Console.Write("Enter Y2\n>> ");

                    tempArg = Console.ReadLine();

                    if (i == 0)
                        d_args[j] = new ElementsOfFigures(Convert.ToDouble(tempArg));
                    if (i == 1)
                        d_args[j].dy1 = Convert.ToDouble(tempArg);
                    if (i == 2)
                        d_args[j].dx2 = Convert.ToDouble(tempArg);
                    if (i == 3)
                        d_args[j].dy2 = Convert.ToDouble(tempArg);

                    // sprawdzamy założenia
                    if (i == 3 && d_args[j].dy2 >= 0)
                        Error("Error! Y2 must be negativ intiger");

                    // trzeba zrobic 3 ify zamiast jeden bo trzeba sie jakos odwolywac do elemntow klasy x1 y1 x2
                    if (i == 0 && d_args[j].dx1 < 0)
                        Error("Error! X1 can't be negativ intiger");
                    if (i == 1 && d_args[j].dy1 < 0)
                        Error("Error! Y1 can't be negativ intiger");
                    if (i == 2 && d_args[j].dx2 < 0)
                        Error("Error! X2 can't be negativ intiger");

                    if (i == 3 && (d_args[j].dx1 == d_args[j].dy1 || d_args[j].dx2 == d_args[j].dy2))
                        Error("Error! Badly matched coefficients");
                }
            }
            catch (MyExceptions error)
            {
                Console.WriteLine(error.ErrorMessage);
                Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                Application.Exit(); // zamknięcie konsoli
            }
        }

        public void draw_Parallelogram(double dx1, double dy1, double dx2, double dy2)
        {
            double vec1 = dy1 / dx1;
            double vec2 = dy2 / dx2;
            double vec3 = dy1 / (-dx2);
            double vec4 = dy2 / (-dx1);

            // wspolczynniki
            double wsp1 = Convert.ToDouble(dy1 - dx1 * vec2);
            double wsp2 = Convert.ToDouble(dy2 - dx2 * vec1);
            double wsp3 = Convert.ToDouble(dy2 - dx2 * vec4);
            double wsp4 = Convert.ToDouble(dy1 - dx1 * vec3);

            for (int y = Convert.ToInt32(dy1); y >= dy2; y--)
            {
                for (int x = 0; x <= dx1 + dx2; x++)
                {
                    // -0,1 dlatego ze skonczona dokladnosc obliczeniowa -> żeby w ostatniej linijce "p" sie wyswietlalo
                    if (y <= vec1 * x && y >= vec2 * x && y <= (vec2 * x + wsp1) && y >= (vec1 * x + wsp2 - 0.1) && y >= vec3 * x && y <= (vec3 * x + wsp4) && y <= vec4 * x && y >= (vec4 * x + wsp3 - 0.1))
                        Console.Write("p");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void Console_Complex_Shape()
        {
            bool ifContinue = true;

            while (ifContinue)
            {
                AllocConsole(); // otwiera konsole

                int numberOfFigures = 0, option = 0;
                int numberOfCircles = 0, numbersOfTriangles = 0, numbersOfParallelograms = 0; // zmienne potrzebne do przechowywania informacji o ilosci typow figur do narysowania
                string tempString;
                string drawInOrder = ""; // zmienna pozwalajaca rysowac w kolejnosci podanej przez użytkownika

                Console.Clear(); // czysci konsole
                Console.Write("Enter the number of figures you want to draw (max 5)\n>> ");

                try
                {
                    tempString = Console.ReadLine();
                    numberOfFigures = Convert.ToInt32(tempString);

                    if (numberOfFigures <= 0)
                    {
                        MyExceptions error;
                        error = new MyExceptions("My Exception Occured");
                        error.ErrorMessage = "Error! Number of figgures to draw can't be zero or below zero!";
                        throw error;
                    }
                    if (numberOfFigures > 5)
                    {
                        MyExceptions error;
                        error = new MyExceptions("My Exception Occured");
                        error.ErrorMessage = "Error! Number of figgures to draw can't be more than 5!";
                        throw error;
                    }

                    ElementsOfFigures[] arr = new ElementsOfFigures[numberOfFigures]; // tworzymy tablice klas

                    for (int i = 0; i < numberOfFigures; i++)
                    {
                        Console.Write("Enter " + (i + 1) + " figure\n1. Add circle\n2. Add triangle\n3. Add Parallelogram\n>> ");
                        tempString = Console.ReadLine();
                        option = Convert.ToInt32(tempString);

                        while (option != 1 && option != 2 && option != 3)
                        {
                            Console.Write("Enter the number from 1 to 3.\n>> ");
                            tempString = Console.ReadLine();
                            option = Convert.ToInt32(tempString);
                        }

                        switch (option)
                        {
                            case 1:
                                numberOfCircles++;
                                drawInOrder += 'c';
                                takeData_Circle(arr, i);
                                break;
                            case 2:
                                numbersOfTriangles++;
                                drawInOrder += 't';
                                takeData_Triangle(arr, i);
                                break;
                            case 3:
                                numbersOfParallelograms++;
                                drawInOrder += 'p';
                                takeData_Parallelogram(arr, i);
                                break;
                        }
                    }

                    // rysowanie polaczonej figury
                    Console.Clear(); // czysci konsole
                    for (int i = 0; i < numberOfFigures; i++)
                    {
                        if (numberOfCircles > 0 && drawInOrder[i] == 'c')
                        {
                            draw_Circle(arr[i].r);
                            Console.Write("\n\n");
                            numberOfCircles--;
                        }
                        else if (numbersOfTriangles > 0 && drawInOrder[i] == 't')
                        {
                            draw_Triangle(arr[i].x1, arr[i].y1, arr[i].x2, arr[i].y2);
                            Console.Write("\n\n");
                            numbersOfTriangles--;
                        }
                        else if (numbersOfParallelograms > 0 && drawInOrder[i] == 'p')
                        {
                            draw_Parallelogram(arr[i].dx1, arr[i].dy1, arr[i].dx2, arr[i].dy2);
                            Console.Write("\n\n");
                            numbersOfParallelograms--;
                        }
                    }

                    Console.Write("\nDo you want to continue in console? Y - yes  N - no\n>> ");
                    tempString = Console.ReadLine();

                    if (tempString[0] == 'N' || tempString[0] == 'n')
                    {
                        ifContinue = false;
                        whiteboard.Image = null;
                        count = 5;
                        LabelOfLeftFigures.Text = "Figures left: " + count;
                        ifClicked = 0;
                        new_beginning_x = 0;
                        new_beginning_y = 0;
                        Parallelogram.Visible = true;
                        Circle.Visible = true;
                        Triangle.Visible = true;
                    }
                    if (tempString[0] != 'Y' && tempString[0] != 'N' && tempString[0] != 'y' && tempString[0] != 'n')
                    {
                        MyExceptions error;
                        error = new MyExceptions("My Exception Occured");
                        error.ErrorMessage = "Error! Next time choose Y - yes or N - no!";
                        throw error;
                    }
                }
                catch (MyExceptions error)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                    Application.Exit(); // zamknięcie konsoli
                }
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult resultOfConsWindQuest; // zmienna przechowujaca odpowiedz na poniższego messageboxa
            resultOfConsWindQuest = MessageBox.Show("Do you want to show you the figure in window?\nYes - window  No - console", "Choose console or window", MessageBoxButtons.YesNoCancel);

            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                whiteboard.Image = null;
                count = 5;
                LabelOfLeftFigures.Text = "Figures left: " + count;
                ifClicked = 0;
                new_beginning_x = 0;
                new_beginning_y = 0;
                Parallelogram.Visible = true;
                Circle.Visible = true;
                Triangle.Visible = true;
            }
            else if (resultOfConsWindQuest == DialogResult.No)
                Console_Complex_Shape();
        }

        private void Error(string ErrorMsg)
        {
            MyExceptions error;
            error = new MyExceptions("My Exception Occured");
            error.ErrorMessage = ErrorMsg;
            throw error;
        }
    }
}
