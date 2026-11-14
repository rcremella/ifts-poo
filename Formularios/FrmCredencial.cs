using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // credencial del socio: se muestra con sus datos y al imprimir se registra la entrega del carnet en la base
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
        // IMPRIMIR queda habilitado solo si el carnet todavia no se entrego
        private void mostrarDatos()
        {
            if (_socio == null)
            {
                return;
            }

            lblNombreSocio.Text = _socio.Nombre + " " + _socio.Apellido;
            lblDocumento.Text = _documento.ToString();
            lblCarnet.Text = _socio.Carnet;

            if (_socio.Emitido)
            {
                string fecha = _socio.FechaEntrega.HasValue ? _socio.FechaEntrega.Value.ToString("dd/MM/yyyy") : "";
                lblEntrega.Text = fecha;
                lblMensaje.Text = "El carnet ya fue entregado";
                btnImprimir.Enabled = false;
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

        // "imprimir" guarda en la base que el carnet se entrego hoy
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // el boton solo esta habilitado con un socio encontrado, igual lo reviso por las dudas
            if (_socio == null)
            {
                return;
            }

            if (!_socio.entregarCarnet())
            {
                lblMensaje.Text = "No se pudo registrar la entrega del carnet";
                return;
            }

            // entregarCarnet ya actualizo la fecha en el objeto, muestro la credencial con la entrega
            mostrarDatos();
            lblMensaje.Text = "Carnet entregado correctamente";
        }

        // cierra este formulario y se vuelve a Entregar carnet (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
