using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace Clases_instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion


        #region Construtores
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region metodos

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(3));
        }

        #endregion

        #region Sobrecargas

        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.Append(base.ToString());

            return aux.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder aux = new StringBuilder();
            
            aux.Append(base.ToString());
            aux.AppendLine("LEGAJO NUMERO : " + base.legajo);
            aux.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases item in clasesDelDia)
            {
                aux.AppendLine(item.ToString());
            }

            return aux.ToString();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item != clase)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
