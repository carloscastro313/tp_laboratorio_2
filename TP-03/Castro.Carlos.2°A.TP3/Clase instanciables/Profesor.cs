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
        /// <summary>
        /// constructor estatico privado que inicializa al atributo de clase Random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructores instanciados
        /// 1_El constructor sin parametros llamara al constructor parametrizado asi se cumple
        /// las condicion del TP de que ninguna clase debe ser null
        /// 2_Los constructores parametrizados uno va a llamar a otro y para este otro llame al base "Universitario"
        /// </summary>
        public Profesor() : base(0, "VACIO", "ALUMNO", "0", ENacionalidad.Argentino)
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region metodos
        /// <summary>
        /// Genera valores aleatorios de tipo EClases para el atributo clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna Informacion del la clase base y las clases que participa.
        /// </summary>
        /// <returns>retorna aux</returns>
        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.Append(base.ToString());
            aux.Append(this.ParticiparEnClase());

            return aux.ToString();
        }
        /// <summary>
        /// Retorna las clases que participa el profesor.
        /// </summary>
        /// <returns>retorna aux</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder aux = new StringBuilder();
            
            aux.AppendLine("LEGAJO NUMERO : " + this.legajo);
            aux.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases item in clasesDelDia)
            {
                aux.AppendLine(item.ToString());
            }

            return aux.ToString();
        }

        /// <summary>
        /// Retorna Los datos del metodo MostrarDatos.
        /// </summary>
        /// <returns>retorna MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Operador que compara las clases que participa el profesor(i) y el parametro clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// True: en caso de que el profesor participe en la clase.
        /// False: en caso de que el profesor no participe en la clase.
        /// </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Operador que compara las clases que participa el profesor(i) y el parametro clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>
        /// True: en caso de que el profesor no participe en la clase.
        /// False: en caso de que el profesor participe en la clase.
        /// </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
