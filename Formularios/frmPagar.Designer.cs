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
            btnPagar = new Button();
            btnSalir = new Button();
            txtCarnet = new TextBox();
            lblCarnet = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            txtImporte = new TextBox();
            lblImporte = new Label();
            SuspendLayout();
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(482, 389);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(176, 23);
            btnPagar.TabIndex = 20;
            btnPagar.Text = "PAGAR";
            btnPagar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(664, 389);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 19;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtCarnet
            // 
            txtCarnet.Enabled = false;
            txtCarnet.Location = new Point(320, 179);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(310, 23);
            txtCarnet.TabIndex = 18;
            // 
            // lblCarnet
            // 
            lblCarnet.AutoSize = true;
            lblCarnet.Font = new Font("Segoe UI", 14.25F);
            lblCarnet.Location = new Point(62, 174);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(68, 25);
            lblCarnet.TabIndex = 17;
            lblCarnet.Text = "Carnet";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(320, 133);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(310, 23);
            txtNombre.TabIndex = 16;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F);
            lblNombre.Location = new Point(62, 128);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(81, 25);
            lblNombre.TabIndex = 15;
            lblNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(320, 86);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(310, 23);
            txtApellido.TabIndex = 14;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 14.25F);
            lblApellido.Location = new Point(62, 81);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(82, 25);
            lblApellido.TabIndex = 13;
            lblApellido.Text = "Apellido";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(320, 44);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(310, 23);
            txtDni.TabIndex = 12;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 14.25F);
            lblDni.Location = new Point(62, 39);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(111, 25);
            lblDni.TabIndex = 11;
            lblDni.Text = "Ingrese DNI";
            // 
            // txtImporte
            // 
            txtImporte.Enabled = false;
            txtImporte.Location = new Point(320, 224);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(310, 23);
            txtImporte.TabIndex = 22;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 14.25F);
            lblImporte.Location = new Point(62, 219);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(78, 25);
            lblImporte.TabIndex = 21;
            lblImporte.Text = "Importe";
            // 
            // frmPagar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtImporte);
            Controls.Add(lblImporte);
            Controls.Add(btnPagar);
            Controls.Add(btnSalir);
            Controls.Add(txtCarnet);
            Controls.Add(lblCarnet);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Name = "frmPagar";
            Text = "PAGAR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPagar;
        private Button btnSalir;
        private TextBox txtCarnet;
        private Label lblCarnet;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtDni;
        private Label lblDni;
        private TextBox txtImporte;
        private Label lblImporte;
    }
}