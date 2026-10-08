namespace proyectoClub
{
    public partial class frmOpcionesGestion : Form
    {
        private readonly Usuario _usuario;

        public frmOpcionesGestion(Usuario usuario)   // ← public
        {
            InitializeComponent();
            _usuario = usuario;

            lblDescripcionUsuario.Text = "Usuario: " + _usuario.nombreReal + " " + _usuario.apellidoReal;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            // lo que necesites
            Form formulario = new frmRegistrarCliente();
            formulario.ShowDialog(); // llama al formulario instanciado de la forma MODAL
        }
    }
}
