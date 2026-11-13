using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // formulario para entregar el carnet al socio
    // se busca por dni y el checkbox marca si el carnet ya se entrego
    public partial class frmEntregarCarnet : Form
    {
        // socio encontrado, es null mientras no haya uno valido
        private Socio? _socio = null;

        public frmEntregarCarnet()
        {
            InitializeComponent();
        }

        // cierra este formulario y se vuelve al menu (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // se ejecuta cuando el foco sale del campo documento
        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            buscarPersona();
        }

        // tambien se busca al apretar Enter dentro del campo documento
        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarPersona();
                e.SuppressKeyPress = true; // evita el sonido de Windows al apretar Enter
            }
        }

        // busca el documento en la base
        // IMPRIMIR CARNET queda habilitado solo si la persona existe
        private void buscarPersona()
        {
            int documento;

            // mismas validaciones que en el registro de socios
            if (!int.TryParse(txtDocumento.Text, out documento) || documento <= 0 || txtDocumento.Text.Length > 9)
            {
                limpiarDatos("Ingrese un documento válido");
                return;
            }

            MySqlConnection myCon = Conexion.Obtener();

            // primero veo si la persona existe y si es socio o no socio
            Persona persona = new Persona(myCon, documento);

            if (!persona.validarExistencia())
            {
                limpiarDatos("La persona no se encuentra registrada");
                return;
            }

            // solo los socios tienen carnet
            if (persona.tipo != "socio")
            {
                limpiarDatos("Los no socios no tienen carnet");
                return;
            }

            Socio socio = new Socio(myCon, documento);

            if (socio.validarCarnet())
            {
                // lo encontro: muestro sus datos y habilito el boton
                txtNombre.Text = socio.Nombre;
                txtApellido.Text = socio.Apellido;
                txtCarnet.Text = socio.Carnet;
                chkEntregado.Checked = socio.Emitido;
                _socio = socio;
                btnImprimir.Enabled = true;
                lblMensaje.Text = "Persona encontrada";
            }
            else
            {
                limpiarDatos("El socio no tiene carnet registrado");
            }
        }

        // vacia los datos y deja el boton IMPRIMIR CARNET deshabilitado
        private void limpiarDatos(string mensaje)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarnet.Text = "";
            chkEntregado.Checked = false;
            _socio = null;
            btnImprimir.Enabled = false;
            lblMensaje.Text = mensaje;
        }

        // entrega el carnet: lo marca como entregado en la base y muestra sus datos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // el boton solo esta habilitado con un socio encontrado, igual lo reviso por las dudas
            if (_socio == null)
            {
                return;
            }

            // si ya se entrego antes, pregunto si se quiere volver a imprimir (no se cambia la fecha)
            if (_socio.Emitido)
            {
                DialogResult respuesta = MessageBox.Show("El carnet ya fue entregado. ¿Desea imprimirlo de nuevo?",
                                                         "Carnet ya entregado", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (!_socio.entregarCarnet())
                {
                    lblMensaje.Text = "No se pudo registrar la entrega del carnet";
                    return;
                }

                chkEntregado.Checked = true;
                lblMensaje.Text = "Carnet entregado correctamente";
            }

            // la "impresion" es un resumen con los datos del carnet
            string fecha = _socio.FechaEntrega.HasValue ? _socio.FechaEntrega.Value.ToString("dd/MM/yyyy") : "";

            MessageBox.Show("Carnet N° " + _socio.Carnet + "\n" +
                            "Socio: " + _socio.Nombre + " " + _socio.Apellido + "\n" +
                            "Fecha de entrega: " + fecha,
                            "Carnet");
        }
    }
}
