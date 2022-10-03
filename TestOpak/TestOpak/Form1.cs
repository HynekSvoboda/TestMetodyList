using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOpak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        List<char> seznam = new List<char>();
        List<char> specialniznaky = new List<char>();
        List<char> cisla = new List<char>();
        private void Vypis(List<char>seznam, ListBox listbox)
        {
            foreach(char c in seznam)
            {
                listbox.Items.Add(c);
            }
        }
        private void pocet(ref bool mezera,ref int poceta,ref int pocete,List<char>seznam)
        {
            foreach (char c in seznam)
            {
                if (c != ' ')
                {
                    textBox1.Text += c;
                    if (c == 'a') poceta++;
                    if (c == 'e') pocete++;
                }
                else mezera = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool mezera = false;
            int poceta = 0;
            int pocete = 0;
            textBox1.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            seznam.Clear();
            cisla.Clear();
            specialniznaky.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            Random rng = new Random();
            string text = "";
            for(int i=0;i<n;i++)
            {
                int znak = rng.Next(32, 128);
                seznam.Add(Convert.ToChar(znak));
                if (Convert.ToChar(znak) >= '0' && Convert.ToChar(znak) <= '9') cisla.Add(Convert.ToChar( znak));
                else if (znak >= 33 && znak <=47 || znak>=58 &&znak <= 64 || znak>=91 && znak <=96 || znak>=123)specialniznaky.Add(Convert.ToChar(znak));
                text += Convert.ToChar(znak);
            }
            int pomocna = 0;
            string help = "";
            foreach(char c in text)
            {
                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    help += c;
                    pomocna++;
                }
                else if (pomocna >= 2)
                {
                    listBox1.Items.Add(help);
                    pomocna = 0;
                    help = "";
                }
                else
                {
                    pomocna = 0;
                    help = "";
                }
            }
            if (pomocna >=2) listBox1.Items.Add(help);
            int pocetcisel = cisla.Count();
            specialniznaky.Sort();
            Vypis(specialniznaky, listBox2);
            pocet(ref mezera, ref poceta, ref pocete,seznam);
            label1.Text = "Počet a: " + poceta.ToString() + " ,počet e: " + pocete.ToString() + " je zde mezera? " + mezera.ToString();
            //label2.Text = text;
            cisla.Sort();
            if (pocetcisel >1)
            {
                char median =Convert.ToChar(((cisla.Max()+cisla.Min())/2));
                MessageBox.Show(median.ToString(),"Medián čísel: ",MessageBoxButtons.OK);
            }
        }
    }
}
