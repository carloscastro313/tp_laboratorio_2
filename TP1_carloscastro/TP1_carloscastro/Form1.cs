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
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResultado.Text = operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();  
            
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
            flag = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(verificarResultadoExistente(lblResultado.Text))
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
            if (verificarResultadoExistente(lblResultado.Text))
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
            flag = true;

            return Calculadora.Operar(n1, n2, operando);

        }

        private bool verificarResultadoExistente(string resultado)
        {
            bool verificacion = true;
            double aux;

            if(double.TryParse(resultado, out aux))
            {
                verificacion = false;

            }

            return verificacion;
        }

    }
}
