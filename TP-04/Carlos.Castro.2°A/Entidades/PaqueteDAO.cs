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
        private static SqlConnection _conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        private static SqlCommand _comando = new SqlCommand();

        static PaqueteDAO()
        {
            PaqueteDAO._comando.CommandType = CommandType.Text;
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
        }
        /// <summary>
        /// Ingresa datos a la tabla Pequetes de la base de datos correo-sp-2017
        /// ATENCION = Se debe agregar una Conexion en las propiedades de Entidades para que esto funcione
        /// </summary>
        /// <param name="p"></param>
        /// <returns>
        /// TRUE = Cuando hay exito al insertar los datos
        /// FALSE = Error al conectarse a la base de datos
        /// </returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                PaqueteDAO._comando.CommandText = String.Format("INSERT INTO[correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES('{0}','{1}','Carlos Castro')", p.DireccionEntrega, p.TrackingID);
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception e)
            {
                throw e;
                
            }finally
            {
                if(PaqueteDAO._conexion.State==ConnectionState.Open)
                {
                    PaqueteDAO._conexion.Close();
                }
            }
            return retorno;
        }
    }
}
