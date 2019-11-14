using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base("Alumno repetido.") { }
    }
}

