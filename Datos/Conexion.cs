using MySql.Data.MySqlClient;

namespace proyectoClub
{
    internal static class Conexion
    {
        // cadena de conexion a la base, si cambia algo se modifica solo aca
        private const string CadenaConexion = "user=admindsoo;host=164.152.243.176;port=1080;database=dsoo;pwd=ClaVeGenerica21";

        public static MySqlConnection Obtener()
        {
            return new MySqlConnection(CadenaConexion);
        }
    }
}