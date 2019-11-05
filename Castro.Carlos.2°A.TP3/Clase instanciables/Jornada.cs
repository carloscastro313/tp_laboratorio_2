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
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instrutor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region constructores
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

        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar("Jornada.txt", jornada.ToString());
        }
        #endregion

        #region sobrecargas

        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("JORNADA: ");
            aux.AppendLine("CLASE DE" + this.clase.ToString()+ "PROFESOR: " + this.instructor.ToString());
            aux.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                aux.AppendLine(item.ToString());
            }
            aux.AppendLine("<-------------------------------------------> ");
            return aux.ToString();
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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

