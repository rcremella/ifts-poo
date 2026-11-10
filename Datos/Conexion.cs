using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // clase estatica: no hace falta crear objetos, se usa directo con Conexion.Obtener()
    internal static class Conexion
    {
        // la cadena de conexion se lee de los user secrets (ver README)
        private static string? cadenaConexion;

        // devuelve una conexion nueva (sin abrir), cada clase la abre y la cierra cuando la necesita
        public static MySqlConnection Obtener()
        {
            // ??= la lee solo la primera vez
            cadenaConexion ??= LeerCadenaConexion();
            return new MySqlConnection(cadenaConexion);
        }

        // busca la cadena en los user secrets y, si no esta, en las variables de entorno
        private static string LeerCadenaConexion()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Conexion).Assembly)
                .AddEnvironmentVariables()
                .Build();

            var cadena = config.GetConnectionString("Club");

            // sin cadena no se puede seguir, por eso se corta con una excepcion
            if (string.IsNullOrEmpty(cadena))
                throw new InvalidOperationException("Falta ConnectionStrings:Club en los secretos de usuario.");
            return cadena;
        }
    }
}
