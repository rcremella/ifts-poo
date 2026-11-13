using System.Data;

namespace proyectoClub
{
    // formulario que lista en una grilla los vencimientos de los socios
    // desde aca tambien se pueden imprimir
    public partial class frmListarVencimientos : Form
    {
        public frmListarVencimientos()
        {
            InitializeComponent();

            // la grilla es solo para mirar, no se puede editar ni agregar filas
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cargarGrilla();
        }

        // pide los vencimientos a la base y los muestra en la grilla
        private void cargarGrilla()
        {
            try
            {
                Vencimiento vencimiento = new Vencimiento(Conexion.Obtener());
                DataTable tabla = vencimiento.listarVencimientosDeHoy();

                // DataSource enlaza la tabla con la grilla
                dgvVencimientos.DataSource = tabla;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión");
            }
        }
    }
}
