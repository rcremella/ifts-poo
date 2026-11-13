using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona
    internal class noSocio : Persona
    {
        // base(...) llama al constructor de Persona
        public noSocio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un socio
        public override string ObtenerDescripcion()
        {
            return "No Socio: " + _nombre + " " + _apellido;
        }

        // va despues de registrarPersona porque usa su _id
        public bool registrarCliente()
        {
            try
            {
                _conexion.Open();

                // el importe del no socio se toma de la tabla precio
                string query = "INSERT INTO no_cliente(id_persona, importe) " +
                    "values (@id_persona, (select importe from precio where detalle = 'no_socio'))";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", _id);

                // el apto fisico se guarda en persona, va en un comando aparte
                // (si fueran los dos juntos ExecuteNonQuery sumaria las filas de ambos y nunca daria 1)
                string queryUpdate = "UPDATE persona SET apto_fisico = @apto_fisico WHERE id = @id_persona";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, _conexion);
                cmdUpdate.Parameters.AddWithValue("@apto_fisico", AptoFisico);
                cmdUpdate.Parameters.AddWithValue("@id_persona", _id);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

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
