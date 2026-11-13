using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // clase base: tiene los datos y metodos que comparte cualquier persona del club
    internal class Persona
    {
        // protected: tambien lo puede usar Socio
        protected readonly MySqlConnection _conexion;

        public int _documento { get; set; }
        public int _id = 0; // 0 significa que todavia no se cargo o no existe en la base

        // atributos privados/protegidos, afuera se accede por las propiedades de abajo (encapsulamiento)
        protected string _nombre = "";
        protected string _apellido = "";
        private string _telefono = "";

        public string _tipo = ""; // socio o no_socio, lo uso para mostrarlo en el mensaje de validacion


        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        public string tipo { get { return _tipo; } set { _tipo = value; } }

        // el constructor recibe la conexion y el dni, el resto de los datos se cargan despues
        public Persona(MySqlConnection conexion, int documento)
        {
            _documento = documento;
            _conexion = conexion;
        }


        // busca el dni en la tabla persona, devuelve true si existe (y carga sus datos)
        public virtual bool validarExistencia()
        {
            try
            {
                _conexion.Open();

                string query = "select p.*, c.id, id_persona, importe, 'socio' as tipo , c2.id as carnet , c2.emitido as emitido " +
                                "from cliente c " +
                                "inner join persona p on p.id = c.id_persona " +
                                "inner join carnet c2 on c.id = c2.id_cliente where p.documento = @documento " +
                                "union all " +
                                "select p.*, nc.id, id_persona, importe, 'no_socio' as tipo , null, null from no_cliente nc " +
                                "inner join persona p on p.id = nc.id_persona where p.documento = @documento";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                // usar @parametros evita la inyeccion SQL
                cmd.Parameters.AddWithValue("@documento", _documento.ToString());

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // si la encuentra cargo los datos de la persona
                    _id = Convert.ToInt32(reader["id"]);
                    _nombre = reader["nombre"].ToString() ?? "";
                    _apellido = reader["apellido"].ToString() ?? "";
                    _telefono = reader["telefono"].ToString() ?? "";
                    _tipo = reader["tipo"].ToString() ?? "";



                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                // si falla la base lo muestro por consola y devuelvo false para que el programa no se caiga
                Console.WriteLine("Error en validarExistencia: " + ex.Message);
                return false;
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
                cmd.Parameters.AddWithValue("@documento", _documento);

                // devuelve cuantas filas se insertaron
                int filas = cmd.ExecuteNonQuery();

                if (filas == 1)
                {
                    _id = (int)cmd.LastInsertedId; // guardo el id para despues cargarlo en cliente
                    Console.WriteLine("insertado correctamente");

                    return true;
                }

                Console.WriteLine("Error en insertar");

                return false;
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
