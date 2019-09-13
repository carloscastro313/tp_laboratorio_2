using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP1_carloscastro
{
    public partial class Form1 : Form
    {
        bool flag = true;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("-");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResultado.Text = operar(this.txtNumero2.Text, this.txtNumero1.Text, this.cmbOperador.Text).ToString();  
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtNumero2.Clear();
            this.txtNumero1.Clear();
            this.cmbOperador.Text="";
            lblResultado.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text == "")
            {
                lblResultado.Text = "Valor Invalido";
            }
            else if(flag)
            {              
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                flag = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text == "")
            {
                lblResultado.Text = "Valor Invalido";
            }
            else if(flag==false)
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                flag = true;
            }
        }
        private double operar(string numero1, string numero2, string operando)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operando);

        }

    }
}
