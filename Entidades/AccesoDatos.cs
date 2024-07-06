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
        static SqlCommand command;
        static SqlConnection connection;
        static string connectionString;

        //Constructores
        static AccesoDatos()
        {

        }

        public static bool Guardar()
        {
            bool resultado;
            resultado = false;

            return resultado;
        }

    }
}
