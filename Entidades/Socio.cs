using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona
    internal class Socio : Persona
    {
        private bool _aptoFisico = false;

        public bool AptoFisico { get { return _aptoFisico; } set { _aptoFisico = value; } }

        // base(...) llama al constructor de Persona
        public Socio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        public override string ObtenerDescripcion()
        {
            return "Socio: " + _nombre + " " + _apellido;
        }

        public void cargarAptoFisico()
        {
            try
            {
                _conexion.Open();

                string query = "SELECT apto_fisico FROM cliente WHERE id_persona=@id_persona";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", _id);

                MySqlDataReader reader = cmd.ExecuteReader();

                // DBNull = campo vacio en la base
                if (reader.Read() && reader["apto_fisico"] != DBNull.Value)
                {
                    _aptoFisico = Convert.ToBoolean(reader["apto_fisico"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }

        // va despues de registrarPersona porque usa su _id
        public bool registrarCliente()
        {
            try
            {
                _conexion.Open();

                string query = "INSERT INTO cliente(id_persona, tipo, apto_fisico) values (@id_persona, 'socio', @apto_fisico)";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", _id);
                cmd.Parameters.AddWithValue("@apto_fisico", _aptoFisico);

                int filas = cmd.ExecuteNonQuery();

                return filas == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
