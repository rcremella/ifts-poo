namespace proyectoClub
{
    partial class frmPagar
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
            btnCobrar = new Button();
            btnVolver = new Button();
            txtCarnet = new TextBox();
            lblCarnet = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtDocumento = new TextBox();
            lblDocumento = new Label();
            txtImporte = new TextBox();
            lblImporte = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // btnCobrar
            // 
            btnCobrar.Enabled = false;
            btnCobrar.Location = new Point(366, 71);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(92, 23);
            btnCobrar.TabIndex = 20;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(366, 186);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 23);
            btnVolver.TabIndex = 19;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtCarnet
            // 
            txtCarnet.Enabled = false;
            txtCarnet.Location = new Point(122, 158);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(184, 23);
            txtCarnet.TabIndex = 18;
            // 
            // lblCarnet
            // 
            lblCarnet.AutoSize = true;
            lblCarnet.Font = new Font("Segoe UI", 9F);
            lblCarnet.Location = new Point(47, 161);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(42, 15);
            lblCarnet.TabIndex = 17;
            lblCarnet.Text = "Carnet";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(122, 129);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(184, 23);
            txtNombre.TabIndex = 16;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.Location = new Point(47, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 15;
            lblNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(122, 100);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(184, 23);
            txtApellido.TabIndex = 14;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F);
            lblApellido.Location = new Point(47, 103);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 13;
            lblApellido.Text = "Apellido";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(122, 71);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(184, 23);
            txtDocumento.TabIndex = 12;
            txtDocumento.KeyDown += txtDocumento_KeyDown;
            txtDocumento.Leave += txtDocumento_Leave;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 9F);
            lblDocumento.Location = new Point(47, 74);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 11;
            lblDocumento.Text = "Documento";
            // 
            // txtImporte
            // 
            txtImporte.Enabled = false;
            txtImporte.Location = new Point(122, 187);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(184, 23);
            txtImporte.TabIndex = 22;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 9F);
            lblImporte.Location = new Point(47, 190);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(49, 15);
            lblImporte.TabIndex = 21;
            lblImporte.Text = "Importe";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(122, 36);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(109, 15);
            lblMensaje.TabIndex = 23;
            lblMensaje.Text = "Complete los datos";
            // 
            // frmPagar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 231);
            Controls.Add(lblMensaje);
            Controls.Add(txtImporte);
            Controls.Add(lblImporte);
            Controls.Add(btnCobrar);
            Controls.Add(btnVolver);
            Controls.Add(txtCarnet);
            Controls.Add(lblCarnet);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Name = "frmPagar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cobrar Cuota";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCobrar;
        private Button btnVolver;
        private TextBox txtCarnet;
        private Label lblCarnet;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtDocumento;
        private Label lblDocumento;
        private TextBox txtImporte;
        private Label lblImporte;
        private Label lblMensaje;
    }
}