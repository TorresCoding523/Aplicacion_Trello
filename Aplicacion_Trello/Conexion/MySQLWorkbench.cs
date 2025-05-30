using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Trello.Conexion
{
    public static class MySQLWorkbench
    {
        private static readonly string connectionString = "Server=10.0.2.2;UserId=root1;Password=21021192;Port=3306;Database=ClassroomDB;";

        public static (bool isConnected, string message) CheckConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return (true, "Connection successful!");
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"MySQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"General error: {ex.Message}");
            }
        }
    }
}
