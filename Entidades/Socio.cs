using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace proyectoClub
{
    // hereda de Persona
    internal class Socio : Persona
    {
        // atributo propio de Socio, Persona no lo tiene
        private bool _aptoFisico = false;

        public bool AptoFisico { get { return _aptoFisico; } set { _aptoFisico = value; } }

        private string _carnet = "";

        public string Carnet { get { return _carnet; } set { _carnet = value; } }

        private string _emitido = "";

        public string Emitido { get { return _emitido; } set { _emitido = value; } }    

        // base(...) llama al constructor de Persona
        public Socio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        // polimorfismo: misma firma que en Persona pero devuelve el texto de un socio
        public override string ObtenerDescripcion()
        {
            return "Socio: " + _nombre + " " + _apellido;
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

                string query = "INSERT INTO cliente(id_persona, tipo) values (@id_persona, 'socio')";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                cmd.Parameters.AddWithValue("@id_persona", _id);

                string queryUpdate = "UPDATE persona SET apto_fisico = @apto_fisico WHERE id = @id_persona";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, _conexion);
                cmdUpdate.Parameters.AddWithValue("@apto_fisico", _aptoFisico);
                cmdUpdate.Parameters.AddWithValue("@id_persona", _id);

                // ExecuteNonQuery devuelve las filas afectadas, si es 1 se inserto bien
                int filas = cmd.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                int idCliente = (int)cmd.LastInsertedId;
                string queryCarnet = "INSERT INTO carnet(id_cliente) values (@id_cliente)";




                MySqlCommand cmdCarnet = new MySqlCommand(queryCarnet, _conexion);
                cmdCarnet.Parameters.AddWithValue("@id_cliente", idCliente);
                int filasCarnet = cmdCarnet.ExecuteNonQuery();




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



        public override bool validarExistencia()
        {
            try
            {
                _conexion.Open();

                string query = "select p.*, c.id, importe, 'socio' as tipo, ca.id as carnet, ca.emitido from cliente c " +
                                "inner join persona p on p.id = c.id_persona " +
                                "inner join carnet ca on c.id = ca.id_cliente " +
                                "where p.documento = @documento ";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);
                // usar @parametros evita la inyeccion SQL
                cmd.Parameters.AddWithValue("@documento", _documento.ToString());

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // si la encuentra cargo los datos de la persona
                    //id = Convert.ToInt32(reader["id"]);
                    _nombre = reader["nombre"].ToString() ?? "";
                    _apellido = reader["apellido"].ToString() ?? "";
                    //telefono = reader["telefono"].ToString() ?? "";
                    tipo = reader["tipo"].ToString() ?? "";
                    _carnet = reader["carnet"].ToString() ?? "";
                    _emitido = reader["emitido"].ToString() ?? "";

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


    }
}
