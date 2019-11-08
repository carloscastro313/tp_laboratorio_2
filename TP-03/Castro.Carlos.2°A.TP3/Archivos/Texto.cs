using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                TextWriter tw = new StreamWriter(archivo, true);
                tw.WriteLine(datos);
                tw.Close();
                return true;
            }
            catch (ArchivosException e)
            {

                throw e.InnerException;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                TextReader tr = new StreamReader(archivo);
                datos = tr.ReadToEnd();
                tr.Close();
                return true;
            }
            catch (ArchivosException e)
            {

                throw e.InnerException;
            }
        }
    }
}
