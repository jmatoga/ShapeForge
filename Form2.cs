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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void back_button_click(object sender, EventArgs e)
        {
            Form1 back_to_form1 = new Form1();
            back_to_form1.Show();
            this.Hide();
        }
      
        private void read_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
    }
}
