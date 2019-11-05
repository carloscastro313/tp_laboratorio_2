using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;

namespace Clases_instanciables
{
    public class Universidad
    {
        #region atributos
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }
        protected List<Alumno> alumnos;
        protected List<Jornada> jornada;
        protected List<Profesor> profesores;

        #endregion

        #region propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region construtor
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }
        #endregion

        #region metodo

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializar = new Xml<Universidad>();

            return serializar.Guardar("Universidad.xml", uni);
        }

        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> deserializar = new Xml<Universidad>();

            deserializar.Leer("Universidad.xml", out uni);

            return uni;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder aux = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                aux.Append(item.ToString());
            }

            return aux.ToString();
        }
        #endregion

        #region sobrecargas
        public override string ToString()
        {

            return Universidad.MostrarDatos(this);
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(!Object.Equals(g,null)&&!object.Equals(a,null))
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (item==a)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            if(g.profesores != null)
            {
                if (g.profesores.Contains(i))
                {
                    return false;
                }
            }
 
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    if (!object.Equals(item, null))
                    {
                        return item;
                    }
                }
            }

            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            return null;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada aux = new Jornada(clase, (g == clase));

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    aux.Alumnos.Add(item);
                }
            }
            g.jornada.Add(aux);
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }

            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        #endregion
    }
}
