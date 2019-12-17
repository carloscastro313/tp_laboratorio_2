using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo extendido de la clase string
        /// </summary>
        /// <param name="texto"> Lo que se quiere Guardar </param>
        /// <param name="archivo">PATH donde se va a guardar</param>
        /// <returns>
        /// TRUE = Cuando se guardo con exito
        /// FALSE = Cuando ocurrio un error
        /// </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(texto);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
