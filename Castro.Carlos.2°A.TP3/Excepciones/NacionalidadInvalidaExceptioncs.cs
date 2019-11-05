using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : this("Nacionalidad invalida!!!") { }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje) { }
    }
}
