using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace proyectoClub
{
    internal static class Conexion
    {
        // la cadena de conexion se lee de los user secrets (ver README)
        private static string? cadenaConexion;

        public static MySqlConnection Obtener()
        {
            cadenaConexion ??= LeerCadenaConexion();
            return new MySqlConnection(cadenaConexion);
        }

        private static string LeerCadenaConexion()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Conexion).Assembly)
                .AddEnvironmentVariables()
                .Build();

            var cadena = config.GetConnectionString("Club");
            if (string.IsNullOrEmpty(cadena))
                throw new InvalidOperationException("Falta ConnectionStrings:Club en los secretos de usuario.");
            return cadena;
        }
    }
}
