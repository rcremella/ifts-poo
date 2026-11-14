using System.Data;
using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // arma el listado de socios que vencen hoy, para mostrarlo en la grilla
    internal class Vencimiento
    {
        private readonly MySqlConnection _conexion;

        public Vencimiento(MySqlConnection conexion)
        {
            _conexion = conexion;
        }

        // devuelve una tabla con los socios cuya fecha de vencimiento es la de hoy
        public DataTable listarVencimientosDeHoy()
        {
            try
            {
                _conexion.Open();

                // los AS son los titulos de las columnas que se ven en la grilla
                string query = "SELECT p.documento AS Documento, p.nombre AS Nombre, p.apellido AS Apellido, " +
                               "p.telefono AS Telefono, DATE_FORMAT(c.fechaVto, '%d/%m/%Y') AS Vencimiento " +
                               "FROM persona p " +
                               "INNER JOIN cliente c ON p.id = c.id_persona " +
                               "WHERE c.fechaVto = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, _conexion);

                MySqlDataReader reader = cmd.ExecuteReader();

                // Load copia todas las filas del reader a la tabla
                DataTable tabla = new DataTable();
                tabla.Load(reader);

                reader.Close();
                return tabla;
            }
            catch (Exception)
            {
                // lo relanzo para que el formulario avise que no se pudo conectar
                throw;
            }
            finally
            {
                if (_conexion.State == System.Data.ConnectionState.Open)
                    _conexion.Close();
            }
        }
    }
}
