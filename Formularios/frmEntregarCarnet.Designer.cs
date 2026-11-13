namespace proyectoClub
{
    partial class frmEntregarCarnet
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
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtCarnet = new TextBox();
            lblCarnet = new Label();
            btnVolver = new Button();
            btnImprimir = new Button();
            chkEntregado = new CheckBox();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 9F);
            lblDocumento.Location = new Point(47, 74);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 0;
            lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(122, 71);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(184, 23);
            txtDocumento.TabIndex = 1;
            txtDocumento.Leave += txtDocumento_Leave;
            txtDocumento.KeyDown += txtDocumento_KeyDown;
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(122, 100);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(184, 23);
            txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F);
            lblApellido.Location = new Point(47, 103);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(122, 129);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(184, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.Location = new Point(47, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // txtCarnet
            // 
            txtCarnet.Enabled = false;
            txtCarnet.Location = new Point(122, 158);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(184, 23);
            txtCarnet.TabIndex = 7;
            // 
            // lblCarnet
            // 
            lblCarnet.AutoSize = true;
            lblCarnet.Font = new Font("Segoe UI", 9F);
            lblCarnet.Location = new Point(47, 161);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(42, 15);
            lblCarnet.TabIndex = 6;
            lblCarnet.Text = "Carnet";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(399, 183);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 23);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(349, 71);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(142, 23);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "IMPRIMIR CARNET";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // chkEntregado
            // 
            chkEntregado.AutoSize = true;
            chkEntregado.Enabled = false;
            chkEntregado.Font = new Font("Segoe UI", 9F);
            chkEntregado.Location = new Point(226, 187);
            chkEntregado.Name = "chkEntregado";
            chkEntregado.Size = new Size(80, 19);
            chkEntregado.TabIndex = 10;
            chkEntregado.Text = "Entregado";
            chkEntregado.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(122, 36);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(109, 15);
            lblMensaje.TabIndex = 11;
            lblMensaje.Text = "Complete los datos";
            // 
            // frmEntregarCarnet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 231);
            Controls.Add(lblMensaje);
            Controls.Add(chkEntregado);
            Controls.Add(btnImprimir);
            Controls.Add(btnVolver);
            Controls.Add(txtCarnet);
            Controls.Add(lblCarnet);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Name = "frmEntregarCarnet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entregar Carnet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDocumento;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtCarnet;
        private Label lblCarnet;
        private Button btnVolver;
        private Button btnImprimir;
        private CheckBox chkEntregado;
        private Label lblMensaje;
    }
}