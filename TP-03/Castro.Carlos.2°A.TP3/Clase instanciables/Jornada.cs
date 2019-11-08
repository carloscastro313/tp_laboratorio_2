using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;
using Archivos;

namespace Clases_instanciables
{
    public class Jornada
    {
        #region atributos
        protected List<Alumno> alumnos;
        protected Universidad.EClases clase;
        protected Profesor instructor;
        #endregion

        #region propiedades
        /// <summary>
        /// get: retorna la lista de alumnos
        /// set: se le dara una lista al atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// get: retorna una EClases
        /// set: se le dara un valor al atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// get: retorna un clase Profesor
        /// set: se le dara un valor al atributo instructor
        /// </summary>
        public Profesor Instrutor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region constructores
        /// <summary>
        /// El constructor publico instanciado se le dara parametros que inicien los atributos de la clase jornada
        /// y se le llamara a la sobrecarga del constructor privado que instanciara la lista Alumno.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Guarda en un archivo .txt los datos de clase jornada.
        /// True: en caso de tener exito.
        /// False: en caso de fallar.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>
        /// bool t.Guardar("Jornada.txt", jornada.ToString())
        /// </returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Leer un archivo .txt los datos de clase jornada.
        /// True: en caso de tener exito.
        /// False: en caso de fallar.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>
        /// bool retorno
        /// </returns>
        public static string Leer(Jornada jornada)
        {
            string retorno;
            Texto t = new Texto();
            t.Leer("Jornada.txt", out retorno);
            return retorno;
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Sobrecarga de ToString.
        /// </summary>
        /// <returns>
        /// String retorna los datos de la clase jornada.
        /// </returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("JORNADA: ");
            aux.AppendLine("CLASE DE " + this.clase.ToString()+ " PROFESOR: " + this.instructor.ToString());
            aux.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                aux.AppendLine(item.ToString());
            }
            aux.AppendLine("<-------------------------------------------> ");
            return aux.ToString();
        }

        /// <summary>
        /// Operado que compara los alumnos de la clase Jornada y una clase Alumno.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>
        /// True: si se encuentra Alumno a en la list de Jornada j.
        /// False: si no se encuentra Alumno a en la list de Jornada j.
        /// </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Operado que compara los alumnos de la clase Jornada y una clase Alumno.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>
        /// True: si no se encuentra Alumno a en la list de Jornada j.
        /// False: si se encuentra Alumno a en la list de Jornada j.
        /// </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador que agrega un alumno a la lista de jornada en caso de que no se encuentren en la misma.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }
        #endregion
    }
}

