using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using MySql.Data.MySqlClient;

namespace proyectoClub
{
    internal class Persona
    {
        private readonly MySqlConnection _conexion;

        public int _documento { get; set; }
        public int _id = 0;

        public string _nombre = "";
        public string _apellido = "";
        public string _telefono = "";

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


        public bool verificarDatosCompletos()
        {
            if(_apellido == null ||  _nombre == null || _telefono  == null )
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
