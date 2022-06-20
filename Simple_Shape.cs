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
    //tworzenie okienka pierwszego Simple Shape
    public partial class Simple_Shape : Form
    {
        // aby utworzyć konsole
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private System.Drawing.Graphics g; // tworzenie zmiennej Grapihics do rysowania 

        // tworzenie dlugopisów do rysowania 
        private System.Drawing.Pen pen_circle = new System.Drawing.Pen(Color.Aquamarine, 3);
        private System.Drawing.Pen pen_triangle = new System.Drawing.Pen(Color.Purple, 3);
        private System.Drawing.Pen pen_figure = new System.Drawing.Pen(Color.LimeGreen, 3);

        public Simple_Shape()
        {
            InitializeComponent(); // to sie robi samo - metoda wymagana do obsługi projektanta 
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult resultOfConsWindQuest; // zmienna przechowujaca odpowiedz na poniższego messageboxa
            resultOfConsWindQuest = MessageBox.Show("Do you want to show you the figure in window?\nYes - window  No - console", "Choose console or window", MessageBoxButtons.YesNoCancel);

            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                int radius = 0;
                string message = "Please enter the radius:", title = "Taking data", defaultValue = "For example 1";
                object Value;

                whiteboard.Image = null; // czysczenie whiteboarda

                Value = Interaction.InputBox(message, title, defaultValue);

                // jesli uzytkownik kliknie samo enter czyli bedzie defaultValue 
                if ((string)Value == defaultValue)
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else if ((string)Value == "") { } // gdy sie kliknie cancel
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

                    radius = Int32.Parse(Value.ToString()); // konwertuje ze stringa do int i przypisuje do wartosci radius
                }

                g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                g.DrawEllipse(pen_circle, 200,180, radius, radius); // rysowanie elipsy (z ktorej robimy koło poprzez podanie 2 razy promienia w 2 ostatnich argumenatch)
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
                        error = new MyExceptions("My Exception Occured");
                        error.ErrorMessage = "Error! Radius can't be zero!";
                        throw error;
                    }
                }
                catch (MyExceptions error)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                    Environment.Exit(1); // zamknięcie konsoli
                }

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
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult resultOfConsWindQuest; // zmienna przechowujaca odpowiedz na poniższego messageboxa
            resultOfConsWindQuest = MessageBox.Show("Do you want to show you the figure in window?\nYes - window  No - console", "Choose console or window", MessageBoxButtons.YesNoCancel);

            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                string message = "Please enter the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please enter the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;
                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                whiteboard.Image = null; // czysczenie whiteboarda

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

                        // sprawdzamy założenia
                        for (int i = 0; i < 4; i++)
                        {
                            if (i == 3 && args[3] >= 0)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! Y2 must be negativ intiger", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                            if (i < 3 && args[i] < 0)
                            {
                                string temp = "Wrong Value";
                                if (i == 0)
                                    temp = "X1";
                                else if (i == 1)
                                    temp = "Y1";
                                else if (i == 2)
                                    temp = "X2";

                                Microsoft.VisualBasic.Interaction.MsgBox("Error! " + temp + " can't be negativ intiger", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                            if (i == 3 && (args[0] == args[1] || args[2] == args[3]))
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! Badly matched coefficients", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int x1_int = Convert.ToInt32(args[0]);
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);

                        g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                        Point[] points = new Point[] { new Point { X = 0+200, Y = 277-y1_int }, new Point { X = x1_int + 200, Y = 277 + y1_int - y1_int }, new Point { X = x2_int + 200, Y =277+ y2_int - y1_int } }; // ustawianie wierzchołków trójkąta
                                                                                                                                                                                                                                                                  //  Y =277, Y=277+y2_int zeby (0,0) było od srodka,a nie lewy górny , bo caly rizmiar y to 555 /2 =277
                        g.DrawPolygon(pen_triangle, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki)
                    }
                }
            }
            else if (resultOfConsWindQuest == DialogResult.No)
            {
                AllocConsole(); // otwiera konsole
                int[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2
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
                        args[i] = Convert.ToInt32(tempArg);

                        // sprawdzamy założenia
                        if (i == 3 && args[3] >= 0)
                            Error(sender, e, "Error! Y2 must be negativ intiger");

                        if (i < 3 && args[i] < 0)
                        {
                            string temp = "Wrong Value";
                            if (i == 0)
                                temp = "X1";
                            else if (i == 1)
                                temp = "Y1";
                            else if (i == 2)
                                temp = "X2";

                            Error(sender, e, "Error! " + temp + " can't be negativ intiger");
                        }
                        if (i == 3 && (args[0] == args[1] || args[2] == args[3]))
                            Error(sender, e, "Error! Badly matched coefficients");
                    }
                }
                catch (MyExceptions error)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                    Environment.Exit(1); // zamknięcie konsoli
                }

                int height = args[1] - args[3]; // - ponieważ y2 musi byc wartoscia ujemna
                int width = args[0] + args[2];

                // przypisywanie wartości wpisane przez użytkownika do zmiennych x1,y1,x2,y2 zeby bylo wygodniej
                int x1 = args[0];
                int y1 = args[1];
                int x2 = args[2];
                int y2 = args[3];

                double vec1 = y1 / Convert.ToDouble(x1);
                double vec2 = y2 / Convert.ToDouble(x2);
                double vec3 = (x2 - x1) / Convert.ToDouble((y2 - y1)); // obliczony 3 wektor (czyli na obrazku  z polecenia to prawa dolna krawedz trojkata)

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
        }

        private void TakeData(object sender, EventArgs e, string stringValue, double[] args, int data1, int data2)
        {
            bool ifSpace = false; // zmienna sprawdzajaca czy jestesmy juz po spacji (zeby wpisywac wartosci do Y)
            int j = 0; // zmienna do liczenia na ktorym elemencie po spacji jestesmy
            bool negation = false; // zmienna sprawdzajaca czy wystepuje minus przed liczba

            // przechodzimy po wszystkich elementach stringa i zamieniamy ta wartosc na inta jesli napotkamy spacje to idziemy do przypisywania wartosci Y
            for (int i = 0; i < stringValue.Length; i++)
            {
                if (stringValue[i] == '-') // sprawdzamy czy wystepuje negacja
                    negation = true;
                else if (stringValue[i] != ' ' && ifSpace == false) // sprawdzamy stringa do napotkania spacji
                {
                    char tempChar = stringValue[i]; // tworzymy zmienna czar zeby mozna wyciagnac tylko jeden znak do stringa ktorego naspetnie zamieniac bedziemy na inta
                    string tempString = Convert.ToString(tempChar);

                    // jesli napotkamy 0 to musimy pomnożyć o 10 (jesli bedzie na poczatku to i tak sie nic nie zmieni a jesli pozniej to bedzie prawidlowo)
                    if (Int32.Parse(tempString) == 0) // zamieniamy stringa na inta i sprawdzamy
                        args[data1] = args[data1] * 10;
                    else if (negation == true) // jesli napotkamy negacje to musimy miec w wykladniku potegi i-1 poniewaz jednym znakiem bedzie minus
                        args[data1] = (args[data1] * Math.Pow(10, i - 1)) + Int32.Parse(tempString);
                    else
                        args[data1] = (args[data1] * Math.Pow(10, i)) + Int32.Parse(tempString);
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
                        args[data2] = (args[data2] * Math.Pow(10, j)) + Int32.Parse(tempString);

                    j++;
                }
            }
            if (negation == true)
                args[data2] = -args[data2];
        }

        private void Parallelogram_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult resultOfConsWindQuest; // zmienna przechowujaca odpowiedz na poniższego messageboxa
            resultOfConsWindQuest = MessageBox.Show("Do you want to show you the figure in window?\nYes - window  No - console", "Choose console or window", MessageBoxButtons.YesNoCancel);

            if (resultOfConsWindQuest == DialogResult.Yes)
            {
                string message = "Please enter the X coords and Y coords:", title = "Taking data", defaultValue = "For example 1 3";
                string message1 = "Please enter the second X coords and Y coords:", title1 = "Taking second data";
                object Value, Value1;

                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2

                whiteboard.Image = null; // czysczenie whiteboarda

                Value = Interaction.InputBox(message, title, defaultValue); // wyswietlamy pierwsze okienko

                // jesli uzytkownik kliknie samo enter czyli bedzie defaultValue
                if ((string)Value == defaultValue) // zeby sie nie wyswietlilo Value1 czyli drugie okienko skoro w pierwszym juz jest blad
                    Microsoft.VisualBasic.Interaction.MsgBox("Error! You have to write an intiger for example 1 3.", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                else if ((string)Value == "") { } // gdy sie kliknie cancel
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

                        // sprawdzamy założenia
                        for (int i = 0; i < 4; i++)
                        {
                            if (i == 3 && args[3] >= 0)
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! Y2 must be negativ intiger", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                            if (i < 3 && args[i] < 0)
                            {
                                string temp = "Wrong Value";
                                if (i == 0)
                                    temp = "X1";
                                else if (i == 1)
                                    temp = "Y1";
                                else if (i == 2)
                                    temp = "X2";

                                Microsoft.VisualBasic.Interaction.MsgBox("Error! " + temp + " can't be negativ intiger", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                            if (i == 3 && (args[0] == args[1] || args[2] == args[3]))
                            {
                                Microsoft.VisualBasic.Interaction.MsgBox("Error! Badly matched coefficients", MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "Data Error");
                                Environment.Exit(1); // opuszczenie programu z kodem błedu 1
                            }
                        }

                        // zamiana double na int (double trzeba użyć przy obliczaniu potęgi)
                        int x1_int = Convert.ToInt32(args[0]);
                        int y1_int = Convert.ToInt32(args[1]);
                        int x2_int = Convert.ToInt32(args[2]);
                        int y2_int = Convert.ToInt32(args[3]);

                        g = whiteboard.CreateGraphics(); // tworzenie grafiki zmiennej na tablicy whiteboard
                        Point[] points = new Point[] { new Point { X = 200, Y = 277 - y1_int }, new Point { X = x1_int+ 200, Y = 277 + y1_int - y1_int }, new Point { X = x1_int + 200 + x2_int, Y = 277 + y1_int + y2_int - y1_int }, new Point { X = x2_int + 200, Y = 277 + y2_int - y1_int } }; // ustawianie wierzchołków równoległoboku
                        g.DrawPolygon(pen_figure, points); // rysowanie wielokąta (w tym przypadku trójkąt bo 3 wierzchołki)
                    }
                }
            }
            else if (resultOfConsWindQuest == DialogResult.No)
            {
                AllocConsole(); // otwiera konsole
                double[] args = { 0, 0, 0, 0 }; // argumenty x1, y1, x2, y2
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
                        args[i] = Convert.ToInt32(tempArg);

                        if (i == 3 && args[3] >= 0)
                            Error(sender, e, "Error! Y2 must be negativ intiger");
                        if (i < 3 && args[i] < 0)
                        {
                            string temp = "Wrong Value";
                            if (i == 0)
                                temp = "X1";
                            else if (i == 1)
                                temp = "Y1";
                            else if (i == 2)
                                temp = "X2";

                            Error(sender, e, "Error! " + temp + " can't be negativ intiger");
                        }
                        if (i == 3 && (args[0] == args[1] || args[2] == args[3]))
                            Error(sender, e, "Error! Badly matched coefficients");
                    }
                }
                catch (MyExceptions error)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.ReadKey(); // zatrzymanie aby móc zobaczyć bład w konsoli
                    Environment.Exit(1); // zamknięcie konsoli
                }

                // przypisywanie wartości wpisane przez użytkownika do zmiennych x1,y1,x2,y2 zeby bylo wygodniej
                double x1 = args[0];
                double y1 = args[1];
                double x2 = args[2];
                double y2 = args[3];

                double vec1 = y1 / x1;
                double vec2 = y2 / x2;
                double vec3 = y1 /(-x2);
                double vec4 = y2 / (-x1);

                // wspolczynniki
                double wsp1 = Convert.ToDouble(y1 - x1 * vec2);
                double wsp2 = Convert.ToDouble(y2 - x2 * vec1);
                double wsp3 = Convert.ToDouble(y2 - x2 * vec4);
                double wsp4 = Convert.ToDouble(y1 - x1 * vec3);

                for (int y = Convert.ToInt32(y1); y >= y2; y--)
                {
                    for (int x = 0; x <= x1 + x2; x++)
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
        }

        private void Complex_Click(object sender, EventArgs e)
        {
            Complex_Shape complex_shape_window = new Complex_Shape();
            complex_shape_window.Show();
            this.Hide();
        }

        private void Error(object sender, EventArgs e, string ErrorMsg)
        {
            MyExceptions error;
            error = new MyExceptions("My Exception Occured");
            error.ErrorMessage = ErrorMsg;
            throw error;
        }
    }

    public class MyExceptions : Exception
    {
        public MyExceptions() : base() { }
        public MyExceptions(string message) : base(message) { }

        private string strErrorMessage;
        public string ErrorMessage
        {
            get
            {
                return strErrorMessage;
            }

            set
            {
                strErrorMessage = value;
            }
        }
    }
}
