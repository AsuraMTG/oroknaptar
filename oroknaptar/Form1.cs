using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            label1.Text = "Add meg a dátumot (YYYY-MM-DD): ";
            label2.Text = "";
            label3.Text = "Esetleges esemény megadása:";
            label4.Text = "Fájl neve:";

            button1.Text = "Mutat";
            button2.Text = "Törles";
        }

        public string[] napok = { "Vasárnap", "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat" };

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Contains("A bevitt adat nem datum!"))
                label2.Text = "";

            if (DateTime.TryParse(textBox1.Text, out DateTime datum))
            {
                string esemeny = "A megadott dátum";
                string nap = napok[(int)datum.DayOfWeek];

                if (textBox2.Text != "")
                    esemeny = textBox2.Text;

                string kalkulált = $"{esemeny}: {datum.ToShortDateString()} {nap}i napra esett.\n";
                label2.Text += kalkulált;

                if (textBox3.Text == "")
                    textBox3.Text = "Datumok";

                using (StreamWriter outputFile = new StreamWriter(Path.Combine($"{textBox3.Text}.txt"), true))
                    outputFile.Write($"{kalkulált}");
            }
            else
                label2.Text = $"A bevitt adat nem datum!";

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("Datumok.txt")))
                outputFile.Write("");
        }
    }
}
