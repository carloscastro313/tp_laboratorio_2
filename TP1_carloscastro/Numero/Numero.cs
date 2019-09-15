using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        private string SetNumero
        {
            set {this.numero = ValidarNumero(value);}
        }
        
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            this.SetNumero= strNumero;
        }
            
        private double ValidarNumero(string strNumero)
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
            return (double)(n1.numero + n2.numero);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return (double)(n1.numero - n2.numero);
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return (double)(n1.numero * n2.numero);
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if(object.Equals(n2,0))
            {
                return double.MinValue;
            }else
            {
                return (double)(n1.numero / n2.numero);
            }
            
        }

        public static string BinarioDecimal(string binario)
        {
            string resultado;
            int len = binario.Length;
            double suma=0;
            int exponente=0;
            

            for (int i = len-1; i >=0 ; i--)
            {
                if(binario[i] == '1')
                {
                    suma += Math.Pow(2, exponente);
                }
                exponente++;
            }

            resultado = suma.ToString();

            return resultado;
        }

        public static string DecimalBinario(string numero)
        {
            double aux;

            if(!(double.TryParse(numero,out aux)))
            {

                return "Valor Invalido";
            }
            else
            {
                return DecimalBinario(double.Parse(numero));             
            }                    
        }

        public static string DecimalBinario(double numero)
        {
            string binario="";
            string aux;
            UInt32 suma;

            if (numero<0)
            {
                numero = numero * (-1);
            }

            suma = (UInt32)numero;

            if (suma>0)
            {
                while(suma >= 2)
                {
                     aux = ((suma % 2).ToString());
                     suma = suma / 2;
                    binario = aux + binario;
                }
                binario = "1" + binario;
            }
            else
            {
                binario = "0";
            }
            
               
            return binario;
        }
        
    }
}
