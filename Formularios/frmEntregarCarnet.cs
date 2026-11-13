using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // formulario para entregar el carnet al socio
    // se busca por dni y el checkbox marca si el carnet ya se entrego
    public partial class frmEntregarCarnet : Form
    {
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
            Persona persona = new Persona(myCon, documento);

            if (persona.validarExistencia())
            {
                // la encontro: muestro sus datos y habilito el boton
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                btnImprimir.Enabled = true;
                lblMensaje.Text = "Persona encontrada";
            }
            else
            {
                limpiarDatos("La persona no se encuentra registrada");
            }
        }

        // vacia los datos y deja el boton IMPRIMIR CARNET deshabilitado
        private void limpiarDatos(string mensaje)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarnet.Text = "";
            btnImprimir.Enabled = false;
            lblMensaje.Text = mensaje;
        }
    }
}
