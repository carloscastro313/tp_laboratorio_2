using System;
using System.Text;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructores instanciados
        /// 1_El constructor sin parametros llamara al constructor parametrizado asi se cumple
        /// las condicion del TP de que ninguna clase debe ser null.
        /// 2_Los constructores parametrizados uno va a llamar a otro y para este otro llame al base "Universitario".
        /// </summary>
        public Alumno() : this(0, "VACIO", "ALUMNO", "0", ENacionalidad.Argentino,Universidad.EClases.Laboratorio,EEstadoCuenta.Deudor) { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// La sobrecarga de MostrarDatos va retornar los datos de un alumno(legajo, estado de cuenta 
        /// y base.Tostring).
        /// </summary>
        /// <returns> retorna aux </returns>
        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            
            aux.Append(base.ToString());
            aux.AppendLine("LEGAJO: "+base.legajo.ToString());
            aux.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);

            return aux.ToString();
        }

        /// <summary>
        /// Devuelve la clase en la que participa el alumno.
        /// </summary>
        /// <returns> retorna "CLASES DEL DIA: " + this.claseQueToma + "\n" </returns>
        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DIA: " + this.claseQueToma + "\n";
        }

        /// <summary>
        /// llamara a la metodos MostrarDatos y ParticiparEnClase para retornar los datos del alumno.
        /// </summary>
        /// <returns> string this.MostrarDatos() + this.ParticiparEnClase() </returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Operador que compara la clase del alumno y la clase ingresada.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// TRUE= si el alumno no es deudor y se encuentra en la clase.
        /// FLASE= Si el alumno es deudor o no se encuentra en la clase.
        /// </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ((a.estadoCuenta != EEstadoCuenta.Deudor) && a.claseQueToma == clase);
        }

        /// <summary>
        /// Llamara al operador == pero negado.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// TRUE= Si el alumno es deudor o no se encuentra en la clase
        /// FLASE= si el alumno no es deudor y se encuentra en la clase
        /// </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}

