namespace SubastaWinForms.Views
{
    partial class SubastadorView
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
            Subastaslbl = new Label();
            dgvSubastas = new DataGridView();
            lblSubastador = new Label();
            lblArticulo = new Label();
            lblSubastaDetalle = new Label();
            txtArticuloNombre = new TextBox();
            txtArticuloDetalle = new TextBox();
            txtMontoInicial = new TextBox();
            txtPujaDeAumento = new TextBox();
            btnIniciarSubasta = new Button();
            txtDuracion = new TextBox();
            lblSubastadorActivo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).BeginInit();
            SuspendLayout();
            // 
            // Subastaslbl
            // 
            Subastaslbl.AutoSize = true;
            Subastaslbl.Font = new Font("Segoe UI", 20F);
            Subastaslbl.Location = new Point(12, 9);
            Subastaslbl.Name = "Subastaslbl";
            Subastaslbl.Size = new Size(151, 46);
            Subastaslbl.TabIndex = 0;
            Subastaslbl.Text = "Subastas";
            Subastaslbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvSubastas
            // 
            dgvSubastas.AllowUserToAddRows = false;
            dgvSubastas.AllowUserToDeleteRows = false;
            dgvSubastas.AllowUserToResizeColumns = false;
            dgvSubastas.AllowUserToResizeRows = false;
            dgvSubastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubastas.Location = new Point(12, 302);
            dgvSubastas.MultiSelect = false;
            dgvSubastas.Name = "dgvSubastas";
            dgvSubastas.ReadOnly = true;
            dgvSubastas.RowHeadersWidth = 40;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.Size = new Size(1418, 385);
            dgvSubastas.TabIndex = 100;
            dgvSubastas.VirtualMode = true;
            dgvSubastas.SelectionChanged += dgvSubastas_SelectionChanged;
            // 
            // lblSubastador
            // 
            lblSubastador.AutoSize = true;
            lblSubastador.Font = new Font("Segoe UI", 14F);
            lblSubastador.Location = new Point(101, 117);
            lblSubastador.Name = "lblSubastador";
            lblSubastador.Size = new Size(206, 32);
            lblSubastador.TabIndex = 8;
            lblSubastador.Text = "Subastador Activo";
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Font = new Font("Segoe UI", 14F);
            lblArticulo.Location = new Point(540, 117);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(96, 32);
            lblArticulo.TabIndex = 9;
            lblArticulo.Text = "Articulo";
            // 
            // lblSubastaDetalle
            // 
            lblSubastaDetalle.AutoSize = true;
            lblSubastaDetalle.Font = new Font("Segoe UI", 14F);
            lblSubastaDetalle.Location = new Point(1033, 117);
            lblSubastaDetalle.Name = "lblSubastaDetalle";
            lblSubastaDetalle.Size = new Size(89, 32);
            lblSubastaDetalle.TabIndex = 10;
            lblSubastaDetalle.Text = "Detalle";
            // 
            // txtArticuloNombre
            // 
            txtArticuloNombre.Location = new Point(540, 161);
            txtArticuloNombre.Name = "txtArticuloNombre";
            txtArticuloNombre.PlaceholderText = "Nombre";
            txtArticuloNombre.Size = new Size(133, 27);
            txtArticuloNombre.TabIndex = 3;
            // 
            // txtArticuloDetalle
            // 
            txtArticuloDetalle.Location = new Point(540, 194);
            txtArticuloDetalle.Name = "txtArticuloDetalle";
            txtArticuloDetalle.PlaceholderText = "Detalle";
            txtArticuloDetalle.Size = new Size(133, 27);
            txtArticuloDetalle.TabIndex = 4;
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(1033, 161);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.PlaceholderText = "Monto Inicial";
            txtMontoInicial.Size = new Size(145, 27);
            txtMontoInicial.TabIndex = 5;
            // 
            // txtPujaDeAumento
            // 
            txtPujaDeAumento.Location = new Point(1033, 194);
            txtPujaDeAumento.Name = "txtPujaDeAumento";
            txtPujaDeAumento.PlaceholderText = "Puja de Aumento";
            txtPujaDeAumento.Size = new Size(145, 27);
            txtPujaDeAumento.TabIndex = 6;
            // 
            // btnIniciarSubasta
            // 
            btnIniciarSubasta.BackColor = Color.Lime;
            btnIniciarSubasta.ForeColor = SystemColors.ButtonHighlight;
            btnIniciarSubasta.Location = new Point(1312, 161);
            btnIniciarSubasta.Name = "btnIniciarSubasta";
            btnIniciarSubasta.Size = new Size(118, 65);
            btnIniciarSubasta.TabIndex = 8;
            btnIniciarSubasta.Text = "INICIAR SUBASTA";
            btnIniciarSubasta.UseVisualStyleBackColor = false;
            btnIniciarSubasta.Click += btnIniciarSubasta_Click;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(1033, 227);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.PlaceholderText = "Duración en minutos";
            txtDuracion.Size = new Size(145, 27);
            txtDuracion.TabIndex = 7;
            // 
            // lblSubastadorActivo
            // 
            lblSubastadorActivo.AutoSize = true;
            lblSubastadorActivo.Font = new Font("Segoe UI", 16F);
            lblSubastadorActivo.ForeColor = Color.DarkRed;
            lblSubastadorActivo.Location = new Point(158, 169);
            lblSubastadorActivo.Name = "lblSubastadorActivo";
            lblSubastadorActivo.Size = new Size(0, 37);
            lblSubastadorActivo.TabIndex = 101;
            // 
            // SubastadorView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 699);
            Controls.Add(lblSubastadorActivo);
            Controls.Add(txtDuracion);
            Controls.Add(btnIniciarSubasta);
            Controls.Add(txtPujaDeAumento);
            Controls.Add(txtMontoInicial);
            Controls.Add(txtArticuloDetalle);
            Controls.Add(txtArticuloNombre);
            Controls.Add(lblSubastaDetalle);
            Controls.Add(lblArticulo);
            Controls.Add(lblSubastador);
            Controls.Add(dgvSubastas);
            Controls.Add(Subastaslbl);
            Name = "SubastadorView";
            Text = "SubastadorView";
            Load += SubastadorView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubastas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Subastaslbl;
        private DataGridView dgvSubastas;
        private Label lblSubastador;
        private Label lblArticulo;
        private Label lblSubastaDetalle;
        private TextBox txtArticuloNombre;
        private TextBox txtArticuloDetalle;
        private TextBox txtMontoInicial;
        private TextBox txtPujaDeAumento;
        private Button btnIniciarSubasta;
        private TextBox txtDuracion;
        private Label lblSubastadorActivo;
    }
}