using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // formulario para entregar el carnet al socio
    // se busca por dni y el checkbox marca si el carnet ya se entrego
    public partial class frmEntregarCarnet : Form
    {
        public frmEntregarCarnet()
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
