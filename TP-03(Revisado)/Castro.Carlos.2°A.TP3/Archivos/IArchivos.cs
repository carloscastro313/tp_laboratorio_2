using System;
using System.Collections.Generic;
using System.Text;

namespace Archivos
{
    public interface IArchivos<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
