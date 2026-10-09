using MySql.Data.MySqlClient;

namespace proyectoClub
{
    public partial class frmRegistrarCliente : Form
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
        }


        // si ya existe bloquea los campos, si no los habilita
        private void bloquearExistente(Persona persona)
        {
            if (persona.validarExistencia())
            {
                lblMensaje.Text = "El socio ya se encuentra registrado";

                txtApellido.Text = persona.Apellido;
                txtNombre.Text = persona.Nombre;
                txtTelefono.Text = persona.Telefono;

                txtDocumento.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtTelefono.Enabled = false;
                chkAptoFisico.Enabled = false;
                btnRegistrar.Enabled = false;
            }
            else
            {
                lblMensaje.Text = "Complete los datos";
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefono.Enabled = true;
                chkAptoFisico.Enabled = true;
                btnRegistrar.Enabled = true;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            // verifico el dni, si ya existe se cargan sus datos y si no se habilita el registro
            MySqlConnection myCon = Conexion.Obtener();

            int documento;

            // TryParse no tira error si no es un numero, devuelve false
            if (!int.TryParse(txtDocumento.Text, out documento) || documento <= 0 || txtDocumento.Text.Length > 9)
            {
                lblMensaje.Text = "Ingrese un documento válido";
                return;
            }

            Socio socio = new Socio(myCon, documento);

            bloquearExistente(socio);

            // si ya existe muestro su apto fisico (_id lo carga validarExistencia)
            if (socio._id > 0)
            {
                socio.cargarAptoFisico();
                chkAptoFisico.Checked = socio.AptoFisico;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // valido los datos antes de registrar
            MySqlConnection myCon = Conexion.Obtener();

            int documento;

            if (!int.TryParse(txtDocumento.Text, out documento) || documento <= 0 || txtDocumento.Text.Length > 9)
            {
                lblMensaje.Text = "Ingrese un documento válido";
                return;
            }

            // todos los caracteres tienen que ser numeros
            if (!txtTelefono.Text.All(char.IsDigit))
            {
                lblMensaje.Text = "El teléfono debe ser numérico";
                return;
            }

            Socio socio = new Socio(myCon, documento);
            socio.Nombre = txtNombre.Text;
            socio.Apellido = txtApellido.Text;
            socio.Telefono = txtTelefono.Text;
            socio.AptoFisico = chkAptoFisico.Checked;

            bool verificacion = socio.verificarDatosCompletos();

            if (verificacion)
            {
                if (!socio.registrarPersona())
                {
                    lblMensaje.Text = "Error al registrar el socio";
                    return;
                }

                bool clienteOk = socio.registrarCliente();

                // la persona ya se guardo, bloqueo el formulario para que no se cargue dos veces
                bloquearExistente(socio);

                if (clienteOk)
                {
                    // variable de tipo Persona con un objeto Socio: se ejecuta el override de Socio
                    Persona persona = socio;
                    lblMensaje.Text = persona.ObtenerDescripcion() + " registrado correctamente";
                }
                else
                {
                    lblMensaje.Text = "Se guardó la persona pero no se pudo registrar como socio";
                }
            }
            else
            {
                lblMensaje.Text = "Complete los datos";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";

            txtDocumento.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtTelefono.Enabled = true;
            chkAptoFisico.Checked = false;
            chkAptoFisico.Enabled = true;
            btnRegistrar.Enabled = true;

            lblMensaje.Text = "Complete los datos";
        }
    }
}
