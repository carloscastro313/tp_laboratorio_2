using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        protected static string mensajeBase = "La nacionalidad no se coincide con el numero de DNI";

        #region construtores
        public DniInvalidoException() : base(DniInvalidoException.mensajeBase)
        {

        }

        public DniInvalidoException(string menssage, Exception e) : base(menssage, e)
        {

        }

        public DniInvalidoException(Exception e) : this(DniInvalidoException.mensajeBase, e)
        {

        }

        public DniInvalidoException(string menssage) : this(menssage, null)
        {

        }

        #endregion
    }
}
