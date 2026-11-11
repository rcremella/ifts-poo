namespace proyectoClub.Formularios
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
            lblDni = new Label();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtCarnet = new TextBox();
            lblCarnet = new Label();
            btnSalir = new Button();
            btnImprimir = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 14.25F);
            lblDni.Location = new Point(87, 41);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(191, 25);
            lblDni.TabIndex = 0;
            lblDni.Text = "Ingrese DNI del socio";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(345, 46);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(310, 23);
            txtDni.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(345, 88);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(310, 23);
            txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 14.25F);
            lblApellido.Location = new Point(87, 83);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(82, 25);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(345, 135);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(310, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F);
            lblNombre.Location = new Point(87, 130);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(81, 25);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // txtCarnet
            // 
            txtCarnet.Enabled = false;
            txtCarnet.Location = new Point(345, 181);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(310, 23);
            txtCarnet.TabIndex = 7;
            // 
            // lblCarnet
            // 
            lblCarnet.AutoSize = true;
            lblCarnet.Font = new Font("Segoe UI", 14.25F);
            lblCarnet.Location = new Point(87, 176);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(68, 25);
            lblCarnet.TabIndex = 6;
            lblCarnet.Text = "Carnet";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(689, 391);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(507, 391);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(176, 23);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "IMPRIMIR CARNET";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(537, 243);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(118, 29);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Entregado";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmEntregarCarnet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox1);
            Controls.Add(btnImprimir);
            Controls.Add(btnSalir);
            Controls.Add(txtCarnet);
            Controls.Add(lblCarnet);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Enabled = false;
            Name = "frmEntregarCarnet";
            Text = "Entregar Carnet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDni;
        private TextBox txtDni;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtCarnet;
        private Label lblCarnet;
        private Button btnSalir;
        private Button btnImprimir;
        private CheckBox checkBox1;
    }
}