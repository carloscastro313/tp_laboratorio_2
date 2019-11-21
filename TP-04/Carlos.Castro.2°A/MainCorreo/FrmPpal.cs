using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            this.Text = "Correo UTN por Carlos.Castro.2°A";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.mtxtTrackingID.Text, this.txtDireccion.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {

                MessageBox.Show(ex.Message);
            } finally
            {
                this.ActualizarEstado();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            correo.FinEntregas();
        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            } else
            {
                this.ActualizarEstado();
            }
        }

        private void ActualizarEstado()
        {

            this.lstEstadoIngresdo.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {

                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresdo.Items.Add((object)item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add((object)item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add((object)item);
                        break;
                    default:
                        break;
                }
            }
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if ((object)elemento != null)
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
              this.rtbMostrar.Text.Guardar("salida.txt");
        }
            
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);

        }
    }
}
