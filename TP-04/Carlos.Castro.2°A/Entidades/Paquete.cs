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

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.trackingID = trackingID;
            this.direccionEntrega = direccionEntrega;
            this.estado = EEstado.Ingresado;
        }

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

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return string.Format("{0} para {1}", (object)paquete.trackingID, (object)paquete.direccionEntrega);
        }

        public override string ToString()
        {
            
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
