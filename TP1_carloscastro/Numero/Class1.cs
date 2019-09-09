using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numero
{
    public class Numero
    {
        private double numero;
        
        public Numero()
        {
            numero = 0;
        }
        public Numero(double aux)
        {
            numero = aux;
        }
        public Numero(string strNumero)
        {
            numero=
        }
            
        public double ValidarNumero(string strNumero)
        {
            double aux=0;

            if(double.TryParse(strNumero, out aux))
            {
                aux = double.Parse(strNumero);
            }

            return aux;
        }

        public static double operator +(Numero n1,Numero n2)
        {
            return n1 + n2;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1 - n2;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1 * n2;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if(object.Equals(n2,0))
            {
                return double.MinValue;
            }else
            {
                return n1 / n2;
            }
            
        }

        public string BinarioDecimal(string binario)
        {
            string numeroAux="Valor invalido";

            if(binario.Length<=8)
            {
                numeroAux=Convert.ToInt32(binario, 10).ToString();
            }

            return numeroAux;
        }

        public string DecimalBinario(string numero)
        {
            string numeroAux = "Valor invalido";

            if (int.Parse(numero) <= 255)
            {
                numeroAux = Convert.ToInt32(numero, 2).ToString();
            }

            return numeroAux;
        }
    }
}
