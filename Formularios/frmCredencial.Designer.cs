namespace proyectoClub
{
    partial class frmCredencial
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
            pnlCredencial = new Panel();
            pnlEncabezado = new Panel();
            lblClub = new Label();
            lblTipoCredencial = new Label();
            pbFoto = new PictureBox();
            lblNombreSocio = new Label();
            lblTituloDocumento = new Label();
            lblDocumento = new Label();
            lblTituloCarnet = new Label();
            lblCarnet = new Label();
            lblTituloEntrega = new Label();
            lblEntrega = new Label();
            lblMensaje = new Label();
            btnImprimir = new Button();
            btnVolver = new Button();
            pnlCredencial.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // pnlCredencial
            // 
            pnlCredencial.BackColor = Color.White;
            pnlCredencial.BorderStyle = BorderStyle.FixedSingle;
            pnlCredencial.Controls.Add(pnlEncabezado);
            pnlCredencial.Controls.Add(pbFoto);
            pnlCredencial.Controls.Add(lblNombreSocio);
            pnlCredencial.Controls.Add(lblTituloDocumento);
            pnlCredencial.Controls.Add(lblDocumento);
            pnlCredencial.Controls.Add(lblTituloCarnet);
            pnlCredencial.Controls.Add(lblCarnet);
            pnlCredencial.Controls.Add(lblTituloEntrega);
            pnlCredencial.Controls.Add(lblEntrega);
            pnlCredencial.Location = new Point(20, 20);
            pnlCredencial.Name = "pnlCredencial";
            pnlCredencial.Size = new Size(400, 210);
            pnlCredencial.TabIndex = 0;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(31, 56, 100);
            pnlEncabezado.Controls.Add(lblClub);
            pnlEncabezado.Controls.Add(lblTipoCredencial);
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(398, 56);
            pnlEncabezado.TabIndex = 0;
            // 
            // lblClub
            // 
            lblClub.AutoSize = true;
            lblClub.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClub.ForeColor = Color.White;
            lblClub.Location = new Point(14, 6);
            lblClub.Name = "lblClub";
            lblClub.Size = new Size(171, 25);
            lblClub.TabIndex = 0;
            lblClub.Text = "CLUB DEPORTIVO";
            // 
            // lblTipoCredencial
            // 
            lblTipoCredencial.AutoSize = true;
            lblTipoCredencial.Font = new Font("Segoe UI", 9F);
            lblTipoCredencial.ForeColor = Color.White;
            lblTipoCredencial.Location = new Point(16, 33);
            lblTipoCredencial.Name = "lblTipoCredencial";
            lblTipoCredencial.Size = new Size(131, 15);
            lblTipoCredencial.TabIndex = 1;
            lblTipoCredencial.Text = "CREDENCIAL DE SOCIO";
            // 
            // pbFoto
            // 
            pbFoto.BackColor = Color.Gainsboro;
            pbFoto.BorderStyle = BorderStyle.FixedSingle;
            pbFoto.Location = new Point(16, 72);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(90, 116);
            pbFoto.TabIndex = 1;
            pbFoto.TabStop = false;
            // 
            // lblNombreSocio
            // 
            lblNombreSocio.AutoSize = true;
            lblNombreSocio.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNombreSocio.Location = new Point(122, 72);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(0, 25);
            lblNombreSocio.TabIndex = 2;
            // 
            // lblTituloDocumento
            // 
            lblTituloDocumento.AutoSize = true;
            lblTituloDocumento.Font = new Font("Segoe UI", 9F);
            lblTituloDocumento.ForeColor = Color.DimGray;
            lblTituloDocumento.Location = new Point(122, 118);
            lblTituloDocumento.Name = "lblTituloDocumento";
            lblTituloDocumento.Size = new Size(70, 15);
            lblTituloDocumento.TabIndex = 3;
            lblTituloDocumento.Text = "Documento";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDocumento.Location = new Point(210, 118);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(0, 15);
            lblDocumento.TabIndex = 4;
            // 
            // lblTituloCarnet
            // 
            lblTituloCarnet.AutoSize = true;
            lblTituloCarnet.Font = new Font("Segoe UI", 9F);
            lblTituloCarnet.ForeColor = Color.DimGray;
            lblTituloCarnet.Location = new Point(122, 143);
            lblTituloCarnet.Name = "lblTituloCarnet";
            lblTituloCarnet.Size = new Size(59, 15);
            lblTituloCarnet.TabIndex = 5;
            lblTituloCarnet.Text = "Carnet N°";
            // 
            // lblCarnet
            // 
            lblCarnet.AutoSize = true;
            lblCarnet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCarnet.Location = new Point(210, 143);
            lblCarnet.Name = "lblCarnet";
            lblCarnet.Size = new Size(0, 15);
            lblCarnet.TabIndex = 6;
            // 
            // lblTituloEntrega
            // 
            lblTituloEntrega.AutoSize = true;
            lblTituloEntrega.Font = new Font("Segoe UI", 9F);
            lblTituloEntrega.ForeColor = Color.DimGray;
            lblTituloEntrega.Location = new Point(122, 168);
            lblTituloEntrega.Name = "lblTituloEntrega";
            lblTituloEntrega.Size = new Size(47, 15);
            lblTituloEntrega.TabIndex = 7;
            lblTituloEntrega.Text = "Entrega";
            // 
            // lblEntrega
            // 
            lblEntrega.AutoSize = true;
            lblEntrega.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEntrega.Location = new Point(210, 168);
            lblEntrega.Name = "lblEntrega";
            lblEntrega.Size = new Size(0, 15);
            lblEntrega.TabIndex = 8;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(20, 245);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 15);
            lblMensaje.TabIndex = 1;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(226, 258);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(92, 23);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(328, 258);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 23);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmCredencial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 305);
            Controls.Add(btnVolver);
            Controls.Add(btnImprimir);
            Controls.Add(lblMensaje);
            Controls.Add(pnlCredencial);
            Name = "frmCredencial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Credencial de socio";
            Load += frmCredencial_Load;
            pnlCredencial.ResumeLayout(false);
            pnlCredencial.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCredencial;
        private Panel pnlEncabezado;
        private Label lblClub;
        private Label lblTipoCredencial;
        private PictureBox pbFoto;
        private Label lblNombreSocio;
        private Label lblTituloDocumento;
        private Label lblDocumento;
        private Label lblTituloCarnet;
        private Label lblCarnet;
        private Label lblTituloEntrega;
        private Label lblEntrega;
        private Label lblMensaje;
        private Button btnImprimir;
        private Button btnVolver;
    }
}
