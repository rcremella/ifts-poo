using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace proyectoClub
{
    // hereda de Persona
    internal class Socio : Persona
    {
        // atributos propios de Socio, Persona no los tiene
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
                cmdUpdate.Parameters.AddWithValue("@apto_fisico", AptoFisico);
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



        // busca al socio con su carnet (solo lo usa frmEntregarCarnet)
        // no es override: validarExistencia de Persona sigue buscando en socios y no socios
        public bool validarCarnet()
        {
            try
            {
                _conexion.Open();

                string query = "select p.id, p.nombre, p.apellido, 'socio' as tipo, ca.id as carnet, ca.emitido from cliente c " +
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
                    _id = Convert.ToInt32(reader["id"]);
                    _nombre = reader["nombre"].ToString() ?? "";
                    _apellido = reader["apellido"].ToString() ?? "";
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
                Console.WriteLine("Error en validarCarnet: " + ex.Message);
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
