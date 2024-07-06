using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AccesoDatos
    {
        static MySqlCommand command;
        static MySqlConnection connection;
        static string connectionString;

        //Constructores
        static AccesoDatos()
        {
            connectionString = $"Server=localhost; Database=escuela; User ID=root; Password=; SslMode=none;";
            connection = new MySqlConnection(connectionString);
        }

        public static bool Guardar(string mensajeReparacion)
        {
            bool resultado;
            resultado = false;

            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO alumnos(mensaje, alumno)" +
                    $"VALUES(@mensaje,@alumno)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@mensaje", mensajeReparacion);
                command.Parameters.AddWithValue("@alumno", "Natalia");
                command.ExecuteNonQuery();
                resultado = true;
            }

            return resultado;
        }

    }
}
