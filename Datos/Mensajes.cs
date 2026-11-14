namespace proyectoClub
{
    // clase estatica con los avisos que se repetian en varios formularios
    internal static class Mensajes
    {
        // aviso cuando no se puede usar la base (faltan los user secrets o MySQL no responde)
        // no muestra detalles de la conexion para no filtrar la cadena
        public static void errorConexion()
        {
            MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión");
        }
    }
}
