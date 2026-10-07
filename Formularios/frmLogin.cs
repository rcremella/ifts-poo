using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;

namespace proyectoClub
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.ActiveControl = btnConectar; // lo pongo para que no haga foco directo en el nombre de usuario
        }

        private void txtNombre_Text_Enter(object sender, EventArgs e)
        {
            /* este evento se ejecuta cuand llega el fojo */
            if (txtUsuario.Text == "Ingrese Nombre de Usuario")
            {
                txtUsuario.Text = "";

            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            /* este evento se ejecuta cuand llega el fojo */
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


             String conexion = "user=admindsoo;host=164.152.243.176;port=1080;database=dsoo;pwd=ClaVeGenerica21";
             MySqlConnection myCon = new MySqlConnection(conexion);



            String nombreUsuario= txtUsuario.Text;
            String clave = txtClave.Text;

            //conexion automatica
            /* nombreUsuario = "empleado1";
             clave = "123456";
            */

            Usuario u = new Usuario(myCon, nombreUsuario, clave);

            bool logueado = u.ValidarLogin();
            
            if (logueado)
            {
                lblResultado.Text = "Usuario y contraseña correctos";
                lblResultado.BackColor = Color.Green;
                Form formulario = new frmOpcionesGestion(u);
                formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL

            }
            else
            {
                lblResultado.Text = "Usuario o contraseña incorrectos";
                lblResultado.BackColor = Color.Red;
            }

        }
    }
}
