namespace proyectoClub
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblConexion = new Label();
            lblNombre = new Label();
            lblClave = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnEnviar = new Button();
            btnConectar = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblConexion
            // 
            lblConexion.AutoSize = true;
            lblConexion.Location = new Point(122, 24);
            lblConexion.Name = "lblConexion";
            lblConexion.Size = new Size(67, 15);
            lblConexion.TabIndex = 0;
            lblConexion.Text = "CONEXIÓN";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(31, 97);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(147, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre de Usuario";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 12F);
            lblClave.Location = new Point(89, 131);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(89, 21);
            lblClave.TabIndex = 2;
            lblClave.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(193, 99);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(172, 23);
            txtUsuario.TabIndex = 3;
            txtUsuario.Text = "Ingrese Nombre de Usuario";
            txtUsuario.Enter += txtNombre_Text_Enter;
            txtUsuario.Leave += txtNombre_Leave;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(193, 131);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(172, 23);
            txtClave.TabIndex = 4;
            txtClave.Text = "Ingrese su contraseña";
            txtClave.Enter += txtClave_Enter;
            txtClave.Leave += txtClave_Leave;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(0, 0);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 0;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(283, 192);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(82, 23);
            btnConectar.TabIndex = 5;
            btnConectar.Text = "CONECTAR";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(151, 170);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(0, 15);
            lblResultado.TabIndex = 6;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 243);
            Controls.Add(lblResultado);
            Controls.Add(btnConectar);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(lblNombre);
            Controls.Add(lblConexion);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConexion;
        private Label lblNombre;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnEnviar;
        private Button btnConectar;
        private Label lblResultado;
    }
}
