namespace proyectoClub
{
    public partial class frmOpcionesGestion : Form
    {
        private readonly Usuario _usuario;

        public frmOpcionesGestion(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            lblDescripcionUsuario.Text = "Usuario: " + _usuario.nombreReal + " " + _usuario.apellidoReal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new frmRegistrarCliente();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
    }
}
