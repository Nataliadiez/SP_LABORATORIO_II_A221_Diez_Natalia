using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Entidades
{
    public static class AccesoDatos
    {
        static MySqlCommand command;
        static MySqlConnection connection;
        static string connectionString;

        // Constructor estático para inicializar la cadena de conexión
        static AccesoDatos()
        {
            connectionString = $"Server=localhost; Database=escuela; User ID=root; Password=; SslMode=none;";
        }

        /// <summary>
        /// Guarda un mensaje de reparación en la base de datos.
        /// </summary>
        /// <param name="mensajeReparacion">Mensaje de reparación a guardar.</param>
        /// <returns>True si se guardó correctamente, False si ocurrió un error.</returns>
        public static bool Guardar(string mensajeReparacion)
        {
            bool resultado;
            resultado = false;

            connection = new MySqlConnection(connectionString);
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

        /// <summary>
        /// Guarda un barco en la base de datos.
        /// </summary>
        /// <param name="barco">Barco a guardar.</param>
        /// <returns>True si se guardó correctamente, False si ocurrió un error.</returns>
        public static bool GuardarBarcos(Barco barco)
        {
            bool resultado;
            resultado = false;
            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO taller (nombre, costo, tipo, operacion, tripulacion, estado_reparacion)" +
                    " VALUES (@nombre, @costo, @tipo, @operacion, @tripulacion, @estado_reparacion)";

                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", barco.Nombre);
                command.Parameters.AddWithValue("@costo", barco.Costo);
                command.Parameters.AddWithValue("@tipo", barco is Pirata ? "Pirata" : "Marina");
                command.Parameters.AddWithValue("@operacion", barco.Operacion.ToString());
                command.Parameters.AddWithValue("@tripulacion", barco.Tripulacion);
                command.Parameters.AddWithValue("@estado_reparacion", barco.EstadoReparado);
                command.ExecuteNonQuery();
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene todos los barcos almacenados en la base de datos.
        /// </summary>
        /// <returns>Lista de barcos obtenidos.</returns>
        public static List<Barco> SeleccionarBarcos()
        {
            List<Barco> listaBarcos = new List<Barco>();

            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "SELECT * FROM taller";
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    float costo = reader.GetFloat("costo");
                    bool estado = reader.GetBoolean("estado_reparacion");
                    string nombre = reader.GetString("nombre");
                    string operacionStr = reader.GetString("operacion");
                    int tripulacion = reader.GetInt32("tripulacion");
                    string tipo = reader.GetString("tipo");

                    if (Enum.TryParse<EOperacion>(operacionStr, out EOperacion operacion))
                    {
                        Barco barco = null;
                        if (tipo == "Pirata")
                        {
                            barco = new Pirata(costo, estado, nombre, operacion, tripulacion);
                        }
                        else if (tipo == "Marina")
                        {
                            barco = new Marina(costo, estado, nombre, operacion, tripulacion);
                        }
                        if (barco != null)
                        {
                            listaBarcos.Add(barco);
                        }
                    }
                }
            }

            return listaBarcos;
        }

        /// <summary>
        /// Modifica los datos de un barco en la base de datos.
        /// </summary>
        /// <param name="barco">Barco con los datos actualizados.</param>
        /// <returns>True si se modificó correctamente, False si ocurrió un error.</returns>
        public static bool ModificarBarcos(Barco barco)
        {
            bool resultado = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE taller SET nombre = @nombre, costo = @costo, operacion = @operacion, tripulacion = @tripulacion, estado_reparacion = @estado_reparacion " +
                               "WHERE nombre = @nombre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", barco.Nombre);
                    command.Parameters.AddWithValue("@costo", barco.Costo);
                    command.Parameters.AddWithValue("@operacion", barco.Operacion.ToString());
                    command.Parameters.AddWithValue("@tripulacion", barco.Tripulacion);
                    command.Parameters.AddWithValue("@estado_reparacion", barco.EstadoReparado);
                    command.ExecuteNonQuery();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un barco de la base de datos según su nombre.
        /// </summary>
        /// <param name="nombre">Nombre del barco a eliminar.</param>
        /// <returns>True si se eliminó correctamente, False si ocurrió un error.</returns>
        public static bool EliminarBarco(string nombre)
        {
            bool resultado;
            resultado = false;
            connection = new MySqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string query = "DELETE FROM taller WHERE nombre = @nombre";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.ExecuteNonQuery();
            }

            return resultado;
        }
    }
}
