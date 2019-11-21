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
        private static SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        private static SqlCommand comando = new SqlCommand();

        static PaqueteDAO()
        {
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO.comando.CommandText = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES("+"'"+p.DireccionEntrega+"','"+p.DireccionEntrega+"','Carlos Castro)";
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
                
            }finally
            {
                if(PaqueteDAO.conexion.State==ConnectionState.Open)
                {
                    PaqueteDAO.conexion.Close();
                }
            }
            return true;
        }
    }
}
