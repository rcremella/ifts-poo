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

        // hasta cuando queda paga la cuota despues de registrar el pago (null si es no socio)
        public DateTime? NuevoVencimiento { get; private set; }

        // el constructor recibe la conexion y los datos del pago
        public Pago(MySqlConnection conexion, int idPersona, decimal importe, string tipoPago)
        {
            _conexion = conexion;
            _idPersona = idPersona;
            _importe = importe;
            _tipoPago = tipoPago;
        }

        // guarda el pago con la fecha de hoy y, si la persona es socio, le suma un mes a su vencimiento
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

                // el pago es por adelantado: se suma 1 mes al vencimiento que ya tiene, asi no pierde dias
                // si ya estaba vencido o nunca pago (null) el mes se cuenta desde hoy
                // GREATEST se queda con la fecha mayor, COALESCE reemplaza el null por hoy
                // si la persona es no socio no tiene fila en cliente, entonces no se modifica nada
                string queryVto = "UPDATE cliente SET fechaVto = DATE_ADD(GREATEST(COALESCE(fechaVto, CURDATE()), CURDATE()), INTERVAL 1 MONTH) " +
                                  "WHERE id_persona = @id_persona";

                MySqlCommand cmdVto = new MySqlCommand(queryVto, _conexion, transaccion);
                cmdVto.Parameters.AddWithValue("@id_persona", _idPersona);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdVto.ExecuteNonQuery();

                if (filas == 1)
                {
                    // leo el vencimiento nuevo antes de confirmar, para mostrarlo en el formulario
                    MySqlCommand cmdLeer = new MySqlCommand("SELECT fechaVto FROM cliente WHERE id_persona = @id_persona", _conexion, transaccion);
                    cmdLeer.Parameters.AddWithValue("@id_persona", _idPersona);
                    object? vto = cmdLeer.ExecuteScalar();

                    transaccion.Commit(); // confirma los dos cambios juntos

                    // ExecuteScalar devuelve null si no hay fila (no socio) o DBNull si el campo esta vacio
                    if (vto != null && vto != DBNull.Value)
                    {
                        NuevoVencimiento = Convert.ToDateTime(vto);
                    }
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
