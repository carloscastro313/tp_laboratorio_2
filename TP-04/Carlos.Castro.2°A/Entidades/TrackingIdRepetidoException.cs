using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion TrackingIdRepetidoException 
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje que se quiere mostrar
        /// </param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor de la excepcion TrackingIdRepetidoException que tiene ademas del mensaje una excepcion
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
