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

        // abre la credencial del socio, desde ahi se imprime y se registra la entrega
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // el boton solo esta habilitado con un socio encontrado, igual lo reviso por las dudas
            if (_socio == null)
            {
                return;
            }

            // se abre de forma MODAL y le paso el documento para que traiga los datos
            frmCredencial credencial = new frmCredencial(_socio._documento);
            credencial.ShowDialog();

            // al volver busco de nuevo, asi el check "entregado" queda actualizado
            buscarPersona();
        }
    }
}
