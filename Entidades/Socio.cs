using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // hereda de Persona
    internal class Socio : Persona
    {
        // atributo propio de Socio, Persona no lo tiene
        private bool _aptoFisico = false;
        private decimal _importe = 0; // atributo propio de Socio, Persona no lo tiene

        private string _carnet = ""; // atributo propio de Socio, Persona no lo tiene

        private bool _carnetEntregado = false; // atributo propio de Socio, Persona no lo tiene

        public bool AptoFisico { get { return _aptoFisico; } set { _aptoFisico = value; } }
        public decimal Importe { get { return _importe; } set { _importe = value; } }
        public string Carnet { get { return _carnet; } set { _carnet = value; } }
        public bool CarnetEntregado { get { return _carnetEntregado; } set { _carnetEntregado = value; } }  

        // base(...) llama al constructor de Persona
        public Socio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un socio
        public override string ObtenerDescripcion()
        {
            return "Socio: " + _nombre + " " + _apellido;
        }


        public override bool validarExistencia()
        {
            try
            {
                _conexion.Open();

                string query = "select p.*, c.id, id_persona, importe, 'socio' as tipo , c2.id as carnet , c2.emitido as emitido " +
                                "from cliente c " +
                                "inner join persona p on p.id = c.id_persona " +
                                "inner join carnet c2 on c.id = c2.id_cliente where p.documento = @documento ";

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
                    // _telefono = reader["telefono"].ToString() ?? "";
                    _importe = reader["importe"] != DBNull.Value ? Convert.ToDecimal(reader["importe"]) : 0;    
                    _tipo = reader["tipo"].ToString() ?? "";
                    _aptoFisico = reader["apto_fisico"] != DBNull.Value && Convert.ToBoolean(reader["apto_fisico"]);
                    _carnet = reader["carnet"].ToString() ?? "";
                    _carnetEntregado = reader["emitido"] != DBNull.Value && Convert.ToBoolean(reader["emitido"]);

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





        // consulta la tabla cliente y guarda en _aptoFisico lo que figura en la base
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
