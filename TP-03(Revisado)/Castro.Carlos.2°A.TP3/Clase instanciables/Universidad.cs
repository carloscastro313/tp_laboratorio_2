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

        /// <summary>
        /// get: retorna una lista de alumnos
        /// set: le da una lista de alumnos a atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// get: retorna una lista de jornadas
        /// set: le da una lista de jornadas a atributo jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// get: retorna una lista de profesores
        /// set: le da una lista de profesores a atributo profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// get: retorna una clase jornada en el indice ingresado
        /// set: Le da un valor a un al indice de la lista jornada
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region construtor

        /// <summary>
        /// Constructor publico instanciado que inicializa las listas de la clase universidad
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }
        #endregion

        #region metodo

        /// <summary>
        /// Guarda en un archivo Xml los datos de la clase universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>retorna bool</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializar = new Xml<Universidad>();

            return serializar.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee en un archivo Xml los datos de la clase universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>retorna universidad</returns>
        public static Universidad Leer(Universidad uni)
        {
            Xml<Universidad> deserializar = new Xml<Universidad>();

            deserializar.Leer("Universidad.xml", out uni);

            return uni;
        }

        /// <summary>
        /// Retorna los datos de la lista jornada.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna aux</returns>
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

        /// <summary>
        /// retorna los datos de la clase universidad.
        /// </summary>
        /// <returns>retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Operador que compara si se encuentra una alumno en las lista alumnos de la instancia universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>
        /// Devolvera una excepcion en caso que se encuentre un alumno repetido en la lista.
        /// False: si no se encuentra el alumno en la lista.
        /// </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(!Object.Equals(g,null)&&!object.Equals(a,null))
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (item==a)
                    {
                        throw new AlumnoRepetidoException();                
                    }
                }
            }
            
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Operador que compara si se encuentra una profesor en las lista instrutores de la instancia universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>
        /// True: si se encuentra el profesor en la lista.
        /// False: si no se encuentra el profesor en la lista. 
        /// </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            if(g.profesores != null)
            {
                if (g.profesores.Contains(i))
                {
                    return true;
                }
            }
 
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca en la lista de profesores si se encuentra un profesor que participe en la clase ingresada.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// retornara al profesor que este en la clase ingresada.
        /// Devolvera una excepcion si no se encuentra ningun profesor en la clase ingresada. 
        /// </returns>
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

        /// <summary>
        /// Agrega una jornada a la lista
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna universidad</returns>
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

        /// <summary>
        /// Agrega un alumno a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>Retorna universidad</returns>
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
