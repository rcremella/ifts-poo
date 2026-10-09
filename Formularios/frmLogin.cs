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
            /* este evento se ejecuta cuando llega el foco */
            if (txtUsuario.Text == "Ingrese Nombre de Usuario")
            {
                txtUsuario.Text = "";

            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            /* este evento se ejecuta cuando se va el foco */
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Ingrese Nombre de Usuario";

            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Ingrese su contraseña")
            {
                txtClave.Text = "";
                txtClave.UseSystemPasswordChar = true;

            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "Ingrese su contraseña";
                txtClave.UseSystemPasswordChar = false;

            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
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

            MySqlConnection myCon;
            try
            {
                myCon = Conexion.Obtener();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexion");
                return;
            }

            Usuario u = new Usuario(myCon, nombreUsuario, clave);

            bool logueado = u.ValidarLogin();

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
