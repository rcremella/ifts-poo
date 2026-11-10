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
            lblDescripcionUsuario.Text ="Usuario: " + _usuario.nombreReal + " " + _usuario.apellidoReal;
        }

        // este boton abre el formulario para registrar un socio nuevo
        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new frmRegistrarCliente();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
    }
}
