using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // consulta los precios que figuran en la tabla precio (uno para socios y otro para no socios)
    internal class Precio
    {
        // readonly: se asigna una sola vez en el constructor
        private readonly MySqlConnection _conexion;

        public Precio(MySqlConnection conexion)
        {
            _conexion = conexion;
        }

        // busca el importe segun el tipo de persona ("socio" o "no_socio")
        // devuelve null si no hay precio cargado o si falla la base
        public decimal? obtenerImporte(string tipo)
        {
            try
            {
                _conexion.Open();

                string query = "SELECT importe FROM precio WHERE detalle = @detalle";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@detalle", tipo);

                MySqlDataReader reader = cmd.ExecuteReader();

                decimal? importe = null;

                // DBNull = campo vacio en la base
                if (reader.Read() && reader["importe"] != DBNull.Value)
                {
                    importe = Convert.ToDecimal(reader["importe"]);
                }

                reader.Close();
                return importe;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }
    }
}
