using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // un pago que hace una persona, se guarda en la tabla pago
    internal class Pago
    {
        // readonly: se asigna una sola vez en el constructor
        private readonly MySqlConnection _conexion;

        private int _idPersona;
        private decimal _importe;
        private string _tipoPago;

        public int IdPersona { get { return _idPersona; } set { _idPersona = value; } }
        public decimal Importe { get { return _importe; } set { _importe = value; } }
        public string TipoPago { get { return _tipoPago; } set { _tipoPago = value; } }

        // el constructor recibe la conexion y los datos del pago
        public Pago(MySqlConnection conexion, int idPersona, decimal importe, string tipoPago)
        {
            _conexion = conexion;
            _idPersona = idPersona;
            _importe = importe;
            _tipoPago = tipoPago;
        }

        // guarda el pago con la fecha de hoy y, si la persona es socio, corre su vencimiento un mes
        // devuelve true si se guardo bien
        public bool registrar()
        {
            // la transaccion agrupa las 2 escrituras: o se guardan las dos o ninguna
            MySqlTransaction? transaccion = null;

            try
            {
                _conexion.Open();
                transaccion = _conexion.BeginTransaction();

                string query = "INSERT INTO pago(id_persona, importe, fecha_pago, tipo_pago) " +
                               "values (@id_persona, @importe, CURDATE(), @tipo_pago)";

                MySqlCommand cmd = new MySqlCommand(query, _conexion, transaccion);
                cmd.Parameters.AddWithValue("@id_persona", _idPersona);
                cmd.Parameters.AddWithValue("@importe", _importe);
                cmd.Parameters.AddWithValue("@tipo_pago", _tipoPago);

                // el vencimiento es la fecha del pago + 1 mes
                // si la persona es no socio no tiene fila en cliente, entonces no se modifica nada
                string queryVto = "UPDATE cliente SET fechaVto = DATE_ADD(CURDATE(), INTERVAL 1 MONTH) " +
                                  "WHERE id_persona = @id_persona";

                MySqlCommand cmdVto = new MySqlCommand(queryVto, _conexion, transaccion);
                cmdVto.Parameters.AddWithValue("@id_persona", _idPersona);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdVto.ExecuteNonQuery();

                if (filas == 1)
                {
                    transaccion.Commit(); // confirma los dos cambios juntos
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
