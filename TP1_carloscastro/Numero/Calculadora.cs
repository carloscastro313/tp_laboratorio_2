using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double resultado = 0;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = n1 + n2;
                    break;
                case "-":
                    resultado = n1 - n2;
                    break;
                case "*":
                    resultado = n1 * n2;
                    break;
                case "/":
                    resultado = n1 / n2;          
                    break;
                default:
                    resultado = n1 + n2;
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            
            if((operador!="+"&&operador!="-")&&(operador != "*" && operador != "/"))
            {
                operador = "+";
            }
            return operador;
        }
    }
}
