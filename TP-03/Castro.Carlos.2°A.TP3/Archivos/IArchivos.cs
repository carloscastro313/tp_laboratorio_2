using System;
using System.Collections.Generic;
using System.Text;

namespace Archivos
{
    interface IArchivos<T>
    {
        bool Guardar(string archivo, T datos);
        bool leer(string archivo, out T datos);
    }
}
