using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event Paquete.DelegadoEstado InformaEstado;

        #region Propiedades
        /// <summary>
        /// 
        /// Propiedad que devuelve y establese un valor a la direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve y establese un valor al estado de paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve y le da valor al atributo trackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor parametrizado que establese los valores de trackingID, direccionEntrega y estado, este ultimo siempre estableciendolo como Ingresado
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.trackingID = trackingID;
            this.direccionEntrega = direccionEntrega;
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que duerme por 4 segundo a Thread para despues cambiar el estado del paquete y llama al evento InformaEstado
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                ++this.estado;
                this.InformaEstado((object)this, new EventArgs());
            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Metodo que devuelve la informacion del paquete en string
        /// </summary>
        /// <param name="elemento">
        /// Es el elemento el cual se va a mostrar
        /// </param>
        /// <returns>
        /// La informacion del elemento
        /// </returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return string.Format("{0} para {1}", paquete.trackingID, paquete.direccionEntrega);
        }

        /// <summary>
        /// Sobrecarga de ToString()
        /// </summary>
        /// <returns>
        /// Devuelve los datos del paquete
        /// </returns>
        public override string ToString()
        {      
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Operador == que compara el trackingID dos paquetes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>
        /// TRUE si la id es igual y FALSE en caso contrario
        /// </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Operador == que compara el trackingID dos paquetes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>
        /// FALSE si la id es igual y TRUE en caso contrario
        /// </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
