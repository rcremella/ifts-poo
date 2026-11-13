using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // formulario para cobrar la cuota a un socio
    // se busca al socio por dni y se carga el importe que paga
    public partial class frmPagar : Form
    {
        // es true solo cuando el documento ingresado existe en la base
        private bool _personaEncontrada = false;

        public frmPagar()
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
        // COBRAR queda habilitado solo si la persona existe
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
                // la encontro: muestro sus datos y habilito el importe y el boton
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtImporte.Enabled = true;
                _personaEncontrada = true;
                habilitarCobrar();
                lblMensaje.Text = "Ingrese el importe a pagar";
            }
            else
            {
                limpiarDatos("La persona no se encuentra registrada");
            }
        }

        // vacia los datos y deja el boton COBRAR deshabilitado
        private void limpiarDatos(string mensaje)
        {
            _personaEncontrada = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtImporte.Text = "";
            txtImporte.Enabled = false;
            btnCobrar.Enabled = false;
            lblMensaje.Text = mensaje;
        }

        // cada vez que cambia el importe reviso si ya se puede cobrar
        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            habilitarCobrar();
        }

        // COBRAR queda habilitado solo si hay una persona encontrada y un importe mayor a cero
        private void habilitarCobrar()
        {
            decimal importe;

            // TryParse no tira error si el texto no es un numero, devuelve false
            bool importeOk = decimal.TryParse(txtImporte.Text, out importe) && importe > 0;

            btnCobrar.Enabled = _personaEncontrada && importeOk;
        }
    }
}
