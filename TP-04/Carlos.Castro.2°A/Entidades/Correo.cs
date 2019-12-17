using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo :IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades 
        
        /// <summary>
        /// Propiedad que devuelve y da valor a la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializan la list de mockPaquetes y paquetes
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Mostras la informacion en string de todos los paquetes de la lista paquetes
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetes = ((Correo)elementos).paquetes;
            StringBuilder aux=new StringBuilder();
            foreach (Paquete p in paquetes)
            {
                aux.AppendLine(string.Format("{0} ({1})", p.ToString(), p.Estado));
            }
            return aux.ToString();
        }

        /// <summary>
        /// Abortara todos los hilos de la lista mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Operador que añade un paquete a la lista paquetes
        /// </summary>
        /// <param name="c">Instancia Correo</param>
        /// <param name="p">Paquete que se quiere añadir</param>
        /// <returns>
        /// Dependiendo si "p" se encuentra en la lista, va a devolver una correo con un paquete añadido(o no)
        /// </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (p == paquete)
                {
                    TrackingIdRepetidoException ex = new TrackingIdRepetidoException(string.Format("Id{0} ya ingresada",paquete.TrackingID));
                    throw ex;
                }
            }
            Thread thread = new Thread(new ThreadStart(p.MockCicloDeVida));
            thread.Start();
            c.mockPaquetes.Add(thread);
            c.Paquetes.Add(p);

            return c;
        }
        #endregion
    }
}
