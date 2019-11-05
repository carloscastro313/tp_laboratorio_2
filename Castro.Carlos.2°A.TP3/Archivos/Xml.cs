using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(archivo, true);

                ser.Serialize(tw, datos);

                tw.Close();

                return true;
            }
            catch (ArchivosException e)
            {

                throw e.InnerException;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextReader tr = new StreamReader(archivo);

                datos = (T)ser.Deserialize(tr);

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
