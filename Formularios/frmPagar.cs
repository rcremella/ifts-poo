namespace proyectoClub
{
    // formulario para cobrar la cuota a un socio
    // se busca al socio por dni y se carga el importe que paga
    public partial class frmPagar : Form
    {
        public frmPagar()
        {
            InitializeComponent();
        }

        // cierra este formulario y se vuelve al menu (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
