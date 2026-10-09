using MySql.Data.MySqlClient;

namespace proyectoClub
{
    internal class Socio : Persona
    {
        public Socio(MySqlConnection conexion, int documento) : base(conexion, documento)
        {
        }

        public override string ObtenerDescripcion()
        {
            return "Socio: " + _nombre + " " + _apellido;
        }
    }
}
