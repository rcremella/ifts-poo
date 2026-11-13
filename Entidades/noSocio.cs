using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona
    internal class noSocio : Persona
    {
        // atributo propio de Socio, Persona no lo tiene
        private bool _aptoFisico = false;

        public bool AptoFisico { get { return _aptoFisico; } set { _aptoFisico = value; } }

        // base(...) llama al constructor de Persona
        public noSocio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un socio
        public override string ObtenerDescripcion()
        {
            return "No Socio: " + _nombre + " " + _apellido;
        }

        // consulta la tabla cliente y guarda en _aptoFisico lo que figura en la base
        public void cargarAptoFisico()
        {
            try
            {
                _conexion.Open();

                string query = "SELECT apto_fisico FROM persona WHERE id=@id_persona";

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

                string query = "INSERT INTO no_cliente(id_persona, importe) " +
                    "values (@id_persona, (select importe from precio where detalle = 'no_socio'));" +
                    "UPDATE persona SET apto_fisico = @apto_fisico WHERE id = @id_persona";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", _id);
                cmd.Parameters.AddWithValue("@apto_fisico", _aptoFisico);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
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
