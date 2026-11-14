using System.Data;

namespace proyectoClub
{
    // formulario que lista en una grilla los vencimientos de los socios
    // desde aca tambien se pueden imprimir
    public partial class FrmListarVencimientos : Form
    {
        public FrmListarVencimientos()
        {
            InitializeComponent();

            // la grilla es solo para mirar, no se puede editar ni agregar filas
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cargarGrilla();
        }

        // cierra este formulario y se vuelve al menu (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // pide los vencimientos a la base y los muestra en la grilla
        private void cargarGrilla()
        {
            try
            {
                Vencimiento vencimiento = new Vencimiento(Conexion.Obtener());
                DataTable tabla = vencimiento.listarVencimientos();

                // DataSource enlaza la tabla con la grilla
                dgvVencimientos.DataSource = tabla;
            }
            catch (Exception)
            {
                Mensajes.errorConexion();
            }
        }
    }
}
