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

namespace lotto_gyakorlas2
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolasok = new List<Sorsolas>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            List<Sorsolas> szamok_lista = new List<Sorsolas>();
            string[] lines = File.ReadAllLines("lotto.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                sorsolasok.Add(sorsolas_object);
            }
            int db = 0;
            for (int i = 0; i < 46; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if (i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5 || i == item.szam6)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int min_db = int.MinValue;
            int min_szam = 0;
            int paratlan_db = 0;
            foreach (var item in sorsolasok)
            {
                if (item.szam1 % 3 == 0 || item.szam2 % 3 == 0 || item.szam3 % 3 == 0 || item.szam4 % 3 == 0 || item.szam5 % 3 == 0 || item.szam6 % 3 == 0)
                {
                    paratlan_db++;
                }
            }
            label2.Text = $"Pártalan számok: {paratlan_db} db";

            foreach (var item in szamok)
            {
                if (item.db > min_db)
                {
                    min_db = item.db;
                    min_szam = item.szam;
                }
            }

            foreach (var item in szamok)
            {
                if (item.szam == 1)
                    label3.Text = $"1-es: {item.db} db";
            }

            foreach (var item in szamok)
            {
                if (item.szam == 3)
                    label5.Text = $"3-as: {item.db} db";
            }
            foreach (var item in szamok)
            {
                dataGridView1.Rows.Add(item.szam, item.db);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolasok)
            {
                if (numericUpDown1.Value == item.het)
                    label1.Text = $"1.Feladat: {item.het}. hét: {item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5},{item.szam6}";
            }
        }
    }
}
