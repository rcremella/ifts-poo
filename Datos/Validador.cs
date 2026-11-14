namespace proyectoClub
{
    // clase estatica con las validaciones que se repetian en varios formularios
    internal static class Validador
    {
        // revisa que el texto sea un documento valido: numero mayor a cero de hasta 9 digitos
        // si es valido lo devuelve en el parametro out
        public static bool documentoValido(string texto, out int documento)
        {
            // TryParse no tira error si no es un numero, devuelve false
            return int.TryParse(texto, out documento) && documento > 0 && texto.Length <= 9;
        }
    }
}
