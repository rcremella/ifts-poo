using MySql.Data.MySqlClient;

namespace proyectoClub
{
    public class Usuario
    {
        private readonly MySqlConnection _conexion;

        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }

        public string nombreReal = "";
        public string apellidoReal = "";
        public string funcionReal = "";

        public Usuario(MySqlConnection conexion, string nombre, string clave)
        {
            _conexion = conexion;
            NombreUsuario = nombre;
            ClaveUsuario = clave;
        }

        public bool ValidarLogin()
        {
            try
            {
                _conexion.Open();

                string query = "SELECT nombre, apellido, funcion FROM usuario " +
                               "WHERE nombreUsuario=@user AND clave=@pass";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@user", NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", ClaveUsuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // si devuelve una fila el usuario y la clave son correctos
                    nombreReal = reader["nombre"].ToString() ?? "";
                    apellidoReal = reader["apellido"].ToString() ?? "";
                    funcionReal = reader["funcion"].ToString() ?? "";

                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ValidarLogin: " + ex.Message);
                return false;
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }
    }
}