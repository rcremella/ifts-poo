namespace proyectoClub
{
    partial class frmOpcionesGestion
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
            btnRegistrar = new Button();
            btnCobrar = new Button();
            btnListarVto = new Button();
            btnCarnet = new Button();
            lblDescripcionUsuario = new Label();
            SuspendLayout();
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Red;
            btnRegistrar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnRegistrar.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrar.Location = new Point(148, 64);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(183, 115);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar Persona";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += button1_Click;
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.Red;
            btnCobrar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCobrar.ForeColor = SystemColors.ButtonHighlight;
            btnCobrar.Location = new Point(471, 64);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(183, 115);
            btnCobrar.TabIndex = 2;
            btnCobrar.Text = "Cobrar Cuota";
            btnCobrar.UseVisualStyleBackColor = false;
            // 
            // btnListarVto
            // 
            btnListarVto.BackColor = Color.Red;
            btnListarVto.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnListarVto.ForeColor = SystemColors.ButtonHighlight;
            btnListarVto.Location = new Point(471, 234);
            btnListarVto.Name = "btnListarVto";
            btnListarVto.Size = new Size(183, 115);
            btnListarVto.TabIndex = 4;
            btnListarVto.Text = "Listar Vencimientos";
            btnListarVto.UseVisualStyleBackColor = false;
            // 
            // btnCarnet
            // 
            btnCarnet.BackColor = Color.Red;
            btnCarnet.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCarnet.ForeColor = SystemColors.ButtonHighlight;
            btnCarnet.Location = new Point(148, 234);
            btnCarnet.Name = "btnCarnet";
            btnCarnet.Size = new Size(183, 115);
            btnCarnet.TabIndex = 3;
            btnCarnet.Text = "Entregar Carnet";
            btnCarnet.UseVisualStyleBackColor = false;
            // 
            // lblDescripcionUsuario
            // 
            lblDescripcionUsuario.AutoSize = true;
            lblDescripcionUsuario.Location = new Point(21, 9);
            lblDescripcionUsuario.Name = "lblDescripcionUsuario";
            lblDescripcionUsuario.Size = new Size(53, 15);
            lblDescripcionUsuario.TabIndex = 5;
            lblDescripcionUsuario.Text = "Usuario: ";
            // 
            // frmOpcionesGestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDescripcionUsuario);
            Controls.Add(btnListarVto);
            Controls.Add(btnCarnet);
            Controls.Add(btnCobrar);
            Controls.Add(btnRegistrar);
            Name = "frmOpcionesGestion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión Club";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegistrar;
        private Button btnCobrar;
        private Button btnListarVto;
        private Button btnCarnet;
        private Label lblDescripcionUsuario;
    }
}