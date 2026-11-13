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
            btnImprimir = new Button();
            dgvVencimientos = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(474, 367);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(176, 23);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "IMPRIMIR VENCIMIENTOS";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(31, 52);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.Size = new Size(717, 284);
            dgvVencimientos.TabIndex = 11;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(656, 367);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 23);
            btnVolver.TabIndex = 20;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmListarVencimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 429);
            Controls.Add(btnVolver);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnImprimir);
            Name = "frmListarVencimientos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Vencimientos";
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnImprimir;
        private DataGridView dgvVencimientos;
        private Button btnVolver;
    }
}