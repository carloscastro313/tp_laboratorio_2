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
        public Alumno() { }
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

        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            
            aux.Append(base.ToString());
            aux.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);

            return aux.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DIA: " + this.claseQueToma + "\n";
        }

        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ((a.estadoCuenta != EEstadoCuenta.Deudor) && a.claseQueToma == clase);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}

