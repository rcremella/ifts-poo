using MySql.Data.MySqlClient;

namespace proyectoClub
{
    internal class Persona
    {
        protected readonly MySqlConnection _conexion;

        public int _documento { get; set; }
        public int _id = 0;

        protected string _nombre = "";
        protected string _apellido = "";
        private string _telefono = "";

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        public Persona(MySqlConnection conexion, int documento)
        {
            _documento = documento;
            _conexion = conexion;
        }


        public bool validarExistencia()
        {

            try
            {
                _conexion.Open();

                string query = "SELECT * FROM persona WHERE documento=@documento";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@documento", _documento.ToString());

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Hay fila → el usuario existe y la clave es correcta
                    _id = (int)reader["id"];
                    _nombre = reader["nombre"].ToString() ?? "";
                    _apellido = reader["apellido"].ToString() ?? "";
                    _telefono = reader["telefono"].ToString() ?? "";

                    Console.WriteLine(_nombre);

                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ValidarLogin: " + ex.Message);
                return false;
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }


        public virtual string ObtenerDescripcion()
        {
            return "Persona: " + _nombre + " " + _apellido;
        }

        public bool verificarDatosCompletos()
        {
            if (string.IsNullOrWhiteSpace(_apellido) || string.IsNullOrWhiteSpace(_nombre) || string.IsNullOrWhiteSpace(_telefono))
            {
                return false;
            }
            return true;
        }

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


                //MySqlDataReader reader = cmd.ExecuteReader();
                int filas = cmd.ExecuteNonQuery();

                if (filas == 1)
                {
                    _id = (int)cmd.LastInsertedId; // id de la persona recién creada, lo usa Socio para la tabla cliente
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
