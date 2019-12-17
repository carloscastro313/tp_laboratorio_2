using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comando;
        #region Constructores
        /// <summary>
        /// Construtor estatico que Incializa _conexion y _comando
        /// </summary>
        static PaqueteDAO()
        {
            _conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            _comando = new SqlCommand();
        }
        #endregion

        /// <summary>
        /// Ingresa datos a la tabla Pequetes de la base de datos correo-sp-2017
        /// ATENCION = Se debe agregar una Conexion en las propiedades de Entidades para que esto funcione
        /// </summary>
        /// <param name="p">
        /// Paquete que se va a ingresar a la base de datos
        /// </param>
        /// <returns>
        /// TRUE = Cuando hay exito al insertar los datos
        /// FALSE = Error al conectarse a la base de datos
        /// </returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            _comando.CommandType = CommandType.Text;
            _comando.CommandText = String.Format("INSERT INTO[correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES('{0}','{1}','Carlos Castro')", p.DireccionEntrega, p.TrackingID);
            _comando.Connection = _conexion;

            try
            {
                _conexion.Open();
                _comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(_conexion.State==ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            return retorno;
        }
    }
}
