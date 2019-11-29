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

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();

        }
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
                aux.AppendLine(string.Format("{0} para {1} ({2})", (object)p.TrackingID, (object)p.DireccionEntrega, (object)p.Estado.ToString()));
            }
                return aux.ToString();
        }
            
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (p == item)
                {
                    TrackingIdRepetidoException ex = new TrackingIdRepetidoException(string.Format("Id{0} ya ingresada",(object)item.TrackingID));
                    throw ex;
                }
            }
            Thread thread = new Thread(new ThreadStart(p.MockCicloDeVida));
            thread.Start();
            c.mockPaquetes.Add(thread);
            c.Paquetes.Add(p);

            return c;
        }
        /// <summary>
        /// Abortara todos los hilos de la lista mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                {
                    item.Abort();
                }
            }
        }
    }
}
