using MySql.Data.MySqlClient;

namespace proyectoClub
{
    // formulario para cobrar la cuota a un socio
    // se busca al socio por dni y se carga el importe que paga
    public partial class frmPagar : Form
    {
        // es true solo cuando el documento ingresado existe en la base
        private bool _personaEncontrada = false;

        // id de la persona encontrada, lo necesita el pago para guardarse en la base
        private int _idPersona = 0;

        public frmPagar()
        {
            InitializeComponent();
        }

        // cierra este formulario y se vuelve al menu (se abrio con ShowDialog)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // se ejecuta cuando el foco sale del campo documento
        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            buscarPersona();
        }

        // tambien se busca al apretar Enter dentro del campo documento
        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarPersona();
                e.SuppressKeyPress = true; // evita el sonido de Windows al apretar Enter
            }
        }

        // busca el documento en la base
        // COBRAR queda habilitado solo si la persona existe
        private void buscarPersona()
        {
            int documento;

            // mismas validaciones que en el registro de socios
            if (!int.TryParse(txtDocumento.Text, out documento) || documento <= 0 || txtDocumento.Text.Length > 9)
            {
                limpiarDatos("Ingrese un documento válido");
                return;
            }

            MySqlConnection myCon = Conexion.Obtener();
            Persona persona = new Persona(myCon, documento);

            if (persona.validarExistencia())
            {
                // la encontro: muestro sus datos y habilito el importe y el boton
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtImporte.Enabled = true;
                cboTipoPago.Enabled = true;
                cboTipoPago.SelectedIndex = 0; // arranca en Efectivo
                _idPersona = persona._id;
                _personaEncontrada = true;

                // el importe se completa solo con el precio de su tipo (socio o no socio), pero se puede corregir
                Precio precio = new Precio(myCon);
                decimal? importe = precio.obtenerImporte(persona.tipo);

                if (importe != null)
                {
                    txtImporte.Text = importe.Value.ToString("0.##");
                    lblMensaje.Text = "Verifique el importe y elija el tipo de pago";
                }
                else
                {
                    txtImporte.Text = "";
                    lblMensaje.Text = "No hay precio cargado, ingrese el importe";
                }

                habilitarCobrar();
            }
            else
            {
                limpiarDatos("La persona no se encuentra registrada");
            }
        }

        // vacia los datos y deja el boton COBRAR deshabilitado
        private void limpiarDatos(string mensaje)
        {
            _personaEncontrada = false;
            _idPersona = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtImporte.Text = "";
            txtImporte.Enabled = false;
            cboTipoPago.SelectedIndex = -1; // sin seleccion
            cboTipoPago.Enabled = false;
            btnCobrar.Enabled = false;
            lblMensaje.Text = mensaje;
        }

        // cada vez que cambia el importe reviso si ya se puede cobrar
        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            habilitarCobrar();
        }

        // COBRAR queda habilitado solo si hay una persona encontrada y un importe mayor a cero
        private void habilitarCobrar()
        {
            decimal importe;

            // TryParse no tira error si el texto no es un numero, devuelve false
            bool importeOk = decimal.TryParse(txtImporte.Text, out importe) && importe > 0;

            btnCobrar.Enabled = _personaEncontrada && importeOk;
        }

        // guarda el pago en la base y deja el formulario listo para cobrar a otra persona
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            decimal importe;

            // el boton ya esta habilitado solo con importe valido, igual lo reviso por las dudas
            if (!decimal.TryParse(txtImporte.Text, out importe) || importe <= 0)
            {
                lblMensaje.Text = "Ingrese un importe válido";
                return;
            }

            bool guardado;

            // si faltan los user secrets o falla MySQL aviso con un mensaje (sin detalles de la cadena)
            try
            {
                MySqlConnection myCon = Conexion.Obtener();
                Pago pago = new Pago(myCon, _idPersona, importe, cboTipoPago.Text);
                guardado = pago.registrar();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexión");
                return;
            }

            if (guardado)
            {
                // limpio todo para el proximo cobro
                txtDocumento.Text = "";
                limpiarDatos("Pago registrado correctamente");
                txtDocumento.Focus();
            }
            else
            {
                lblMensaje.Text = "No se pudo registrar el pago";
            }
        }
    }
}
