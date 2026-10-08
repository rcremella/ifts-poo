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
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            // verificar el dni 
            // se crea la clase persona que verifica existencia, se carga o admite el registro
            MySqlConnection myCon = Conexion.Obtener();



            int documento = int.Parse(txtDocumento.Text);
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



            int documento = int.Parse(txtDocumento.Text);
            Persona persona = new Persona(myCon, documento);
            persona._nombre = txtNombre.Text;
            persona._apellido = txtApellido.Text;
            persona._telefono = txtTelefono.Text;

            bool verificacion = persona.verificarDatosCompletos();
            if (verificacion)
            {
                persona.registrarPersona();
                bloquearExistente(persona);

            }

            //mensaje de error , que complete los campos


        }
    }
}
