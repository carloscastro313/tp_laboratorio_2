using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("La nacionalidad no se coincide con el numero de DNI")
        {

        }

        public DniInvalidoException(string menssage, Exception e) : base(menssage, e)
        {

        }

        public DniInvalidoException(Exception e) : this("La nacionalidad no se coincide con el numero de DNI", e)
        {

        }

        public DniInvalidoException(string menssage) : this(menssage, null)
        {

        }
    }
}
