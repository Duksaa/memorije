using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memorije
{
    public partial class Form1 : Form
    {
        List<Button> dodatitasteri = new List<Button>();
        List<int> broj = new List<int>();
        List<int> pogodak = new List<int>();
        int otkriveno = 0;
        int vreme = 10; // Vreme u sekundama
        public Form1()
        {
            InitializeComponent();
        }
        void taster_click(object sender, EventArgs e)
        {
            otkriveno++;
            string p1 = "", p2 = "";
            int poz1 = -1, poz2 = -1;
            if (otkriveno == 3)
            {
                otkriveno = 1;
            }
            Button tast = sender as Button;
            string ime = tast.Name;
            int z = ime.Length;
            ime = ime.Substring(5, z - 5);
            int z1 = Convert.ToInt32(ime);
            tast.Text = Convert.ToString(broj[z1-1]);

            if (otkriveno == 2)
            {
                for (int i = 0; i < 16; i++)
                {
                    if ((dodatitasteri[i].Text != "X") && (pogodak[i] != 1))
                    {
                        p1 = dodatitasteri[i].Text;
                        poz1 = i;
                        break;
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    if ((dodatitasteri[i].Text != "X") && (i != poz1) && (pogodak[i] != 1))
                    {
                        p2 = dodatitasteri[i].Text;
                        poz2 = i;
                        break;
                    }
                }
                if (p1 == p2)
                {
                    pogodak[poz1] = 1;
                    pogodak[poz2] = 1;
                }
                if (p1 != p2) MessageBox.Show("Nisi pogodio!");
                for (int i = 0; i < 16; i++)
                {
                    if (pogodak[i] == 0) dodatitasteri[i].Text = "X";
                }
            }
            int zavrseno = 0;
            for(int i = 0; i < 16; i++)
            {
                zavrseno += pogodak[i];
            }
            if (zavrseno == 16)
            {
                MessageBox.Show("Bravo");
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Enabled = true;
            label1.Text = Convert.ToString(vreme);
            Random x = new Random();
            int sluc = 0;
            int k = 0;
            int s = 1;
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                {
                    if (k == 0) sluc = x.Next(1, 100);
                    broj.Insert(0, sluc);
                    pogodak.Insert(0, 0);
                    Button taster = new Button();
                    taster.Click += new EventHandler(taster_click);
                    taster.Size = new Size(100,100);
                    taster.Location = new Point(j*100,i*100);
                    taster.BackColor = Color.Yellow;
                    taster.Text = Convert.ToString(sluc);
                    taster.Text = "X";
                    taster.Name = "dugme" + Convert.ToString(s);
                    panel2.Controls.Add(taster);
                    dodatitasteri.Insert(0,taster);
                    k++;
                    s++;
                    if (k == 2) k = 0;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(vreme);
            vreme--;
            if (vreme == -1) {
                timer1.Enabled = false;
                MessageBox.Show("Vreme isteklo.. ali ne boj se, uvek moze gore");
                Application.Exit();
            }
        }
    }
}
