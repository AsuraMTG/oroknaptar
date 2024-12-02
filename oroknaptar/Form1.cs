using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oroknaptar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (DateTime.TryParse(textBox1.Text, out DateTime datum))
            {
                string[] napok = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };
                string nap = napok[(int)datum.DayOfWeek - 1];
                label2.Text = $"A megadott dátum: {datum.ToShortDateString()} {nap}i napra esett.";
            }
            else
            {
                label2.Text = $"A bevitt adat nem datum!";
            }
        }
    }
}
