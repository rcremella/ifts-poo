using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona: una persona que usa el club sin ser socio (no tiene carnet ni vencimiento)
    internal class noSocio : Persona
    {
        // base(...) llama al constructor de Persona
        public noSocio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un no socio
        public override string ObtenerDescripcion()
        {
            return "No Socio: " + _nombre + " " + _apellido;
        }

        // override de Persona: guarda al no socio en la tabla no_cliente
        // va despues de registrarPersona porque usa su Id
        public override bool registrarCliente()
        {
            // la transaccion agrupa las 2 escrituras: o se guardan las dos o ninguna
            MySqlTransaction? transaccion = null;

            try
            {
                _conexion.Open();
                transaccion = _conexion.BeginTransaction();

                // el importe del no socio se toma de la tabla precio
                string query = "INSERT INTO no_cliente(id_persona, importe) " +
                    "values (@id_persona, (select importe from precio where detalle = 'no_socio'))";

                MySqlCommand cmd = new MySqlCommand(query, _conexion, transaccion);
                cmd.Parameters.AddWithValue("@id_persona", Id);

                // el apto fisico se guarda en persona, va en un comando aparte
                // (si fueran los dos juntos ExecuteNonQuery sumaria las filas de ambos y nunca daria 1)
                string queryUpdate = "UPDATE persona SET apto_fisico = @apto_fisico WHERE id = @id_persona";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, _conexion, transaccion);
                cmdUpdate.Parameters.AddWithValue("@apto_fisico", AptoFisico);
                cmdUpdate.Parameters.AddWithValue("@id_persona", Id);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                if (filas == 1)
                {
                    transaccion.Commit(); // confirma los 2 cambios juntos
                    return true;
                }

                transaccion.Rollback();
                return false;
            }
            catch (Exception)
            {
                // si algo fallo deshago lo que se haya guardado
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
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
