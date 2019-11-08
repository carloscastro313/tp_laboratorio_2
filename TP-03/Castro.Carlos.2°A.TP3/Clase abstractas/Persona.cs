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
        /// <summary>
        /// get= retornara un apellido.
        /// set= le dara un valor a apellido.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        /// <summary>
        ///get= retornara un dni.
        /// set= llamara a la metodo sobrecargado ValidarDni(ENacionalidad, int) que le devolvera un entero(dni).
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set {
                    try
                    {
                        this.dni = ValidarDni(this.nacionalidad, value);
                    }

                    catch (DniInvalidoException e)
                    {

                        throw e;
                    }
                }
        }

        /// <summary>
        /// get= retornara una nacionalidad.
        /// set= le dara un valor a nacionalidad.
        /// </summary>
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

        /// <summary>
        /// set= llamara a la metodo sobrecargado ValidarDni(ENacionalidad, string) que le devolvera un entero(dni).
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }

                catch (DniInvalidoException e)
                {

                    throw e;
                }
            }
        }

        #endregion

        #region construtores
        /// <summary>
        /// Constructores instanciados
        /// 1_El constructor sin parametros llamara al constructor parametrizado asi se cumple
        /// las condicion del TP de que ninguna clase debe ser null
        /// 2_Los constructores parametrizados uno va a llamar a otro.
        /// </summary>
        public Persona() : this("VACIO", "ALUMNO", ENacionalidad.Argentino)
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobrecarga que devuelve la informacion de persona
        /// </summary>
        /// <returns> string aux</returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(this.Apellido + ", " + this.Nombre);
            aux.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return aux.ToString();
        }

        /// <summary>
        /// metodo que verifica la validez del dni, este puede generar una excepcion en caso que no sea valido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna dato</returns>
        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if((dato <= 89999999 || dato >= 1))
                    {
                        return dato;
                    }else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                case ENacionalidad.Extranjero:
                    if ((dato >= 90000000))
                    {
                        return dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                default:
                    throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// sobrecarga del metodo ValidarDni pero que tomara como parametro un string. Este va
        /// a hacer un parse de dato a int y llamara a la sobrecarga ValidarDni que recibe entero
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>retorna ValidarDni</returns>
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = int.Parse(dato);

            return ValidarDni(nacionalidad, aux);
        }

        /// <summary>
        /// Verifica si el nombre o apellido solo posee letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>
        /// string dato en caso de que sea valido
        /// string " " en caso que no sea valido
        /// </returns>
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
