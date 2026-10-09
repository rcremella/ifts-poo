using MySql.Data.MySqlClient;

namespace proyectoClub
{
    public partial class frmRegistrarCliente : Form
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
        }


        private void bloquearExistente(Persona persona)
        {
            if (persona.validarExistencia())
            {
                lblMensaje.Text = "El usuario ya existe";

                txtApellido.Text = persona._apellido;
                txtNombre.Text = persona._nombre;
                txtTelefono.Text = persona._telefono;

                txtDocumento.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtTelefono.Enabled = false;
                btnRegistrar.Enabled = false;
            }
            else
            {
                lblMensaje.Text = "Complete los datos";
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefono.Enabled = true;
                btnRegistrar.Enabled = true;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            // verificar el dni 
            // se crea la clase persona que verifica existencia, se carga o admite el registro
            MySqlConnection myCon = Conexion.Obtener();

            int documento;

            if (!int.TryParse(txtDocumento.Text, out documento))
            {
                lblMensaje.Text = "Ingrese un documento valido";
                return;
            }

            Console.WriteLine(documento);

            Persona persona = new Persona(myCon, documento);

            bloquearExistente(persona);

            /*
                if (persona.validarExistencia())
                {
                    lblMensaje.Text = "el usuario ya existe";
                    txtApellido.Text = persona._apellido;
                    txtNombre.Text = persona._nombre;
                    txtTelefono.Text = persona._telefono;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtTelefono.Enabled = false;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    lblMensaje.Text = "Complete los datos";
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtTelefono.Enabled = true;
                    btnRegistrar.Enabled = true;
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";


                }
            */
            // Console.WriteLine(persona._apellido);





        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            //primerro verificar que existan los datos, sino hacer foco en el cuadro de texto

            // tomar todos los datos y agregarlos a persona
            MySqlConnection myCon = Conexion.Obtener();

            int documento;

            if (!int.TryParse(txtDocumento.Text, out documento))
            {
                lblMensaje.Text = "Ingrese un documento valido";
                return;
            }

            Persona persona = new Persona(myCon, documento);
            persona._nombre = txtNombre.Text;
            persona._apellido = txtApellido.Text;
            persona._telefono = txtTelefono.Text;

            bool verificacion = persona.verificarDatosCompletos();

            if (verificacion)
            {
                if (persona.registrarPersona())
                {
                    bloquearExistente(persona);
                    lblMensaje.Text = "Usuario añadido correctamente";
                }
                else
                {
                    lblMensaje.Text = "Error al registrar el usuario";
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
            btnRegistrar.Enabled = true;

            lblMensaje.Text = "Complete los datos";
        }
    }
}
