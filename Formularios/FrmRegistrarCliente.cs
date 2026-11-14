using MySql.Data.MySqlClient;

namespace proyectoClub
{
    public partial class FrmRegistrarCliente : Form
    {
        // es true solo cuando el documento se verifico y no existe en la base
        private bool _documentoVerificado = false;

        public FrmRegistrarCliente()
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
                chkSocio.Checked = persona.tipo == "socio";
                chkAptoFisico.Checked = persona.AptoFisico;

                // ya esta registrado: bloqueo todo, incluso el documento
                txtDocumento.Enabled = false;
                bloquearDatos();
            }
            else
            {
                lblMensaje.Text = "Complete todos los datos y marque el apto físico";
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefono.Enabled = true;
                chkAptoFisico.Enabled = true;
                chkSocio.Enabled = true;

                // REGISTRAR se habilita recien cuando tambien este marcado el apto fisico
                _documentoVerificado = true;
                habilitarRegistrar();
            }
        }

        // REGISTRAR queda habilitado solo con el documento verificado, nombre, apellido y telefono escritos
        // y el apto fisico marcado (lo unico opcional es el check SOCIO)
        private void habilitarRegistrar()
        {
            bool datosOk = !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                           !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                           !string.IsNullOrWhiteSpace(txtTelefono.Text);

            btnRegistrar.Enabled = _documentoVerificado && datosOk && chkAptoFisico.Checked;
        }

        // cada vez que se marca o desmarca el apto fisico reviso si ya se puede registrar
        private void chkAptoFisico_CheckedChanged(object sender, EventArgs e)
        {
            habilitarRegistrar();
        }

        // lo usan nombre, apellido y telefono: cada vez que cambia el texto reviso si ya se puede registrar
        private void txtDatos_TextChanged(object sender, EventArgs e)
        {
            habilitarRegistrar();
        }

        // se ejecuta cuando el foco sale del campo documento
        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            buscarDocumento();
        }

        // tambien se busca al apretar Enter dentro del campo documento
        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarDocumento();
                e.SuppressKeyPress = true; // evita el sonido de Windows al apretar Enter
            }
        }

        // si se modifica el documento ya verificado, hay que verificarlo de nuevo
        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (_documentoVerificado)
            {
                bloquearDatos();
                lblMensaje.Text = "Ingrese el documento";
            }
        }

        // bloquea los datos y el boton REGISTRAR hasta que el dni este verificado
        private void bloquearDatos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            chkAptoFisico.Enabled = false;
            _documentoVerificado = false;
            btnRegistrar.Enabled = false;
            chkSocio.Enabled = false;
        }

        private void buscarDocumento()
        {
            // verifico el dni, si ya existe se cargan sus datos y si no se habilita el registro
            int documento;

            if (!Validador.documentoValido(txtDocumento.Text, out documento))
            {
                bloquearDatos();
                lblMensaje.Text = "Ingrese un documento válido";
                return;
            }

            // si falla la base no es lo mismo que "no existe", por eso se avisa aparte
            try
            {
                MySqlConnection myCon = Conexion.Obtener();

                // uso Persona porque su validarExistencia busca tanto en socios como en no socios
                Persona persona = new Persona(myCon, documento);

                bloquearExistente(persona);
            }
            catch (Exception)
            {
                // sin la base no se puede verificar, queda bloqueado hasta reintentar
                bloquearDatos();
                lblMensaje.Text = "No se pudo consultar la base de datos";
                Mensajes.errorConexion();
            }
        }

        // el boton REGISTRAR: si falla la base se avisa con un mensaje en lugar de cerrar el programa
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                registrarCliente();
            }
            catch (Exception)
            {
                lblMensaje.Text = "No se pudo consultar la base de datos";
                Mensajes.errorConexion();
            }
        }

        // primero se guarda en persona y despues en cliente, porque cliente necesita el id de la persona
        private void registrarCliente()
        {
            // valido los datos antes de registrar
            MySqlConnection myCon = Conexion.Obtener();

            int documento;

            if (!Validador.documentoValido(txtDocumento.Text, out documento))
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

            // cargo el objeto con lo que escribio la persona en el formulario
            // aca decido si va a ser socio o no socio, si es socio se guarda en la tabla cliente y si no en no_cliente
            // la variable es de tipo Persona y guarda un Socio o un noSocio (herencia)
            Persona cliente;

            if (chkSocio.Checked)
            {
                cliente = new Socio(myCon, documento);
            }
            else
            {
                cliente = new noSocio(myCon, documento);
            }


            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.AptoFisico = chkAptoFisico.Checked;



            bool verificacion = cliente.verificarDatosCompletos();

            if (verificacion)
            {
                if (!cliente.registrarPersona())
                {
                    lblMensaje.Text = "Error al registrar la persona";
                    return;
                }

                // polimorfismo: se ejecuta el registrarCliente de Socio o el de noSocio segun el objeto
                bool clienteOk = cliente.registrarCliente();

                // la persona ya se guardo, bloqueo el formulario para que no se cargue dos veces
                bloquearExistente(cliente);

                if (clienteOk)
                {
                    // variable de tipo Persona con un objeto Socio o noSocio: se ejecuta el override que corresponda
                    lblMensaje.Text = cliente.ObtenerDescripcion() + " registrado correctamente";
                }
                else
                {
                    lblMensaje.Text = "Se guardó la persona pero no se pudo registrar como cliente";
                }
            }
            else
            {
                lblMensaje.Text = "Complete los datos";
            }
        }

        // deja el formulario como al principio para cargar otro socio
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";

            // solo queda habilitado el documento, el resto se habilita al verificarlo
            txtDocumento.Enabled = true;
            chkAptoFisico.Checked = false;
            chkSocio.Checked = false;
            bloquearDatos();

            lblMensaje.Text = "Ingrese el documento";
        }

        // cierra este formulario y se vuelve al menu (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
