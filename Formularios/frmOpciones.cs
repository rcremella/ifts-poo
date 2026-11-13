using proyectoClub.Formularios;

namespace proyectoClub
{
    public partial class frmOpcionesGestion : Form
    {
        // el usuario que inicio sesion, viene desde el login
        private readonly Usuario _usuario;

        public frmOpcionesGestion(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // muestro quien esta usando el sistema
            lblDescripcionUsuario.Text = "Usuario: " + _usuario.nombreReal + " " + _usuario.apellidoReal;
        }

        // este boton abre el formulario para registrar un socio nuevo


        private void abrirRegistrarCliente(object sender, EventArgs e)
        {
            Form formulario = new frmRegistrarCliente();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL

        }


        private void abrirEntregarCarnet(object sender, EventArgs e)
        {
            Form formulario = new frmEntregarCarnet();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
        private void abrirCobrarCuota(object sender, EventArgs e)
        {
            Form formulario = new frmPagar();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
        private void abrirListarVencimientos(object sender, EventArgs e)
        {
            Form formulario = new frmListarVencimientos();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
    }
}
