using System;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region atributos
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }
        protected string apellido;
        protected int dni;
        protected ENacionalidad nacionalidad;
        protected string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string StringToDNI
        {
            set { this.dni = int.Parse(value); }
        }

        #endregion

        #region construtores

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region metodos
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.Append(this.Apellido + ", " + this.Nombre);
            aux.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return aux.ToString();
        }

        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad != ENacionalidad.Argentino && (dato <= 89999999 || dato >= 1))
            {
                return dato;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = int.Parse(dato);

            return ValidarDni(nacionalidad, aux);
        }
        private string ValidarNombreApellido(string dato)
        {
            Regex reg = new Regex("^[A-Za-z]+$");
            if (reg.IsMatch(dato))
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
