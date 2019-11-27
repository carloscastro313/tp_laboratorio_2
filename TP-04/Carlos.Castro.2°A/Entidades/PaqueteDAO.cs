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
        
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO._comando.CommandText = String.Format("INSERT INTO[correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES('{0}','{1}','Carlos Castro')", p.DireccionEntrega, p.TrackingID);
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();

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
            return true;
        }
    }
}
