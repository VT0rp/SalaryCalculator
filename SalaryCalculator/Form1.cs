using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SalaryCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void getFlagsEs(bool[] flag, double dineros)
        {
            if(dineros > 0)
            {
                flag[0] = true;
                if(dineros >= 12450)
                {
                    flag[1] = true;
                    if(dineros >= 20200)
                    {
                        flag[2] = true;
                        if(dineros >= 35200)
                        {
                            flag[3] = true;
                            if(dineros >= 60000)
                            {
                                flag[4] = true;
                                if(dineros >= 300000)
                                {
                                    flag[5] = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void getFlagsAn(bool[] flag, double dineros)
        {
            if(dineros > 0)
            {
                flag[0] = true;
                if(dineros > 24000)
                {
                    flag[1] = true;
                    if(dineros > 40000)
                    {
                        flag[2] = true;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] flags = {false, false, false, false, false, false};
                double salario = Double.Parse(textBox1.Text);
                double impuestos = 0;
                if(salario > 0)
                {
                    getFlagsEs(flags, salario);
                    if (flags[0])
                    {
                        if(salario >= 12450)
                        {
                            impuestos += (12450 * 0.19);
                        }
                        else
                        {
                            impuestos += (salario * 0.19);
                        }
                        if (flags[1])
                        {
                            if(salario >= 20200)
                            {
                                impuestos += ((20200 - 12450) * 0.24);
                            }
                            else
                            {
                                impuestos += ((salario - 12450) * 0.24);
                            }
                            if (flags[2])
                            {
                                if(salario >= 35200)
                                {
                                    impuestos += ((35200 - 20200) * 0.3);
                                }
                                else
                                {
                                    impuestos += ((salario - 20200) * 0.3);
                                }
                                if (flags[3])
                                {
                                    if(salario >= 60000)
                                    {
                                        impuestos += ((60000 - 35200) * 0.37);
                                    }
                                    else
                                    {
                                        impuestos += ((salario - 35200) * 0.37);
                                    }
                                    if (flags[4])
                                    {
                                        if(salario >= 300000)
                                        {
                                            impuestos += ((300000 - 60000) * 0.45);
                                        }
                                        else
                                        {
                                            impuestos += ((salario - 60000) * 0.45);
                                        }
                                        if (flags[5])
                                        {
                                            impuestos += ((salario - 300000) * 0.47);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, introduce un salario mayor que 0");
                    }
                    textBox2.Text = (salario - impuestos).ToString() + "€";
                    textBox3.Text = impuestos.ToString() + "€";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Introduce un número para proceder");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] flags = { false, false, false };
                double salario = Double.Parse(textBox1.Text);
                double impuestos = 0;
                if (salario > 0)
                {
                    getFlagsAn(flags, salario);
                    if (flags[0] && salario >= 24000)
                    {
                        impuestos += 0;
                        if (flags[1] && salario >= 40000)
                        {
                            impuestos += ((40000 - 24000) * 0.05);
                            if (flags[2] && salario > 40000)
                            {
                                impuestos += ((salario - 40000) * 0.1);
                            }
                        }
                        else
                        {
                            impuestos += ((salario - 24000) * 0.05);
                        }
                    }
                    else
                    {
                        impuestos += 0;
                    }
                }
                else
                {
                    MessageBox.Show("Error, introduce un salario mayor que 0");
                }
                textBox2.Text = (salario - impuestos).ToString() + "€";
                textBox3.Text = impuestos.ToString() + "€";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Introduce un número para proceder");
            }
        }
    }
}
