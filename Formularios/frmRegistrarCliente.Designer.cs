namespace proyectoClub
{
    partial class frmRegistrarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(47, 74);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 0;
            lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(122, 74);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(184, 23);
            txtDocumento.TabIndex = 1;
            txtDocumento.Leave += textBox1_Leave;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(122, 103);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(184, 23);
            txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(47, 103);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(122, 161);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(184, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(47, 161);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Télefono";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(122, 132);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(184, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(47, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(326, 95);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(326, 124);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(122, 36);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(109, 15);
            lblMensaje.TabIndex = 10;
            lblMensaje.Text = "Complete los datos";
            // 
            // frmRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 220);
            Controls.Add(lblMensaje);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Name = "frmRegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRegistrarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDocumento;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private Label lblMensaje;
    }
}