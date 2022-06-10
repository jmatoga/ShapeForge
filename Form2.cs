using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektOkienkowy
{
    public partial class Complex_Shape : Form
    {
        string data = "";
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
