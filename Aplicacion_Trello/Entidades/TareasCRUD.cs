using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Trello.Entidades
{
    public class TareasCRUD
    {
        //Agregar la variable connectionString con la cadena de conexión a la base de datos
        private static readonly string connectionString = "Server=10.0.2.2;UserId=root1;Password=21021192;Port=3306;Database=ClassroomDB;";

        //Lee todas las tareas almacenadas por estado
        public static List<Tareas> ObtenerTareasPorEstado(string estadoDeseado)
        {
            List<Tareas> listaTareas = new List<Tareas>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Tareas WHERE Estado = @Estado";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Estado", estadoDeseado);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaTareas.Add(new Tareas
                                {
                                    Id = reader.GetInt32("Id"),
                                    Titulo = reader.GetString("Titulo"),
                                    Materia = reader.GetString("Materia"),
                                    Descripcion = reader.GetString("Descripcion"),
                                    Fecha_Asignacion = reader.GetDateTime("Fecha_Asignacion"),
                                    Fecha_entrega = reader.GetDateTime("Fecha_Entrega"),
                                    Estado = reader.GetString("Estado")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener tareas por estado: {ex.Message}");
                }
            }
            return listaTareas;
        }


        //Lee todas las tareas almacenadas en la base de datos.
        public static List<Tareas> ObtenerTareas()
        {
            List<Tareas> listaTareas = new List<Tareas>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Tareas";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaTareas.Add(new Tareas
                            {
                                Id = reader.GetInt32("Id"),
                                Titulo = reader.GetString("Titulo"),
                                Materia = reader.GetString("Materia"),
                                Descripcion = reader.GetString("Descripcion"),
                                Fecha_Asignacion = reader.GetDateTime("Fecha_Asignacion"),
                                Fecha_entrega = reader.GetDateTime("Fecha_Entrega"),
                                Estado = reader.GetString("Estado")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener tareas: {ex.Message}");
                }
            }
            return listaTareas;
        }

        //Insertar nuevas tareas en la base de datos.
        public static bool InsertarTarea(Tareas tarea)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Tareas (Titulo, Materia, Descripcion, Fecha_Asignacion, Fecha_Entrega, Estado) VALUES (@Titulo, @Materia, @Descripcion, @Fecha_Asignacion, @Fecha_Entrega, @Estado)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        cmd.Parameters.AddWithValue("@Materia", tarea.Materia);
                        cmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                        cmd.Parameters.AddWithValue("@Fecha_Asignacion", tarea.Fecha_Asignacion);
                        cmd.Parameters.AddWithValue("@Fecha_Entrega", tarea.Fecha_entrega);
                        cmd.Parameters.AddWithValue("@Estado", tarea.Estado);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al insertar tarea: {ex.Message}");
                    return false;
                }
            }
        }

        //Actualiza los datos de una tarea específica.
        public static bool ActualizarTarea(Tareas tarea)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Tareas SET Titulo=@Titulo, Materia=@Materia, Descripcion=@Descripcion, Fecha_Asignacion=@Fecha_Asignacion, Fecha_Entrega=@Fecha_Entrega, Estado=@Estado WHERE Id=@Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        cmd.Parameters.AddWithValue("@Materia", tarea.Materia);
                        cmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                        cmd.Parameters.AddWithValue("@Fecha_Asignacion", tarea.Fecha_Asignacion);
                        cmd.Parameters.AddWithValue("@Fecha_Entrega", tarea.Fecha_entrega);
                        cmd.Parameters.AddWithValue("@Estado", tarea.Estado);
                        cmd.Parameters.AddWithValue("@Id", tarea.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar tarea: {ex.Message}");
                    return false;
                }
            }
        }

        //Elimina una tarea de la base de datos.
        public static bool EliminarTarea(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Tareas WHERE Id=@Id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar tarea: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
