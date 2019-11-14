using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        protected int legajo;
        #endregion

        #region constructores
        /// <summary>
        /// Constructores instanciados
        /// 1_El constructor sin parametros llamara al constructor parametrizado asi se cumple
        /// las condicion del TP de que ninguna clase debe ser null
        /// 2_Los constructores parametrizados uno va a llamar a otro y para este otro llame al base "Persona"
        /// </summary>
        public Universitario() : this(0, "VACIO", "ALUMNO", "0", ENacionalidad.Argentino) { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// metodos abstractos de MostrarDatos
        /// </summary>
        /// <returns>string</returns>
        protected abstract string MostrarDatos();
        /// <summary>
        /// metodos abstractos de ParticiparEnClase
        /// </summary>
        /// <returns>string</returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region operatores

        /// <summary>
        /// Sobrecarga si el parametro obj pertenece a la clase Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retorna obj is Universitario</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Operador que compara clases Universitario .
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>
        /// True: si nacionalidad son iguales y el legajo o dni son iguales.
        /// False: si nacionalidad no son iguales o el legajo o dni no son iguales.
        /// </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Nacionalidad == pg2.Nacionalidad && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// Operador que compara clases Universitario .
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>
        /// True: si nacionalidad no son iguales o el legajo o dni no son iguales.
        /// False: si nacionalidad son iguales y el legajo o dni son iguales.
        /// </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}