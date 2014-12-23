using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text="Бiном. розподiл (n=7, p=0.13):\n";
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {                
                System.Threading.Thread.Sleep(5);
                richTextBox1.Text += Binom();
                richTextBox1.Text += "\n";
            }
        }

        public int Binom()
        {
            int n = 7;
            double p = 0.13;
            int eps = 10000;
            double[] mas = new double[n];
            int res=0;
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = (double)r.Next(eps) / eps;                
                if (mas[i]<p)
                {
                    res++;
                }
            }
            return res;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChiKvadrat(Convert.ToInt32(textBox1.Text));
        }

        public void ChiKvadrat(int count)
        {
            int n = 5;
            double [] res = new double[count];
            richTextBox1.Text = "X2 розподiл з 5 степенями свободи:\n";
            Random r = new Random();
            double U;
            int eps = 10000;
            n = n / 2;
            for(int i=0; i<count; i++)
            {
                double sum = 0;                
                for (int j = 0; j < n; j++)
                {
                    U = (double)r.Next(eps) / eps;
                    sum += -2*Math.Log(U);
                }                  
                res[i] = sum;
                double V = 0;
                double G = 0;
                double t = 0;
                double A = n - (int)n;
                V = Math.E / (Math.E + A);
                do
                {
                    double U1 = (double)r.Next(eps) / eps;
                    double U2 = (double)r.Next(eps) / eps;
                    double U3 = (double)r.Next(eps) / eps;
                    if (U1 <= V)
                    {
                        G = Math.Pow((U2 / V), 1 / A);
                        t = U3 * Math.Pow(G, A - 1);
                    }
                    else
                    {
                        G = 1 - Math.Log(U2);
                        t = U3 * Math.Pow(Math.E, -G);
                    }
                }
                while (t > Math.Pow(G, A - 1) * Math.Pow(Math.E, -G));
                res[i] += G;
                richTextBox1.Text += res[i] + "\n";
            }            
        }
    }
}
