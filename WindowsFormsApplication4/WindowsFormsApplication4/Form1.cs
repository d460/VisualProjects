using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            
           label1.Text = "Deshabilitado";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                button1.Enabled = true;
            else
                button1.Enabled = false;
            label1.Text = "Deshabilitado";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = "Hola mundo";

            
        }
    }
}
