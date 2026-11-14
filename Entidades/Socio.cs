using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona
    internal class Socio : Persona
    {
        // atributos propios de Socio, Persona no los tiene
        private string _carnet = "";

        public string Carnet { get { return _carnet; } set { _carnet = value; } }

        // true si el carnet ya se entrego (campo emitido de la tabla carnet)
        private bool _emitido = false;

        public bool Emitido { get { return _emitido; } set { _emitido = value; } }

        // fecha en que se entrego el carnet, null si todavia no se entrego
        private DateTime? _fechaEntrega = null;

        public DateTime? FechaEntrega { get { return _fechaEntrega; } set { _fechaEntrega = value; } }

        // base(...) llama al constructor de Persona
        public Socio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un socio
        public override string ObtenerDescripcion()
        {
            return "Socio: " + _nombre + " " + _apellido;
        }

        // override de Persona: guarda al socio en la tabla cliente y le crea el carnet
        // va despues de registrarPersona porque usa su Id
        public override bool registrarCliente()
        {
            // la transaccion agrupa las 3 escrituras: o se guardan todas o no se guarda ninguna
            MySqlTransaction? transaccion = null;

            try
            {
                _conexion.Open();
                transaccion = _conexion.BeginTransaction();

                string query = "INSERT INTO cliente(id_persona, tipo) values (@id_persona, 'socio')";

                MySqlCommand cmd = new MySqlCommand(query, _conexion, transaccion);
                cmd.Parameters.AddWithValue("@id_persona", Id);

                string queryUpdate = "UPDATE persona SET apto_fisico = @apto_fisico WHERE id = @id_persona";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, _conexion, transaccion);
                cmdUpdate.Parameters.AddWithValue("@apto_fisico", AptoFisico);
                cmdUpdate.Parameters.AddWithValue("@id_persona", Id);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                // el carnet necesita el id del cliente que se acaba de insertar
                int idCliente = (int)cmd.LastInsertedId;
                string queryCarnet = "INSERT INTO carnet(id_cliente) values (@id_cliente)";

                MySqlCommand cmdCarnet = new MySqlCommand(queryCarnet, _conexion, transaccion);
                cmdCarnet.Parameters.AddWithValue("@id_cliente", idCliente);
                int filasCarnet = cmdCarnet.ExecuteNonQuery();

                if (filas == 1 && filasCarnet == 1)
                {
                    transaccion.Commit(); // confirma los 3 cambios juntos
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

        // busca al socio con su carnet (solo lo usa FrmEntregarCarnet)
        // no es override: validarExistencia de Persona sigue buscando en socios y no socios
        public bool validarCarnet()
        {
            try
            {
                _conexion.Open();

                string query = "select p.id, p.nombre, p.apellido, 'socio' as tipo, ca.id as carnet, ca.emitido, ca.fecha_entrega, c.fechaVto as fecha_vto from cliente c " +
                                "inner join persona p on p.id = c.id_persona " +
                                "inner join carnet ca on c.id = ca.id_cliente " +
                                "where p.documento = @documento ";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                // usar @parametros evita la inyeccion SQL
                cmd.Parameters.AddWithValue("@documento", Documento.ToString());

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // si la encuentra cargo los datos de la persona
                    Id = Convert.ToInt32(reader["id"]);
                    _nombre = reader["nombre"].ToString() ?? "";
                    _apellido = reader["apellido"].ToString() ?? "";
                    tipo = reader["tipo"].ToString() ?? "";
                    _carnet = reader["carnet"].ToString() ?? "";
                    // DBNull = campo vacio en la base, en ese caso queda en false
                    _emitido = reader["emitido"] != DBNull.Value && Convert.ToBoolean(reader["emitido"]);

                    if (reader["fecha_entrega"] != DBNull.Value)
                    {
                        _fechaEntrega = Convert.ToDateTime(reader["fecha_entrega"]);
                    }

                    // si nunca pago el vencimiento queda en null
                    if (reader["fecha_vto"] != DBNull.Value)
                    {
                        FechaVto = Convert.ToDateTime(reader["fecha_vto"]);
                    }

                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch (Exception)
            {
                // lo relanzo para que el formulario avise que fallo la base
                // si devolviera false se confundiria con "el socio no tiene carnet"
                throw;
            }
            finally
            {
                // finally se ejecuta siempre, haya error o no
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }

        // la cuota esta activa si el vencimiento es hoy o una fecha futura
        // si nunca pago (null) o ya vencio, no esta activa
        // va despues de validarCarnet porque usa su FechaVto
        public bool CuotaActiva()
        {
            return FechaVto != null && FechaVto.Value.Date >= DateTime.Today;
        }

        // marca el carnet como entregado con la fecha de hoy, devuelve true si se guardo bien
        // solo se entrega si la cuota esta activa (si no, la consulta no encuentra el cliente y no cambia nada)
        // va despues de validarCarnet porque usa su Id
        public bool entregarCarnet()
        {
            try
            {
                _conexion.Open();

                // el carnet se busca a traves del cliente que corresponde a esta persona
                string query = "UPDATE carnet SET emitido = 1, fecha_entrega = CURDATE() " +
                               "WHERE id_cliente = (SELECT id FROM cliente WHERE id_persona = @id_persona AND fechaVto >= CURDATE())";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", Id);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se actualizo bien
                int filas = cmd.ExecuteNonQuery();

                if (filas == 1)
                {
                    _emitido = true;
                    _fechaEntrega = DateTime.Today;
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
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
