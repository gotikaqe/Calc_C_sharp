using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bir_Art_Calc
{
    public partial class Form1 : Form
    {
        double result, aa, bb;
        bool op;
        bool errorr;
        char deistvie;
        int where_pluss = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void nom_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += b.Text;
        }

        private void math_click(object sender, EventArgs e)
        {
            if (!op && textBox1.TextLength>0)
            {
                Button c = (Button)sender;
                textBox1.Text += c.Text;
                deistvie = c.Text[0];
                op = true;
                where_pluss = textBox1.TextLength;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = label2.Text + Convert.ToString(File.ReadAllText(@"C:\Calculator\save\save.txt"));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter abc = File.CreateText(@"C:\Calculator\save\save.txt");
            abc.Write(textBox1.Text);
            abc.Close();
        }

        private void math_one_op_click(object sender, EventArgs e)
        {
            Button z = (Button)sender;
            if (z.Text == "ln")
            {
                textBox1.Text = "ln(";
                deistvie = 'l';
                where_pluss = 3;
            }
            else if (z.Text[0]=='m')
            {
                textBox1.Text = "|";
                deistvie = 'm';
                where_pluss = 1;
            } else if (z.Text == "√")
            {
                textBox1.Text = "√";
                deistvie = '√';
                where_pluss = 1;
            }
            op = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (op && where_pluss < textBox1.TextLength)
            {
                if (deistvie != 'm' && deistvie != 'l' && deistvie != '√') aa = Convert.ToDouble(textBox1.Text.Substring(0, where_pluss-1));
                bb = Convert.ToDouble(textBox1.Text.Substring(where_pluss , textBox1.Text.Length - where_pluss));
                switch (deistvie)
                {
                    case '+':
                        result = aa + bb;
                        break;
                    case '-':
                        result = aa - bb;
                        break;
                    case '*':
                        result = aa * bb;
                        break;
                    case '/':
                        if (bb == 0) errorr = true;
                        else result = aa / bb;
                        break;
                    case '%':
                        result = aa * bb / 100;
                        break;
                    case '^':
                        result = System.Math.Pow(aa, bb);
                        break;
                    case 'm':
                        result = System.Math.Abs(bb);
                        textBox1.Text += "|";
                        break;
                    case 'l':
                        if (bb == 0) errorr = true;
                        else
                        {
                            result = System.Math.Log(bb);
                            textBox1.Text += ")";
                        }
                        break;
                    case '√':
                        if (bb < 0) errorr = true;
                        else result = System.Math.Sqrt(bb);
                        break;

                }
                op = false;
                if (errorr)
                {
                    label1.Text = "Ошибка!";
                    textBox1.Text = "";
                }
                else
                {
                    label1.Text = textBox1.Text + " = " + Convert.ToString(result);
                    textBox1.Text = Convert.ToString(result);
                }
                errorr = false;
                where_pluss = 0;
            }
        }
    }
}
