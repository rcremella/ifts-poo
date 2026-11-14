namespace proyectoClub
{
    public partial class FrmOpciones : Form
    {
        // el usuario que inicio sesion, viene desde el login
        private readonly Usuario _usuario;

        public FrmOpciones(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // muestro quien esta usando el sistema
            lblDescripcionUsuario.Text = "Usuario: " + _usuario.nombreReal + " " + _usuario.apellidoReal;
        }

        // este boton abre el formulario para registrar un socio nuevo
        private void abrirRegistrarCliente(object sender, EventArgs e)
        {
            Form formulario = new FrmRegistrarCliente();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }

        // abre el formulario para entregar el carnet
        private void abrirEntregarCarnet(object sender, EventArgs e)
        {
            Form formulario = new FrmEntregarCarnet();
            formulario.ShowDialog();
        }

        // abre el formulario para cobrar la cuota
        private void abrirCobrarCuota(object sender, EventArgs e)
        {
            Form formulario = new FrmPagar();
            formulario.ShowDialog();
        }

        // abre el listado de vencimientos
        private void abrirListarVencimientos(object sender, EventArgs e)
        {
            Form formulario = new FrmListarVencimientos();
            formulario.ShowDialog();
        }
    }
}
