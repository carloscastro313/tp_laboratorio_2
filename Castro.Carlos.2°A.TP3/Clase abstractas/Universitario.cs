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
        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        protected abstract string MostrarDatos();
        protected abstract string ParticiparEnClase();
        #endregion

        #region operatores
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Nacionalidad == pg2.Nacionalidad && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}