using MySql.Data.MySqlClient;

namespace proyectoClub
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.ActiveControl = btnConectar; // lo pongo para que no haga foco directo en el nombre de usuario
            this.AcceptButton = btnConectar; // al apretar Enter en cualquier campo se ejecuta CONECTAR
        }

        private void txtNombre_Text_Enter(object sender, EventArgs e)
        {
            // este evento se ejecuta cuando llega el foco
            // si tiene el texto de ayuda lo borro para que pueda escribir
            if (txtUsuario.Text == "Ingrese Nombre de Usuario")
            {
                txtUsuario.Text = "";

            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            // este evento se ejecuta cuando se va el foco
            // si quedo vacio vuelvo a poner el texto de ayuda
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Ingrese Nombre de Usuario";

            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            // igual que el usuario, pero ademas activo los asteriscos para ocultar la clave
            if (txtClave.Text == "Ingrese su contraseña")
            {
                txtClave.Text = "";
                txtClave.UseSystemPasswordChar = true;

            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            // si queda vacia saco los asteriscos para que se lea el texto de ayuda
            if (txtClave.Text == "")
            {
                txtClave.Text = "Ingrese su contraseña";
                txtClave.UseSystemPasswordChar = false;

            }
        }

        // cada vez que cambia el texto de un campo reviso si ya se puede conectar
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            habilitarConectar();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            habilitarConectar();
        }

        // CONECTAR queda habilitado solo si hay usuario y clave escritos (el texto de ayuda no cuenta)
        private void habilitarConectar()
        {
            bool usuarioOk = !String.IsNullOrWhiteSpace(txtUsuario.Text) && txtUsuario.Text != "Ingrese Nombre de Usuario";
            bool claveOk = !String.IsNullOrWhiteSpace(txtClave.Text) && txtClave.Text != "Ingrese su contraseña";

            btnConectar.Enabled = usuarioOk && claveOk;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // tomo lo que escribio la persona en los campos
            String nombreUsuario = txtUsuario.Text;
            String clave = txtClave.Text;

            // si algún campo está vacío o tiene el texto de ayuda, no consulto la base
            if (String.IsNullOrWhiteSpace(nombreUsuario) || nombreUsuario == "Ingrese Nombre de Usuario" ||
                String.IsNullOrWhiteSpace(clave) || clave == "Ingrese su contraseña")
            {
                lblResultado.Text = "Complete usuario y contraseña";
                lblResultado.BackColor = Color.Red;
                return;
            }

            // si faltan los user secrets o falla MySQL muestro error de conexion (sin detalles de la cadena)
            Usuario u;
            bool logueado;
            try
            {
                MySqlConnection myCon = Conexion.Obtener();
                u = new Usuario(myCon, nombreUsuario, clave);
                logueado = u.ValidarLogin();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión");
                return;
            }

            // si los datos son correctos paso al menu, si no aviso con el label
            if (logueado)
            {
                this.Hide(); // oculto el login mientras está abierto el menú

                Form formulario = new frmOpcionesGestion(u);
                formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL

                this.Close(); // al cerrar el menú termina la aplicación
            }
            else
            {
                lblResultado.Text = "Usuario o contraseña incorrectos";
                lblResultado.BackColor = Color.Red;
            }

        }
    }
}
