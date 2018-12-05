using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int n = 10000;

        public int[] a = new int[10000];
        public int[] b = new int[10000];

        void shellSort()
        {
            int inc = Convert.ToInt32(Math.Log(n, 2));
            while (inc > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    int j = i;
                    int temp = b[i];


                    while ((j >= inc) && (b[j - inc] > temp))
                    {
                        b[j] = b[j - inc];
                        j = j - inc;
                    }
                    b[j] = temp;
                }
                if (inc > 1)
                    inc = inc / 2;
                else if (inc == 1)
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox2.Items.Clear();

            Random rnd = new Random();

            for (int i = 0; i < n; i++)

            {
                a[i] = rnd.Next(0, 100);
                b[i] = a[i];
                listBox1.Items.Add(a[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            shellSort();

            sw.Stop();

            listBox2.Items.Add((sw.ElapsedMilliseconds / 100.0).ToString());

            listBox2.Items.Add("");

            for (int i = 0; i < n; i++)

            { listBox2.Items.Add(b[i]); }
        }
    }
}
