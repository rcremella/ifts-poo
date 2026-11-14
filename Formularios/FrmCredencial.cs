using MySql.Data.MySqlClient;
using System.Drawing.Imaging;

namespace proyectoClub
{
    // credencial del socio: se muestra con sus datos, al imprimir se guarda como imagen y se registra la entrega del carnet en la base
    // es un formulario distinto al que lo genera (FrmEntregarCarnet)
    public partial class FrmCredencial : Form
    {
        // documento del socio, llega desde el formulario que abre la credencial
        private readonly int _documento;

        // socio con los datos del carnet, es null mientras no se haya encontrado
        private Socio? _socio = null;

        public FrmCredencial(int documento)
        {
            InitializeComponent();
            _documento = documento;
        }

        // los datos se traen de la base cuando se abre el formulario (evento Load)
        private void FrmCredencial_Load(object sender, EventArgs e)
        {
            btnImprimir.Enabled = false;

            // si faltan los user secrets o falla MySQL aviso con un mensaje (sin detalles de la cadena)
            try
            {
                MySqlConnection myCon = Conexion.Obtener();
                Socio socio = new Socio(myCon, _documento);

                if (socio.validarCarnet())
                {
                    _socio = socio;
                    mostrarDatos();
                }
                else
                {
                    lblMensaje.Text = "No se encontró el carnet del socio";
                }
            }
            catch (Exception)
            {
                Mensajes.errorConexion();
            }
        }

        // pone los datos del socio en las etiquetas de la credencial
        // IMPRIMIR entrega el carnet (solo con la cuota paga)
        // si ya se entrego el boton pasa a REIMPRIMIR, que solo vuelve a guardar la imagen (por si se perdio)
        private void mostrarDatos()
        {
            if (_socio == null)
            {
                return;
            }

            lblNombreSocio.Text = _socio.Nombre + " " + _socio.Apellido;
            lblDocumento.Text = _documento.ToString();
            lblCarnet.Text = _socio.Carnet;

            btnImprimir.Text = _socio.Emitido ? "REIMPRIMIR" : "IMPRIMIR";

            if (_socio.Emitido)
            {
                string fecha = _socio.FechaEntrega.HasValue ? _socio.FechaEntrega.Value.ToString("dd/MM/yyyy") : "";
                lblEntrega.Text = fecha;

                // reimprimir pide la misma regla que entregar: la cuota tiene que estar paga
                btnImprimir.Enabled = _socio.CuotaActiva();
                lblMensaje.Text = _socio.CuotaActiva()
                    ? "El carnet ya fue entregado, puede reimprimirlo"
                    : "El carnet ya fue entregado, la cuota no está paga para reimprimirlo";
            }
            else if (!_socio.CuotaActiva())
            {
                // por las dudas: desde Entregar carnet ya no se llega con la cuota sin pagar
                lblEntrega.Text = "Pendiente";
                lblMensaje.Text = "La cuota no está paga, no se puede entregar el carnet";
                btnImprimir.Enabled = false;
            }
            else
            {
                lblEntrega.Text = "Pendiente";
                lblMensaje.Text = "Presione IMPRIMIR para entregar el carnet";
                btnImprimir.Enabled = true;
            }
        }

        // "imprimir" guarda la credencial como imagen y despues registra en la base que el carnet se entrego hoy
        // si el carnet ya estaba entregado es una reimpresion: solo se guarda la imagen, la entrega no se toca
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // el boton solo esta habilitado con un socio encontrado, igual lo reviso por las dudas
            if (_socio == null)
            {
                return;
            }

            // pido donde guardar la imagen, si cancela no se entrega nada
            // el nombre viene armado con el del socio, sacando los caracteres que Windows no permite en un archivo
            string nombreArchivo = "Credencial - " + _socio.Nombre + " " + _socio.Apellido;
            nombreArchivo = string.Concat(nombreArchivo.Split(Path.GetInvalidFileNameChars()));

            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Imagen PNG (*.png)|*.png";
            dialogo.FileName = nombreArchivo;

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // reimpresion: se guarda la imagen con la fecha de entrega original, sin tocar la base
            if (_socio.Emitido)
            {
                lblMensaje.Text = guardarImagen(dialogo.FileName) ? "Imagen guardada" : "No se pudo guardar la imagen";
                return;
            }

            // la imagen sale con la fecha de entrega de hoy, que es la que se va a guardar
            string entregaAnterior = lblEntrega.Text;
            lblEntrega.Text = DateTime.Today.ToString("dd/MM/yyyy");

            // primero la imagen: si no se pudo guardar, el carnet no se marca como entregado
            if (!guardarImagen(dialogo.FileName))
            {
                lblEntrega.Text = entregaAnterior;
                lblMensaje.Text = "No se pudo guardar la imagen";
                return;
            }

            if (!_socio.entregarCarnet())
            {
                lblEntrega.Text = entregaAnterior;
                lblMensaje.Text = "No se pudo registrar la entrega del carnet";
                return;
            }

            // entregarCarnet ya actualizo la fecha en el objeto, muestro la credencial con la entrega
            mostrarDatos();
            lblMensaje.Text = "Carnet entregado e imagen guardada";
        }

        // saca una "foto" del panel de la credencial y la guarda como imagen PNG
        // devuelve false si no se pudo guardar (por ejemplo carpeta sin permiso)
        private bool guardarImagen(string ruta)
        {
            try
            {
                Bitmap imagen = new Bitmap(pnlCredencial.Width, pnlCredencial.Height);
                pnlCredencial.DrawToBitmap(imagen, new Rectangle(0, 0, pnlCredencial.Width, pnlCredencial.Height));
                imagen.Save(ruta, ImageFormat.Png);
                imagen.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // cierra este formulario y se vuelve a Entregar carnet (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
