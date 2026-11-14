using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // clase base: tiene los datos y metodos que comparte cualquier persona del club
    internal class Persona
    {
        // protected: tambien lo puede usar Socio
        protected readonly MySqlConnection _conexion;

        // desde afuera solo se leen: el documento se fija en el constructor y el id lo cargan las consultas
        public int Documento { get; private set; }
        public int Id { get; protected set; } // 0 significa que todavia no se cargo o no existe en la base

        // hasta cuando tiene paga la cuota (solo socios), null si nunca pago
        public DateTime? FechaVto { get; private set; }

        // atributos privados/protegidos, afuera se accede por las propiedades de abajo (encapsulamiento)
        protected string _nombre = "";
        protected string _apellido = "";
        private string _telefono = "";

        private string _tipo = ""; // socio o no_socio, lo uso para mostrarlo en el mensaje de validacion

        // el apto fisico esta en la tabla persona, asi que lo tienen tanto socios como no socios
        private bool _aptoFisico = false;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        public string tipo { get { return _tipo; } set { _tipo = value; } }

        public bool AptoFisico { get { return _aptoFisico; } set { _aptoFisico = value; } }

        // el constructor recibe la conexion y el dni, el resto de los datos se cargan despues
        public Persona(MySqlConnection conexion, int documento)
        {
            Documento = documento;
            _conexion = conexion;
        }


        // busca el dni en la tabla persona, devuelve true si existe (y carga sus datos)
        public virtual bool validarExistencia()
        {
            try
            {
                _conexion.Open();

                // busca en las dos tablas (socios y no socios), como el documento es unico solo va a traer una fila
                string query = "select p.id, p.nombre, p.apellido, p.documento, p.telefono, p.apto_fisico, 'socio' as tipo, c.fechaVto as fecha_vto from cliente c " +
                                "inner join persona p on p.id = c.id_persona where p.documento = @documento " +
                                "union all " +
                                "select p.id, p.nombre, p.apellido, p.documento, p.telefono, p.apto_fisico, 'no_socio' as tipo, null as fecha_vto from no_cliente nc " +
                                "inner join persona p on p.id = nc.id_persona where p.documento = @documento";

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
                    _telefono = reader["telefono"].ToString() ?? "";
                    _tipo = reader["tipo"].ToString() ?? "";

                    // DBNull = campo vacio en la base, en ese caso queda en false
                    if (reader["apto_fisico"] != DBNull.Value)
                    {
                        _aptoFisico = Convert.ToBoolean(reader["apto_fisico"]);
                    }

                    // solo los socios tienen vencimiento, si nunca pago o es no socio queda en null
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
                // si devolviera false se confundiria con "la persona no existe"
                throw;
            }
            finally
            {
                // finally se ejecuta siempre, haya error o no
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }


        // virtual: Socio lo puede cambiar con override
        public virtual string ObtenerDescripcion()
        {
            return "Persona: " + _nombre + " " + _apellido;
        }

        // virtual: cada tipo de persona guarda sus datos en su propia tabla (Socio en cliente, noSocio en no_cliente)
        // en Persona no hace nada porque una persona sola no es cliente
        public virtual bool registrarCliente()
        {
            return false;
        }

        // devuelve false si falta nombre, apellido o telefono (IsNullOrWhiteSpace tambien detecta solo espacios)
        public bool verificarDatosCompletos()
        {
            if (string.IsNullOrWhiteSpace(_apellido) || string.IsNullOrWhiteSpace(_nombre) || string.IsNullOrWhiteSpace(_telefono))
            {
                return false;
            }
            return true;
        }

        // inserta la persona en la base, devuelve true si se guardo bien
        public bool registrarPersona()
        {
            try
            {
                _conexion.Open();

                string query = "INSERT INTO persona(nombre, apellido, telefono, documento) values (@nombre, @apellido, @telefono, @documento)";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@nombre", _nombre);
                cmd.Parameters.AddWithValue("@apellido", _apellido);
                cmd.Parameters.AddWithValue("@telefono", _telefono);
                cmd.Parameters.AddWithValue("@documento", Documento);

                // devuelve cuantas filas se insertaron
                int filas = cmd.ExecuteNonQuery();

                if (filas == 1)
                {
                    Id = (int)cmd.LastInsertedId; // guardo el id para despues cargarlo en cliente

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
