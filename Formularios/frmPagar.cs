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

        // precio de la tabla precio segun el tipo de la persona, es null si no hay uno cargado
        private decimal? _precioBase = null;

        // si se paga en efectivo se descuenta el 10% del importe
        private const decimal DescuentoEfectivo = 0.10m;

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

                // solo los socios tienen carnet, a los no socios les queda vacio
                txtCarnet.Text = "";

                if (persona.tipo == "socio")
                {
                    Socio socio = new Socio(myCon, documento);

                    if (socio.validarCarnet())
                    {
                        txtCarnet.Text = socio.Carnet;
                    }
                }

                // el importe se completa solo con el precio de su tipo (socio o no socio), pero se puede corregir
                Precio precio = new Precio(myCon);
                decimal? importe = precio.obtenerImporte(persona.tipo);

                _precioBase = importe;

                if (importe != null)
                {
                    // arranca en efectivo, asi que ya viene con el descuento
                    calcularImporte();
                    // aclaro que significa el importe: el socio paga una cuota mensual y el no socio por dia
                    string detalle = persona.tipo == "socio" ? "Cuota mensual de socio" : "Importe diario de no socio";
                    lblMensaje.Text = detalle + ", verifique el importe";
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
            _precioBase = null;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarnet.Text = "";
            txtImporte.Text = "";
            txtImporte.Enabled = false;
            cboTipoPago.SelectedIndex = -1; // sin seleccion
            cboTipoPago.Enabled = false;
            btnCobrar.Enabled = false;
            lblMensaje.Text = mensaje;
        }

        // deja el formulario como al principio para cobrar a otra persona
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            limpiarDatos("Ingrese el documento");
            txtDocumento.Focus();
        }

        // las cuotas solo se eligen con tarjeta de credito, y el importe depende de como se paga
        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool conTarjeta = cboTipoPago.SelectedIndex == 1;

            cboCuotas.Enabled = conTarjeta;
            cboCuotas.SelectedIndex = conTarjeta ? 0 : -1; // con tarjeta arranca en 1 cuota

            calcularImporte();
        }

        // pone en el importe el precio de la tabla, con descuento si se paga en efectivo
        // si no hay precio cargado no toca lo que escribio el usuario
        private void calcularImporte()
        {
            if (_precioBase == null || cboTipoPago.SelectedIndex == -1)
            {
                return;
            }

            decimal importe = _precioBase.Value;

            if (cboTipoPago.SelectedIndex == 0)
            {
                importe = importe - importe * DescuentoEfectivo;
            }

            txtImporte.Text = importe.ToString("0.##");
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
                // lo que se guarda en la base: "Efectivo", "Transferencia" o "Tarjeta - 3 cuotas"
                // (el texto del combo de efectivo trae el "10% off", por eso no se usa directo)
                string tipoPago = cboTipoPago.Text;

                if (cboTipoPago.SelectedIndex == 0)
                {
                    tipoPago = "Efectivo";
                }
                else if (cboTipoPago.SelectedIndex == 1)
                {
                    tipoPago = "Tarjeta - " + cboCuotas.Text;
                }

                Pago pago = new Pago(myCon, _idPersona, importe, tipoPago);
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
