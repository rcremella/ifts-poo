namespace proyectoClub
{
    partial class frmListarVencimientos
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
            components = new System.ComponentModel.Container();
            btnImprimir = new Button();
            frmRegistrarClienteBindingSource = new BindingSource(components);
            dgvVencimientos = new DataGridView();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)frmRegistrarClienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(470, 400);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(176, 23);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "IMPRIMIR VENCIMIENTOS";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // frmRegistrarClienteBindingSource
            // 
            frmRegistrarClienteBindingSource.DataSource = typeof(frmRegistrarCliente);
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(31, 52);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.Size = new Size(717, 284);
            dgvVencimientos.TabIndex = 11;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(673, 400);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 20;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmListarVencimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnImprimir);
            Name = "frmListarVencimientos";
            Text = "Listar Vencimientos";
            ((System.ComponentModel.ISupportInitialize)frmRegistrarClienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnImprimir;
        private BindingSource frmRegistrarClienteBindingSource;
        private DataGridView dgvVencimientos;
        private Button btnSalir;
    }
}